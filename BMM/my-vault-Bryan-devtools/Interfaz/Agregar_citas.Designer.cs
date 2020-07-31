namespace DentalCare_System.Interfaz
{
    partial class Agregar_citas
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
            this.TxtMotivo = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.CmbPaciente = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtFecha = new System.Windows.Forms.DateTimePicker();
            this.CmbDoctor = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.TxtHora = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxtMotivo
            // 
            this.TxtMotivo.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TxtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TxtMotivo.Font = new System.Drawing.Font("Century", 11.25F);
            this.TxtMotivo.Location = new System.Drawing.Point(347, 178);
            this.TxtMotivo.Margin = new System.Windows.Forms.Padding(4);
            this.TxtMotivo.Name = "TxtMotivo";
            this.TxtMotivo.Size = new System.Drawing.Size(298, 86);
            this.TxtMotivo.TabIndex = 22;
            this.TxtMotivo.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century", 11.25F);
            this.label6.Location = new System.Drawing.Point(19, 163);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 18);
            this.label6.TabIndex = 21;
            this.label6.Text = "Paciente";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century", 11.25F);
            this.label5.Location = new System.Drawing.Point(415, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 18);
            this.label5.TabIndex = 20;
            this.label5.Text = "Doctor";
            // 
            // CmbPaciente
            // 
            this.CmbPaciente.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CmbPaciente.Font = new System.Drawing.Font("Century", 11.25F);
            this.CmbPaciente.FormattingEnabled = true;
            this.CmbPaciente.Location = new System.Drawing.Point(96, 160);
            this.CmbPaciente.Margin = new System.Windows.Forms.Padding(4);
            this.CmbPaciente.Name = "CmbPaciente";
            this.CmbPaciente.Size = new System.Drawing.Size(179, 26);
            this.CmbPaciente.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century", 11.25F);
            this.label3.Location = new System.Drawing.Point(344, 156);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 18);
            this.label3.TabIndex = 17;
            this.label3.Text = "Motivo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century", 11.25F);
            this.label2.Location = new System.Drawing.Point(19, 78);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 18);
            this.label2.TabIndex = 16;
            this.label2.Text = "Fecha";
            // 
            // TxtFecha
            // 
            this.TxtFecha.CalendarMonthBackground = System.Drawing.SystemColors.InactiveBorder;
            this.TxtFecha.Font = new System.Drawing.Font("Century", 11.25F);
            this.TxtFecha.Location = new System.Drawing.Point(77, 72);
            this.TxtFecha.Margin = new System.Windows.Forms.Padding(4);
            this.TxtFecha.Name = "TxtFecha";
            this.TxtFecha.Size = new System.Drawing.Size(298, 26);
            this.TxtFecha.TabIndex = 14;
            // 
            // CmbDoctor
            // 
            this.CmbDoctor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.CmbDoctor.Font = new System.Drawing.Font("Century", 9.25F);
            this.CmbDoctor.FormattingEnabled = true;
            this.CmbDoctor.Location = new System.Drawing.Point(479, 72);
            this.CmbDoctor.Margin = new System.Windows.Forms.Padding(4);
            this.CmbDoctor.Name = "CmbDoctor";
            this.CmbDoctor.Size = new System.Drawing.Size(179, 24);
            this.CmbDoctor.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.label1.Location = new System.Drawing.Point(212, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 34);
            this.label1.TabIndex = 31;
            this.label1.Text = "Agregar Citas";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.BtnGuardar.FlatAppearance.BorderSize = 0;
            this.BtnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnGuardar.Font = new System.Drawing.Font("Century", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnGuardar.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BtnGuardar.Location = new System.Drawing.Point(130, 218);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(112, 32);
            this.BtnGuardar.TabIndex = 32;
            this.BtnGuardar.Text = "CAPTURAR";
            this.BtnGuardar.UseVisualStyleBackColor = false;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click_1);
            // 
            // TxtHora
            // 
            this.TxtHora.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.TxtHora.Location = new System.Drawing.Point(510, 138);
            this.TxtHora.Mask = "00:00";
            this.TxtHora.Name = "TxtHora";
            this.TxtHora.Size = new System.Drawing.Size(86, 20);
            this.TxtHora.TabIndex = 34;
            this.TxtHora.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TxtHora.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century", 11.25F);
            this.label4.Location = new System.Drawing.Point(459, 140);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 18);
            this.label4.TabIndex = 35;
            this.label4.Text = "Hora";
            // 
            // Agregar_citas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(707, 303);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.TxtHora);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxtMotivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.CmbPaciente);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtFecha);
            this.Controls.Add(this.CmbDoctor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "Agregar_citas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Agregar_citas_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox TxtMotivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CmbPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker TxtFecha;
        private System.Windows.Forms.ComboBox CmbDoctor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.MaskedTextBox TxtHora;
        private System.Windows.Forms.Label label4;
    }
}