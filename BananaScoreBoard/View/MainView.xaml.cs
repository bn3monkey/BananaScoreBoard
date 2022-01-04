using BananaScoreBoard.ViewModel;
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

namespace BananaScoreBoard.View
{
    /// <summary>
    /// MainView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainView : Page
    {
        private MainViewModel viewModel;

        public FolderPathView.FolderPathView folderPathView;
        public TabView.TabView tabView;
        public ToastView.ToastView toastView;
        
        public MainView()
        {
            InitializeComponent();
            this.FolderPathView.Content = folderPathView = new FolderPathView.FolderPathView();
            this.TabView.Content = tabView = new TabView.TabView();
            this.ToastView.Content = toastView = new ToastView.ToastView();

            this.DataContext = viewModel = new MainViewModel(this);
        }
    }
}
