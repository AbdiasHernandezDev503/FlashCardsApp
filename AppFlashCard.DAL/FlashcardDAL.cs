using AppFlashCard.EL;
using AppFlashCard.EL.DTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFlashCard.DAL
{
    public class FlashcardDAL
    {
        private readonly string _connectionString;

        public FlashcardDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<(bool Exito, string Mensaje)> CrearFlashcardAsync(Flashcard flashcard)
        {
            try
            {
                await using (var conexion = new SqlConnection(_connectionString))
                {
                    await using (var cmd = new SqlCommand("SP_InsertarFlashcard", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@UsuarioId", flashcard.UsuarioId);
                        cmd.Parameters.AddWithValue("@TemaId", flashcard.TemaId);
                        cmd.Parameters.AddWithValue("@Pregunta", flashcard.Pregunta);
                        cmd.Parameters.AddWithValue("@Respuesta", flashcard.Respuesta);
                        await conexion.OpenAsync();
                        await cmd.ExecuteNonQueryAsync();
                    }
                }
                return (true, "Se guardó la flashcard con exito");
            }
            catch (SqlException sqlEx)
            {
                return (false, sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (false, "Ocurrió un error inesperado al insertar la flashcard: " + ex.Message);
            }
        }

        public async Task<int> ContarFlashcardAsync(int usuarioId, int temaId)
        {
            int cantidad = 0;
            try
            {
                await using (var conexion = new SqlConnection(_connectionString))
                {
                    await using (var cmd = new SqlCommand("SELECT dbo.FN_ContarFlashcardsPorTemaUsuario(@UsuarioId, @TemaId)", conexion))
                    {
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        cmd.Parameters.AddWithValue("@TemaId", temaId);
                        await conexion.OpenAsync();
                        var result = await cmd.ExecuteScalarAsync();
                        cantidad = Convert.ToInt32(result);
                        return cantidad;
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
                return cantidad;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return cantidad;
            }
        }

        public async Task<List<InfoTemaFlashcard>> ObtenerInfoTemaFlashcardsAsync()
        {
            List<InfoTemaFlashcard> lista = new List<InfoTemaFlashcard>();
            try
            {
                await using (var conexion = new SqlConnection(_connectionString))
                {
                    await using (var cmd = new SqlCommand("SP_ObtenerInfoTemaFlashcards", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        await conexion.OpenAsync();
                        await using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new InfoTemaFlashcard
                                {
                                    Materia = reader["Materia"].ToString(),
                                    Tema = reader["Tema"].ToString(),
                                    Usuario = reader["Usuario"].ToString(),
                                    TemaId = Convert.ToInt32(reader["TemaId"]),
                                    UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lista;
        }

        public async Task<List<Flashcard>> ObtenerFlashcardsPorTemaUsuarioAsync(int temaId, int usuarioId)
        {
            List<Flashcard> lista = new List<Flashcard>();
            try
            {
                await using (var conexion = new SqlConnection(_connectionString))
                {
                    await using (var cmd = new SqlCommand("SP_ObtenerFlashcardsPorTemaYUsuario", conexion))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TemaId", temaId);
                        cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);
                        await conexion.OpenAsync();
                        await using (var reader = await cmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                lista.Add(new Flashcard
                                {
                                    Id = Convert.ToInt32(reader["Id"]),
                                    UsuarioId = Convert.ToInt32(reader["UsuarioId"]),
                                    TemaId = Convert.ToInt32(reader["TemaId"]),
                                    Pregunta = reader["Pregunta"].ToString(),
                                    Respuesta = reader["Respuesta"].ToString(),
                                    FechaCreacion = Convert.ToDateTime(reader["FechaCreacion"])
                                });
                            }
                        }
                    }
                }
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine(sqlEx.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return lista;
        }
    }
}
