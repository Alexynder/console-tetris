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

        static int Delay = 500;
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            TetrisGame game = new TetrisGame();
            game.RePrintGame();
            while (true)
            {
                Tick(Delay, game);
            }
        }
        static void Tick(int delay,TetrisGame game)
        {
            game.NextTick();
            Thread.Sleep(delay);
        }
        static void KeyReader()
        {

        }
    }
}
