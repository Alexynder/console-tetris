using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public static class Printer
    {
        public static void PaintFigureBlack(Figure figure)
        {
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < figure.Size; i++)
            {
                for (int j = 0; j < figure.Size; j++)
                {
                    if (figure[i, j] == Block.block)
                    {
                        Console.SetCursorPosition(figure.Coord.X * 2 + j * 2, figure.Coord.Y + i);
                        Console.Write("  ");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static void PrintFigure(Figure figure)
        {
            Console.BackgroundColor = figure.figureColor;
            for (int i = 0; i < figure.Size; i++)
            {
                for (int j = 0; j < figure.Size; j++)
                {
                    if (figure[i, j] == Block.block)
                    {
                        Console.SetCursorPosition(figure.Coord.X * 2 + j * 2, figure.Coord.Y + i);
                        Console.Write("  ");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
