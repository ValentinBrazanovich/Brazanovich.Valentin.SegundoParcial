using Opciones;
using Roedores;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinFormR;
using WinFormVisualizador;

namespace VeterinariaExoticos
{
    public partial class VeterinariaCRUD : Form
    {
        private Terrario terrario;
        private string nombreOperador;

        public VeterinariaCRUD(string nombreOperador)
        {
            InitializeComponent();
            terrario = new Terrario();
            this.nombreOperador = nombreOperador;
        }

        /// <summary>
        /// Muestra en el toolStripStatus el nombre del usuario que ha ingresado y la fecha.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VeterinariaCRUD_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Operador: " + nombreOperador;

            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            toolStripStatusLabel2.Text = "Fecha: " + fechaActual;
        }

        /// <summary>
        /// Agrega un nuevo Roedor a la lista si es que no existe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            FrmRoedor frmRoedor = new FrmRoedor();
            DialogResult result = frmRoedor.ShowDialog();

            if (result == DialogResult.OK)
            {
                Roedor nuevoRoedor = frmRoedor.RoedorDelFormulario;
                if (terrario == nuevoRoedor)
                {
                    MensajeError("El roedor ya estaba en la lista.");
                }
                else
                {
                    terrario += nuevoRoedor;
                }

                ActualizarVisor();
            }
        }

        /// <summary>
        /// Modifica el Roedor seleccionado de la lista si no coincide con uno ya existente.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (lstRoedores.SelectedIndex != -1)
            {
                Roedor roedorSeleccionado = (Roedor)lstRoedores.SelectedItem;

                FrmRoedor frmRoedor = new FrmRoedor();
                frmRoedor.CargarDatosRoedor(roedorSeleccionado);

                DialogResult result = frmRoedor.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Roedor roedorMod = frmRoedor.RoedorDelFormulario;

                    if (terrario.Roedores.Contains(roedorMod))
                    {
                        MensajeError("El roedor modificado ya existe en la lista.");
                    }
                    else
                    {
                        terrario.Roedores[lstRoedores.SelectedIndex] = roedorMod;
                        ActualizarVisor();
                    }
                }
            }
            else
            {
                MensajeError("No hay roedor seleccionado para modificar.");
            }
        }

        /// <summary>
        /// Elimina el Roedor seleccionado de la lista
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lstRoedores.SelectedIndex != -1)
            {
                Roedor roedorSeleccionado = (Roedor)lstRoedores.SelectedItem;

                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar al roedor?",
                                                      "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    terrario -= roedorSeleccionado;
                    ActualizarVisor();
                }
            }
            else
            {
                MensajeError("No hay roedor seleccionado para eliminar.");
            }
        }

        /// <summary>
        /// Muestra un mensaje de error personalizado.
        /// </summary>
        /// <param name="mensaje"> El error que se quiere mostrar</param>
        private static void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Actualiza el visor para poder ver sus elementos correctamente.
        /// </summary>
        private void ActualizarVisor()
        {
            lstRoedores.Items.Clear();
            foreach (Roedor roedor in terrario.Roedores)
            {
                lstRoedores.Items.Add(roedor);
            }
        }

        /// <summary>
        /// Abre un Form con el registro de cada ingreso exitoso.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistroDeUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmVisualizador visualizador = new FrmVisualizador();
            visualizador.ShowDialog();
        }


        /// <summary>
        /// Serializa la lista de Roedores en un archivo .JSON ingresando
        /// manualmente la ubicación.
        /// </summary>
        private void SerializarJSON()
        {
            try
            {
                List<Roedor> roedores = new List<Roedor>();
                foreach (object item in lstRoedores.Items)
                {
                    if (item is Roedor roedor)
                    {
                        roedores.Add(roedor);
                    }
                }

                JsonSerializerOptions opciones = new JsonSerializerOptions
                {
                    Converters = { new RoedorConverter() },
                    WriteIndented = true
                };

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Guardar archivo JSON";
                saveFileDialog.Filter = "JSON files (*.json)|*.json";
                saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ruta = saveFileDialog.FileName;
                    string json = JsonSerializer.Serialize(roedores, opciones);
                    File.WriteAllText(ruta, json);
                }
            }
            catch (Exception ex)
            {
                MensajeError($"Error al serializar a JSON: {ex.Message}");
            }
        }

        /// <summary>
        /// Deserializa el archivo JSON indicado manualmente solo si contiene
        /// instancias de Roedor.
        /// </summary>
        private void DeserializarJSON()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Abrir archivo JSON";
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);

                if (string.IsNullOrEmpty(json))
                {
                    MensajeError("El archivo seleccionado está vacío.");
                    return;
                }

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new RoedorConverter() }
                };

                try
                {
                    List<Roedor>? roedoresDeserializados = JsonSerializer.Deserialize<List<Roedor>>(json, options);
                    if (roedoresDeserializados != null)
                    {
                        terrario.Roedores = roedoresDeserializados;
                        ActualizarVisor();
                    }
                }
                catch (JsonException)
                {
                    MensajeError("El archivo seleccionado no tiene el formato adecuado.");
                }
            }
            else
            {
                MensajeError("No se seleccionó ningún archivo.");
            }
        }

        /// <summary>
        /// Serializa la lista de Roedores en un archivo .XML ingresando
        /// manualmente la ubicación.
        /// </summary>
        private void SerializarXML()
        {
            try
            {
                List<Roedor> roedores = new List<Roedor>();
                foreach (object item in lstRoedores.Items)
                {
                    if (item is Roedor roedor)
                    {
                        roedores.Add(roedor);
                    }
                }

                XmlSerializer serializer = new XmlSerializer(typeof(List<Roedor>));

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Title = "Guardar archivo XML";
                saveFileDialog.Filter = "XML files (*.xml)|*.xml";
                saveFileDialog.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string ruta = saveFileDialog.FileName;
                    using (TextWriter writer = new StreamWriter(ruta))
                    {
                        serializer.Serialize(writer, roedores);
                    }
                }
            }
            catch (Exception ex)
            {
                MensajeError($"Error al serializar a XML: {ex.Message}");
            }
        }

        /// <summary>
        /// Deserializa el archivo .XML indicado manualmente solo si contiene
        /// instancias de Roedor.
        /// </summary>
        private void DeserializarXML()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Abrir archivo XML";
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Roedor>));
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open))
                    {
                        if (serializer.Deserialize(fs) is List<Roedor> roedoresDeserializados)
                        {
                            terrario.Roedores = roedoresDeserializados;
                            ActualizarVisor();
                        }
                    }
                }
                catch (InvalidOperationException)
                {
                    MensajeError("El archivo XML no tiene el formato adecuado.");
                }
            }
            else
            {
                MensajeError("No se seleccionó ningún archivo.");
            }
        }

        private void SerializeJSONMenuItem_Click(object sender, EventArgs e)
        {
            SerializarJSON();
        }

        private void DeserializeJSONMenuItem_Click(object sender, EventArgs e)
        {
            DeserializarJSON();
            ActualizarVisor();
        }

        private void SerializeXMLMenuItem_Click(object sender, EventArgs e)
        {
            SerializarXML();
        }

        private void DeserializeXMLMenuItem_Click(object sender, EventArgs e)
        {
            DeserializarXML();
            ActualizarVisor();
        }

        /// <summary>
        /// Cambia el color del item de la lista dependiendo si pertenece a
        /// un Hamster, un Raton o un Topo.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LstRoedores_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                Roedor roedor = (Roedor)lstRoedores.Items[e.Index];

                // Define el color según el tipo de roedor
                Color color = Color.Black;
                if (roedor is Hamster)
                {
                    color = Color.Red;
                }
                else if (roedor is Raton)
                {
                    color = Color.Blue;
                }
                else if (roedor is Topo)
                {
                    color = Color.Green;
                }

                e.Graphics.DrawString(roedor.ToString(), e.Font, new SolidBrush(color), e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void OrdenarAscendentePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorNombre(true);
            ActualizarVisor();
        }

        private void OrdenarDescendentePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorNombre(false);
            ActualizarVisor();
        }

        private void OrdenarAscendentePorPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorPeso(true);
            ActualizarVisor();
        }

        private void OrdenarDescendentePorPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorPeso(false);
            ActualizarVisor();
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarVisor();
        }

        /// <summary>
        /// Al intentar cerrar el Form principal se instancia el Form FrmSalir
        /// preguntando si se desea salir o no.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VeterinariaCRUD_FormClosing(object sender, FormClosingEventArgs e)
        {
            Roedor roedorSeleccionado = (Roedor)lstRoedores.SelectedItem;
            FrmSalir frmSalir = new FrmSalir(roedorSeleccionado);

            DialogResult resultado = frmSalir.ShowDialog();


            if (resultado == DialogResult.Retry)
            {
                SerializarJSON();
                SerializarXML();
            }
            else if (resultado == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// Al apretar el BtnOpciones, se muestra una serie de opciones dependiendo
        /// del item que se haya seleccionado de la lista.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOpciones_Click(object sender, EventArgs e)
        {
            if (lstRoedores.SelectedIndex != -1)
            {
                Roedor roedorSeleccionado = (Roedor)lstRoedores.SelectedItem;
                FrmOpciones opcionesForm = new FrmOpciones(roedorSeleccionado);
                opcionesForm.ShowDialog();
            }
            else
            {
                MensajeError("No hay roedor seleccionado para ver sus opciones.");
            }
        }

        /// <summary>
        /// Se muestra el mensaje de peso promedio
        /// </summary>
        /// <param name="msg"> El mensaje a mostrar </param>
        /// <param name="promedio"> El promedio de peso </param>
        private static void MensajePromedio(string msg, double promedio)
        {
            MessageBox.Show($"{msg}: {promedio}", "Promedio de Peso",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Al hacer click se muestra el peso promedio de hámsters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HamsterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double promedioHamster = Gestion.MostrarPromedioRoedor<Hamster>(terrario);
            MensajePromedio("Promedio de peso de Hámsters", promedioHamster);
        }

        /// <summary>
        /// Al hacer click se muestra el peso promedio de ratones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RatonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double promedioRaton = Gestion.MostrarPromedioRoedor<Raton>(terrario);
            MensajePromedio("Promedio de peso de Ratón", promedioRaton);
        }

        /// <summary>
        /// Al hacer click se muestra el peso promedio de topos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double promedioTopo = Gestion.MostrarPromedioRoedor<Topo>(terrario);
            MensajePromedio("Promedio de peso de Topo", promedioTopo);
        }


    }
}
