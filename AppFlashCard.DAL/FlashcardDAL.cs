using AppFlashCard.EL;
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
    }
}
