using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public bool RemoveCustomerByEmail(string email)
        {
            var customer = customers.FirstOrDefault(c => c.Email == email);
            if (customer != null)
            {
                customers.Remove(customer);
                return true;
            }
            return false;
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return customers.FirstOrDefault(c => c.Email == email);
        }

        public int GetNumberOfCustomers()
        {
            return customers.Count;
        }
    }
}
