﻿using System;
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
        public LabelText label;
        public LabelText misc1, misc2, misc3, misc4;

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
        public Match loserMatch3_2;
        public Match loserMatch4_1;

        public int current_tab = 0;
        
        Repository()
        {
            player1 = new Player("", 0);
            player2 = new Player("", 0);
            clock = new Clock(new Tuple<int, int>(0, 0));
            label = new LabelText();
            misc1 = new LabelText();
            misc2 = new LabelText();
            misc3 = new LabelText();
            misc4 = new LabelText();
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
            loserMatch3_2 = new Match("", "");
            loserMatch4_1 = new Match("", "");

            // PlayerWithDB.openPlayerList();
        }

        public List<string> listPlayer(string name)
        {
            return PlayerWithDB.listPlayer(name);
        }

        public void ResetTournament()
        {
            winnerMatch1_1.Reset();
            winnerMatch1_2.Reset();
            winnerMatch1_3.Reset();
            winnerMatch1_4.Reset();
            winnerMatch2_1.Reset();
            winnerMatch2_2.Reset();
            winnerMatch3_1.Reset();
            winnerMatch4_1.Reset();


            loserMatch1_1.Reset();
            loserMatch1_2.Reset();
            loserMatch2_1.Reset();
            loserMatch2_2.Reset();
            loserMatch3_1.Reset();
            loserMatch3_2.Reset();
            loserMatch4_1.Reset();
        }
        public void UpdateTournament()
        {
            //record.WriteString(Record.Name.WinnerRound_1_1, 

            record.WriteString(Record.GetTournamentFileName(true, 1, 1, 1),  winnerMatch1_1.player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 2, 1),  winnerMatch1_2.player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 3, 1),  winnerMatch1_3.player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 4, 1),  winnerMatch1_4.player1);
            record.WriteString(Record.GetTournamentFileName(true, 2, 1, 1),  winnerMatch2_1.player1);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2, 1),  winnerMatch2_2.player1);
            record.WriteString(Record.GetTournamentFileName(true, 3, 1, 1),  winnerMatch3_1.player1);
            record.WriteString(Record.GetTournamentFileName(true, 4, 1, 1),  winnerMatch4_1.player1);
            record.WriteString(Record.GetTournamentFileName(false, 1, 1, 1), loserMatch1_1.player1);
            record.WriteString(Record.GetTournamentFileName(false, 1, 2, 1), loserMatch1_2.player1);
            record.WriteString(Record.GetTournamentFileName(false, 2, 1, 1), loserMatch2_1.player1);
            record.WriteString(Record.GetTournamentFileName(false, 2, 2, 1), loserMatch2_2.player1);
            record.WriteString(Record.GetTournamentFileName(false, 3, 1, 1), loserMatch3_1.player1);
            record.WriteString(Record.GetTournamentFileName(false, 3, 2, 1), loserMatch3_2.player1);
            record.WriteString(Record.GetTournamentFileName(false, 4, 1, 1), loserMatch4_1.player1);

            record.WriteString(Record.GetTournamentFileName(true, 1, 1,  2), winnerMatch1_1.player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 2,  2), winnerMatch1_2.player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 3,  2), winnerMatch1_3.player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 4,  2), winnerMatch1_4.player2);
            record.WriteString(Record.GetTournamentFileName(true, 2, 1,  2), winnerMatch2_1.player2);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2,  2), winnerMatch2_2.player2);
            record.WriteString(Record.GetTournamentFileName(true, 3, 1,  2), winnerMatch3_1.player2);
            record.WriteString(Record.GetTournamentFileName(true, 4, 1,  2), winnerMatch4_1.player2);
            record.WriteString(Record.GetTournamentFileName(false, 1, 1, 2), loserMatch1_1.player2);
            record.WriteString(Record.GetTournamentFileName(false, 1, 2, 2), loserMatch1_2.player2);
            record.WriteString(Record.GetTournamentFileName(false, 2, 1, 2), loserMatch2_1.player2);
            record.WriteString(Record.GetTournamentFileName(false, 2, 2, 2), loserMatch2_2.player2);
            record.WriteString(Record.GetTournamentFileName(false, 3, 1, 2), loserMatch3_1.player2);
            record.WriteString(Record.GetTournamentFileName(false, 3, 2, 2), loserMatch3_2.player2);
            record.WriteString(Record.GetTournamentFileName(false, 4, 1, 2), loserMatch3_1.player2);

            record.WriteInt(Record.GetTournamentWinnerFileName(true, 1, 1), winnerMatch1_1.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(true, 1, 2), winnerMatch1_2.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(true, 1, 3), winnerMatch1_3.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(true, 1, 4), winnerMatch1_4.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(true, 2, 1), winnerMatch2_1.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(true, 2, 2), winnerMatch2_2.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(true, 3, 1), winnerMatch3_1.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(true, 4, 1), winnerMatch4_1.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(false, 1, 1), loserMatch1_1.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(false, 1, 2), loserMatch1_2.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(false, 2, 1), loserMatch2_1.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(false, 2, 2), loserMatch2_2.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(false, 3, 1), loserMatch3_1.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(false, 3, 2), loserMatch3_2.winner);
            record.WriteInt(Record.GetTournamentWinnerFileName(false, 4, 1), loserMatch4_1.winner);
        }


        public void update()
        {
            record.WriteString(Record.Name.Name1P, player1.name);
            record.WriteInt(Record.Name.Score1P, player1.score);
            record.WriteString(Record.Name.Name2P, player2.name);
            record.WriteInt(Record.Name.Score2P, player2.score);
            record.WriteString(Record.Name.Label, label.value);
            record.WriteString(Record.Name.MISC1, misc1.value);
            record.WriteString(Record.Name.MISC2, misc2.value);
            record.WriteString(Record.Name.MISC3, misc3.value);
            record.WriteString(Record.Name.MISC4, misc4.value);

            //player1.addPlayer();
            //player2.addPlayer();
        }

        public void Refresh()
        {
            if(current_tab == 0)
            {
                player1.Refresh();
                player2.Refresh();
                clock.Refresh();
                label.Refresh();
                misc1.Refresh();
                misc2.Refresh();
                misc3.Refresh();
                misc4.Refresh();
            }
            else if(current_tab == 1)
            {
                winnerMatch1_1.Refresh();
                winnerMatch1_2.Refresh();
                winnerMatch1_3.Refresh();
                winnerMatch1_4.Refresh();
                winnerMatch2_1.Refresh();
                winnerMatch2_2.Refresh();
                winnerMatch3_1.Refresh();
                winnerMatch4_1.Refresh();

                loserMatch1_1.Refresh();
                loserMatch1_2.Refresh();
                loserMatch2_1.Refresh();
                loserMatch2_2.Refresh();
                loserMatch3_1.Refresh();
                loserMatch3_2.Refresh();
                loserMatch4_1.Refresh();
            }
        }
        public void Load()
        {
            record.loadPath();

            if (current_tab == 0)
            {
                {
                    player1.name = record.ReadString(Record.Name.Name1P);
                    player1.score = record.ReadInt(Record.Name.Score1P);
                    // player1 = new PlayerWithDB(name, score);
                }

                {
                    player2.name = record.ReadString(Record.Name.Name2P);
                    player2.score = record.ReadInt(Record.Name.Score2P);
                    // player2 = new PlayerWithDB(name, score);
                }

                label.value = record.ReadString(Record.Name.Label);
                misc1.value = record.ReadString(Record.Name.MISC1);
                misc2.value = record.ReadString(Record.Name.MISC2);
                misc3.value = record.ReadString(Record.Name.MISC3);
                misc4.value = record.ReadString(Record.Name.MISC3);


                {
                    Tuple<int, int> param = record.readClock();
                    clock.minute = param.Item1;
                    clock.second = param.Item2;
                }
            }
            else if (current_tab == 1)
            {
                winnerMatch1_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 1));
                winnerMatch1_2.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 2, 1));
                winnerMatch1_3.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 3, 1));
                winnerMatch1_4.player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 4, 1));
                winnerMatch2_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 2, 1, 1));
                winnerMatch2_2.player1 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 1));
                winnerMatch3_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 3, 1, 1));
                winnerMatch4_1.player1 = record.ReadString(Record.GetTournamentFileName(true, 4, 1, 1));
                loserMatch1_1.player1 = record.ReadString(Record.GetTournamentFileName(false, 1, 1, 1));
                loserMatch1_2.player1 = record.ReadString(Record.GetTournamentFileName(false, 1, 2, 1));
                loserMatch2_1.player1 = record.ReadString(Record.GetTournamentFileName(false, 2, 1, 1));
                loserMatch2_2.player1 = record.ReadString(Record.GetTournamentFileName(false, 2, 2, 1));
                loserMatch3_1.player1 = record.ReadString(Record.GetTournamentFileName(false, 3, 1, 1));
                loserMatch3_2.player1 = record.ReadString(Record.GetTournamentFileName(false, 3, 2, 1));
                loserMatch4_1.player1 = record.ReadString(Record.GetTournamentFileName(false, 4, 1, 1));

                winnerMatch1_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 2));
                winnerMatch1_2.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 2, 2));
                winnerMatch1_3.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 3, 2));
                winnerMatch1_4.player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 4, 2));
                winnerMatch2_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 2, 1, 2));
                winnerMatch2_2.player2 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 2));
                winnerMatch3_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 3, 1, 2));
                winnerMatch4_1.player2 = record.ReadString(Record.GetTournamentFileName(true, 4, 1, 2));
                loserMatch1_1.player2 = record.ReadString(Record.GetTournamentFileName(false, 1, 1, 2));
                loserMatch1_2.player2 = record.ReadString(Record.GetTournamentFileName(false, 1, 2, 2));
                loserMatch2_1.player2 = record.ReadString(Record.GetTournamentFileName(false, 2, 1, 2));
                loserMatch2_2.player2 = record.ReadString(Record.GetTournamentFileName(false, 2, 2, 2));
                loserMatch3_1.player2 = record.ReadString(Record.GetTournamentFileName(false, 3, 1, 2));
                loserMatch4_1.player2 = record.ReadString(Record.GetTournamentFileName(false, 4, 1, 2));

                winnerMatch1_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 1, 1));
                winnerMatch1_2.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 1, 2));
                winnerMatch1_3.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 1, 3));
                winnerMatch1_4.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 1, 4));
                winnerMatch2_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 2, 1));
                winnerMatch2_2.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 2, 2));
                winnerMatch3_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 3, 1));
                winnerMatch4_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(true, 4, 1));
                loserMatch1_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(false, 1, 1));
                loserMatch1_2.winner = record.ReadInt(Record.GetTournamentWinnerFileName(false, 1, 2));
                loserMatch2_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(false, 2, 1));
                loserMatch2_2.winner = record.ReadInt(Record.GetTournamentWinnerFileName(false, 2, 2));
                loserMatch3_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(false, 3, 1));
                loserMatch3_2.winner = record.ReadInt(Record.GetTournamentWinnerFileName(false, 3, 2));
                loserMatch4_1.winner = record.ReadInt(Record.GetTournamentWinnerFileName(false, 4, 1));
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
