using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{    
    public class Figure
    {
        public Figure()
        {
        }
        public Block this[int Yindex, int Xindex]
        {
            get { return FigureMap[Yindex, Xindex]; }
        }
        public int Size { get; set; }
        public Block[,] FigureMap { get; set; }
        public Point Coord { get; set; }
        public ConsoleColor figureColor;
        public readonly char FigureType;

        public Figure(char fType)
        {
            FigureFabric.CreateFigure(this,fType);
            FigureType = fType;
        }
        public Figure(Block[,] map,Point coords,int arrsize)
        {
            FigureMap = map;
            Coord = coords;
            Size = arrsize;
        }  
    }
}
