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
    public class FigureEventArgs : EventArgs
    {

    }
    public class Strucs
    {
    }
}
