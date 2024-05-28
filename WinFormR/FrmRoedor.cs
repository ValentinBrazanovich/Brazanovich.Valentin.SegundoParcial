using Roedores;

namespace WinFormR
{
    public partial class FrmRoedor : Form
    {
        private Hamster hamster;
        private Raton raton;
        private Topo topo;

        public FrmRoedor()
        {
            InitializeComponent();
        }

        private void FrmRoedor_Load(object sender, EventArgs e)
        {
            // Llenar el ComboBox con los nombres de los valores del enumerado
            comboAlimentacion.DataSource = Enum.GetNames(typeof(ETipoAlimentacion));
        }


        public Roedor RoedorDelFormulario { 
            get { return CrearRoedor(); }
        }

        public void CargarDatosRoedor(Roedor roedor)
        {
            txtNombre.Text = roedor.nombre;
            txtPeso.Text = roedor.peso.ToString();
            comboAlimentacion.SelectedItem = roedor.tipoAlimentacion.ToString();

            if (roedor is Hamster)
            {
                Hamster hamster = (Hamster)roedor;
                rdoHamster.Checked = true;
                txtAtributo.Text = hamster.longitud.ToString();
                checkAtributo.Checked = hamster.esNocturno;
            }
            else if (roedor is Raton)
            {
                Raton raton = (Raton)roedor;
                rdoRaton.Checked = true;
                txtAtributo.Text = raton.largoCola.ToString();
                checkAtributo.Checked = raton.esAlbino;
            }
            else if (roedor is Topo)
            {
                Topo topo = (Topo)roedor;
                rdoTopo.Checked = true;
                txtAtributo.Text = topo.profundidadExcavada.ToString();
                checkAtributo.Checked = topo.garrasAfiladas;
            }

            ActualizarCampos();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (CamposValidos())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Debe completar bien los campos.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ActualizarCampos()
        {
            if (rdoHamster.Checked)
            {
                labelAtributo.Text = "Longitud:";
                checkAtributo.Text = "Es nocturno";
            }
            else if (rdoRaton.Checked)
            {
                labelAtributo.Text = "Largo de cola:";
                checkAtributo.Text = "Es albino";
            }
            else if (rdoTopo.Checked)
            {
                labelAtributo.Text = "Profundidad excavada:";
                checkAtributo.Text = "Garras afiladas";
            }
        }

        private bool CamposValidos()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) &&
                   !string.IsNullOrEmpty(txtAtributo.Text);
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarCampos();
        }

        private Roedor CrearRoedor()
        {
            string nombre = txtNombre.Text;
            double peso;
            double atributoDouble;
            bool pesoValido = double.TryParse(txtPeso.Text, out peso);
            bool atributoValido = ((double.TryParse(txtAtributo.Text, out atributoDouble)) && (atributoDouble >= 4.0 && atributoDouble <= 18.0));

            if (CamposValidos())
            {
                ETipoAlimentacion tipoAlimentacion = (ETipoAlimentacion)Enum.Parse(typeof(ETipoAlimentacion),
                                                        comboAlimentacion.SelectedItem.ToString());
                bool atributoBooleano = checkAtributo.Checked;

                if (rdoHamster.Checked)
                {
                    return CrearHamster(nombre, peso, pesoValido, tipoAlimentacion,
                                    atributoDouble, atributoValido, atributoBooleano);
                }
                else if (rdoRaton.Checked)
                {
                    return CrearRaton(nombre, peso, pesoValido, tipoAlimentacion,
                                  atributoDouble, atributoValido, atributoBooleano);
                }
                else if (rdoTopo.Checked)
                {
                    return CrearTopo(nombre, peso, pesoValido, tipoAlimentacion, 
                                 atributoDouble, atributoValido, atributoBooleano);
                }
            }

            return hamster;
        }

        private Hamster CrearHamster(string nombre, double peso, bool pesoValido, ETipoAlimentacion tipoAlimentacion,
                                        double atributoDouble, bool atributoValido, bool esNocturno)
        {
            if (pesoValido && peso >= 20 && peso <= 180 && atributoValido)
            {
                hamster = new Hamster(nombre, peso, tipoAlimentacion, atributoDouble, esNocturno);
            }
            else if (atributoValido)
            {
                hamster = new Hamster(nombre, tipoAlimentacion, atributoDouble, esNocturno);
            }
            else
            {
                hamster = new Hamster(nombre, esNocturno);
            }

            return hamster;
        }

        private Raton CrearRaton(string nombre, double peso, bool pesoValido, ETipoAlimentacion tipoAlimentacion,
                                    double atributoDouble, bool atributoValido, bool esAlbino)
        {
            if (pesoValido && peso >= 15 && peso <= 80 && atributoValido)
            {
                raton = new Raton(nombre, peso, tipoAlimentacion, atributoDouble, esAlbino);
            }
            else if (atributoValido)
            {
                raton = new Raton(nombre, tipoAlimentacion, atributoDouble, esAlbino);
            }
            else
            {
                raton = new Raton(nombre, esAlbino);
            }

            return raton;
        }

        private Topo CrearTopo(string nombre, double peso, bool pesoValido, ETipoAlimentacion tipoAlimentacion,
                                    double atributoDouble, bool atributoValido, bool garrasAfiladas)
        {
            if (pesoValido && peso >= 30 && peso <= 110 && atributoValido)
            {
                topo = new Topo(nombre, peso, tipoAlimentacion, atributoDouble, garrasAfiladas);
            }
            else if (atributoValido)
            {
                topo = new Topo(nombre, tipoAlimentacion, atributoDouble, garrasAfiladas);
            }
            else
            {
                topo = new Topo(nombre, garrasAfiladas);
            }

            return topo;
        }

        
    }
}
