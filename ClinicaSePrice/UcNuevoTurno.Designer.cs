namespace ClinicaSePrice
{
    partial class UcNuevoTurno
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panelPaciente = new System.Windows.Forms.Panel();
            this.lbDatosPaciente = new System.Windows.Forms.Label();
            this.lbDni = new System.Windows.Forms.Label();
            this.txtDni = new System.Windows.Forms.TextBox();
            this.btnBuscarPaciente = new System.Windows.Forms.Button();
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lbApellido = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lbTelefono = new System.Windows.Forms.Label();
            this.txtObraSocial = new System.Windows.Forms.TextBox();
            this.lbObraSocial = new System.Windows.Forms.Label();
            this.panelTurno = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lbEstudio = new System.Windows.Forms.Label();
            this.cmbEstudio = new System.Windows.Forms.ComboBox();
            this.cmbProfesional = new System.Windows.Forms.ComboBox();
            this.lbProfesional = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.lbFecha = new System.Windows.Forms.Label();
            this.btnbuscarDisponibilidad = new System.Windows.Forms.Button();
            this.lbHorario = new System.Windows.Forms.Label();
            this.cmbHorarios = new System.Windows.Forms.ComboBox();
            this.panelPaciente.SuspendLayout();
            this.panelTurno.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nuevo Turno";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panelPaciente
            // 
            this.panelPaciente.AutoSize = true;
            this.panelPaciente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelPaciente.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPaciente.Controls.Add(this.txtObraSocial);
            this.panelPaciente.Controls.Add(this.lbObraSocial);
            this.panelPaciente.Controls.Add(this.txtTelefono);
            this.panelPaciente.Controls.Add(this.lbTelefono);
            this.panelPaciente.Controls.Add(this.txtApellido);
            this.panelPaciente.Controls.Add(this.lbApellido);
            this.panelPaciente.Controls.Add(this.txtNombre);
            this.panelPaciente.Controls.Add(this.lbNombre);
            this.panelPaciente.Controls.Add(this.btnBuscarPaciente);
            this.panelPaciente.Controls.Add(this.txtDni);
            this.panelPaciente.Controls.Add(this.lbDni);
            this.panelPaciente.Controls.Add(this.lbDatosPaciente);
            this.panelPaciente.Location = new System.Drawing.Point(3, 51);
            this.panelPaciente.Name = "panelPaciente";
            this.panelPaciente.Size = new System.Drawing.Size(908, 120);
            this.panelPaciente.TabIndex = 1;
            // 
            // lbDatosPaciente
            // 
            this.lbDatosPaciente.AutoSize = true;
            this.lbDatosPaciente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDatosPaciente.Location = new System.Drawing.Point(17, 11);
            this.lbDatosPaciente.Name = "lbDatosPaciente";
            this.lbDatosPaciente.Size = new System.Drawing.Size(161, 21);
            this.lbDatosPaciente.TabIndex = 0;
            this.lbDatosPaciente.Text = "DATOS DEL PACIENTE";
            this.lbDatosPaciente.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbDni
            // 
            this.lbDni.AutoSize = true;
            this.lbDni.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDni.Location = new System.Drawing.Point(28, 56);
            this.lbDni.Name = "lbDni";
            this.lbDni.Size = new System.Drawing.Size(33, 17);
            this.lbDni.TabIndex = 1;
            this.lbDni.Text = "DNI:";
            // 
            // txtDni
            // 
            this.txtDni.Location = new System.Drawing.Point(67, 56);
            this.txtDni.Name = "txtDni";
            this.txtDni.Size = new System.Drawing.Size(100, 20);
            this.txtDni.TabIndex = 2;
            // 
            // btnBuscarPaciente
            // 
            this.btnBuscarPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(56)))), ((int)(((byte)(99)))));
            this.btnBuscarPaciente.FlatAppearance.BorderSize = 0;
            this.btnBuscarPaciente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscarPaciente.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPaciente.ForeColor = System.Drawing.Color.White;
            this.btnBuscarPaciente.Location = new System.Drawing.Point(204, 49);
            this.btnBuscarPaciente.Name = "btnBuscarPaciente";
            this.btnBuscarPaciente.Size = new System.Drawing.Size(75, 31);
            this.btnBuscarPaciente.TabIndex = 3;
            this.btnBuscarPaciente.Text = "Buscar";
            this.btnBuscarPaciente.UseVisualStyleBackColor = false;
            this.btnBuscarPaciente.Click += new System.EventHandler(this.btnBuscarPaciente_Click);
            // 
            // lbNombre
            // 
            this.lbNombre.AutoSize = true;
            this.lbNombre.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNombre.Location = new System.Drawing.Point(641, 30);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(60, 17);
            this.lbNombre.TabIndex = 4;
            this.lbNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(707, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(100, 20);
            this.txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(482, 30);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.ReadOnly = true;
            this.txtApellido.Size = new System.Drawing.Size(100, 20);
            this.txtApellido.TabIndex = 7;
            // 
            // lbApellido
            // 
            this.lbApellido.AutoSize = true;
            this.lbApellido.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbApellido.Location = new System.Drawing.Point(416, 30);
            this.lbApellido.Name = "lbApellido";
            this.lbApellido.Size = new System.Drawing.Size(59, 17);
            this.lbApellido.TabIndex = 6;
            this.lbApellido.Text = "Apellido:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Location = new System.Drawing.Point(482, 75);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.ReadOnly = true;
            this.txtTelefono.Size = new System.Drawing.Size(100, 20);
            this.txtTelefono.TabIndex = 9;
            // 
            // lbTelefono
            // 
            this.lbTelefono.AutoSize = true;
            this.lbTelefono.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTelefono.Location = new System.Drawing.Point(416, 75);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(61, 17);
            this.lbTelefono.TabIndex = 8;
            this.lbTelefono.Text = "Telefono:";
            // 
            // txtObraSocial
            // 
            this.txtObraSocial.Location = new System.Drawing.Point(707, 75);
            this.txtObraSocial.Name = "txtObraSocial";
            this.txtObraSocial.ReadOnly = true;
            this.txtObraSocial.Size = new System.Drawing.Size(100, 20);
            this.txtObraSocial.TabIndex = 11;
            // 
            // lbObraSocial
            // 
            this.lbObraSocial.AutoSize = true;
            this.lbObraSocial.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbObraSocial.Location = new System.Drawing.Point(622, 75);
            this.lbObraSocial.Name = "lbObraSocial";
            this.lbObraSocial.Size = new System.Drawing.Size(79, 17);
            this.lbObraSocial.TabIndex = 10;
            this.lbObraSocial.Text = "Obra Social:";
            // 
            // panelTurno
            // 
            this.panelTurno.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTurno.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTurno.Controls.Add(this.cmbHorarios);
            this.panelTurno.Controls.Add(this.lbHorario);
            this.panelTurno.Controls.Add(this.btnbuscarDisponibilidad);
            this.panelTurno.Controls.Add(this.lbFecha);
            this.panelTurno.Controls.Add(this.dtpFecha);
            this.panelTurno.Controls.Add(this.cmbProfesional);
            this.panelTurno.Controls.Add(this.lbProfesional);
            this.panelTurno.Controls.Add(this.cmbEstudio);
            this.panelTurno.Controls.Add(this.lbEstudio);
            this.panelTurno.Controls.Add(this.label2);
            this.panelTurno.Location = new System.Drawing.Point(3, 177);
            this.panelTurno.Name = "panelTurno";
            this.panelTurno.Size = new System.Drawing.Size(908, 156);
            this.panelTurno.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "DATOS DEL TURNO";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbEstudio
            // 
            this.lbEstudio.AutoSize = true;
            this.lbEstudio.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbEstudio.Location = new System.Drawing.Point(19, 51);
            this.lbEstudio.Name = "lbEstudio";
            this.lbEstudio.Size = new System.Drawing.Size(54, 17);
            this.lbEstudio.TabIndex = 7;
            this.lbEstudio.Text = "Estudio:";
            // 
            // cmbEstudio
            // 
            this.cmbEstudio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstudio.FormattingEnabled = true;
            this.cmbEstudio.Location = new System.Drawing.Point(79, 47);
            this.cmbEstudio.Name = "cmbEstudio";
            this.cmbEstudio.Size = new System.Drawing.Size(121, 21);
            this.cmbEstudio.TabIndex = 8;
            this.cmbEstudio.SelectedIndexChanged += new System.EventHandler(this.cmbEstudio_SelectedIndexChanged);
            // 
            // cmbProfesional
            // 
            this.cmbProfesional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesional.FormattingEnabled = true;
            this.cmbProfesional.Location = new System.Drawing.Point(353, 47);
            this.cmbProfesional.Name = "cmbProfesional";
            this.cmbProfesional.Size = new System.Drawing.Size(121, 21);
            this.cmbProfesional.TabIndex = 10;
            // 
            // lbProfesional
            // 
            this.lbProfesional.AutoSize = true;
            this.lbProfesional.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbProfesional.Location = new System.Drawing.Point(271, 51);
            this.lbProfesional.Name = "lbProfesional";
            this.lbProfesional.Size = new System.Drawing.Size(76, 17);
            this.lbProfesional.TabIndex = 9;
            this.lbProfesional.Text = "Profesional:";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(79, 89);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(99, 20);
            this.dtpFecha.TabIndex = 11;
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFecha.Location = new System.Drawing.Point(18, 92);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(44, 17);
            this.lbFecha.TabIndex = 12;
            this.lbFecha.Text = "Fecha:";
            // 
            // btnbuscarDisponibilidad
            // 
            this.btnbuscarDisponibilidad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(56)))), ((int)(((byte)(99)))));
            this.btnbuscarDisponibilidad.FlatAppearance.BorderSize = 0;
            this.btnbuscarDisponibilidad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnbuscarDisponibilidad.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbuscarDisponibilidad.ForeColor = System.Drawing.Color.White;
            this.btnbuscarDisponibilidad.Location = new System.Drawing.Point(531, 62);
            this.btnbuscarDisponibilidad.Name = "btnbuscarDisponibilidad";
            this.btnbuscarDisponibilidad.Size = new System.Drawing.Size(84, 34);
            this.btnbuscarDisponibilidad.TabIndex = 13;
            this.btnbuscarDisponibilidad.Text = "Buscar";
            this.btnbuscarDisponibilidad.UseVisualStyleBackColor = false;
            // 
            // lbHorario
            // 
            this.lbHorario.AutoSize = true;
            this.lbHorario.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbHorario.Location = new System.Drawing.Point(291, 96);
            this.lbHorario.Name = "lbHorario";
            this.lbHorario.Size = new System.Drawing.Size(56, 17);
            this.lbHorario.TabIndex = 14;
            this.lbHorario.Text = "Horario:";
            // 
            // cmbHorarios
            // 
            this.cmbHorarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHorarios.FormattingEnabled = true;
            this.cmbHorarios.Location = new System.Drawing.Point(353, 92);
            this.cmbHorarios.Name = "cmbHorarios";
            this.cmbHorarios.Size = new System.Drawing.Size(121, 21);
            this.cmbHorarios.TabIndex = 15;
            // 
            // UcNuevoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.panelTurno);
            this.Controls.Add(this.panelPaciente);
            this.Controls.Add(this.label1);
            this.Name = "UcNuevoTurno";
            this.Size = new System.Drawing.Size(914, 437);
            this.panelPaciente.ResumeLayout(false);
            this.panelPaciente.PerformLayout();
            this.panelTurno.ResumeLayout(false);
            this.panelTurno.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelPaciente;
        private System.Windows.Forms.Label lbDatosPaciente;
        private System.Windows.Forms.Button btnBuscarPaciente;
        private System.Windows.Forms.TextBox txtDni;
        private System.Windows.Forms.Label lbDni;
        private System.Windows.Forms.TextBox txtObraSocial;
        private System.Windows.Forms.Label lbObraSocial;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.Label lbTelefono;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lbApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Panel panelTurno;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.ComboBox cmbProfesional;
        private System.Windows.Forms.Label lbProfesional;
        private System.Windows.Forms.ComboBox cmbEstudio;
        private System.Windows.Forms.Label lbEstudio;
        private System.Windows.Forms.Button btnbuscarDisponibilidad;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.ComboBox cmbHorarios;
        private System.Windows.Forms.Label lbHorario;
    }
}
