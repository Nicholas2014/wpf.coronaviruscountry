using ContactManager.Presenters;
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

namespace ContactManager
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class Shell : Window
    {
        public Shell()
        {
            InitializeComponent();
            DataContext = new ApplicationPresenter(this, new Model.ContactRepository());
        }

        public void AddTab<T>(PresenterBase<T> presenter)
        {
            TabItem newTab = null;
            for (int i = 0; i < tabs.Items.Count; i++)
            {
                var existTab = tabs.Items[i] as TabItem;
                if (existTab.DataContext.Equals(presenter))
                {
                    tabs.Items.Remove(existTab);
                    newTab = existTab;
                    break;
                }
            }

            if (newTab == null)
            {
                newTab = new TabItem();
                var headerBinding = new Binding(presenter.TabHeaderPath);
                BindingOperations.SetBinding(newTab, TabItem.HeaderProperty, headerBinding);
                newTab.DataContext = presenter;
                newTab.Content = presenter.View;
            }

            tabs.Items.Insert(0, newTab);
            newTab.Focus();
        }

        public void RemoveTab<T>(PresenterBase<T> presenter)
        {
            for (int i = 0; i < tabs.Items.Count; i++)
            {
                var existTab = tabs.Items[i] as TabItem;
                if (existTab.DataContext.Equals(presenter))
                {
                    tabs.Items.Remove(existTab);
                    break;
                }
            }
        }
    }

}
