using System;
using System.Collections.Generic;
using System.Text;
using OOPASWC.Interfaces;
using OOPASWC.Objects;

namespace OOPVisual
{
    public class Worker
    {
        public void Work()
        {
            World w = new World();

            IPlayer p1 = new Player(new Position(5, 5), '1', 10, null, 2, w);

            IPlayer p2 = new Player(new Position(15, 15), '2', 10, null, 2, w);

            w.AddPlayer(p1);
            w.AddPlayer(p2);

            w.Draw();
            w.PlayerTurn = 0;

            Console.WriteLine($" Player: {w.PlayerTurn + 1} X: {w.Players[w.PlayerTurn].Pos.X} Y: {w.Players[w.PlayerTurn].Pos.Y} Hitpoints: {w.Players[w.PlayerTurn].Hitpoints}");


            while (w.AllPlayersAreAlive())
            {
                char typedKey = Console.ReadKey().KeyChar;

                w.Players[w.PlayerTurn].Move(typedKey);

                w.Draw();
                Console.WriteLine($" Player: {w.PlayerTurn + 1} X: {w.Players[w.PlayerTurn].Pos.X} Y: {w.Players[w.PlayerTurn].Pos.Y} Is alive: {w.Players[w.PlayerTurn].Hitpoints}");
            }

        }
    }
}
