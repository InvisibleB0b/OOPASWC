using System;
using System.Collections.Generic;
using System.Text;

namespace OOPASWC.Interfaces
{
    //TODO Strategy design pattern
    public interface IDamageStrategy
    {
        public int AmountOfDmg(IPlayer p);
    }
}
