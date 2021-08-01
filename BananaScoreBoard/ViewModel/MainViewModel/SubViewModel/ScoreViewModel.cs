using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.View.MainView.SubView;

using BananaScoreBoard.Model;
using System.Windows;
using System.Collections.ObjectModel;

namespace BananaScoreBoard.ViewModel.MainViewModel.SubViewModel
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

        MainViewModel parent;
        public ScoreViewModel(MainViewModel parent, ScoreView view)
        {
            this.parent = parent;
            view.DataContext = this;
            view.Swap.Click += ClickSwap;
            view.Update.Click += ClickUpdate;
            view.Reset.Click += ClickReset;

            view.Score1pUp.Click += ClickScore1PUp;
            view.Score1pReset.Click += ClickScore1PReset;
            view.Score1pDown.Click += ClickScore1PDown;

            view.Score2pUp.Click += ClickScore2PUp;
            view.Score2pReset.Click += ClickScore2PReset;
            view.Score2pDown.Click += ClickScore2PDown;

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
        }


        void ClickSwap(object sender, RoutedEventArgs e)
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

            parent.toastVIewModel.Toast = "Player 1 and Player 2 is changed";
        }

        void ClickUpdate(object sender, RoutedEventArgs e)
        {
            Task task = new Task(
                () =>
                {
                    Repository.Instance.update();
                    

                    parent.toastVIewModel.Toast = "Update Done";
                }
                );
            task.Start();

        }

        void ClickReset(object sender, RoutedEventArgs e)
        {
            Score1P = 0;
            Score2P = 0;
            parent.toastVIewModel.Toast = "Reset Done";
        }

        void ClickScore1PUp(object sender, RoutedEventArgs e)
        {
            Score1P += 1;
        }
        void ClickScore1PDown(object sender, RoutedEventArgs e)
        {
            Score1P -= 1;
        }
        void ClickScore1PReset(object sender, RoutedEventArgs e)
        {
            Score1P = 0;
        }

        void ClickScore2PUp(object sender, RoutedEventArgs e)
        {
            Score2P += 1;
        }
        void ClickScore2PDown(object sender, RoutedEventArgs e)
        {
            Score2P -= 1;
        }
        void ClickScore2PReset(object sender, RoutedEventArgs e)
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
