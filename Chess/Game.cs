using System;
using System.Collections.Generic;

namespace Chess
{
    public class Game
    {
        string fen;
        public string Fen
        {
            get
            {
                return fen;
            }
            set { }
        }
        public Game()
        {
            Fen = "rnbqknbr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w kqKQ -0 1";
        }
        public Game(string fen)
        {
            Fen = fen;
        }
        public void GenerationNewFen()
        {

        }
        public List<string> GetAllPossibleMovesForMovingFigure(string movingFigure)
        {
            List<string> moves;

            moves = FindAllPossibleMovesForMovingFigure(movingFigure);

            return moves;
        }
        public string GetFigureAt(int x, int y)
        {
            string figure;

            figure = Cell.FigureOnCell(x, y);

            return figure;
        }
        public void MakeMove(string movingFigure, string figureMove)
        {
            foreach(var existMove in AllMovesForMovingFigure(movingFigure))
                if(figureMove == existMove)
                {
                    string startCell = movingFigure.Substring(1);
                    Move.ChangeFigurePosition(startCell, figureMove);
                    return;
                }
        }
        private List<string> FindAllPossibleMovesForMovingFigure(string movingFigure)
        {
            List<string> possibleMoves = new List<string>();

            foreach (string move in AllMovesForMovingFigure(movingFigure))
                if (Move.CanMove(movingFigure, move))
                {
                    possibleMoves.Add(move);
                }

            return possibleMoves;
        }
        private List<string> AllMovesForMovingFigure(string movingFigure)
        {
            List<string> moves;

            return moves;
        }
    }
}
