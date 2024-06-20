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
            this.MaximizeBox = false;
        }

        private void FrmRoedor_Load(object sender, EventArgs e)
        {
            comboAlimentacion.DataSource = Enum.GetNames(typeof(ETipoAlimentacion));
        }

        private static void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public Roedor RoedorDelFormulario
        {
            get { return CrearRoedor(); }
        }

        /// <summary>
        /// Carga los datos del Roedor (según sea el caso)
        /// que posiblemente se vaya a .
        /// </summary>
        /// <param name="roedor"></param>
        public void CargarDatosRoedor(Roedor roedor)
        {
            txtNombre.Text = roedor.Nombre;
            txtPeso.Text = roedor.Peso.ToString();
            comboAlimentacion.SelectedItem = roedor.TipoAlimentacion.ToString();

            if (roedor is Hamster)
            {
                Hamster hamster = (Hamster)roedor;
                rdoHamster.Checked = true;
                txtAtributo.Text = hamster.Longitud.ToString();
                checkAtributo.Checked = hamster.EsNocturno;
            }
            else if (roedor is Raton)
            {
                Raton raton = (Raton)roedor;
                rdoRaton.Checked = true;
                txtAtributo.Text = raton.LargoCola.ToString();
                checkAtributo.Checked = raton.EsAlbino;
            }
            else if (roedor is Topo)
            {
                Topo topo = (Topo)roedor;
                rdoTopo.Checked = true;
                txtAtributo.Text = topo.ProfundidadExcavada.ToString();
                checkAtributo.Checked = topo.GarrasAfiladas;
            }

            ActualizarCampos();
        }


        private void BtnAceptar_Click(object sender, EventArgs e)
        {
            if (CamposValidos())
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MensajeError("Debe completar bien los campos.");
            }

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Actualiza los campos mostrados en el Form según sea
        /// un Hámster, un Ratón o un Topo.
        /// </summary>
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

        /// <summary>
        /// Verifica que los campos Nombre (padre) y el primer atributo (derivada)
        /// no estén vacios y contengan datos válidos.
        /// </summary>
        /// <returns></returns>
        private bool CamposValidos()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) &&
                   !string.IsNullOrEmpty(txtAtributo.Text) &&
                    double.TryParse(txtAtributo.Text, out _);
        }

        /// <summary>
        /// Cada vez que se aprete un RadioButton se cambian los campos según
        /// el roedor que indique el mismo RadioButton.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ActualizarCampos();
        }

        /// <summary>
        /// Crea una instancia de clase derivada de Roedor verificando los atributos que
        /// se le intentan ingresar y, dependiendo del caso, se le asignan ciertos valores por defecto.
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Se crea una instancia de Hamster
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="peso"></param>
        /// <param name="pesoValido"></param>
        /// <param name="tipoAlimentacion"></param>
        /// <param name="atributoDouble"></param>
        /// <param name="atributoValido"></param>
        /// <param name="esNocturno"></param>
        /// <returns> Retorna el Hamster con atributos dependiendo de los atributos validos </returns>
        private Hamster CrearHamster(string nombre, double peso, bool pesoValido, ETipoAlimentacion tipoAlimentacion,
                                        double atributoDouble, bool atributoValido, bool esNocturno)
        {
            if (pesoValido && peso >= 20 && peso <= 180 && atributoValido)
            {
                hamster = new Hamster(nombre, peso, tipoAlimentacion, atributoDouble, esNocturno);
            }
            else if (atributoValido)
            {
                MensajeError("El peso no ha sido ingresado. Se asignó el peso por defecto para un Hámster.");
                hamster = new Hamster(nombre, tipoAlimentacion, atributoDouble, esNocturno);
            }
            else
            {
                MensajeError("El peso y longitud no son válidos. Se asignaron valores por defecto para un Hámster.");
                hamster = new Hamster(nombre, esNocturno);
            }

            return hamster;
        }

        /// <summary>
        /// Se crea una instancia de Raton
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="peso"></param>
        /// <param name="pesoValido"></param>
        /// <param name="tipoAlimentacion"></param>
        /// <param name="atributoDouble"></param>
        /// <param name="atributoValido"></param>
        /// <param name="esAlbino"></param>
        /// <returns> Retorna el Raton con atributos dependiendo de los atributos validos</returns>
        private Raton CrearRaton(string nombre, double peso, bool pesoValido, ETipoAlimentacion tipoAlimentacion,
                                    double atributoDouble, bool atributoValido, bool esAlbino)
        {
            if (pesoValido && peso >= 15 && peso <= 80 && atributoValido)
            {
                raton = new Raton(nombre, peso, tipoAlimentacion, atributoDouble, esAlbino);
            }
            else if (atributoValido)
            {
                MensajeError("El peso no ha sido ingresado. Se asignó el peso por defecto para un Ratón.");
                raton = new Raton(nombre, tipoAlimentacion, atributoDouble, esAlbino);
            }
            else
            {
                MensajeError("El peso y longitud de cola no son válidos. Se asignaron valores por defecto para un Ratón.");
                raton = new Raton(nombre, esAlbino);
            }

            return raton;
        }

        /// <summary>
        /// Se crea una instancia de Topo
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="peso"></param>
        /// <param name="pesoValido"></param>
        /// <param name="tipoAlimentacion"></param>
        /// <param name="atributoDouble"></param>
        /// <param name="atributoValido"></param>
        /// <param name="garrasAfiladas"></param>
        /// <returns> Retorna el Topo con atributos dependiendo de los atributos validos</returns>
        private Topo CrearTopo(string nombre, double peso, bool pesoValido, ETipoAlimentacion tipoAlimentacion,
                                    double atributoDouble, bool atributoValido, bool garrasAfiladas)
        {
            if (pesoValido && peso >= 30 && peso <= 110 && atributoValido)
            {
                topo = new Topo(nombre, peso, tipoAlimentacion, atributoDouble, garrasAfiladas);
            }
            else if (atributoValido)
            {
                MensajeError("El peso no ha sido ingresado. Se asignó el peso por defecto para un Topo.");
                topo = new Topo(nombre, tipoAlimentacion, atributoDouble, garrasAfiladas);
            }
            else
            {
                MensajeError("El peso y profundidad excavado no son válidos. Se asignaron valores por defecto para un Topo.");
                topo = new Topo(nombre, garrasAfiladas);
            }

            return topo;
        }

    }
}
