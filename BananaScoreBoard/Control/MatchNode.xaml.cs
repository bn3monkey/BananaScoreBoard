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


        private static readonly DependencyProperty Player1ScoreTextProperty =
            DependencyProperty.Register("Player1Score", typeof(int), typeof(MatchNode), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnPlayer1ScoreTextPropertyChanged)));
        public int Player1Score
        {
            get
            {
                return (int)GetValue(Player1ScoreTextProperty);
            }
            set
            {
                SetValue(Player1ScoreTextProperty, value);
            }
        }

        private static void ChangeTextBoxColor(MatchNode self, int player1_score, int player2_score)
        {
            if (player1_score == player2_score)
            {
                self.Player1TextBox.Background = Brushes.White;
                self.Player2TextBox.Background = Brushes.White;
                self.Player1ScoreTextBox.Background = Brushes.White;
                self.Player2ScoreTextBox.Background = Brushes.White;
            }
            else if (player1_score > player2_score)
            {
                self.Player1TextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
                self.Player2TextBox.Background = Brushes.White;
                self.Player1ScoreTextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
                self.Player2ScoreTextBox.Background = Brushes.White;
            }
            else
            {
                self.Player1TextBox.Background = Brushes.White;
                self.Player2TextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
                self.Player1ScoreTextBox.Background = Brushes.White;
                self.Player2ScoreTextBox.Background = new SolidColorBrush(Color.FromArgb(255, 73, 144, 226));
            }
        }

        private static void OnPlayer1ScoreTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            self.Player1ScoreTextBox.Text = e.NewValue.ToString();

            int player1_score = int.Parse(e.NewValue.ToString());
            int player2_score = self.Player2Score;

            ChangeTextBoxColor(self, player1_score, player2_score);
        }

        private static readonly DependencyProperty Player2ScoreTextProperty =
            DependencyProperty.Register("Player2Score", typeof(int), typeof(MatchNode), new FrameworkPropertyMetadata(0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, new PropertyChangedCallback(OnPlayer2ScoreTextPropertyChanged)));
        public int Player2Score
        {
            get
            {
                return (int)GetValue(Player2ScoreTextProperty);
            }
            set
            {
                SetValue(Player2ScoreTextProperty, value);
            }
        }

        private static void OnPlayer2ScoreTextPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MatchNode self = d as MatchNode;
            self.Player2ScoreTextBox.Text = e.NewValue.ToString();

            int player1_score = self.Player1Score;
            int player2_score = int.Parse(e.NewValue.ToString());

            ChangeTextBoxColor(self, player1_score, player2_score);
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
            self.Player1TextBox.Focusable = false;
            self.Player2TextBox.Focusable = false;
        }

    }
}
