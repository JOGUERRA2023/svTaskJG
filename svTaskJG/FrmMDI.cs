using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Data.SQLite;
using Newtonsoft.Json;
using System.Globalization;
using System.IO;

namespace svTaskJG
{
    public partial class FrmMDI : Form
    {
        private string connectionString = "Data Source=dbtask.s3db;Version=3;";
        int errores_totales = 0;
        long ID = 0;
        public FrmMDI()
        {
            InitializeComponent();
            var configuracion = LeerConfiguracion();
            ID = configuracion.Id;
            tmTiempo.Interval = 60000; // 1 minuto
            tmTiempo.Start();
        }
        public (long Id, bool Actualizar, TimeSpan Hora) LeerConfiguracion()
        {
            // Leer los valores desde el archivo de configuración
            long id = TaskConfig.Default.id;
            bool actualizar = TaskConfig.Default.actualizar;
            TimeSpan hora = TaskConfig.Default.hora;

            // Devolver los valores como una tupla
            return (id, actualizar, hora);
        }
        public void ActualizarConfiguracion(long id)
        {
            TaskConfig.Default.id = id;
            TaskConfig.Default.Save();
        }
        public (decimal Compra, decimal Venta) getObtenerTipoCambio()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless"); // Modo sin cabeza
            chromeOptions.AddArgument("--disable-gpu");
            chromeOptions.AddArgument("--no-sandbox");
            chromeOptions.AddArgument("--ignore-certificate-errors");
            chromeOptions.AddArgument("user-agent=Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/91.0.4472.124 Safari/537.36");

            // Especifica la ruta a tu ChromeDriver
            var chromeDriverPath = "D:\\chromedriver\\chromedriver.exe";

            // Inicializar el navegador
            var driver = new ChromeDriver(chromeDriverPath, chromeOptions);

            try
            {
                // Abrir la página de SUNAT
                driver.Navigate().GoToUrl("https://e-consulta.sunat.gob.pe/cl-at-ittipcam/tcS01Alias");

                // Esperar a que la página cargue completamente
                Thread.Sleep(10000); // 10 segundos

                // Localizar la tabla que contiene los valores del tipo de cambio
                var tabla = driver.FindElement(By.ClassName("calendar-table"));

                // Extraer las filas de la tabla
                var filas = tabla.FindElements(By.TagName("tr"));

                // Variables para almacenar los últimos valores de compra y venta
                string ultimoCompra = null;
                string ultimoVenta = null;

                // Recorrer las filas para encontrar los valores de compra y venta
                foreach (var fila in filas)
                {
                    var celdas = fila.FindElements(By.TagName("td"));
                    foreach (var celda in celdas)
                    {
                        // Buscar los elementos que contienen los valores de compra y venta
                        var eventos = celda.FindElements(By.ClassName("event"));
                        foreach (var evento in eventos)
                        {
                            if (evento.GetAttribute("title").Contains("Tipo de Cambio"))
                            {
                                var texto = evento.Text;
                                if (texto.Contains("Compra"))
                                {
                                    ultimoCompra = texto.Split().Last(); // Actualizar el último valor de compra
                                }
                                else if (texto.Contains("Venta"))
                                {
                                    ultimoVenta = texto.Split().Last(); // Actualizar el último valor de venta
                                }
                            }
                        }
                    }
                }

                // Devolver los valores de compra y venta
                if (!string.IsNullOrEmpty(ultimoCompra) && !string.IsNullOrEmpty(ultimoVenta))
                {
                    decimal compra = decimal.Parse(ultimoCompra, CultureInfo.InvariantCulture);
                    decimal venta = decimal.Parse(ultimoVenta, CultureInfo.InvariantCulture);
                    return (compra, venta);
                }
                else
                {
                    throw new Exception("No se encontraron valores de compra o venta.");
                }
            }
            catch (Exception ex)
            {
               
                string errorMessage = "Error al obtener el tipo de cambio: " + ex.Message;

                // Ruta del archivo de texto
                string filePath = @"D:\chromedriver\logs.txt";

                try
                {
                    // Escribir el error en el archivo de texto
                    using (StreamWriter writer = new StreamWriter(filePath, true)) // El parámetro "true" indica que se añadirá al archivo existente
                    {
                        writer.WriteLine(DateTime.Now.ToString() + " - " + errorMessage);
                    }
                   
                }
                catch (Exception ioEx)
                {
                    // Manejar errores al escribir en el archivo
                    Console.WriteLine("Error al escribir en el archivo de logs: " + ioEx.Message);
                }

                // Relanzar la excepción si es necesario
                throw new Exception(errorMessage);
             }
            finally
            {
                // Cerrar el navegador
                driver.Quit();
            }
        }

