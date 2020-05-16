using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticChangeNotification
{
    class Person
    {
        public event EventHandler FirstNameChanged;
        private void OnFirstNameChanged()
        {
            FirstNameChanged?.Invoke(this, EventArgs.Empty);
        }
        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnFirstNameChanged();
            }
        }

    }
}
