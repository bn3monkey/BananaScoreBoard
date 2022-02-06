using BananaScoreBoard.Auxiliary;
using BananaScoreBoard.Model;
using BananaScoreBoard.Model.Type;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Repository.Instance.winnerMatch4_1.SetNextMatch(null, 0, null, 0);


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
                OnPropertyUpdate("W1_1_Winner");
            });
            Repository.Instance.winnerMatch1_2.registerRefresher(() =>
            {
                OnPropertyUpdate("W1_2_P1");
                OnPropertyUpdate("W1_2_P2");
                OnPropertyUpdate("W1_2_Winner");
            });
            Repository.Instance.winnerMatch1_3.registerRefresher(() =>
            {
                OnPropertyUpdate("W1_3_P1");
                OnPropertyUpdate("W1_3_P2");
                OnPropertyUpdate("W1_3_Winner");
            });
            Repository.Instance.winnerMatch1_4.registerRefresher(() =>
            {
                OnPropertyUpdate("W1_4_P1");
                OnPropertyUpdate("W1_4_P2");
                OnPropertyUpdate("W1_4_Winner");
            });
            Repository.Instance.winnerMatch2_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W2_1_P1");
                OnPropertyUpdate("W2_1_P2");
                OnPropertyUpdate("W2_1_Winner");
            });
            Repository.Instance.winnerMatch2_2.registerRefresher(() =>
            {
                OnPropertyUpdate("W2_2_P1");
                OnPropertyUpdate("W2_2_P2");
                OnPropertyUpdate("W2_2_Winner");
            });
            Repository.Instance.winnerMatch3_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W3_1_P1");
                OnPropertyUpdate("W3_1_P2");
                OnPropertyUpdate("W3_1_Winner");
            });
            Repository.Instance.winnerMatch4_1.registerRefresher(() =>
            {
                OnPropertyUpdate("W4_1_P1");
                OnPropertyUpdate("W4_1_P2");
                OnPropertyUpdate("W4_1_Winner");
            });

            Repository.Instance.loserMatch1_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L1_1_P1");
                OnPropertyUpdate("L1_1_P2");
                OnPropertyUpdate("L1_1_Winner");
            });
            Repository.Instance.loserMatch1_2.registerRefresher(() =>
            {
                OnPropertyUpdate("L1_2_P1");
                OnPropertyUpdate("L1_2_P2");
                OnPropertyUpdate("L1_2_Winner");
            });

            Repository.Instance.loserMatch2_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L2_1_P1");
                OnPropertyUpdate("L2_1_P2");
                OnPropertyUpdate("L2_1_Winner");
            });
            Repository.Instance.loserMatch2_2.registerRefresher(() =>
            {
                OnPropertyUpdate("L2_2_P1");
                OnPropertyUpdate("L2_2_P2");
                OnPropertyUpdate("L2_2_Winner");
            });

            Repository.Instance.loserMatch3_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L3_1_P1");
                OnPropertyUpdate("L3_1_P2");
                OnPropertyUpdate("L3_1_Winner");
            });


            Repository.Instance.loserMatch4_1.registerRefresher(() =>
            {
                OnPropertyUpdate("L4_1_P1");
                OnPropertyUpdate("L4_1_P2");
                OnPropertyUpdate("L4_1_Winner");
            });
        }

        private void DetermineWinnerToPlayer1(Match match)
        {
            Match.WinnerCode code = match.WinPlayer1();
            SendToast(match, code);
        }
        private void DetermineWinnerToPlayer2(Match match)
        {
            Match.WinnerCode code = match.WinPlayer2();
            SendToast(match, code);
        }
        private void SendToast(Match match, Match.WinnerCode code)
        {
            switch (code)
            {
                case Model.Type.Match.WinnerCode.PLAYER1_EMPTY:
                    Repository.Instance.toast.SendMessage("Please Enter Player1");
                    break;
                case Model.Type.Match.WinnerCode.PLAYER2_EMPTY:
                    Repository.Instance.toast.SendMessage("Please Enter Player2");
                    break;
                case Model.Type.Match.WinnerCode.ALL_EMPTY:
                    Repository.Instance.toast.SendMessage("Please Enter Player1 and Player2");
                    break;
                case Model.Type.Match.WinnerCode.WINNER_MATCH_NEEDS_NO_WINNER:
                    Repository.Instance.toast.SendMessage("De-activate Winner in {0}", match.WinnerMatchName);
                    break;
                case Model.Type.Match.WinnerCode.LOSER_MATCH_NEEDS_NO_WINNER:
                    Repository.Instance.toast.SendMessage("De-activate Winner in {0}", match.LoserMatchName);
                    break;
                case Model.Type.Match.WinnerCode.ALL_MATCH_NEEDS_NO_WINNER:
                    Repository.Instance.toast.SendMessage("De-activate Winner in {0} and {1}", match.WinnerMatchName, match.LoserMatchName);
                    break;
                case Model.Type.Match.WinnerCode.SUCCESS:
                    break;
                default:
                    break;
            }
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

        public int W1_1_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch1_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                    1, 1, 
                    Repository.Instance.winnerMatch1_1.winner, value));
                Repository.Instance.winnerMatch1_1.winner = value;
                OnPropertyUpdate("W1_1_Winner");
            }
        }

        private ICommand w1_1_player1WinCommand;
        public ICommand W1_1_Player1WinCommand
        {
            get
            {
                return w1_1_player1WinCommand ?? (w1_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 1, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch1_1);
                }));
            }
        }
        private ICommand w1_1_player2WinCommand;
        public ICommand W1_1_Player2WinCommand
        {
            get
            {
                return w1_1_player2WinCommand ?? (w1_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 1, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch1_1);
                }));
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

        public int W1_2_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch1_2.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   1, 2,
                   Repository.Instance.winnerMatch1_2.winner, value));
                Repository.Instance.winnerMatch1_2.winner = value;
                OnPropertyUpdate("W1_2_Winner");
            }
        }

        private ICommand w1_2_player1WinCommand;
        public ICommand W1_2_Player1WinCommand
        {
            get
            {
                return w1_2_player1WinCommand ?? (w1_2_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 2, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch1_2);

                }));
            }
        }
        private ICommand w1_2_player2WinCommand;
        public ICommand W1_2_Player2WinCommand
        {
            get
            {
                return w1_2_player2WinCommand ?? (w1_2_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 2, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch1_2);
                }));
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

        public int W1_3_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch1_3.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   1, 3,
                   Repository.Instance.winnerMatch1_3.winner, value));
                Repository.Instance.winnerMatch1_3.winner = value;
                OnPropertyUpdate("W1_3_Winner");
            }
        }

        private ICommand w1_3_player1WinCommand;
        public ICommand W1_3_Player1WinCommand
        {
            get
            {
                return w1_3_player1WinCommand ?? (w1_3_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 3, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch1_3);
                }));
            }
        }
        private ICommand w1_3_player2WinCommand;
        public ICommand W1_3_Player2WinCommand
        {
            get
            {
                return w1_3_player2WinCommand ?? (w1_3_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 3, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch1_3);
                }));
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

        public int W1_4_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch1_4.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   1, 4,
                   Repository.Instance.winnerMatch1_4.winner, value));
                Repository.Instance.winnerMatch1_4.winner = value;
                OnPropertyUpdate("W1_4_Winner");
            }
        }

        private ICommand w1_4_player1WinCommand;
        public ICommand W1_4_Player1WinCommand
        {
            get
            {
                return w1_4_player1WinCommand ?? (w1_4_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 4, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch1_4);
                }));
            }
        }
        private ICommand w1_4_player2WinCommand;
        public ICommand W1_4_Player2WinCommand
        {
            get
            {
                return w1_4_player2WinCommand ?? (w1_4_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 1, 4, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch1_4);
                }));
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

        public int W2_1_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch2_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   2, 1,
                   Repository.Instance.winnerMatch2_1.winner, value));
                Repository.Instance.winnerMatch2_1.winner = value;
                OnPropertyUpdate("W2_1_Winner");
            }
        }

        private ICommand w2_1_player1WinCommand;
        public ICommand W2_1_Player1WinCommand
        {
            get
            {
                return w2_1_player1WinCommand ?? (w2_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 2, 1, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch2_1);
                }));
            }
        }
        private ICommand w2_1_player2WinCommand;
        public ICommand W2_1_Player2WinCommand
        {
            get
            {
                return w2_1_player2WinCommand ?? (w2_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 2, 1, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch2_1);
                }));
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

        public int W2_2_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch2_2.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   2, 2,
                   Repository.Instance.winnerMatch2_2.winner, value));

                Repository.Instance.winnerMatch2_2.winner = value;
                OnPropertyUpdate("W2_2_Winner");
            }
        }

        private ICommand w2_2_player1WinCommand;
        public ICommand W2_2_Player1WinCommand
        {
            get
            {
                return w2_2_player1WinCommand ?? (w2_2_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 2, 2, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch2_2);
                }));
            }
        }
        private ICommand w2_2_player2WinCommand;
        public ICommand W2_2_Player2WinCommand
        {
            get
            {
                return w2_2_player2WinCommand ?? (w2_2_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 2, 2, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch2_2);
                }));
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

        public int W3_1_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch3_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   3, 1,
                   Repository.Instance.winnerMatch3_1.winner, value));
                Repository.Instance.winnerMatch3_1.winner = value;
                OnPropertyUpdate("W3_1_Winner");
            }
        }

        private ICommand w3_1_player1WinCommand;
        public ICommand W3_1_Player1WinCommand
        {
            get
            {
                return w3_1_player1WinCommand ?? (w3_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 3, 1, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch3_1);
                }));
            }
        }
        private ICommand w3_1_player2WinCommand;
        public ICommand W3_1_Player2WinCommand
        {
            get
            {
                return w3_1_player2WinCommand ?? (w3_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 3, 1, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch3_1);
                }));
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

        public int W4_1_Winner
        {
            get
            {
                return Repository.Instance.winnerMatch4_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change WinnerMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   4, 1,
                   Repository.Instance.winnerMatch4_1.winner, value));
                Repository.Instance.winnerMatch4_1.winner = value;
                OnPropertyUpdate("W4_1_Winner");
            }
        }

        private ICommand w4_1_player1WinCommand;
        public ICommand W4_1_Player1WinCommand
        {
            get
            {
                return w4_1_player1WinCommand ?? (w4_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 4, 1, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.winnerMatch4_1);
                }));
            }
        }
        private ICommand w4_1_player2WinCommand;
        public ICommand W4_1_Player2WinCommand
        {
            get
            {
                return w4_1_player2WinCommand ?? (w4_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("WinnerMatch{0}_{1}Round {2}Player Win button is pressed", 4, 1, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.winnerMatch4_1);
                }));
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

        public int L1_1_Winner
        {
            get
            {
                return Repository.Instance.loserMatch1_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   1, 1,
                   Repository.Instance.loserMatch1_1.winner, value));
                Repository.Instance.loserMatch1_1.winner = value;
                OnPropertyUpdate("L1_1_Winner");
            }
        }

        private ICommand l1_1_player1WinCommand;
        public ICommand L1_1_Player1WinCommand
        {
            get
            {
                return l1_1_player1WinCommand ?? (l1_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 1, 1, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.loserMatch1_1);
                }));
            }
        }
        private ICommand l1_1_player2WinCommand;
        public ICommand L1_1_Player2WinCommand
        {
            get
            {
                return l1_1_player2WinCommand ?? (l1_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 1, 1, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.loserMatch1_1);
                }));
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

        public int L1_2_Winner
        {
            get
            {
                return Repository.Instance.loserMatch1_2.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   1, 2,
                   Repository.Instance.loserMatch1_2.winner, value));

                Repository.Instance.loserMatch1_2.winner = value;
                OnPropertyUpdate("L1_2_Winner");
            }
        }

        private ICommand l1_2_player1WinCommand;
        public ICommand L1_2_Player1WinCommand
        {
            get
            {
                return l1_2_player1WinCommand ?? (l1_2_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 1, 2, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.loserMatch1_2);
                }));
            }
        }
        private ICommand l1_2_player2WinCommand;
        public ICommand L1_2_Player2WinCommand
        {
            get
            {
                return l1_2_player2WinCommand ?? (l1_2_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 1, 2, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.loserMatch1_2);
                }));
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

        public int L2_1_Winner
        {
            get
            {
                return Repository.Instance.loserMatch2_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   2, 1,
                   Repository.Instance.loserMatch2_1.winner, value));

                Repository.Instance.loserMatch2_1.winner = value;
                OnPropertyUpdate("L2_1_Winner");
            }
        }

        private ICommand l2_1_player1WinCommand;
        public ICommand L2_1_Player1WinCommand
        {
            get
            {
                return l2_1_player1WinCommand ?? (l2_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 2, 1, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.loserMatch2_1);
                }));
            }
        }
        private ICommand l2_1_player2WinCommand;
        public ICommand L2_1_Player2WinCommand
        {
            get
            {
                return l2_1_player2WinCommand ?? (l2_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 2, 1, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.loserMatch2_1);
                }));
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

        public int L2_2_Winner
        {
            get
            {
                return Repository.Instance.loserMatch2_2.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   2, 2,
                   Repository.Instance.loserMatch2_2.winner, value));

                Repository.Instance.loserMatch2_2.winner = value;
                OnPropertyUpdate("L2_2_Winner");
            }
        }

        private ICommand l2_2_player1WinCommand;
        public ICommand L2_2_Player1WinCommand
        {
            get
            {
                return l2_2_player1WinCommand ?? (l2_2_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 2, 2, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.loserMatch2_2);
                }));
            }
        }
        private ICommand l2_2_player2WinCommand;
        public ICommand L2_2_Player2WinCommand
        {
            get
            {
                return l2_2_player2WinCommand ?? (l2_2_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 2, 2, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.loserMatch2_2);
                }));
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

        
        public int L3_1_Winner
        {
            get
            {
                return Repository.Instance.loserMatch3_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                   3, 1,
                   Repository.Instance.loserMatch3_1.winner, value));
                Repository.Instance.loserMatch3_1.winner = value;
                OnPropertyUpdate("L3_1_Winner");
            }
        }

        private ICommand l3_1_player1WinCommand;
        public ICommand L3_1_Player1WinCommand
        {
            get
            {
                return l3_1_player1WinCommand ?? (l3_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 3, 1, 1));

                    DetermineWinnerToPlayer1(Repository.Instance.loserMatch3_1);
                }));
            }
        }
        private ICommand l3_1_player2WinCommand;
        public ICommand L3_1_Player2WinCommand
        {
            get
            {
                return l3_1_player2WinCommand ?? (l3_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 3, 1, 2));

                    DetermineWinnerToPlayer2(Repository.Instance.loserMatch3_1);
                }));
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

        public int L4_1_Winner
        {
            get
            {
                return Repository.Instance.loserMatch4_1.winner;
            }
            set
            {
                Log.Log.V(string.Format("Change LoserMatch({0}) {1}Round Winner : Player{2} -> Player{3}",
                    4, 1,
                    Repository.Instance.loserMatch4_1.winner, value));
                Repository.Instance.loserMatch4_1.winner = value;
                OnPropertyUpdate("L4_1_Winner");
            }
        }

        private ICommand l4_1_player1WinCommand;
        public ICommand L4_1_Player1WinCommand
        {
            get
            {
                return l4_1_player1WinCommand ?? (l4_1_player1WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 4, 1, 1));
                    DetermineWinnerToPlayer1(Repository.Instance.loserMatch4_1);
                }));
            }
        }
        private ICommand l4_1_player2WinCommand;
        public ICommand L4_1_Player2WinCommand
        {
            get
            {
                return l4_1_player2WinCommand ?? (l4_1_player2WinCommand = new DelegateCommand(() =>
                {
                    Log.Log.V(string.Format("LoserMatch{0}_{1}Round {2}Player Win button is pressed", 4, 1, 2));
                    DetermineWinnerToPlayer2(Repository.Instance.loserMatch4_1);
                }));
            }
        }
        #endregion

        #endregion

    }
}
