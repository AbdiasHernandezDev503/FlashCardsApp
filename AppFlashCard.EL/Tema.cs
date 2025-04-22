using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppFlashCard.EL
{
    public class Tema
    {
        public string Nombre { get; set; }  
        public List<Flashcard> Flashcards { get; set; } = new List<Flashcard>();
    }
}
