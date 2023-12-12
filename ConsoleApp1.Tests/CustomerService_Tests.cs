using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Tests
{
    /// <summary>
    /// Testklass för CustomerService.
    /// Innehåller tester för att validera funktionaliteten i CustomerService-klassen.
    /// </summary>
    [TestClass]
    public class CustomerServiceTests
    {
        /// <summary>
        /// Testar om lägg till kund-metoden ökar antalet kunder korrekt.
        /// </summary>
        [TestMethod]
        public void AddCustomer_ShouldIncreaseCustomerCount()
        {
            // Arrange - Förbered testet genom att skapa en instans av CustomerService och ett Customer-objekt.
            var service = new CustomerService();
            var customer = new Customer("Test", "Customer", "12345678", "test@example.com", "Test Address");

            // Act - Utför handlingen som ska testas, i det här fallet att lägga till en kund.
            service.AddCustomer(customer);

            // Assert - Kontrollera att resultatet av handlingen är det förväntade, i det här fallet att antalet kunder har ökat med 1.
            Assert.AreEqual(1, service.GetNumberOfCustomers());
        }
    }
}
