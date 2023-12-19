using ConsoleApp1.Models;
using System.Collections.Generic;

namespace ConsoleApp1.Interfaces
{
    /// <summary>
    /// Definierar en uppsättning operationer för att hantera kunder.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Lägger till en ny kund i systemet.
        /// </summary>
        /// <param name="customer">Kunden som ska läggas till.</param>
        void AddCustomer(Customer customer);

        /// <summary>
        /// Tar bort en kund identifierad via e-post.
        /// </summary>
        /// <param name="email">E-postadressen för den kund som ska tas bort.</param>
        /// <returns>true om kunden framgångsrikt tas bort; annars false.</returns>
        bool RemoveCustomerByEmail(string email);

        /// <summary>
        /// Hämtar alla kunder.
        /// </summary>
        /// <returns>En samling av alla kunder.</returns>
        IEnumerable<Customer> GetAllCustomers();

        /// <summary>
        /// Hämtar en kund via deras e-post.
        /// </summary>
        /// <param name="email">E-postadressen för den kund som ska hämtas.</param>
        /// <returns>Kunden med den angivna e-postadressen, om den finns; annars null.</returns>
        Customer GetCustomerByEmail(string email);
    }
}
