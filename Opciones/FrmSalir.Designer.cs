namespace Opciones
{
    partial class FrmSalir
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // btnVerde
            // 
            btnVerde.Text = "Si";
            btnVerde.Click += BtnVerde_Click;
            // 
            // btnAzul
            // 
            btnAzul.Size = new Size(102, 59);
            btnAzul.Text = "Guardar (En JSON y XML) y salir";
            btnAzul.Click += BtnAzul_Click;
            // 
            // lblInformacion
            // 
            lblInformacion.Location = new Point(78, 30);
            lblInformacion.Size = new Size(223, 20);
            lblInformacion.Text = "¿Está seguro de que desea salir?";
            // 
            // btnRojo
            // 
            btnRojo.Text = "No";
            btnRojo.Click += BtnRojo_Click;
            // 
            // FrmSalir
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 172);
            Name = "FrmSalir";
            Text = "Advertencia";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}