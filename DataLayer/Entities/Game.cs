using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Fen { get; set; }//Forsyth–Edwards Notation
        public GameStatus Status { get; set; }//wait, play, done 
    }
}
