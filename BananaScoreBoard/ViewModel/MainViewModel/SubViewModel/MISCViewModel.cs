using BananaScoreBoard.View.MainView.SubView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BananaScoreBoard.Model;
using System.Windows;

namespace BananaScoreBoard.ViewModel.MainViewModel.SubViewModel
{
    class MISCViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public MISCViewModel(MainViewModel parent, MISCView view)
        {
            view.DataContext = this;
        }

        public string Label
        {
            get
            {
                return Repository.Instance.label;
            }
            set
            {
                Repository.Instance.label = value;
                OnPropertyUpdate("Label");
            }
        }

        public string MISC1
        {
            get
            {
                return Repository.Instance.misc1;
            }
            set
            {
                Repository.Instance.misc1 = value;
                OnPropertyUpdate("MISC1");
            }
        }

        public string MISC2
        {
            get
            {
                return Repository.Instance.misc2;
            }
            set
            {
                Repository.Instance.misc2 = value;
                OnPropertyUpdate("MISC2");
            }
        }

        public string MISC3
        {
            get
            {
                return Repository.Instance.misc3;
            }
            set
            {
                Repository.Instance.misc3 = value;
                OnPropertyUpdate("MISC3");
            }
        }

        public string MISC4
        {
            get
            {
                return Repository.Instance.misc4;
            }
            set
            {
                Repository.Instance.misc4 = value;
                OnPropertyUpdate("MISC4");
            }
        }
    }
}
