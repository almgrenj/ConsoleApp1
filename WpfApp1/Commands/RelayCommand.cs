using System;
using System.Windows.Input;

namespace WpfApp1.Commands
{
    /// <summary>
    /// En generisk implementation av ICommand för användning i WPF-applikationer.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// Initerar en ny instans av RelayCommand-klassen.
        /// </summary>
        /// <param name="execute">Åtgärden som ska utföras när kommandot anropas.</param>
        /// <param name="canExecute">En funktion som avgör om kommandot kan utföras (valfri).</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>
        /// Uppstår när förändringar inträffar som påverkar om kommandot ska utföras.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Avgör om kommandot kan utföras i sitt nuvarande tillstånd.
        /// </summary>
        /// <param name="parameter">Parametern för kommandot (används inte).</param>
        /// <returns>Sant om kommandot kan utföras, annars falskt.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// Utför kommandot.
        /// </summary>
        /// <param name="parameter">Parametern för kommandot (används inte).</param>
        public void Execute(object parameter)
        {
            _execute();
        }

        /// <summary>
        /// Meddelar att kommandots förmåga att utföras har ändrats.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }
    }
}
