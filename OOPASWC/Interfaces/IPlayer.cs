using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Objects;

namespace OOPASWC.Interfaces
{
    //TODO SOL(I)D
    public interface IPlayer : IWorldObject
    {
        public int Hitpoints { get; set; }
        public Weapon Weapon { get; set; }
        public int Dmg { get; set; }
        public IWorld TheWorld { get; set; }
        public IDamageStrategy DmgStrategy { get; set; }

        public bool IsAlive();

        public void Move(char c);

        public bool HandleEnterTile(Field fromField, Field toField);

        public void Hit(IPlayer player);

        public static IPlayer operator +(IPlayer p, Weapon weapon)
        {
            p.Weapon = weapon;
            return p;
        }
    }
}
