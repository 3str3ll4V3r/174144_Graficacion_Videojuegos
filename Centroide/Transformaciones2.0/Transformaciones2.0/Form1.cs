using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Transformaciones2._0
{
    public partial class Form1 : Form
    {
        static Bitmap bmp;
        Canvas canvas;
        Figura figura;
        double rotar;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            canvas = new Canvas(Graphics.FromImage(bmp), bmp);
            PCT_CANVAS.Image = bmp;
            canvas.Render(new Size(PCT_CANVAS.Width, PCT_CANVAS.Height));
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {

            if (figura != null)
            {
                canvas.Clear();
                canvas.Render(new Size(PCT_CANVAS.Width, PCT_CANVAS.Height));
                canvas.RenderFigura(figura);
            }
            PCT_CANVAS.Invalidate();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void BTN_Figuras_Click(object sender, EventArgs e)
        {

            int cx = PCT_CANVAS.Width / 2;
            int cy = PCT_CANVAS.Height / 2;
            int lado = 100;
            figura = Figura.Cuadrado(cx, cy, lado);
            Init();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            int cx = PCT_CANVAS.Width / 2;
            int cy = PCT_CANVAS.Height / 2;
            int lado = 100;
            figura = Figura.Triangulo(cx, cy, lado);
            Init();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            int cx = PCT_CANVAS.Width / 2;
            int cy = PCT_CANVAS.Height / 2;
            int lado = 100;
            figura = Figura.Pentagono(cx, cy, lado);
            Init();
        }
        private void BTN_Rotar_Click(object sender, EventArgs e)
        {
            rotar = Convert.ToDouble(textBox1.Text);
            rotar = rotar * Math.PI / 180;

            if (figura != null)
            {
                figura.Rotar(rotar);
                Init();
            }
        }

        private void BTN_Escalar_Click(object sender, EventArgs e)
        {
            if (figura != null)
            {
                figura.Trasladar(PCT_CANVAS.Size);
                Init();
            }
        }


        private void BTN_Escalado_Click(object sender, EventArgs e)
        {
            if (figura != null)
            {
                figura.Escalar();
                Init();
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
