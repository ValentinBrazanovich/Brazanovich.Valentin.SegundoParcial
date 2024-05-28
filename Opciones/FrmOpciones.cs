using Roedores;

namespace Opciones
{
    public partial class FrmOpciones : Form
    {
        internal Roedor roedorSeleccionado;

        public FrmOpciones(Roedor roedorSeleccionado) : this ()
        {
            this.roedorSeleccionado = roedorSeleccionado;

            this.MaximizeBox = false;
            if (roedorSeleccionado is Hamster)
            {
                btnRojo.Visible = false;
            }
        }

        public FrmOpciones()
        {
            InitializeComponent();
        }

        private void BtnVerde_Click(object sender, EventArgs e)
        {
            if(roedorSeleccionado is Hamster || roedorSeleccionado is Raton ||
               roedorSeleccionado is Topo)
            {
                MessageBox.Show(roedorSeleccionado.ObtenerSonido(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public virtual void BtnAzul_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.PesoIdeal(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public virtual void BtnRojo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.MoverCola(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
