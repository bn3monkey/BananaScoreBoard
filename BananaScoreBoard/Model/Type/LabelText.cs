using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model.Type
{
    class LabelText : Refreshable
    {
        public string value;
        public LabelText(string value = "")
        {
            this.value = value;
        }

    }
}
