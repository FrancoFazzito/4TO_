using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    //Value Object
    public class ClientName
    {
        private string _value;

        private void EnsureHasMoreThan5Characters(string value)
        {
            if (value.Length >= 5)
                throw new Exception("Name should have more than 5 characters");
        }

        private void EnsureHasLessThan15Characters(string value)
        {
            if (value.Length <= 15)
                throw new Exception("Name should have less than 15 characters");
        }

        public string Value
        {
            get => _value;
            set
            {
                EnsureHasLessThan15Characters(value);
                EnsureHasMoreThan5Characters(value);
                _value = value;
            }
        }
    }
}
