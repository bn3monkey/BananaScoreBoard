using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.View.TabView.MatchView.SubView;

using BananaScoreBoard.Model;
using System.Windows;
using System.Windows.Input;
using BananaScoreBoard.Auxiliary;

namespace BananaScoreBoard.ViewModel.TabViewModel.MatchViewModel.SubViewModel
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

        public TimerViewModel(TimerView view)
        {
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

            Repository.Instance.clock.registerRefresher(()=>
            {
                OnPropertyUpdate("Minute");
                OnPropertyUpdate("Second");
            });
        }


        private ICommand timerResetCommand;
        public ICommand TimerResetCommand
        {
            get
            {
                return timerResetCommand ?? (timerResetCommand = new DelegateCommand(() => {
                    Log.Log.V("Timer Reset Button is pressed");
                    IsTimerStarted = false;
                    Minute = 0;
                    Second = 0;
                }));
            }
        }

        private ICommand timerStartCommand;
        public ICommand TimerStartCommand
        {
            get
            {
                return timerStartCommand ?? (timerStartCommand = new DelegateCommand(() =>
                {
                    Log.Log.V("Timer Start Button is pressed");
                    IsTimerStarted = !IsTimerStarted;
                }));
            }
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
                        Log.Log.V("Timer is started");
                        Repository.Instance.clock.Start();
                    }
                    else
                    {
                        Log.Log.V("Timer is paused");
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
