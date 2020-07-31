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
using DentalCare_System.Interfaz;
using DentalCare_System.Entidades;
using Validaciones;

namespace DentalCare_System.Interfaz
{
    public partial class Paciente : Form
    {
        public Paciente()
        {
            InitializeComponent();
        }

       string datos2;//variable que guardara el ID del contacto
        int TxtFlag;// Variable q se va utilizar para decirle al programa si se guarda un nuevo registro o se modifica un atiguo.

        private void Cerrar_Click(object sender, EventArgs e)
        {
            Close();

        }
        //Void para borrar los campos después de guardar todo.
        private void Borrar()
        {
            TxtNombre.Focus();
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtCelular.Text = "";
            TxtTelefono.Text = "";
            TxtFechaNacimiento.Text = "";
            TxtEstadoCivil.Text = "";
            TxtDireccion.Text = "";
            TxtOcupacion.Text = "";
        }
        //Void para controlar los botones. Que se activen o desactiven dependiendo de lo que se esté haciendo.
        public void EditarAñadirGuardar(bool b)
        {
            TxtNombre.Enabled = !b;
            TxtApellido.Enabled = !b;
            TxtCelular.Enabled = !b;
            TxtTelefono.Enabled = !b;
            TxtSexo.Enabled = !b;
            TxtDireccion.Enabled = !b;
            TxtOcupacion.Enabled = !b;
            TxtEstadoCivil.Enabled = !b;

            
            BtnGuardar.Enabled = !b;
            BtnAgregar.Enabled = b;
            BtnEliminar.Enabled = !b;
            BtnEditar.Enabled = !b;

        }
        //Segundo Metodo para desabilitar los botones Eliminar y Editar hasta que no se seleccione un contacto
        public void EliminarEditar(bool b)
        {
            BtnEditar.Enabled = !b;
            BtnEliminar.Enabled = !b;
        }
        //Void para buscar el Id del Paciente. Esto servirá para actualizar los datos.
        private void BuscarIdPaciente()
        {
            string nombre = TxtNombre.Text;

            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();

            //Llama específicamente el Id del nombre que está en el combobox.
            MySqlCommand comando = new MySqlCommand("SELECT id FROM paciente WHERE nombre = '" + nombre + "'", conexiondb);
            conexiondb.Open();

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                //Guarda los datos de ese Id en una variable.
                datos2 = registro["id"].ToString();
            }
        }
        



