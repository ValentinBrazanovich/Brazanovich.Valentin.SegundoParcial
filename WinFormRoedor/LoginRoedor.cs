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
            string contraseña = txtContraseña.Text;

            bool existe = usuarios.Exists(u => u.Correo == correo && u.Contraseña == contraseña);

            if (existe)
            {
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class Usuario
        {
            public string Correo { get; set; }
            public string Contraseña { get; set; }
        }

    }
}
