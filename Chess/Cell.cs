using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Cell
    {
        int x;
        int y;
        int X
        {
            get { return x; }
            set { }
        }
        int Y
        {
            get { return y; }
            set { }
        }
        public static string FigureOnCell(int x, int y)
        {
            foreach (var figure in ListWithAllFigureOnBoardInSomeClassWhichNotCreate.liveFigure)
                if (figure.X == x && figure.Y == y) return figure.name;
            return ".";
        }
    }
}
