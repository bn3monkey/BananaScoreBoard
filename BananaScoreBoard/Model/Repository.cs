using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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
        public Toast toast;

        public Match winnerMatch1_1;
        public Match winnerMatch1_2;
        public Match winnerMatch1_3;
        public Match winnerMatch1_4;
        public Match winnerMatch2_1;
        public Match winnerMatch2_2;
        public Match winnerMatch3_1;
        public Match winnerMatch4_1;

        public Match loserMatch1_1;
        public Match loserMatch1_2;
        public Match loserMatch2_1;
        public Match loserMatch2_2;
        public Match loserMatch3_1;

        public int current_tab = 0;
        
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
            toast = new Toast();

            winnerMatch1_1 = new Match("", "");
            winnerMatch1_2 = new Match("", "");
            winnerMatch1_3 = new Match("", "");
            winnerMatch1_4 = new Match("", "");
            winnerMatch2_1 = new Match("", "");
            winnerMatch2_2 = new Match("", "");
            winnerMatch3_1 = new Match("", "");
            winnerMatch4_1 = new Match("", "");

            loserMatch1_1 = new Match("", "");
            loserMatch1_2 = new Match("", "");
            loserMatch2_1 = new Match("", "");
            loserMatch2_2 = new Match("", "");
            loserMatch3_1 = new Match("", "");

            // PlayerWithDB.openPlayerList();
        }

        public delegate void Refresher();    
        private List<Refresher> refreshers = new List<Refresher>();

        public void refresh()
        {
            foreach(var refresher in refreshers)
            {
                refresher.Invoke();
            }
        }
        public void registerReferehser(Refresher refresher)
        {
            refreshers.Add(refresher);
        }



        public List<string> listPlayer(string name)
        {
            return PlayerWithDB.listPlayer(name);
        }

        public void updateTournament()
        {
            //record.WriteString(Record.Name.WinnerRound_1_1, 

            record.WriteString(Record.GetTournamentFileName(true, 1, 1, 1),  winnerMatch1_1.player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 1, 1),  winnerMatch1_2.player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 1, 1),  winnerMatch1_3.player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 1, 1),  winnerMatch1_4.player1);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2, 1),  winnerMatch2_1.player1);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2, 1),  winnerMatch2_2.player1);
            record.WriteString(Record.GetTournamentFileName(true, 3, 3, 1),  winnerMatch3_1.player1);
            record.WriteString(Record.GetTournamentFileName(true, 4, 4, 1),  winnerMatch4_1.player1);
            record.WriteString(Record.GetTournamentFileName(false, 1, 1, 1), loserMatch1_1.player1);
            record.WriteString(Record.GetTournamentFileName(false, 1, 2, 1), loserMatch1_2.player1);
            record.WriteString(Record.GetTournamentFileName(false, 2, 1, 1), loserMatch2_1.player1);
            record.WriteString(Record.GetTournamentFileName(false, 2, 2, 1), loserMatch2_2.player1);
            record.WriteString(Record.GetTournamentFileName(false, 3, 1, 1), loserMatch3_1.player1);

            record.WriteString(Record.GetTournamentFileName(true, 1, 1,  2), winnerMatch1_1.player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 1,  2), winnerMatch1_2.player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 1,  2), winnerMatch1_3.player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 1,  2), winnerMatch1_4.player2);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2,  2), winnerMatch2_1.player2);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2,  2), winnerMatch2_2.player2);
            record.WriteString(Record.GetTournamentFileName(true, 3, 3,  2), winnerMatch3_1.player2);
            record.WriteString(Record.GetTournamentFileName(true, 4, 4,  2), winnerMatch4_1.player2);
            record.WriteString(Record.GetTournamentFileName(false, 1, 1, 2), loserMatch1_1.player2);
            record.WriteString(Record.GetTournamentFileName(false, 1, 2, 2), loserMatch1_2.player2);
            record.WriteString(Record.GetTournamentFileName(false, 2, 1, 2), loserMatch2_1.player2);
            record.WriteString(Record.GetTournamentFileName(false, 2, 2, 2), loserMatch2_2.player2);
            record.WriteString(Record.GetTournamentFileName(false, 3, 1, 2), loserMatch3_1.player2);
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

            //player1.addPlayer();
            //player2.addPlayer();
        }

        public void Load()
        {
            record.loadPath();

            if (current_tab == 0)
            {
                {
                    string name = record.ReadString(Record.Name.Name1P);
                    int score = record.ReadInt(Record.Name.Score1P);
                    // player1 = new PlayerWithDB(name, score);
                    player1 = new Player(name, score);
                }

                {
                    string name = record.ReadString(Record.Name.Name2P);
                    int score = record.ReadInt(Record.Name.Score2P);
                    // player2 = new PlayerWithDB(name, score);
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
            else if (current_tab == 1)
            {
                winnerMatch1_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 1));
                winnerMatch1_2.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 1));
                winnerMatch1_3.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 1));
                winnerMatch1_4.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 1));
                winnerMatch2_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 1));
                winnerMatch2_2.player1 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 1));
                winnerMatch3_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 3, 3, 1));
                winnerMatch4_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 4, 4, 1));
                loserMatch1_1.player1 = record.ReadString(Record.GetTournamentFileName(false, 1, 1, 1));
                loserMatch1_2.player1 = record.ReadString(Record.GetTournamentFileName(false, 1, 2, 1));
                loserMatch2_1.player1 = record.ReadString(Record.GetTournamentFileName(false, 2, 1, 1));
                loserMatch2_2.player1 = record.ReadString(Record.GetTournamentFileName(false, 2, 2, 1));
                loserMatch3_1.player1 = record.ReadString(Record.GetTournamentFileName(false, 3, 1, 1));

                winnerMatch1_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 2));
                winnerMatch1_2.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 2));
                winnerMatch1_3.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 2));
                winnerMatch1_4.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 2));
                winnerMatch2_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 2));
                winnerMatch2_2.player2 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 2));
                winnerMatch3_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 3, 3, 2));
                winnerMatch4_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 4, 4, 2));
                loserMatch1_1.player2 = record.ReadString(Record.GetTournamentFileName(false, 1, 1, 2));
                loserMatch1_2.player2 = record.ReadString(Record.GetTournamentFileName(false, 1, 2, 2));
                loserMatch2_1.player2 = record.ReadString(Record.GetTournamentFileName(false, 2, 1, 2));
                loserMatch2_2.player2 = record.ReadString(Record.GetTournamentFileName(false, 2, 2, 2));
                loserMatch3_1.player2 = record.ReadString(Record.GetTournamentFileName(false, 3, 1, 2));
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
