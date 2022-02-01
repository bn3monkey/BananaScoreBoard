using BananaScoreBoard.Model.Type;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.Model
{
    class Roster : Refreshable
    {
        const int max_player = 8;
        public struct Player
        {
            public string name;
            public int mmr;
        }

        public Player[] players = new Player[max_player];


        public void Read(string text)
        {
            string[] players_content = text.Split('\n');
            for (int i = 0;i < max_player; i++)
            {
                string[] player_content = players_content[i].Split(' ');
                players[i].name = player_content[0];
                players[i].mmr = int.Parse(player_content[1]);
            }       
        }

        public void OrderByRandom()
        {
            Random random = new Random();
            int n = players.Length;

            while (n > 1)
            {
                int k = random.Next(n);
                n--;
                Player temp = players[n];
                players[n] = players[k];
                players[k] = temp;
            }
        }

        private bool isAsec = true;
        private static int CompareByMMR(Player x, Player y)
        {
            return x.mmr.CompareTo(y.mmr);
        }
        private static int CompareByMMRReverse(Player x, Player y)
        {
            return -x.mmr.CompareTo(y.mmr);
        }

        public void OrderByMMR()
        {
            if (isAsec)
                Array.Sort(players, CompareByMMR);
            else
                Array.Sort(players, CompareByMMRReverse);
            isAsec = !isAsec;
        }
    }
}
