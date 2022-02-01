using BananaScoreBoard.Model;
using BananaScoreBoard.View.TabView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BananaScoreBoard.ViewModel.TabViewModel
{
    class TabViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public int Selected
        {
            get
            {
                switch(Repository.Instance.current_tab)
                {
                    case Repository.TabName.Match:
                        return 0;
                    case Repository.TabName.Tournament:
                        return 1;
                    case Repository.TabName.Info:
                        return 2;
                }
                return 0;
            }
            set
            {
                Log.Log.V(string.Format("Change Current Tab : {0} -> {1}", Repository.Instance.current_tab, (Repository.TabName)value));
                switch (value)
                {
                    case 0:
                        Repository.Instance.current_tab = Repository.TabName.Match;
                        break;
                    case 1:
                        Repository.Instance.current_tab = Repository.TabName.Tournament;
                        break;
                    case 2:
                        Repository.Instance.current_tab = Repository.TabName.Info;
                        break;
                }
                OnPropertyUpdate("Selected");
            }
        }


        private TabView view;
        public TabViewModel(TabView view)
        {
            this.view = view;
        }
    }
}
