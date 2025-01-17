﻿using System;
using SimpleTrader.Domain.Services;
using SimpleTrader.FinancialModelingPrepAPI.Results;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;

namespace SimpleTrader.FinancialModelingPrepAPI.Services
{
    public class StockPriceService : IStockPriceService
    {
        private readonly FinancialModelingPrepHttpClientFactory _httpClientFactory;

        public StockPriceService(FinancialModelingPrepHttpClientFactory financialModelingPrepHttpClientFactory)
        {
            this._httpClientFactory = financialModelingPrepHttpClientFactory;
        }
        public async Task<double> GetPrice(string symbol)
        {
            using (var client = _httpClientFactory.CreateHttpClient())
            {
                var url = "stock/real-time-price/" + symbol;
                var result = await client.GetAsync<StockPriceResult>(url);

                if (result.Price == 0)
                {
                    throw new InvalidSymbolException(symbol);
                }

                return result.Price;
            }
        }
    }
}
