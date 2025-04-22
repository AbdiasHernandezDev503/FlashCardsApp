using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFlashCard.EL
{
    public class Materia
    {
        public string Nombre { get; set; }
        public List<Tema> Temas { get; set; } = new List<Tema>();
    }
}
