
namespace CalculadoraBasica
{
    partial class CalculatorForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtDisplay;

        private System.Windows.Forms.Button btn0, btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9;
        private System.Windows.Forms.Button btnPunto, btnSuma, btnResta, btnMul, btnDiv, btnIgual, btnC, btnBack;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculatorForm));
            lblTitulo = new Label();
            txtDisplay = new TextBox();
            lblEstado = new Label();
            btn7 = new Button();
            btn8 = new Button();
            btn9 = new Button();
            btnDiv = new Button();
            btn4 = new Button();
            btn5 = new Button();
            btn6 = new Button();
            btnMul = new Button();
            btn1 = new Button();
            btn2 = new Button();
            btn3 = new Button();
            btnResta = new Button();
            btn0 = new Button();
            btnPunto = new Button();
            btnIgual = new Button();
            btnSuma = new Button();
            btnC = new Button();
            btnBack = new Button();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitulo.Location = new Point(42, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(310, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Calculadora Básica";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtDisplay
            // 
            txtDisplay.BackColor = Color.Gray;
            txtDisplay.Font = new Font("Consolas", 24F, FontStyle.Bold);
            txtDisplay.ForeColor = Color.FromArgb(230, 238, 243);
            txtDisplay.Location = new Point(42, 52);
            txtDisplay.MaxLength = 20;
            txtDisplay.Name = "txtDisplay";
            txtDisplay.ReadOnly = true;
            txtDisplay.Size = new Size(310, 45);
            txtDisplay.TabIndex = 1;
            txtDisplay.Text = "0";
            txtDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // lblEstado
            // 
            lblEstado.Font = new Font("Segoe UI", 14F);
            lblEstado.Location = new Point(12, 111);
            lblEstado.Name = "lblEstado";
            lblEstado.Size = new Size(364, 42);
            lblEstado.TabIndex = 2;
            lblEstado.Text = "Listo.";
            lblEstado.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // btn7
            // 
            btn7.BackColor = Color.FromArgb(42, 49, 54);
            btn7.BackgroundImageLayout = ImageLayout.None;
            btn7.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 230);
            btn7.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn7.ForeColor = Color.FromArgb(230, 238, 243);
            btn7.Location = new Point(12, 184);
            btn7.Name = "btn7";
            btn7.Size = new Size(68, 54);
            btn7.TabIndex = 5;
            btn7.Text = "7";
            btn7.UseVisualStyleBackColor = false;
            btn7.Click += DigitButton_Click;
            // 
            // btn8
            // 
            btn8.BackColor = Color.FromArgb(42, 49, 54);
            btn8.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 230);
            btn8.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn8.ForeColor = Color.FromArgb(230, 238, 243);
            btn8.Location = new Point(86, 184);
            btn8.Name = "btn8";
            btn8.Size = new Size(68, 54);
            btn8.TabIndex = 6;
            btn8.Text = "8";
            btn8.UseVisualStyleBackColor = false;
            btn8.Click += DigitButton_Click;
            // 
            // btn9
            // 
            btn9.BackColor = Color.FromArgb(42, 49, 54);
            btn9.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn9.ForeColor = Color.FromArgb(230, 238, 243);
            btn9.Location = new Point(160, 184);
            btn9.Name = "btn9";
            btn9.Size = new Size(68, 54);
            btn9.TabIndex = 7;
            btn9.Text = "9";
            btn9.UseVisualStyleBackColor = false;
            btn9.Click += DigitButton_Click;
            // 
            // btnDiv
            // 
            btnDiv.BackColor = Color.FromArgb(255, 138, 101);
            btnDiv.FlatAppearance.BorderColor = Color.FromArgb(216, 222, 230);
            btnDiv.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnDiv.ForeColor = Color.FromArgb(11, 11, 11);
            btnDiv.Location = new Point(234, 184);
            btnDiv.Name = "btnDiv";
            btnDiv.Size = new Size(68, 54);
            btnDiv.TabIndex = 8;
            btnDiv.Text = "/";
            btnDiv.UseVisualStyleBackColor = false;
            btnDiv.Click += OperadorButton_Click;
            // 
            // btn4
            // 
            btn4.BackColor = Color.FromArgb(42, 49, 54);
            btn4.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn4.ForeColor = Color.FromArgb(230, 238, 243);
            btn4.Location = new Point(12, 244);
            btn4.Name = "btn4";
            btn4.Size = new Size(68, 54);
            btn4.TabIndex = 9;
            btn4.Text = "4";
            btn4.UseVisualStyleBackColor = false;
            btn4.Click += DigitButton_Click;
            // 
            // btn5
            // 
            btn5.BackColor = Color.FromArgb(42, 49, 54);
            btn5.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn5.ForeColor = Color.FromArgb(230, 238, 243);
            btn5.Location = new Point(86, 244);
            btn5.Name = "btn5";
            btn5.Size = new Size(68, 54);
            btn5.TabIndex = 10;
            btn5.Text = "5";
            btn5.UseVisualStyleBackColor = false;
            btn5.Click += DigitButton_Click;
            // 
            // btn6
            // 
            btn6.BackColor = Color.FromArgb(42, 49, 54);
            btn6.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn6.ForeColor = Color.FromArgb(230, 238, 243);
            btn6.Location = new Point(160, 244);
            btn6.Name = "btn6";
            btn6.Size = new Size(68, 54);
            btn6.TabIndex = 11;
            btn6.Text = "6";
            btn6.UseVisualStyleBackColor = false;
            btn6.Click += DigitButton_Click;
            // 
            // btnMul
            // 
            btnMul.BackColor = Color.FromArgb(255, 138, 101);
            btnMul.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnMul.ForeColor = Color.FromArgb(11, 11, 11);
            btnMul.Location = new Point(234, 244);
            btnMul.Name = "btnMul";
            btnMul.Size = new Size(68, 54);
            btnMul.TabIndex = 12;
            btnMul.Text = "×";
            btnMul.UseVisualStyleBackColor = false;
            btnMul.Click += OperadorButton_Click;
            // 
            // btn1
            // 
            btn1.BackColor = Color.FromArgb(42, 49, 54);
            btn1.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn1.ForeColor = Color.FromArgb(230, 238, 243);
            btn1.Location = new Point(12, 304);
            btn1.Name = "btn1";
            btn1.Size = new Size(68, 54);
            btn1.TabIndex = 13;
            btn1.Text = "1";
            btn1.UseVisualStyleBackColor = false;
            btn1.Click += DigitButton_Click;
            // 
            // btn2
            // 
            btn2.BackColor = Color.FromArgb(42, 49, 54);
            btn2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn2.ForeColor = Color.FromArgb(230, 238, 243);
            btn2.Location = new Point(86, 304);
            btn2.Name = "btn2";
            btn2.Size = new Size(68, 54);
            btn2.TabIndex = 14;
            btn2.Text = "2";
            btn2.UseVisualStyleBackColor = false;
            btn2.Click += DigitButton_Click;
            // 
            // btn3
            // 
            btn3.BackColor = Color.FromArgb(42, 49, 54);
            btn3.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn3.ForeColor = Color.FromArgb(230, 238, 243);
            btn3.Location = new Point(160, 304);
            btn3.Name = "btn3";
            btn3.Size = new Size(68, 54);
            btn3.TabIndex = 15;
            btn3.Text = "3";
            btn3.UseVisualStyleBackColor = false;
            btn3.Click += DigitButton_Click;
            // 
            // btnResta
            // 
            btnResta.BackColor = Color.FromArgb(255, 138, 101);
            btnResta.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnResta.ForeColor = Color.FromArgb(11, 11, 11);
            btnResta.Location = new Point(234, 304);
            btnResta.Name = "btnResta";
            btnResta.Size = new Size(68, 54);
            btnResta.TabIndex = 16;
            btnResta.Text = "−";
            btnResta.UseVisualStyleBackColor = false;
            btnResta.Click += OperadorButton_Click;
            // 
            // btn0
            // 
            btn0.BackColor = Color.FromArgb(42, 49, 54);
            btn0.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btn0.ForeColor = Color.FromArgb(230, 238, 243);
            btn0.Location = new Point(12, 364);
            btn0.Name = "btn0";
            btn0.Size = new Size(142, 54);
            btn0.TabIndex = 17;
            btn0.Text = "0";
            btn0.UseVisualStyleBackColor = false;
            btn0.Click += DigitButton_Click;
            // 
            // btnPunto
            // 
            btnPunto.BackColor = Color.FromArgb(255, 138, 101);
            btnPunto.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnPunto.Location = new Point(160, 364);
            btnPunto.Name = "btnPunto";
            btnPunto.Size = new Size(68, 54);
            btnPunto.TabIndex = 18;
            btnPunto.Text = ".";
            btnPunto.UseVisualStyleBackColor = false;
            btnPunto.Click += PuntoButton_Click;
            // 
            // btnIgual
            // 
            btnIgual.BackColor = Color.FromArgb(67, 160, 71);
            btnIgual.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnIgual.ForeColor = Color.FromArgb(11, 11, 11);
            btnIgual.Location = new Point(308, 304);
            btnIgual.Name = "btnIgual";
            btnIgual.Size = new Size(68, 114);
            btnIgual.TabIndex = 19;
            btnIgual.Text = "=";
            btnIgual.UseVisualStyleBackColor = false;
            btnIgual.Click += IgualButton_Click;
            // 
            // btnSuma
            // 
            btnSuma.BackColor = Color.FromArgb(255, 138, 101);
            btnSuma.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSuma.ForeColor = Color.FromArgb(11, 11, 11);
            btnSuma.Location = new Point(234, 364);
            btnSuma.Name = "btnSuma";
            btnSuma.Size = new Size(68, 54);
            btnSuma.TabIndex = 20;
            btnSuma.Text = "+";
            btnSuma.UseVisualStyleBackColor = false;
            btnSuma.Click += OperadorButton_Click;
            // 
            // btnC
            // 
            btnC.BackColor = Color.FromArgb(229, 57, 53);
            btnC.Cursor = Cursors.Cross;
            btnC.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnC.ForeColor = Color.White;
            btnC.Location = new Point(308, 184);
            btnC.Name = "btnC";
            btnC.Size = new Size(68, 54);
            btnC.TabIndex = 4;
            btnC.Text = "C";
            btnC.UseVisualStyleBackColor = false;
            btnC.Click += ClearButton_Click;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(84, 110, 122);
            btnBack.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(308, 244);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(68, 54);
            btnBack.TabIndex = 3;
            btnBack.Text = "←";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += BackButton_Click;
            // 
            // CalculatorForm
            // 
            AcceptButton = btnIgual;
            AutoScaleMode = AutoScaleMode.Inherit;
            BackColor = Color.MediumAquamarine;
            CancelButton = btnC;
            ClientSize = new Size(390, 459);
            Controls.Add(lblTitulo);
            Controls.Add(txtDisplay);
            Controls.Add(lblEstado);
            Controls.Add(btnBack);
            Controls.Add(btnC);
            Controls.Add(btn7);
            Controls.Add(btn8);
            Controls.Add(btn9);
            Controls.Add(btnDiv);
            Controls.Add(btn4);
            Controls.Add(btn5);
            Controls.Add(btn6);
            Controls.Add(btnMul);
            Controls.Add(btn1);
            Controls.Add(btn2);
            Controls.Add(btn3);
            Controls.Add(btnResta);
            Controls.Add(btn0);
            Controls.Add(btnPunto);
            Controls.Add(btnIgual);
            Controls.Add(btnSuma);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "CalculatorForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculadora Básica";
            Load += CalculatorForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}