using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Move
    {
        Board board;
        public Figure figure { get; private set; }
        public Square square { get; private set; }
        public Move(Board board)
        {
            this.board = board;
        }
        internal bool CanMove(string movingFigure, string move)
        {
            figure = board.GetFigureAt(new Square(movingFigure));
            square = new Square(move);
            return CanMoveFrom() &&
                   CanMoveTo() && 
                   CanFigureMove();
        }
        private bool CanMoveFrom()
        {
            return figure.square.OnBoard() &&
                board.moveColour==figure.colour;
        }
        private bool CanMoveTo()
        {
            return square.OnBoard() &&
                (figure.square.x != square.x || figure.square.y != square.y) &&
                board.GetFigureAt(square).colour!=figure.colour;
        }
        private bool CanFigureMove()
        {
            return figure.name switch
            {
                'k' or 'K' => CanKingMove() || CanCastling(),
                'q' or 'Q' => CanQueenMove(),
                'p' or 'P' => CanPawnMove(),
                'r' or 'R' => CanRookMove(),
                'n' or 'N' => CanKnightMove(),
                'b' or 'B' => CanBishopMove(),
                '.' => false,
                _ => false
            };
        }
        private bool CanKingMove()
        {
            return (Math.Abs(figure.square.x-square.x)<=1 && Math.Abs(figure.square.y - square.y) <= 1);
        }
        private bool CanBishopMove()
        {
            return (Math.Abs(figure.square.x - square.x)==Math.Abs(figure.square.y - square.y));
        }
        private bool CanKnightMove()
        {
            return (Math.Abs(figure.square.x - square.x) == 2 && Math.Abs(figure.square.y - square.y) == 1) ||
                (Math.Abs(figure.square.x - square.x) == 1 && Math.Abs(figure.square.y - square.y) == 2);
        }
        private bool CanRookMove()
        {
            return (Math.Abs(figure.square.x - square.x) == 0 || Math.Abs(figure.square.y - square.y) == 0);
        }
        private bool CanPawnMove()
        {
            if(figure.colour == Colour.white && figure.square.y  == 1)
                return (Math.Abs(figure.square.y - square.y) == 1 || Math.Abs(figure.square.y - square.y) == 2);
            if (figure.colour == Colour.black && figure.square.y == 6)
                return (Math.Abs(figure.square.y - square.y) == 1 || Math.Abs(figure.square.y - square.y) == 2);
            return (Math.Abs(figure.square.y - square.y) == 1);
        }
        private bool CanQueenMove()
        {
            return (Math.Abs(figure.square.x - square.x) == Math.Abs(figure.square.y - square.y)) ||
                (Math.Abs(figure.square.x - square.x) == 0 || Math.Abs(figure.square.y - square.y) == 0) ;
        }
        private bool CanCastling()
        {
            if(figure.colour == Colour.white)
            {
                if (board.castling.Contains('K') || board.castling.Contains('Q')) 
                    return Math.Abs(figure.square.x - square.x) == 2;
            }
            if (figure.colour == Colour.black)
            {
                if (board.castling.Contains('k') || board.castling.Contains('q'))
                    return Math.Abs(figure.square.x - square.x) == 2;
            }
            return false;
        }

       
    }
}
