using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model.Type
{
    class TournamentFrame : Refreshable
    {
        public enum Name
        {
            Tournament,
            Roster
        }

        private Name name = Name.Tournament;
        public Name FrameName
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                Refresh();
            }
        }
    }
}
