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
using BananaScoreBoard.View.MainView.SubView;
using BananaScoreBoard.ViewModel.MainViewModel;

namespace BananaScoreBoard.View.MainView
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Page
    {
        private MainViewModel view_model;

        public FolderPathView folderPathView;
        public ScoreView scoreView;
        public MISCView miscView;
        public TimerView timerView;
        public ToastView toastView;

        public MainView()
        {
            InitializeComponent();
            this.FolderPathView.Content = folderPathView = new FolderPathView();
            this.ScoreView.Content = scoreView = new ScoreView();
            this.MISCView.Content = miscView=  new MISCView();
            this.TimerView.Content = timerView = new TimerView();
            this.ToastView.Content = toastView = new ToastView();

            view_model = new MainViewModel(this);
        }
    }
}
