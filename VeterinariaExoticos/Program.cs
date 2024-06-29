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

            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                Usuario usuario = (Usuario)loginForm.Tag;

                Application.Run(new VeterinariaCRUD(usuario));
            }
            else
            {
                Application.Exit();
            }
        }
    }
}