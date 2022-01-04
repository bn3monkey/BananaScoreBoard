using BananaScoreBoard.View.FolderPathView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BananaScoreBoard.Model;
using System.Windows;
using System.Windows.Input;
using BananaScoreBoard.Auxiliary;

namespace BananaScoreBoard.ViewModel.FolderPathViewModel
{
    class FolderPathViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public FolderPathViewModel(FolderPathView view)
        {
            Repository.Instance.record.loadPath();
        }


        private ICommand findFolderPathCommand;
        public ICommand FindFolderPathCommand
        {
            get
            {
                return this.findFolderPathCommand ?? (this.findFolderPathCommand = new DelegateCommand(FindFolderPath));
            }
        }

        private ICommand readFolderPathCommand;
        public ICommand ReadFolderPathCommand
        {
            get
            {
                return this.readFolderPathCommand ?? (this.readFolderPathCommand = new DelegateCommand(ReadFolderPath));
            }
        }


        void FindFolderPath()
        {
            FolderPath = Repository.Instance.record.FindPath();
            Repository.Instance.record.savePath();
        }

        void ReadFolderPath()
        {
            Repository.Instance.record.InitializePath();
            Repository.Instance.load();
            Repository.Instance.refresh();
            
        }

        public string FolderPath
        {
            get
            {
                return Repository.Instance.record.folder_path;
            }
            set
            {
                Repository.Instance.record.folder_path = value;
                OnPropertyUpdate("FolderPath");
            }
        }
    }
}
