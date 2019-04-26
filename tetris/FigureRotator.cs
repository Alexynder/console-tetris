using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public static class FigureRotator
    {
        public static void Rotate(Figure figure, Rotation direction, TetrisGame game)
        {
            Block[,] copy = (Block[,])figure.FigureMap.Clone();
            Block[,] futurePos = (Block[,])figure.FigureMap.Clone();
            switch (direction)
            {
                case Rotation.left:
                    {
                        for (int i = 0; i < figure.Size; i++)
                        {
                            for (int j = 0; j < figure.Size; j++)
                            {
                                futurePos[i, j] = copy[figure.Size - 1 - j, i];
                            }
                        }
                        break;
                    }
                case Rotation.right:
                    {
                        for (int i = figure.Size - 1; i >= 0; i--)
                        {
                            for (int j = figure.Size - 1; j >= 0; j--)
                            {
                                futurePos[i, j] = copy[j, figure.Size - 1 - i];
                            }
                        }
                        break;
                    }
            }
            if (!game.HasColision(new Figure(futurePos, figure.Coord, figure.Size)))
            {
                Printer.PaintFigureBlack(figure);
                figure.FigureMap = (Block[,])futurePos.Clone();
                Printer.PrintFigure(figure);
            }
        }
    }
}
