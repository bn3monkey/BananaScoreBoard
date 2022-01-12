using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BananaScoreBoard.Model;
using BananaScoreBoard.View.TabView.MatchView;
using BananaScoreBoard.ViewModel.TabViewModel.MatchViewModel.SubViewModel;

namespace BananaScoreBoard.ViewModel.TabViewModel.MatchViewModel
{
    class MatchViewModel : INotifyPropertyChanged
    {

        MatchView view;
        public MatchViewModel(MatchView view)
        {
            this.view = view;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public void ReadFolderPath()
        {
            Task task = new Task(() =>
            {
                Repository.Instance.record.InitializePath();
                Repository.Instance.Load();
                Repository.Instance.refresh();
            }
            );
            task.Start();
        }
    }
}
