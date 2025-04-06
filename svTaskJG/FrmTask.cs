using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Diagnostics.SymbolStore;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace svTaskJG
{
    
    public partial class FrmTask : Form
    {
        private string connectionString = "Data Source=dbtask.s3db;Version=3;";
        public FrmTask()
        {
            InitializeComponent();
            CrearTablaSiNoExiste();
           
        }
        private void CrearTablaSiNoExiste()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Servicios (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Endpoints (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Url TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS Empresas (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Nombre TEXT NOT NULL
                );";
                    command.ExecuteNonQuery();
                }
            }
            CargarDatos();
        }

        private void CargarDatos()
        {
            CargarListBox("SELECT Nombre FROM Servicios", lvServicos);
            CargarListBox("SELECT Url FROM Endpoints", lvEnspoints);
            CargarListBox("SELECT Nombre FROM Empresas", lvEmpresas);
            //leer valores de configuracion
            var configuracion = LeerConfiguracion();
            txtID.Text= configuracion.Id.ToString();
            lblValor.Text= "ID Actualizar: "+ configuracion.Id.ToString();
            tmHora.Text= configuracion.Hora.ToString();
            chVolverActualizar.Checked = configuracion.Actualizar;
        }

        // Método genérico para cargar datos en un ListBox
        private void CargarListBox(string query, ListBox listBox)
        {
            listBox.Items.Clear();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listBox.Items.Add(reader[0].ToString());
                        }
                    }
                }
            }
        }
        // Método para insertar un registro en la base de datos
        private void InsertarRegistro(string query, string valor, ListBox listBox)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@valor", valor);
                    command.ExecuteNonQuery();
                }
            }
            string QUERY = listBox.Name == "lvServicos" ? "SELECT Nombre FROM Servicios" : listBox.Name == "lvEnspoints" ? "SELECT Url FROM Endpoints" : "SELECT Nombre FROM Empresas";
            
            CargarListBox(QUERY, listBox); // Recargar ListBox
        }

        private void btnAgregarServicos_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtServicios.Text))
            {
                string query = "INSERT INTO Servicios (Nombre) VALUES (@valor)";
                InsertarRegistro(query, txtServicios.Text, lvServicos);
                txtServicios.Clear();
            }
        }

        private void btnAgregarEndpoint_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEndPonint.Text))
            {
                string query = "INSERT INTO Endpoints (Url) VALUES (@valor)";
                InsertarRegistro(query, txtEndPonint.Text, lvEnspoints);
                txtEndPonint.Clear();
            }
        }

        private void btnAgregarEmpresas_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmpresas.Text))
            {
                string query = "INSERT INTO Empresas (Nombre) VALUES (@valor)";
                InsertarRegistro(query, txtEmpresas.Text, lvEmpresas);
                txtEmpresas.Clear();
            }
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
        public void ActualizarConfiguracion(long id, bool actualizar, TimeSpan hora)
        {
            // Actualizar los valores en el archivo de configuración
            TaskConfig.Default.id = id;
            TaskConfig.Default.actualizar = actualizar;
            TaskConfig.Default.hora = hora;

            // Guardar los cambios
            TaskConfig.Default.Save();
        }

        private void btnActualizarCambios_Click(object sender, EventArgs e)
        {
            TimeSpan nuevaHora = tmHora.Value.TimeOfDay;
            ActualizarConfiguracion(long.Parse(txtID.Text), chVolverActualizar.Checked, nuevaHora);
            // Mostrar un mensaje de éxito
            MessageBox.Show("Configuración actualizada correctamente. La aplicación se reiniciará.","Team Code");

            // Reiniciar la aplicación
            Application.Restart();
        }
    }
}
