using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.View.MainView.SubView;

using BananaScoreBoard.Model;
using System.Windows;
using System.Threading;
using System.Windows.Media;

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

        ToastView view;
        public ToastViewModel(MainViewModel parent, ToastView view)
        {
            this.view = view;
            view.DataContext = this;
        }

        private string toast;

        Timer toastTimer = null;

        int toastMaxCount = 30;
        int toastCount = 0;

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

                if (toast != "")
                {
                    toastTimer?.Dispose();
                    toastCount = toastMaxCount;
                    toastTimer = new Timer((Object stateInfo) =>
                    {
                        view.Dispatcher.Invoke(() =>
                        {
                            toastCount -= 1;

                            {
                                Color clr = Color.FromArgb((byte)(255 * toastCount / toastMaxCount), 221, 221, 221);
                                SolidColorBrush brush = new SolidColorBrush(clr);
                                view.ToastBackground.Background = brush;
                            }
                            {
                                Color clr = Color.FromArgb((byte)(255 * toastCount / toastMaxCount), 0, 0, 0);
                                SolidColorBrush brush = new SolidColorBrush(clr);
                                view.Toast.Foreground = brush;
                            }
                            if (toastCount == 0)
                            {
                                Toast = "";
                                toastTimer.Dispose();
                            }
                        });
                    }, null, 0, 100);
                }
            }
        }
    }
}
