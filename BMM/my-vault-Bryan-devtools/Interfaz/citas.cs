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
    public partial class Citas : Form
    {
        public Citas()
        {
            InitializeComponent();
        }

        private void CitasLista(string fecha)
        {


            string fechaC = fecha;
            TxtDiaActual.Text = Convert.ToDateTime(fecha).ToShortDateString().ToString();
            if (fechaC != "")
            {
                //Llamar todos los datos al DataGridView
                MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                conexiondb.Open();


                //Variable que va a traer todos los datos de las tablas correspondientes.
                string query = "SELECT c.hora as Hora, c.fecha as Fecha, p.nombre as Paciente, concat(d.nombre,' ',d.apellido) AS Doctor, c.descripcion as Motivo FROM citas as c INNER JOIN paciente as p ON c.id_paciente = p.id INNER JOIN doctor as d ON c.id_doctor = d.id  Where c.fecha = '" + fechaC + "'";


                //Comando que recoge los datos que queremos, y la conexión a la base de datos.
                MySqlCommand comando = new MySqlCommand(query, conexiondb);
                comando.ExecuteNonQuery();


                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);


                da.Fill(dt);
                ListadoCitas.DataSource = dt;


                conexiondb.Close();
            }

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

       

        private void BtnAgregarCita_Click(object sender, EventArgs e)
        {
            Form agregar_cita = new Agregar_citas();
            agregar_cita.Show();
        }

        private void Citas_Load(object sender, EventArgs e)
        {
            cargarDoctor();
            DateTime fechaActual = DateTime.Today;
            string fecha = Convert.ToDateTime(fechaActual).ToString("yyyy-MM-dd");
            CitasLista(fecha);
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

        private void BtnBuscarFecha_Click(object sender, EventArgs e)
        {
            string fecha = Convert.ToDateTime(TxtFecha.Text).ToString("yyyy-MM-dd");
            CitasLista(fecha);
        }

        private void BtnSiguiente_Click(object sender, EventArgs e)
        {
            string fecha = Convert.ToDateTime(TxtDiaActual.Text).AddDays(1).ToString("yyyy-MM-dd");

            CitasLista(fecha);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            string fecha = Convert.ToDateTime(TxtDiaActual.Text).AddDays(-1).ToString("yyyy-MM-dd");

            CitasLista(fecha);
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            Form agregar_cita = new Agregar_citas();
            agregar_cita.Show();
        }
    }
}
