using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using BananaScoreBoard.Model;
using BananaScoreBoard.View.MainView;
using BananaScoreBoard.ViewModel.MainViewModel.SubViewModel;

namespace BananaScoreBoard.ViewModel.MainViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        
        public FolderPathViewModel folderPathViewModel;
        public MISCViewModel miscViewModel;
        public ScoreViewModel scoreViewModel;
        public TimerViewModel timerViewModel;
        public ToastViewModel toastVIewModel;

        public MainViewModel(MainView view)
        {
            folderPathViewModel = new FolderPathViewModel(this, view.folderPathView);
            miscViewModel = new MISCViewModel(this, view.miscView);
            scoreViewModel = new ScoreViewModel(this, view.scoreView);
            timerViewModel = new TimerViewModel(this, view.timerView);
            toastVIewModel = new ToastViewModel(this, view.toastView);

            view.DataContext = this;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
