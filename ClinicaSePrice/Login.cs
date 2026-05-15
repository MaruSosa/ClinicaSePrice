using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClinicaSePrice
{

    public partial class Login : Form
    {
        Conexion cn = new Conexion();
        // Bordes redondeados
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );

        public Login()
        {
            InitializeComponent();

            // Formulario moderno
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.LightGray;

            // Bordes redondeados del form
            this.Region = Region.FromHrgn(CreateRoundRectRgn
            (
                0, 0, Width, Height, 20, 20
            ));

            // BOTÓN LOGIN
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatAppearance.MouseOverBackColor =
                Color.FromArgb(80, 150, 255);

            btnIngresar.BackColor = Color.FromArgb(26, 50,99);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Font = new Font("Segoe UI", 11, FontStyle.Bold);

            // Bordes redondeados botón login
            btnIngresar.Region = Region.FromHrgn(CreateRoundRectRgn
            (
                0, 0, btnIngresar.Width, btnIngresar.Height, 20, 20
            ));

            // BOTÓN CERRAR
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.Red;

        }
        public class Conexion
        {
            private MySqlConnection conexion = new MySqlConnection(
                "server=localhost;port=3306;database=clinica_seprice;uid=root;pwd=root;"
            );

            public MySqlConnection Conectar()
            {
                if (conexion.State == ConnectionState.Closed)
                    conexion.Open();

                return conexion;
            }

            public void Desconectar()
            {
                if (conexion.State == ConnectionState.Open)
                    conexion.Close();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Click detectado");
            try
            {
                string query = "SELECT * FROM usuarios WHERE usuario=@usuario AND password=@password";

                MySqlCommand cmd = new MySqlCommand(query, cn.Conectar());

                cmd.Parameters.AddWithValue("@usuario", txtUsuario.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    this.Hide();
                    MenuPrincipal menu = new MenuPrincipal();
                    menu.Show();
                }
                else
                {
                    MessageBox.Show("Usuario o contraseña incorrectos");
                }

                cn.Desconectar();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Contraseña_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

    }
}
