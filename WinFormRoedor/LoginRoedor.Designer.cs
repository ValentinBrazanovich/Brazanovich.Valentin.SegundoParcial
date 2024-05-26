namespace WinFormRoedor
{
    partial class LoginRoedor
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
            txtContraseña = new TextBox();
            txtCorreo = new TextBox();
            btnIngresar = new Button();
            labelCorreo = new Label();
            labelContraseña = new Label();
            SuspendLayout();
            // 
            // txtContraseña
            // 
            txtContraseña.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtContraseña.Location = new Point(50, 145);
            txtContraseña.MaxLength = 20;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(200, 25);
            txtContraseña.TabIndex = 0;
            // 
            // txtCorreo
            // 
            txtCorreo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCorreo.Location = new Point(50, 65);
            txtCorreo.MaxLength = 40;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 25);
            txtCorreo.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresar.Location = new Point(90, 200);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(120, 50);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // labelCorreo
            // 
            labelCorreo.AutoSize = true;
            labelCorreo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelCorreo.Location = new Point(50, 40);
            labelCorreo.Name = "labelCorreo";
            labelCorreo.Size = new Size(58, 21);
            labelCorreo.TabIndex = 3;
            labelCorreo.Text = "Correo";
            // 
            // labelContraseña
            // 
            labelContraseña.AutoSize = true;
            labelContraseña.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelContraseña.Location = new Point(50, 120);
            labelContraseña.Name = "labelContraseña";
            labelContraseña.Size = new Size(89, 21);
            labelContraseña.TabIndex = 4;
            labelContraseña.Text = "Contraseña";
            // 
            // LoginRoedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 280);
            Controls.Add(labelContraseña);
            Controls.Add(labelCorreo);
            Controls.Add(btnIngresar);
            Controls.Add(txtCorreo);
            Controls.Add(txtContraseña);
            Name = "LoginRoedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtContraseña;
        private TextBox txtCorreo;
        private Button btnIngresar;
        private Label labelCorreo;
        private Label labelContraseña;
    }
}
