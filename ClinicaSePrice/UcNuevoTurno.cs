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

namespace ClinicaSePrice
{
    public partial class UcNuevoTurno : UserControl
    {
        public UcNuevoTurno()
        {
            InitializeComponent();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaSeleccionada = dtpFecha.Value.Date;

            MessageBox.Show("Fecha seleccionada: " + fechaSeleccionada.ToShortDateString());

            // acá después vas a cargar horarios
        }

        private void btnGuadarTurno_Click(object sender, EventArgs e)
        {
            GuardarTurno();
        }
        private void GuardarTurno()
        {
            Conexion cn = new Conexion();
            MySqlConnection conexion = cn.conectar();

            conexion.Open();

            // 1. buscar paciente
            string buscar = "SELECT id_paciente FROM pacientes WHERE dni=@dni";
            MySqlCommand cmdBuscar = new MySqlCommand(buscar, conexion);
            cmdBuscar.Parameters.AddWithValue("@dni", txtDni.Text);

            object resultado = cmdBuscar.ExecuteScalar();

            int idPaciente;

            // 2. si no existe, crear
            if (resultado == null)
            {
                string insertPaciente = @"
        INSERT INTO pacientes (dni, nombre, apellido, telefono)
        VALUES (@dni, @nom, @ape, @tel)";

                MySqlCommand cmdInsert = new MySqlCommand(insertPaciente, conexion);

                cmdInsert.Parameters.AddWithValue("@dni", txtDni.Text);
                cmdInsert.Parameters.AddWithValue("@nom", txtNombre.Text);
                cmdInsert.Parameters.AddWithValue("@ape", txtApellido.Text);
                cmdInsert.Parameters.AddWithValue("@tel", txtTelefono.Text);

                cmdInsert.ExecuteNonQuery();

                idPaciente = (int)cmdInsert.LastInsertedId;
            }
            else
            {
                idPaciente = Convert.ToInt32(resultado);
            }

            // 3. verificar turno
            string ver = @"
    SELECT COUNT(*) FROM turnos
    WHERE id_profesional=@prof
    AND fecha=@fecha
    AND hora=@hora";

            MySqlCommand cmdVer = new MySqlCommand(ver, conexion);

            cmdVer.Parameters.AddWithValue("@prof", cmbProfesional.SelectedValue);
            cmdVer.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);
            cmdVer.Parameters.AddWithValue("@hora", cmbHora.Text);

            int existe = Convert.ToInt32(cmdVer.ExecuteScalar());

            if (existe > 0)
            {
                MessageBox.Show("Horario ocupado");
                conexion.Close();
                return;
            }

            // 4. guardar turno
            string insertTurno = @"
    INSERT INTO turnos (id_paciente, id_profesional, fecha, hora)
    VALUES (@pac, @prof, @fecha, @hora)";

            MySqlCommand cmdTurno = new MySqlCommand(insertTurno, conexion);

            cmdTurno.Parameters.AddWithValue("@pac", idPaciente);
            cmdTurno.Parameters.AddWithValue("@prof", cmbProfesional.SelectedValue);
            cmdTurno.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);
            cmdTurno.Parameters.AddWithValue("@hora", cmbHora.Text);

            cmdTurno.ExecuteNonQuery();

            conexion.Close();

            MessageBox.Show("Turno guardado correctamente");
        }
    }
}