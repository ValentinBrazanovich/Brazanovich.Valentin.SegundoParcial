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

            this.MaximizeBox = false;
        }

        private void CargarUsuarios()
        {
            try
            {
                string json = File.ReadAllText("./MOCK_DATA.json");
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrió un error al leer el archivo de usuarios: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void GuardarLogUsuario(Usuario usuario)
        {
            string filePath = "./usuarios.log";

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

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string clave = txtClave.Text;

            Usuario? usuarioConectado = usuarios.FirstOrDefault(u => u.correo == correo && u.clave == clave);

            if (usuarioConectado != null)
            {
                DialogResult = DialogResult.OK;
                Tag = usuarioConectado.nombre;
                GuardarLogUsuario(usuarioConectado);
                Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRegistro_Click(object sender, EventArgs e)
        {
            FrmVisualizador visualizador = new FrmVisualizador();
            visualizador.ShowDialog();
        }

    }
}