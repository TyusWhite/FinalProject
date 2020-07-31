using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DentalCare_System.DB;
using MySql.Data.MySqlClient;

namespace DentalCare_System.Interfaz
{
    public partial class Especialidades : Form
    {
        public Especialidades()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string especialidad = TxtEspecialidad.Text;

                if(especialidad != "")
                {
                    string sql = "INSERT INTO especialidad (nombre) VALUES ('" + especialidad + "')";

                    MySqlConnection conexiondb = DbConnection.ObtenerConeccion();

                    conexiondb.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexiondb);


                        comando.ExecuteNonQuery();

                        MessageBox.Show("Datos guardados");
                        TxtEspecialidad.Text = "";
                        TxtEspecialidad.Focus();
                    }
                    catch(MySqlException ex)
                    {
                        MessageBox.Show("Error al guardar. Revise los datos." + ex.Message);
                    }
                    finally
                    {
                        conexiondb.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar el campo.");
                }
            }
            catch(FormatException fex)
            {
                MessageBox.Show("Error de información" + fex.Message);
            }
        }

        private void Especialidades_Load(object sender, EventArgs e)
        {

        }
    }
}
