using DentalCare_System.DB;
using DentalCare_System.Entidades;
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
    public partial class Consultas : Form
    {
        string datos;
        string datos2;
        int Flag;
        public Consultas()
        {
            InitializeComponent();
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            cargarPaciente();
            cargarDoctor();
            /* //Llamar todos los datos al DataGridView
             MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
             conexiondb.Open();

             //Variable que va a traer todos los datos de las tablas correspondientes.
             string query = "SELECT doctor.nombre AS Doctor, paciente.nombre as Paciente, consultas.observacion AS Observacion, consultas.fecha_hora FROM doctor INNER JOIN consultas ON doctor.id_doctor INNER JOIN consultas ON paciente.id_paciente";

             //Comando que recoge los datos que queremos, y la conexión a la base de datos.
             MySqlCommand comando = new MySqlCommand(query, conexiondb);
             comando.ExecuteNonQuery();

             DataTable dt = new DataTable();
             MySqlDataAdapter da = new MySqlDataAdapter(comando);

             da.Fill(dt);
             ListaRegistros.DataSource = dt;

             conexiondb.Close();*/


        }


        /*=========================================================================
                           █▀▄ █▀█ █▀▀ ▀█▀ █▀█ █▀█
                           █▄▀ █▄█ █▄▄ ░█░ █▄█ █▀▄
        ===========================================================================*/
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
        //==============================================================================
        //Aqui termina el combo box Doctor                                             |
        //==============================================================================


        /*===============================================================
                        █▀█ ▄▀█ █▀▀ █ █▀▀ █▄░█ ▀█▀ █▀▀ █▀
                        █▀▀ █▀█ █▄▄ █ ██▄ █░▀█ ░█░ ██▄ ▄█
         ================================================================*/

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

        //==============================================================================
        //Aqui termina el combo box Paciente                                           |
        //==============================================================================


        /*========================================================================
                * █▄▄ █▀█ ▀█▀ █▀█ █▄░█   █▀▀ █░█ ▄▀█ █▀█ █▀▄ ▄▀█ █▀█
                  █▄█ █▄█ ░█░ █▄█ █░▀█   █▄█ █▄█ █▀█ █▀▄ █▄▀ █▀█ █▀▄
         ========================================================================*/

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {

           

            try
            {

                //Creando las variables
                SConsulta consulta = new SConsulta();
                consulta.CmbPaciente1 = Convert.ToInt32(CmbPaciente.SelectedValue);
                consulta.CmbDoctor1 =Convert.ToInt32(CmbDoctor.SelectedValue);
                consulta.Descripcion = TxtObservacion.Text;
                consulta.Fecha_hora = Convert.ToDateTime(TxtFecha.Text).ToString("yyyy-MM-dd");


                if (Flag==0)
                {
                   

                    if (CmbPaciente.Text != "" && consulta.Descripcion  != "" && CmbDoctor.Text != "")
                    {


                        string sql = "INSERT INTO consultas (descripcion, fecha_hora, id_paciente,id_doctor)" +
                                "VALUES ('" + consulta.Descripcion + "', '" + consulta.Fecha_hora + "','" + consulta.CmbPaciente1 + "','" + consulta.CmbDoctor1 + "')";
                        MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                        conexiondb.Open();

                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Cita guardada", "Información", MessageBoxButtons.OK);


                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Error de información " + ex.Message);
                        }
                        finally
                        {
                            conexiondb.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Error de información. Revise los campos.");

                    }



                }
                else
                {


                   
                    string sql = "UPDATE consultas SET observacion= '" + consulta.Descripcion + "', fecha_hora='" + consulta.Fecha_hora + "', id_doctor = '" + Convert.ToInt32(datos2) + "', id_paciente='" + Convert.ToInt32(datos) + "'  WHERE id='" + Convert.ToInt32(datos2) + "'";
                    
                    MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                    conexiondb.Open();

                    try
                    {
                        MySqlCommand comando = new MySqlCommand(sql, conexiondb);
                         
                        comando.ExecuteNonQuery();

                        MessageBox.Show("Datos modificados", "Información", MessageBoxButtons.OK);


                    }
                    catch (MySqlException ex)
                    {
                        MessageBox.Show("Error de información " + ex.Message);
                    }
                    finally
                    {
                        conexiondb.Close();
                    }
                }
                   

            }catch(FormatException fex)

            {

                MessageBox.Show("Error de información " + fex.Message);
            }
    
        }

        private void ListaRegistros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //La condición de si no está vacía la fila, que mande los datos.
            if (ListaRegistros.CurrentRow != null)
            {

                CmbPaciente.Text = ListaRegistros.CurrentRow.Cells[1].Value.ToString();
                CmbDoctor.Text = ListaRegistros.CurrentRow.Cells[2].Value.ToString();
                TxtObservacion.Text = ListaRegistros.CurrentRow.Cells[3].Value.ToString();
                TxtFecha.Text = ListaRegistros.CurrentRow.Cells[4].Value.ToString();
                

            }
        }
    }
}
