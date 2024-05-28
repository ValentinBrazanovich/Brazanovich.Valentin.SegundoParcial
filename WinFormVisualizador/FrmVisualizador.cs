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

        private void MostrarContenidoLog()
        {
            string filePath = "./usuarios.log";

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
