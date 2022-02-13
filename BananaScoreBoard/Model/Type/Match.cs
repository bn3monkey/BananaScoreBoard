using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model.Type
{
    class Match : Refreshable
    {
        private Match winnerMatch = null;
        private int winner_player_number;
        private Match loserMatch = null;
        private int loser_player_number;

        private Match player1OriginMatch = null;
        private Match player2OriginMatch = null;


        public int player1_score;
        public int player2_score;

        private string player1;
        public string Player1
        {
            get
            {
                if (player1OriginMatch == null)
                    return player1;
                else
                {
                    if (player1OriginMatch.winnerMatch != null)
                    {
                        if (player1OriginMatch.winnerMatch.Equals(this) && player1OriginMatch.winner_player_number == 1)
                        {
                            if (player1OriginMatch.player1_score > player1OriginMatch.player2_score)
                                return player1OriginMatch.Player1;
                            else if (player1OriginMatch.player1_score < player1OriginMatch.player2_score)
                                return player1OriginMatch.Player2;

                        }
                    }
                    if (player1OriginMatch.loserMatch != null)
                    {
                        if (player1OriginMatch.loserMatch.Equals(this) && player1OriginMatch.loser_player_number == 1)
                        {
                            if (player1OriginMatch.player1_score < player1OriginMatch.player2_score)
                                return player1OriginMatch.Player1;
                            else if (player1OriginMatch.player1_score > player1OriginMatch.player2_score)
                                return player1OriginMatch.Player2;

                        }
                    }
                }
                return "";
            }
            set
            {
                if (player1OriginMatch == null)
                    player1 = value;
            }
        }

        private string player2;
        public string Player2
        {
            get
            {
                if (player2OriginMatch == null)
                    return player2;
                else
                {
                    if (player2OriginMatch.winnerMatch != null)
                    {
                        if (player2OriginMatch.winnerMatch.Equals(this) && player2OriginMatch.winner_player_number == 2)
                        {
                            if (player2OriginMatch.player1_score > player2OriginMatch.player2_score)
                                return player2OriginMatch.Player1;
                            else if (player2OriginMatch.player1_score < player2OriginMatch.player2_score)
                                return player2OriginMatch.Player2;
                        }
                    }
                    if (player2OriginMatch.loserMatch != null)
                    {
                        if (player2OriginMatch.loserMatch.Equals(this) && player2OriginMatch.loser_player_number == 2)
                        {
                            if (player2OriginMatch.player1_score < player2OriginMatch.player2_score)
                                return player2OriginMatch.Player1;
                            else if (player2OriginMatch.player1_score > player2OriginMatch.player2_score)
                                return player2OriginMatch.Player2;
                        }
                    }
                }
                return "";
            }
            set
            {
                if (player2OriginMatch == null)
                    player2 = value;
            }
        }
        
        #region Name
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
        #endregion

        #region Initializer
        public Match(string name, string player1, string player2)
        {
            this.name = name;
            this.player1 = player1;
            this.player2 = player2;
            this.player1_score = 0;
            this.player2_score = 0;
        }

        
        public void SetNextWinnerMatch(Match winnerMatch, int winner_player_number)
        {
            this.winnerMatch = winnerMatch;
            this.winner_player_number = winner_player_number;

            switch (winner_player_number)
            {
                case 1: winnerMatch.player1OriginMatch = this;
                    break;
                case 2: winnerMatch.player2OriginMatch = this;
                    break;
            }
        }
        public void SetNextLoserMatch(Match loserMatch, int loser_player_number)
        {
            this.loserMatch = loserMatch;
            this.loser_player_number = loser_player_number;
            switch (loser_player_number)
            {
                case 1:
                    loserMatch.player1OriginMatch = this;
                    break;
                case 2:
                    loserMatch.player2OriginMatch = this;
                    break;
            }
        }

        public void SetNextMatch(Match winnerMatch, int winner_player_number, 
                                    Match loserMatch, int loser_player_number)
        {
            SetNextWinnerMatch(winnerMatch, winner_player_number);
            SetNextLoserMatch(loserMatch, loser_player_number);
        }

        public void Reset()
        {
            this.Player1 = "";
            this.Player2 = "";
            this.player1_score = 0;
            this.player2_score = 0;
        }
        #endregion

        #region Refresh
        public void RefreshRecursive()
        {
            Refresh();
            if (winnerMatch != null)
                winnerMatch.RefreshRecursive();
            if (loserMatch != null)
                loserMatch.RefreshRecursive();
        }
        #endregion

        public enum MatchStatus
        {
            OK,
            PLAYER1_EMPTY,
            PLAYER2_EMPTY,
            BOTH_EMPTY
        }

        public MatchStatus CheckWinnerDeterminable()
        {
            if (Player1 == "" && Player2 == "")
            {
                return MatchStatus.BOTH_EMPTY;
            }
            else if (Player1 == "" && Player2 != "")
            {
                return MatchStatus.PLAYER1_EMPTY;
            }
            else if (Player1 != "" && Player2 == "")
            {
                return MatchStatus.PLAYER2_EMPTY;
            }
            else
                return MatchStatus.OK;
        }
    }
}
