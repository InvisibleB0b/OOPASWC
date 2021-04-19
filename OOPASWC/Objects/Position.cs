using System;
using System.Collections.Generic;
using System.Text;

namespace OOPASWC.Objects
{
    public class Position
    {
        //TODO SO(L)ID
        public int X { get; set; }
        public int Y { get; set; }

        public Position(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                throw new ArgumentOutOfRangeException($"x and y must be above 0 X = {x} Y = {y}");
            }
            else
            {
                X = x;
                Y = y;
            }

        }
    }
}
