using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSePrice
{
    public partial class UcVerTurnos : UserControl
    {
        public UcVerTurnos()
        {
            InitializeComponent();
            EstiloDataGrid();
            
        }

        // ================= ESTILO =================
        private void EstiloDataGrid()
        {
            dgvVerTurnos.EnableHeadersVisualStyles = false;

            dgvVerTurnos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 144, 255);
            dgvVerTurnos.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvVerTurnos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);

            dgvVerTurnos.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvVerTurnos.DefaultCellStyle.SelectionBackColor = Color.LightSteelBlue;
            dgvVerTurnos.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvVerTurnos.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);
        }

        // ================= CARGAR TODO =================
        private void CargarTurnos()
        {
            string conexion = "server=localhost;database=clinica_seprice;uid=root;pwd=root;";

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            t.id_turno,
                            p.nombre,
                            p.apellido,
                            t.fecha,
                            t.hora,
                            t.estado
                        FROM turnos t
                        INNER JOIN pacientes p ON t.id_paciente = p.id_paciente
                        ORDER BY t.fecha DESC, t.hora ASC";

                    MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvVerTurnos.DataSource = dt;

                    if (dgvVerTurnos.Columns.Contains("id_turno"))
                        dgvVerTurnos.Columns["id_turno"].Visible = false;

                    dgvVerTurnos.Columns["nombre"].HeaderText = "Nombre";
                    dgvVerTurnos.Columns["apellido"].HeaderText = "Apellido";
                    dgvVerTurnos.Columns["fecha"].HeaderText = "Fecha";
                    dgvVerTurnos.Columns["hora"].HeaderText = "Hora";
                    dgvVerTurnos.Columns["estado"].HeaderText = "Estado";

                    dgvVerTurnos.Refresh();
                    PintarFilas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        // ================= FILTRAR POR FECHA =================
        private void FiltrarPorFecha()
        {
            string conexion = "server=localhost;database=clinica_seprice;uid=root;pwd=root;";

            using (MySqlConnection conn = new MySqlConnection(conexion))
            {
                try
                {
                    conn.Open();

                    string query = @"
                        SELECT 
                            t.id_turno,
                            p.nombre,
                            p.apellido,
                            t.fecha,
                            t.hora,
                            t.estado
                        FROM turnos t
                        INNER JOIN pacientes p ON t.id_paciente = p.id_paciente
                        WHERE DATE(t.fecha) = DATE(@fecha)
                        ORDER BY t.hora ASC";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@fecha", dtpFecha.Value.Date);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvVerTurnos.DataSource = dt;

                    if (dgvVerTurnos.Columns.Contains("id_turno"))
                        dgvVerTurnos.Columns["id_turno"].Visible = false;

                    dgvVerTurnos.Refresh();
                    PintarFilas();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error filtro: " + ex.Message);
                }
            }
        }

        // ================= BOTÓN BUSCAR =================
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (dtpFecha.Value == null)
            {
                dgvVerTurnos.DataSource = null;
                return;
            }

            FiltrarPorFecha();
        }

        // ================= COLORES POR ESTADO =================
        private void PintarFilas()
        {
            foreach (DataGridViewRow row in dgvVerTurnos.Rows)
            {
                if (row.Cells["estado"].Value == null) continue;

                string estado = row.Cells["estado"].Value.ToString();

                if (estado == "Confirmado")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(198, 239, 206);

                else if (estado == "Pendiente")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 235, 156);

                else if (estado == "Cancelado")
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 199, 206);
            }
        }
    }
}