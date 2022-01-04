using BananaScoreBoard.ViewModel.ToastViewModel;
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

namespace BananaScoreBoard.View.ToastView
{
    /// <summary>
    /// ToastView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class ToastView : Page
    {
        ToastViewModel viewModel;
        public ToastView()
        {
            InitializeComponent();
            this.DataContext = viewModel = new ToastViewModel(this);
        }
    }
}
