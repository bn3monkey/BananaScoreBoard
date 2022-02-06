using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace BananaScoreBoard.Model
{
    class Record
    {
        public enum Name
        {
            Name1P = 0,
            Name2P = 1,
            Score1P = 2,
            Score2P = 3,
            Label = 4,
            MISC1 = 5,
            MISC2= 6,
            MISC3 = 7,
            MISC4 = 8,
            Timer = 9,
        }

        public static string GetTournamentWinnerFileName(bool isWinnerMatch, int round, int match_num)
        {
            string ret = isWinnerMatch ? "W" : "L";
            ret += round.ToString();
            ret += "_";
            ret += match_num.ToString();
            ret += "_";
            ret += "Winner.txt";
            return ret;
        }
        public static string GetTournamentFileName(bool isWinnerMatch, int round, int match_num, int player_num)
        {
            string ret = isWinnerMatch ? "W" : "L";
            ret += round.ToString();
            ret += "_";
            ret += match_num.ToString();
            ret += "_";
            ret += "P";
            ret += player_num.ToString();
            ret += ".txt";
            return ret;
        }


        public void loadPath()
        {
            if (File.Exists(path_file_path))
            {
                using (StreamReader reader = File.OpenText(path_file_path))
                {
                    folder_path = reader.ReadLine();
                }
            }
            else
            {
                folder_path = Directory.GetCurrentDirectory();
                savePath();
            }

        }
        public void savePath()
        {
            using (StreamWriter writer = File.CreateText(path_file_path))
            {
                writer.WriteLine(folder_path);
            }
        }

        public void InitializePath()
        {

            if (!Exists(Name.Name1P))
                WriteString(Name.Name1P, "");

            if (!Exists(Name.Name2P))
                WriteString(Name.Name2P, "");

            if (!Exists(Name.Score1P))
                WriteInt(Name.Score1P, 0);

            if (!Exists(Name.Score2P))
                WriteInt(Name.Score2P, 0);

            if (!Exists(Name.Label))
                WriteString(Name.Label, "");

            if (!Exists(Name.MISC1))
                WriteString(Name.MISC1, "");
            if (!Exists(Name.MISC2))
                WriteString(Name.MISC2, "");
            if (!Exists(Name.MISC3))
                WriteString(Name.MISC3, "");
            if (!Exists(Name.MISC4))
                WriteString(Name.MISC4, "");

            if (!Exists(Name.Timer))
                writeClock(0, 0);

            for (int round = 1; round <= 3; round++)
            {
                int max_match = 4 / (int)Math.Pow(2, round-1);
                for (int match_num = 1; match_num <= max_match; match_num++)
                    for (int player_num = 1; player_num <= 2; player_num++)
                    {
                        string filename = GetTournamentFileName(true, round, match_num, player_num);
                        if (!Exists(filename))
                            WriteString(filename, "");
                    }

            }
            for (int player_num = 1; player_num <= 2; player_num++)
            {
                string filename = GetTournamentFileName(true, 4, 1, player_num);
                if (!Exists(filename))
                    WriteString(filename, "");
            }

            for (int round = 1; round <= 3; round++)
            {
                int max_match = 2 - (round - 1 / 2);
                for (int match_num = 1; match_num <= max_match; match_num++)
                    for (int player_num = 1; player_num <= 2; player_num++)
                    {
                        string filename = GetTournamentFileName(true, round, match_num, player_num);
                        if (!Exists(filename))
                            WriteString(filename, "");
                    }
            }
            
        }
        public string FindPath()
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                return fbd.SelectedPath;
            }
            else
                return "";
        }

        public bool Exists(Name name)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += name_path[name];
            return File.Exists(full_path);
        }

        public bool Exists(string filename)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += filename;
            return File.Exists(full_path);
        }

        public string ReadString(Name name)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += name_path[name];

            SemaphoreSlim local_name_lock = name_lock[name];
            local_name_lock.Wait();

            string ret = "";
            try
            {
                using (StreamReader reader = File.OpenText(full_path))
                {
                    ret = reader.ReadLine();
                }
            }
            catch(Exception e)
            {
                // Do Nothing
            }

            local_name_lock.Release();
            return ret;
        }

        public string ReadString(string filename)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += filename;

            string ret = "";
            try
            {
                using (StreamReader reader = File.OpenText(full_path))
                {
                    ret = reader.ReadLine();
                }
            }
            catch (Exception e)
            {
                // Do Nothing
            }
            return ret;
        }

        public string ReadText(string filename)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += filename;

            string ret = "";
            try
            {
                using (StreamReader reader = File.OpenText(full_path))
                {
                    ret = reader.ReadToEnd();
                }
            }
            catch(Exception e)
            {
                // Do Nothing
            }
            return ret;
        }

        public void WriteString(Name name, string value)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += name_path[name];

            SemaphoreSlim local_name_lock = name_lock[name];
            local_name_lock.Wait();

            try
            { 
                using (StreamWriter writer = File.CreateText(full_path))
                {
                    writer.WriteLine(value);
                }
            }
            catch (Exception e)
            {
                // Do Nothing
            }

            local_name_lock.Release();
        }

        public void WriteString(string filename, string value)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += filename;

            try
            {
                using (StreamWriter writer = File.CreateText(full_path))
                {
                    writer.WriteLine(value);
                }
            }
            catch(Exception e)
            {
                // Do Nothing
            }
}

        public int ReadInt(string filename)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += filename;

            int ret = 0;
            try
            {
                using (StreamReader reader = File.OpenText(full_path))
                {
                    string result = reader.ReadLine();
                    try
                    {
                        ret = Int32.Parse(result);
                    }
                    catch
                    {
                    }
                }
            }
            catch(Exception e)
            {
                // Do Nothing
            }
            return ret;
        }

        

        public int ReadInt(Name name)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += name_path[name];
            
            SemaphoreSlim local_name_lock = name_lock[name];
            local_name_lock.Wait();

            int ret = 0;
            try
            { 
                using (StreamReader reader = File.OpenText(full_path))
                {
                    string result = reader.ReadLine();
                    try
                    {
                        ret = Int32.Parse(result);
                    }
                    catch
                    {
                    }
                }
            }
            catch (Exception e)
            {
                // Do Nothing
            }

            local_name_lock.Release();
            return ret;
        }

        public void WriteInt(string filename, int value)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += filename;

            try
            { 
                using (StreamWriter writer = File.CreateText(full_path))
                {
                    string result = value.ToString();
                    writer.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                // Do Nothing
            }

        }
        public void WriteInt(Name name, int value)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += name_path[name];

            SemaphoreSlim local_name_lock = name_lock[name];
            local_name_lock.Wait();

            try
            { 
                using (StreamWriter writer = File.CreateText(full_path))
                {
                    string result = value.ToString();
                    writer.WriteLine(result);
                }
            }
            catch (Exception e)
            {
                // Do Nothing
            }

            local_name_lock.Release();
        }

        public Tuple<int, int> readClock()
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += name_path[Name.Timer];

            SemaphoreSlim local_name_lock = name_lock[Name.Timer];
            local_name_lock.Wait();

            int minute = 0;
            int second = 0;
            try
            { 
                using (StreamReader reader = File.OpenText(full_path))
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
                }
            }
            catch (Exception e)
            {
                // Do Nothing
            }

            local_name_lock.Release();
            return new Tuple<int, int>(minute, second);
        }

        public void writeClock(int minute, int second)
        {
            string full_path = folder_path;
            full_path += "\\";
            full_path += name_path[Name.Timer];

            SemaphoreSlim local_name_lock = name_lock[Name.Timer];
            local_name_lock.Wait();

            try
            { 
                using (StreamWriter writer = File.CreateText(full_path))
                {
                    String minute_str = minute.ToString("D2");
                    String second_str = second.ToString("D2");

                    String value = minute_str + ":" + second_str;
                    writer.WriteLine(value);
                }
            }
            catch (Exception e)
            {
                // Do Nothing
            }

            local_name_lock.Release();
        }

        private Dictionary<Name, SemaphoreSlim> name_lock = new Dictionary<Name, SemaphoreSlim>
        {
            {Name.Name1P,  new SemaphoreSlim(1,1)},
            {Name.Name2P,  new SemaphoreSlim(1,1)},
            {Name.Score1P, new SemaphoreSlim(1,1)},
            {Name.Score2P, new SemaphoreSlim(1,1)},
            {Name.Label,  new SemaphoreSlim(1,1)},
            {Name.MISC1,  new SemaphoreSlim(1,1)},
            {Name.MISC2,  new SemaphoreSlim(1,1)},
            {Name.MISC3,  new SemaphoreSlim(1,1)},
            {Name.MISC4,  new SemaphoreSlim(1,1)},
            {Name.Timer,  new SemaphoreSlim(1,1)},
        };

        private Dictionary<Name, String> name_path = new Dictionary<Name, string>
        {
            {Name.Name1P,  "name_1p.txt"},
            {Name.Name2P,  "name_2p.txt"},
            {Name.Score1P,  "score_1p.txt"},
            {Name.Score2P,  "score_2p.txt"},
            {Name.Label,  "label.txt"},
            {Name.MISC1,  "misc1.txt"},
            {Name.MISC2,  "misc2.txt"},
            {Name.MISC3,  "misc3.txt"},
            {Name.MISC4,  "misc4.txt"},
            {Name.Timer,  "timer.txt"},

        };

        private string path_file_path = "folder_path.txt";
        public string folder_path;
    }
}
