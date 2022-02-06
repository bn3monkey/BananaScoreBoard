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
        private Match loserMatch = null;

        private Match player1OriginMatch = null;
        private Match player2OriginMatch = null;


        public int winner;

        private string player1;
        public string Player1
        {
            get
            {
                if (player1OriginMatch == null)
                    return player1;
                else
                {
                    if (player1OriginMatch.winnerMatch.Equals(this))
                    {
                        switch (player1OriginMatch.winner)
                        {
                            case 1: return player1OriginMatch.Player1;
                            case 2: return player1OriginMatch.Player2;
                        }
                    }
                    else if(player1OriginMatch.loserMatch.Equals(this))
                    {
                        switch (player1OriginMatch.winner)
                        {
                            case 2: return player1OriginMatch.Player1;
                            case 1: return player1OriginMatch.Player2;
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
                    if (player2OriginMatch.winnerMatch.Equals(this))
                    {
                        switch (player2OriginMatch.winner)
                        {
                            case 1: return player2OriginMatch.Player1;
                            case 2: return player2OriginMatch.Player2;
                        }
                    }
                    else if (player2OriginMatch.loserMatch.Equals(this))
                    {
                        switch (player2OriginMatch.winner)
                        {
                            case 2: return player2OriginMatch.Player1;
                            case 1: return player2OriginMatch.Player2;
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
        

        #region PlayerCount
        bool isOnePlayer = false;
        public bool IsOnePlayer
        {
            get { return isOnePlayer; }
            set { isOnePlayer = value; }
        }
        #endregion

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
            this.winner = 0;
        }

        
        public void SetNextWinnerMatch(Match winnerMatch, int winner_player_number)
        {
            this.winnerMatch = winnerMatch;
            switch(winner_player_number)
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
            this.winner = 0;
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

        private WinnerCode ReturnWinnerCode()
        {
            if (isOnePlayer)
            {
                if (Player1 == "")
                    return WinnerCode.PLAYER1_EMPTY;
            }
            else
            {
                if (Player1 == "")
                {
                    if (Player2 == "")
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
                    if (Player2 == "")
                    {
                        return WinnerCode.PLAYER2_EMPTY;
                    }
                }
            }

            if (winnerMatch != null && loserMatch != null)
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
            else if (winnerMatch == null && loserMatch != null)
            {
                if (loserMatch.winner != 0)
                    return WinnerCode.LOSER_MATCH_NEEDS_NO_WINNER;
            }
            else if (loserMatch == null && winnerMatch != null)
            {

                if (winnerMatch.winner != 0)
                    return WinnerCode.WINNER_MATCH_NEEDS_NO_WINNER;
            }
            return WinnerCode.SUCCESS;
        }

        

        public WinnerCode WinPlayer1()
        {
            WinnerCode code = ReturnWinnerCode();
            if (code != WinnerCode.SUCCESS)
                return code;

            switch(winner)
            {
                case 0: winner = 1;
                    break;
                case 1:winner = 0;
                    break;
                case 2:winner = 1;
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
            WinnerCode code = ReturnWinnerCode();
            if (code != WinnerCode.SUCCESS)
                return code;

            switch (winner)
            {
                case 0:
                    winner = 2;
                    break;
                case 1:
                    winner = 2;
                    break;
                case 2:
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

    }
}
