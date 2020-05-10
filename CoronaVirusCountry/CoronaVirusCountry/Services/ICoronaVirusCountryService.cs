using System.Collections.Generic;
using System.Threading.Tasks;
using CoronaVirusCountry.Models;

namespace CoronaVirusCountry.Services
{
    public interface ICoronaVirusCountryService
    {
        Task<List<CoronaVirusCoutryModel>> GetTopCases(int amountOfCountries = 10);
    }
}