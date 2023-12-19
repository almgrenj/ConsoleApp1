using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1;
using WpfApp1.ViewModels;

namespace WpfApp1.Tests
{
    /// <summary>
    /// Enhetstest för ContactListView.
    /// </summary>
    [TestClass]
    public class ContactListViewTests
    {
        /// <summary>
        /// Testfall för att kontrollera att ContactListView-initialiseringen skapar en ViewModel.
        /// </summary>
        [TestMethod]
        public void ContactListView_ShouldInitializeViewModel()
        {
            // Arrangera och utföra
            var window = new ContactListView();

            // Påstå
            Assert.IsNotNull(window.DataContext, "DataContext ska vara initialiserad.");
            Assert.IsInstanceOfType(window.DataContext, typeof(ContactListViewModel), "DataContext bör vara av typen ContactListViewModel.");
        }
    }
}
