namespace VeterinariaExoticos
{
    partial class VeterinariaCRUD
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
            lstRoedores = new ListBox();
            btnAgregar = new Button();
            btnModificar = new Button();
            btnEliminar = new Button();
            menuStrip1 = new MenuStrip();
            SuspendLayout();
            // 
            // lstRoedores
            // 
            lstRoedores.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lstRoedores.FormattingEnabled = true;
            lstRoedores.ItemHeight = 21;
            lstRoedores.Location = new Point(12, 43);
            lstRoedores.Name = "lstRoedores";
            lstRoedores.Size = new Size(729, 235);
            lstRoedores.TabIndex = 0;
            // 
            // btnAgregar
            // 
            btnAgregar.Location = new Point(12, 300);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 50);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(185, 300);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(130, 50);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(359, 300);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 50);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(753, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // VeterinariaCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 378);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(lstRoedores);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "VeterinariaCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Veterinaria Exóticos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstRoedores;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private MenuStrip menuStrip1;
    }
}
