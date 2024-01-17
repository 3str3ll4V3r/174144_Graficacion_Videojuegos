namespace Primer_Trabajo
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
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            PCT_CANVAS = new PictureBox();
            BTN_EXE = new Button();
            TextB = new TextBox();
            BTN = new Button();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(16, 9);
            label1.Name = "label1";
            label1.Size = new Size(327, 22);
            label1.TabIndex = 1;
            label1.Text = "Nombre: Estrella Jissel Verdiguel Colin";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(58, 55);
            label3.Name = "label3";
            label3.Size = new Size(219, 22);
            label3.TabIndex = 4;
            label3.Text = "Graficación y videojuegos";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(111, 31);
            label2.Name = "label2";
            label2.Size = new Size(101, 22);
            label2.TabIndex = 3;
            label2.Text = "ID: 174144";
            // 
            // PCT_CANVAS
            // 
            PCT_CANVAS.Location = new Point(395, 55);
            PCT_CANVAS.Name = "PCT_CANVAS";
            PCT_CANVAS.Size = new Size(368, 351);
            PCT_CANVAS.TabIndex = 5;
            PCT_CANVAS.TabStop = false;
            PCT_CANVAS.Click += pictureBox1_Click;
            // 
            // BTN_EXE
            // 
            BTN_EXE.ForeColor = SystemColors.ActiveCaptionText;
            BTN_EXE.Location = new Point(100, 152);
            BTN_EXE.Name = "BTN_EXE";
            BTN_EXE.Size = new Size(112, 34);
            BTN_EXE.TabIndex = 6;
            BTN_EXE.Text = "Mostrar";
            BTN_EXE.UseVisualStyleBackColor = true;
            BTN_EXE.Click += BTN_EXE_Click;
            // 
            // TextB
            // 
            TextB.BackColor = Color.Thistle;
            TextB.Location = new Point(12, 104);
            TextB.Name = "TextB";
            TextB.Size = new Size(357, 31);
            TextB.TabIndex = 7;
            // 
            // BTN
            // 
            BTN.ForeColor = SystemColors.ActiveCaptionText;
            BTN.Location = new Point(12, 219);
            BTN.Name = "BTN";
            BTN.Size = new Size(112, 34);
            BTN.TabIndex = 8;
            BTN.Text = "Normal";
            BTN.UseVisualStyleBackColor = true;
            BTN.Click += BTN_Click;
            // 
            // button1
            // 
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Location = new Point(148, 219);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 9;
            button1.Text = "otro";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.ForeColor = SystemColors.ActiveCaptionText;
            button2.Location = new Point(16, 278);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 10;
            button2.Text = "Center";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.ForeColor = SystemColors.ActiveCaptionText;
            button3.Location = new Point(148, 278);
            button3.Name = "button3";
            button3.Size = new Size(112, 34);
            button3.TabIndex = 11;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Desktop;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(BTN);
            Controls.Add(TextB);
            Controls.Add(BTN_EXE);
            Controls.Add(PCT_CANVAS);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            ForeColor = SystemColors.ButtonFace;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)PCT_CANVAS).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label3;
        private Label label2;
        private PictureBox PCT_CANVAS;
        private Button BTN_EXE;
        private TextBox TextB;
        private Button BTN;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}
