using System;
using System.Collections.Generic;

namespace Domain
{
    public class ClientWallet
    {
        private double _amount;
        private string _currency;
        private readonly ICollection<string> _validCurrencies = new List<string>();

        public ClientWallet()
        {
            _validCurrencies.Add("USD");
            _validCurrencies.Add("ARS");
            _validCurrencies.Add("YEN");
        }

        private void EnsureValidCurrency(string value)
        {
            if (_validCurrencies.Contains(value))
                throw new Exception($"The currency {value} is not valid");
        }

        private void EnsureNotNegativeAmount(double value)
        {
            if (value < 0)
                throw new Exception("The amount cannot be negative");
        }

        public double Amount 
        { 
            get => _amount;
            set
            {
                EnsureNotNegativeAmount(value);
                _amount = value;
            }
        }

        public string Currency 
        {
            get => _currency;
            set
            {
                EnsureValidCurrency(value);
                _currency = value;
            }
        }
    }
}