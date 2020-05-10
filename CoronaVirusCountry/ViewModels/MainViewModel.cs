using CoronaVirusCountry.Services;

namespace CoronaVirusCountry.ViewModels
{
    public class MainViewModel
    {
        public CoronaVirusCountriesChartViewModel CoronaVirusCountriesChartViewModel { get; set; }

        public MainViewModel()
        {
            ICoronaVirusCountryService service = new CoronaVirusCountryService();
            CoronaVirusCountriesChartViewModel =
                CoronaVirusCountriesChartViewModel.LoadViewModel(service);
        }
    }
}
