using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    /// <summary>
    /// Definierar ett gränssnitt för tjänster som hanterar kundinformation.
    /// Detta gränssnitt specificerar de metoder som en CustomerService-klass bör implementera.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// Lägger till en kund i tjänsten.
        /// </summary>
        /// <param name="customer">Kunden som ska läggas till.</param>
        void AddCustomer(Customer customer);

        /// <summary>
        /// Returnerar antalet kunder som hanteras av tjänsten.
        /// </summary>
        /// <returns>Antalet kunder.</returns>
        int GetNumberOfCustomers();
    }
}
