using Roedores;
using WinFormR;

namespace VeterinariaExoticos
{
    public partial class VeterinariaCRUD : Form
    {
        private Terrario terrario;

        public VeterinariaCRUD()
        {
            InitializeComponent();
            terrario = new Terrario();
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Se crea la instancia del formulario frmRoedor
            FrmRoedor frmRoedor = new FrmRoedor();
            //Se muestra ese formulario de forma modal
            DialogResult result = frmRoedor.ShowDialog();

            if (result == DialogResult.OK)
            {////
                Roedor nuevoRoedor = frmRoedor.RoedorDelFormulario;
                terrario += nuevoRoedor;
                
                ActualizarVisor();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (lstRoedores.SelectedIndex != -1)
            {
                Roedor roedorSeleccionado = (Roedor)lstRoedores.SelectedItem;

                FrmRoedor frmRoedor = new FrmRoedor();
                frmRoedor.CargarDatosRoedor(roedorSeleccionado);

                DialogResult result = frmRoedor.ShowDialog();

                if (result == DialogResult.OK) {
                    terrario.Roedores[lstRoedores.SelectedIndex] = frmRoedor.RoedorDelFormulario;

                    ActualizarVisor();
                }
            }
            else
            {
                MensajeError("No hay roedor seleccionado para modificar.");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstRoedores.SelectedIndex != -1)
            {////
                Roedor roedorSeleccionado = (Roedor)lstRoedores.SelectedItem;

                terrario -= roedorSeleccionado;

                ActualizarVisor();
            }
            else
            {
                MensajeError("No hay roedor seleccionado para eliminar.");
            }
        }

        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ActualizarVisor()
        {
            // Limpiamos el ListBox
            lstRoedores.Items.Clear();
            // Agregamos los roedores al ListBox
            foreach (Roedor roedor in terrario.Roedores)
            {
                lstRoedores.Items.Add(roedor);
            }
        }


    }
}
