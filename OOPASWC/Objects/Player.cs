using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using OOPASWC.Interfaces;

namespace OOPASWC.Objects
{

    //TODO (S)OLID
    public class Player : IPlayer
    {
        public Position Pos { get; set; }
        public char Display { get; set; }
        public int Hitpoints { get; set; }
        public Weapon Weapon { get; set; }
        public int Dmg { get; set; }
        public IWorld TheWorld { get; set; }
        public IDamageStrategy DmgStrategy { get; set; }

        public Player(Position pos, char display, int hitpoints, Weapon weapon, int dmg, IWorld theWorld)
        {
            Pos = pos;
            Display = display;
            Hitpoints = hitpoints;
            Weapon = weapon;
            Dmg = dmg;
            TheWorld = theWorld;
            DmgStrategy = new DefaultDmgStrategy();

        }

        public bool IsAlive()
        {
            return Hitpoints > 0;
        }

        public void Move(char c)
        {
            switch (c)
            {
                case 'w':
                    if (HandleEnterTile(TheWorld.Size[Pos.Y, Pos.X], TheWorld.Size[Pos.Y - 1, Pos.X]))
                    {
                        Pos.Y -= 1;
                    }
                    break;
                case 's':
                    if (HandleEnterTile(TheWorld.Size[Pos.Y, Pos.X], TheWorld.Size[Pos.Y + 1, Pos.X]))
                    {
                        Pos.Y += 1;
                    }
                    break;
                case 'a':

                    if (HandleEnterTile(TheWorld.Size[Pos.Y, Pos.X], TheWorld.Size[Pos.Y, Pos.X - 1]))
                    {
                        Pos.X -= 1;
                    }
                    break;
                case 'd':
                    if (HandleEnterTile(TheWorld.Size[Pos.Y, Pos.X], TheWorld.Size[Pos.Y, Pos.X + 1]))
                    {
                        Pos.X += 1;
                    }
                    break;
            }

            TheWorld.Singleton.TraceEvent(TheAction.Move, this);
        }

        public bool HandleEnterTile(Field fromField, Field toField)
        {
            bool returType = toField.Passable;

            if (returType)
            {
                if (toField.O is Weapon w)
                {
                    Weapon += w;
                    DmgStrategy = new WeaponDmgStrategy();
                    TheWorld.Singleton.TraceEvent(TheAction.Pickup, w);
                }

                toField.O = this;
                toField.Passable = false;
                fromField.O = null;
                fromField.Passable = true;
            }
            else
            {
                if (toField.O is IPlayer p)
                {
                    Hit(p);
                }

            }

            return returType;
        }

        public void Hit(IPlayer player)
        {
            int damage = DmgStrategy.AmountOfDmg(this);

            player.Hitpoints -= damage;
            TheWorld.Singleton.TraceEvent(TheAction.Attack, this);
        }
    }
}
