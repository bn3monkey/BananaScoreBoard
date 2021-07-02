using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace BananaScoreBoard.Model.Type
{
    class Round
    {
        private static string round_path = "Round.txt";
        SemaphoreSlim round_sema;

        public Round()
        {
            round_sema = new SemaphoreSlim(1, 1);
            try
            {
                if (!File.Exists(round_path))
                    File.WriteAllText(round_path, "0");
            }
            catch (Exception e)
            {
                error_msg = "Cannot Create " + round_path;
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

        public async Task<int> getRound()
        {
            int value = 0;
            await round_sema.WaitAsync();
            using (StreamReader reader = File.OpenText(round_path))
            {
                string result = reader.ReadLine();
                try
                {
                    value = Int32.Parse(result);
                }
                catch (Exception e)
                {
                    // Do Nothing
                }
            }
            round_sema.Release();
            return value;
        }
      
        public async Task setRound(int round)
        {
            string value = round.ToString();
            await round_sema.WaitAsync();
            using (StreamWriter writer = File.CreateText(round_path))
            {
                await writer.WriteAsync(value);
            }
            round_sema.Release();
        }
    }
}
