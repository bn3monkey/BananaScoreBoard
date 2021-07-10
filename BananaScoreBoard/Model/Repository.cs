using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BananaScoreBoard.Model.Type;

namespace BananaScoreBoard.Model
{
    class Repository
    {
        public Player player1;
        public Player player2;
        public Clock clock;
        public string label;
        public string misc1, misc2, misc3, misc4;

        public Record record;

        Repository()
        {
            player1 = new Player("", 0);
            player2 = new Player("", 0);
            clock = new Clock(new Tuple<int, int>(0, 0));
            label = "";
            misc1 = "";
            misc2 = "";
            misc3 = "";
            misc4 = "";
            record = new Record();
        }

        public void update()
        {
            record.WriteString(Record.Name.Name1P, player1.name);
            record.WriteInt(Record.Name.Score1P, player1.score);
            record.WriteString(Record.Name.Name2P, player2.name);
            record.WriteInt(Record.Name.Score2P, player2.score);
            record.WriteString(Record.Name.Label, label);
            record.WriteString(Record.Name.MISC1, misc1);
            record.WriteString(Record.Name.MISC2, misc2);
            record.WriteString(Record.Name.MISC3, misc3);
            record.WriteString(Record.Name.MISC4, misc4);
        }

        public void load()
        {
            record.loadPath();

            {
                string name = record.ReadString(Record.Name.Name1P);
                int score = record.ReadInt(Record.Name.Score1P);
                player1 = new Player(name, score);
            }

            {
                string name = record.ReadString(Record.Name.Name2P);
                int score = record.ReadInt(Record.Name.Score2P);
                player2 = new Player(name, score);
            }

            label = record.ReadString(Record.Name.Label);
            misc1 = record.ReadString(Record.Name.MISC1);
            misc2 = record.ReadString(Record.Name.MISC2);
            misc3 = record.ReadString(Record.Name.MISC3);
            misc4 = record.ReadString(Record.Name.MISC3);

            {
                Tuple<int, int> param = record.readClock();
                clock = new Clock(param);
            }
        }
        

        private static readonly Lazy<Repository> _instance = new Lazy<Repository>(() => new Repository());
        public static Repository Instance
        {
            get
            {
                return _instance.Value;
            }
        }
    }
}
