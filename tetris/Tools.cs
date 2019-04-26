using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris
{
    public static class Tools
    {
        public static void Swap(ref Block a, ref Block b)
        {
            Block temp = a;
            a = b;
            b = temp;
        }
    }
}
