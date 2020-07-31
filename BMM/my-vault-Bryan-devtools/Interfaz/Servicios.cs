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
    public partial class Servicios : Form
    {
        public Servicios()
        {
            InitializeComponent();
        }
        String datos2;//variable que alojara el ID del servio
        int TxtFlag; //bandera para permitirnos selecionar si un registro nuevo o se actuliaza un viejo.

        //Deactivar y activar campos y botones
       private void ActivarDesactivar(bool b)
        {
            TxtNombre.Enabled = !b;
            TxtPrecio.Enabled = !b;

            BtnGuardar.Enabled = !b;
            BtnEditar.Enabled = !b;
            BtnEliminar.Enabled = !b;


        }

        /*Segundo metodo para deactivar los botones editar y eliminar al momento de habilitar los campos
         y asi impedir que se pueda eliminar o editar sin tener ningun contacto seleccionado.
         */
        private void EditarEliminar(bool b)
        {
            BtnEditar.Enabled = !b;
            BtnEliminar.Enabled = !b;
            BtnAgregar.Enabled = !b;
            ListaServicios.Enabled = !b;
        }
        //Metodo para limpiar los campos
        private void borrar()
        {
            TxtNombre.Text = "";
            TxtPrecio.Text = "";

        }

        //metodo para buscar ID del servicio
        private void BuscarIdServicio()
        {
            string nombre = TxtNombre.Text;

            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();

            //Llama específicamente el Id del nombre que está en el combobox.
            MySqlCommand comando = new MySqlCommand("SELECT id FROM servicios WHERE nombre = '" + nombre + "'", conexiondb);
            conexiondb.Open();

            MySqlDataReader registro = comando.ExecuteReader();

            while (registro.Read())
            {
                //Guarda los datos de ese Id en una variable.
                datos2 = registro["id"].ToString();
            }
        }


        /* *******************************************
         * Metodo para llenar los campos del data grid
         * *********************************************/
        private void ListaServicios_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            //La condición de si no está vacía la fila, que mande los datos.
            if (ListaServicios.CurrentRow != null)
            {

                TxtNombre.Text = ListaServicios.CurrentRow.Cells[1].Value.ToString();
                TxtPrecio.Text = ListaServicios.CurrentRow.Cells[2].Value.ToString();
                EditarEliminar(false);


            }
        }


        /*******************************************************************
        //metodo para llenar los texbox con la informacion del Datagriview *

         *****************************************************************/
        private void Servicios_Load(object sender, EventArgs e)
        {

            try
            {
                
                TxtNombre.Focus();

                //Llamar todos los datos al DataGridView
                MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                conexiondb.Open();

                //Variable que va a traer todos los datos de las tablas correspondientes.
                string query = "SELECT  nombre as Nombre, precio AS Precio " + " FROM servicios";

                //Comando que recoge los datos que queremos, y la conexión a la base de datos.
                MySqlCommand comando = new MySqlCommand(query, conexiondb);
                comando.ExecuteNonQuery();

                DataTable dt = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(comando);

                da.Fill(dt);
                ListaServicios.DataSource = dt;



                conexiondb.Close();


            }
            catch (FormatException fex)
            {
                MessageBox.Show("Datos incorrectos: " + fex.Message);

            }
            ActivarDesactivar(true);

        }


        /* =====================================================================
         *  Promgramando los botones del formulario
         *  ====================================================================
         */

        /*  =========
         * | Boton   |
         * | Guardar |
         *  =========
        */
        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Se Declaran las Varaiables 
                String Nombre = TxtNombre.Text;
                 string Precio = TxtPrecio.Text;
               


                if (Nombre != "" && Precio !="")
                    
                {
                    if (TxtFlag == 1)
                    {
                        string sql = "INSERT INTO servicios ( nombre, precio)" +
                       " VALUES ( '" + Nombre + "','" + Precio + "')";

                        MySqlConnection conexionBD = DbConnection.ObtenerConeccion();

                        conexionBD.Open();

                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexionBD);


                            comando.ExecuteNonQuery();
                            MessageBox.Show("Registro guardado");

                            borrar();
                            ListaServicios.Enabled = true;
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
                        BuscarIdServicio();
                        string sql = "UPDATE servicios SET  nombre = '" + Nombre + "', precio = '" + Precio + "' WHERE id = '" + Convert.ToInt32(datos2) + "'";

                        MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                        conexiondb.Open();

                        try
                        {
                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);

                            comando.ExecuteNonQuery();

                            MessageBox.Show("Datos modificados", "Información", MessageBoxButtons.OK);
                            Servicios_Load(null, null);
                            borrar();
                            ActivarDesactivar(true);
                            ListaServicios.Enabled = true;

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

            Servicios_Load(null, null);

            //metodos de bloqueo de botones
            ActivarDesactivar(true);
            EditarEliminar(true);


        }
        
        //========================================================================================
        /*  =========
         * | Boton   |
         * | Agregar |
         *  =========
         */
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            TxtFlag = 1;
            ActivarDesactivar(false);
            EditarEliminar(true);
            borrar();
        }


        //========================================================================================
        /* ===========
         *|  Boton    |
         *|  Eliminar |
         * ===========
         */
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
                    foreach (DataGridViewRow row in ListaServicios.Rows)
                    {
                        //Un boolean nos permitirá eliminar o no.
                        if (Convert.ToBoolean(row.Cells["Eliminar"].Value) == false)
                        {

                        }
                        else
                        {
                            //Aplico el Void de buscar el Id del paciente, que se necesita para eliminar.
                            BuscarIdServicio();

                            MySqlConnection conexiondb = DbConnection.ObtenerConeccion();
                            conexiondb.Open();

                            //La variable que va a contener el mandato para eliminar.
                            string sql = "DELETE FROM servicios WHERE id = '" + Convert.ToInt32(datos2) + "'";

                            MySqlCommand comando = new MySqlCommand(sql, conexiondb);
                            comando.ExecuteNonQuery();

                            //Recargamos el DataGridView y listo!
                            Servicios_Load(null, null);
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

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            TxtFlag = 2;
            ListaServicios.Enabled = true;
            TxtNombre.Focus();
            ActivarDesactivar(false);
            EditarEliminar(true);
            BtnGuardar.Enabled = true;
        }
    }
}
