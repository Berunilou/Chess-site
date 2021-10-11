using System;
using System.Collections.Generic;

namespace Chess
{
    public class Game//main class that play game
    {
        Board board;
        public string fen{ get; private set; }
        public Game()
        {
            this.fen = "rnbqknbr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w kqKQ -0 1";
            board = new Board(fen);
        }
        public Game(string fen)
        {
            this.fen = fen;
            board = new Board(fen);
        }
        public List<string> GetAllPossibleMovesForMovingFigure(string movingFigure)
        {
            List<string> moves;

            moves = FindAllPossibleMovesForMovingFigure(movingFigure);

            return moves;
        }
        public void MakeMove(string movingFigure, string figureMove)
        {
            foreach(var existMove in AllMovesForMovingFigure(movingFigure))
                if(figureMove == existMove)
                {
                    string startCell = movingFigure.Substring(1);
                    //ChangeFigurePosition(startCell, figureMove);
                    return;
                }
        }
        private List<string> AllMovesForMovingFigure(string movingFigure)
        {
            List<string> moves = new List<string>();

            return moves;
        }

        public char GetFigureAt(int x, int y)
        {
            return board.GetFigureAt(new Square(x,y)).name;
        }
    }
}
