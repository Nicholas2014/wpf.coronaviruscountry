using System;
using System.Collections.Generic;
using System.Text;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.Domain.Models
{
    public class Asset : EntityBase
    {
        public string Symbol { get; set; }
        public double PricePerShare { get; set; }
    }
}
