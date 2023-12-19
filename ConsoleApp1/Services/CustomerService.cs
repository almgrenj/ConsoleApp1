using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// En tjänstklass som hanterar kundobjekt och deras operationer.
    /// </summary>
    public class CustomerService : ICustomerService
    {
        private List<Customer> customers = new List<Customer>();

        /// <summary>
        /// Lägger till en ny kund i listan.
        /// </summary>
        /// <param name="customer">Kunden som ska läggas till.</param>
        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        /// <summary>
        /// Tar bort en kund med den angivna e-postadressen från listan.
        /// </summary>
        /// <param name="email">E-postadressen för kunden som ska tas bort.</param>
        /// <returns>True om kunden togs bort, annars false.</returns>
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

        /// <summary>
        /// Hämtar alla kunder i listan.
        /// </summary>
        /// <returns>En uppsättning av alla kunder.</returns>
        public IEnumerable<Customer> GetAllCustomers()
        {
            return customers;
        }

        /// <summary>
        /// Hämtar en kund med den angivna e-postadressen.
        /// </summary>
        /// <param name="email">E-postadressen för den önskade kunden.</param>
        /// <returns>Kunden med matchande e-postadress eller null om ingen hittades.</returns>
        public Customer GetCustomerByEmail(string email)
        {
            return customers.FirstOrDefault(c => c.Email == email);
        }

        /// <summary>
        /// Hämtar antalet kunder i listan.
        /// </summary>
        /// <returns>Antalet kunder i listan.</returns>
        public int GetNumberOfCustomers()
        {
            return customers.Count;
        }
    }
}
