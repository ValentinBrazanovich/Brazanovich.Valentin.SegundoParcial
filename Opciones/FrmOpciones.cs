using Roedores;

namespace Opciones
{
    public partial class FrmOpciones : Form
    {
        private Roedor roedorSeleccionado;


        public FrmOpciones(Roedor roedorSeleccionado)
        {
            InitializeComponent();
            this.roedorSeleccionado = roedorSeleccionado;

            this.MaximizeBox = false;
            if (roedorSeleccionado is Hamster)
            {
                btnMoverCola.Visible = false;
            }
        }


        private void BtnHacerSonido_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.ObtenerSonido(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnCalcularPesoIdeal_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.PesoIdeal(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnMoverCola_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.MoverCola(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
