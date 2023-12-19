using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.ViewModels;
using ConsoleApp1.Models; // Using the Customer class from ConsoleApp1.Models
using System.Linq;

namespace WpfApp1.Tests
{
    [TestClass]
    public class ContactListViewModelTests
    {
        private ContactListViewModel _viewModel;

        [TestInitialize]
        public void Setup()
        {
            _viewModel = new ContactListViewModel();
        }

        [TestMethod]
        public void AddCustomer_ShouldAddCustomerToCollection()
        {
            // Arrange
            var newCustomer = new Customer("John", "Doe", "555-1234", "john.doe@example.com", "123 Main St");

            // Act
            _viewModel.AddCustomerCommand.Execute(newCustomer);

            // Assert
            var customerInCollection = _viewModel.Customers.FirstOrDefault(c => c.Email == newCustomer.Email);
            Assert.IsNotNull(customerInCollection, "The customer should be added to the collection.");
            Assert.AreEqual(newCustomer.FirstName, customerInCollection.FirstName, "First names should be the same.");
            Assert.AreEqual(newCustomer.LastName, customerInCollection.LastName, "Last names should be the same.");
            Assert.AreEqual(newCustomer.PhoneNumber, customerInCollection.PhoneNumber, "Phone numbers should be the same.");
            Assert.AreEqual(newCustomer.Email, customerInCollection.Email, "Email addresses should be the same.");
            Assert.AreEqual(newCustomer.Address, customerInCollection.Address, "Addresses should be the same.");
        }

        [TestMethod]
        public void EditCustomer_ShouldUpdateCustomerDetails()
        {
            // Arrange
            var customer = new Customer("Jane", "Doe", "555-6789", "jane.doe@example.com", "456 Main St");
            _viewModel.Customers.Add(customer);
            _viewModel.SelectedCustomer = customer;

            var updatedCustomer = new Customer("Jane", "Smith", "555-6789", "jane.smith@example.com", "789 Main St");

            // Act
            _viewModel.EditCustomerCommand.Execute(updatedCustomer);

            // Assert
            var editedCustomer = _viewModel.Customers.FirstOrDefault(c => c.Email == updatedCustomer.Email);
            Assert.IsNotNull(editedCustomer, "The customer should be updated in the collection.");
            Assert.AreEqual(updatedCustomer.LastName, editedCustomer.LastName, "Last names should be updated.");
            // Add assertions for other fields as needed
        }

        [TestMethod]
        public void DeleteCustomer_ShouldRemoveCustomerFromCollection()
        {
            // Arrange
            var customer = new Customer("Jane", "Doe", "555-6789", "jane.doe@example.com", "456 Main St");
            _viewModel.Customers.Add(customer);
            _viewModel.SelectedCustomer = customer;

            // Act
            _viewModel.DeleteCustomerCommand.Execute(null);

            // Assert
            var deletedCustomer = _viewModel.Customers.FirstOrDefault(c => c.Email == customer.Email);
            Assert.IsNull(deletedCustomer, "The customer should be removed from the collection.");
        }


    }
}
