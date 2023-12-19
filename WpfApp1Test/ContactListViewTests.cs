using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using WpfApp1.ViewModels;

namespace WpfApp1.Tests
{
    [TestClass]
    public class ContactListViewTests
    {
        [TestMethod]
        public void ContactListView_ShouldInitializeViewModel()
        {
            // Arrange & Act
            var window = new ContactListView();

            // Assert
            Assert.IsNotNull(window.DataContext, "DataContext should be initialized.");
            Assert.IsInstanceOfType(window.DataContext, typeof(ContactListViewModel), "DataContext should be of type ContactListViewModel.");
        }

    }
}
