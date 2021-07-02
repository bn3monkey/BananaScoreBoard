using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;


namespace BananaScoreBoard
{
    class Player
    {
        private string name_path;
        private string score_path;
        private string note1_path;
        private string note2_path;

        SemaphoreSlim name_sema;
        SemaphoreSlim score_sema;
        SemaphoreSlim note1_sema;
        SemaphoreSlim note2_sema;

        public Player(string side)
        {
            name_sema = new SemaphoreSlim(1, 1);
            score_sema = new SemaphoreSlim(1, 1);
            note1_sema = new SemaphoreSlim(1, 1);
            note2_sema = new SemaphoreSlim(1, 1);

            name_path = side + "_name.txt";
            score_path = side + "_score.txt";
            note1_path = side + "_note1.txt";
            note2_path = side + "_note2.txt";

            try
            {
                if (!File.Exists(name_path))
                    File.WriteAllText(name_path, side);
            }
            catch (Exception e)
            {
                error_msg = "Cannot Create " + name_path;
            }

            try
            {
                if (!File.Exists(score_path))
                    File.WriteAllText(score_path, "0");
            }
            catch (Exception e)
            {
                error_msg = "Cannot Create " + score_path;
            }

            try
            {
                if (!File.Exists(note1_path))
                    File.WriteAllText(note1_path, "Sans");
            }
            catch (Exception e)
            {
                error_msg = "Cannot Create " + note1_path;
            }

            try
            {
                if (!File.Exists(note2_path))
                    File.WriteAllText(note2_path, "Papyrus");
            }
            catch (Exception e)
            {
                error_msg = "Cannot Create " + note2_path;
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

        public static async Task swap(Player a, Player b)
        {
            await a.name_sema.WaitAsync();
            await b.name_sema.WaitAsync();
            await a.score_sema.WaitAsync();
            await b.score_sema.WaitAsync();

            if (File.Exists(a.name_path) && File.Exists(a.score_path) && File.Exists(b.name_path) && File.Exists(b.score_path))
            {
                File.Move(a.name_path, "temp");
                File.Move(b.name_path, a.name_path);
                File.Move("temp", b.name_path);

                File.Move(a.score_path, "temp");
                File.Move(b.score_path, a.score_path);
                File.Move("temp", b.score_path);
            }

            a.name_sema.Release();
            b.name_sema.Release();
            a.score_sema.Release();
            b.score_sema.Release();
        }

        public async Task<string> getName()
        {
            string result = "";
            await name_sema.WaitAsync();           
            using (StreamReader reader = File.OpenText(name_path))
            {
                result = reader.ReadLine();
            }
            name_sema.Release();
            return result;
        }

        public async Task<int> getScore()
        {
            int value = 0;
            await score_sema.WaitAsync();
            using (StreamReader reader = File.OpenText(name_path))
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
            score_sema.Release();
            return value;
        }

        public async Task<string> getNote1()
        {
            string result = "";
            await note1_sema.WaitAsync();
            using (StreamReader reader = File.OpenText(note1_path))
            {
                result = reader.ReadLine();
            }
            note1_sema.Release();
            return result;
        }

        public async Task<string> getNote2()
        {
            string result = "";
            await note2_sema.WaitAsync();
            using (StreamReader reader = File.OpenText(note2_path))
            {
                result = reader.ReadLine();
            }
            note2_sema.Release();
            return result;
        }


        public async Task setName(string name)
        {
            await name_sema.WaitAsync();
            using (StreamWriter writer = File.CreateText(name_path))
            {
                await writer.WriteAsync(name);
            }
            name_sema.Release();
        }



        public async Task setScore(int score)
        {
            string value = score.ToString();
            await score_sema.WaitAsync();
            using (StreamWriter writer = File.CreateText(score_path))
            {
                await writer.WriteAsync(value);
            }
            score_sema.Release();
        }


        public async Task setNote1(string score)
        {
            await note1_sema.WaitAsync();
            using (StreamWriter writer = File.CreateText(note1_path))
            {
                await writer.WriteAsync(score);
            }
            note1_sema.Release();
        }



        public async Task setNote2(string score)
        {
            await note2_sema.WaitAsync();
            using (StreamWriter writer = File.CreateText(note2_path))
            {
                await writer.WriteAsync(score);
            }
            note2_sema.Release();
        }
    }
}
