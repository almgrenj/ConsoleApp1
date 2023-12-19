using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1.Commands;

namespace WpfApp1.Tests
{
    [TestClass]
    public class RelayCommandTests
    {
        private bool isExecuted;
        private bool canExecute;

        [TestInitialize]
        public void Setup()
        {
            isExecuted = false;
            canExecute = true;
        }

        [TestMethod]
        public void RelayCommand_ShouldExecute()
        {
            // Arrange
            var command = new RelayCommand(() => isExecuted = true, () => canExecute);

            // Act
            command.Execute(null);

            // Assert
            Assert.IsTrue(isExecuted, "Command should set isExecuted to true.");
        }

        [TestMethod]
        public void RelayCommand_ShouldRespectCanExecute()
        {
            // Arrange
            var command = new RelayCommand(() => isExecuted = true, () => canExecute);
            canExecute = false;

            // Act & Assert
            Assert.IsFalse(command.CanExecute(null), "Command should not be executable.");
        }
    }
}
