using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public static class FigureFabric
    {
        public static void CreateFigure(Figure figure,char fType)
        {
            switch (fType)
            {
                case 'I':
                    {
                        figure.figureColor = ConsoleColor.DarkCyan;
                        figure.FigureMap = new Block[4, 4] {  { 0, Block.block,  0, 0 },
                                                       { 0, Block.block,  0, 0 },
                                                       { 0, Block.block,  0, 0 },
                                                       { 0, Block.block,  0, 0 } };
                        figure.Size = 4;
                        break;
                    }
                case 'J':
                    {
                        figure.figureColor = ConsoleColor.DarkBlue;
                        figure.FigureMap = new Block[3, 3] {  { Block.block,   0,           0, },
                                                       { Block.block, Block.block, Block.block},
                                                       { 0,             0,           0, }};
                        figure.Size = 3;
                        break;
                    }
                case 'L':
                    {
                        figure.figureColor = ConsoleColor.DarkYellow;
                        figure.FigureMap = new Block[3, 3] {  { 0,             0,         Block.block },
                                                       { Block.block, Block.block, Block.block },
                                                       { 0,             0,           0 }};
                        figure.Size = 3;
                        break;
                    }
                case 'O':
                    {
                        figure.figureColor = ConsoleColor.Yellow;
                        figure.FigureMap = new Block[2, 2]
                        {
                            {Block.block,Block.block },
                            {Block.block,Block.block }
                        };
                        figure.Size = 2;
                        break;
                    }
                case 'S':
                    {
                        figure.figureColor = ConsoleColor.DarkGreen;
                        figure.FigureMap = new Block[3, 3] { { 0,           Block.block, Block.block},
                                                      { Block.block, Block.block, 0},
                                                      { 0,               0,              0 }};
                        figure.Size = 3;
                        break;
                    }
                case 'T':
                    {
                        figure.figureColor = ConsoleColor.DarkMagenta;
                        figure.FigureMap = new Block[3, 3] { { 0,           Block.block,        0 },
                                                      { Block.block, Block.block, Block.block},
                                                      { 0,               0,              0 }};
                        figure.Size = 3;
                        break;
                    }
                case 'Z':
                    {
                        figure.figureColor = ConsoleColor.DarkRed;
                        figure.FigureMap = new Block[3, 3] { { Block.block, Block.block,        0 },
                                                      { 0           , Block.block, Block.block},
                                                      { 0,               0,              0 }};
                        figure.Size = 3;
                        break;
                    }
            }
            figure.Coord = new Point(5, 0);
        }
    }
}
