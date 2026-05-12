using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace ClinicaSePrice
{
    public partial class Profesionales : Form
    {
        Conexion cn = new Conexion();

        public Profesionales()
        {
            InitializeComponent();
            EstiloTabla();
            dgvProfesionales.CellClick += dgvProfesionales_CellClick;
        
        }

        private void Profesionales_Load(object sender, EventArgs e)
        {
            MostrarProfesionales();
        }

        private void MostrarProfesionales()
        {
            MySqlConnection conexion = cn.conectar();

            string consulta = "SELECT * FROM profesionales";

            MySqlDataAdapter adaptador =
                new MySqlDataAdapter(consulta, conexion);

            DataTable tabla = new DataTable();

            adaptador.Fill(tabla);

            dgvProfesionales.DataSource = tabla;
            if (!dgvProfesionales.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar =
                    new DataGridViewButtonColumn();

                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "✏";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.DefaultCellStyle.BackColor = Color.LightGreen;
                btnEditar.DefaultCellStyle.ForeColor = Color.White;
                btnEditar.DefaultCellStyle.SelectionBackColor = Color.RoyalBlue;
                btnEditar.FlatStyle = FlatStyle.Flat;

                dgvProfesionales.Columns.Add(btnEditar);
            }

            // BOTON ELIMINAR
            if (!dgvProfesionales.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar =
                    new DataGridViewButtonColumn();

                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "🗑";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.DefaultCellStyle.BackColor = Color.IndianRed;
                btnEliminar.DefaultCellStyle.ForeColor = Color.White;
                btnEliminar.DefaultCellStyle.SelectionBackColor = Color.Firebrick;
                btnEliminar.FlatStyle = FlatStyle.Flat;

                dgvProfesionales.Columns.Add(btnEliminar);
            }
        }

        private void EstiloTabla()
        {
            dgvProfesionales.EnableHeadersVisualStyles = false;

            dgvProfesionales.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(13, 43, 82);

            dgvProfesionales.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvProfesionales.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 11, FontStyle.Bold);

            dgvProfesionales.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvProfesionales.RowTemplate.Height = 35;

            dgvProfesionales.AlternatingRowsDefaultCellStyle.BackColor =
                Color.FromArgb(245, 245, 245);
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void dgvProfesionales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvProfesionales.Columns["Eliminar"].Index)
            {
                MessageBox.Show("Eliminar profesional");
            }

            if (e.ColumnIndex == dgvProfesionales.Columns["Editar"].Index)
            {
                MessageBox.Show("Editar profesional");
            }
        }
    }
}