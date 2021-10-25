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
        private Figure NotFigure = new NotFigure('.', Colour.none, new Square(-1, -1));
        private Figure[,] figures;
        internal Colour moveColour;
        private string moveOnTwoSquares;
        internal string castling;
        private int movenumber;
        private int moveWithoutHit;
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
            moveColour = (fenComponents[1] == "w") ? Colour.white : Colour.black;
            castling = fenComponents[2];
            moveOnTwoSquares = fenComponents[3];
            moveWithoutHit = int.Parse(fenComponents[4]);
            movenumber = int.Parse(fenComponents[5]);
        }
        private void FigureInsall(string figureList)
        {
            for (int i = 8; i >= 2; i--)
                figureList = figureList.Replace(i.ToString(), (i - 1).ToString() + "1");

            string[] rows = figureList.Split('/');

            for (int x = 0; x < 8; x++)
                for (int y = 0; y < 8; y++)
                {
                    if (rows[y][x] == 'k') figures[x, 7 - y] = new King('k', Colour.black, new Square(x, 7 - y));
                    if (rows[y][x] == 'K') figures[x, 7 - y] = new King('K', Colour.white, new Square(x, 7 - y));
                    if (rows[y][x] == 'b') figures[x, 7 - y] = new Bishop('b', Colour.black, new Square(x, 7 - y));
                    if (rows[y][x] == 'B') figures[x, 7 - y] = new Bishop('B', Colour.white, new Square(x, 7 - y));
                    if (rows[y][x] == 'r') figures[x, 7 - y] = new Rook('r', Colour.black, new Square(x, 7 - y));
                    if (rows[y][x] == 'R') figures[x, 7 - y] = new Rook('R', Colour.white, new Square(x, 7 - y));
                    if (rows[y][x] == 'n') figures[x, 7 - y] = new Knight('n', Colour.black, new Square(x, 7 - y));
                    if (rows[y][x] == 'N') figures[x, 7 - y] = new Knight('N', Colour.white, new Square(x, 7 - y));
                    if (rows[y][x] == 'q') figures[x, 7 - y] = new Queen('q', Colour.black, new Square(x, 7 - y));
                    if (rows[y][x] == 'Q') figures[x, 7 - y] = new Queen('Q', Colour.white, new Square(x, 7 - y));
                    if (rows[y][x] == 'p') figures[x, 7 - y] = new Pawn('p', Colour.black, new Square(x, 7 - y));
                    if (rows[y][x] == 'P') figures[x, 7 - y] = new Pawn('P', Colour.white, new Square(x, 7 - y));
                    if (rows[y][x] == '1') figures[x, 7 - y] = new NotFigure('.', Colour.none, new Square(x, 7 - y));
                }
        }
        public void MakeMove(string figureId, string move)
        {
            ChangeFigurePosition(GetFigureAt(new Square(figureId)), new Square(move));
            if (moveColour == Colour.black) movenumber++;
            moveColour = (moveColour == Colour.white) ? Colour.black : Colour.white;
            fen = GenerateNewFen();
        }

        private string GenerateNewFen()
        {
            return GetFiguresFen() + " " +
                (moveColour == Colour.white ? "w" : "b") + " " +
                castling + " " +
                moveOnTwoSquares + " " +
                moveWithoutHit + " " +
                movenumber;
        }

        private string GetFiguresFen()
        {
            string figuresFen = "";
            for (int y = 7; y >= 0; y--)
            {
                for (int x = 0; x < 8; x++)
                {
                    if (figures[x, y].name != '.')
                        figuresFen += figures[x, y].name.ToString();
                    else
                        figuresFen += "1";
                }
                figuresFen += "/";
            }

            string freeSquares = "11111111";

            for (int i = 8; i >= 2; i--)
                figuresFen = figuresFen.Replace(freeSquares.Substring(0, i), i.ToString());

            return figuresFen;
        }

        private void/***/ ChangeFigurePosition(Figure figure, Square square)
        {
            if (square.OnBoard() &&
                figure.square.OnBoard() &&
                figure.colour == moveColour)
            {
                Figure tempFigure = GetFigureAt(square);
                figures[square.x, square.y] = figure;
                figures[figure.square.x, figure.square.y] = tempFigure;
                int tempY, tempX;
                tempX = figure.square.x;
                tempY = figure.square.y;
                figure.square.x = square.x;
                figure.square.y = square.y;
                square.x = tempX;
                square.y = tempY;
            }
        }
        public Figure GetFigureAt(Square square)
        {
            if (square.OnBoard())
                return figures[square.x, square.y];
            return NotFigure;
        }
    }
}
