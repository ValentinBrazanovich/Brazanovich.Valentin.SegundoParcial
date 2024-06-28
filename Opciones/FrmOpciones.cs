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
        /// Según el Roedor que se haya seleccionado se muestra
        /// una onomatopeya del sonido del mismo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVerde_Click(object sender, EventArgs e)
        {
            if(roedorSeleccionado is Hamster || roedorSeleccionado is Raton ||
               roedorSeleccionado is Topo)
            {
                MessageBox.Show(roedorSeleccionado.ObtenerSonido(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Según el Roedor que se haya seleccionado se muestra
        /// si el mismo esta en su peso ideal o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void BtnAzul_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.PesoIdeal(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Según el Roedor que se haya seleccionado se muestra
        /// si el mismo mueve la cola (En caso del Hámster esta opción no está disponible).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public virtual void BtnRojo_Click(object sender, EventArgs e)
        {
            MessageBox.Show(roedorSeleccionado.MoverCola(), "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
