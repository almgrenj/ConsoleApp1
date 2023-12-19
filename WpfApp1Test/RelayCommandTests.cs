using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WpfApp1.Commands;

namespace WpfApp1.Tests
{
    /// <summary>
    /// Enhetstest för RelayCommand.
    /// </summary>
    [TestClass]
    public class RelayCommandTests
    {
        private bool isExecuted;
        private bool canExecute;

        /// <summary>
        /// Metod som körs före varje testfall för att ställa in testmiljön.
        /// </summary>
        [TestInitialize]
        public void Setup()
        {
            isExecuted = false;
            canExecute = true;
        }

        /// <summary>
        /// Testfall för att kontrollera att RelayCommand utför en åtgärd.
        /// </summary>
        [TestMethod]
        public void RelayCommand_ShouldExecute()
        {
            // Arrangera
            var command = new RelayCommand(() => isExecuted = true, () => canExecute);

            // Utför
            command.Execute(null);

            // Påstå
            Assert.IsTrue(isExecuted, "Kommandot bör sätta isExecuted till true.");
        }

        /// <summary>
        /// Testfall för att kontrollera att RelayCommand respekterar CanExecute.
        /// </summary>
        [TestMethod]
        public void RelayCommand_ShouldRespectCanExecute()
        {
            // Arrangera
            var command = new RelayCommand(() => isExecuted = true, () => canExecute);
            canExecute = false;

            // Utför och påstå
            Assert.IsFalse(command.CanExecute(null), "Kommandot bör inte vara exekverbart.");
        }
    }
}
