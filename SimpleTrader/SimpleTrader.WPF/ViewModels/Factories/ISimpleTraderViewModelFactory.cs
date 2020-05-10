using SimpleTrader.WPF.Models;
using SimpleTrader.WPF.State.Navigators;

namespace SimpleTrader.WPF.ViewModels.Factories
{
    public interface ISimpleTraderViewModelFactory<T> where T : ObservableObject
    {
        T CreateViewModel();
    }
}