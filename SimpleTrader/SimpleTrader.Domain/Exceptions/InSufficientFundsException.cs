﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTrader.Domain.Exceptions
{
    public class InSufficientFundsException : Exception
    {
        public double AccountBalance { get; set; }
        public double RequiredBalance { get; set; }

        public InSufficientFundsException(double accountBalance, double requiredBalance)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public InSufficientFundsException(double accountBalance, double requiredBalance, string message) : base(message)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }

        public InSufficientFundsException(double accountBalance, double requiredBalance, string message, Exception innerException) : base(message, innerException)
        {
            AccountBalance = accountBalance;
            RequiredBalance = requiredBalance;
        }
    }
}