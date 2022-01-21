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
            DependencyProperty.Register("Title", typeof(string), typeof(MatchNode), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
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
            DependencyProperty.Register("Player1", typeof(string), typeof(MatchNode), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
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
                   DependencyProperty.Register("Player2", typeof(string), typeof(MatchNode), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
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
                   DependencyProperty.Register("Player1WinCommand", typeof(ICommand), typeof(MatchNode));

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
                    DependencyProperty.Register("Player2WinCommand", typeof(ICommand), typeof(MatchNode));

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
            DependencyProperty.Register("ReadOnly", typeof(bool), typeof(MatchNode), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnReadOnlyPrpoertyChanged)));

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

        private static readonly DependencyProperty IsOnePlayerProperty =
            DependencyProperty.Register("IsOnePlayer", typeof(bool), typeof(MatchNode), new FrameworkPropertyMetadata(false, new PropertyChangedCallback(OnIsOnePlayerPropertyChanged)));
        public bool IsOnePlayer
        {
            get
            {
                return (bool)GetValue(IsOnePlayerProperty);
            }
            set
            {
                SetValue(IsOnePlayerProperty, value);
            }
        }

        private static void OnIsOnePlayerPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            bool? temp = e.NewValue as bool?;
            self.Player2TextBox.Visibility = temp ?? temp.Value ? Visibility.Collapsed : Visibility.Visible;
            self.Player2Button.Visibility = temp ?? temp.Value ? Visibility.Collapsed : Visibility.Visible;
        }

        private static readonly DependencyProperty WinnerProperty =
            DependencyProperty.Register("Winner", typeof(int), typeof(MatchNode), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnWinnerChanged)));

        public int Winner
        {
            get
            {
                return (int)GetValue(WinnerProperty);
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
                case 0:
                    self.Player1TextBox.Background = Brushes.White;
                    self.Player2TextBox.Background = Brushes.White;
                    break;

                case 1:
                    self.Player1TextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
                    self.Player2TextBox.Background = Brushes.White;
                    break;

                case 2:
                    self.Player1TextBox.Background = Brushes.White; 
                    self.Player2TextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
                    break;
            }
        }


        /*
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
        */
    }
}
