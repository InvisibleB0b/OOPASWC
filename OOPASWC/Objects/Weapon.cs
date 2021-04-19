using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Objects;

namespace OOPASWC.Interfaces
{
    public class Weapon : IWorldObject
    {
        public int Dmg { get; set; }
        public Position Pos { get; set; }
        public char Display { get; set; }


        //TODO Operator overload
        public static Weapon operator +(Weapon w, Weapon weapon)
        {
            if (w == null || w.Dmg < weapon.Dmg) return weapon;
            else return w;

        }
    }
}
