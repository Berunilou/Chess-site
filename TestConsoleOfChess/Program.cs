using System;
using System.Collections.Generic;

namespace TestConsoleOfChess
{
    class Program
    {
        static void Main(string[] args)
        {
            // Position will be remember in fen notice. At the start it will looks like:
            //rnbqknbr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w kqKQ - 0 1

            //  position of black figures                                                                   rnbqknbr/pppppppp/
            //  position of white figures                                                                   /PPPPPPPP/RNBQKBNR 
            //  empty fields                                                                                /8/8/8/8
            //  whose move                                                                                  w
            //  variant of castling(king/queen side)                                                        kqKQ
            //  is here pawn move on two squares?                                                           -
            //  move quontity without pawn move, or check(50th rule of chess)                               0
            //  move number                                                                                 1

            Chess.Game game = new Chess.Game();  //Chess  will be library of my game

            string figureMove, movingFigure;
            List<string> possibleMovesForFigure;

            while(true)
            {
                Console.WriteLine(game.Fen); // need to check
                Console.WriteLine(Print(game));

                movingFigure = Console.ReadLine();

                possibleMovesForFigure = game.GetAllPossibleMovesForMovingFigure(movingFigure);
                Console.WriteLine(possibleMovesForFigure);

                figureMove = Console.ReadLine();

                if (!MoveExist(figureMove, possibleMovesForFigure)) continue;

                game.MakeMove(movingFigure, figureMove);
            }
        }

        static bool MoveExist(string move, List<string> possibleMovesForFigure)
        {
            foreach (var possibleMove in possibleMovesForFigure)
                if (move == possibleMove) return true;
            return false;
        }

        static string Print(Chess.Game game)
        {
            string text = "  +--------+ \n";
            for (int y = 7; y >= 0; y++)
            {
                text += y + 1;
                text += "|";
                for (int x = 0; x < 8; x++)
                {
                    text += game.GetFigureAt(x, y) + " ";
                }
                text += "|";
            }
            
            text = "  +--------+ \n";
            text += " a b c d e f g h ";
            return text;
        }
    }
}
