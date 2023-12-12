using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System.Collections.Generic;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// En tjänst som erbjuder funktionalitet för att hantera kundinformation.
    /// Implementerar ICustomerService-gränssnittet.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers = new List<Customer>();

        /// <summary>
        /// Lägger till en ny kund till listan av kunder.
        /// </summary>
        /// <param name="customer">Kunden som ska läggas till.</param>
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        /// <summary>
        /// Returnerar det totala antalet kunder i listan.
        /// </summary>
        /// <returns>Antalet kunder som en int.</returns>
        public int GetNumberOfCustomers()
        {
            return customers.Count;
        }
    }
}
