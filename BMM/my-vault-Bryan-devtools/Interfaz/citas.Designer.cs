namespace DentalCare_System.Interfaz
{
    partial class Citas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Citas));
            this.label1 = new System.Windows.Forms.Label();
            this.citasControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnEdititar = new System.Windows.Forms.Button();
            this.BtnAgregar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.DiaActual = new System.Windows.Forms.Label();
            this.ListadoCitas = new System.Windows.Forms.DataGridView();
            this.BtnAtras = new System.Windows.Forms.Button();
            this.BtnSiguiente = new System.Windows.Forms.Button();
            this.TxtDiaActual = new System.Windows.Forms.TextBox();
            this.TxtFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.CmbDoctor = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.BtnBuscarFecha = new System.Windows.Forms.Button();
            this.citasControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoCitas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(466, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Doctor";
            // 
            // citasControl
            // 
            this.citasControl.Controls.Add(this.tabPage1);
            this.citasControl.Controls.Add(this.tabPage2);
            this.citasControl.Font = new System.Drawing.Font("Century", 11.25F);
            this.citasControl.Location = new System.Drawing.Point(12, 26);
            this.citasControl.Name = "citasControl";
            this.citasControl.SelectedIndex = 0;
            this.citasControl.Size = new System.Drawing.Size(933, 517);
            this.citasControl.TabIndex = 18;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.BtnBuscarFecha);
            this.tabPage1.Controls.Add(this.BtnEliminar);
            this.tabPage1.Controls.Add(this.BtnEdititar);
            this.tabPage1.Controls.Add(this.BtnAgregar);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.DiaActual);
            this.tabPage1.Controls.Add(this.ListadoCitas);
            this.tabPage1.Controls.Add(this.BtnAtras);
            this.tabPage1.Controls.Add(this.BtnSiguiente);
            this.tabPage1.Controls.Add(this.TxtDiaActual);
            this.tabPage1.Controls.Add(this.TxtFecha);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.CmbDoctor);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Font = new System.Drawing.Font("Century", 9.25F);
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(925, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Citas";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEliminar.FlatAppearance.BorderSize = 0;
            this.BtnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEliminar.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEliminar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnEliminar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEliminar.Image")));
            this.BtnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEliminar.Location = new System.Drawing.Point(624, 78);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(109, 33);
            this.BtnEliminar.TabIndex = 45;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEliminar.UseVisualStyleBackColor = true;
            // 
            // BtnEdititar
            // 
            this.BtnEdititar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnEdititar.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.BtnEdititar.FlatAppearance.BorderSize = 0;
            this.BtnEdititar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnEdititar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnEdititar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnEdititar.Image = ((System.Drawing.Image)(resources.GetObject("BtnEdititar.Image")));
            this.BtnEdititar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnEdititar.Location = new System.Drawing.Point(532, 76);
            this.BtnEdititar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnEdititar.Name = "BtnEdititar";
            this.BtnEdititar.Size = new System.Drawing.Size(89, 37);
            this.BtnEdititar.TabIndex = 46;
            this.BtnEdititar.Text = "Editar";
            this.BtnEdititar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnEdititar.UseVisualStyleBackColor = true;
            // 
            // BtnAgregar
            // 
            this.BtnAgregar.AccessibleDescription = "";
            this.BtnAgregar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BtnAgregar.FlatAppearance.BorderSize = 0;
            this.BtnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAgregar.Font = new System.Drawing.Font("Century", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnAgregar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BtnAgregar.Image = ((System.Drawing.Image)(resources.GetObject("BtnAgregar.Image")));
            this.BtnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnAgregar.Location = new System.Drawing.Point(751, 13);
            this.BtnAgregar.Margin = new System.Windows.Forms.Padding(0);
            this.BtnAgregar.Name = "BtnAgregar";
            this.BtnAgregar.Size = new System.Drawing.Size(102, 34);
            this.BtnAgregar.TabIndex = 44;
            this.BtnAgregar.Text = "Agregar";
            this.BtnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnAgregar.UseVisualStyleBackColor = true;
            this.BtnAgregar.Click += new System.EventHandler(this.BtnAgregar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Fecha";
            // 
            // DiaActual
            // 
            this.DiaActual.AutoSize = true;
            this.DiaActual.Font = new System.Drawing.Font("Century", 16.25F);
            this.DiaActual.Location = new System.Drawing.Point(267, 80);
            this.DiaActual.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.DiaActual.Name = "DiaActual";
            this.DiaActual.Size = new System.Drawing.Size(48, 27);
            this.DiaActual.TabIndex = 41;
            this.DiaActual.Text = "Día";
            // 
            // ListadoCitas
            // 
            this.ListadoCitas.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ListadoCitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ListadoCitas.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.ListadoCitas.Location = new System.Drawing.Point(18, 116);
            this.ListadoCitas.Name = "ListadoCitas";
            this.ListadoCitas.Size = new System.Drawing.Size(868, 364);
            this.ListadoCitas.TabIndex = 40;
            // 
            // BtnAtras
            // 
            this.BtnAtras.FlatAppearance.BorderSize = 0;
            this.BtnAtras.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAtras.Image = ((System.Drawing.Image)(resources.GetObject("BtnAtras.Image")));
            this.BtnAtras.Location = new System.Drawing.Point(22, 78);
            this.BtnAtras.Name = "BtnAtras";
            this.BtnAtras.Size = new System.Drawing.Size(98, 30);
            this.BtnAtras.TabIndex = 38;
            this.BtnAtras.UseVisualStyleBackColor = true;
            this.BtnAtras.Click += new System.EventHandler(this.BtnAtras_Click);
            // 
            // BtnSiguiente
            // 
            this.BtnSiguiente.FlatAppearance.BorderSize = 0;
            this.BtnSiguiente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSiguiente.Image = ((System.Drawing.Image)(resources.GetObject("BtnSiguiente.Image")));
            this.BtnSiguiente.Location = new System.Drawing.Point(792, 79);
            this.BtnSiguiente.Name = "BtnSiguiente";
            this.BtnSiguiente.Size = new System.Drawing.Size(98, 30);
            this.BtnSiguiente.TabIndex = 37;
            this.BtnSiguiente.UseVisualStyleBackColor = true;
            this.BtnSiguiente.Click += new System.EventHandler(this.BtnSiguiente_Click);
            // 
            // TxtDiaActual
            // 
            this.TxtDiaActual.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TxtDiaActual.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtDiaActual.Font = new System.Drawing.Font("Century", 15.25F);
            this.TxtDiaActual.Location = new System.Drawing.Point(323, 84);
            this.TxtDiaActual.Name = "TxtDiaActual";
            this.TxtDiaActual.Size = new System.Drawing.Size(168, 25);
            this.TxtDiaActual.TabIndex = 36;
            // 
            // TxtFecha
            // 
            this.TxtFecha.Location = new System.Drawing.Point(74, 21);
            this.TxtFecha.Margin = new System.Windows.Forms.Padding(5);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Size = new System.Drawing.Size(347, 22);
            this.TxtFecha.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-48, 71);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 30;
            this.label2.Text = "Fecha";
            // 
            // CmbDoctor
            // 
            this.CmbDoctor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CmbDoctor.CausesValidation = false;
            this.CmbDoctor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CmbDoctor.Location = new System.Drawing.Point(523, 19);
            this.CmbDoctor.Margin = new System.Windows.Forms.Padding(5);
            this.CmbDoctor.Name = "CmbDoctor";
            this.CmbDoctor.Size = new System.Drawing.Size(209, 24);
            this.CmbDoctor.TabIndex = 29;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(925, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Citas Pendientes";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.tabPage2_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label9.Location = new System.Drawing.Point(333, 9);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 33);
            this.label9.TabIndex = 40;
            this.label9.Text = "Citas";
            // 
            // BtnBuscarFecha
            // 
            this.BtnBuscarFecha.Location = new System.Drawing.Point(429, 23);
            this.BtnBuscarFecha.Name = "BtnBuscarFecha";
            this.BtnBuscarFecha.Size = new System.Drawing.Size(27, 23);
            this.BtnBuscarFecha.TabIndex = 48;
            this.BtnBuscarFecha.UseVisualStyleBackColor = true;
            this.BtnBuscarFecha.Click += new System.EventHandler(this.BtnBuscarFecha_Click);
            // 
            // Citas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 566);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.citasControl);
            this.Font = new System.Drawing.Font("Century", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Citas";
            this.Text = "Citas";
            this.Load += new System.EventHandler(this.Citas_Load);
            this.citasControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListadoCitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl citasControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridView ListadoCitas;
        private System.Windows.Forms.Button BtnAtras;
        private System.Windows.Forms.Button BtnSiguiente;
        private System.Windows.Forms.TextBox TxtDiaActual;
        private System.Windows.Forms.DateTimePicker TxtFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CmbDoctor;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label DiaActual;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnEdititar;
        private System.Windows.Forms.Button BtnAgregar;
        private System.Windows.Forms.Button BtnBuscarFecha;
    }
}