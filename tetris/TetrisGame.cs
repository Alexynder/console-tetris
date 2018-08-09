using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    class TetrisGame
    {
        public bool landed = false;
        Block[,] gameField;
        public int score;
        ConsoleColor[,] colorData;
        private readonly char[] blockTypes = { 'I', 'J', 'L', 'O', 'S', 'T', 'Z' };
        public Figure NextFigure;
        public Figure CurrentFigure;
        public bool HasColision(Figure f)
        {
            Block[,] SearchArea = new Block[f.Size, f.Size];
            for (int i=0;i<f.Size;i++)
            {
                for (int j=0;j<f.Size;j++)
                {
                    if (gameField[i + f.Coord.Y, j + f.Coord.X] == Block.block && f[i, j] == Block.block)
                        return true;
                }
            }
            return false;
        }
        public TetrisGame()
        {
            gameField = new Block[21, 10];
            for (int i = 0; i < 10; i++)
                gameField[20, i] = Block.block;
            colorData = new ConsoleColor[21, 10];
            CreateNextFigure();
            CurrentFigure = new Figure(NextFigure.FigureType);
            CreateNextFigure();
        }
        void CreateNextFigure()
        {
            Random rnd = new Random();
            NextFigure = new Figure(blockTypes[rnd.Next(0, blockTypes.Length)]);
        }
        void AddFigureToField()
        {
            for (int i=0;i<CurrentFigure.Size;i++)
            {
                for (int j=0; j<CurrentFigure.Size;j++)
                {
                    gameField[CurrentFigure.Coord.Y + i, CurrentFigure.Coord.X + j] = CurrentFigure[i, j];
                    colorData[CurrentFigure.Coord.Y + i, CurrentFigure.Coord.X + j] = CurrentFigure.figureColor;
                }
            }
            CheckRows();
        }
        void CheckRows()
        {

        }
        public void NextTick()
        {
            CurrentFigure.MoveTo(Rotation.down,this);
            if (landed)
            {
                Random rnd = new Random();
                AddFigureToField();
                landed = false;
                CurrentFigure = new Figure(NextFigure.FigureType);
                NextFigure = new Figure(blockTypes[rnd.Next(0, blockTypes.Length)]);
            }

        }
        public void RePrintGame()
        {
            Console.Clear();
            for (int i=0;i<20;i++)
            {
                Console.WriteLine("                    ||");
            }
            Console.WriteLine    ("====================||");
            Console.SetCursorPosition(0, 0);
            for (int i=0;i<20;i++)
            {
                for (int j=0;j<10;j++)
                {
                    Console.BackgroundColor = colorData[i, j];
                    Console.Write("  ");
                }
                Console.SetCursorPosition(0, i+1);
            }
        }
    }
}
