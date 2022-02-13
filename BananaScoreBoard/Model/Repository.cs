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
        public Match winnerMatch5_1;

        public Match loserMatch1_1;
        public Match loserMatch1_2;
        public Match loserMatch2_1;
        public Match loserMatch2_2;
        public Match loserMatch3_1;
        public Match loserMatch4_1;

        public Roster roster;

        public enum TabName
        {
            Match = 0,
            Tournament = 1,
            Info = 2,
        }
        public TabName current_tab = TabName.Match;
        public TournamentFrame tournamentFrame;
        
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

            winnerMatch1_1 = new Match("Qualifier 1st", "", "");
            winnerMatch1_2 = new Match("Qualifier 2nd", "", "");
            winnerMatch1_3 = new Match("Qualifier 3rd", "", "");
            winnerMatch1_4 = new Match("Qualifier 4th", "", "");
            winnerMatch2_1 = new Match("Semi-Final 1st", "", "");
            winnerMatch2_2 = new Match("Semi-Final 2nd", "", "");
            winnerMatch3_1 = new Match("Winner Final", "", "");
            winnerMatch4_1 = new Match("Grand Final", "", "");
            winnerMatch5_1 = new Match("Grand Final Rematch", "", "");

            loserMatch1_1 = new Match("Loser Match 1Round 1st", "", "");
            loserMatch1_2 = new Match("Loser Match 1Round 2nd", "", "");
            loserMatch2_1 = new Match("Loser Match 2Round 1st", "", "");
            loserMatch2_2 = new Match("Loser Match 2Round 2nd", "", "");
            loserMatch3_1 = new Match("Loser Match 3Round 1st", "", "");
            loserMatch4_1 = new Match("Loser Match Final", "", "");

            roster = new Roster();
            tournamentFrame = new TournamentFrame();

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
            loserMatch4_1.Reset();
        }
        public void UpdateTournament()
        {
            //record.WriteString(Record.Name.WinnerRound_1_1, 

            record.WriteString(Record.GetTournamentFileName(true, 1, 1, 1),  winnerMatch1_1.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 2, 1),  winnerMatch1_2.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 3, 1),  winnerMatch1_3.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 1, 4, 1),  winnerMatch1_4.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 2, 1, 1),  winnerMatch2_1.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2, 1),  winnerMatch2_2.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 3, 1, 1),  winnerMatch3_1.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 4, 1, 1),  winnerMatch4_1.Player1);
            record.WriteString(Record.GetTournamentFileName(true, 5, 1, 1), winnerMatch5_1.Player1);
            record.WriteString(Record.GetTournamentFileName(false, 1, 1, 1), loserMatch1_1.Player1);
            record.WriteString(Record.GetTournamentFileName(false, 1, 2, 1), loserMatch1_2.Player1);
            record.WriteString(Record.GetTournamentFileName(false, 2, 1, 1), loserMatch2_1.Player1);
            record.WriteString(Record.GetTournamentFileName(false, 2, 2, 1), loserMatch2_2.Player1);
            record.WriteString(Record.GetTournamentFileName(false, 3, 1, 1), loserMatch3_1.Player1);
            record.WriteString(Record.GetTournamentFileName(false, 4, 1, 1), loserMatch4_1.Player1);

            record.WriteString(Record.GetTournamentFileName(true, 1, 1,  2), winnerMatch1_1.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 2,  2), winnerMatch1_2.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 3,  2), winnerMatch1_3.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 1, 4,  2), winnerMatch1_4.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 2, 1,  2), winnerMatch2_1.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 2, 2,  2), winnerMatch2_2.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 3, 1,  2), winnerMatch3_1.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 4, 1,  2), winnerMatch4_1.Player2);
            record.WriteString(Record.GetTournamentFileName(true, 5, 1, 1), winnerMatch5_1.Player2);
            record.WriteString(Record.GetTournamentFileName(false, 1, 1, 2), loserMatch1_1.Player2);
            record.WriteString(Record.GetTournamentFileName(false, 1, 2, 2), loserMatch1_2.Player2);
            record.WriteString(Record.GetTournamentFileName(false, 2, 1, 2), loserMatch2_1.Player2);
            record.WriteString(Record.GetTournamentFileName(false, 2, 2, 2), loserMatch2_2.Player2);
            record.WriteString(Record.GetTournamentFileName(false, 3, 1, 2), loserMatch3_1.Player2);
            record.WriteString(Record.GetTournamentFileName(false, 4, 1, 2), loserMatch3_1.Player2);

            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 1,  1), winnerMatch1_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 2,  1), winnerMatch1_2.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 3,  1), winnerMatch1_3.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 4,  1), winnerMatch1_4.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 2, 1,  1), winnerMatch2_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 2, 2,  1), winnerMatch2_2.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 3, 1,  1), winnerMatch3_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 4, 1,  1), winnerMatch4_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 5, 1,  1), winnerMatch5_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 1, 1, 1), loserMatch1_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 1, 2, 1), loserMatch1_2.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 2, 1, 1), loserMatch2_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 2, 2, 1), loserMatch2_2.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 3, 1, 1), loserMatch3_1.player1_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 4, 1, 1), loserMatch4_1.player1_score);

            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 1,  2), winnerMatch1_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 2,  2), winnerMatch1_2.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 3,  2), winnerMatch1_3.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 1, 4,  2), winnerMatch1_4.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 2, 1,  2), winnerMatch2_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 2, 2,  2), winnerMatch2_2.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 3, 1,  2), winnerMatch3_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 4, 1,  2), winnerMatch4_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(true, 5, 1,  2), winnerMatch5_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 1, 1, 2),  loserMatch1_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 1, 2, 2),  loserMatch1_2.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 2, 1, 2),  loserMatch2_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 2, 2, 2),  loserMatch2_2.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 3, 1, 2),  loserMatch3_1.player2_score);
            record.WriteInt(Record.GetTournamentScoreFileName(false, 4, 1, 2),  loserMatch4_1.player2_score);
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
            switch (current_tab)
            {
                case TabName.Match:
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
                    break;
                case TabName.Tournament:
                    {
                        if (tournamentFrame.FrameName == TournamentFrame.Name.Tournament)
                        {
                            winnerMatch1_1.Refresh();
                            winnerMatch1_2.Refresh();
                            winnerMatch1_3.Refresh();
                            winnerMatch1_4.Refresh();
                            winnerMatch2_1.Refresh();
                            winnerMatch2_2.Refresh();
                            winnerMatch3_1.Refresh();
                            winnerMatch4_1.Refresh();
                            winnerMatch5_1.Refresh();

                            loserMatch1_1.Refresh();
                            loserMatch1_2.Refresh();
                            loserMatch2_1.Refresh();
                            loserMatch2_2.Refresh();
                            loserMatch3_1.Refresh();
                            loserMatch4_1.Refresh();
                        }
                        else
                        {
                            roster.Refresh();
                        }
                    }
                    break;
            }
         
        }
        public void Load()
        {
            record.loadPath();

            switch (current_tab)
            {
                case TabName.Match:
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
                    break;
                case TabName.Tournament:
                    {
                        if (tournamentFrame.FrameName == TournamentFrame.Name.Tournament)
                        {
                            winnerMatch1_1.Player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 1));
                            winnerMatch1_2.Player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 2, 1));
                            winnerMatch1_3.Player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 3, 1));
                            winnerMatch1_4.Player1 = record.ReadString(Record.GetTournamentFileName(true, 1, 4, 1));

                            winnerMatch1_1.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 2));
                            winnerMatch1_2.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 2, 2));
                            winnerMatch1_3.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 3, 2));
                            winnerMatch1_4.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 4, 2));


                            // winnerMatch2_1.Player1 = record.ReadString(Record.GetTournamentFileName(true, 2, 1, 1));
                            // winnerMatch2_2.Player1 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 1));
                            // winnerMatch3_1.Player1 = record.ReadString(Record.GetTournamentFileName(true, 3, 1, 1));
                            // winnerMatch4_1.Player1 = record.ReadString(Record.GetTournamentFileName(true, 4, 1, 1));
                            // loserMatch1_1.Player1 = record.ReadString(Record.GetTournamentFileName(false, 1, 1, 1));
                            // loserMatch1_2.Player1 = record.ReadString(Record.GetTournamentFileName(false, 1, 2, 1));
                            // loserMatch2_1.Player1 = record.ReadString(Record.GetTournamentFileName(false, 2, 1, 1));
                            // loserMatch2_2.Player1 = record.ReadString(Record.GetTournamentFileName(false, 2, 2, 1));
                            // loserMatch3_1.Player1 = record.ReadString(Record.GetTournamentFileName(false, 3, 1, 1));
                            // loserMatch3_2.Player1 = record.ReadString(Record.GetTournamentFileName(false, 3, 2, 1));
                            // loserMatch4_1.Player1 = record.ReadString(Record.GetTournamentFileName(false, 4, 1, 1));

                            // winnerMatch1_1.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 1, 2));
                            // winnerMatch1_2.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 2, 2));
                            // winnerMatch1_3.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 3, 2));
                            // winnerMatch1_4.Player2 = record.ReadString(Record.GetTournamentFileName(true, 1, 4, 2));
                            // winnerMatch2_1.Player2 = record.ReadString(Record.GetTournamentFileName(true, 2, 1, 2));
                            // winnerMatch2_2.Player2 = record.ReadString(Record.GetTournamentFileName(true, 2, 2, 2));
                            // winnerMatch3_1.Player2 = record.ReadString(Record.GetTournamentFileName(true, 3, 1, 2));
                            // winnerMatch4_1.Player2 = record.ReadString(Record.GetTournamentFileName(true, 4, 1, 2));
                            // loserMatch1_1.Player2 = record.ReadString(Record.GetTournamentFileName(false, 1, 1, 2));
                            // loserMatch1_2.Player2 = record.ReadString(Record.GetTournamentFileName(false, 1, 2, 2));
                            // loserMatch2_1.Player2 = record.ReadString(Record.GetTournamentFileName(false, 2, 1, 2));
                            // loserMatch2_2.Player2 = record.ReadString(Record.GetTournamentFileName(false, 2, 2, 2));
                            // loserMatch3_1.Player2 = record.ReadString(Record.GetTournamentFileName(false, 3, 1, 2));
                            // loserMatch4_1.Player2 = record.ReadString(Record.GetTournamentFileName(false, 4, 1, 2));

                            winnerMatch1_1.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 1, 1));
                            winnerMatch1_2.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 2, 1));
                            winnerMatch1_3.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 3, 1));
                            winnerMatch1_4.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 4, 1));
                            winnerMatch2_1.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 2, 1, 1));
                            winnerMatch2_2.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 2, 2, 1));
                            winnerMatch3_1.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 3, 1, 1));
                            winnerMatch4_1.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 4, 1, 1));
                            winnerMatch5_1.player1_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 5, 1, 1));
                            loserMatch1_1.player1_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 1, 1, 1));
                            loserMatch1_2.player1_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 1, 2, 1));
                            loserMatch2_1.player1_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 2, 1, 1));
                            loserMatch2_2.player1_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 2, 2, 1));
                            loserMatch3_1.player1_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 3, 1, 1));
                            loserMatch4_1.player1_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 4, 1, 1));

                            winnerMatch1_1.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 1, 2));
                            winnerMatch1_2.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 2, 2));
                            winnerMatch1_3.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 3, 2));
                            winnerMatch1_4.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 1, 4, 2));
                            winnerMatch2_1.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 2, 1, 2));
                            winnerMatch2_2.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 2, 2, 2));
                            winnerMatch3_1.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 3, 1, 2));
                            winnerMatch4_1.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 4, 1, 2));
                            winnerMatch5_1.player2_score = record.ReadInt(Record.GetTournamentScoreFileName(true, 5, 1, 2));
                            loserMatch1_1.player2_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 1, 1, 2));
                            loserMatch1_2.player2_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 1, 2, 2));
                            loserMatch2_1.player2_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 2, 1, 2));
                            loserMatch2_2.player2_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 2, 2, 2));
                            loserMatch3_1.player2_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 3, 1, 2));
                            loserMatch4_1.player2_score  = record.ReadInt(Record.GetTournamentScoreFileName(false, 4, 1, 2));
                        }
                        else
                        {

                        }
                    }
                    break;
            }
        }

        public void ReadRoster()
        {
            if (record.Exists("roster.txt"))
            {
                string roster_text = record.ReadText("roster.txt");
                roster.Read(roster_text);
                roster.Refresh();
            }
        }

        public void CommitRoster()
        {
            ResetTournament();
            winnerMatch1_1.Player1 = roster.players[0].name;
            winnerMatch1_1.Player2 = roster.players[1].name;
            winnerMatch1_2.Player1 = roster.players[2].name;
            winnerMatch1_2.Player2 = roster.players[3].name;
            winnerMatch1_3.Player1 = roster.players[4].name;
            winnerMatch1_3.Player2 = roster.players[5].name;
            winnerMatch1_4.Player1 = roster.players[6].name;
            winnerMatch1_4.Player2 = roster.players[7].name;

        }

        public bool CheckWinnerDeterminable(Match match)
        {
            var ret = match.CheckWinnerDeterminable();
            switch(ret)
            {
                case Match.MatchStatus.PLAYER1_EMPTY:
                    toast.SendMessage("{0} | Player1 is Empty", match.Name);
                    return false;
                case Match.MatchStatus.PLAYER2_EMPTY:
                    toast.SendMessage("{0} | Player2 is Empty", match.Name);
                    return false;
                case Match.MatchStatus.BOTH_EMPTY:
                    toast.SendMessage("{0} | Player1 and Player2 is Empty", match.Name);
                    return false;
                case Match.MatchStatus.OK:
                    return true;
            }
            return true;
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
