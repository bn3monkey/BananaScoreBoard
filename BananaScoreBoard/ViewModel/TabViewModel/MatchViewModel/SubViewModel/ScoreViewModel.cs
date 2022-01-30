using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.View.TabView.MatchView.SubView;

using BananaScoreBoard.Model;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Input;
using BananaScoreBoard.Auxiliary;

namespace BananaScoreBoard.ViewModel.TabViewModel.MatchViewModel.SubViewModel
{
    class ScoreViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public ScoreViewModel(ScoreView view)
        {

            /*
            BananaScoreBoard.Control.AutoComplete.GetItemSource suggestion = (string value) => {
                var list = Repository.Instance.listPlayer(value);

                if (list.Count == 1)
                {
                    if (value.CompareTo(list[0]) == 0)
                        return new List<string> { };
                }
                return list;
            };

            view.Name1P.GetSuggestion = suggestion;
            view.Name2P.GetSuggestion = suggestion;
            */
            
            Repository.Instance.player1.registerRefresher(() =>
            {
                OnPropertyUpdate("Name1P");
                OnPropertyUpdate("Score1P");

            });
            Repository.Instance.player2.registerRefresher(() =>
            {
                OnPropertyUpdate("Name2P");
                OnPropertyUpdate("Score2P");

            });
        }

        private ICommand swapCommand;
        public ICommand SwapCommand
        {
            get
            {
                return swapCommand ?? (swapCommand = new DelegateCommand(() => {

                    Log.Log.V(string.Format("Swap button is pressed | Name : {0} <-> {1}  Score {2} <-> {3}", Name1P, Name2P, Score1P, Score2P));

                    {
                        string temp;
                        temp = Name1P;
                        Name1P = Name2P;
                        Name2P = temp;
                    }
                    {
                        int temp;
                        temp = Score1P;
                        Score1P = Score2P;
                        Score2P = temp;
                    }

                    Repository.Instance.toast.SendMessage("Player 1 and Player 2 is changed");
                }));
            }
        }


        private ICommand updateCommand;
        public ICommand UpdateCommand
        {
            get
            {
                return updateCommand ?? (updateCommand = new DelegateCommand(()=>
                {
                    Log.Log.V(string.Format("Update button in Match Tap is pressed"));

                    Task task = new Task(
                   () =>
                   {
                       Repository.Instance.update();
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
                return resetCommand ?? (resetCommand = new DelegateCommand(() => {
                    Log.Log.V(string.Format("Reset Button in Match Tap is pressed"));
                    Score1P = 0;
                    Score2P = 0;
                    Repository.Instance.toast.SendMessage("Reset Done");
                }));
            }
        }

        private ICommand score1PUpCommand;
        public ICommand Score1PUpCommand
        {
            get
            {
                return score1PUpCommand ?? (score1PUpCommand = new DelegateCommand(() => {
                    Log.Log.V(string.Format("Score 1P UP Button in Match Tap is pressed"));
                    Score1P += 1;
                }));
            }
        }

        private ICommand score1PDownCommand;
        public ICommand Score1PDownCommand
        {
            get
            {
                return score1PDownCommand ?? (score1PDownCommand = new DelegateCommand(() => {
                    Log.Log.V(string.Format("Score 1P DOWN Button in Match Tap is pressed"));
                    Score1P -= 1;
                }));
            }
        }


        private ICommand score1PResetCommand;
        public ICommand Score1PResetCommand
        {
            get
            {
                return score1PResetCommand ?? (score1PResetCommand = new DelegateCommand(() => {
                    Log.Log.V(string.Format("Score 1P RESET Button in Match Tap is pressed"));
                    Score1P = 0;
                }));
            }
        }

        private ICommand score2PUpCommand;
        public ICommand Score2PUpCommand
        {
            get
            {
                return score2PUpCommand ?? (score2PUpCommand = new DelegateCommand(() => {
                    Log.Log.V(string.Format("Score 2P UP Button in Match Tap is pressed"));
                    Score2P += 1;
                }));
            }
        }

        private ICommand score2PDownCommand;
        public ICommand Score2PDownCommand
        {
            get
            {
                return score2PDownCommand ?? (score2PDownCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("Score 2P DOWN Button in Match Tap is pressed"));
                    Score2P -= 1;
                }));
            }
        }

        private ICommand score2PResetCommand;
        public ICommand Score2PResetCommand
        {
            get
            {
                return score2PResetCommand ?? (score2PResetCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("Score 2P RESET Button in Match Tap is pressed"));
                    Score2P = 0;
                }));
            }
        }

        public string Name1P
        {
            get
            {
                return Repository.Instance.player1.name;
            }
            set
            {
                Log.Log.V(string.Format("Change Name1P : {0} -> {1}", Repository.Instance.player1.name, value));
                Repository.Instance.player1.name = value;
                OnPropertyUpdate("Name1P");
            }
        }

        public string Name2P
        {
            get
            {
                return Repository.Instance.player2.name;
            }
            set
            {
                Log.Log.V(string.Format("Change Name2P : {0} -> {1}", Repository.Instance.player2.name, value));
                Repository.Instance.player2.name = value;
                OnPropertyUpdate("Name2P");
            }
        }

        public int Score1P
        {
            get
            {
                return Repository.Instance.player1.score;
            }
            set
            {
                Log.Log.V(string.Format("Change Score1P : {0} -> {1}", Repository.Instance.player1.score, value));
                Repository.Instance.player1.score = value;
                OnPropertyUpdate("Score1P");
            }
        }

        public int Score2P
        {
            get
            {
                return Repository.Instance.player2.score;
            }
            set
            {
                Log.Log.V(string.Format("Change Score2P : {0} -> {1}", Repository.Instance.player2.score, value));
                Repository.Instance.player2.score = value;
                OnPropertyUpdate("Score2P");
            }
        }

        
    }
}
