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
        public Player player1 = null, player2 = null;
        public TimeView timer = null;
        public Round round = null;

        private Repository()
        {
            player1 = new Player("p1");
            player2 = new Player("p2");
            timer = new TimeView();
            round = new Round();
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
