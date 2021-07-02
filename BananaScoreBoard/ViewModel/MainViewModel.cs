using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BananaScoreBoard.Model;

namespace BananaScoreBoard.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Repository repo;
        public MainViewModel()
        {
            repo = Repository.Instance;

            Task<String> name1pTask = repo.player1.getName();
            Task<String> name2pTask = repo.player2.getName();
            
            Task<int> score1pTask = repo.player1.getScore();
            Task<int> score2pTask = repo.player2.getScore();

            Task<String> note11pTask = repo.player1.getNote1();
            Task<String> note12pTask = repo.player2.getNote1();

            Task<String> note21pTask = repo.player1.getNote2();
            Task<String> note22pTask = repo.player2.getNote2();

            Task<Tuple<int, int>> timeTask = repo.timer.getTime();
            Task<int> roundTask = repo.round.getRound();

            name_1p = name1pTask.Result;
            name_2p = name2pTask.Result;
            score_1p = score1pTask.Result;
            score_2p = score2pTask.Result;
            note1_1p = note11pTask.Result;
            note1_2p = note12pTask.Result;
            note2_1p = note21pTask.Result;
            note2_2p = note22pTask.Result;
            Tuple<int, int> time = timeTask.Result;
            minute = time.Item1;
            second = time.Item2;
            round = roundTask.Result;
            
            repo.timer.registerCallback((int minute, int second) =>
            {
                timerChange(minute, second);
            });

            play_button = "Start";
        }

        public delegate void TimerChange(int minute, int second);
        TimerChange timerChange;

        public void registerCallback(TimerChange _timerChange)
        {
            timerChange = _timerChange;
        }

        private string name_1p, name_2p;
        private int score_1p, score_2p;
        private string note1_1p, note1_2p;
        private string note2_1p, note2_2p;

        private int minute, second;
        private string play_button;

        private int round;

        public string Name1P
        {
            get
            {
                return name_1p;
            }
            set
            {
                name_1p = value;
                saveName1P().Wait();
                OnPropertyUpdate("Name1P");
            }
        }

        private async Task saveName1P()
        {
            await repo.player1.setName(name_1p);
        }

        public string Name2P
        {
            get
            {
                return name_2p;
            }
            set
            {
                name_2p = value;
                saveName2P().Wait();
                OnPropertyUpdate("Name2P");
            }
        }

        private async Task saveName2P()
        {
            await repo.player2.setName(name_2p);
        }

        public int Score1P
        {
            get
            {
                return score_1p;
            }
            set
            {
                score_1p = value;
                saveScore1P().Wait();
                OnPropertyUpdate("Score1P");
            }
        }

        private async Task saveScore1P()
        {
            await repo.player1.setScore(score_1p);
        }


        public int Score2P
        {
            get
            {
                return score_2p;
            }
            set
            {
                score_2p = value;
                saveScore2P().Wait();
                OnPropertyUpdate("Score2P");
            }
        }

        public async Task saveScore2P()
        {
            await repo.player2.setScore(score_2p);
        }

        public string Note1_1P
        {
            get
            {
                return note1_1p;
            }
            set
            {
                note1_1p = value;
                saveNote1_1p();
                OnPropertyUpdate("Note1_1P");
            }
        }

        private async void saveNote1_1p()
        {
            await repo.player1.setNote1(note1_1p);
        }

        public string Note1_2P
        {
            get
            {
                return note1_2p;
            }
            set
            {
                note1_2p = value;
                saveNote1_2p();
                OnPropertyUpdate("Note1_2P");
            }
        }

        private async void saveNote1_2p()
        {
            await repo.player2.setNote1(note1_2p);
        }

        public string Note2_1P
        {
            get
            {
                return note2_1p;
            }
            set
            {
                note2_1p = value;
                saveNote2_1p();
                OnPropertyUpdate("Note2_1P");
            }
        }

        private async void saveNote2_1p()
        {
            await repo.player1.setNote2(note2_1p);
        }

        public string Note2_2P
        {
            get
            {
                return note2_2p;
            }
            set
            {
                note2_2p = value;
                saveNote2_2p();
                OnPropertyUpdate("Note2_2P");
            }
        }

        private async void saveNote2_2p()
        {
            await repo.player2.setNote2(note2_2p);
        }

        public async void swap()
        {
            string new_name_1p = name_2p;
            string new_name_2p = name_1p;
            int new_score_1p = score_2p;
            int new_score_2p = score_1p;

            Score1P = new_score_1p;
            Score2P = new_score_2p;
            Name1P = new_name_1p;
            Name2P = new_name_2p;

            //await Player.swap(repo.player1, repo.player2);
        }

        public int Minute
        {
            get
            {
                return minute;
            }
            set
            {
                minute = value;
                repo.timer.setTime(minute, second).Wait();
                OnPropertyUpdate("Minute");
            }
        }

        public int Second
        {
            get
            {
                return second;
            }
            set
            {
                if (0 <= value && value < 60)
                    second = value;
                else
                    second = 0;
                repo.timer.setTime(minute, second).Wait();
                OnPropertyUpdate("Second");
            }
        }


        
        public string PlayButton
        {
            get
            {
                return play_button;
            }
            set
            {
                play_button = value;
                OnPropertyUpdate("PlayButton");
            }

        }
        

        public void start()
        {
            repo.timer.Start(minute, second);
        }
        public void pause()
        {
            repo.timer.Pause();
        }

        public int Round
        {
            get
            {
                return round;
            }
            set
            {
                round = value;
                repo.round.setRound(value).Wait();
                OnPropertyUpdate("Round");
            }
        }

        private async void saveRound(int value)
        {
            await repo.round.setRound(value);
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyUpdate(string propertyname)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
