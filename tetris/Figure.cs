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
        int X, Y;
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
    class Figure
    {
        int size;
        public Block[,] figureMap;
        public Point coord;
        public Rotation rotatPos = Rotation.right;
        public ConsoleColor figureColor;
        public Figure(char fType)
        {
            switch (fType)
            {
                case 'I':
                    {
                        figureColor = ConsoleColor.DarkCyan;
                        figureMap = new Block[4, 4] {  { Block.block, 0, 0, 0 },
                                                       { Block.block, 0, 0, 0 },
                                                       { Block.block, 0, 0, 0 },
                                                       { Block.block, 0, 0, 0 } };
                        size = 4;
                        break;
                    }
                case 'J':
                    {
                        figureColor = ConsoleColor.DarkBlue;
                        figureMap = new Block[3, 3] {  { 0,             0,           0, },
                                                       { Block.block,   0,           0, },
                                                       { Block.block, Block.block, Block.block} };
                        size = 3;
                        break;
                    }
                case 'L':
                    {
                        figureColor = ConsoleColor.DarkYellow;
                        figureMap = new Block[3, 3] {  { 0,             0,           0 },
                                                       { 0,             0,         Block.block },
                                                       { Block.block, Block.block, Block.block } };
                        size = 3;
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
                        size = 2;
                        break;
                    }
                case 'S':
                    {
                        figureColor = ConsoleColor.DarkGreen;
                        figureMap = new Block[3, 3] { { 0,               0,              0 },
                                                      { 0,           Block.block, Block.block},
                                                      { Block.block, Block.block, 0} };
                        size = 3;
                        break;
                    }
                case 'T':
                    {
                        figureColor = ConsoleColor.DarkMagenta;
                        figureMap = new Block[3, 3] { { 0,               0,              0 },
                                                      { 0,           Block.block,        0 },
                                                      { Block.block, Block.block, Block.block} };
                        size = 3;
                        break;
                    }
                case 'Z':
                    {
                        figureColor = ConsoleColor.DarkRed;
                        figureMap = new Block[3, 3] { { 0,               0,              0 },
                                                      { Block.block, Block.block,        0 },
                                                      { 0           , Block.block, Block.block} };
                        size = 3;
                        break;
                    }
            }
            coord = new Point(5, 0);
        }
        public void rotate(Rotation direction)
        {
            switch(direction)
            {
                case Rotation.left:
                    {
                        Block[,] copy = (Block[,])figureMap.Clone();
                        for (int i=0;i<size;i++)
                        {
                            for (int j =0;j<size;j++)
                            {
                                figureMap[i, j] = copy[size-1-j,i];
                            }
                        }
                        break;
                    }
                case Rotation.right:
                    {
                        Block[,] copy = (Block[,])figureMap.Clone();
                        for (int i = size-1; i >=0; i--)
                        {
                            for (int j = size-1; j >=0 ; j--)
                            {
                                figureMap[i, j] = copy[j, size-1-i];
                            }
                        }
                        break;
                    }
            }
        }
        public void Print()
        {
            ConsoleColor prevcolor = Console.BackgroundColor;
            Console.Clear();
            for (int i=0;i<size;i++)
            {
                for (int j=0;j<size; j++)
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
        void Swap(ref Block a,ref Block b)
        {
            Block temp = a;
            a = b;
            b = temp;
        }
    }
}
