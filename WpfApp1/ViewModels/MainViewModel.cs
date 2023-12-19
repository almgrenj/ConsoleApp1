using System.ComponentModel;
using System.Windows.Input;
using WpfApp1.Commands;

namespace WpfApp1.ViewModels
{
    /// <summary>
    /// ViewModel för huvudfönstret.
    /// </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Kommando för att öppna kontaktlistan.
        /// </summary>
        public ICommand OpenContactListViewCommand { get; private set; }

        /// <summary>
        /// Skapar en ny instans av MainViewModel.
        /// </summary>
        public MainViewModel()
        {
            // Skapa ett kommando för att öppna kontaktlistan
            OpenContactListViewCommand = new RelayCommand(OpenContactListView);
        }

        /// <summary>
        /// Metod som öppnar kontaktlistan när kommandot körs.
        /// </summary>
        private void OpenContactListView()
        {
            // Öppna kontaktlistan genom att skapa och visa ett nytt ContactListView-fönster
            ContactListView contactListView = new ContactListView();
            contactListView.Show();
        }

        /// <summary>
        /// Hjälpermetod för att meddela att en egenskap har ändrats.
        /// </summary>
        /// <param name="propertyName">Namnet på den ändrade egenskapen.</param>
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
