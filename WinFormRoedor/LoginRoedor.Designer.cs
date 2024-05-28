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
            txtClave = new TextBox();
            txtCorreo = new TextBox();
            btnIngresar = new Button();
            labelCorreo = new Label();
            labelClave = new Label();
            btnRegistro = new Button();
            SuspendLayout();
            // 
            // txtClave
            // 
            txtClave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtClave.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtClave.Location = new Point(50, 145);
            txtClave.MaxLength = 20;
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(200, 25);
            txtClave.TabIndex = 0;
            // 
            // txtCorreo
            // 
            txtCorreo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCorreo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtCorreo.Location = new Point(50, 65);
            txtCorreo.MaxLength = 40;
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(200, 25);
            txtCorreo.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnIngresar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnIngresar.Location = new Point(90, 200);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(120, 50);
            btnIngresar.TabIndex = 2;
            btnIngresar.Text = "Ingresar";
            btnIngresar.UseVisualStyleBackColor = true;
            btnIngresar.Click += BtnIngresar_Click;
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
            // labelClave
            // 
            labelClave.AutoSize = true;
            labelClave.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelClave.Location = new Point(50, 120);
            labelClave.Name = "labelClave";
            labelClave.Size = new Size(48, 21);
            labelClave.TabIndex = 4;
            labelClave.Text = "Clave";
            // 
            // btnRegistro
            // 
            btnRegistro.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRegistro.Location = new Point(233, 12);
            btnRegistro.Name = "btnRegistro";
            btnRegistro.Size = new Size(59, 23);
            btnRegistro.TabIndex = 5;
            btnRegistro.Text = "Registro";
            btnRegistro.UseVisualStyleBackColor = true;
            btnRegistro.Click += BtnRegistro_Click;
            // 
            // LoginRoedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(304, 280);
            Controls.Add(btnRegistro);
            Controls.Add(labelClave);
            Controls.Add(labelCorreo);
            Controls.Add(btnIngresar);
            Controls.Add(txtCorreo);
            Controls.Add(txtClave);
            Name = "LoginRoedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Inicio de sesión";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtClave;
        private TextBox txtCorreo;
        private Button btnIngresar;
        private Label labelCorreo;
        private Label labelClave;
        private Button btnRegistro;
    }
}
