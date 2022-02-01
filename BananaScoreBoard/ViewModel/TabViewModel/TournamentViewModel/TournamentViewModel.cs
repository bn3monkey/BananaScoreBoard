using BananaScoreBoard.Auxiliary;
using BananaScoreBoard.Model;
using BananaScoreBoard.View.TabView.TournamentView;
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
        TournamentView view;
        public TournamentViewModel(TournamentView view)
        {
            this.view = view;
            Repository.Instance.tournamentFrame.registerRefresher(() =>
            {
                view.Dispatcher.Invoke(() =>
                {
                    if (Repository.Instance.tournamentFrame.FrameName == Model.Type.TournamentFrame.Name.Tournament)
                    {
                        view.SwitchFrame(TournamentView.FrameName.Tournament);
                    }
                    else if (Repository.Instance.tournamentFrame.FrameName == Model.Type.TournamentFrame.Name.Roster)
                    {
                        view.SwitchFrame(TournamentView.FrameName.Roster);
                    }
                });
            });
        }

        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Update Button in Tournament Tab is pressed");
                    Task task = new Task(
                        () =>
                        {
                            Repository.Instance.UpdateTournament();
                            Repository.Instance.toast.SendMessage("Update Done");
                        }
                    );
                    task.Start();
                }));
            }
        }


        private ICommand resetCommand;
        public ICommand ResetCommand
        {
            get
            {
                return resetCommand ?? (resetCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Reset Button in Tournament Tab is pressed");
                    Task task = new Task(
                        () =>
                        {
                            Repository.Instance.ResetTournament();
                            Repository.Instance.Refresh();
                            Repository.Instance.toast.SendMessage("Reset Done");
                        }
                    );
                    task.Start();
                }));
            }
        }

        private ICommand rosterCommand;
        public ICommand RosterCommand
        {
            get
            {
                return rosterCommand ?? (rosterCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Roster Button in Tournament Tab is pressed");

                    if (Repository.Instance.tournamentFrame.FrameName == Model.Type.TournamentFrame.Name.Tournament)
                        Repository.Instance.tournamentFrame.FrameName = Model.Type.TournamentFrame.Name.Roster;
                    else if (Repository.Instance.tournamentFrame.FrameName == Model.Type.TournamentFrame.Name.Roster)
                        Repository.Instance.tournamentFrame.FrameName = Model.Type.TournamentFrame.Name.Tournament;
                    Repository.Instance.toast.SendMessage("Roster Done");
                }));
            }
        }
    }
}
