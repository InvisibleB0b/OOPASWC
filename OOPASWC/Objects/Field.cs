using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Interfaces;

namespace OOPASWC.Objects
{
    public class Field
    {
        public IWorldObject O { get; set; }
        public bool Passable { get; set; }

        public Field(IWorldObject o, bool passable)
        {
            O = o;
            Passable = passable;
        }

    }
}
