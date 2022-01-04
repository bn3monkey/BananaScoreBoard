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
using BananaScoreBoard.View.TabView.MatchView.SubView;
using BananaScoreBoard.ViewModel.TabViewModel.MatchViewModel;

namespace BananaScoreBoard.View.TabView.MatchView
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MatchView : Page
    {
        private MatchViewModel viewModel;

        public ScoreView scoreView;
        public MISCView miscView;
        public TimerView timerView;
     
        public MatchView()
        {
            InitializeComponent();
            this.ScoreView.Content = scoreView = new ScoreView();
            this.MISCView.Content = miscView=  new MISCView();
            this.TimerView.Content = timerView = new TimerView();

            this.DataContext = viewModel = new MatchViewModel(this);
        }
    }
}
