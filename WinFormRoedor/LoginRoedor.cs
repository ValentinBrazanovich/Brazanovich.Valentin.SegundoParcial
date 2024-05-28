using System.Text.Json;

namespace WinFormRoedor
{
    public partial class LoginRoedor : Form
    {
        private List<Usuario>? usuarios;
        public string NombreOperadorConectado { get; set; }

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

        private void BtnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string clave = txtClave.Text;

            Usuario? usuarioConectado = usuarios.FirstOrDefault(u => u.correo == correo && u.clave == clave);

            if (usuarioConectado != null)
            {
                DialogResult = DialogResult.OK;
                Tag = usuarioConectado.nombre;
                Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Usuario
        {
            public string apellido { get; set; }
            public string nombre { get; set; }
            public int legajo { get; set; }
            public string correo { get; set; }
            public string clave { get; set; }
            public string perfil { get; set; }
        }

    }
}