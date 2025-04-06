using Newtonsoft.Json;
using svTaskJG.ConexionAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace svTaskJG.ConsumirAPI
{
    public class ConsumirAPI
    {
        ConexionWebAPI ws = new ConexionWebAPI();
        public async Task<bool> PutData(string url_api, string funcion, string parametros = "", string empresa = "")
        {
            string data = "";
            dynamic data_dynamic = null;
            try
            {
                data = await ws.ConsumirSpringBoot(HttpMethod.Put, true, url_api, funcion, parametros, empresa);
                if (Constantes.Constantes.MensajeError == "OK")
                {
                    await Task.Run(() =>
                    {
                        data_dynamic = JsonConvert.DeserializeObject<dynamic>(data);
                    });
                }
                if (data_dynamic == null)
                    return false;
                if (data_dynamic["id"] != 0)
                    return false;
                return true;
            }
            catch
            {
                Constantes.Constantes.MensajeError = "No fue posible obtener la data..!";
                return false;
            }

        }
    }
}
