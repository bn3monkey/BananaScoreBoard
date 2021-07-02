using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace BananaScoreBoard.Model.Type
{
    class TimeView
    {
        public TimeView()
        {
            timer_sema = new SemaphoreSlim(1, 1);
            try
            {
                if (!File.Exists(timer_path))
                    File.WriteAllText(timer_path, "00:00");
            }
            catch (Exception e)
            {
                error_msg = "Cannot Create " + timer_path;
            }

            is_initialized = true;
        }


        private bool is_initialized = false;
        private string error_msg = "";
        bool isInitialized()
        {
            return is_initialized;
        }
        string error()
        {
            return error_msg;
        }



        private static string timer_path = "Timer.txt";
        SemaphoreSlim timer_sema;
        
        private Timer timer;

        public delegate void Notifier(int minute, int second);
        Notifier notifier= null;
        public void registerCallback(Notifier notify)
        {
            notifier = notify;
        }


        public async Task<Tuple<int, int>> getTime()
        {
            int minute = 0;
            int second = 0;

            await timer_sema.WaitAsync();
            using (StreamReader reader = File.OpenText(timer_path))
            {
                string result = reader.ReadLine();
                char[] delimeters = { ':' };
                string[] times = result.Split(delimeters);
                if (times.Length == 2)
                {
                    try
                    {
                        minute = Int32.Parse(times[0]);
                        second = Int32.Parse(times[1]);
                        if (second < 0 && second >= 60)
                            second = 0;
                    }
                    catch (Exception e)
                    {
                        // Do Nothing
                    }

                }
                timer_sema.Release();
            }
            return new Tuple<int,int>(minute, second);
        }

        public async Task setTime(int minute, int second)
        {
            await timer_sema.WaitAsync();
            using (StreamWriter writer = File.CreateText(timer_path))
            {
                String minute_str = minute.ToString("D2");
                String second_str = second.ToString("D2");

                String value = minute_str + ":" + second_str;
                await writer.WriteAsync(value);
            }
            timer_sema.Release();
        }


        public bool Start(int minute, int second)
        {
            if (0 >= second && second > 60)
                return false;        

            timer = new Timer((Object stateInfo) =>
            {
                second--;
                if (second < 0)
                {
                    minute -= 1;
                    if (minute < 0)
                    {
                        minute = 0;
                        second = 0;
                    }
                    else
                    {
                        second = 59;
                    }
                }

                if (notifier != null)
                    notifier.Invoke(minute, second);
            }, null, 1000, 1000);
            
            return true;
        }

        public void Pause()
        {
            timer.Dispose();
        }

    }
}
