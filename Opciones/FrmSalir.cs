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

            btnRojo.Visible = true;
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

        /// <summary>
        /// No se hace override porque primero debe hacer el sonido del
        /// ultimo animal si se ha seleccionado) y luego cerrar el programa.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVerde_Click(object sender, EventArgs e)
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
