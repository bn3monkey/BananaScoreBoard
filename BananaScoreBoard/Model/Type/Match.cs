using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model.Type
{
    class Match
    {
        public string player1;
        public string player2;
        public int winner;

        public Match(string player1, string player2)
        {
            this.player1 = player1;
            this.player2 = player2;
            this.winner = 0;
        }
    }
}
