using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using CoronaVirusCountry.Models;
using Newtonsoft.Json;

namespace CoronaVirusCountry.Services
{
    public class CoronaVirusCountryService : ICoronaVirusCountryService
    {
        private const string CORONAVIRUS_URL = "https://corona.lmao.ninja/v2/countries?sort=cases";

        public async Task<List<CoronaVirusCoutryModel>> GetTopCases(int amountOfCountries = 10)
        {
            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(CORONAVIRUS_URL);
                var content = await res.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<List<CoronaVirusResponse>>(content);

                return result.Select(r => new CoronaVirusCoutryModel()
                {
                    Country = r.Country,
                    Cases = r.Cases,
                    FlagUri = r.CountryInfo.Flag
                }).Take(amountOfCountries).ToList();
            }
        }
    }

    public class CoronaVirusResponse
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public InnerCountryInfo CountryInfo { get; set; }

        public class InnerCountryInfo
        {
            public string Flag { get; set; }
        }
    }
}
