using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFlashCard.EL
{
    // Esta clase se utiliza para almacenar datos en memoria, es una clase temporal que se entregará como primera fase del proyecto y sera eliminada posteriormente.
    public class DatosEnMemoria
    {
        public static List<Materia> Materias { get; set; } = new List<Materia>
    {
        new Materia
        {
            Nombre = "Matemáticas",
            Temas = new List<Tema>
            {
                new Tema { Nombre = "Sumas" },
                new Tema { Nombre = "Restas" }
            }
        },
        new Materia
        {
            Nombre = "Inglés",
            Temas = new List<Tema>
            {
                new Tema { Nombre = "Verbos" }
            }
        }
    };
    }
}
