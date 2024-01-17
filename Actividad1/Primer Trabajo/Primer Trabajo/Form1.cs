namespace Primer_Trabajo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void BTN_EXE_Click(object sender, EventArgs e)
        {
            string str = @"C:\Users\Verdi\OneDrive\Imágenes\Capturas de pantalla\174144_PrimerTrabajo.png";
            Bitmap bmp = new Bitmap(str);
            PCT_CANVAS.Image = bmp;
        }

        private void BTN_Click(object sender, EventArgs e)
        {
            PCT_CANVAS.SizeMode = PictureBoxSizeMode.Normal;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PCT_CANVAS.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PCT_CANVAS.SizeMode = PictureBoxSizeMode.CenterImage;
        }
        int x = 100;
        int y = 100;
        Random rand = new Random();
        private void button3_Click(object sender, EventArgs e)
        {
            x = x + 10;
            y = y + 10;
            Bitmap bmp = new Bitmap(640, 480);
            Graphics.FromImage(bmp).DrawLine(Pens.Yellow,rand.Next(0,1000), y, 150, 50);
            PCT_CANVAS.Image = bmp;
        }
    }
}
