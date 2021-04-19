using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Objects;

namespace OOPASWC.Interfaces
{
    public interface IWorld
    {
        //TODO SOL(I)D
        public Field[,] Size { get; set; }
        public int Rows { get; set; }
        public int Colls { get; set; }
        public List<IPlayer> Players { get; set; }
        public int PlayerTurn { get; set; }
        public TraceingSingleton Singleton { get; set; }


        public void Draw();
    }
}
