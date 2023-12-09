using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System.Collections.Generic;

namespace ConsoleApp1.Services
{
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers = new List<Customer>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public int GetNumberOfCustomers()
        {
            return customers.Count;
        }
    }
}
