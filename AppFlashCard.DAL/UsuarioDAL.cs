using AppFlashCard.EL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFlashCard.DAL
{
    public class UsuarioDAL
    {
        private readonly string _connectionString;

        public UsuarioDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<(bool Exito, string Mensaje)> RegistrarUsuarioAsync(Usuario usuario)
        {
            // Hahsear la contraseña del usuario
            string hashClave = BCrypt.Net.BCrypt.HashPassword(usuario.Clave);

            await using (var conexion = new SqlConnection(_connectionString))
            { 
                await using (var cmd = new SqlCommand("SP_RegistrarUsuario", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                    cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                    cmd.Parameters.AddWithValue("@Username", usuario.Username);
                    cmd.Parameters.AddWithValue("@Clave", hashClave);
                    cmd.Parameters.AddWithValue("@Correo", usuario.Correo);
                    cmd.Parameters.AddWithValue("@Telefono", usuario.Telefono);
                    cmd.Parameters.AddWithValue("@CarnetEstudiante", (object?)usuario.CarnetEstudiante ?? DBNull.Value);

                    try
                    {
                        await conexion.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                        return (true, "Usuario insertado correctamente.");
                    }
                    catch (SqlException ex)
                    {
                        return (false, ex.Message);
                    }
                }
            }
        }

        public async Task<Usuario?> LoginUsuarioAsync(string username, string clave)
        {
            await using (var conexion = new SqlConnection(_connectionString))
            {
                await using (var cmd = new SqlCommand("SP_LoginUsuario", conexion))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Username", username);

                    try
                    {
                        await conexion.OpenAsync();
                        var reader = await cmd.ExecuteReaderAsync();
                        if (await reader.ReadAsync())
                        {
                            string hashAlmacenado = reader["Clave"].ToString();

                            if (BCrypt.Net.BCrypt.Verify(clave, hashAlmacenado))
                            {
                                return new Usuario
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    Username = reader["Username"].ToString(),
                                    Nombres = reader["Nombres"].ToString(),
                                    Apellidos = reader["Apellidos"].ToString(),
                                };
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("Error SQL: " + ex.Message);
                    }
                }
            }
            return null;
        }


    }
}
