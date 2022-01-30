using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Log
{
    class Log
    {
        const int capacity = 8196;
        static string[] log_stack = new string[capacity];
        
        private static int head = 0;
        private static int tail = -1;
        private static int count = 0;

        private static void Store(string log)
        {
            tail = (tail + 1) % capacity;
            log_stack[tail] = log;
             if (count == capacity)
                head = (head + 1) % capacity;
            if (count < capacity)
                count = (count + 1);

        }

        private static string GetTimeDate()
        {
            string DateTime = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return DateTime;
        }

        public static void V(string verbose)
        {
            string log = String.Format("{0}[Verbose] : {1}\n", GetTimeDate(), verbose);
            Store(log);
            Debug.WriteLine(log);
        }
        public static void E(string error)
        {
            string log = String.Format("{0}[Error  ] : {1}\n", GetTimeDate(), error);
            Store(log);
            Debug.WriteLine(log);
        }

        public static bool ExportLog(string filename)
        {
            if (tail == -1)
            {
                return false;
            }

            try
            {
                using (StreamWriter writer = File.CreateText(filename))
                {
                    int index = head-1;
                    do
                    {
                        index = (index + 1) % capacity;
                        writer.WriteLine(log_stack[index]);
                    }
                    while (index != tail);
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
