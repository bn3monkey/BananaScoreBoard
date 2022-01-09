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
                    // Repository.Instance.updateTournament();
                    Repository.Instance.toast.SendMessage("Update Done");
                }
            );
            task.Start();

        }
    }
}
