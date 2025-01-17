﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using SimpleTrader.Domain.Services;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Accounts;

namespace SimpleTrader.WPF.ViewModels
{
    public class BuyViewModel : ViewModelBase
    {

        private string _symbol;

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
                OnPropertyChanged(nameof(Symbol));
            }
        }


        private string _searchSymbolResult = string.Empty;

        public string SearchSymbolResult
        {
            get { return _searchSymbolResult; }
            set
            {
                _searchSymbolResult = value;
                OnPropertyChanged(nameof(SearchSymbolResult));
            }
        }



        private double _stockPrice;

        public double StockPrice
        {
            get { return _stockPrice; }
            set
            {
                _stockPrice = value;
                OnPropertyChanged(nameof(StockPrice));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }


        private int _sharesToBuy;

        public int SharesToBuy
        {
            get { return _sharesToBuy; }
            set
            {
                _sharesToBuy = value;
                OnPropertyChanged(nameof(SharesToBuy));
                OnPropertyChanged(nameof(TotalPrice));
            }
        }

        public double TotalPrice => SharesToBuy * StockPrice;

        public ICommand SearchSymbolCommand { get; set; }
        public ICommand BuyStockCommand { get; set; }

        public BuyViewModel(IStockPriceService stockPriceService, IBuyStockService buyStockService,IAccountStore accountStore)
        {
            SearchSymbolCommand = new SearchSymbolCommand(this, stockPriceService);
            BuyStockCommand = new BuyStockCommand(this, buyStockService,accountStore);            
        }
    }
}
