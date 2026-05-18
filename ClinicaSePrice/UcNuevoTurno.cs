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
            CargarEstudios();
            dtpFecha.ValueChanged += (s, e) => CargarHorariosDisponibles();
            cmbProfesional.SelectedIndexChanged += (s, e) => CargarHorariosDisponibles();
        }
        
        private void CargarEstudios()
        {
            Conexion cn = new Conexion();

            MySqlConnection conexion = cn.conectar();

            try
            {
                conexion.Open();

                string consulta =
                    "SELECT id_estudio, nombre_estudio FROM estudios";

                MySqlDataAdapter da =
                    new MySqlDataAdapter(consulta, conexion);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbEstudio.DataSource = dt;

                cmbEstudio.DisplayMember = "nombre_estudio";

                cmbEstudio.ValueMember = "id_estudio";

                cmbEstudio.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void CargarProfesionales()
        {
            if (cmbEstudio.SelectedValue == null)
                return;

            Conexion cn = new Conexion();

            MySqlConnection conexion = cn.conectar();

            try
            {
                conexion.Open();

                string consulta = @"
        SELECT 
        id_profesional,
        CONCAT(nombre, ' ', apellido) AS profesional
        FROM profesionales
        WHERE id_estudio = @idEstudio";

                MySqlCommand cmd =
                    new MySqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue(
                    "@idEstudio",
                    cmbEstudio.SelectedValue
                );

                MySqlDataAdapter da =
                    new MySqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbProfesional.DataSource = null;

                cmbProfesional.DataSource = dt;

                cmbProfesional.DisplayMember = "profesional";

                cmbProfesional.ValueMember = "id_profesional";

                cmbProfesional.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarPaciente_Click(object sender, EventArgs e)
        {

            Conexion cn = new Conexion();

            MySqlConnection conexion = cn.conectar();

            try
            {
                conexion.Open();

                string consulta = @"
        SELECT nombre, apellido, telefono, obra_social
        FROM pacientes
        WHERE dni = @dni";

                MySqlCommand cmd =
                    new MySqlCommand(consulta, conexion);

                cmd.Parameters.AddWithValue("@dni", txtDni.Text);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtNombre.Text = reader["nombre"].ToString();
                    txtApellido.Text = reader["apellido"].ToString();
                    txtTelefono.Text = reader["telefono"].ToString();
                    txtObraSocial.Text = reader["obra_social"].ToString();
                }
                else
                {
                    MessageBox.Show("Paciente no encontrado");

                    txtNombre.Clear();
                    txtApellido.Clear();
                    txtTelefono.Clear();
                    txtObraSocial.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
        private void CargarHorariosDisponibles()
        {
            cmbHorarios.Items.Clear();

            string conexion = "server=localhost;database=clinica_seprice;uid=root;pwd=;root";
            MySqlConnection cn = new MySqlConnection(conexion);
            {
                cn.Open();

                string query = @"SELECT hora 
                         FROM turnos 
                         WHERE id_profesional = @idProfesional 
                         AND fecha = @fecha";

                MySqlCommand cmd = new MySqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@idProfesional", cmbProfesional.SelectedValue);
                cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);

                MySqlDataReader reader = cmd.ExecuteReader();

                List<string> ocupados = new List<string>();

                while (reader.Read())
                {
                    ocupados.Add(reader["hora"].ToString());
                }

                reader.Close();

                // Horarios base de la clínica
                List<string> horarios = new List<string>
        {
            "08:00", "08:30", "09:00", "09:30",
            "10:00", "10:30", "11:00"
        };

                foreach (string h in horarios)
                {
                    if (!ocupados.Contains(h))
                    {
                        cmbHorarios.Items.Add(h);
                    }
                }
            }
        }
        private void cmbEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarProfesionales();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            CargarHorariosDisponibles();
        }
    }

}
