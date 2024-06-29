using Opciones;
using Entidades;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Windows.Forms;
using System.Xml.Serialization;
using WinFormR;
using WinFormVisualizador;
using Microsoft.Data.SqlClient;
using System.Data;
using WinFormRoedor;

namespace VeterinariaExoticos
{
    public partial class VeterinariaCRUD : Form
    {
        private Terrario terrario;
        private string nombreOperador;
        private bool esBaseDeDatos = false;

        public VeterinariaCRUD(Usuario usuario)
        {
            InitializeComponent();
            terrario = new Terrario();
            this.nombreOperador = usuario.nombre;
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
                    MensajeError("Ya existe un roedor con ese nombre.");
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
                        MensajeError("El nombre del roedor modificado ya está en la lista.");
                    }
                    else
                    {
                        terrario.Roedores[lstRoedores.SelectedIndex] = roedorMod;
                        ActualizarVisor();

                        if (esBaseDeDatos)
                        {
                            ModificarBaseDeDatos(roedorMod, roedorSeleccionado);
                        }
                    }
                }
            }
            else
            {
                MensajeError("No hay roedor seleccionado para modificar.");
            }
        }

        /// <summary>
        /// Modifica el roedor en la base de datos
        /// </summary>
        /// <param name="roedorMod"> El roedor modificado </param>
        /// <param name="roedorSeleccionado"> El roedor original que se modificará </param>
        private static void ModificarBaseDeDatos(Roedor roedorMod, Roedor roedorSeleccionado)
        {
            AccesoDatosRoedores ado = new AccesoDatosRoedores();
            bool resultado = false;

            if (roedorMod is Hamster hamsterMod)
            {
                resultado = ado.ModificarHamster(hamsterMod, roedorSeleccionado.Nombre);
            }
            else if (roedorMod is Raton ratonMod)
            {
                resultado = ado.ModificarRaton(ratonMod, roedorSeleccionado.Nombre);
            }
            else if (roedorMod is Topo topoMod)
            {
                resultado = ado.ModificarTopo(topoMod, roedorSeleccionado.Nombre);
            }

            if (!resultado)
            {
                MensajeError($"Error al modificar {roedorMod.Nombre} en la base de datos.");
            }
        }

        /// <summary>
        /// Elimina el roedor en la base de datos
        /// </summary>
        /// <param name="roedorSeleccionado"> El roedor que se eliminará </param>
        private static void EliminarRoedorEnBaseDeDatos(Roedor roedorSeleccionado)
        {
            AccesoDatosRoedores ado = new AccesoDatosRoedores();
            bool resultado = false;

            if (roedorSeleccionado is Hamster)
            {
                resultado = ado.EliminarHamster(roedorSeleccionado.Nombre);
            }
            else if (roedorSeleccionado is Raton)
            {
                resultado = ado.EliminarRaton(roedorSeleccionado.Nombre);
            }
            else if (roedorSeleccionado is Topo)
            {
                resultado = ado.EliminarTopo(roedorSeleccionado.Nombre);
            }

            if (!resultado)
            {
                MensajeError($"Error al eliminar '{roedorSeleccionado.Nombre}' de la base de datos.");
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

                DialogResult result = MessageBox.Show("¿Está seguro de que desea eliminar al roedor?\nSi está usando" +
                                                      " base de datos, el roedor se eliminará de la misma.",
                                                      "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    terrario -= roedorSeleccionado;
                    ActualizarVisor();

                    if (esBaseDeDatos)
                    {
                        EliminarRoedorEnBaseDeDatos(roedorSeleccionado);
                    }
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

            if (esBaseDeDatos)
            {
                BDLabel.Visible = true;
            }
            else
            {
                BDLabel.Visible = false;
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
        /// Calcula el directorio en donde está ubicado el proyecto
        /// VeterinariaExoticos
        /// </summary>
        /// <returns> Retorna el directorio </returns>
        private static string ObtenerDirectorioInicial()
        {
            try
            {
                //Obtener el directorio actual
                string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
                //Obtener el directorio tres niveles por encima
                DirectoryInfo directorioInfo = new DirectoryInfo(directorioActual);
                for (int i = 0; i < 3; i++)
                {
                    if (directorioInfo.Parent != null)
                    {
                        directorioInfo = directorioInfo.Parent;
                    }
                }

                if (directorioInfo.Exists)
                {
                    return directorioInfo.FullName;
                }
            }
            catch (Exception ex)
            {
                MensajeError($"Error al obtener el directorio inicial: {ex.Message}");
            }

            //Directorio de respaldo (escritorio) si ocurre algún error o el directorio no existe
            return Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                saveFileDialog.InitialDirectory = ObtenerDirectorioInicial();

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
            openFileDialog.InitialDirectory = ObtenerDirectorioInicial();

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

                        esBaseDeDatos = false;
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
                saveFileDialog.InitialDirectory = ObtenerDirectorioInicial();

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
            openFileDialog.InitialDirectory = ObtenerDirectorioInicial();

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

                            esBaseDeDatos = false;
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

        /// <summary>
        /// Ordena los elementos de la lista
        /// </summary>
        /// <param name="tipo"> El campo en el que se basará el ordenamiento (Nombre o peso) </param>
        /// <param name="ascendente"> Si se ordenará de forma ascendente o descendente </param>
        private void OrdenarPor(int tipo, bool ascendente)
        {
            try
            {
                if (terrario.Roedores.Count == 0)
                {
                    throw new ListaRoedoresVaciaException();
                }
                if (tipo == 1)
                { 
                    terrario.OrdenarPorNombre(ascendente);
                }
                else if (tipo == 2)
                {
                    terrario.OrdenarPorPeso(ascendente);
                }
                ActualizarVisor();
            }
            catch (ListaRoedoresVaciaException ex)
            {
                MensajeError(ex.Message);
            }
        }

        private void OrdenarAscendentePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenarPor(1, true);
        }

        private void OrdenarDescendentePorNombreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenarPor(1, false);
        }

        private void OrdenarAscendentePorPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenarPor(2, true);
        }

        private void OrdenarDescendentePorPesoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OrdenarPor(2, true);
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

        /// <summary>
        /// Muestra el contenido de las tablas de la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeserializarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AccesoDatosRoedores ado = new AccesoDatosRoedores();
                if (ado.VerificarConexion())
                {
                    ConeccionBaseDatosLabel.Visible = true;

                    List<Hamster> listaHamster = ado.ObtenerHamsters();
                    List<Raton> listaRatones = ado.ObtenerRatones();
                    List<Topo> listaTopos = ado.ObtenerTopos();

                    if (listaHamster.Count == 0 && listaRatones.Count == 0 && listaTopos.Count == 0)
                    {
                        throw new ListaRoedoresVaciaException();
                    }

                    terrario.Roedores.Clear();

                    terrario.Roedores.AddRange(listaHamster);
                    terrario.Roedores.AddRange(listaRatones);
                    terrario.Roedores.AddRange(listaTopos);

                    esBaseDeDatos = true;
                    ActualizarVisor();
                }
                else
                {
                    ConeccionBaseDatosLabel.Visible = false;
                    MensajeError("Primero debe establecer conección con la base de datos");
                }
            
            }
            catch(ListaRoedoresVaciaException ex)
            {
                MensajeError(ex.Message);
            }
            catch(InvalidOperationException ex)
            {
                MensajeError("Error al deserializar la base de datos\n" + ex.Message);
            }
            catch(Exception ex)
            {
                MensajeError("Ocurrió un error: " + ex.Message);
            }
        }

        /// <summary>
        /// Guarda los elementos en lista en la base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SerializarBaseDeDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                AccesoDatosRoedores ado = new AccesoDatosRoedores();
                if (ado.VerificarConexion())
                {
                    ConeccionBaseDatosLabel.Visible = true;

                    if (!ado.LimpiarBaseDeDatos())
                    {
                        MensajeError("Error al limpiar la base de datos.");
                        return;
                    }

                    foreach (Roedor roedor in terrario.Roedores)
                    {
                        bool resultado;

                        if (roedor is Hamster hamster)
                        {
                            resultado = ado.AgregarHamster(hamster);
                        }
                        else if (roedor is Raton raton)
                        {
                            resultado = ado.AgregarRaton(raton);
                        }
                        else if (roedor is Topo topo)
                        {
                            resultado = ado.AgregarTopo(topo);
                        }
                        else
                        {
                            resultado = false;
                        }

                        if (!resultado)
                        {
                            ConeccionBaseDatosLabel.Visible = false;
                            MensajeError($"Error al sincronizar {roedor.Nombre} con la base de datos.");
                        }
                    }

                    MessageBox.Show("Sincronización completada.", "Base de datos",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MensajeError("Primero debe establecer conección con la base de datos");
                }
            }
            catch (InvalidOperationException ex)
            {
                MensajeError(ex.Message);
            }
            catch (Exception ex)
            {
                MensajeError("Ocurrió un error: " + ex.Message);
            }
        }


    }
}
