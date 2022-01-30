using BananaScoreBoard.Auxiliary;
using BananaScoreBoard.Model;
using BananaScoreBoard.View.TabView.InfoView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BananaScoreBoard.ViewModel.TabViewModel.InfoViewModel
{
    class InfoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        private InfoView view;
        public InfoViewModel(InfoView view)
        {
            this.view = view;
        }

        public string SoftwareVersion
        {
            get
            {
                return Version.get();
            }
        }

        private ICommand logCommand = null;
        public ICommand LogCommand
        {
            get
            {
                return logCommand = logCommand ?? (logCommand = new DelegateCommand(() =>
                {
                    string dateTime = System.DateTime.Now.ToString("yyyyMMdd HH-mm-ss");
                    string logfile = string.Format("LOG_{0}.txt", dateTime);

                    if (Log.Log.ExportLog(logfile))
                    {
                        Repository.Instance.toast.SendMessage(String.Format("Log file is exported : {0}", logfile));
                    }
                    else
                    {
                        Repository.Instance.toast.SendMessage("Log file cannot be exported");
                    }
                }));
            }
        }
    }
}
