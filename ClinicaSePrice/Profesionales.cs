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

            btnMaximizar.Click += btnMaximizar_Click;
            btnMinimizar.Click += btnMinimizar_Click;

            CargarEspecialidades();

            btnBuscar.FlatStyle = FlatStyle.Flat;
            btnBuscar.FlatAppearance.BorderSize = 0;
            btnBuscar.BackColor = Color.FromArgb(20, 45, 90);
            btnBuscar.ForeColor = Color.White;
            btnBuscar.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            btnBuscar.Width = 110;
            btnBuscar.Height = 40;
            btnBuscar.Cursor = Cursors.Hand;
            
            txtBuscar.Text = "Ingrese nombre";
            txtBuscar.Height = 40;
            txtBuscar.Width = 120;
            txtBuscar.ForeColor = Color.Gray;
            txtBuscar.Enter += (s, e) =>
            {
                if (txtBuscar.Text == "Ingrese nombre")
                {
                    txtBuscar.Text = "";
                    txtBuscar.ForeColor = Color.Black;
                }
            };

            txtBuscar.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtBuscar.Text))
                {
                    txtBuscar.Text = "Ingrese nombre";
                    txtBuscar.ForeColor = Color.Gray;
                }
            };

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

            string consulta = @"
                SELECT 
                    p.id_profesional,
                    p.nombre,
                    p.apellido,
                    e.nombre_especialidad AS especialidad
                FROM profesionales p
                INNER JOIN especialidades e 
                    ON p.id_especialidad = e.id_especialidad";

            MySqlDataAdapter adaptador = new MySqlDataAdapter(consulta, conexion);
            DataTable tabla = new DataTable();
            adaptador.Fill(tabla);

            dgvProfesionales.Columns.Clear(); // importante para evitar duplicados
            dgvProfesionales.DataSource = tabla;

            // BOTÓN EDITAR
            if (!dgvProfesionales.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn btnEditar = new DataGridViewButtonColumn();
                btnEditar.Name = "Editar";
                btnEditar.HeaderText = "Editar";
                btnEditar.Text = "✏";
                btnEditar.UseColumnTextForButtonValue = true;
                btnEditar.DefaultCellStyle.BackColor = Color.LightGreen;
                btnEditar.DefaultCellStyle.ForeColor = Color.White;
                btnEditar.FlatStyle = FlatStyle.Flat;

                dgvProfesionales.Columns.Add(btnEditar);
            }

            // BOTÓN ELIMINAR
            if (!dgvProfesionales.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn btnEliminar = new DataGridViewButtonColumn();
                btnEliminar.Name = "Eliminar";
                btnEliminar.HeaderText = "Eliminar";
                btnEliminar.Text = "🗑";
                btnEliminar.UseColumnTextForButtonValue = true;
                btnEliminar.DefaultCellStyle.BackColor = Color.IndianRed;
                btnEliminar.DefaultCellStyle.ForeColor = Color.White;
                btnEliminar.FlatStyle = FlatStyle.Flat;

                dgvProfesionales.Columns.Add(btnEliminar);
            }
        }


        private void EstiloTabla()
        {
            dgvProfesionales.EnableHeadersVisualStyles = false;
            
            dgvProfesionales.BorderStyle = BorderStyle.None;
            dgvProfesionales.BackgroundColor = Color.White;
            dgvProfesionales.GridColor = Color.FromArgb(240, 240, 240); 

            dgvProfesionales.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(26, 50, 99);
            dgvProfesionales.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvProfesionales.ColumnHeadersHeight = 40;
            dgvProfesionales.EnableHeadersVisualStyles = false;

          
            dgvProfesionales.RowTemplate.Height = 35;
            dgvProfesionales.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvProfesionales.BackgroundColor = Color.FromArgb(230, 240, 250); 
            btnMaximizar.FlatStyle = FlatStyle.Flat;
            btnMaximizar.FlatAppearance.BorderSize = 0;
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }
        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        // metodo para traer las especialidades de la base de datos
        private void CargarEspecialidades()
        {
            try
            {
                MySqlConnection conexion = cn.conectar();

                conexion.Open();

                string query = "SELECT id_especialidad, nombre_especialidad FROM especialidades";

                MySqlDataAdapter da = new MySqlDataAdapter(query, conexion);

                DataTable dt = new DataTable();

                da.Fill(dt);

                cmbEspecialidad.DataSource = dt;

                cmbEspecialidad.DisplayMember = "nombre_especialidad";

                cmbEspecialidad.ValueMember = "id_especialidad";

                conexion.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

       
    }
}