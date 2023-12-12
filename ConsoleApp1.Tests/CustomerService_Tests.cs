using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1.Tests
{
    /// <summary>
    /// Testklass f�r CustomerService.
    /// Inneh�ller tester f�r att validera funktionaliteten i CustomerService-klassen.
    /// </summary>
    [TestClass]
    public class CustomerServiceTests
    {
        /// <summary>
        /// Testar om l�gg till kund-metoden �kar antalet kunder korrekt.
        /// </summary>
        [TestMethod]
        public void AddCustomer_ShouldIncreaseCustomerCount()
        {
            // Arrange - F�rbered testet genom att skapa en instans av CustomerService och ett Customer-objekt.
            var service = new CustomerService();
            var customer = new Customer("Test", "Customer", "12345678", "test@example.com", "Test Address");

            // Act - Utf�r handlingen som ska testas, i det h�r fallet att l�gga till en kund.
            service.AddCustomer(customer);

            // Assert - Kontrollera att resultatet av handlingen �r det f�rv�ntade, i det h�r fallet att antalet kunder har �kat med 1.
            Assert.AreEqual(1, service.GetNumberOfCustomers());
        }
    }
}
