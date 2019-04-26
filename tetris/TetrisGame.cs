using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public class TetrisGame
    {
        Random rnd = new Random();
        public bool cantMove = false;
        public int deltaX = 5;
        public bool landed = false;
        public Block[,] gameField;
        public int score;
        public int scoreDelta = 100;
        public ConsoleColor[,] colorData;
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
                    if (gameField[i + f.Coord.Y, j + f.Coord.X+deltaX+1] == Block.block && f[i, j] == Block.block)
                        return true;
                }
            }
            return false;
        }
        public TetrisGame()
        {            
            gameField = new Block[30, 20];
            for (int i = 0; i < 20; i++)
                gameField[20, i] = Block.block;
            for (int i = 0; i < 22; i++)
            {
                gameField[i, deltaX] = Block.block;
                gameField[i, 11+deltaX] = Block.block;
            }
            colorData = new ConsoleColor[30, 20];
            CreateNextFigure();
            CurrentFigure = new Figure(NextFigure.FigureType);
            CreateNextFigure();
        }
        void CreateNextFigure()
        {
            NextFigure = new Figure(blockTypes[rnd.Next(0, blockTypes.Length)]);
        }
        void AddFigureToField()
        {
            for (int i=0;i<CurrentFigure.Size;i++)
            {
                for (int j=0; j<CurrentFigure.Size;j++)
                {
                    if (CurrentFigure[i, j] == Block.block)
                    {
                        gameField[CurrentFigure.Coord.Y + i, CurrentFigure.Coord.X + j + deltaX+1] = CurrentFigure[i, j];
                        colorData[CurrentFigure.Coord.Y + i, CurrentFigure.Coord.X + j + deltaX+1] = CurrentFigure.figureColor;
                    }
                }
            }
            RowHandler.CheckRows(this);
        }
        public void NextTick()
        {
            cantMove = true;
            FigureMoover.MoveTo(CurrentFigure, Rotation.down, this);
            if (landed)
            {
                AddFigureToField();
                landed = false;
                CurrentFigure = new Figure(NextFigure.FigureType);
                if (NextFigure != null)
                    Printer.PaintFigureBlack(NextFigure);
                NextFigure = new Figure(blockTypes[rnd.Next(0, blockTypes.Length)]);
                NextFigure.Coord = new Point(12, 3);
                Printer.PrintFigure(NextFigure);
            }
            cantMove = false;
        }
        public void SetNewDirection(Rotation dir)
        {
            if (!cantMove)
                FigureMoover.MoveTo(CurrentFigure, dir, this);                
        }
        public void RotateFigure(Rotation rot)
        {
            if (!cantMove)
                FigureRotator.Rotate(CurrentFigure, rot, this);
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
                for (int j=deltaX+1;j<10+deltaX+1;j++)
                {
                    Console.BackgroundColor = colorData[i, j];
                    Console.Write("  ");
                }
                Console.SetCursorPosition(0, i+1);
            }
            Printer.PrintFigure(NextFigure);
            Console.SetCursorPosition(25, 1);
            Console.Write("Next");
            Console.SetCursorPosition(25, 10);
            Console.Write("Score:");
            Console.SetCursorPosition(25, 11);
            Console.Write(score);
        }
    }
}
