using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.WPF.Models;

namespace SimpleTrader.WPF.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase;
    public class ViewModelBase : ObservableObject
    {
    }
}
