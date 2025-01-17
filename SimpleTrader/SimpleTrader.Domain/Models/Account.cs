﻿using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.Domain.Models
{
    public class Account : EntityBase
    {
        public Account()
        {
            this.AssetTransactions = new List<AssetTransaction>();
        }
        public User AccountHolder { get; set; }
        public double Balance { get; set; }
        public ICollection<AssetTransaction> AssetTransactions { get; set; }
    }
}
