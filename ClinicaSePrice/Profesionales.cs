using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
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
            dgvProfesionales.Dock = DockStyle.Fill;
            contenedorGrillaProfesionales.Dock = DockStyle.Fill;
            contenedorGrillaProfesionales.Padding = new Padding(15);
            contenedorGrillaProfesionales.BackColor = Color.White;


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
            
            dgvProfesionales.BorderStyle = BorderStyle.None;
            dgvProfesionales.BackgroundColor = Color.White;
            dgvProfesionales.GridColor = Color.FromArgb(240, 240, 240); // Gris muy claro

            dgvProfesionales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 50, 99);
            dgvProfesionales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfesionales.ColumnHeadersHeight = 40;
            dgvProfesionales.EnableHeadersVisualStyles = false;

            // Filas limpias
            dgvProfesionales.RowTemplate.Height = 35;
            dgvProfesionales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProfesionales.BackgroundColor = Color.FromArgb(230, 240, 250); // Azul suave al seleccionar 
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

        private void contenedorGrillaProfesionales_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelBusqueda_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            float borderRadius = 20f; // Ajusta qué tan redondo lo quieres

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = new GraphicsPath())
            {
                // Definimos las esquinas redondeadas
                path.AddArc(0, 0, borderRadius, borderRadius, 180, 90);
                path.AddArc(panel.Width - borderRadius, 0, borderRadius, borderRadius, 270, 90);
                path.AddArc(panel.Width - borderRadius, panel.Height - borderRadius, borderRadius, borderRadius, 0, 90);
                path.AddArc(0, panel.Height - borderRadius, borderRadius, borderRadius, 90, 90);
                path.CloseAllFigures();

                // Aplicamos la región al panel para que el fondo sea redondo
                panel.Region = new Region(path);

                // Opcional: Dibujar un borde suave si quieres que resalte
                using (Pen pen = new Pen(Color.FromArgb(220, 220, 220), 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}