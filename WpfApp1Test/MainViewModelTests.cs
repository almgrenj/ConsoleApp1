using Microsoft.VisualStudio.TestTools.UnitTesting;
using WpfApp1.ViewModels;

namespace WpfApp1.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void MainViewModel_ShouldInitializeCommands()
        {
            // Arrange & Act
            var viewModel = new MainViewModel();

            // Assert
            Assert.IsNotNull(viewModel.OpenContactListViewCommand, "OpenContactListViewCommand should be initialized.");
        }

    }
}
