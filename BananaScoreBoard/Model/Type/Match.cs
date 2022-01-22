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


        public Match(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.winner = 0;
        }

        public void SetNextMatch(Match winnerMatch, Match loserMatch)
        {
            this.winnerMatch = winnerMatch;
            winnermatch_player_number = 0;
            this.loserMatch = loserMatch;
            losermatch_player_number = 0;
        }

        public void Reset()
        {
            this.player1 = "";
            this.player2 = "";
            this.winner = 0;
        }

        public void WinPlayer1()
        {
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
        }


        public void WinPlayer2()
        {
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
                if (winnerMatch.player1 == "")
                {
                    winnermatch_player_number = 1;
                    winnerMatch.player1 = winner;
                }
                else
                {
                    winnermatch_player_number = 2;
                    winnerMatch.player2 = winner;
                }
            }

            if (loserMatch != null)
            {
                if (loserMatch.player1 == "")
                {
                    losermatch_player_number = 1;
                    loserMatch.player1 = loser;
                }
                else
                {
                    losermatch_player_number = 2;
                    loserMatch.player2 = loser;
                }
            }
        }
    }
}
