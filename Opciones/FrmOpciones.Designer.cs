namespace Opciones
{
    partial class FrmOpciones
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
            btnHacerSonido = new Button();
            btnCalcularPeso = new Button();
            btnMoverCola = new Button();
            lblInformacion = new Label();
            SuspendLayout();
            // 
            // btnHacerSonido
            // 
            btnHacerSonido.BackColor = Color.DarkSeaGreen;
            btnHacerSonido.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnHacerSonido.Location = new Point(12, 101);
            btnHacerSonido.Name = "btnHacerSonido";
            btnHacerSonido.Size = new Size(102, 47);
            btnHacerSonido.TabIndex = 0;
            btnHacerSonido.Text = "Hacer sonido";
            btnHacerSonido.UseVisualStyleBackColor = false;
            btnHacerSonido.Click += this.BtnHacerSonido_Click;
            // 
            // btnCalcularPeso
            // 
            btnCalcularPeso.BackColor = SystemColors.ActiveCaption;
            btnCalcularPeso.Location = new Point(139, 101);
            btnCalcularPeso.Name = "btnCalcularPeso";
            btnCalcularPeso.Size = new Size(102, 47);
            btnCalcularPeso.TabIndex = 1;
            btnCalcularPeso.Text = "Calcular peso ideal";
            btnCalcularPeso.UseVisualStyleBackColor = false;
            btnCalcularPeso.Click += this.BtnCalcularPesoIdeal_Click;
            // 
            // btnMoverCola
            // 
            btnMoverCola.BackColor = Color.RosyBrown;
            btnMoverCola.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnMoverCola.Location = new Point(266, 101);
            btnMoverCola.Name = "btnMoverCola";
            btnMoverCola.Size = new Size(102, 47);
            btnMoverCola.TabIndex = 2;
            btnMoverCola.Text = "Mover la cola";
            btnMoverCola.UseVisualStyleBackColor = false;
            btnMoverCola.Click += this.BtnMoverCola_Click;
            // 
            // lblInformacion
            // 
            lblInformacion.AutoSize = true;
            lblInformacion.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Point);
            lblInformacion.ForeColor = Color.IndianRed;
            lblInformacion.Location = new Point(41, 31);
            lblInformacion.Name = "lblInformacion";
            lblInformacion.Size = new Size(299, 20);
            lblInformacion.TabIndex = 3;
            lblInformacion.Text = "Según el animal seleccionado usted puede: ";
            // 
            // FrmOpciones
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            ClientSize = new Size(380, 172);
            Controls.Add(lblInformacion);
            Controls.Add(btnMoverCola);
            Controls.Add(btnCalcularPeso);
            Controls.Add(btnHacerSonido);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmOpciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Opciones varias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnHacerSonido;
        private Button btnCalcularPeso;
        private Button btnMoverCola;
        private Label lblInformacion;
    }
}
