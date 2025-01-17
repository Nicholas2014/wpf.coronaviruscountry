﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Model
{
    [Serializable]
    public class Address : Notifier
    {
        private string _city;
        private string _country;
        private string _line1;
        private string _line2;
        private string _state;
        private string _zip;

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged(nameof(Country));
            }
        }
        public string Line1
        {
            get { return _line1; }
            set
            {
                _line1 = value;
                OnPropertyChanged(nameof(Line1));
            }
        }
        public string Line2
        {
            get { return _line2; }
            set
            {
                _line2 = value;
                OnPropertyChanged(nameof(Line2));
            }
        }
        public string State
        {
            get { return _state; }
            set
            {
                _state = value;
                OnPropertyChanged(nameof(State));
            }
        }
        public string Zip
        {
            get { return _zip; }
            set
            {
                _zip = value;
                OnPropertyChanged(nameof(Zip));
            }
        }
    }
}
