using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class MajorIndexService : IMajorIndexService
    {
        private readonly FinancialModelingPrepHttpClientFactory _httpClientFactory;

        public MajorIndexService(FinancialModelingPrepHttpClientFactory financialModelingPrepHttpClientFactory)
        {
            this._httpClientFactory = financialModelingPrepHttpClientFactory;
        }
        public async Task<MajorIndex> GetMajorIndex(MajorIndexType majorIndexType)
        {
            using (var client = _httpClientFactory.CreateHttpClient())
            {
                var url = "majors-indexes/" + GetUriSuffix(majorIndexType);
                var majorIndex = await client.GetAsync<MajorIndex>(url);
                majorIndex.Type = majorIndexType;

                return majorIndex;
            }
        }

        private string GetUriSuffix(MajorIndexType majorIndexType)
            {
                switch (majorIndexType)
                {
                    case MajorIndexType.DowJones:
                        return ".DJI";
                    case MajorIndexType.Nasdaq:
                        return ".IXIC";
                    case MajorIndexType.SP500:
                        return ".INX";
                    default:
                        throw new Exception("MajorIndexType does not have a suffix defined.");
                }
            }
        }
    }
