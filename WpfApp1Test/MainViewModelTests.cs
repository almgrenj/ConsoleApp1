using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.ViewModels;

namespace WpfApp1.Tests
{
    /// <summary>
    /// Enhetstest för MainViewModel.
    /// </summary>
    [TestClass]
    public class MainViewModelTests
    {
        /// <summary>
        /// Testfall för att kontrollera att MainViewModel-initialiseringen skapar kommandon.
        /// </summary>
        [TestMethod]
        public void MainViewModel_ShouldInitializeCommands()
        {
            // Arrangera och utföra
            var viewModel = new MainViewModel();

            // Påstå
            Assert.IsNotNull(viewModel.OpenContactListViewCommand, "OpenContactListViewCommand ska vara initialiserad.");
        }
    }
}
