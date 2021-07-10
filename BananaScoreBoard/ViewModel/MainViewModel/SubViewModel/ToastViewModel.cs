using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.View.MainView.SubView;

using BananaScoreBoard.Model;
using System.Windows;

namespace BananaScoreBoard.ViewModel.MainViewModel.SubViewModel
{
    class ToastViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public ToastViewModel(MainViewModel parent, ToastView view)
        {
            view.DataContext = this;
        }

        private string toast;
        public string Toast
        {
            get
            {
                return toast;
            }
            set
            {
                toast = value;
                OnPropertyUpdate("Toast");
            }
        }
    }
}
