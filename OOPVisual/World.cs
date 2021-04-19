using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using OOPASWC.Interfaces;
using OOPASWC.Objects;

namespace OOPVisual
{
    public class World : AbstractWorld
    {



        public override void Draw()
        {
            Console.Clear();

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colls; j++)
                {
                    if (Size[i, j].O != null)
                    {
                        Console.Write(Size[i, j].O.Display);
                    }
                    else
                    {
                        Console.Write(" ");
                    }


                }
                Console.Write("\n");
            }

            PlayerTurn = (PlayerTurn + 1) % Players.Count;

        }


    }
}
