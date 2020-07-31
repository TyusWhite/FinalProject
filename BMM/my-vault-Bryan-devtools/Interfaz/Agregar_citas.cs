using DentalCare_System.DB;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DentalCare_System.Interfaz
{
    public partial class Agregar_citas : Form
    {
        public Agregar_citas()
        {
            InitializeComponent();
        }

        private void Agregar_citas_Load(object sender, EventArgs e)
        {
            cargarDoctor();
            cargarPaciente();

        }
        private void cargarDoctor()
        {

            try
            {
                MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                MySqlCommand comando = new MySqlCommand("SELECT id,concat(nombre,' ',apellido) As doctor FROM doctor", conexiondb);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                //Para que no se modifiquen los campos
                CmbDoctor.DropDownStyle = ComboBoxStyle.DropDownList;

                CmbDoctor.DisplayMember = "doctor".ToString();
                CmbDoctor.ValueMember = "id".ToString();
                da.Fill(dt);
                CmbDoctor.DataSource = dt;
                CmbDoctor.Focus();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error de lectura. " + ex.Message);
            }
        }
        private void cargarPaciente()
        {

            try
            {
                MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                MySqlCommand comando = new MySqlCommand("SELECT id,concat(nombre,' ',apellido) As paciente FROM paciente", conexiondb);

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                //Para que no se modifiquen los campos
                CmbPaciente.DropDownStyle = ComboBoxStyle.DropDownList;

                CmbPaciente.DisplayMember = "paciente".ToString();
                CmbPaciente.ValueMember = "id".ToString();
                da.Fill(dt);
                CmbPaciente.DataSource = dt;
                CmbPaciente.Focus();
            }

            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error de lectura. " + ex.Message);
            }
        }

        

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            //Creando las variables
            int paciente = Convert.ToInt32(CmbPaciente.SelectedValue);
            int doctor = Convert.ToInt32(CmbDoctor.SelectedValue);
            string fecha = Convert.ToDateTime(TxtFecha.Text).ToString("yy-MM-dd");
            string motivo = TxtMotivo.Text;
            string hora = Convert.ToDateTime(TxtHora.Text).ToLongTimeString();




            if (paciente != 0 && doctor != 0 && fecha != "" && hora != "" && motivo != "")
            {

                string sql = "INSERT INTO citas ( hora,id_paciente,id_doctor,descripcion,fecha,estado)" +
                    "VALUES ('" + hora + "','" + paciente + "', '" + doctor + "', '" + motivo + "', '" + fecha + "',1)";

                MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                conexiondb.Open();

                try
                {
                    MySqlCommand comando = new MySqlCommand(sql, conexiondb);

                    comando.ExecuteNonQuery();

                    MessageBox.Show("Datos guardados", "Información", MessageBoxButtons.OK);
                    /*  Doctor_Load(null, null);
                      Borrar();
                      EditarAñadirGuardar(false);
                      ListaDoctores.Enabled = true;*/

                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("Error de información " + ex.Message);
                }
                finally
                {
                    conexiondb.Close();
                }
                Agregar_citas_Load(null, null);
            }

        }
    }
}
