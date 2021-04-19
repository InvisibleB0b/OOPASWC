using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Xml;
using OOPASWC.Interfaces;

namespace OOPASWC.Objects
{
    //TODO Template designpattern
    public abstract class AbstractWorld : IWorld
    {
        public Field[,] Size { get; set; }
        public int Rows { get; set; }
        public int Colls { get; set; }
        public List<IPlayer> Players { get; set; }
        public int PlayerTurn { get; set; }
        public TraceingSingleton Singleton { get; set; }

        public bool AllPlayersAreAlive() => (from player in Players where player.IsAlive() == true select player).ToList().Count > 1;


        public AbstractWorld()
        {

            Players = new List<IPlayer>();

            PlayerTurn = 0;

            Singleton = TraceingSingleton.Instance;

            LoadFromXml();

            Size = new Field[Rows, Colls];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Colls; j++)
                {
                    if (i == 0 || i == Rows - 1 || j == 0 || j == Colls - 1)
                    {
                        Size[i, j] = new Field(new Wall(new Position(i, j)), false);
                    }
                    else
                    {
                        Size[i, j] = new Field(null, true);
                    }
                }
            }
        }

        public abstract void Draw();

        private static XmlDocument ConfigDocument()
        {
            XmlDocument configfile = new XmlDocument();

            configfile.Load("Appconfig.xml");

            return configfile;
        }

        private void LoadFromXml()
        {
            XmlNode xNode = ConfigDocument().DocumentElement.SelectSingleNode("x");
            XmlNode yNode = ConfigDocument().DocumentElement.SelectSingleNode("y");

            string xStr = xNode.InnerText.Trim();
            string yStr = yNode.InnerText.Trim();

            int x = Convert.ToInt32(xStr);
            int y = Convert.ToInt32(yStr);

            Rows = y + 2;
            Colls = x + 2;
        }

        public void AddPlayer(IPlayer player)
        {
            Players.Add(player);
            Size[player.Pos.Y, player.Pos.X] = new Field(player, false);
        }
    }
}
