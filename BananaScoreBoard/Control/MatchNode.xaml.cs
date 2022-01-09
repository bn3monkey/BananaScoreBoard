using BananaScoreBoard.Auxiliary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BananaScoreBoard.Control
{
    /// <summary>
    /// MatchNode.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MatchNode : UserControl
    {
        public MatchNode()
        {
            InitializeComponent();
        }

        private static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MatchNode), new FrameworkPropertyMetadata(OnTitlePropertyChanged));
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
            set
            {
                SetValue(TitleProperty, value);
            }
        }
        private static void OnTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            self.TitleTextBlock.Text = e.NewValue.ToString();
        }

        private static readonly DependencyProperty Player1TextProperty = 
            DependencyProperty.Register("Player1", typeof(string), typeof(MatchNode), new FrameworkPropertyMetadata(OnPlayer1TextPropertyChanged));
        public string Player1
        {
            get
            {
                return (string)GetValue(Player1TextProperty);
            }
            set
            {
                SetValue(Player1TextProperty, value);
            }
        }
        private static void OnPlayer1TextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            self.Player1TextBox.Text = e.NewValue.ToString();
        }

        
        private static readonly DependencyProperty Player2TextProperty =
                   DependencyProperty.Register("Player2", typeof(string), typeof(MatchNode), new FrameworkPropertyMetadata(OnPlayer2TextPropertyChanged));
        public string Player2
        {
            get
            {
                return (string)GetValue(Player2TextProperty);
            }
            set
            {
                SetValue(Player2TextProperty, value);
            }
        }
        private static void OnPlayer2TextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            self.Player2TextBox.Text = e.NewValue.ToString();
        }


        private static readonly DependencyProperty Player1WinCommandProperty =
                   DependencyProperty.Register("Player1WinCommand", typeof(ICommand), typeof(MatchNode), new FrameworkPropertyMetadata(OnPlayer1WinCommandPropertyChanged));

        public ICommand Player1WinCommand
        {
            get
            {
                return (ICommand)GetValue(Player1WinCommandProperty);
            }
            set
            {
                SetValue(Player1WinCommandProperty, value);
            }
        }
        private static void OnPlayer1WinCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            self.Player1Button.Command = e.NewValue as ICommand;
        }


        private static readonly DependencyProperty Player2WinCommandProperty =
                    DependencyProperty.Register("Player2WinCommand", typeof(ICommand), typeof(MatchNode), new FrameworkPropertyMetadata(OnPlayer2WinCommandPropertyChanged));

        public ICommand Player2WinCommand
        {
            get
            {
                return (ICommand)GetValue(Player2WinCommandProperty);
            }
            set
            {
                SetValue(Player2WinCommandProperty, value);
            }
        }
        private static void OnPlayer2WinCommandPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            self.Player2Button.Command = e.NewValue as ICommand;
        }

        private static readonly DependencyProperty ReadOnlyProperty =
            DependencyProperty.Register("ReadOnly", typeof(bool), typeof(MatchNode), new FrameworkPropertyMetadata(OnReadOnlyPrpoertyChanged));

        public bool ReadOnly
        {
            get
            {
                return (bool)GetValue(ReadOnlyProperty);
            }
            set
            {
                SetValue(ReadOnlyProperty, value);
            }
        }

        private static void OnReadOnlyPrpoertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            bool? temp = e.NewValue as bool?;
            self.Player1TextBox.IsReadOnly = temp ?? temp.Value;
            self.Player2TextBox.IsReadOnly = temp ?? temp.Value;
        }

        public enum PlayerNumber
        {
            None,
            P1,
            P2,
        }

        private static readonly DependencyProperty WinnerProperty =
            DependencyProperty.Register("Winner", typeof(PlayerNumber), typeof(MatchNode), new FrameworkPropertyMetadata(PlayerNumber.None, OnWinnerChanged));

        public PlayerNumber Winner
        {
            get
            {
                return (PlayerNumber)GetValue(WinnerProperty);
            }
            set
            {
                SetValue(WinnerProperty, value);
            }
        }

        private static void OnWinnerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            switch(e.NewValue)
            {
                case PlayerNumber.None:
                    self.Player1TextBox.Background = Brushes.White;
                    self.Player2TextBox.Background = Brushes.White;
                    break;

                case PlayerNumber.P1:
                    self.Player1TextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
                    self.Player2TextBox.Background = Brushes.White;
                    break;

                case PlayerNumber.P2:
                    self.Player1TextBox.Background = Brushes.White; 
                    self.Player2TextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
                    break;
            }
        }


        private MatchNode winnerMatch;
        private PlayerNumber winnermatch_winner_number = PlayerNumber.None;

        private MatchNode loserMatch;
        private PlayerNumber losermatch_loser_number = PlayerNumber.None;

        
        private void ResetNextMatch()
        {
            switch(winnermatch_winner_number)
            {
                case PlayerNumber.None: break;
                case PlayerNumber.P1:
                    winnerMatch.Player1 = "";
                    break;
                case PlayerNumber.P2:
                    winnerMatch.Player2 = "";
                    break;
            }
            switch (losermatch_loser_number)
            {
                case PlayerNumber.None: break;
                case PlayerNumber.P1:
                    loserMatch.Player1 = "";
                    break;
                case PlayerNumber.P2:
                    loserMatch.Player2 = "";
                    break;
            }
        }
        private void DetermineNextMatch(string winner, string loser)
        {
            if (Player1.Length == 0 || Player2.Length == 0)
                return;

            if (winnerMatch.Player1 == "")
            {
                winnermatch_winner_number = PlayerNumber.P1;
                winnerMatch.Player1 = winner;
            }
            else
            {
                winnermatch_winner_number = PlayerNumber.P2;
                winnerMatch.Player2 = winner;
            }

            if (loserMatch.Player1 == "")
            {
                losermatch_loser_number = PlayerNumber.P1;
                loserMatch.Player1 = loser;
            }
            else
            {
                losermatch_loser_number = PlayerNumber.P2;
                loserMatch.Player2 = loser;
            }
        }

        public void RegisterResultNode(MatchNode winnerMatch, MatchNode loserMatch)
        {
            this.winnerMatch = winnerMatch;
            this.loserMatch = loserMatch;

            Player1WinCommand = new DelegateCommand(() =>
            {
                switch (Winner)
                {
                    case PlayerNumber.None:
                        DetermineNextMatch(Player1, Player2);
                        Winner = PlayerNumber.P1;
                        break;
                    case PlayerNumber.P1:
                        ResetNextMatch();
                        Winner = PlayerNumber.None;
                        break;
                    case PlayerNumber.P2:
                        ResetNextMatch();
                        DetermineNextMatch(Player1, Player2);
                        Winner = PlayerNumber.P1;
                        break;
                }

            });
            Player2WinCommand = new DelegateCommand(() =>
            {
                switch (Winner)
                {
                    case PlayerNumber.None:
                        DetermineNextMatch(Player2, Player1);
                        Winner = PlayerNumber.P2;
                        break;
                    case PlayerNumber.P1:
                        ResetNextMatch();
                        DetermineNextMatch(Player2, Player1);
                        Winner = PlayerNumber.None;
                        break;
                    case PlayerNumber.P2:
                        ResetNextMatch();
                        Winner = PlayerNumber.P2;
                        break;
                }

            });
        }

        public void UnregisterResultNode()
        {
            this.winnerMatch = null;
            this.loserMatch = null;
            Player1WinCommand = null;
            Player2WinCommand = null;
        }
    }
}
