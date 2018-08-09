using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    class Program
    {
        int Delay = 500;
        static void Main(string[] args)
        {
            Figure f = new Figure('T');
            while(true)
            {
                f.Print();
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            f.rotate(Rotation.left);
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            f.rotate(Rotation.right);
                            break;
                        }

                    case ConsoleKey.I:                        
                        {
                            f = new Figure('I');
                            break;
                        }
                    case ConsoleKey.J:
                        {
                            f = new Figure('J');
                            break;
                        }
                    case ConsoleKey.L:
                        {
                            f = new Figure('L');
                            break;
                        }
                    case ConsoleKey.O:
                        {
                            f = new Figure('O');
                            break;
                        }
                    case ConsoleKey.S:
                        {
                            f = new Figure('S');
                            break;
                        }
                    case ConsoleKey.T:
                        {
                            f = new Figure('T');
                            break;
                        }
                    case ConsoleKey.Z:
                        {
                            f = new Figure('Z');
                            break;
                        }
                }
            }
        }
        static void Tick(int delay)
        {

        }
        static void KeyReader()
        {

        }
    }
}
