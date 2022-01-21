using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model.Type
{
    public delegate void Refresher();
    class Refreshable
    {

        protected Refresher refresher;
        public virtual void registerRefresher(Refresher refresher)
        {
            this.refresher = refresher;
        }
        public virtual void Refresh()
        {
            Debug.Assert(refresher != null);

            refresher();
        }
    }
}
