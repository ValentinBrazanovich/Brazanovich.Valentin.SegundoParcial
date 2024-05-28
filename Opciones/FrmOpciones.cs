using Roedores;

namespace Opciones
{
    public partial class FrmOpciones : Form
    {
        internal Roedor roedorSeleccionado;

        public FrmOpciones(Roedor roedorSeleccionado)
        {
            this.roedorSeleccionado = roedorSeleccionado;
            InitializeComponent();

            this.MaximizeBox = false;
            if (roedorSeleccionado is Hamster)
            {
                btnRojo.Visible = false;
            }
        }


        public virtual void BtnVerde_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.ObtenerSonido(), "Informaci�n",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public virtual void BtnAzul_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.PesoIdeal(), "Informaci�n",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public virtual void BtnRojo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.MoverCola(), "Informaci�n",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
