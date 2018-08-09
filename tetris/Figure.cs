using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public enum Rotation
    {
        up, right, down, left
    }
    
    public struct Point
    {
        public int X, Y;
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public enum Block
    {
        empty, block
    }
    public class FigureEventArgs:EventArgs
    {

    }
    class Figure
    {
        public delegate  void FigureMoveEndedEventHandler(object Sender, EventArgs e);
        public event FigureMoveEndedEventHandler FigureEndedMoving;    
        public Figure()
        {

        }
        public Block this[int Yindex, int Xindex]
        {
            get { return figureMap[Yindex, Xindex]; }
        }
        public int Size;
        Block[,] figureMap;
        private Point coord;
        public ConsoleColor figureColor;
        public readonly char FigureType;
        public Point Coord { get => coord; set => coord = value; }

        public Figure(char fType)
        {
            switch (fType)
            {
                case 'I':
                    {
                        figureColor = ConsoleColor.DarkCyan;
                        figureMap = new Block[4, 4] {  { 0, Block.block,  0, 0 },
                                                       { 0, Block.block,  0, 0 },
                                                       { 0, Block.block,  0, 0 },
                                                       { 0, Block.block,  0, 0 } };
                        Size = 4;
                        break;
                    }
                case 'J':
                    {
                        figureColor = ConsoleColor.DarkBlue;
                        figureMap = new Block[3, 3] {  { Block.block,   0,           0, },
                                                       { Block.block, Block.block, Block.block},
                                                       { 0,             0,           0, }};
                        Size = 3;
                        break;
                    }
                case 'L':
                    {
                        figureColor = ConsoleColor.DarkYellow;
                        figureMap = new Block[3, 3] {  { 0,             0,         Block.block },
                                                       { Block.block, Block.block, Block.block },
                                                       { 0,             0,           0 }};
                        Size = 3;
                        break;
                    }
                case 'O':
                    {
                        figureColor = ConsoleColor.Yellow;
                        figureMap = new Block[2, 2]
                        {
                            {Block.block,Block.block },
                            {Block.block,Block.block }
                        };
                        Size = 2;
                        break;
                    }
                case 'S':
                    {
                        figureColor = ConsoleColor.DarkGreen;
                        figureMap = new Block[3, 3] { { 0,           Block.block, Block.block},
                                                      { Block.block, Block.block, 0},
                                                      { 0,               0,              0 }};
                        Size = 3;
                        break;
                    }
                case 'T':
                    {
                        figureColor = ConsoleColor.DarkMagenta;
                        figureMap = new Block[3, 3] { { 0,           Block.block,        0 },
                                                      { Block.block, Block.block, Block.block},
                                                      { 0,               0,              0 }};
                        Size = 3;
                        break;
                    }
                case 'Z':
                    {
                        figureColor = ConsoleColor.DarkRed;
                        figureMap = new Block[3, 3] { { Block.block, Block.block,        0 },
                                                      { 0           , Block.block, Block.block},
                                                      { 0,               0,              0 }};
                        Size = 3;
                        break;
                    }
            }
            FigureType = fType;
            Coord = new Point(5, 0);
        }
        public Figure(Block[,] map,Point coords,int arrsize)
        {
            figureMap = map;
            coord = coords;
            Size = arrsize;
        }
        public void MoveTo(Rotation direction,TetrisGame game)
        {
            Figure futurePos = new Figure();
            switch (direction)
            {
                case Rotation.left:
                    {
                        futurePos = new Figure(figureMap, new Point(coord.X - 1, coord.Y), Size);
                        break;
                    }

                case Rotation.right:
                    {
                        futurePos = new Figure(figureMap, new Point(coord.X + 1, coord.Y), Size);
                        break;
                    }

                case Rotation.down:
                    {
                        futurePos = new Figure(figureMap, new Point(coord.X , coord.Y + 1), Size);
                        break;
                    }
            }
            if (!game.HasColision(futurePos))
            {
                PaintFigureINBlack();
                coord = futurePos.coord;
                PrintFigure();
            }
            else if (direction==Rotation.down&& game.HasColision(futurePos))
            {
                game.landed = true;
            }
        }
        public void rotate(Rotation direction,TetrisGame game)
        {
            Block[,] copy = (Block[,])figureMap.Clone();
            Block[,] futurePos = (Block[,])figureMap.Clone();
            switch (direction)
            {
                case Rotation.left:
                    {
                        for (int i=0;i<Size;i++)
                        {
                            for (int j =0;j<Size;j++)
                            {
                                futurePos[i, j] = copy[Size-1-j,i];
                            }
                        }
                        break;
                    }
                case Rotation.right:
                    {
                        for (int i = Size-1; i >=0; i--)
                        {
                            for (int j = Size-1; j >=0 ; j--)
                            {
                                futurePos[i, j] = copy[j, Size-1-i];
                            }
                        }
                        break;
                    }
            }
            if (!game.HasColision(new Figure(futurePos, coord,Size)))
            {
                figureMap = (Block[,])futurePos.Clone();
            }
        }
        public void Print()
        {
            ConsoleColor prevcolor = Console.BackgroundColor;
            Console.Clear();
            for (int i=0;i<Size;i++)
            {
                for (int j=0;j<Size; j++)
                {
                    switch(figureMap[i,j])
                    {
                        case Block.empty:
                            {
                                Console.Write("  ");
                                break;
                            }
                        case Block.block:
                            {
                                Console.BackgroundColor = figureColor;
                                Console.Write("  ");
                                Console.BackgroundColor = prevcolor;
                                break;
                            }
                    }
                }
                Console.Write("\n");
            }
        }
        void PaintFigureINBlack()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (this[i, j] == Block.block)
                    {
                        Console.SetCursorPosition(coord.X * 2+j*2, coord.Y + i);
                        Console.Write("  ");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        void PrintFigure()
        {
            Console.BackgroundColor = figureColor;
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (this[i, j] == Block.block)
                    {
                        Console.SetCursorPosition(coord.X * 2 + j * 2, coord.Y + i);
                        Console.Write("  ");
                    }
                }
            }
            Console.BackgroundColor = ConsoleColor.Black;
        }
        void Swap(ref Block a,ref Block b)
        {
            Block temp = a;
            a = b;
            b = temp;
        }
    }
}
