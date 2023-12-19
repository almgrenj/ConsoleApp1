using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    public interface ICustomerService
    {
        void AddCustomer(Customer customer);
        bool RemoveCustomerByEmail(string email);
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerByEmail(string email);
    }
}
