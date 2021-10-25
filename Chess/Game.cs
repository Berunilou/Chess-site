using System;
using System.Collections.Generic;

namespace Chess
{
    public class Game//main class that play game
    {
        Board board;
        Move move;
        public string fen { get; private set; }
        public Game()
        {
            this.fen = "rnbqknbr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w kqKQ -0 1";
            board = new Board(fen);
        }
        public Game(string fen)
        {
            this.fen = fen;
            board = new Board(fen);
            move = new Move(board);
        }
        private Game(Board board)
        {
            this.board = board;
            this.fen = board.fen;
            move = new Move(board);
        }
        public List<string> GetAllPossibleMovesForMovingFigure(string movingFigure)
        {
            List<string> moves;

            moves = FindAllPossibleMovesForMovingFigure(movingFigure);

            return moves;
        }
        public Game MakeMove(string movingFigure, string figureMove)
        {
            if (move.CanMove(movingFigure, figureMove))
            {
                board.MakeMove(movingFigure, figureMove);
                return new Game(board);
            }
            return this;
        }
        private List<string> FindAllPossibleMovesForMovingFigure(string movingFigure)
        {
            List<string> possibleMoves = new List<string>();

            foreach (string move in AllMovesForMovingFigure(movingFigure))
            //if (Move.CanMove(movingFigure, move))
            {
                possibleMoves.Add(move);
            }

            return possibleMoves;
        }
        private List<string> AllMovesForMovingFigure(string movingFigure)
        {
            List<string> moves = new List<string>();

            return moves;
        }
        public char GetFigureAt(int x, int y)
        {
            return board.GetFigureAt(new Square(x, y)).name;
        }
    }
}
