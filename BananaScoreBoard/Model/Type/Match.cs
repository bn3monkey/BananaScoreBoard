using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model.Type
{
    class Match : Refreshable
    {
        public string player1;
        public string player2;
        public int winner;

        private Match winnerMatch = null;
        private int winnermatch_player_number = 0;

        private Match loserMatch = null;
        private int losermatch_player_number = 0;

        bool isOnePlayer = false;
        public bool IsOnePlayer
        {
            get { return isOnePlayer; }
            set { isOnePlayer = value; }
        }

        private string name;
        public string Name
        {
            get
            {
                return name;
            }
        }
        public string WinnerMatchName
        {
            get
            {
                if (winnerMatch != null)
                    return winnerMatch.Name;
                return "";
            }
        }
        public string LoserMatchName
        {
            get
            {
                if (loserMatch != null)
                    return loserMatch.Name;
                return "";
            }
        }


        public Match(string name, string player1, string player2)
        {
            this.name = name;
            this.player1 = player1;
            this.player2 = player2;
            this.winner = 0;
        }

        public void SwitchLoserMatchToOtherWinnerMatch(Match otherMatch)
        {
            Match temp;
            string temp3;

            if (this.losermatch_player_number == 1)
            {
                temp3 = loserMatch.player1;
                if (otherMatch.winnermatch_player_number == 1)
                {
                    loserMatch.player1 = otherMatch.winnerMatch.player1;
                    otherMatch.winnerMatch.player1 = temp3;
                }
                else if (otherMatch.winnermatch_player_number == 2)
                {
                    loserMatch.player1 = otherMatch.winnerMatch.player2;
                    otherMatch.winnerMatch.player2 = temp3;
                }
            }
            else if (this.losermatch_player_number == 2)
            {
                temp3 = loserMatch.player2;
                if (otherMatch.winnermatch_player_number == 1)
                {
                    loserMatch.player2 = otherMatch.winnerMatch.player1;
                    otherMatch.winnerMatch.player1 = temp3;
                }
                else if (otherMatch.winnermatch_player_number == 2)
                {
                    loserMatch.player2 = otherMatch.winnerMatch.player2;
                    otherMatch.winnerMatch.player2 = temp3;
                }
            }

            temp = this.loserMatch;
            this.loserMatch = otherMatch.winnerMatch;
            otherMatch.winnerMatch = temp;

            int temp2;
            temp2 = this.losermatch_player_number;
            this.losermatch_player_number = otherMatch.winnermatch_player_number;
            otherMatch.winnermatch_player_number = temp2;

        }

        public void SetNextMatch(Match winnerMatch, int winnermatch_player_number, 
                                    Match loserMatch, int losermatch_player_number)
        {
            this.winnerMatch = winnerMatch;
            this.winnermatch_player_number = winnermatch_player_number;
            this.loserMatch = loserMatch;
            this.losermatch_player_number = losermatch_player_number;
        }

        public void Reset()
        {
            this.player1 = "";
            this.player2 = "";
            this.winner = 0;
        }

        public enum WinnerCode
        {
            PLAYER1_EMPTY,
            PLAYER2_EMPTY,
            ALL_EMPTY,
            WINNER_MATCH_NEEDS_NO_WINNER,
            LOSER_MATCH_NEEDS_NO_WINNER,
            ALL_MATCH_NEEDS_NO_WINNER,
            SUCCESS,
        }
        public WinnerCode WinPlayer1()
        {
            if (isOnePlayer)
            {
                if (player1 == "")
                    return WinnerCode.PLAYER1_EMPTY;
            }
            else
            {
                if (player1 == "")
                {
                    if (player2 == "")
                    {
                        return WinnerCode.ALL_EMPTY;
                    }
                    else
                    {
                        return WinnerCode.PLAYER1_EMPTY;
                    }
                }
                else
                {
                    if (player2 == "")
                    {
                        return WinnerCode.PLAYER2_EMPTY;
                    }
                }
            }

            if (winnerMatch == null && loserMatch == null)
            {
                // Do nothing
            }
            else if (winnerMatch == null)
            {
                if (loserMatch.winner != 0)
                    return WinnerCode.LOSER_MATCH_NEEDS_NO_WINNER;
            }
            else if (loserMatch == null)
            {
                if (winnerMatch.winner != 0)
                    return WinnerCode.WINNER_MATCH_NEEDS_NO_WINNER;
            }
            else
            {
                if (winnerMatch.winner != 0)
                {
                    if (loserMatch.winner != 0)
                    {
                        return WinnerCode.ALL_MATCH_NEEDS_NO_WINNER;
                    }
                    else
                    {
                        return WinnerCode.WINNER_MATCH_NEEDS_NO_WINNER;
                    }
                }
                else
                {
                    if (loserMatch.winner != 0)
                    {
                        return WinnerCode.LOSER_MATCH_NEEDS_NO_WINNER;
                    }
                }
            }
            


            switch (winner)
            {
                case 0:
                    DetermineNextMatch(player1, player2);
                    winner = 1;
                    break;
                case 1:
                    ResetNextMatch();
                    winner = 0;
                    break;
                case 2:
                    ResetNextMatch();
                    DetermineNextMatch(player1, player2);
                    winner = 1;
                    break;
            }
            this.Refresh();
            if (winnerMatch != null)
                winnerMatch.Refresh();
            if (loserMatch != null)
                loserMatch.Refresh();

            return WinnerCode.SUCCESS;
        }


        public WinnerCode WinPlayer2()
        {
            if (isOnePlayer)
            {
                if (player1 == "")
                    return WinnerCode.PLAYER1_EMPTY;
            }
            else
            {
                if (player1 == "")
                {
                    if (player2 == "")
                    {
                        return WinnerCode.ALL_EMPTY;
                    }
                    else
                    {
                        return WinnerCode.PLAYER1_EMPTY;
                    }
                }
                else
                {
                    if (player2 == "")
                    {
                        return WinnerCode.PLAYER2_EMPTY;
                    }
                }
            }

            if (winnerMatch == null && loserMatch == null)
            {
                // Do nothing
            }
            else if (winnerMatch == null)
            {
                if (loserMatch.winner != 0)
                    return WinnerCode.LOSER_MATCH_NEEDS_NO_WINNER;
            }
            else if (loserMatch == null)
            {
                if (winnerMatch.winner != 0)
                    return WinnerCode.WINNER_MATCH_NEEDS_NO_WINNER;
            }
            else
            {
                if (winnerMatch.winner != 0)
                {
                    if (loserMatch.winner != 0)
                    {
                        return WinnerCode.ALL_MATCH_NEEDS_NO_WINNER;
                    }
                    else
                    {
                        return WinnerCode.WINNER_MATCH_NEEDS_NO_WINNER;
                    }
                }
                else
                {
                    if (loserMatch.winner != 0)
                    {
                        return WinnerCode.LOSER_MATCH_NEEDS_NO_WINNER;
                    }
                }
            }

            switch (winner)
            {
                case 0:
                    DetermineNextMatch(player2, player1);
                    winner = 2;
                    break;
                case 1:
                    ResetNextMatch();
                    DetermineNextMatch(player2, player1);
                    winner = 2;
                    break;
                case 2:
                    ResetNextMatch();
                    winner = 0;
                    break;
            }
            this.Refresh();

            if (winnerMatch != null)
                winnerMatch.Refresh();

            if (loserMatch != null)
                loserMatch.Refresh();

            return WinnerCode.SUCCESS;
        }


        private void ResetNextMatch()
        {
            switch (winnermatch_player_number)
            {
                case 0: break;
                case 1:
                    if (winnerMatch != null)
                        winnerMatch.player1 = "";
                    break;
                case 2:
                    if (winnerMatch != null)
                        winnerMatch.player2 = "";
                    break;
            }
            switch (losermatch_player_number)
            {
                case 0: break;
                case 1:
                    if (loserMatch != null)
                        loserMatch.player1 = "";
                    break;
                case 2:
                    if (loserMatch != null)
                        loserMatch.player2 = "";
                    break;
            }
        }
        private void DetermineNextMatch(string winner, string loser)
        {
            /*
            if (player1.Length == 0 || player2.Length == 0)
                return;
            */

            if (winnerMatch != null)
            {
                if (winnermatch_player_number == 1)
                    winnerMatch.player1 = winner;
                else if (winnermatch_player_number == 2)
                    winnerMatch.player2 = winner;
            }

            if (loserMatch != null)
            {
                if (losermatch_player_number == 1)
                    loserMatch.player1 = loser;
                else if (losermatch_player_number == 2)
                    loserMatch.player2 = loser;
            }
        }
    }
}
