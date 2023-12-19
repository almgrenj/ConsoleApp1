using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.ViewModels;
using ConsoleApp1.Models;
using System.Linq;

namespace WpfApp1.Tests
{
    /// <summary>
    /// Enhetstester för ContactListViewModel.
    /// </summary>
    [TestClass]
    public class ContactListViewModelTests
    {
        private ContactListViewModel _viewModel;

        /// <summary>
        /// Metod som körs före varje testfall för att ställa in testmiljön.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            _viewModel = new ContactListViewModel();
        }

        /// <summary>
        /// Testfall för att lägga till en kund i samlingen.
        /// </summary>
        [TestMethod]
        public void AddCustomer_ShouldAddCustomerToCollection()
        {
            // Arrangera
            var newCustomer = new Customer("John", "Doe", "555-1234", "john.doe@example.com", "123 Main St");

            // Utför
            _viewModel.AddCustomerCommand.Execute(newCustomer);

            // Påstå
            var customerInCollection = _viewModel.Customers.FirstOrDefault(c => c.Email == newCustomer.Email);
            Assert.IsNotNull(customerInCollection, "Kunden bör läggas till i samlingen.");
            Assert.AreEqual(newCustomer.FirstName, customerInCollection.FirstName, "Förnamn bör vara samma.");
            Assert.AreEqual(newCustomer.LastName, customerInCollection.LastName, "Efternamn bör vara samma.");
            Assert.AreEqual(newCustomer.PhoneNumber, customerInCollection.PhoneNumber, "Telefonnummer bör vara samma.");
            Assert.AreEqual(newCustomer.Email, customerInCollection.Email, "E-postadresser bör vara samma.");
            Assert.AreEqual(newCustomer.Address, customerInCollection.Address, "Adresser bör vara samma.");
        }

        /// <summary>
        /// Testfall för att uppdatera kunduppgifter.
        /// </summary>
        [TestMethod]
        public void EditCustomer_ShouldUpdateCustomerDetails()
        {
            // Arrangera
            var customer = new Customer("Jane", "Doe", "555-6789", "jane.doe@example.com", "456 Main St");
            _viewModel.Customers.Add(customer);
            _viewModel.SelectedCustomer = customer;

            var updatedCustomer = new Customer("Jane", "Smith", "555-6789", "jane.smith@example.com", "789 Main St");

            // Utför
            _viewModel.EditCustomerCommand.Execute(updatedCustomer);

            // Påstå
            var editedCustomer = _viewModel.Customers.FirstOrDefault(c => c.Email == updatedCustomer.Email);
            Assert.IsNotNull(editedCustomer, "Kunden bör uppdateras i samlingen.");
            Assert.AreEqual(updatedCustomer.LastName, editedCustomer.LastName, "Efternamn bör uppdateras.");
            // Lägg till påståenden för andra fält vid behov
        }

        /// <summary>
        /// Testfall för att ta bort en kund från samlingen.
        /// </summary>
        [TestMethod]
        public void DeleteCustomer_ShouldRemoveCustomerFromCollection()
        {
            // Arrangera
            var customer = new Customer("Jane", "Doe", "555-6789", "jane.doe@example.com", "456 Main St");
            _viewModel.Customers.Add(customer);
            _viewModel.SelectedCustomer = customer;

            // Utför
            _viewModel.DeleteCustomerCommand.Execute(null);

            // Påstå
            var deletedCustomer = _viewModel.Customers.FirstOrDefault(c => c.Email == customer.Email);
            Assert.IsNull(deletedCustomer, "Kunden bör tas bort från samlingen.");
        }
    }
}
