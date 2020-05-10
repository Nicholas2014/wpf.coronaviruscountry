using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CoronaVirusCountry.Annotations;
using CoronaVirusCountry.Services;
using LiveCharts;

namespace CoronaVirusCountry.ViewModels
{
    public class CoronaVirusCountriesChartViewModel : INotifyPropertyChanged
    {
        private const int AMOUNT_OF_COUNTRIES = 10;
        private readonly ICoronaVirusCountryService _coronaVirusCountryService;


        public ChartValues<int> _coronaVirusCountryCaseCounts { get; set; }

        public ChartValues<int> CoronaVirusCountryCaseCounts
        {
            get { return _coronaVirusCountryCaseCounts; }
            set
            {
                _coronaVirusCountryCaseCounts = value;
                OnPropertyChanged(nameof(CoronaVirusCountryCaseCounts));
            }
        }

        public string[] _coronaVirusCountryNames { get; set; }
        public string[] CoronaVirusCountryNames
        {
            get
            {
                return _coronaVirusCountryNames;
            }
            set
            {
                _coronaVirusCountryNames = value;
                OnPropertyChanged(nameof(CoronaVirusCountryNames));
            }
        }

        public CoronaVirusCountriesChartViewModel(ICoronaVirusCountryService coronaVirusCountryService)
        {
            _coronaVirusCountryService = coronaVirusCountryService;
        }

        public static CoronaVirusCountriesChartViewModel LoadViewModel(
            ICoronaVirusCountryService coronaVirusCountryService, Action<Task> onLoaded = null)
        {
            var vm = new CoronaVirusCountriesChartViewModel(coronaVirusCountryService);
            vm.Load().ContinueWith(t => onLoaded?.Invoke(t));

            return vm;
        }

        private async Task Load()
        {
            var list = await _coronaVirusCountryService.GetTopCases(AMOUNT_OF_COUNTRIES);
            this.CoronaVirusCountryCaseCounts = new ChartValues<int>(list.Select(r => r.Cases).ToList());
            this.CoronaVirusCountryNames = list.Select(r => r.Country).ToArray();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
