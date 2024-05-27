using System.Text.Json;

namespace WinFormRoedor
{
    public partial class LoginRoedor : Form
    {
        private List<Usuario> usuarios;

        public LoginRoedor()
        {
            InitializeComponent();
            CargarUsuarios();
        }


        private void CargarUsuarios()
        {
            try
            {
                string json = File.ReadAllText("./usuarios.json");
                usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al leer el archivo de usuarios: {ex.Message}",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contrase�a = txtContrase�a.Text;

            bool existe = usuarios.Exists(u => u.Correo == correo && u.Contrase�a == contrase�a);

            if (existe)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Correo o contrase�a incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Usuario
        {
            public string Correo { get; set; }
            public string Contrase�a { get; set; }
        }

    }
}