        private async Task EnviarRegistroAsync(string apiUrl, decimal tipoVenta, decimal tipoCompra, string empresa, long id)
        {
            if (errores_totales > 2)
                return;
            var data = new
            {
                venta = tipoVenta,
                compra = tipoCompra
            };

            bool rpta = await new ConsumirAPI.ConsumirAPI().PutData(apiUrl, "gnrl/tipocambio/" + id.ToString(), JsonConvert.SerializeObject(data), empresa);
            if (!rpta)
            {
                errores_totales++;
                await EnviarRegistroAsync(apiUrl, tipoVenta, tipoCompra, empresa, id);
               
                
            }
            else
            {
                errores_totales = 0;
            }
        }

        private async Task EnviarDatos(List<string> endpoints, List<string> idEmpresas, long id_registro)
        {
            // Crear el NotifyIcon y configurarlo
            notitask = new NotifyIcon();
            notitask.Icon = SystemIcons.Information;  // Icono predeterminado de información
            notitask.Visible = true;  // Mostrar el ícono en la bandeja del sistema
            if (errores_totales > 2)
                return;
            var tipo_cambio = getObtenerTipoCambio();
           
            for (int i = 0; i < endpoints.Count; i++)
            {
                try
                {
                    await EnviarRegistroAsync(endpoints[i], Convert.ToDecimal(tipo_cambio.Venta), Convert.ToDecimal(tipo_cambio.Compra), idEmpresas[i], id_registro);
                }
                catch (Exception ex)
                {
                    string filePath = @"D:\chromedriver\logs.txt";
                    notitask.ShowBalloonTip(3000, "Tipo de Cambio", $"Error al conectar con el endpoint {endpoints[i]}: {ex.Message}", ToolTipIcon.Info);
                    //notitask.Visible = false;
                    
                    try
                    {
                        // Escribir el error en el archivo de texto
                        using (StreamWriter writer = new StreamWriter(filePath, true)) // El parámetro "true" indica que se añadirá al archivo existente
                        {
                            writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message);
                        }

                    }
                    catch (Exception ioEx)
                    {
                        // Manejar errores al escribir en el archivo
                        Console.WriteLine("Error al escribir en el archivo de logs: " + ioEx.Message);
                    }
                }
            }
        }
        private List<string> ObtenerValoresDesdeBD(string query)
        {
            var valores = new List<string>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            valores.Add(reader[0].ToString());
                        }
                    }
                }
            }

            return valores;
        }
        private async void ProcesarDatos(bool actualizarID)
        {
            // Crear el NotifyIcon y configurarlo
            notitask = new NotifyIcon();
            notitask.Icon = SystemIcons.Information;  // Icono predeterminado de información
            notitask.Visible = true;  // Mostrar el ícono en la bandeja del sistema
            try
            {

                // Obtener los endpoints y empresas desde la base de datos
                var endpoints = ObtenerValoresDesdeBD("SELECT Url FROM Endpoints");
                var idEmpresas = ObtenerValoresDesdeBD("SELECT Nombre FROM Empresas");

                // Verificar que las listas tengan la misma longitud
                if (endpoints.Count != idEmpresas.Count)
                {
                    notitask.ShowBalloonTip(3000, "Tipo de Cambio", "Error: La cantidad de endpoints no coincide con la cantidad de empresas.", ToolTipIcon.Info);
                    //notitask.Visible = false;
                    return;
                }
             
                long id_registro = actualizarID ? ID + 1 : ID;

                if (id_registro == 0)
                {
                    notitask.ShowBalloonTip(3000, "Tipo de Cambio", "Error: El ID de Actualización es cero(0).", ToolTipIcon.Info);
                    return;
                }

                // Enviar los datos
                await EnviarDatos(endpoints, idEmpresas, id_registro);

                if (actualizarID)
                {
                    ID = ID + 1;
                    ActualizarConfiguracion(ID);

                }
                    

                // Mostrar la notificación (BalloonTip)
                notitask.ShowBalloonTip(3000, "Tipo de Cambio", "El tipo de cambio fue actualizado correctamente", ToolTipIcon.Info);
               // notitask.Visible = false;
            }
            catch(Exception ex) 
            {
                notitask.ShowBalloonTip(3000, "Tipo de Cambio", ex.Message, ToolTipIcon.Info);
               // notitask.Visible = false;
                string filePath = @"D:\chromedriver\logs.txt";
                try
                {
                    // Escribir el error en el archivo de texto
                    using (StreamWriter writer = new StreamWriter(filePath, true)) // El parámetro "true" indica que se añadirá al archivo existente
                    {
                        writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message);
                    }

                }
                catch (Exception ioEx)
                {
                    // Manejar errores al escribir en el archivo
                    Console.WriteLine("Error al escribir en el archivo de logs: " + ioEx.Message);
                }
            }
           
        }

        private void tmTiempo_Tick(object sender, EventArgs e)
        {
            try
            {
                //Leer valores
                var configuracion = LeerConfiguracion();

                TimeSpan hora1 = configuracion.Hora;
                bool actualizar = configuracion.Actualizar;
                // Obtener la hora actual
                var horaActual = DateTime.Now.TimeOfDay;

                // Definir las horas de ejecución
                //var hora1 = new TimeSpan(17, 0, 0); // 17:00:00
                var hora2 = new TimeSpan(18, 0, 0); // 18:00:00
                if(actualizar==true)
                {
                    ProcesarDatos(false);
                    //Actualizar datos
                    TaskConfig.Default.actualizar = false;
                    TaskConfig.Default.Save();
                    return;
                }

                // Verificar si es la hora de ejecución
                if (horaActual >= hora1 && horaActual < hora1.Add(TimeSpan.FromMinutes(1)))
                {
                    ProcesarDatos(true);
                }
                else if (horaActual >= hora2 && horaActual < hora2.Add(TimeSpan.FromMinutes(1)))
                {
                    ProcesarDatos(false);
                }
            }
            catch (Exception ex)
            {
                notitask.ShowBalloonTip(3000, "Team Code", $"Error al intentar registrar el tipo de cambio: {ex.Message}", ToolTipIcon.Info);
                //notitask.Visible = false;
                string filePath = @"D:\chromedriver\logs.txt";
                try
                {
                    // Escribir el error en el archivo de texto
                    using (StreamWriter writer = new StreamWriter(filePath, true)) // El parámetro "true" indica que se añadirá al archivo existente
                    {
                        writer.WriteLine(DateTime.Now.ToString() + " - " + ex.Message);
                    }

                }
                catch (Exception ioEx)
                {
                    // Manejar errores al escribir en el archivo
                    Console.WriteLine("Error al escribir en el archivo de logs: " + ioEx.Message);
                }
                // MessageBox.Show($"Error al intentar registrar el tipo de cambio: {ex.Message}");
            }
        }

        private void configurarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTask frmTask = new FrmTask();
            frmTask.ShowDialog();
        }

        private void FrmMDI_Load(object sender, EventArgs e)
        {
            this.Hide(); // Oculta el formulario
            notitask.Visible = true;
            notitask.ShowBalloonTip(3000, "Team Code", "Ejecutándose en segundo plano", ToolTipIcon.Info);
           // notitask.Visible = false;
        }

        private void FrmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
           // e.Cancel = true; // Cancela el cierre del formulario
            this.Hide();     // Oculta el formulario en lugar de cerrarlo
            notitask.Visible = true; // Muestra el ícono en la bandeja del sistema
        }

        private void notitask_BalloonTipClosed(object sender, EventArgs e)
        {
            
        }
    }
}
