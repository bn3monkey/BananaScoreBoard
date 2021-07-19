using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.View.MainView.SubView;

using BananaScoreBoard.Model;
using System.Windows;

namespace BananaScoreBoard.ViewModel.MainViewModel.SubViewModel
{
    class TimerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
            //if (PropertyChanged != null)
            //    PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }

        public TimerViewModel(MainViewModel parent, TimerView view)
        {
            view.DataContext = this;

            timerStartedUI = (bool value) =>
            {
                view.Dispatcher.Invoke(() =>
                {
                    if (value)
                    {
                        view.TimerMinute.IsReadOnly = true;
                        view.TimerSecond.IsReadOnly = true;
                        view.TimerStart.Content = "Pause";
                    }
                    else
                    {
                        view.TimerMinute.IsReadOnly = false;
                        view.TimerSecond.IsReadOnly = false;
                        view.TimerStart.Content = "Start";
                    }
                });
            };

            timerChangedUI = (int minute, int second) =>
            {
               view.Dispatcher.Invoke(() =>  
                    {
                        Minute = minute;
                        Second = second;
                        if (Minute == 0 && Second == 0)
                        {
                            IsTimerStarted = false;
                        }
                    }
                );
            };

           

            Repository.Instance.clock.registerUICallback(timerChangedUI);
            Repository.Instance.clock.registerFileCallback((int minute, int second) =>
            {
                Task task = new Task(() => {
                    Repository.Instance.record.writeClock(minute, second);
                });
                task.Start();
            });


            view.TimerStart.Click += ClickTimerStart;
            view.TimerReset.Click += ClickTimerReset;
        }

        private void ClickTimerReset(object sender, RoutedEventArgs e)
        {
            IsTimerStarted = false;
            Minute = 0;
            Second = 0;
        }

        private void ClickTimerStart(object sender, RoutedEventArgs e)
        {
            IsTimerStarted = !IsTimerStarted;
            
        }

        public delegate void TimerStartedUI(bool value);
        TimerStartedUI timerStartedUI;
        Model.Type.Clock.Notifier timerChangedUI;

        private bool isTimerStarted = false;
        public bool IsTimerStarted
        {
            get
            {
                return isTimerStarted;
            }
            set
            {
                if (isTimerStarted != value)
                {
                    isTimerStarted = value;
                    if (isTimerStarted)
                    {
                        Repository.Instance.clock.Start();
                    }
                    else
                    {
                        Repository.Instance.clock.Pause();
                    }
                    timerStartedUI(value);
                }
            }
        }


        public int Minute
        {
            get
            {
                return Repository.Instance.clock.minute;
            }
            set
            {
                Repository.Instance.clock.minute = value;
                OnPropertyUpdate("Minute");
            }
        }
        public int Second
        {
            get
            {
                return Repository.Instance.clock.second;
            }
            set
            {
                Repository.Instance.clock.second = value;
                OnPropertyUpdate("Second");
            }
        }

    }
}
