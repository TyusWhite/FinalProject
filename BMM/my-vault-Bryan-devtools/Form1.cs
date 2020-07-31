using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices; // Libreria utilizada para mover mediante la barra de titulo    
using DentalCare_System.Interfaz;

namespace DentalCare_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            BtnRestaurar.Visible = false;//desabilida el boton restaurar al momento de inicar el programa

        }
        private void Form1_Load(object sender, EventArgs e)
        {


        }

        //==============================================================================================
        //Código para mover mediante la barra de titulo:
        //==============================================================================================
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        //==============================================================================================

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        /* 
        ======================================================
         Controles personalizados para Maximizar, Minimizar y
         pantalla normal utilizando la propiedad window state
         o Estado de Ventana.
         ======================================================
         */
        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            Close();//Cierra el programa
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {

            this.WindowState = FormWindowState.Maximized;//Pantalla completa
            BtnMinimizar.Visible = false;//desabilida el boton minimizar
            BtnRestaurar.Visible = true;//habilida el boton restaurar
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;//minimiza el programa
        }

        private void BtnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;

            BtnMinimizar.Visible = true;//habilida minimizar
            BtnRestaurar.Visible = false;//desabilida restaurar
        }

        /*funcion para abrir formulario dentro de un contenedor */
        private void AbrirFormEnPanel(object Formhijo)
        {
            if (this.PanelContenedor.Controls.Count > 0)
                this.PanelContenedor.Controls.RemoveAt(0);
            Form fh = Formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(fh);
            this.PanelContenedor.Tag = fh;
            fh.Show();
        }
       
        private void Paciente_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Paciente());
        }

        private void btnServicio_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Servicios());
        }

        private void btnDoctor_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Doctor());

        }

       

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Consultas());
        }

        private void BtnCitas_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Citas());
        }

        private void PanelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
