using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Square
    {
        public int x { get; private set; }
        public int y { get; private set; }
        public Square(string squareId)
        {
            if (squareId[0] >= 'a' && squareId[0] <= 'h'
                && squareId[1] >= 1 && squareId[1] <= '8')
            {
                x = squareId[0] - 'a';
                y = squareId[1] - '1';
            }
        }
        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;

        }
        public bool OnBoard()
        {
            return x >= 0 &&
                   x < 8 &&
                   y >= 0 &&
                   y < 8;
        }
    }
}
