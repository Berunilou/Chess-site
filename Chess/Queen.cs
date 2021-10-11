using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Queen: Figure
    {
        public Queen(char name, Colour colour, Square square) : base(name, colour, square) { }
        public override bool CanFigureMove()
        {
            return true;
        }
    }
}
