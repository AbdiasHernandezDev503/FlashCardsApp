using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFlashCard.EL
{
    public class Flashcard
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int TemaId { get; set; }
        public string Pregunta { get; set; }
        public string Respuesta { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
