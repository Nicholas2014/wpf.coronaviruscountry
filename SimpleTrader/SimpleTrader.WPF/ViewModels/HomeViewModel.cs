namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
        }

        public MajorIndexListingViewModel MajorIndexListingViewModel { get; set; }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         