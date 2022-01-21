using BananaScoreBoard.Auxiliary;
using BananaScoreBoard.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BananaScoreBoard.ViewModel.TabViewModel.TournamentViewModel
{
    class TournamentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new DelegateCommand(Update));
            }
        }
        void Update()
        {
            Task task = new Task(
                () =>
                {
                    Repository.Instance.UpdateTournament();
                    Repository.Instance.toast.SendMessage("Update Done");
                }
            );
            task.Start();
        }

        private ICommand resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return resetCommand ?? (resetCommand = new DelegateCommand(Reset));
            }
        }
        void Reset()
        {
            Task task = new Task(
                () =>
                {
                    Repository.Instance.ResetTournament();
                    Repository.Instance.Refresh();
                    Repository.Instance.toast.SendMessage("Reset Done");
                }
            );
            task.Start();
        }

        private ICommand rosterCommand;
        public ICommand RosterCommand
        {
            get
            {
                return rosterCommand ?? (rosterCommand = new DelegateCommand(Roster));
            }
        }
        void Roster()
        {
            Task task = new Task(
                () =>
                {
                    Repository.Instance.toast.SendMessage("Roster Done");
                });
            task.Start();
        }
    }
}
