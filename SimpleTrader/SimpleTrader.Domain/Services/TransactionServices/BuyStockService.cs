using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SimpleTrader.Domain.Exceptions;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public class BuyStockService : IBuyStockService
    {
        private readonly IStockPriceService _stockPriceService;
        private readonly IDataService<Account> _accountService;

        public BuyStockService(IStockPriceService stockPriceService, IDataService<Account> accountService)
        {
            _stockPriceService = stockPriceService;
            _accountService = accountService;
        }

        public async Task<Account> BuyStock(Account buyer, string symbol, int shares)
        {
            var stockPrice = await _stockPriceService.GetPrice(symbol);
            var transactionPrice = stockPrice * shares;

            if (transactionPrice > buyer.Balance)
            {
                throw new InSufficientFundsException(buyer.Balance, transactionPrice);
            }

            var transaction = new AssetTransaction()
            {
                Account = buyer,
                Asset = new Asset() { Symbol = symbol, PricePerShare = stockPrice },
                DateProcessed = DateTime.Now,
                IsPurchase = true,
                Shares = shares
            };

            buyer.AssetTransactions.Add(transaction);
            buyer.Balance -= stockPrice * shares;

            await _accountService.Update(buyer.Id, buyer);

            return buyer;
        }
    }
}
