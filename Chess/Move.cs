using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Move
    {
        internal static bool CanMove(string movingFigure, string move)
        {
            return CanMoveFrom()&&CanMoveTo(movingFigure) &&CanFigureMove(movingFigure);
        }
        static bool CanMoveFrom()
        {
            return true;
        }
        static bool CanMoveTo(string movingFigure)
        {
            return true;
        }
        static bool CanFigureMove(string movingFigure)
        {
            return true;
        }
    }
}
