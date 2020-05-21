using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Model
{
    [Serializable]
    public class Contact : Notifier
    {
        private Address _address = new Address();
        private string _firstName;
        private string _lastName;
        private string _cellPhone;
        private string _homePhone;
        private string _officePhone;
        private Guid _id = Guid.Empty;
        private string _imagePath;
        private string _jobTitle;
        private string _organization;
        private string _primaryEmail;
        private string _secondEmail;


        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string ImagePath
        {
            get { return _imagePath; }
            set
            {
                _imagePath = value;
                OnPropertyChanged(nameof(ImagePath));
            }
        }
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged(nameof(FirstName));
                OnPropertyChanged(nameof(LookupName));
            }
        }
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged(nameof(LastName));
                OnPropertyChanged(nameof(LookupName));
            }
        }
        public string Organization
        {
            get { return _organization; }
            set
            {
                _organization = value;
                OnPropertyChanged(nameof(Organization));
            }
        }
        public string JobTitle
        {
            get { return _jobTitle; }
            set
            {
                _jobTitle = value;
                OnPropertyChanged(nameof(JobTitle));
            }
        }
        public string OfficePhone
        {
            get { return _officePhone; }
            set
            {
                _officePhone = value;
                OnPropertyChanged(nameof(OfficePhone));
            }
        }
        public string CellPhone
        {
            get { return _cellPhone; }
            set
            {
                _cellPhone = value;
                OnPropertyChanged(nameof(CellPhone));
            }
        }
        public string HomePhone
        {
            get { return _homePhone; }
            set
            {
                _homePhone = value;
                OnPropertyChanged(nameof(HomePhone));
            }
        }
        public string PrimaryEmail
        {
            get { return _primaryEmail; }
            set
            {
                _primaryEmail = value;
                OnPropertyChanged(nameof(PrimaryEmail));
            }
        }
        public string SecondEmail
        {
            get { return _secondEmail; }
            set
            {
                _secondEmail = value;
                OnPropertyChanged(nameof(SecondEmail));
            }
        }

        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public string LookupName
        {
            get { return $"{_lastName}, {_firstName}"; }
        }

        public override string ToString()
        {
            return LookupName;
        }
        public override bool Equals(object obj)
        {
            var other = obj as Contact;

            return other != null && other.Id == Id;
        }
    }
}
