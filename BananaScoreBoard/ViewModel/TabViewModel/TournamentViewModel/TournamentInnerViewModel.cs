using BananaScoreBoard.Auxiliary;
using BananaScoreBoard.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace BananaScoreBoard.ViewModel.TabViewModel.TournamentViewModel
{
    class TournamentInnerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public TournamentInnerViewModel()
        {
            Repository.Instance.winnerMatch1_1.SetNextMatch(Repository.Instance.winnerMatch2_1, 1, Repository.Instance.loserMatch1_1, 1);
            Repository.Instance.winnerMatch1_2.SetNextMatch(Repository.Instance.winnerMatch2_1, 2, Repository.Instance.loserMatch1_1, 2);
            Repository.Instance.winnerMatch1_3.SetNextMatch(Repository.Instance.winnerMatch2_2, 1, Repository.Instance.loserMatch1_2, 1);
            Repository.Instance.winnerMatch1_4.SetNextMatch(Repository.Instance.winnerMatch2_2, 2, Repository.Instance.loserMatch1_2, 2);

            Repository.Instance.winnerMatch2_1.SetNextMatch(Repository.Instance.winnerMatch3_1, 1, Repository.Instance.loserMatch2_1, 1);
            Repository.Instance.winnerMatch2_2.SetNextMatch(Repository.Instance.winnerMatch3_1, 2, Repository.Instance.loserMatch2_2, 1);

            Repository.Instance.winnerMatch3_1.SetNextMatch(Repository.Instance.winnerMatch4_1, 1, Repository.Instance.loserMatch4_1, 2);
            Repository.Instance.winnerMatch4_1.SetNextMatch(Repository.Instance.winnerMatch5_1, 1, Repository.Instance.winnerMatch5_1, 2);
            Repository.Instance.winnerMatch5_1.SetNextMatch(null, 0, null, 0);


            Repository.Instance.loserMatch1_1.SetNextMatch(Repository.Instance.loserMatch2_1, 2, null, 0);
            Repository.Instance.loserMatch1_2.SetNextMatch(Repository.Instance.loserMatch2_2, 2, null, 0);

            Repository.Instance.loserMatch2_1.SetNextMatch(Repository.Instance.loserMatch3_1, 1, null, 0);
            Repository.Instance.loserMatch2_2.SetNextMatch(Repository.Instance.loserMatch3_1, 2, null, 0);

            Repository.Instance.loserMatch3_1.SetNextMatch(Repository.Instance.loserMatch4_1, 1, null, 0);
           
            Repository.Instance.loserMatch4_1.SetNextMatch(Repository.Instance.winnerMatch4_1, 2, null, 0);

            Repository.Instance.winnerMatch1_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W1_1_P1");
                OnPropertyUpdate("W1_1_P2");
                OnPropertyUpdate("W1_1_P1_Score");
                OnPropertyUpdate("W1_1_P2_Score");
            });
            Repository.Instance.winnerMatch1_2.registerRefresher(() =>
            {
                OnPropertyUpdate("W1_2_P1");
                OnPropertyUpdate("W1_2_P2");
                OnPropertyUpdate("W1_2_P1_Score");
                OnPropertyUpdate("W1_2_P2_Score");
            });
            Repository.Instance.winnerMatch1_3.registerRefresher(() =>
            {
                OnPropertyUpdate("W1_3_P1");
                OnPropertyUpdate("W1_3_P2");
                OnPropertyUpdate("W1_3_P1_Score");
                OnPropertyUpdate("W1_3_P2_Score");
            });
            Repository.Instance.winnerMatch1_4.registerRefresher(() =>
            {
                OnPropertyUpdate("W1_4_P1");
                OnPropertyUpdate("W1_4_P2");
                OnPropertyUpdate("W1_4_P1_Score");
                OnPropertyUpdate("W1_4_P2_Score");
            });
            Repository.Instance.winnerMatch2_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W2_1_P1");
                OnPropertyUpdate("W2_1_P2");
                OnPropertyUpdate("W2_1_P1_Score");
                OnPropertyUpdate("W2_1_P2_Score");
            });
            Repository.Instance.winnerMatch2_2.registerRefresher(() =>
            {
                OnPropertyUpdate("W2_2_P1");
                OnPropertyUpdate("W2_2_P2");
                OnPropertyUpdate("W2_2_P1_Score");
                OnPropertyUpdate("W2_2_P2_Score");
            });
            Repository.Instance.winnerMatch3_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W3_1_P1");
                OnPropertyUpdate("W3_1_P2");
                OnPropertyUpdate("W3_1_P1_Score");
                OnPropertyUpdate("W3_1_P2_Score");
            });
            Repository.Instance.winnerMatch4_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W4_1_P1");
                OnPropertyUpdate("W4_1_P2");
                OnPropertyUpdate("W4_1_P1_Score");
                OnPropertyUpdate("W4_1_P2_Score");
            });

            Repository.Instance.winnerMatch5_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W5_1_P1");
                OnPropertyUpdate("W5_1_P2");
                OnPropertyUpdate("W5_1_P1_Score");
                OnPropertyUpdate("W5_1_P2_Score");
            });

            Repository.Instance.loserMatch1_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L1_1_P1");
                OnPropertyUpdate("L1_1_P2");
                OnPropertyUpdate("L1_1_P1_Score");
                OnPropertyUpdate("L1_1_P2_Score");
            });
            Repository.Instance.loserMatch1_2.registerRefresher(() =>
            {
                OnPropertyUpdate("L1_2_P1");
                OnPropertyUpdate("L1_2_P2");
                OnPropertyUpdate("L1_2_P1_Score");
                OnPropertyUpdate("L1_2_P2_Score");
            });

            Repository.Instance.loserMatch2_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L2_1_P1");
                OnPropertyUpdate("L2_1_P2");
                OnPropertyUpdate("L2_1_P1_Score");
                OnPropertyUpdate("L2_1_P2_Score");
            });
            Repository.Instance.loserMatch2_2.registerRefresher(() =>
            {
                OnPropertyUpdate("L2_2_P1");
                OnPropertyUpdate("L2_2_P2");
                OnPropertyUpdate("L2_2_P1_Score");
                OnPropertyUpdate("L2_2_P2_Score");
            });

            Repository.Instance.loserMatch3_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L3_1_P1");
                OnPropertyUpdate("L3_1_P2");
                OnPropertyUpdate("L3_1_P1_Score");
                OnPropertyUpdate("L3_1_P2_Score");
            });


            Repository.Instance.loserMatch4_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L4_1_P1");
                OnPropertyUpdate("L4_1_P2");
                OnPropertyUpdate("L4_1_P1_Score");
                OnPropertyUpdate("L4_1_P2_Score");
            });
        }


        bool isExchanged = false;
        private ICommand exchangeCommand;
        public ICommand ExchangeCommand
        {
            get
            {
                return exchangeCommand ?? (exchangeCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Exchange Button is pressed");

                    if (isExchanged)
                    {
                        Repository.Instance.winnerMatch2_1.SetNextLoserMatch(Repository.Instance.loserMatch2_1, 1);
                        Repository.Instance.winnerMatch2_2.SetNextLoserMatch(Repository.Instance.loserMatch2_2, 1);
                    }
                    else
                    {
                        Repository.Instance.winnerMatch2_1.SetNextLoserMatch(Repository.Instance.loserMatch2_2, 1);
                        Repository.Instance.winnerMatch2_2.SetNextLoserMatch(Repository.Instance.loserMatch2_1, 1);
                    }
                    isExchanged = !isExchanged;

                    Repository.Instance.loserMatch2_1.Refresh();
                    Repository.Instance.loserMatch2_2.Refresh();
                }));
            }
        }

        private Visibility isRematchNeeded = Visibility.Hidden;
        public Visibility IsRematchNeeded
        {
            get
            {
                return isRematchNeeded;
            }
            set
            {
                isRematchNeeded = value;
                OnPropertyUpdate("IsRematchNeeded");
            }
        }

        #region Winner
        #region W1_1
        public string W1_1_P1
        {
            get
            {
                return Repository.Instance.winnerMatch1_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 1, 1, 
                    Repository.Instance.winnerMatch1_1.Player1, value));
                Repository.Instance.winnerMatch1_1.Player1 = value;
                OnPropertyUpdate("W1_1_P1");
            }
        }
        public string W1_1_P2
        {
            get
            {
                return Repository.Instance.winnerMatch1_1.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 1, 2,
                    Repository.Instance.winnerMatch1_1.Player2, value));
                Repository.Instance.winnerMatch1_1.Player2 = value;
                OnPropertyUpdate("W1_1_P2");
            }
        }

        public int W1_1_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 1, 1,
                    Repository.Instance.winnerMatch1_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_1))
                {
                    Repository.Instance.winnerMatch1_1.player1_score = value;
                }
                Repository.Instance.winnerMatch1_1.RefreshRecursive();
            }
        }
        public int W1_1_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 1, 2,
                    Repository.Instance.winnerMatch1_1.player2_score, value));


                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_1))
                {
                    Repository.Instance.winnerMatch1_1.player2_score = value;
                }

                Repository.Instance.winnerMatch1_1.RefreshRecursive();
            }
        }

        #endregion

        #region W1_2
        public string W1_2_P1
        {
            get
            {
                return Repository.Instance.winnerMatch1_2.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 2, 1,
                   Repository.Instance.winnerMatch1_2.Player1, value));
                Repository.Instance.winnerMatch1_2.Player1 = value;
                OnPropertyUpdate("W1_2_P1");
            }
        }
        public string W1_2_P2
        {
            get
            {
                return Repository.Instance.winnerMatch1_2.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 2, 2,
                   Repository.Instance.winnerMatch1_2.Player2, value));
                Repository.Instance.winnerMatch1_2.Player2 = value;
                OnPropertyUpdate("W1_2_P2");
            }
        }

        public int W1_2_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_2.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 2, 1,
                    Repository.Instance.winnerMatch1_2.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_2))
                {
                    Repository.Instance.winnerMatch1_2.player1_score = value;
                }
                Repository.Instance.winnerMatch1_2.RefreshRecursive();
            }
        }
        public int W1_2_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_2.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 2, 2,
                    Repository.Instance.winnerMatch1_2.player2_score, value));


                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_2))
                {
                    Repository.Instance.winnerMatch1_2.player2_score = value;
                }

                Repository.Instance.winnerMatch1_2.RefreshRecursive();
            }
        }
        #endregion

        #region W1_3
        public string W1_3_P1
        {
            get
            {
                return Repository.Instance.winnerMatch1_3.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 3, 1,
                   Repository.Instance.winnerMatch1_3.Player1, value));
                Repository.Instance.winnerMatch1_3.Player1 = value;
                OnPropertyUpdate("W1_3_P1");
            }
        }
        public string W1_3_P2
        {
            get
            {
                return Repository.Instance.winnerMatch1_3.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 3, 2,
                   Repository.Instance.winnerMatch1_3.Player2, value));
                Repository.Instance.winnerMatch1_3.Player2 = value;
                OnPropertyUpdate("W1_3_P2");
            }
        }

        public int W1_3_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_3.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 3, 1,
                    Repository.Instance.winnerMatch1_3.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_3))
                {
                    Repository.Instance.winnerMatch1_3.player1_score = value;
                }

                Repository.Instance.winnerMatch1_3.RefreshRecursive();
            }
        }
        public int W1_3_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_3.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 3, 2,
                    Repository.Instance.winnerMatch1_3.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_3))
                {
                    Repository.Instance.winnerMatch1_3.player2_score = value;
                }

                Repository.Instance.winnerMatch1_3.RefreshRecursive();
            }
        }
        #endregion

        #region W1_4
        public string W1_4_P1
        {
            get
            {
                return Repository.Instance.winnerMatch1_4.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 4, 1,
                   Repository.Instance.winnerMatch1_4.Player1, value));

                Repository.Instance.winnerMatch1_4.Player1 = value;
                OnPropertyUpdate("W1_4_P1");
            }
        }
        public string W1_4_P2
        {
            get
            {
                return Repository.Instance.winnerMatch1_4.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 4, 2,
                   Repository.Instance.winnerMatch1_4.Player2, value));


                Repository.Instance.winnerMatch1_4.Player2 = value;
                OnPropertyUpdate("W1_4_P2");
            }
        }

        public int W1_4_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_4.player1_score;
            }
            set
            {
     
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 4, 1,
                    Repository.Instance.winnerMatch1_4.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_4))
                {
                    Repository.Instance.winnerMatch1_4.player1_score = value;
                }
                Repository.Instance.winnerMatch1_4.RefreshRecursive();
            }
        }
        public int W1_4_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch1_4.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 4, 2,
                    Repository.Instance.winnerMatch1_4.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch1_4))
                {
                    Repository.Instance.winnerMatch1_4.player2_score = value;
                }
                Repository.Instance.winnerMatch1_4.RefreshRecursive();
            }
        }
        #endregion

        #region W2_1
        public string W2_1_P1
        {
            get
            {
                return Repository.Instance.winnerMatch2_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 1, 1,
                   Repository.Instance.winnerMatch2_1.Player1, value));
                Repository.Instance.winnerMatch2_1.Player1 = value;
                OnPropertyUpdate("W2_1_P1");
            }
        }
        public string W2_1_P2
        {
            get
            {
                return Repository.Instance.winnerMatch2_1.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 1, 2,
                   Repository.Instance.winnerMatch2_1.Player2, value));
                Repository.Instance.winnerMatch2_1.Player2 = value;
                OnPropertyUpdate("W2_1_P2");
            }
        }

        public int W2_1_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch2_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 1, 1,
                    Repository.Instance.winnerMatch2_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch2_1))
                {
                    Repository.Instance.winnerMatch2_1.player1_score = value;
                }

                Repository.Instance.winnerMatch2_1.RefreshRecursive();
            }
        }
        public int W2_1_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch2_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 1, 2,
                    Repository.Instance.winnerMatch2_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch2_1))
                {
                    Repository.Instance.winnerMatch2_1.player2_score = value;
                }
                Repository.Instance.winnerMatch2_1.RefreshRecursive();
            }
        }
        #endregion

        #region W2_2
        public string W2_2_P1
        {
            get
            {
                return Repository.Instance.winnerMatch2_2.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 2, 1,
                   Repository.Instance.winnerMatch2_2.Player1, value));

                Repository.Instance.winnerMatch2_2.Player1 = value;
                OnPropertyUpdate("W2_2_P1");
            }
        }
        public string W2_2_P2
        {
            get
            {
                return Repository.Instance.winnerMatch2_2.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 2, 2,
                   Repository.Instance.winnerMatch2_2.Player2, value));
                Repository.Instance.winnerMatch2_2.Player2 = value;
                OnPropertyUpdate("W2_2_P2");
            }
        }
        public int W2_2_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch2_2.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 2, 1,
                    Repository.Instance.winnerMatch2_2.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch2_2))
                {
                    Repository.Instance.winnerMatch2_2.player1_score = value;
                }
                Repository.Instance.winnerMatch2_2.RefreshRecursive();
            }
        }
        public int W2_2_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch2_2.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 2, 2,
                    Repository.Instance.winnerMatch2_2.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch2_2))
                {
                    Repository.Instance.winnerMatch2_2.player2_score = value;
                }
                Repository.Instance.winnerMatch2_2.RefreshRecursive();
            }
        }
        #endregion

        #region W3_1
        public string W3_1_P1
        {
            get
            {
                return Repository.Instance.winnerMatch3_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   3, 1, 1,
                   Repository.Instance.winnerMatch3_1.Player1, value));

                Repository.Instance.winnerMatch3_1.Player1 = value;
                OnPropertyUpdate("W3_1_P1");
            }
        }
        public string W3_1_P2
        {
            get
            {
                return Repository.Instance.winnerMatch3_1.Player2;
            }
            set
            {

                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                                   3, 1, 2,
                                   Repository.Instance.winnerMatch3_1.Player2, value));
                Repository.Instance.winnerMatch3_1.Player2 = value;
                OnPropertyUpdate("W3_1_P2");
            }
        }

        public int W3_1_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch3_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    3, 1, 1,
                    Repository.Instance.winnerMatch3_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch3_1))
                {
                    Repository.Instance.winnerMatch3_1.player1_score = value;
                }
                Repository.Instance.winnerMatch3_1.RefreshRecursive();
            }
        }
        public int W3_1_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch3_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    3, 1, 2,
                    Repository.Instance.winnerMatch3_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch3_1))
                {
                    Repository.Instance.winnerMatch3_1.player2_score = value;
                }
                Repository.Instance.winnerMatch3_1.RefreshRecursive();
            }
        }
        #endregion

        #region W4_1
        public string W4_1_P1
        {
            get
            {
                return Repository.Instance.winnerMatch4_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   4, 1, 1,
                   Repository.Instance.winnerMatch4_1.Player1, value));
                Repository.Instance.winnerMatch4_1.Player1 = value;
                OnPropertyUpdate("W4_1_P1");
            }
        }
        public string W4_1_P2
        {
            get
            {
                return Repository.Instance.winnerMatch4_1.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   4, 1, 2,
                   Repository.Instance.winnerMatch4_1.Player2, value));
                Repository.Instance.winnerMatch4_1.Player2 = value;
                OnPropertyUpdate("W4_1_P2");
            }
        }

        private void DetermineRematch()
        {
            if (Repository.Instance.winnerMatch4_1.player1_score > Repository.Instance.winnerMatch4_1.player2_score)
            {
                Repository.Instance.toast.SendMessage("Final Winner is {0}", Repository.Instance.winnerMatch4_1.Player1);
                IsRematchNeeded = Visibility.Hidden;
            }
            else if(Repository.Instance.winnerMatch4_1.player1_score < Repository.Instance.winnerMatch4_1.player2_score)
            {
                Repository.Instance.toast.SendMessage("Rematch is Needed", Repository.Instance.winnerMatch4_1.Player1);
                IsRematchNeeded = Visibility.Visible;
            }
        }
        public int W4_1_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch4_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    4, 1, 1,
                    Repository.Instance.winnerMatch4_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch4_1))
                {
                    Repository.Instance.winnerMatch4_1.player1_score = value;
                    DetermineRematch();
                }
                Repository.Instance.winnerMatch4_1.RefreshRecursive();
            }
        }
        public int W4_1_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch4_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    4, 1, 2,
                    Repository.Instance.winnerMatch4_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch4_1))
                {
                    Repository.Instance.winnerMatch4_1.player2_score = value;
                    DetermineRematch();
                }
                Repository.Instance.winnerMatch4_1.RefreshRecursive();
            }
        }
        #endregion

        #region W5_1
        public string W5_1_P1
        {
            get
            {
                return Repository.Instance.winnerMatch5_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   5, 1, 1,
                   Repository.Instance.winnerMatch5_1.Player1, value));
                Repository.Instance.winnerMatch5_1.Player1 = value;
                OnPropertyUpdate("W5_1_P1");
            }
        }
        public string W5_1_P2
        {
            get
            {
                return Repository.Instance.winnerMatch5_1.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   5, 1, 2,
                   Repository.Instance.winnerMatch5_1.Player2, value));
                Repository.Instance.winnerMatch5_1.Player2 = value;
                OnPropertyUpdate("W5_1_P2");
            }
        }

        public int W5_1_P1_Score
        {
            get
            {
                return Repository.Instance.winnerMatch5_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    5, 1, 1,
                    Repository.Instance.winnerMatch5_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch5_1))
                {
                    Repository.Instance.winnerMatch5_1.player1_score = value;
                }
                Repository.Instance.winnerMatch5_1.RefreshRecursive();
            }
        }
        public int W5_1_P2_Score
        {
            get
            {
                return Repository.Instance.winnerMatch5_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    5, 1, 2,
                    Repository.Instance.winnerMatch5_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.winnerMatch5_1))
                {
                    Repository.Instance.winnerMatch5_1.player2_score = value;
                }
                Repository.Instance.winnerMatch5_1.RefreshRecursive();
            }
        }
        #endregion

        #endregion

        #region Loser
        #region L1_1
        public string L1_1_P1
        {
            get
            {
                return Repository.Instance.loserMatch1_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 1, 1,
                   Repository.Instance.loserMatch1_1.Player1, value));
                Repository.Instance.loserMatch1_1.Player1 = value;
                OnPropertyUpdate("L1_1_P1");
            }
        }
        public string L1_1_P2
        {
            get
            {
                return Repository.Instance.loserMatch1_1.Player2;
            }
            set
            {

                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                                   1, 1, 2,
                                   Repository.Instance.loserMatch1_1.Player2, value));
                Repository.Instance.loserMatch1_1.Player2 = value;
                OnPropertyUpdate("L1_1_P2");
            }
        }

        public int L1_1_P1_Score
        {
            get
            {
                return Repository.Instance.loserMatch1_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 1, 1,
                    Repository.Instance.loserMatch1_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch1_1))
                {
                    Repository.Instance.loserMatch1_1.player1_score = value;
                }
                Repository.Instance.loserMatch1_1.RefreshRecursive();
            }
        }
        public int L1_1_P2_Score
        {
            get
            {
                return Repository.Instance.loserMatch1_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 1, 2,
                    Repository.Instance.loserMatch1_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch1_1))
                {
                    Repository.Instance.loserMatch1_1.player2_score = value;
                }
                Repository.Instance.loserMatch1_1.RefreshRecursive();
            }
        }
        #endregion

        #region L1_2
        public string L1_2_P1
        {
            get
            {
                return Repository.Instance.loserMatch1_2.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 2, 1,
                   Repository.Instance.loserMatch1_2.Player1, value));

                Repository.Instance.loserMatch1_2.Player1 = value;
                OnPropertyUpdate("W1_2_P1");
            }
        }
        public string L1_2_P2
        {
            get
            {
                return Repository.Instance.loserMatch1_2.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   1, 2, 2,
                   Repository.Instance.loserMatch1_2.Player2, value));


                Repository.Instance.loserMatch1_2.Player2 = value;
                OnPropertyUpdate("L1_2_P2");
            }
        }


        public int L1_2_P1_Score
        {
            get
            {
                return Repository.Instance.loserMatch1_2.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 2, 1,
                    Repository.Instance.loserMatch1_2.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch1_2))
                {
                    Repository.Instance.loserMatch1_2.player1_score = value;
                }
                Repository.Instance.loserMatch1_2.RefreshRecursive();
            }
        }
        public int L1_2_P2_Score
        {
            get
            {
                return Repository.Instance.loserMatch1_2.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    1, 2, 2,
                    Repository.Instance.loserMatch1_2.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch1_2))
                {
                    Repository.Instance.loserMatch1_2.player2_score = value;
                }
                Repository.Instance.loserMatch1_2.RefreshRecursive();
            }
        }
        #endregion

        #region L2_1
        public string L2_1_P1
        {
            get
            {
                return Repository.Instance.loserMatch2_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 1, 1,
                   Repository.Instance.loserMatch2_1.Player1, value));

                Repository.Instance.loserMatch2_1.Player1 = value;
                OnPropertyUpdate("L2_1_P1");
            }
        }
        public string L2_1_P2
        {
            get
            {
                return Repository.Instance.loserMatch2_1.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 1, 2,
                   Repository.Instance.loserMatch2_1.Player2, value));

                Repository.Instance.loserMatch2_1.Player2 = value;
                OnPropertyUpdate("L2_1_P2");
            }
        }

        public int L2_1_P1_Score
        {
            get
            {
                return Repository.Instance.loserMatch2_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 1, 1,
                    Repository.Instance.loserMatch2_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch2_1))
                {
                    Repository.Instance.loserMatch2_1.player1_score = value;
                }
                Repository.Instance.loserMatch2_1.RefreshRecursive();
            }
        }
        public int L2_1_P2_Score
        {
            get
            {
                return Repository.Instance.loserMatch2_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 1, 2,
                    Repository.Instance.loserMatch2_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch2_1))
                {
                    Repository.Instance.loserMatch2_1.player2_score = value;
                }
                Repository.Instance.loserMatch2_1.RefreshRecursive();
            }
        }
        #endregion

        #region L2_2
        public string L2_2_P1
        {
            get
            {
                return Repository.Instance.loserMatch2_2.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 2, 1,
                   Repository.Instance.loserMatch2_2.Player1, value));

                Repository.Instance.loserMatch2_2.Player1 = value;
                OnPropertyUpdate("L2_2_P1");
            }
        }
        public string L2_2_P2
        {
            get
            {
                return Repository.Instance.loserMatch2_2.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   2, 2, 2,
                   Repository.Instance.loserMatch2_2.Player2, value));


                Repository.Instance.loserMatch2_2.Player2 = value;
                OnPropertyUpdate("L2_2_P2");
            }
        }

        public int L2_2_P1_Score
        {
            get
            {
                return Repository.Instance.loserMatch2_2.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 2, 1,
                    Repository.Instance.loserMatch2_2.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch2_2))
                {
                    Repository.Instance.loserMatch2_2.player1_score = value;
                }
                Repository.Instance.loserMatch2_2.RefreshRecursive();
            }
        }
        public int L2_2_P2_Score
        {
            get
            {
                return Repository.Instance.loserMatch2_2.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    2, 2, 2,
                    Repository.Instance.loserMatch2_2.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch2_2))
                {
                    Repository.Instance.loserMatch2_2.player2_score = value;
                }
                Repository.Instance.loserMatch2_2.RefreshRecursive();
            }
        }
        #endregion

        #region L3_1
        public string L3_1_P1
        {
            get
            {
                return Repository.Instance.loserMatch3_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   3, 1, 1,
                   Repository.Instance.loserMatch3_1.Player1, value));

                Repository.Instance.loserMatch3_1.Player1 = value;
                OnPropertyUpdate("L3_1_P1");
            }
        }
        public string L3_1_P2
        {
            get
            {
                return Repository.Instance.loserMatch3_1.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   3, 1, 2,
                   Repository.Instance.loserMatch3_1.Player2, value));
                Repository.Instance.loserMatch3_1.Player2 = value;
                OnPropertyUpdate("L3_1_P2");
            }
        }
        public int L3_1_P1_Score
        {
            get
            {
                return Repository.Instance.loserMatch3_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    3, 1, 1,
                    Repository.Instance.loserMatch3_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch3_1))
                {
                    Repository.Instance.loserMatch3_1.player1_score = value;
                }
                Repository.Instance.loserMatch3_1.RefreshRecursive();
            }
        }
        public int L3_1_P2_Score
        {
            get
            {
                return Repository.Instance.loserMatch3_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    3, 1, 2,
                    Repository.Instance.loserMatch3_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch3_1))
                {
                    Repository.Instance.loserMatch3_1.player2_score = value;
                }
                Repository.Instance.loserMatch3_1.RefreshRecursive();
            }
        }
        #endregion

        #region L4_1
        public string L4_1_P1
        {
            get
            {
                return Repository.Instance.loserMatch4_1.Player1;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                   4, 1, 1,
                   Repository.Instance.loserMatch4_1.Player1, value));
                Repository.Instance.loserMatch4_1.Player1 = value;
                OnPropertyUpdate("L4_1_P1");
            }
        }
        public string L4_1_P2
        {
            get
            {
                return Repository.Instance.loserMatch4_1.Player2;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    4, 1, 2,
                    Repository.Instance.loserMatch4_1.Player2, value));
                Repository.Instance.loserMatch4_1.Player2 = value;
                OnPropertyUpdate("L4_1_P2");
            }
        }
        public int L4_1_P1_Score
        {
            get
            {
                return Repository.Instance.loserMatch4_1.player1_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    4, 1, 1,
                    Repository.Instance.loserMatch4_1.player1_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch4_1))
                {
                    Repository.Instance.loserMatch4_1.player1_score = value;
                }
                Repository.Instance.loserMatch4_1.RefreshRecursive();
            }
        }
        public int L4_1_P2_Score
        {
            get
            {
                return Repository.Instance.loserMatch4_1.player2_score;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Player{2} : {3} -> {4}",
                    4, 1, 2,
                    Repository.Instance.loserMatch4_1.player2_score, value));

                if (Repository.Instance.CheckWinnerDeterminable(Repository.Instance.loserMatch4_1))
                {
                    Repository.Instance.loserMatch4_1.player2_score = value;
                }
                Repository.Instance.loserMatch4_1.RefreshRecursive();
            }
        }
        #endregion

        #endregion

    }
}
