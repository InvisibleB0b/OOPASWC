﻿using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Interfaces;

namespace OOPASWC.Objects
{
    class WeaponDmgStrategy : IDamageStrategy

    {
        public int AmountOfDmg(IPlayer p)
        {
            return p.Dmg + p.Weapon.Dmg;
        }
    }
}
