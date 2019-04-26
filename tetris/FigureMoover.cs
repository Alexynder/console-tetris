using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public static class FigureMoover
    {
        public static void MoveTo(Figure figure, Rotation direction, TetrisGame game)
        {
            Figure futurePos = new Figure();
            switch (direction)
            {
                case Rotation.left:
                    {
                        futurePos = new Figure(figure.FigureMap, new Point(figure.Coord.X - 1, figure.Coord.Y), figure.Size);
                        break;
                    }

                case Rotation.right:
                    {
                        futurePos = new Figure(figure.FigureMap, new Point(figure.Coord.X + 1, figure.Coord.Y), figure.Size);
                        break;
                    }

                case Rotation.down:
                    {
                        futurePos = new Figure(figure.FigureMap, new Point(figure.Coord.X, figure.Coord.Y + 1), figure.Size);
                        break;
                    }
            }
            if (!game.HasColision(futurePos))
            {
                Printer.PaintFigureBlack(figure);
                figure.Coord = futurePos.Coord;
                Printer.PrintFigure(figure);
            }
            else if (direction == Rotation.down && game.HasColision(futurePos))
            {
                game.landed = true;
            }
        }
    }
}
