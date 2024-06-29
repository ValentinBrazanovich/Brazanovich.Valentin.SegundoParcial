namespace WinFormVisualizador
{
    public partial class FrmVisualizador : Form
    {
        public FrmVisualizador()
        {
            InitializeComponent();
        }

        private void VisualizadorLogUsuarios_Load(object sender, EventArgs e)
        {
            MostrarContenidoLog();
        }

        /// <summary>
        /// Ubica la carpeta Usuarios dentro de mi solución
        /// </summary>
        /// <returns> Retorna el directorio de la carpeta Usuarios </returns>
        /// <exception cref="InvalidOperationException"></exception>
        public static string ObtenerRutaArchivoUsuarios()
        {
            string directorioActual = AppDomain.CurrentDomain.BaseDirectory;
            DirectoryInfo directorioInfo = new DirectoryInfo(directorioActual);

            for (int i = 0; i < 4; i++)
            {
                if (directorioInfo.Parent != null)
                {
                    directorioInfo = directorioInfo.Parent;
                }
                else
                {
                    throw new InvalidOperationException("No se pudo encontrar la carpeta deseada.");
                }
            }

            return Path.Combine(directorioInfo.FullName, "Usuarios");
        }

        /// <summary>
        /// Muestra el contenido de usuarios.log en el richTextBox del Form.
        /// </summary>
        private void MostrarContenidoLog()
        {
            string filePath = ObtenerRutaArchivoUsuarios() + "./usuarios.log";

            try
            {
                if (File.Exists(filePath))
                {
                    string contenido = File.ReadAllText(filePath);
                    richTextBoxLog.Text = contenido;
                }
                else
                {
                    richTextBoxLog.Text = "El archivo de registro de usuarios no existe.";
                }
            }
            catch (Exception ex)
            {
                richTextBoxLog.Text = $"Error al leer el archivo de registro de usuarios: {ex.Message}";
            }
        }

    }
}
