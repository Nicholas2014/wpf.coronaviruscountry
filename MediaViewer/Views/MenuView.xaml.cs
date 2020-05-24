using MediaViewer.Presenters;
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

namespace MediaViewer.Views
{
    /// <summary>
    /// MenuView.xaml 的交互逻辑
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView(MenuPresenter presenter)
        {
            InitializeComponent();
            DataContext = presenter;
        }

        public MenuPresenter Presenter
        {
            get

            {
                return DataContext as MenuPresenter;
            }
        }

        private void Video_Click(object sender, RoutedEventArgs e)
        {
            Presenter.WatchVideo();
        }

        private void Music_Click(object sender, RoutedEventArgs e)
        {
            Presenter.ListenToMusic();
        }

        private void Pictures_Click(object sender, RoutedEventArgs e)
        {
            Presenter.DisplayPictures();
        }
    }
}
