using WinFormRoedor;

namespace VeterinariaExoticos
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            LoginRoedor loginForm = new LoginRoedor();

            // Se muestra el formulario de login
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Si el login es exitoso, se muestra el formulario principal
                Application.Run(new VeterinariaCRUD());
            }
            else
            {
                Application.Exit();
            }
        }
    }
}