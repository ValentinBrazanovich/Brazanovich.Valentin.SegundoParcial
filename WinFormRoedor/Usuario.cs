using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace WinFormRoedor
{
    internal class Usuario
    {
        public string correo { get; set; }
        public string contraseña { get; set; }


        public static List<Usuario> VerificarUsuarios(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var usuarios = JsonSerializer.Deserialize<List<Usuario>>(json);

                if (usuarios == null)
                {
                    throw new InvalidOperationException("El archivo de usuarios es nulo.");
                }

                return usuarios;
            }
            else
            {
                throw new FileNotFoundException("El archivo de usuarios no existe.");
            }

        }

    }
}
