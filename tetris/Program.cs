using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tetris
{
    class Program
    {
        public delegate void KeyPressHandler(Rotation dir);
        public static event KeyPressHandler FigurePosKeyPressed;
        public static event KeyPressHandler RotateFigureEvent;
        static int delay = 500;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            TetrisGame game = new TetrisGame();
            game.RePrintGame();
            FigurePosKeyPressed += game.SetNewDirection;
            RotateFigureEvent += game.RotateFigure;
            Thread keyReader = new Thread(new ThreadStart(KeyReader))
            {
                Name = "KeyPressRegister"
            };
            keyReader.Start();
            game.CreateNextFigure();
            while (true)
            {
                Tick(delay, game);
            }
        }
        static void Tick(int delay,TetrisGame game)
        {
            game.NextTick();
            Thread.Sleep(delay);
        }
        static void KeyReader()
        {
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKey k = Console.ReadKey(true).Key;
                    switch (k)
                    {
                        case ConsoleKey.Spacebar:
                            {
                                delay -= 25;
                                if (delay < 25)
                                    delay = 25;
                                break;
                            }
                        case ConsoleKey.Enter:
                            {
                                delay += 25;
                                if (delay > 600)
                                    delay = 600;
                                break;
                            }
                        case ConsoleKey.LeftArrow:
                            {
                                FigurePosKeyPressed?.Invoke(Rotation.left);
                                break;
                            }
                        case ConsoleKey.DownArrow:
                            {
                                FigurePosKeyPressed?.Invoke(Rotation.down);
                                break;
                            }
                        case ConsoleKey.RightArrow:
                            {
                                FigurePosKeyPressed?.Invoke(Rotation.right);
                                break;
                            }
                        case ConsoleKey.A:
                            {
                                RotateFigureEvent?.Invoke(Rotation.left);
                                break;
                            }
                        case ConsoleKey.S:
                            {
                                FigurePosKeyPressed?.Invoke(Rotation.down);
                                break;
                            }
                        case ConsoleKey.D:
                            {
                                RotateFigureEvent?.Invoke(Rotation.right);
                                break;
                            }
                        case ConsoleKey.Escape:
                            {

                                break;
                            }
                    }
                }
            }
        }
    }
}
