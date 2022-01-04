using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.View;

namespace BananaScoreBoard.ViewModel
{
    class MainViewModel
    {
        MainView view;
        public MainViewModel(MainView view)
        {
            this.view = view;
        }
    }
}
