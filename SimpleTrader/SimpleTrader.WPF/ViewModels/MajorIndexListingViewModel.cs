using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.WPF.ViewModels
{
    public class MajorIndexListingViewModel : ViewModelBase
    {
        private readonly IMajorIndexService _majorIndexService;

        private MajorIndex _dowJones;
        public MajorIndex DowJones
        {
            get => _dowJones;
            set
            {
                _dowJones = value;
                OnPropertyChanged(nameof(DowJones));
            }
        }

        private MajorIndex _nasdaq;

        public MajorIndex Nasdaq
        {
            get { return _nasdaq; }
            set
            {
                _nasdaq = value;
                OnPropertyChanged(nameof(Nasdaq));
            }
        }


        private MajorIndex _sp500;

        public MajorIndex SP500
        {
            get { return _sp500; }
            set
            {
                _sp500 = value;
                OnPropertyChanged(nameof(SP500));
            }
        }



        public MajorIndexListingViewModel(IMajorIndexService majorIndexService)
        {
            _majorIndexService = majorIndexService;
        }

        public static MajorIndexListingViewModel LoadMajorIndexViewModel(IMajorIndexService majorIndexService)
        {
            var model = new MajorIndexListingViewModel(majorIndexService);
            model.LoadMajorIndexes();

            return model;
        }

        private void LoadMajorIndexes()
        {
            _majorIndexService.GetMajorIndex(MajorIndexType.DowJones).ContinueWith(t =>
            {
                if (t.Exception == null)
                {
                    DowJones = t.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.Nasdaq).ContinueWith(t =>
            {
                if (t.Exception == null)
                {
                    Nasdaq = t.Result;
                }
            });

            _majorIndexService.GetMajorIndex(MajorIndexType.SP500).ContinueWith(t =>
            {
                if (t.Exception == null)
                {
                    SP500 = t.Result;
                }
            });
        }
    }
}
