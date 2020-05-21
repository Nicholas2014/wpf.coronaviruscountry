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

namespace PreviewEvents
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Handler(object sender, KeyEventArgs e)
        {
            var isPreview = e.RoutedEvent.Name.StartsWith("Preview");
            var direction = isPreview ? "ˇ" : "ˆ";

            output.Items.Add($"{direction} {sender.GetType().Name}");

            if (sender == e.OriginalSource && isPreview)
            {
                output.Items.Add("-{bounce}-");
            }
            if (sender == this && !isPreview)
            {
                output.Items.Add(" -end- ");
            }
        }
    }
}
