using BananaScoreBoard.View.TabView.MatchView.SubView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BananaScoreBoard.Model;
using System.Windows;

namespace BananaScoreBoard.ViewModel.TabViewModel.MatchViewModel.SubViewModel
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

        public MISCViewModel(MISCView view)
        {
            
            Repository.Instance.label.registerRefresher(() =>
            {
                OnPropertyUpdate("Label");
            });
            Repository.Instance.misc1.registerRefresher(() =>
            {
                OnPropertyUpdate("MISC1");
            });
            Repository.Instance.misc2.registerRefresher(() =>
            {
                OnPropertyUpdate("MISC2");
            });
            Repository.Instance.misc3.registerRefresher(() =>
            {
                OnPropertyUpdate("MISC3");
            });
            Repository.Instance.misc4.registerRefresher(() =>
            {
                OnPropertyUpdate("MISC4");
            });
        }

        public string Label
        {
            get
            {
                return Repository.Instance.label.value;
            }
            set
            {
                Log.Log.V(string.Format("Change Label : {0} -> {1}", Repository.Instance.label.value, value));
                Repository.Instance.label.value = value;
                OnPropertyUpdate("Label");
            }
        }

        public string MISC1
        {
            get
            {
                return Repository.Instance.misc1.value;
            }
            set
            {
                Log.Log.V(string.Format("Change MISC1 : {0} -> {1}", Repository.Instance.misc1.value, value));
                Repository.Instance.misc1.value = value;
                OnPropertyUpdate("MISC1");
            }
        }

        public string MISC2
        {
            get
            {
                return Repository.Instance.misc2.value;
            }
            set
            {
                Log.Log.V(string.Format("Change MISC2 : {0} -> {1}", Repository.Instance.misc2.value, value));
                Repository.Instance.misc2.value = value;
                OnPropertyUpdate("MISC2");
            }
        }

        public string MISC3
        {
            get
            {
                return Repository.Instance.misc3.value;
            }
            set
            {
                Log.Log.V(string.Format("Change MISC3 : {0} -> {1}", Repository.Instance.misc3.value, value));
                Repository.Instance.misc3.value = value;
                OnPropertyUpdate("MISC3");
            }
        }

        public string MISC4
        {
            get
            {
                return Repository.Instance.misc4.value;
            }
            set
            {
                Log.Log.V(string.Format("Change MISC4 : {0} -> {1}", Repository.Instance.misc4.value, value));
                Repository.Instance.misc4.value = value;
                OnPropertyUpdate("MISC4");
            }
        }
    }
}
