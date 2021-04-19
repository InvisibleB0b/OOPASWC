using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Interfaces;

namespace OOPASWC.Objects
{
    public class DefaultDmgStrategy : IDamageStrategy
    {
        public int AmountOfDmg(IPlayer p)
        {
            return p.Dmg;
        }
    }
}
