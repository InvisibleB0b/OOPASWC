using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OOPASWC.Objects;

namespace OOPASWC.Interfaces
{
    public interface IWorldObject
    {
        public Position Pos { get; set; }
        public char Display { get; set; }

    }

}
