using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using OOPASWC.Interfaces;

namespace OOPASWC.Objects
{

    //TODO SingleTon Eventtraceing
    public sealed class TraceingSingleton
    {
        private TraceSource Source { get; set; }
        private int MessageId = 1;
        private static TraceingSingleton _instance;
        private static readonly object Padlock = new object();

        public static TraceingSingleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Padlock)
                    {
                        if (_instance == null)
                        {

                            _instance = new TraceingSingleton();
                        }
                    }
                }



                return _instance;
            }

        }

        private TraceingSingleton()
        {
            Source = new TraceSource("Top source");
            Source.Switch = new SourceSwitch("this is my switch", "All");
            //TraceListener listener = new ConsoleTraceListener(false);

            StreamWriter sw = new StreamWriter("events.txt");
            sw.AutoFlush = true;
            TraceListener listener = new TextWriterTraceListener(sw);

            listener.Filter = new EventTypeFilter(SourceLevels.All);


            Source.Listeners.Add(listener);


        }

        public void TraceEvent(TheAction ac, IWorldObject trigger)
        {

            switch (ac)
            {
                case TheAction.Attack:
                    if (trigger is IPlayer p)
                    {
                        Source.TraceEvent(TraceEventType.Critical, MessageId++, $"Player {p.Display} dealt {p.DmgStrategy.AmountOfDmg(p)} dmg");
                    }
                    break;
                case TheAction.Move:
                    if (trigger is IPlayer p1)
                    {
                        Source.TraceEvent(TraceEventType.Critical, MessageId++, $"Player {p1.Display} Moved to X: {p1.Pos.X}, Y: {p1.Pos.Y}");
                    }
                    break;
                case TheAction.Pickup:
                    if (trigger is Weapon w)
                    {
                        Source.TraceEvent(TraceEventType.Critical, MessageId++, $"Weapon was picked up at X: {w.Pos.X}, Y: {w.Pos.Y}");
                    }
                    break;
            }

        }




    }

    public enum TheAction
    {
        Attack,
        Move,
        Pickup
    }

}
