namespace WinFormR
{
    partial class FrmRoedor
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
            btnAceptar = new Button();
            rdoHamster = new RadioButton();
            rdoRaton = new RadioButton();
            rdoTopo = new RadioButton();
            labelPeso = new Label();
            txtAtributo = new TextBox();
            labelAtributo = new Label();
            txtPeso = new TextBox();
            labelAlimentacion = new Label();
            labelNombre = new Label();
            checkAtributo = new CheckBox();
            txtNombre = new TextBox();
            comboAlimentacion = new ComboBox();
            labelRequeridos = new Label();
            labelOpcionales = new Label();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnAceptar.Location = new Point(50, 295);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(130, 40);
            btnAceptar.TabIndex = 10;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += BtnAceptar_Click;
            // 
            // rdoHamster
            // 
            rdoHamster.AutoSize = true;
            rdoHamster.Checked = true;
            rdoHamster.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoHamster.Location = new Point(30, 253);
            rdoHamster.Name = "rdoHamster";
            rdoHamster.Size = new Size(87, 25);
            rdoHamster.TabIndex = 11;
            rdoHamster.TabStop = true;
            rdoHamster.Text = "Hámster";
            rdoHamster.UseVisualStyleBackColor = true;
            rdoHamster.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // rdoRaton
            // 
            rdoRaton.AutoSize = true;
            rdoRaton.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoRaton.Location = new Point(177, 253);
            rdoRaton.Name = "rdoRaton";
            rdoRaton.Size = new Size(69, 25);
            rdoRaton.TabIndex = 12;
            rdoRaton.Text = "Ratón";
            rdoRaton.UseVisualStyleBackColor = true;
            rdoRaton.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // rdoTopo
            // 
            rdoTopo.AutoSize = true;
            rdoTopo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoTopo.Location = new Point(329, 253);
            rdoTopo.Name = "rdoTopo";
            rdoTopo.Size = new Size(61, 25);
            rdoTopo.TabIndex = 13;
            rdoTopo.Text = "Topo";
            rdoTopo.UseVisualStyleBackColor = true;
            rdoTopo.CheckedChanged += RadioButton_CheckedChanged;
            // 
            // labelPeso
            // 
            labelPeso.AutoSize = true;
            labelPeso.Location = new Point(30, 100);
            labelPeso.Name = "labelPeso";
            labelPeso.Size = new Size(45, 15);
            labelPeso.TabIndex = 8;
            labelPeso.Text = "Peso **";
            // 
            // txtAtributo
            // 
            txtAtributo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtAtributo.Location = new Point(240, 48);
            txtAtributo.Name = "txtAtributo";
            txtAtributo.Size = new Size(150, 25);
            txtAtributo.TabIndex = 5;
            // 
            // labelAtributo
            // 
            labelAtributo.AutoSize = true;
            labelAtributo.Location = new Point(240, 30);
            labelAtributo.Name = "labelAtributo";
            labelAtributo.Size = new Size(63, 15);
            labelAtributo.TabIndex = 9;
            labelAtributo.Text = "Longitud *";
            // 
            // txtPeso
            // 
            txtPeso.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtPeso.Location = new Point(30, 118);
            txtPeso.Name = "txtPeso";
            txtPeso.Size = new Size(150, 25);
            txtPeso.TabIndex = 2;
            // 
            // labelAlimentacion
            // 
            labelAlimentacion.AutoSize = true;
            labelAlimentacion.Location = new Point(30, 170);
            labelAlimentacion.Name = "labelAlimentacion";
            labelAlimentacion.Size = new Size(128, 15);
            labelAlimentacion.TabIndex = 6;
            labelAlimentacion.Text = "Tipo de Alimentacion *";
            // 
            // labelNombre
            // 
            labelNombre.AutoSize = true;
            labelNombre.Location = new Point(30, 30);
            labelNombre.Name = "labelNombre";
            labelNombre.Size = new Size(59, 15);
            labelNombre.TabIndex = 0;
            labelNombre.Text = "Nombre *";
            // 
            // checkAtributo
            // 
            checkAtributo.AutoSize = true;
            checkAtributo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            checkAtributo.Location = new Point(240, 118);
            checkAtributo.Name = "checkAtributo";
            checkAtributo.Size = new Size(101, 23);
            checkAtributo.TabIndex = 14;
            checkAtributo.Text = "Es nocturno";
            checkAtributo.UseVisualStyleBackColor = true;
            // 
            // txtNombre
            // 
            txtNombre.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtNombre.Location = new Point(30, 48);
            txtNombre.MaxLength = 20;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(150, 25);
            txtNombre.TabIndex = 1;
            // 
            // comboAlimentacion
            // 
            comboAlimentacion.DropDownStyle = ComboBoxStyle.DropDownList;
            comboAlimentacion.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            comboAlimentacion.FormattingEnabled = true;
            comboAlimentacion.ImeMode = ImeMode.NoControl;
            comboAlimentacion.Location = new Point(30, 188);
            comboAlimentacion.Name = "comboAlimentacion";
            comboAlimentacion.Size = new Size(150, 25);
            comboAlimentacion.TabIndex = 15;
            // 
            // labelRequeridos
            // 
            labelRequeridos.AutoSize = true;
            labelRequeridos.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelRequeridos.ForeColor = Color.Red;
            labelRequeridos.Location = new Point(298, 166);
            labelRequeridos.Name = "labelRequeridos";
            labelRequeridos.Size = new Size(87, 19);
            labelRequeridos.TabIndex = 16;
            labelRequeridos.Text = "* Requeridos";
            // 
            // labelOpcionales
            // 
            labelOpcionales.AutoSize = true;
            labelOpcionales.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            labelOpcionales.ForeColor = SystemColors.MenuHighlight;
            labelOpcionales.Location = new Point(298, 194);
            labelOpcionales.Name = "labelOpcionales";
            labelOpcionales.Size = new Size(92, 19);
            labelOpcionales.TabIndex = 17;
            labelOpcionales.Text = "** Opcionales";
            // 
            // btnCancelar
            // 
            btnCancelar.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            btnCancelar.Location = new Point(240, 295);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(130, 40);
            btnCancelar.TabIndex = 18;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += BtnCancelar_Click;
            // 
            // FrmRoedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 359);
            Controls.Add(btnCancelar);
            Controls.Add(labelOpcionales);
            Controls.Add(labelRequeridos);
            Controls.Add(comboAlimentacion);
            Controls.Add(checkAtributo);
            Controls.Add(rdoTopo);
            Controls.Add(rdoRaton);
            Controls.Add(rdoHamster);
            Controls.Add(btnAceptar);
            Controls.Add(labelAtributo);
            Controls.Add(labelPeso);
            Controls.Add(labelAlimentacion);
            Controls.Add(txtAtributo);
            Controls.Add(txtPeso);
            Controls.Add(txtNombre);
            Controls.Add(labelNombre);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "FrmRoedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Roedor";
            Load += FrmRoedor_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnAceptar;
        private RadioButton rdoHamster;
        private RadioButton rdoRaton;
        private RadioButton rdoTopo;
        private Label labelPeso;
        private TextBox txtAtributo;
        private Label labelAtributo;
        private TextBox txtPeso;
        private Label labelAlimentacion;
        private Label labelNombre;
        private CheckBox checkAtributo;
        private TextBox txtNombre;
        private ComboBox comboAlimentacion;
        private Label labelRequeridos;
        private Label labelOpcionales;
        private Button btnCancelar;
    }
}
