using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegister.Model
{
    public class Customer : INotifyPropertyChanged
    {

        public Customer()
        {
            BirthDate = DateTime.Now;
            SubscribedNewsLetter = false;
        }

        public Customer(Customer _customer, Guid id)
        {
            Id = id;
            FirstName = _customer.FirstName;
            Address = _customer.Address;
            BirthDate = _customer.BirthDate;
            City = _customer.City;
            CompanyName = _customer.CompanyName;
            Email = _customer.Email;
            LastName = _customer.LastName;
            Notes = _customer.Notes;
            Phone = _customer.Phone;
            SubscribedNewsLetter = _customer.SubscribedNewsLetter;
            Type = _customer.Type;
            ZipCode = _customer.ZipCode;
        }

        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private CustomerType _type;
        public CustomerType Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }


        private string _companyName;
        public string CompanyName
        {
            get { return _companyName; }
            set
            {
                _companyName = value;
                OnPropertyChanged("CompanyName");
            }
        }

        private string _adress;
        public string Address
        {
            get { return _adress; }
            set
            {
                _adress = value;
                OnPropertyChanged("Address");
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get { return _zipCode; }
            set
            {
                _zipCode = value;
                OnPropertyChanged("ZipCode");
            }
        }


        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged("City");
            }
        }

        private bool _subscribedNewsLetter;
        public bool SubscribedNewsLetter
        {
            get { return _subscribedNewsLetter; }
            set
            {
                _subscribedNewsLetter = value;
                OnPropertyChanged("SubscribedNewsLetter");
            }
        }


        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }


        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged("Phone");
            }
        }

        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                OnPropertyChanged("Notes");
            }
        }


        private DateTime _birthDate;
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?
                .Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public enum CustomerType
    {
        Company,
        Private
    }

}
