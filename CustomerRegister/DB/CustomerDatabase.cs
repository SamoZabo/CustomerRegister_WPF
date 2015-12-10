using CustomerRegister.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerRegister.DB
{
    public class CustomerDatabase : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }
}
