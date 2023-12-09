using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Tests
{
    [TestClass]
    public class CustomerServiceTests
    {
        [TestMethod]
        public void AddCustomer_ShouldIncreaseCustomerCount()
        {
            // Arrange
            var service = new CustomerService();
            // Anpassar skapandet av ett Customer-objekt för att matcha den uppdaterade konstruktorn
            var customer = new Customer("Test", "Customer", "12345678", "test@example.com", "Test Address");

            // Act
            service.AddCustomer(customer);

            // Assert
            Assert.AreEqual(1, service.GetNumberOfCustomers());
        }
    }
}
