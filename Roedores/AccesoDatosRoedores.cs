using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;
using Roedores;


namespace Entidades
{
    internal class AccesoDatosRoedores
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand? comando;
        private SqlDataReader? lector;


        static AccesoDatosRoedores()
        {
            AccesoDatosRoedores.cadena_conexion = Properties.Resources.miConexion;
        }

        public AccesoDatosRoedores()
        {
            // CREO UN OBJETO SQLCONECTION
            this.conexion = new SqlConnection(AccesoDatosRoedores.cadena_conexion);
        }


        public bool ProbarConexion()
        {
            bool rta = true;

            try
            {
                this.conexion.Open();
            }
            catch (Exception e)
            {
                rta = false;

                Console.WriteLine("Error al abrir la conexión: " + e.Message);
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }


        public List<Hamster> ObtenerHamsters()
        {
            List<Hamster> lista = new List<Hamster>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT Nombre, Peso, TipoAlimentacion, Longitud, EsNocturno FROM Hamster";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Hamster hamster = new Hamster();

                    hamster.Nombre = lector.GetString(0);
                    hamster.Peso = lector.GetDouble(1);
                    hamster.TipoAlimentacion = (ETipoAlimentacion)lector.GetInt32(2);
                    hamster.Longitud = lector.GetDouble(3);
                    hamster.EsNocturno = lector.GetBoolean(4);

                    lista.Add(hamster);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        public List<Raton> ObtenerRatones()
        {
            List<Raton> lista = new List<Raton>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT Nombre, Peso, TipoAlimentacion, LargoCola, EsAlbino FROM Raton";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Raton raton = new Raton();

                    raton.Nombre = lector.GetString(0);
                    raton.Peso = lector.GetDouble(1);
                    raton.TipoAlimentacion = (ETipoAlimentacion)lector.GetInt32(2);  // Conversión explícita
                    raton.LargoCola = lector.GetDouble(3);
                    raton.EsAlbino = lector.GetBoolean(4);

                    lista.Add(raton);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }

        public List<Topo> ObtenerTopos()
        {
            List<Topo> lista = new List<Topo>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT Nombre, Peso, TipoAlimentacion, ProfundidadExcavada, GarrasAfiladas FROM Topo";
                this.comando.Connection = this.conexion;

                this.conexion.Open();
                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Topo topo = new Topo();

                    topo.Nombre = lector.GetString(0);
                    topo.Peso = lector.GetDouble(1);
                    topo.TipoAlimentacion = (ETipoAlimentacion)lector.GetInt32(2);  // Conversión explícita
                    topo.ProfundidadExcavada = lector.GetDouble(3);
                    topo.GarrasAfiladas = lector.GetBoolean(4);

                    lista.Add(topo);
                }

                lector.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return lista;
        }


        public bool AgregarHamster(Hamster hamster)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO Hamster (Nombre, Peso, TipoAlimentacion, Longitud, EsNocturno) VALUES (@Nombre, @Peso, @TipoAlimentacion, @Longitud, @EsNocturno)";

                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@Nombre", hamster.Nombre);
                this.comando.Parameters.AddWithValue("@Peso", hamster.Peso);
                this.comando.Parameters.AddWithValue("@TipoAlimentacion", (int)hamster.TipoAlimentacion);
                this.comando.Parameters.AddWithValue("@Longitud", hamster.Longitud);
                this.comando.Parameters.AddWithValue("@EsNocturno", hamster.EsNocturno);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public bool AgregarRaton(Raton raton)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO Raton (Nombre, Peso, TipoAlimentacion, LargoCola, EsAlbino) VALUES (@Nombre, @Peso, @TipoAlimentacion, @LargoCola, @EsAlbino)";

                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@Nombre", raton.Nombre);
                this.comando.Parameters.AddWithValue("@Peso", raton.Peso);
                this.comando.Parameters.AddWithValue("@TipoAlimentacion", (int)raton.TipoAlimentacion);
                this.comando.Parameters.AddWithValue("@LargoCola", raton.LargoCola);
                this.comando.Parameters.AddWithValue("@EsAlbino", raton.EsAlbino);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public bool AgregarTopo(Topo topo)
        {
            bool rta = true;

            try
            {
                string sql = "INSERT INTO Topo (Nombre, Peso, TipoAlimentacion, ProfundidadExcavada, GarrasAfiladas) VALUES (@Nombre, @Peso, @TipoAlimentacion, @ProfundidadExcavada, @GarrasAfiladas)";

                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@Nombre", topo.Nombre);
                this.comando.Parameters.AddWithValue("@Peso", topo.Peso);
                this.comando.Parameters.AddWithValue("@TipoAlimentacion", (int)topo.TipoAlimentacion);
                this.comando.Parameters.AddWithValue("@ProfundidadExcavada", topo.ProfundidadExcavada);
                this.comando.Parameters.AddWithValue("@GarrasAfiladas", topo.GarrasAfiladas);

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }


        public bool ModificarHamster(Hamster hamster, string nombreOriginal)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "UPDATE Hamster SET Nombre = @Nombre, Peso = @Peso, TipoAlimentacion = @TipoAlimentacion, Longitud = @Longitud, EsNocturno = @EsNocturno WHERE Nombre = @NombreOriginal";
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@Nombre", hamster.Nombre);
                this.comando.Parameters.AddWithValue("@Peso", hamster.Peso);
                this.comando.Parameters.AddWithValue("@TipoAlimentacion", (int)hamster.TipoAlimentacion);
                this.comando.Parameters.AddWithValue("@Longitud", hamster.Longitud);
                this.comando.Parameters.AddWithValue("@EsNocturno", hamster.EsNocturno);
                this.comando.Parameters.AddWithValue("@NombreOriginal", nombreOriginal);

                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public bool ModificarRaton(Raton raton, string nombreOriginal)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "UPDATE Raton SET Nombre = @Nombre, Peso = @Peso, TipoAlimentacion = @TipoAlimentacion, LargoCola = @LargoCola, EsAlbino = @EsAlbino WHERE Nombre = @NombreOriginal";
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@Nombre", raton.Nombre);
                this.comando.Parameters.AddWithValue("@Peso", raton.Peso);
                this.comando.Parameters.AddWithValue("@TipoAlimentacion", (int)raton.TipoAlimentacion);
                this.comando.Parameters.AddWithValue("@Longitud", raton.LargoCola);
                this.comando.Parameters.AddWithValue("@EsNocturno", raton.EsAlbino);
                this.comando.Parameters.AddWithValue("@NombreOriginal", nombreOriginal);

                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public bool ModificarTopo(Topo topo, string nombreOriginal)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "UPDATE Topo SET Nombre = @Nombre, Peso = @Peso, TipoAlimentacion = @TipoAlimentacion, ProfundidadExcavada = @ProfundidadExcavada, GarrasAfiladas = @GarrasAfiladas WHERE Nombre = @NombreOriginal";
                this.comando.Connection = this.conexion;

                this.comando.Parameters.AddWithValue("@Nombre", topo.Nombre);
                this.comando.Parameters.AddWithValue("@Peso", topo.Peso);
                this.comando.Parameters.AddWithValue("@TipoAlimentacion", (int)topo.TipoAlimentacion);
                this.comando.Parameters.AddWithValue("@Longitud", topo.ProfundidadExcavada);
                this.comando.Parameters.AddWithValue("@EsNocturno", topo.GarrasAfiladas);
                this.comando.Parameters.AddWithValue("@NombreOriginal", nombreOriginal);

                this.conexion.Open();
                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }


        public bool EliminarHamster(string nombre)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Nombre", nombre);

                string sql = "DELETE FROM Hamster WHERE Nombre = @Nombre";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public bool EliminarRaton(string nombre)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Nombre", nombre);

                string sql = "DELETE FROM Raton WHERE Nombre = @Nombre";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }

        public bool EliminarTopo(string nombre)
        {
            bool rta = true;

            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@Nombre", nombre);

                string sql = "DELETE FROM Topo WHERE Nombre = @Nombre";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception)
            {
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }

            return rta;
        }


    }
}
