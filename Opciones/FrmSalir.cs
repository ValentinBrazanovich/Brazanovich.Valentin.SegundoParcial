using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Roedores;

namespace Opciones
{
    public partial class FrmSalir : FrmOpciones
    {

        public FrmSalir(Roedor roedorseleccionado) : base(roedorseleccionado) 
        {
            InitializeComponent();
            CambiarColorLabel(roedorSeleccionado);

            Config();
        }

        void Config()
        {
            this.Size = new Size(396, 211);

            this.Text = "Advertencia";
            lblInformacion.Text = "¿Está seguro de que desea salir?";
            btnVerde.Text = "Si";
            btnAzul.Text = "Guardar (En JSON y XML) y salir";
            btnRojo.Text = "No";
            btnRojo.Visible = true;
            lblInformacion.Location = new Point(75, 31);
        }

        private void CambiarColorLabel(Roedor roedor)
        {
            if (roedor is Hamster)
                lblInformacion.ForeColor = Color.Red;
            else if (roedor is Raton)
                lblInformacion.ForeColor = Color.Blue;
            else if (roedor is Topo)
                lblInformacion.ForeColor = Color.Green;
        }

        public override void BtnVerde_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        public override void BtnAzul_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Retry;
            this.Close();
        }

        public override void BtnRojo_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

    }
}
