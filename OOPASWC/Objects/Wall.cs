using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Interfaces;

namespace OOPASWC.Objects
{
    public class Wall : IWorldObject
    {
        public Position Pos { get; set; }
        public char Display { get; set; }

        public Wall(Position pos, char display = 'W')
        {
            Pos = pos;
            Display = display;
        }

    }
}