        private void Paciente_Load(object sender, EventArgs e)
        {
            BuscarIdPaciente();

            try
            {
                EditarAñadirGuardar(true);
                BtnCancelar.Visible = false;

                TxtNombre.Focus();

                //Llamar todos los datos al DataGridView
                MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                conexiondb.Open();

                //Variable que va a traer todos los datos de las tablas correspondientes.
                 string query = "SELECT  nombre as Nombre, apellido AS Apellido, sexo AS Sexo,celular AS Cel, telefono AS Tel, " +
                     "fecha_nacimiento AS Fecha_de_Nacimiento, ocupacion AS Ocupacion, estado_civil AS Estado_Civil,direccion AS Direccion FROM paciente";
                
                //Comando que recoge los datos que queremos, y la conexión a la base de datos.
                MySqlCommand comando = new MySqlCommand(query, conexiondb);
                comando.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                da.Fill(dt);
                ListaPacientes.DataSource = dt;

               

                conexiondb.Close();


            }catch(FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);

            }
               

            }

        //Boton de Guardar 
        private void BtnGuardar_Click(object sender, EventArgs e)
        {

            BuscarIdPaciente();
            try
            {
                BuscarIdPaciente();
                MessageBox.Show(datos2);

                //hacemos uso del constructor vacio y llenamos cada uno de sus atributos
                SPaciente paciente = new SPaciente();
                paciente.Nombre = TxtNombre.Text;
                paciente.Apellido = TxtApellido.Text;
                paciente.Telefono = TxtTelefono.Text;
                paciente.Celular = TxtCelular.Text;
                paciente.Ocupacion = TxtOcupacion.Text;
                paciente.Direccion = TxtDireccion.Text;
                paciente.Sexo = TxtSexo.Text;
                paciente.EstadoCivil = TxtEstadoCivil.Text;
                 paciente.FechaNacimiento = Convert.ToDateTime(TxtFechaNacimiento.Text).ToString("yyyy-MM-dd");
                
               
                

                if (paciente.Nombre != ""
                    && paciente.Apellido != ""
                    && paciente.Sexo != "" && paciente.FechaNacimiento != "" && paciente.EstadoCivil != "" && paciente.Celular != "" && paciente.Telefono != "" && paciente.Direccion !="")
                {
                    if (TxtFlag == 1)
                    {
                        BuscarIdPaciente();
                        
                        string sql = "INSERT INTO paciente ( nombre, apellido, Fecha_Nacimiento, sexo , estado_civil , celular, telefono, ocupacion, direccion)" +
                        " VALUES ( '" + paciente.Nombre + "','" + paciente.Apellido + "','" + paciente.FechaNacimiento + "','" + paciente.Sexo + "','" + paciente.EstadoCivil + "','" + paciente.Celular + "','" + paciente.Telefono + "','" + paciente.Ocupacion + "','" + paciente.Direccion + "' )";

                        MySqlConnection conexionBD = DbConnection.ObtenerConeccion();

                        conexionBD.Open();

                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexionBD);


                            comando.ExecuteNonQuery();
                            MessageBox.Show("Registro guardado");
                            Paciente_Load(null, null);
                            Borrar();
                            ListaPacientes.Enabled = true;
                        }
                        catch (MySqlException ex)
                        {
                            MessageBox.Show("Error al guardar: " + ex.Message);
                        }
                        finally
                        {
                            conexionBD.Close();
                        }

                    }
                    else
                    {
                        BuscarIdPaciente();
                        MessageBox.Show(datos2);
                        string sql = "UPDATE paciente SET  nombre = '" + paciente.Nombre+ "', apellido = '" + paciente.Apellido + "', celular = '" + paciente.Celular + "', telefono = '" + paciente.Telefono + "', " +
                           "direccion = '" + paciente.Direccion + "' , sexo = '" + paciente.Sexo + "', ocupacion='" + paciente.Ocupacion +"', estado_civil= '" + paciente.EstadoCivil +"' , fecha_nacimiento='"+paciente.FechaNacimiento+"' WHERE id = '" + Convert.ToInt32(datos2) + "'";

                        MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                        conexiondb.Open();

                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Datos modificados", "Información", MessageBoxButtons.OK);
                            Paciente_Load (null, null);
                            Borrar();
                            EditarAñadirGuardar(true);
                            ListaPacientes.Enabled = true;

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
                    
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);
            }

        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
           
            TxtFlag = 1;
            EditarAñadirGuardar(false);
            EliminarEditar(true);
            BtnCancelar.Visible = true;

            BtnGuardar.Enabled = true;
            ListaPacientes.Enabled = false;
            TxtNombre.Focus();
            Borrar();
        }


        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //Proceso para eliminar datos:
            

            try
            {
                //Usamos una caja de mensaje para confirmar si quiere eliminar o no
                if (MessageBox.Show("Desea eliminar estos elementos", "Información", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Hacemos una revisión en todas las filas de la tabla.
                    foreach (DataGridViewRow row in ListaPacientes.Rows)
                    {
                        //Un boolean nos permitirá eliminar o no.
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value) == false)
                        {

                        }
                        else
                        {
                            //Aplico el Void de buscar el Id del paciente, que se necesita para eliminar.
                            BuscarIdPaciente();

                            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                            conexiondb.Open();

                            //La variable que va a contener el mandato para eliminar.
                            string sql = "DELETE FROM paciente WHERE id = '" + Convert.ToInt32(datos2) + "'";

                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);
                            comando.ExecuteNonQuery();

                            //Recargamos el DataGridView y listo!
                            Paciente_Load(null,null);
                            MessageBox.Show("Datos eliminados.", "Información", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error. ", ex.Message);
            }
        }

        private void ListaPacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //La condición de si no está vacía la fila, que mande los datos.
            if (ListaPacientes.CurrentRow != null)
            {

                TxtNombre.Text = ListaPacientes.CurrentRow.Cells[1].Value.ToString();
                TxtApellido.Text = ListaPacientes.CurrentRow.Cells[2].Value.ToString();
                TxtSexo.Text = ListaPacientes.CurrentRow.Cells[3].Value.ToString();
                TxtCelular.Text = ListaPacientes.CurrentRow.Cells[4].Value.ToString();
                TxtTelefono.Text = ListaPacientes.CurrentRow.Cells[5].Value.ToString();
                TxtFechaNacimiento.Text = ListaPacientes.CurrentRow.Cells[6].Value.ToString();
                TxtOcupacion.Text = ListaPacientes.CurrentRow.Cells[7].Value.ToString();
                TxtEstadoCivil.Text = ListaPacientes.CurrentRow.Cells[8].Value.ToString();
                TxtDireccion.Text = ListaPacientes.CurrentRow.Cells[9].Value.ToString();
                EliminarEditar(false);

            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TxtFlag = 2;
            BtnCancelar.Visible = true;
            ListaPacientes.Enabled = true;
            TxtNombre.Focus();
            EditarAñadirGuardar(false);
            EliminarEditar(true);
            BtnGuardar.Enabled = true;
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            EditarAñadirGuardar(true);
            BtnCancelar.Visible = false;
            ListaPacientes.Enabled = true;
            Borrar();
        }
        //Evento KeyPress con clase validar para evitar que se introduzcan caracteres que no se deben.
        private void TxtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }

        private void TxtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);

        }

        private void TxtCelular_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void TxtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloNumeros(e);
        }

        private void TxtOcupacion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);

        }

        private void TxtDireccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            validar.SoloLetras(e);
        }
    }
}
