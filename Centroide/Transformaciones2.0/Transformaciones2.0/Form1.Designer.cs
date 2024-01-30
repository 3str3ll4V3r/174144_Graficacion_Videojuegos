namespace Transformaciones2._0
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            PCT_CANVAS = new PictureBox();
            BTN_Cuadrado = new Button();
            BTN_Rotar = new Button();
            BTN_Trasladar = new Button();
            BTN_Escalado = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            BTN_Triangulo = new Button();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            SuspendLayout();
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.BackColor = SystemColors.Desktop;
            PCT_CANVAS.Location = new Point(0, 2);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(694, 343);
            PCT_CANVAS.TabIndex = 0;
            PCT_CANVAS.TabStop = false;
            // 
            // BTN_Cuadrado
            // 
            BTN_Cuadrado.BackColor = Color.PaleTurquoise;
            BTN_Cuadrado.Location = new Point(12, 360);
            BTN_Cuadrado.Name = "BTN_Cuadrado";
            BTN_Cuadrado.Size = new Size(112, 50);
            BTN_Cuadrado.TabIndex = 1;
            BTN_Cuadrado.Text = "Cuadrado";
            BTN_Cuadrado.UseVisualStyleBackColor = false;
            BTN_Cuadrado.Click += BTN_Figuras_Click;
            // 
            // BTN_Rotar
            // 
            BTN_Rotar.BackColor = Color.Moccasin;
            BTN_Rotar.Location = new Point(340, 397);
            BTN_Rotar.Name = "BTN_Rotar";
            BTN_Rotar.Size = new Size(112, 50);
            BTN_Rotar.TabIndex = 2;
            BTN_Rotar.Text = "Rotar";
            BTN_Rotar.UseVisualStyleBackColor = false;
            BTN_Rotar.Click += BTN_Rotar_Click;
            // 
            // BTN_Trasladar
            // 
            BTN_Trasladar.BackColor = Color.MistyRose;
            BTN_Trasladar.Location = new Point(571, 387);
            BTN_Trasladar.Name = "BTN_Trasladar";
            BTN_Trasladar.Size = new Size(112, 50);
            BTN_Trasladar.TabIndex = 3;
            BTN_Trasladar.Text = "Trasladar";
            BTN_Trasladar.UseVisualStyleBackColor = false;
            BTN_Trasladar.Click += BTN_Escalar_Click;
            // 
            // BTN_Escalado
            // 
            BTN_Escalado.BackColor = Color.Pink;
            BTN_Escalado.Location = new Point(571, 443);
            BTN_Escalado.Name = "BTN_Escalado";
            BTN_Escalado.Size = new Size(112, 50);
            BTN_Escalado.TabIndex = 5;
            BTN_Escalado.Text = "Escalar";
            BTN_Escalado.UseVisualStyleBackColor = false;
            BTN_Escalado.Click += BTN_Escalado_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(323, 453);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 6;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlDarkDark;
            label1.Font = new Font("Stencil", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.Control;
            label1.Location = new Point(231, 360);
            label1.Name = "label1";
            label1.Size = new Size(376, 24);
            label1.TabIndex = 7;
            label1.Text = "Ingresa un angulo, antes de rotar";
            label1.Click += label1_Click;
            // 
            // BTN_Triangulo
            // 
            BTN_Triangulo.BackColor = Color.Aquamarine;
            BTN_Triangulo.Location = new Point(12, 434);
            BTN_Triangulo.Name = "BTN_Triangulo";
            BTN_Triangulo.Size = new Size(112, 50);
            BTN_Triangulo.TabIndex = 8;
            BTN_Triangulo.Text = "Triangulo";
            BTN_Triangulo.UseVisualStyleBackColor = false;
            BTN_Triangulo.Click += button1_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGoldenrodYellow;
            button1.Location = new Point(151, 397);
            button1.Name = "button1";
            button1.Size = new Size(112, 50);
            button1.TabIndex = 9;
            button1.Text = "Pentagono";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(695, 496);
            Controls.Add(button1);
            Controls.Add(BTN_Triangulo);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(BTN_Escalado);
            Controls.Add(BTN_Trasladar);
            Controls.Add(BTN_Rotar);
            Controls.Add(BTN_Cuadrado);
            Controls.Add(PCT_CANVAS);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox PCT_CANVAS;
        private Button BTN_Cuadrado;
        private Button BTN_Rotar;
        private Button BTN_Trasladar;
        private Button BTN_RotarCentro;
        private Button BTN_Escalado;
        private TextBox textBox1;
        private Label label1;
        private Button BTN_Triangulo;
        private Label label2;
        private Button button1;
    }
}
