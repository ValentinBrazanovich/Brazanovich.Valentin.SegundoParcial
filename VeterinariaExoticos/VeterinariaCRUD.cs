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

        private void btnModificar_Click(object sender, EventArgs e)
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

        private void btnEliminar_Click(object sender, EventArgs e)
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

        private void MensajeError(string mensaje)
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

                string json = JsonSerializer.Serialize(roedores, opciones);
                File.WriteAllText("./roedores.json", json);
            }
            catch (Exception ex)
            {
                MensajeError($"Error al serializar a JSON: {ex.Message}");
            }
        }

        private void DeserializarJSON()
        {
            if (File.Exists("./roedores.json"))
            {
                string json = File.ReadAllText("./roedores.json");
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Converters = { new RoedorConverter() }
                };
                terrario.Roedores = JsonSerializer.Deserialize<List<Roedor>>(json, options);
                ActualizarVisor();
            }
            else
            {
                MensajeError("El archivo 'roedores.json' no existe.");
            }
        }

        private void SerializarXML()
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
            using (TextWriter writer = new StreamWriter("./roedores.xml"))
            {
                serializer.Serialize(writer, roedores);
            }
        }

        private void DeserializarXML()
        {
            if (File.Exists("./roedores.xml"))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Roedor>));
                using (FileStream fs = new FileStream("./roedores.xml", FileMode.Open))
                {
                    terrario.Roedores = (List<Roedor>)serializer.Deserialize(fs);
                    ActualizarVisor();
                }
            }
            else
            {
                MensajeError("El archivo 'roedores.xml' no existe.");
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

        private void lstRoedores_DrawItem(object sender, DrawItemEventArgs e)
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

                // Dibuja el texto del ítem con el color especificado
                e.Graphics.DrawString(roedor.ToString(), e.Font, new SolidBrush(color), e.Bounds);
            }
            e.DrawFocusRectangle();
        }

        private void ordenarAscendentePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorNombre(true);
            ActualizarVisor();
        }

        private void ordenarDescendentePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorNombre(false);
            ActualizarVisor();
        }

        private void ordenarAscendentePorPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorPeso(true);
            ActualizarVisor();
        }

        private void ordenarDescendentePorPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            terrario.OrdenarPorPeso(false);
            ActualizarVisor();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ActualizarVisor();
        }
    }
}
