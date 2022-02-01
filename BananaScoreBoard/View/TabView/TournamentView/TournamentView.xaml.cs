using BananaScoreBoard.ViewModel.TabViewModel.TournamentViewModel;
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

namespace BananaScoreBoard.View.TabView.TournamentView
{
    /// <summary>
    /// TournamentView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TournamentView : Page
    {
        TournamentViewModel viewModel;

        private TournamentInnerView tournamentInnerView = new TournamentInnerView();
        private RosterView rosterView = new RosterView();

        public TournamentView()
        {
            InitializeComponent();
            InnerView.Content = tournamentInnerView;
            RosterView.Content = rosterView;
            InnerView.Visibility = Visibility.Visible;
            RosterView.Visibility = Visibility.Collapsed;
            DataContext = viewModel = new TournamentViewModel(this);
        }

        public enum FrameName
        {
            Tournament,
            Roster
        }
        public void SwitchFrame(FrameName framename)
        {
            switch(framename)
            {
                case FrameName.Tournament:
                    InnerView.Visibility = Visibility.Visible;
                    RosterView.Visibility = Visibility.Collapsed;
                    break;
                case FrameName.Roster:
                    InnerView.Visibility = Visibility.Collapsed;
                    RosterView.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
