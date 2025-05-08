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
    public class MateriaDAL
    {
        private readonly string _connectionString;

        public MateriaDAL(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<Materia>> ObtenerMateriasConTemasAsync()
        {
            var listaMaterias = new List<Materia>();
            var dictMaterias = new Dictionary<int, Materia>();  
            await using (var conexion = new SqlConnection(_connectionString))
            {
                await using (var cmd = new SqlCommand("SELECT m.Id, m.Nombre AS Materia, t.Id, t.Nombre AS Tema " +
                                "FROM Materias m LEFT JOIN Temas t ON t.MateriaId = m.Id " +
                                "ORDER BY m.Nombre, t.Nombre", conexion))
                {
                    await conexion.OpenAsync();
                    await using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            int materiaId = reader.GetInt32(0);
                            string materiaNombre = reader.GetString(1);
                            int? temaId = reader.IsDBNull(2) ? null : reader.GetInt32(2);
                            string temaNombre = reader.IsDBNull(3) ? null : reader.GetString(3);

                            if (!dictMaterias.ContainsKey(materiaId))
                            {
                                dictMaterias[materiaId] = new Materia
                                    {
                                    Id = materiaId,
                                    Nombre = materiaNombre,
                                    Temas = new List<Tema>()
                                };
                            }

                            if (temaId.HasValue && temaNombre != null)
                            {
                                dictMaterias[materiaId].Temas!.Add(new Tema
                                {
                                    Id = temaId.Value,
                                    Nombre = temaNombre
                                });
                            }
                        }
                    }
                }
            }
            listaMaterias.AddRange(dictMaterias.Values);
            return listaMaterias;
        }

    }
}
