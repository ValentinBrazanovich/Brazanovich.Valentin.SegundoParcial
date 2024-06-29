using System.Text.Json;
using WinFormVisualizador;

namespace WinFormRoedor
{
    public partial class LoginRoedor : Form
    {
        private List<Usuario>? usuarios;

        public LoginRoedor()
        {
            InitializeComponent();
            CargarUsuarios();

            txtCorreo.KeyPress += Txt_KeyPress;
            txtClave.KeyPress += Txt_KeyPress;

            this.MaximizeBox = false;
        }

        /// <summary>
        /// Carga los usuarios de MOCK_DATA.json en una lista de usuarios.
        /// </summary>
        private void CargarUsuarios()
        {
            try
            {
                string rutaArchivo = FrmVisualizador.ObtenerRutaArchivoUsuarios();

                // Leer el archivo JSON desde la ruta obtenida
                string json = File.ReadAllText(rutaArchivo + "./MOCK_DATA.json");
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al leer el archivo de usuarios: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Guarda en usuarios.log los datos del usuario que ingresó.
        /// </summary>
        /// <param name="usuario">El usuario que ingresó</param>
        private static void GuardarLogUsuario(Usuario usuario)
        {
            string filePath = FrmVisualizador.ObtenerRutaArchivoUsuarios() + "./usuarios.log";

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    string fecha = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    string datos = $"{fecha}: Apellido: {usuario.apellido}, Usuario: {usuario.nombre}," +
                                   $" Legajo: {usuario.legajo}, Correo: {usuario.correo}," +
                                   $" Clave: {usuario.clave}, Perfil: {usuario.perfil}";
                    writer.WriteLine(datos);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al guardar el log de usuario: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Al hacer click en el btnIngresar, se busca el primer objeto en la lista que contenga
        /// el correo y la clave ingresada en txtCorreo y txtClave. Luego guarda los datos del usuario ingresado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string clave = txtClave.Text;

            Usuario? usuarioConectado = usuarios.FirstOrDefault(u => u.correo == correo && u.clave == clave);

            if (usuarioConectado != null)
            {
                DialogResult = DialogResult.OK;
                Tag = usuarioConectado;
                GuardarLogUsuario(usuarioConectado);
                Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Maneja el evento KeyPress para los TextBox de correo y clave.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Txt_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                BtnIngresar_Click(sender, e);
            }
        }

    }
}