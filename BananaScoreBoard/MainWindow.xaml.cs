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

using BananaScoreBoard.ViewModel;

namespace BananaScoreBoard
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel mainViewModel;

        
        public MainWindow()
        {
            InitializeComponent();
            mainViewModel = new MainViewModel();
            this.DataContext = mainViewModel;
            mainViewModel.registerCallback( (int minute, int second) =>
            {
                this.Dispatcher.Invoke(() =>
                {
                    mainViewModel.Minute = minute;
                    mainViewModel.Second = second;
                    if (minute == 0 && second == 0 && is_clicked == true)
                    {
                        TimerMinute.IsReadOnly = false;
                        TimerSecond.IsReadOnly = false;
                        mainViewModel.PlayButton = "Start";
                        mainViewModel.pause();
                        is_clicked = false;
                    }
                });
               
            });

            Name1P.KeyUp += EnterName1P;
            //Name1PCommit.Click += ClickName1PCommit;

            Name2P.KeyUp += EnterName2P;
            //Name2pCommit.Click += ClickName2PCommit;

            Score1p.KeyUp += EnterScore1P;
            Score1pUp.Click += UpScore1P;
            Score1pReset.Click += ResetScore1P;
            Score1pDown.Click += DownScore1P;

            Score2p.KeyUp += EnterScore2P;
            Score2pUp.Click += UpScore2P;
            Score2pReset.Click += ResetScore2P;
            Score2pDown.Click += DownScore2P;

            Note1_1P.KeyUp += EnterNote1_1P;
            Note2_1P.KeyUp += EnterNote2_1P;
            Note1_2P.KeyUp += EnterNote1_2P;
            Note2_2P.KeyUp += EnterNote2_2P;
            Swap.Click += ClickSwap;

            Round.KeyUp += EnterRound;
            RoundUp.Click += UpRound;
            RoundReset.Click += ResetRound;
            RoundDown.Click += DownRound;

            TimerMinute.KeyUp += EnterMinute;
            TimerSecond.KeyUp += EnterSecond;
            TimerStart.Click += ClickPlay;
            TimerReset.Click += ClickReset;

        }
        void EnterName1P(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;
                mainViewModel.Name1P = box.Text;
                //mainViewModel.saveName1P();
            }
        }
        void ClickName1PCommit(object sender, RoutedEventArgs e)
        {
            //mainViewModel.saveName1P();
        }

        void EnterName2P(object sender, KeyEventArgs e)
        {            
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;

                mainViewModel.Name2P = box.Text;
                //mainViewModel.saveName2P();
            }
        }
        void ClickName2PCommit(object sender, RoutedEventArgs e)
        {
            //mainViewModel.saveName2P();
        }

        void EnterScore1P(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;

                try
                {
                    int value = Int32.Parse(box.Text);
                    mainViewModel.Score1P = value;
                }
                catch (Exception v)
                {
                    // Do Nothing
                }
            }
        }

        void UpScore1P(object sender, RoutedEventArgs e)
        {
            mainViewModel.Score1P += 1;
        }

        void ResetScore1P(object sender, RoutedEventArgs e)
        {
            mainViewModel.Score1P = 0;
        }

        void DownScore1P(object sender, RoutedEventArgs e)
        {
            mainViewModel.Score1P -= 1;
        }

        void EnterScore2P(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;

                try
                {
                    int value = Int32.Parse(box.Text);
                    mainViewModel.Score2P = value;
                }
                catch(Exception v)
                {
                    // Do Nothing
                }
                
            }
        }

        void UpScore2P(object sender, RoutedEventArgs e)
        {
            mainViewModel.Score2P += 1;
        }

        void ResetScore2P(object sender, RoutedEventArgs e)
        {
            mainViewModel.Score2P = 0;
        }

        void DownScore2P(object sender, RoutedEventArgs e)
        {
            mainViewModel.Score2P -= 1;
        }

        void EnterNote1_1P(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;
                mainViewModel.Note1_1P = box.Text;
            }
        }

        void EnterNote2_1P(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;
                mainViewModel.Note2_1P = box.Text;
            }
        }

        void EnterNote1_2P(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;
                mainViewModel.Note1_2P = box.Text;
            }
        }

        void EnterNote2_2P(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;
                mainViewModel.Note2_2P = box.Text;
            }
        }

        void ClickSwap(object sender, RoutedEventArgs e)
        {
            mainViewModel.Name1P = Name1P.Text;
            mainViewModel.Name2P = Name2P.Text;
            try
            {
                mainViewModel.Score1P = Int32.Parse(Score1p.Text);
            }
            catch(Exception v)
            {
                // Do nothing
            }
            try
            {
                mainViewModel.Score2P = Int32.Parse(Score2p.Text);
            }
            catch (Exception v)
            {
                // Do nothing
            }
            mainViewModel.swap();
        }

        void EnterRound(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;

                try
                {
                    int value = Int32.Parse(box.Text);
                    mainViewModel.Round = value;
                }
                catch (Exception v)
                {
                    // Do Nothing
                }

            }
        }

        void UpRound(object sender, RoutedEventArgs e)
        {
            mainViewModel.Round += 1;
        }

        void ResetRound(object sender, RoutedEventArgs e)
        {
            mainViewModel.Round = 0;
        }

        void DownRound(object sender, RoutedEventArgs e)
        {
            mainViewModel.Round -= 1;
        }


        void EnterMinute(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;

                try
                {
                    int value = Int32.Parse(box.Text);
                    mainViewModel.Minute = value;
                }
                catch (Exception v)
                {
                    // Do Nothing
                }

            }
        }

        void EnterSecond(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox box = (TextBox)sender;

                try
                {
                    int value = Int32.Parse(box.Text);
                    mainViewModel.Second = value;
                }
                catch (Exception v)
                {
                    // Do Nothing
                }

            }
        }


        bool is_clicked = false;
        void ClickPlay(object sender, RoutedEventArgs e)
        {
            if (is_clicked)
            {
                TimerMinute.IsReadOnly = false;
                TimerSecond.IsReadOnly = false;
                mainViewModel.PlayButton = "Start";
                mainViewModel.pause();
                is_clicked = false;
            }
            else
            {
                TimerMinute.IsReadOnly = true;
                TimerSecond.IsReadOnly = true;
                mainViewModel.PlayButton = "Pause";
                mainViewModel.start();
                is_clicked = true;
            }
        }

        void ClickReset(object sender, RoutedEventArgs e)
        {
            if (is_clicked)
            {
                TimerMinute.IsReadOnly = false;
                TimerSecond.IsReadOnly = false;
                mainViewModel.PlayButton = "Start";
                mainViewModel.pause();
                is_clicked = false;
            }
            mainViewModel.Second = 0;
            mainViewModel.Minute = 0;
        }
    }
}
