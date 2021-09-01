using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
   public class Plateau
    {
        public Plateau(int X, int Y)
        {
            XCordinate = X;
            YCordinate = Y;
        }

        public int XCordinate { get; set; }
        public int YCordinate { get; set; }
    }
}
