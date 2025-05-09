using AppFlashCard.EL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFlashCard.DAL
{
    public class TemaDAL
    {
        private readonly string _connectionString;

        public TemaDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Tema>> ObtenerTemasPorMateriaIdAsync(int materiaId)
        {
            var listaTemas = new List<Tema>();
            await using (var conexion = new SqlConnection(_connectionString))
            {
                await using (var cmd = new SqlCommand("SELECT Id, Nombre FROM Temas WHERE MateriaId = @MateriaId", conexion))
                {
                    cmd.Parameters.AddWithValue("@MateriaId", materiaId);
                    await conexion.OpenAsync();
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            listaTemas.Add(new Tema
                            {
                                Id = reader.GetInt32(0),
                                Nombre = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return listaTemas;
        }
    }
}
