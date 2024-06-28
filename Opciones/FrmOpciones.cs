using Entidades;

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

        /// <summary>
        /// Seg�n el Roedor que se haya seleccionado se muestra
        /// una onomatopeya del sonido del mismo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVerde_Click(object sender, EventArgs e)
        {
            if(roedorSeleccionado is Hamster || roedorSeleccionado is Raton ||
               roedorSeleccionado is Topo)
            {
                MessageBox.Show(roedorSeleccionado.ObtenerSonido(), "Informaci�n",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Seg�n el Roedor que se haya seleccionado se muestra
        /// si el mismo esta en su peso ideal o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void BtnAzul_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.PesoIdeal(), "Informaci�n",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Seg�n el Roedor que se haya seleccionado se muestra
        /// si el mismo mueve la cola (En caso del H�mster esta opci�n no est� disponible).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void BtnRojo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.MoverCola(), "Informaci�n",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
