using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Game
    {
        public int Id;
        public string Fen;//Forsyth–Edwards Notation
        public string Status;//wait, play, done 
    }
}
