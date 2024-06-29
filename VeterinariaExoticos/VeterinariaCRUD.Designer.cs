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
            JSONToolStrip = new ToolStripMenuItem();
            JSONToolStripMenuItem = new ToolStripMenuItem();
            XMLMenuItem = new ToolStripMenuItem();
            deserializarToolStripMenuItem = new ToolStripMenuItem();
            jSONToolStripMenuItem1 = new ToolStripMenuItem();
            xMLToolStripMenuItem1 = new ToolStripMenuItem();
            ordenarToolStripMenuItem = new ToolStripMenuItem();
            ascendenteToolStripMenuItem = new ToolStripMenuItem();
            porNombreToolStripMenuItem = new ToolStripMenuItem();
            porPesoToolStripMenuItem = new ToolStripMenuItem();
            descendenteToolStripMenuItem = new ToolStripMenuItem();
            porNombreToolStripMenuItem1 = new ToolStripMenuItem();
            porPesoToolStripMenuItem1 = new ToolStripMenuItem();
            verToolStripMenuItem = new ToolStripMenuItem();
            registroDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            calcularToolStripMenuItem = new ToolStripMenuItem();
            pesoPromedioToolStripMenuItem = new ToolStripMenuItem();
            hámsterToolStripMenuItem = new ToolStripMenuItem();
            ratónToolStripMenuItem = new ToolStripMenuItem();
            topoToolStripMenuItem = new ToolStripMenuItem();
            aDOToolStripMenuItem = new ToolStripMenuItem();
            serializarEnBaseDeDatosToolStripMenuItem = new ToolStripMenuItem();
            deserializarEnBaseDeDatosToolStripMenuItem = new ToolStripMenuItem();
            lblHamster = new Label();
            lblTopo = new Label();
            lblRaton = new Label();
            BtnActualizar = new Button();
            statusStrip1 = new StatusStrip();
            toolStripStatusLabel1 = new ToolStripStatusLabel();
            toolStripStatusLabel2 = new ToolStripStatusLabel();
            BtnOpciones = new Button();
            BDLabel = new Label();
            ConeccionBaseDatosLabel = new Label();
            menuStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // lstRoedores
            // 
            lstRoedores.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstRoedores.DrawMode = DrawMode.OwnerDrawFixed;
            lstRoedores.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lstRoedores.FormattingEnabled = true;
            lstRoedores.ItemHeight = 21;
            lstRoedores.Location = new Point(12, 43);
            lstRoedores.Name = "lstRoedores";
            lstRoedores.Size = new Size(729, 235);
            lstRoedores.TabIndex = 0;
            lstRoedores.DrawItem += LstRoedores_DrawItem;
            // 
            // btnAgregar
            // 
            btnAgregar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnAgregar.Location = new Point(12, 300);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(130, 50);
            btnAgregar.TabIndex = 1;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += BtnAgregar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnModificar.Location = new Point(168, 300);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(130, 50);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += BtnModificar_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnEliminar.Location = new Point(322, 300);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(130, 50);
            btnEliminar.TabIndex = 3;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += BtnEliminar_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { JSONToolStrip, deserializarToolStripMenuItem, ordenarToolStripMenuItem, verToolStripMenuItem, calcularToolStripMenuItem, aDOToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(753, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // JSONToolStrip
            // 
            JSONToolStrip.DropDownItems.AddRange(new ToolStripItem[] { JSONToolStripMenuItem, XMLMenuItem });
            JSONToolStrip.Name = "JSONToolStrip";
            JSONToolStrip.Size = new Size(65, 20);
            JSONToolStrip.Text = "Serializar";
            // 
            // JSONToolStripMenuItem
            // 
            JSONToolStripMenuItem.Name = "JSONToolStripMenuItem";
            JSONToolStripMenuItem.Size = new Size(102, 22);
            JSONToolStripMenuItem.Text = "JSON";
            JSONToolStripMenuItem.Click += SerializeJSONMenuItem_Click;
            // 
            // XMLMenuItem
            // 
            XMLMenuItem.Name = "XMLMenuItem";
            XMLMenuItem.Size = new Size(102, 22);
            XMLMenuItem.Text = "XML";
            XMLMenuItem.Click += SerializeXMLMenuItem_Click;
            // 
            // deserializarToolStripMenuItem
            // 
            deserializarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { jSONToolStripMenuItem1, xMLToolStripMenuItem1 });
            deserializarToolStripMenuItem.Name = "deserializarToolStripMenuItem";
            deserializarToolStripMenuItem.Size = new Size(78, 20);
            deserializarToolStripMenuItem.Text = "Deserializar";
            // 
            // jSONToolStripMenuItem1
            // 
            jSONToolStripMenuItem1.Name = "jSONToolStripMenuItem1";
            jSONToolStripMenuItem1.Size = new Size(102, 22);
            jSONToolStripMenuItem1.Text = "JSON";
            jSONToolStripMenuItem1.Click += DeserializeJSONMenuItem_Click;
            // 
            // xMLToolStripMenuItem1
            // 
            xMLToolStripMenuItem1.Name = "xMLToolStripMenuItem1";
            xMLToolStripMenuItem1.Size = new Size(102, 22);
            xMLToolStripMenuItem1.Text = "XML";
            xMLToolStripMenuItem1.Click += DeserializeXMLMenuItem_Click;
            // 
            // ordenarToolStripMenuItem
            // 
            ordenarToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ascendenteToolStripMenuItem, descendenteToolStripMenuItem });
            ordenarToolStripMenuItem.Name = "ordenarToolStripMenuItem";
            ordenarToolStripMenuItem.Size = new Size(62, 20);
            ordenarToolStripMenuItem.Text = "Ordenar";
            // 
            // ascendenteToolStripMenuItem
            // 
            ascendenteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { porNombreToolStripMenuItem, porPesoToolStripMenuItem });
            ascendenteToolStripMenuItem.Name = "ascendenteToolStripMenuItem";
            ascendenteToolStripMenuItem.Size = new Size(142, 22);
            ascendenteToolStripMenuItem.Text = "Ascendente";
            // 
            // porNombreToolStripMenuItem
            // 
            porNombreToolStripMenuItem.Name = "porNombreToolStripMenuItem";
            porNombreToolStripMenuItem.Size = new Size(137, 22);
            porNombreToolStripMenuItem.Text = "Por nombre";
            porNombreToolStripMenuItem.Click += OrdenarAscendentePorNombreToolStripMenuItem_Click;
            // 
            // porPesoToolStripMenuItem
            // 
            porPesoToolStripMenuItem.Name = "porPesoToolStripMenuItem";
            porPesoToolStripMenuItem.Size = new Size(137, 22);
            porPesoToolStripMenuItem.Text = "Por peso";
            porPesoToolStripMenuItem.Click += OrdenarAscendentePorPesoToolStripMenuItem_Click;
            // 
            // descendenteToolStripMenuItem
            // 
            descendenteToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { porNombreToolStripMenuItem1, porPesoToolStripMenuItem1 });
            descendenteToolStripMenuItem.Name = "descendenteToolStripMenuItem";
            descendenteToolStripMenuItem.Size = new Size(142, 22);
            descendenteToolStripMenuItem.Text = "Descendente";
            // 
            // porNombreToolStripMenuItem1
            // 
            porNombreToolStripMenuItem1.Name = "porNombreToolStripMenuItem1";
            porNombreToolStripMenuItem1.Size = new Size(137, 22);
            porNombreToolStripMenuItem1.Text = "Por nombre";
            porNombreToolStripMenuItem1.Click += OrdenarDescendentePorNombreToolStripMenuItem_Click;
            // 
            // porPesoToolStripMenuItem1
            // 
            porPesoToolStripMenuItem1.Name = "porPesoToolStripMenuItem1";
            porPesoToolStripMenuItem1.Size = new Size(137, 22);
            porPesoToolStripMenuItem1.Text = "Por peso";
            porPesoToolStripMenuItem1.Click += OrdenarDescendentePorPesoToolStripMenuItem_Click;
            // 
            // verToolStripMenuItem
            // 
            verToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { registroDeUsuariosToolStripMenuItem });
            verToolStripMenuItem.Name = "verToolStripMenuItem";
            verToolStripMenuItem.Size = new Size(35, 20);
            verToolStripMenuItem.Text = "Ver";
            // 
            // registroDeUsuariosToolStripMenuItem
            // 
            registroDeUsuariosToolStripMenuItem.Name = "registroDeUsuariosToolStripMenuItem";
            registroDeUsuariosToolStripMenuItem.Size = new Size(180, 22);
            registroDeUsuariosToolStripMenuItem.Text = "Registro de usuarios";
            registroDeUsuariosToolStripMenuItem.Click += RegistroDeUsuariosToolStripMenuItem_Click;
            // 
            // calcularToolStripMenuItem
            // 
            calcularToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { pesoPromedioToolStripMenuItem });
            calcularToolStripMenuItem.Name = "calcularToolStripMenuItem";
            calcularToolStripMenuItem.Size = new Size(62, 20);
            calcularToolStripMenuItem.Text = "Calcular";
            // 
            // pesoPromedioToolStripMenuItem
            // 
            pesoPromedioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { hámsterToolStripMenuItem, ratónToolStripMenuItem, topoToolStripMenuItem });
            pesoPromedioToolStripMenuItem.Name = "pesoPromedioToolStripMenuItem";
            pesoPromedioToolStripMenuItem.Size = new Size(154, 22);
            pesoPromedioToolStripMenuItem.Text = "Peso promedio";
            // 
            // hámsterToolStripMenuItem
            // 
            hámsterToolStripMenuItem.Name = "hámsterToolStripMenuItem";
            hámsterToolStripMenuItem.Size = new Size(119, 22);
            hámsterToolStripMenuItem.Text = "Hámster";
            hámsterToolStripMenuItem.Click += HamsterToolStripMenuItem_Click;
            // 
            // ratónToolStripMenuItem
            // 
            ratónToolStripMenuItem.Name = "ratónToolStripMenuItem";
            ratónToolStripMenuItem.Size = new Size(119, 22);
            ratónToolStripMenuItem.Text = "Ratón";
            ratónToolStripMenuItem.Click += RatonToolStripMenuItem_Click;
            // 
            // topoToolStripMenuItem
            // 
            topoToolStripMenuItem.Name = "topoToolStripMenuItem";
            topoToolStripMenuItem.Size = new Size(119, 22);
            topoToolStripMenuItem.Text = "Topo";
            topoToolStripMenuItem.Click += TopoToolStripMenuItem_Click;
            // 
            // aDOToolStripMenuItem
            // 
            aDOToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { serializarEnBaseDeDatosToolStripMenuItem, deserializarEnBaseDeDatosToolStripMenuItem });
            aDOToolStripMenuItem.Name = "aDOToolStripMenuItem";
            aDOToolStripMenuItem.Size = new Size(44, 20);
            aDOToolStripMenuItem.Text = "ADO";
            // 
            // serializarEnBaseDeDatosToolStripMenuItem
            // 
            serializarEnBaseDeDatosToolStripMenuItem.Name = "serializarEnBaseDeDatosToolStripMenuItem";
            serializarEnBaseDeDatosToolStripMenuItem.Size = new Size(224, 22);
            serializarEnBaseDeDatosToolStripMenuItem.Text = "Serializar en base de datos";
            serializarEnBaseDeDatosToolStripMenuItem.Click += SerializarBaseDeDatosToolStripMenuItem_Click;
            // 
            // deserializarEnBaseDeDatosToolStripMenuItem
            // 
            deserializarEnBaseDeDatosToolStripMenuItem.Name = "deserializarEnBaseDeDatosToolStripMenuItem";
            deserializarEnBaseDeDatosToolStripMenuItem.Size = new Size(224, 22);
            deserializarEnBaseDeDatosToolStripMenuItem.Text = "Deserializar en base de datos";
            deserializarEnBaseDeDatosToolStripMenuItem.Click += DeserializarBaseDeDatosToolStripMenuItem_Click;
            // 
            // lblHamster
            // 
            lblHamster.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblHamster.AutoSize = true;
            lblHamster.BackColor = SystemColors.GradientActiveCaption;
            lblHamster.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblHamster.ForeColor = Color.Red;
            lblHamster.Location = new Point(471, 300);
            lblHamster.Name = "lblHamster";
            lblHamster.Size = new Size(79, 19);
            lblHamster.TabIndex = 4;
            lblHamster.Text = "***Hámster";
            // 
            // lblTopo
            // 
            lblTopo.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblTopo.AutoSize = true;
            lblTopo.BackColor = SystemColors.GradientActiveCaption;
            lblTopo.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblTopo.ForeColor = Color.Green;
            lblTopo.Location = new Point(471, 331);
            lblTopo.Name = "lblTopo";
            lblTopo.Size = new Size(77, 19);
            lblTopo.TabIndex = 5;
            lblTopo.Text = "***Topo     ";
            // 
            // lblRaton
            // 
            lblRaton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            lblRaton.AutoSize = true;
            lblRaton.BackColor = SystemColors.GradientActiveCaption;
            lblRaton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            lblRaton.ForeColor = Color.Blue;
            lblRaton.Location = new Point(471, 316);
            lblRaton.Name = "lblRaton";
            lblRaton.Size = new Size(79, 19);
            lblRaton.TabIndex = 6;
            lblRaton.Text = "***Ratón    ";
            // 
            // BtnActualizar
            // 
            BtnActualizar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnActualizar.Location = new Point(660, 300);
            BtnActualizar.Name = "BtnActualizar";
            BtnActualizar.Size = new Size(81, 50);
            BtnActualizar.TabIndex = 7;
            BtnActualizar.Text = "Actualizar";
            BtnActualizar.UseVisualStyleBackColor = true;
            BtnActualizar.Click += BtnActualizar_Click;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel1, toolStripStatusLabel2 });
            statusStrip1.Location = new Point(0, 362);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(753, 24);
            statusStrip1.TabIndex = 8;
            statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new Size(75, 19);
            toolStripStatusLabel1.Text = "Operador: ";
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.RightToLeft = RightToLeft.No;
            toolStripStatusLabel2.Size = new Size(51, 19);
            toolStripStatusLabel2.Text = "Fecha: ";
            // 
            // BtnOpciones
            // 
            BtnOpciones.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnOpciones.Location = new Point(573, 300);
            BtnOpciones.Name = "BtnOpciones";
            BtnOpciones.Size = new Size(81, 50);
            BtnOpciones.TabIndex = 9;
            BtnOpciones.Text = "Opciones";
            BtnOpciones.UseVisualStyleBackColor = true;
            BtnOpciones.Click += BtnOpciones_Click;
            // 
            // BDLabel
            // 
            BDLabel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            BDLabel.AutoSize = true;
            BDLabel.ForeColor = Color.IndianRed;
            BDLabel.Location = new Point(588, 24);
            BDLabel.Name = "BDLabel";
            BDLabel.Size = new Size(153, 15);
            BDLabel.TabIndex = 10;
            BDLabel.Text = "* Está usando base de datos";
            BDLabel.Visible = false;
            // 
            // ConeccionBaseDatosLabel
            // 
            ConeccionBaseDatosLabel.AutoSize = true;
            ConeccionBaseDatosLabel.ForeColor = SystemColors.Highlight;
            ConeccionBaseDatosLabel.Location = new Point(12, 25);
            ConeccionBaseDatosLabel.Name = "ConeccionBaseDatosLabel";
            ConeccionBaseDatosLabel.Size = new Size(169, 15);
            ConeccionBaseDatosLabel.TabIndex = 11;
            ConeccionBaseDatosLabel.Text = "* Conectado a la base de datos";
            ConeccionBaseDatosLabel.Visible = false;
            // 
            // VeterinariaCRUD
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(753, 386);
            Controls.Add(ConeccionBaseDatosLabel);
            Controls.Add(BDLabel);
            Controls.Add(BtnOpciones);
            Controls.Add(statusStrip1);
            Controls.Add(BtnActualizar);
            Controls.Add(lblRaton);
            Controls.Add(lblTopo);
            Controls.Add(lblHamster);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnAgregar);
            Controls.Add(lstRoedores);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(769, 417);
            Name = "VeterinariaCRUD";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Veterinaria Exóticos";
            FormClosing += VeterinariaCRUD_FormClosing;
            Load += VeterinariaCRUD_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox lstRoedores;
        private Button btnAgregar;
        private Button btnModificar;
        private Button btnEliminar;
        private MenuStrip menuStrip1;
        private Label lblHamster;
        private Label lblTopo;
        private Label lblRaton;
        private ToolStripMenuItem JSONToolStrip;
        private ToolStripMenuItem JSONToolStripMenuItem;
        private ToolStripMenuItem XMLMenuItem;
        private ToolStripMenuItem deserializarToolStripMenuItem;
        private ToolStripMenuItem jSONToolStripMenuItem1;
        private ToolStripMenuItem xMLToolStripMenuItem1;
        private ToolStripMenuItem ordenarToolStripMenuItem;
        private ToolStripMenuItem ascendenteToolStripMenuItem;
        private ToolStripMenuItem porNombreToolStripMenuItem;
        private ToolStripMenuItem porPesoToolStripMenuItem;
        private ToolStripMenuItem descendenteToolStripMenuItem;
        private ToolStripMenuItem porNombreToolStripMenuItem1;
        private ToolStripMenuItem porPesoToolStripMenuItem1;
        private Button BtnActualizar;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private Button BtnOpciones;
        private ToolStripMenuItem verToolStripMenuItem;
        private ToolStripMenuItem registroDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem calcularToolStripMenuItem;
        private ToolStripMenuItem pesoPromedioToolStripMenuItem;
        private ToolStripMenuItem hámsterToolStripMenuItem;
        private ToolStripMenuItem ratónToolStripMenuItem;
        private ToolStripMenuItem topoToolStripMenuItem;
        private ToolStripMenuItem aDOToolStripMenuItem;
        private ToolStripMenuItem serializarEnBaseDeDatosToolStripMenuItem;
        private ToolStripMenuItem deserializarEnBaseDeDatosToolStripMenuItem;
        private Label BDLabel;
        private Label ConeccionBaseDatosLabel;
    }
}
