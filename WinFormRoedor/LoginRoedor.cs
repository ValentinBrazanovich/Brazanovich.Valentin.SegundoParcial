using VeterinariaExoticos;

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
                usuarios = Usuario.VerificarUsuarios("./usuarios.json");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error al leer el archivo de usuarios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            string correo = txtCorreo.Text;
            string contraseña = txtContraseña.Text;

            bool existe = usuarios.Exists(u => u.correo == correo && u.contraseña == contraseña);

            if (existe)
            {
                VeterinariaCRUD veterinaria = new VeterinariaCRUD();
                veterinaria.Show();

                veterinaria.FormClosed += (s, args) => this.Close();
                ////
                this.Hide();
            }
            else
            {
                MessageBox.Show("Correo o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
