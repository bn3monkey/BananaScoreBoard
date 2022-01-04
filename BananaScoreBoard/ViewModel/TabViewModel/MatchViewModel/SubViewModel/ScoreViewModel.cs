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
            Repository.Instance.registerReferehser(refresh);
        }

        void refresh()
        {
            OnPropertyUpdate("Name1P");
            OnPropertyUpdate("Name2P");
            OnPropertyUpdate("Score1P");
            OnPropertyUpdate("Score2P");
        }

        private ICommand swapCommand;
        public ICommand SwapCommand
        {
            get
            {
                return swapCommand ?? (swapCommand = new DelegateCommand(Swap));
            }
        }

        void Swap()
        {
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
                    Repository.Instance.update();


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
            Score1P = 0;
            Score2P = 0;
            Repository.Instance.toast.SendMessage("Reset Done");
        }

        private ICommand score1PUpCommand;
        public ICommand Score1PUpCommand
        {
            get
            {
                return score1PUpCommand ?? (score1PUpCommand = new DelegateCommand(Score1PUp));
            }
        }
        void Score1PUp()
        {
            Score1P += 1;
        }

        private ICommand score1PDownCommand;
        public ICommand Score1PDownCommand
        {
            get
            {
                return score1PDownCommand ?? (score1PDownCommand = new DelegateCommand(Score1PDown));
            }
        }
        void Score1PDown()
        {
            Score1P -= 1;
        }

        private ICommand score1PResetCommand;
        public ICommand Score1PResetCommand
        {
            get
            {
                return score1PResetCommand ?? (score1PResetCommand = new DelegateCommand(Score1PReset));
            }
        }
        void Score1PReset()
        {
            Score1P = 0;
        }

        private ICommand score2PUpCommand;
        public ICommand Score2PUpCommand
        {
            get
            {
                return score2PUpCommand ?? (score2PUpCommand = new DelegateCommand(Score2PUp));
            }
        }
        void Score2PUp()
        {
            Score2P += 1;
        }

        private ICommand score2PDownCommand;
        public ICommand Score2PDownCommand
        {
            get
            {
                return score2PDownCommand ?? (score2PDownCommand = new DelegateCommand(Score2PDown));
            }
        }
        void Score2PDown()
        {
            Score2P -= 1;
        }

        private ICommand score2PResetCommand;
        public ICommand Score2PResetCommand
        {
            get
            {
                return score2PResetCommand ?? (score2PResetCommand = new DelegateCommand(Score2PReset));
            }
        }
        void Score2PReset()
        {
            Score2P = 0;
        }

        public string Name1P
        {
            get
            {
                return Repository.Instance.player1.name;
            }
            set
            {
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
                Repository.Instance.player2.score = value;
                OnPropertyUpdate("Score2P");
            }
        }

        
    }
}
