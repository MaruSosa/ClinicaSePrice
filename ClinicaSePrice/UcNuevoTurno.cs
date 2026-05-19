using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace ClinicaSePrice
{
    public partial class UcNuevoTurno : UserControl
    {
        public UcNuevoTurno()
        {
            InitializeComponent();
            CargarEstudios();
           

        }

        // BUSCAR PACIENTE
        private void BuscarPacientePorDni()
        {
            string conexion = "server=localhost;database=clinica_seprice;uid=root;pwd=root;";

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = @"SELECT nombre, apellido, obra_social, telefono
                                     FROM pacientes
                                     WHERE dni = @dni";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@dni", txtDni.Text);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtNombre.Text = reader["nombre"].ToString();
                        txtApellido.Text = reader["apellido"].ToString();
                        txtObraSocial.Text = reader["obra_social"].ToString();
                        txtTelefono.Text = reader["telefono"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Paciente no encontrado");

                        txtNombre.Text = "";
                        txtApellido.Text = "";
                        txtObraSocial.Text = "";
                        txtTelefono.Text = "";
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error paciente: " + ex.Message);
                }
            }
        }

        // CARGAR ESTUDIOS
        private void CargarEstudios()
        {
            cmbEstudio.Items.Clear();

            cmbEstudio.Items.Add("Ecografía");
            cmbEstudio.Items.Add("Radiografía");
            cmbEstudio.Items.Add("Tomografía");
            cmbEstudio.Items.Add("Resonancia");
        }

        // CARGAR PROFESIONALES
        private void CargarProfesionales()
        {
            cmbProfesional.Items.Clear();

            string conexion = "server=localhost;database=clinica_seprice;uid=root;pwd=root;";

            int idEstudio = 0;

            if (cmbEstudio.Text == "Ecografía")
                idEstudio = 1;

            else if (cmbEstudio.Text == "Radiografía")
                idEstudio = 2;

            else if (cmbEstudio.Text == "Tomografía")
                idEstudio = 3;

            else if (cmbEstudio.Text == "Resonancia")
                idEstudio = 4;

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = @"
                    SELECT nombre, apellido
                    FROM profesionales
                    WHERE id_estudio = @id";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id", idEstudio);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string profesional =
                            reader["nombre"].ToString() + " " +
                            reader["apellido"].ToString();

                        cmbProfesional.Items.Add(profesional);
                    }

                    reader.Close();

                    if (cmbProfesional.Items.Count == 0)
                    {
                        MessageBox.Show("No hay profesionales");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error profesionales: " + ex.Message);
                }
            }
        }
        private void cmbEstudio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool ValidarCampos()
        {
            if (txtDni.Text == "")
            {
                MessageBox.Show("Ingrese DNI");
                return false;
            }

            if (txtNombre.Text == "")
            {
                MessageBox.Show("Busque un paciente");
                return false;
            }

            if (cmbEstudio.Text == "")
            {
                MessageBox.Show("Seleccione estudio");
                return false;
            }

            if (cmbProfesional.Text == "")
            {
                MessageBox.Show("Seleccione profesional");
                return false;
            }

            if (cmbHorario.Text == "")
            {
                MessageBox.Show("Seleccione horario");
                return false;
            }

            return true;
        }
        private void GuardarTurno()
        {
            if (!ValidarCampos())
                return;

            string conexion = "server=localhost;database=clinica_seprice;uid=root;pwd=root;";

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    // BUSCAR ID PACIENTE
                    string queryPaciente = @"
            SELECT id_paciente
            FROM pacientes
            WHERE dni = @dni";

                    MySqlCommand cmdPaciente = new MySqlCommand(queryPaciente, conn);

                    cmdPaciente.Parameters.AddWithValue("@dni", txtDni.Text);

                    int idPaciente = Convert.ToInt32(cmdPaciente.ExecuteScalar());

                    // INSERTAR TURNO
                    string query = @"
            INSERT INTO turnos
            (id_paciente, profesional, fecha, hora, estado)
            VALUES
            (@id_paciente, @profesional, @fecha, @hora, @estado)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@id_paciente", idPaciente);
                    cmd.Parameters.AddWithValue("@profesional", cmbProfesional.Text);
                    cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);
                    cmd.Parameters.AddWithValue("@hora", cmbHorario.Text);
                    cmd.Parameters.AddWithValue("@estado", "Pendiente");

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Turno guardado correctamente");

                    LimpiarCampos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error guardar turno: " + ex.Message);
                }
            }
        }
        private void LimpiarCampos()
        {
            txtDni.Clear();
            txtNombre.Clear();
            txtApellido.Clear();
            txtObraSocial.Clear();
            txtTelefono.Clear();

            cmbEstudio.SelectedIndex = -1;
            cmbProfesional.SelectedIndex = -1;
            cmbHorario.SelectedIndex = -1;
        }

        private void btnGuardarTurno_Click(object sender, EventArgs e)
        {
            GuardarTurno();
        }

        private void btnBuscarPaciente_Click_1(object sender, EventArgs e)
        {
            BuscarPacientePorDni();
            
        }

        private void btnBuscarDisponibilidad_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Botón funcionando");

            BuscarDisponibilidad();
        }
        private void BuscarDisponibilidad()
        {
            MessageBox.Show("Entró al método");

            CargarProfesionales();

            cmbHorario.Items.Clear();

            cmbHorario.Items.Add("08:00");
            cmbHorario.Items.Add("09:00");
        }
    }
}