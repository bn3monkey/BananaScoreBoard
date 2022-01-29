using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard
{
    class Version
    {
        private static string major = "1";
        private static string minor = "1";
        private static string revision = "0";
        public static string get()
        {
            return string.Format("V{0}.{1}.{2}", major, minor, revision); 
        }
    }
}
