namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {
        public HomeViewModel(AssetSummaryViewModel assetSummaryViewModel,MajorIndexListingViewModel majorIndexListingViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
            AssetSummaryViewModel = assetSummaryViewModel;
        }

        public MajorIndexListingViewModel MajorIndexListingViewModel { get;  }
        public AssetSummaryViewModel AssetSummaryViewModel { get; }
    }
}
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                         