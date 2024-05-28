using Opciones;
using Roedores;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Serialization;
using WinFormR;

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

        private void VeterinariaCRUD_Load(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Operador: " + nombreOperador;

            string fechaActual = DateTime.Now.ToString("dd/MM/yyyy");
            toolStripStatusLabel2.Text = "Fecha: " + fechaActual;
        }


        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Se crea la instancia del formulario frmRoedor
            FrmRoedor frmRoedor = new FrmRoedor();
            //Se muestra ese formulario de forma modal
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
                    terrario.Roedores[lstRoedores.SelectedIndex] = frmRoedor.RoedorDelFormulario;

                    ActualizarVisor();
                }
            }
            else
            {
                MensajeError("No hay roedor seleccionado para modificar.");
            }
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            if (lstRoedores.SelectedIndex != -1)
            {
                Roedor roedorSeleccionado = (Roedor)lstRoedores.SelectedItem;

                terrario -= roedorSeleccionado;

                ActualizarVisor();
            }
            else
            {
                MensajeError("No hay roedor seleccionado para eliminar.");
            }
        }

        private static void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ActualizarVisor()
        {
            lstRoedores.Items.Clear();
            foreach (Roedor roedor in terrario.Roedores)
            {
                lstRoedores.Items.Add(roedor);
            }
        }

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
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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

        private void DeserializarJSON()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Abrir archivo JSON";
            openFileDialog.Filter = "JSON files (*.json)|*.json";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);

                // Verificar si el JSON contiene datos de roedores
                if (string.IsNullOrEmpty(json))
                {
                    MensajeError("El archivo seleccionado est� vac�o.");
                    return;
                }

                // Deserializar el JSON solo si contiene datos de roedores
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
                MensajeError("No se seleccion� ning�n archivo.");
            }
        }

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
                saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

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
                MensajeError("No se seleccion� ning�n archivo.");
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

        private void LstRoedores_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            if (e.Index >= 0)
            {
                Roedor roedor = (Roedor)lstRoedores.Items[e.Index];

                // Define el color seg�n el tipo de roedor
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

                // Dibuja el texto del �tem con el color especificado
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

    }
}
