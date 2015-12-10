using CustomerRegister.DB;
using CustomerRegister.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegister.Repository
{
    public class CustomerRepository
    {
        private CustomerDatabase _db;
        public CustomerRepository()
        {
            _db = new CustomerDatabase();
            
            if (!_db.Customers.Any())
            {
                var customer = new Customer
                {
                    FirstName = "Islam",
                    LastName = "Alzobaydee",
                    Email = "Email@hotmailcom",
                    City = "Stockholm",
                    Address = "gata1",
                    BirthDate = new DateTime(1988, 7, 27),
                    Id = Guid.NewGuid(),
                    SubscribedNewsLetter = true,
                    Notes = "I think I'm superman",
                    Phone = "1234567891",
                    Type = CustomerType.Private,
                    ZipCode = "0046"
                };
                _db.Customers.Add(customer);
                _db.SaveChanges();
            }
        }

        public void Save(Customer customer)
        {
            if (customer != null)
            {
                if (_db.Customers.Any(c => c.Id == customer.Id))
                {
                    var cus = _db.Customers.FirstOrDefault(c => c.Id == customer.Id);
                    cus.FirstName = customer.FirstName;
                    cus.LastName = customer.LastName;
                    cus.CompanyName = customer.CompanyName;
                    cus.Phone = customer.Phone;
                    cus.Notes = customer.Notes;
                    cus.Email = customer.Email;
                    cus.City = customer.City;
                    cus.Address = customer.Address;
                    cus.SubscribedNewsLetter = customer.SubscribedNewsLetter;
                    cus.Type = customer.Type;
                    cus.ZipCode = customer.ZipCode;
                    cus.BirthDate = customer.BirthDate;
                }
                else
                {
                    _db.Customers.Add(customer);
                }

                _db.SaveChanges();
            }
        }

        public void Remove(Guid id)
        {
            var customer = _db.Customers.Find(id);
            if (customer != null)
            {
                _db.Customers.Remove(customer);
                _db.SaveChanges();
            }
        }

        public List<Customer> GetBySearch(string email, string phone)
        {
            var result = _db.Customers.AsQueryable();

            if (email != string.Empty)
                result = result.Where(c => c.Email.Contains(email));

            if (phone != string.Empty)
                result = result.Where(c => c.Phone.Contains(phone));

            return result.ToList();
        }

        public Customer Get(Guid id)
        {
            return _db.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IList<Customer> GetAll()
        {
            return _db.Customers.ToList();
        }


    }
}
