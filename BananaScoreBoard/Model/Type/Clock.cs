using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace BananaScoreBoard.Model.Type
{
    class Clock
    {

        public int minute = 0, second = 0;
        public Clock(Tuple<int, int> tuple)
        {
            minute = tuple.Item1;
            second = tuple.Item2;
        }

        private Timer timer;

        public delegate void Notifier(int minute, int second);
        Notifier notifier= null;
        public void registerCallback(Notifier notify)
        {
            notifier = notify;
        }

        public bool Start()
        {
            if (0 >= second && second > 60)
                return false;        

            timer = new Timer((Object stateInfo) =>
            {
                int next_minute = minute;
                int next_second = second;
                next_second--;
                if (next_second < 0)
                {
                    next_minute -= 1;
                    if (next_minute < 0)
                    {
                        next_minute = 0;
                        next_second = 0;
                    }
                    else
                    {
                        next_second = 59;
                    }
                }

                
                // Send To UI & Repository
                if (notifier != null)
                    notifier.Invoke(next_minute, next_second);
            }, null, 1000, 1000);
            
            return true;
        }

        public void Pause()
        {
            timer.Dispose();
        }

    }
}
