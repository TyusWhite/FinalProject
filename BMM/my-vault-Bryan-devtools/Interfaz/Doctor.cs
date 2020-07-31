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

namespace DentalCare_System.Interfaz
{
    public partial class Doctor : Form
    {
        public Doctor()
        {
            InitializeComponent();
        }

        string datos;
        string datos2;
        int TxtFlag;

        private void Doctor_Load(object sender, EventArgs e)
        {
            
            EditarAñadirGuardar(true);
            BuscarEspecialidad();
            TxtNombre.Focus();
            EliminarEditar(true);

            //Llamar todos los datos al DataGridView
            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
            conexiondb.Open();

            //Variable que va a traer todos los datos de las tablas correspondientes.
            string query = "SELECT doctor.nombre AS Nombre, doctor.apellido AS Apellido, doctor.sexo AS Sexo, doctor.celular AS Celular, doctor.telefono AS Teléfono, " +
                "doctor.correo AS Correo, especialidad.nombre AS Especialidad, doctor.direccion AS Dirección FROM doctor INNER JOIN especialidad ON doctor.id_especialidad = especialidad.id";

            //Comando que recoge los datos que queremos, y la conexión a la base de datos.
            MySqlCommand comando = new MySqlCommand(query, conexiondb);
            comando.ExecuteNonQuery();

            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(comando);

            da.Fill(dt);
            ListaDoctores.DataSource = dt;

            conexiondb.Close();


        }

        private void BuscarEspecialidad()
        {
            //Para llamar los datos que va a presentar el combobox de especialidades.
            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();

            //Especifica el campo que queremos llamar de la tabla.
            MySqlCommand comando = new MySqlCommand("SELECT DISTINCT nombre FROM especialidad", conexiondb);

            //Se abre la conexión
            conexiondb.Open();

            //Se debe leer lo que pedimos que llamara 
            MySqlDataReader registro = comando.ExecuteReader();

            //Mientras se pueda leer, se ejecutará esta parte de código.

            try
            {
                while (registro.Read())
                {
                    CmbEspecialidad.Items.Add(registro["nombre"].ToString());
                }

                CmbEspecialidad.Focus();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Hubo un error de lectura. " + ex.Message);
            }
        }

        private void BtnGuardar_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                //Creando las variables
                string nombre = TxtNombre.Text;
                string apellido = TxtApellido.Text;
                string celular = TxtCelular.Text;
                string telefono = TxtTelefono.Text;
                string sexo = cmbSexo.Text;
                string correo = TxtCorreo.Text;
                //int id = Convert.ToInt32(TxtIdEspecialidad.Text);
                //string especialidad = CmbEspecialidad.Text; (La omito porque no es necesario este campo para que se guarde la info).
                string direccion = TxtDireccion.Text;

                if(nombre != "" && apellido != "" && celular != "" && telefono != "" && sexo != "" && correo != "" && direccion != "")
                {
                    if(TxtFlag == 1)
                    {
                        BuscarIdEspecialidad();
                        string sql = "INSERT INTO doctor (apellido, celular, correo, direccion, id_especialidad, nombre, sexo, telefono)" +
                            "VALUES ('" + apellido + "', '" + celular + "', '" + correo + "', '" + direccion + "', '" + Convert.ToInt32(datos) + "', '" + nombre + "', '" + sexo + "', '" + telefono + "')";

                        MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                        conexiondb.Open();

                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Datos guardados", "Información", MessageBoxButtons.OK);
                            Doctor_Load(null, null);
                            Borrar();
                            EditarAñadirGuardar(false);
                            ListaDoctores.Enabled = true;

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
                        BuscarIdEspecialidad();
                        BuscarIdDoctor();
                        string sql = "UPDATE doctor SET apellido = '" + apellido + "', celular = '" + celular + "', correo = '" + correo + "', " +
                            "direccion = '" + direccion + "', id_especialidad = '" + Convert.ToInt32(datos) + "', nombre = '" + nombre + "', " +
                            "sexo = '" + sexo + "', telefono = '" + telefono + "' WHERE id = '" + Convert.ToInt32(datos2) + "'";

                        MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                        conexiondb.Open();

                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Datos modificados", "Información", MessageBoxButtons.OK);
                            Doctor_Load(null, null);
                            Borrar();
                            EditarAñadirGuardar(true);
                            ListaDoctores.Enabled = true;

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
                    MessageBox.Show("Error de información. Revise los campos.");
                }

            }
            catch(FormatException fex)
            {
                MessageBox.Show("Error de información " + fex.Message);
            }

        }

        //Void para controlar los botones. Que se activen o desactiven dependiendo de lo que se esté haciendo.
        public void EditarAñadirGuardar(bool b)
        {
            TxtNombre.Enabled = !b;
            TxtApellido.Enabled = !b;
            TxtCelular.Enabled = !b;
            TxtTelefono.Enabled = !b;
            cmbSexo.Enabled = !b;
            TxtCorreo.Enabled = !b;
            CmbEspecialidad.Enabled = !b;
            TxtDireccion.Enabled = !b;
            btnBuscarEsp.Enabled = !b;
            BtnGuardar.Enabled = !b;
            BtnAgregar.Enabled = b;
            BtnEliminar.Enabled = b;
            BtnEditar.Enabled = b;

        }
        //Segundo Metodo para desabilitar los botones Eliminar y Editar hasta que no se seleccione un contacto
        public void EliminarEditar(bool b)
        {
            BtnEditar.Enabled = !b;
            BtnEliminar.Enabled = !b;
        }

