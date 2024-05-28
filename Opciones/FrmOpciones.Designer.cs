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
            btnVerde = new Button();
            btnAzul = new Button();
            btnRojo = new Button();
            lblInformacion = new Label();
            SuspendLayout();
            // 
            // btnVerde
            // 
            btnVerde.BackColor = Color.DarkSeaGreen;
            btnVerde.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnVerde.Location = new Point(12, 101);
            btnVerde.Name = "btnVerde";
            btnVerde.Size = new Size(102, 47);
            btnVerde.TabIndex = 0;
            btnVerde.Text = "Hacer sonido";
            btnVerde.UseVisualStyleBackColor = false;
            btnVerde.Click += BtnVerde_Click;
            // 
            // btnAzul
            // 
            btnAzul.BackColor = SystemColors.ActiveCaption;
            btnAzul.Location = new Point(139, 101);
            btnAzul.Name = "btnAzul";
            btnAzul.Size = new Size(102, 47);
            btnAzul.TabIndex = 1;
            btnAzul.Text = "Calcular peso ideal";
            btnAzul.UseVisualStyleBackColor = false;
            btnAzul.Click += BtnAzul_Click;
            // 
            // btnRojo
            // 
            btnRojo.BackColor = Color.RosyBrown;
            btnRojo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnRojo.Location = new Point(266, 101);
            btnRojo.Name = "btnRojo";
            btnRojo.Size = new Size(102, 47);
            btnRojo.TabIndex = 2;
            btnRojo.Text = "Mover la cola";
            btnRojo.UseVisualStyleBackColor = false;
            btnRojo.Click += BtnRojo_Click;
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
            Controls.Add(btnRojo);
            Controls.Add(btnAzul);
            Controls.Add(btnVerde);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmOpciones";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Opciones varias";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        protected Button btnVerde;
        protected Button btnAzul;
        protected Label lblInformacion;
        protected Button btnRojo;
    }
}
