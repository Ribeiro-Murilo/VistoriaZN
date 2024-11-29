using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using VistoriaZN.View;

namespace VistoriaZN
{
    public partial class Dash : Form
    {
        public Panel Selecionado { get; set; }


        public Dash()
        {
            InitializeComponent();
            IniciarNav();
        }

        private void IniciarNav()
        {
            Metodos.Metodos.criarArmazenamento();
        }

        private void Nav_Paint(object sender, PaintEventArgs e)
        {
            PanelForma(sender, e, new List<short> { 25, 117, 209 });
        }

        private void Inicio_Paint(object sender, PaintEventArgs e)
        {
            PanelForma(sender, e, new List<short> { 255, 255, 255 });
        }

        private void Servico_Paint(object sender, PaintEventArgs e)
        {
            PanelForma(sender, e, new List<short> { 255, 255, 255 });
        }

        private void Parceiro_Paint(object sender, PaintEventArgs e)
        {
            PanelForma(sender, e, new List<short> { 255, 255, 255 });
        }

        private void PanelForma(object sender, PaintEventArgs e, List<short> cor)
        {
            Panel panel = (Panel)sender;

            int cornerRadius = 20;
            int arcDiameter = cornerRadius * 1;

            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, arcDiameter, arcDiameter, 180, 90); // Canto superior esquerdo
            path.AddArc(panel.Width - arcDiameter - 1, 0, arcDiameter, arcDiameter, 270, 90); // Canto superior direito
            path.AddArc(panel.Width - arcDiameter - 1, panel.Height - arcDiameter - 1, arcDiameter, arcDiameter, 0, 90); // Canto inferior direito
            path.AddArc(0, panel.Height - arcDiameter - 1, arcDiameter, arcDiameter, 90, 90); // Canto inferior esquerdo
            path.CloseFigure();
            panel.Region = new Region(path);

            using (Brush brush = new SolidBrush(Color.FromArgb(cor[0], cor[1], cor[2])))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.FillPath(brush, path);
            }
            using (Pen pen = new Pen(Color.Black, 2))
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawPath(pen, path);
            }

        }

        private void Selecionar(Panel panel, Form formToOpen)
        {
            List<short> CorSelecionada = new List<short> { 166, 166, 166 };
            List<short> CorPadrao = new List<short> { 255, 255, 255 };

            List<Panel> ListPanel = new List<Panel>()
            {
                Inicio,
                Servico,
                Parceiro
            };

            foreach (var Panel in ListPanel)
            {
                bool ehSelecionado = this.Selecionado == Panel;

                if (ehSelecionado)
                {
                    Panel.Height -= 50;

                }
            }


            formToOpen.TopLevel = false;
            formToOpen.FormBorderStyle = FormBorderStyle.None;
            formToOpen.Dock = DockStyle.Fill;


            BoxInfo.Controls.Clear();
            BoxInfo.Controls.Add(formToOpen);
            BoxInfo.Tag = formToOpen;
            formToOpen.Show();


            panel.Height += 50;
            panel.BackColor = Color.FromArgb(CorPadrao[0], CorPadrao[1], CorPadrao[2]);
        }

        private void Inicio_Click(object sender, EventArgs e)
        {
            Selecionar((Panel)sender, new Inicio());
            Selecionado = (Panel)sender;
        }

        private void Servico_Click(object sender, EventArgs e)
        {
            Selecionar((Panel)sender, new AddServico());
            Selecionado = (Panel)sender;
        }

        private void Parceiro_Click(object sender, EventArgs e)
        {
            Selecionar((Panel)sender, new AddParceiro());
            Selecionado = (Panel)sender;
        }

        private void BoxInfo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dash_Load(object sender, EventArgs e)
        {

        }
    }
}
