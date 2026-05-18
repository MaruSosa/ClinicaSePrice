using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace ClinicaSePrice
{
    public partial class Turnos : Form
    { // mover ventana
        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        [DllImport("gdi32.dll")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
        );
        public Turnos()
        {
            InitializeComponent();
            btnCerrar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnCerrar.FlatAppearance.MouseDownBackColor = Color.FromArgb(60, 60, 60);
            btnMaximizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnMinimizar.FlatAppearance.MouseOverBackColor = Color.FromArgb(60, 60, 60);
            btnNuevoTurno.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 170, 250);
            btnNuevoTurno.FlatAppearance.MouseDownBackColor = Color.FromArgb(20, 130, 210);
            lbFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lbHora.Text = DateTime.Now.ToString("HH:mm");
            panelNuevoTurno.Region = System.Drawing.Region.FromHrgn(
        CreateRoundRectRgn(0, 0,
        panelNuevoTurno.Width,
        panelNuevoTurno.Height,
        20, 20) // <- radio de bordes
    );
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

        private void panelSuperior_Paint(object sender, PaintEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panelSuperior_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void lbHora_Click(object sender, EventArgs e)
        {

        }

        private void timerHora_Tick(object sender, EventArgs e)
        {
            lbHora.Text = DateTime.Now.ToString("HH:mm");
        }

        private void panelNuevoTurno_Paint(object sender, PaintEventArgs e)
        {

        }
        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            panelNuevoTurno.Controls.Clear();

            UcNuevoTurno uc = new UcNuevoTurno();
            uc.Dock = DockStyle.Fill;

            panelNuevoTurno.Controls.Add(uc);
        }
    }
}
