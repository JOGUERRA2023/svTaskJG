using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using svTaskJG.Models;

namespace svTaskJG.ConexionAPI
{
    public class ConexionWebAPI
    {
        public string VerificaApi(string apiFuncion, string url_api)
        {
            string[] prefijosPermitidos = { "inve/", "comp/", "vent/", "rrhh/", "gnrl/", "empr/", "prod/", "flot/" };
            foreach (string prefijo in prefijosPermitidos)
            {
                if (apiFuncion.StartsWith(prefijo))
                {
                    return url_api;
                }
            }
            return Constantes.Constantes.url_spring;
        }

        public async Task<string> ConectarAPISpringBoot(HttpMethod tipo_metodo, bool requeire_tocken, string url_api, string funcion, string parametros, string empresa)
        {
            Constantes.Constantes.MensajeError = "OK";
            string rptjson = "";
            try
            {
                string Ruta_API = url_api;// VerificaApi(funcion, url_api);
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri(Ruta_API);
                var uri = new Uri(Ruta_API + funcion);
                var request = new HttpRequestMessage(tipo_metodo, uri);
                var json = parametros;
                if (json != "")
                {
                    var contentJSON = new StringContent(json, Encoding.UTF8, "application/json");
                    request.Content = contentJSON;
                }
                if (requeire_tocken)
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", Constantes.Constantes.token);
                    request.Headers.Add("id_empresa", empresa);
                }
                var response = await client.SendAsync(request);
                switch (response.StatusCode)
                {
                    case HttpStatusCode.OK:
                        var jsonString = await response.Content.ReadAsStringAsync();
                        if (jsonString != "")
                        {
                            try
                            {
                                rptjson = jsonString;
                            }
                            catch (Exception)
                            {
                                Constantes.Constantes.MensajeError = "Error al obtener los datos del servidor..!";
                                rptjson = "No hay conexión con el servidor";
                            }
                        }
                        break;
                    case HttpStatusCode.Unauthorized:
                        Constantes.Constantes.MensajeError = "tocken";
                        rptjson = "tocken vencido";
                        break;
                    case HttpStatusCode.NotFound:
                        Constantes.Constantes.MensajeError = "El EndPoint que está consumiendo no existe..!";
                        rptjson = "funcion no existe";
                        break;
                    case HttpStatusCode.MethodNotAllowed:
                        Constantes.Constantes.MensajeError = "El metodo http que ha invocado no es el correcto..!";
                        rptjson = "funcion no existe";
                        break;
                    case HttpStatusCode.InternalServerError:
                        Constantes.Constantes.MensajeError = "Ocurrió un error en interno el servidor..!";
                        rptjson = "Acceso no autorizado";
                        break;
                    case HttpStatusCode.BadRequest:
                        Constantes.Constantes.MensajeError = "Estás enviando parametros incorrectos..!";
                        rptjson = "Acceso no autorizado";
                        break;
                    default:
                        Constantes.Constantes.MensajeError = "Error de conexión con el servidor..!";
                        rptjson = "Acceso no autorizado";
                        break;
                }

                return rptjson;
            }
            catch
            {
                rptjson = "No hay conexión con el servidor..!";
                Constantes.Constantes.MensajeError = "No hay conexión con el servidor..!";
                return rptjson;
            }
        }
        public async Task<string> ConsumirSpringBoot(HttpMethod tipo_metodo, bool requeire_tocken, string url_api, string funcion, string parametros, string empresa)
        {
            string data = "";
            try
            {
                if (Constantes.Constantes.token.Trim().Length == 0)
                {
                    await obtenerToken();
                }
                data = await ConectarAPISpringBoot(tipo_metodo, requeire_tocken, url_api, funcion, parametros, empresa);
                if (Constantes.Constantes.MensajeError == "tocken")
                {
                    bool estado = await obtenerToken();
                    if (estado) data = await ConectarAPISpringBoot(tipo_metodo, requeire_tocken, url_api, funcion, parametros, empresa);
                }
            }
            catch
            {
                Constantes.Constantes.MensajeError = "No fue posible obtener la data..!";
                data = "No hay conexión con el servidor";
            }
            return data;
        }
        public async Task<bool> obtenerToken()
        {
            string data = "";
            var data_user = new
            {
                username = "admin",
                password = "123"
            };

            string parametros = JsonConvert.SerializeObject(data_user);
            data = await ConectarAPISpringBoot(HttpMethod.Post, false, Constantes.Constantes.url_spring, "auth/acceso/iniciarSesion", parametros, "");
            if (Constantes.Constantes.MensajeError == "OK")
            {
                UserCredenciales ArrayDatosLogueo = new UserCredenciales();
                await Task.Run(() =>
                {
                    ArrayDatosLogueo = JsonConvert.DeserializeObject<UserCredenciales>(data);
                });

                if (Constantes.Constantes.MensajeError == "OK")
                {
                    if (ArrayDatosLogueo.mensaje == "OK")
                    {
                        if (ArrayDatosLogueo.id != -1 && ArrayDatosLogueo.tipoDeToken != null && ArrayDatosLogueo.tokenDeAcceso != "" && ArrayDatosLogueo.tipoDeToken != null)
                        {
                            Constantes.Constantes.token = ArrayDatosLogueo.tokenDeAcceso;
                            return true;
                        }
                        else
                        {
                            await obtenerToken();
                        }
                    }
                }

            }
            return false;
        }
    }
}