        //Void para borrar los campos después de guardar todo.
        private void Borrar()
        {
            TxtNombre.Focus();
            TxtNombre.Text = "";
            TxtApellido.Text = "";
            TxtCelular.Text = "";
            TxtTelefono.Text = "";
            cmbSexo.Text = "";
            TxtCorreo.Text = "";
            CmbEspecialidad.Text = "Seleccione";
            TxtDireccion.Text = "";
        }

        private void ListaPacientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnBuscarEsp_Click(object sender, EventArgs e)
        {
            Especialidades especialidades = new Especialidades();
            especialidades.Show();
        }

        private void CmbEspecialidad_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }

        

        private void CmbEspecialidad_Enter(object sender, EventArgs e)
        {
           
        }

        private void CmbEspecialidad_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void CmbEspecialidad_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void CmbEspecialidad_MouseCaptureChanged(object sender, EventArgs e)
        {
            
        }

        private void CmbEspecialidad_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        //Void para llamar al Id de la especialidad aparte, y así poder guardar.
        private void BuscarIdEspecialidad()
        {
            string nombre = CmbEspecialidad.Text;

            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();

            //Llama específicamente el Id del nombre que está en el combobox.
            MySqlCommand comando = new MySqlCommand("SELECT id FROM especialidad WHERE nombre = '" + nombre + "'", conexiondb);
            conexiondb.Open();

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                //Guarda los datos de ese Id en una variable.
                datos = registro["id"].ToString();
            }
        }

        //Void para buscar el Id del doctor. Esto servirá para actualizar los datos.
        private void BuscarIdDoctor()
        {
            string nombre = TxtNombre.Text;

            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();

            //Llama específicamente el Id del nombre que está en el combobox.
            MySqlCommand comando = new MySqlCommand("SELECT id FROM doctor WHERE nombre = '" + nombre + "'", conexiondb);
            conexiondb.Open();

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                //Guarda los datos de ese Id en una variable.
                datos2 = registro["id"].ToString();
            }
        }

        private void CmbEspecialidad_TextUpdate(object sender, EventArgs e)
        {
            
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            TxtFlag = 1;
            BtnCancelar.Visible = true;
            EditarAñadirGuardar(false);
            BtnGuardar.Enabled = true;
            ListaDoctores.Enabled = false;
            TxtNombre.Focus();
            Borrar();
            EliminarEditar(true);
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TxtFlag = 2;
            BtnCancelar.Visible = true;
            ListaDoctores.Enabled = true;
            TxtNombre.Focus();
            EditarAñadirGuardar(false);
            BtnGuardar.Enabled = true;
            EliminarEditar(true);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            EditarAñadirGuardar(true);
            BtnCancelar.Visible = false;
            Borrar();
        }

        //Void para presentar los campos de la tabla en los textbox.
        private void ListaDoctores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //La condición de si no está vacía la fila, que mande los datos.
            if(ListaDoctores.CurrentRow != null)
            {
                TxtNombre.Text = ListaDoctores.CurrentRow.Cells[1].Value.ToString();
                TxtApellido.Text = ListaDoctores.CurrentRow.Cells[2].Value.ToString();
                cmbSexo.Text = ListaDoctores.CurrentRow.Cells[3].Value.ToString();
                TxtCelular.Text = ListaDoctores.CurrentRow.Cells[4].Value.ToString();
                TxtTelefono.Text = ListaDoctores.CurrentRow.Cells[5].Value.ToString();
                TxtCorreo.Text = ListaDoctores.CurrentRow.Cells[6].Value.ToString();
                CmbEspecialidad.Text = ListaDoctores.CurrentRow.Cells[7].Value.ToString();
                TxtDireccion.Text = ListaDoctores.CurrentRow.Cells[8].Value.ToString();
                EliminarEditar(false);
            }

        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            //Proceso para eliminar datos:

            try
            {
                //Usamos una caja de mensaje para confirmar si quiere eliminar o no
                if(MessageBox.Show("Desea eliminar estos elementos", "Información", MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //Hacemos una revisión en todas las filas de la tabla.
                    foreach(DataGridViewRow row in ListaDoctores.Rows)
                    {
                        //Un boolean nos permitirá eliminar o no.
                        if(Convert.ToBoolean(row.Cells["Eliminar"].Value) == false)
                        {

                        }
                        else
                        {
                            //Aplico el Void de buscar el Id del doctor, que se necesita para eliminar.
                            BuscarIdDoctor();

                            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                            conexiondb.Open();

                            //La variable que va a contener el mandato para eliminar.
                            string sql = "DELETE FROM doctor WHERE id = '" + Convert.ToInt32(datos2) + "'";

                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);
                            comando.ExecuteNonQuery();

                            //Recargamos el DataGridView y listo!
                            Doctor_Load(null, null);
                            MessageBox.Show("Datos eliminados.", "Información", MessageBoxButtons.OK);
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ha ocurrido un error. ", ex.Message);
            }
        }

        private void CmbEspecialidad_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
