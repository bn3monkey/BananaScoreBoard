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
    class RosterViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public RosterViewModel()
        {
            Repository.Instance.roster.registerRefresher(() =>
            {
                OnPropertyUpdate("Player0Name");
                OnPropertyUpdate("Player0MMR");
                OnPropertyUpdate("Player1Name");
                OnPropertyUpdate("Player1MMR");
                OnPropertyUpdate("Player2Name");
                OnPropertyUpdate("Player2MMR");
                OnPropertyUpdate("Player3Name");
                OnPropertyUpdate("Player3MMR");
                OnPropertyUpdate("Player4Name");
                OnPropertyUpdate("Player4MMR");
                OnPropertyUpdate("Player5Name");
                OnPropertyUpdate("Player5MMR");
                OnPropertyUpdate("Player6Name");
                OnPropertyUpdate("Player6MMR");
                OnPropertyUpdate("Player7Name");
                OnPropertyUpdate("Player7MMR");
            });
        }

        private ICommand readCommand;
        public ICommand ReadCommand
        {
            get
            {
                return readCommand ?? (readCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Read Button in Roster Tab is pressed");
                    Task task = new Task(() =>
                    {
                        Repository.Instance.ReadRoster();
                    });
                    task.Start();
                }));
            }
        }

        private ICommand randomOrderCommand;
        public ICommand RandomOrderCommand
        {
            get
            {
                return randomOrderCommand ?? (randomOrderCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Random Order Button in Roster Tab is pressed");
                    Task task = new Task(() =>
                    {
                        Repository.Instance.roster.OrderByRandom();
                        Repository.Instance.roster.Refresh();
                    });
                    task.Start();
                }));
            }
        }

        private ICommand mmrOrderCommand;
        public ICommand MMROrderCommand
        {
            get
            {
                return mmrOrderCommand ?? (mmrOrderCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("MMR Order Button in Roster Tab is pressed");
                    Task task = new Task(() =>
                    {
                        Repository.Instance.roster.OrderByMMR();
                        Repository.Instance.roster.Refresh();
                    });
                    task.Start();
                }));
            }
        }

        private ICommand commitCommand;
        public ICommand CommitCommand
        {
            get
            {
                return commitCommand ?? (commitCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Commit Button in Roster Tab is pressed");
                    Task task = new Task(() =>
                    {
                        Repository.Instance.CommitRoster();
                        Repository.Instance.tournamentFrame.FrameName = Model.Type.TournamentFrame.Name.Tournament;
                        Repository.Instance.Refresh();
                    });
                    task.Start();
                }));
            }
        }


        public string Notice
        {
            get
            {
                return "Please make 'roaster.txt' in above folder path.\n" +
                       "Enter player name and MMR on multiple lines\n" +
                       "as in the example below.\n\n" +
                       "Ex)\n" +
                       "SANS 1230\nPAPYRUS 320\nUNDYNE 400\nMETATON 380\nALPHYS 220\nASGORE 1080\nTORIEL 970\nPPAP 330\n\n" +
                       "And Press 'Read' Button\n";
            }
        }



        public string Player0Name
        {
            get
            {
                return Repository.Instance.roster.players[0].name;
            }
            set
            {
                Repository.Instance.roster.players[0].name = value;
                OnPropertyUpdate("Player0Name");
            }
        }

        public int Player0MMR
        {
            get
            {
                return Repository.Instance.roster.players[0].mmr;
            }
            set
            {
                Repository.Instance.roster.players[0].mmr = value;
                OnPropertyUpdate("Player0MMR");
            }
        }

        public string Player1Name
        {
            get
            {
                return Repository.Instance.roster.players[1].name;
            }
            set
            {
                Repository.Instance.roster.players[1].name = value;
                OnPropertyUpdate("Player1Name");
            }
        }

        public int Player1MMR
        {
            get
            {
                return Repository.Instance.roster.players[1].mmr;
            }
            set
            {
                Repository.Instance.roster.players[1].mmr = value;
                OnPropertyUpdate("Player1MMR");
            }
        }

        public string Player2Name
        {
            get
            {
                return Repository.Instance.roster.players[2].name;
            }
            set
            {
                Repository.Instance.roster.players[2].name = value;
                OnPropertyUpdate("Player2Name");
            }
        }

        public int Player2MMR
        {
            get
            {
                return Repository.Instance.roster.players[2].mmr;
            }
            set
            {
                Repository.Instance.roster.players[2].mmr = value;
                OnPropertyUpdate("Player2MMR");
            }
        }

        public string Player3Name
        {
            get
            {
                return Repository.Instance.roster.players[3].name;
            }
            set
            {
                Repository.Instance.roster.players[3].name = value;
                OnPropertyUpdate("Player3Name");
            }
        }

        public int Player3MMR
        {
            get
            {
                return Repository.Instance.roster.players[3].mmr;
            }
            set
            {
                Repository.Instance.roster.players[3].mmr = value;
                OnPropertyUpdate("Player3MMR");
            }
        }

        public string Player4Name
        {
            get
            {
                return Repository.Instance.roster.players[4].name;
            }
            set
            {
                Repository.Instance.roster.players[4].name = value;
                OnPropertyUpdate("Player4Name");
            }
        }

        public int Player4MMR
        {
            get
            {
                return Repository.Instance.roster.players[4].mmr;
            }
            set
            {
                Repository.Instance.roster.players[4].mmr = value;
                OnPropertyUpdate("Player4MMR");
            }
        }
        public string Player5Name
        {
            get
            {
                return Repository.Instance.roster.players[5].name;
            }
            set
            {
                Repository.Instance.roster.players[5].name = value;
                OnPropertyUpdate("Player5Name");
            }
        }

        public int Player5MMR
        {
            get
            {
                return Repository.Instance.roster.players[5].mmr;
            }
            set
            {
                Repository.Instance.roster.players[5].mmr = value;
                OnPropertyUpdate("Player5MMR");
            }
        }

        public string Player6Name
        {
            get
            {
                return Repository.Instance.roster.players[6].name;
            }
            set
            {
                Repository.Instance.roster.players[6].name = value;
                OnPropertyUpdate("Player6Name");
            }
        }

        public int Player6MMR
        {
            get
            {
                return Repository.Instance.roster.players[6].mmr;
            }
            set
            {
                Repository.Instance.roster.players[6].mmr = value;
                OnPropertyUpdate("Player6MMR");
            }
        }

        public string Player7Name
        {
            get
            {
                return Repository.Instance.roster.players[7].name;
            }
            set
            {
                Repository.Instance.roster.players[7].name = value;
                OnPropertyUpdate("Player7Name");
            }
        }

        public int Player7MMR
        {
            get
            {
                return Repository.Instance.roster.players[7].mmr;
            }
            set
            {
                Repository.Instance.roster.players[7].mmr = value;
                OnPropertyUpdate("Player7MMR");
            }
        }
    }
}
