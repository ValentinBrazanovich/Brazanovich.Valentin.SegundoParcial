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
            string contrase�a = txtContrase�a.Text;

            bool existe = usuarios.Exists(u => u.correo == correo && u.contrase�a == contrase�a);

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
                MessageBox.Show("Correo o contrase�a incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
