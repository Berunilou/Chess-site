using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Board// main class for controling board and figures
    {
        public string fen { get; private set; }
        Figure[,] figures;
        Colour moveColour;
        string moveOnTwoSquares;
        string castling;
        int movenumber;
        int moveWithoutHit;
        public Board(string fen)
        {
            this.fen = fen;
            figures = new Figure[8, 8];
            PositionInitialization(fen);
        }

        private void PositionInitialization(string fen)
        {
            //rnbqknbr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w kqKQ - 0 1
            string[] fenComponents = fen.Split();
            FigureInsall(fenComponents[0]);
            moveColour = fenComponents[1] == "w" ? Colour.white : Colour.black;
            castling=fenComponents[2];
            moveOnTwoSquares = fenComponents[3];
            moveWithoutHit = int.Parse(fenComponents[4]);
            movenumber = int.Parse(fenComponents[5]);
        }

        private void FigureInsall(string figureList)
        {
            for (int i = 8; i >= 2; i--)
                figureList = figureList.Replace(i.ToString(), (i - 1).ToString() + "1");

            string[] rows = figureList.Split('/');

            for (int i = 7; i >= 0; i--)
                for (int j = 0; j < 8; j++)
                {
                    if (rows[i][j] == 'k') figures[7 - i, j] = new King('k', Colour.black, new Square(i, j));
                    if (rows[i][j] == 'K') figures[7 - i, j] = new King('K', Colour.white, new Square(i, j));
                    if (rows[i][j] == 'b') figures[7 - i, j] = new Bishop('b', Colour.black, new Square(i, j));
                    if (rows[i][j] == 'B') figures[7 - i, j] = new Bishop('B', Colour.white, new Square(i, j));
                    if (rows[i][j] == 'r') figures[7 - i, j] = new Rook('r', Colour.black, new Square(i, j));
                    if (rows[i][j] == 'R') figures[7 - i, j] = new Rook('R', Colour.white, new Square(i, j));
                    if (rows[i][j] == 'n') figures[7 - i, j] = new Knight('n', Colour.black, new Square(i, j));
                    if (rows[i][j] == 'N') figures[7 - i, j] = new Knight('N', Colour.white, new Square(i, j));
                    if (rows[i][j] == 'q') figures[7 - i, j] = new Queen('q', Colour.black, new Square(i, j));
                    if (rows[i][j] == 'Q') figures[7 - i, j] = new Queen('Q', Colour.white, new Square(i, j));
                    if (rows[i][j] == 'p') figures[7 - i, j] = new Pawn('p', Colour.black, new Square(i, j));
                    if (rows[i][j] == 'P') figures[7 - i, j] = new Pawn('P', Colour.white, new Square(i, j));
                    if (rows[i][j] == '1') figures[7 - i, j] = new NotFigure('.', Colour.none, new Square(i, j));
                }
        }
        private void SetFigureAt(Figure figure)
        {
            if (figure.square.OnBoard())
                figures[figure.square.x, figure.square.y] = figure;
        }
        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard())
                return figures[square.x, square.y];
            return new NotFigure('.', Colour.none, new Square(square.x, square.y));
        }
    }
}
