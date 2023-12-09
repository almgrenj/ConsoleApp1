using ConsoleApp1.Models;

namespace ConsoleApp1.Interfaces
{
    public interface ICustomerService
    {
        // Definiera metoderna som ska ingå i gränssnittet
        void AddCustomer(Customer customer);
        int GetNumberOfCustomers();
    }
}
