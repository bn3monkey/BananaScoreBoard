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
                return Repository.Instance.current_tab;
            }
            set
            {
                Repository.Instance.current_tab = value;
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
