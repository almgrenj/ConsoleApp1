using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text.Json;
using System.Windows.Input;
using ConsoleApp1.Models;
using WpfApp1.Commands;
using System.IO;

namespace WpfApp1.ViewModels
{
    /// <summary>
    /// En ViewModel som hanterar en lista med kunder.
    /// </summary>
    public class ContactListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Customer> _customers = new ObservableCollection<Customer>();
        private Customer? _selectedCustomer;

        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// En kollektion av kunder.
        /// </summary>
        public ObservableCollection<Customer> Customers
        {
            get => _customers;
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        /// <summary>
        /// Den valda kunden.
        /// </summary>
        public Customer SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
                (EditCustomerCommand as RelayCommand)?.RaiseCanExecuteChanged();
                (DeleteCustomerCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }

        public ICommand AddCustomerCommand { get; private set; }
        public ICommand EditCustomerCommand { get; private set; }
        public ICommand DeleteCustomerCommand { get; private set; }
        public ICommand DeleteByEmailCommand { get; private set; }
        public ICommand UpdateCustomerCommand { get; private set; }


        /// <summary>
        /// Skapar en ny instans av ContactListViewModel.
        /// </summary>
        public ContactListViewModel()
        {
            LoadCustomersFromFile();
            AddCustomerCommand = new RelayCommand(AddCustomer);
            EditCustomerCommand = new RelayCommand(EditCustomer, CanEditDeleteCustomer);
            DeleteCustomerCommand = new RelayCommand(DeleteCustomer, CanEditDeleteCustomer);
            DeleteByEmailCommand = new RelayCommand(DeleteByEmail);
            UpdateCustomerCommand = new RelayCommand(UpdateCustomer, CanEditDeleteCustomer);

        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddCustomer()
        {
            var newCustomer = new Customer();
            var detailsView = new CustomerDetailsView(newCustomer);
            if (detailsView.ShowDialog() == true)
            {
                Customers.Add(newCustomer);
                SaveCustomersToFile();
            }
        }

        private void SaveCustomersToFile()
        {
            var json = JsonSerializer.Serialize(Customers);
            File.WriteAllText("customers.json", json);
        }

        private void LoadCustomersFromFile()
        {
            if (File.Exists("customers.json"))
            {
                var json = File.ReadAllText("customers.json");
                Customers = JsonSerializer.Deserialize<ObservableCollection<Customer>>(json);
            }
        }

        private void EditCustomer()
        {
            if (SelectedCustomer != null)
            {
                var customerCopy = new Customer(SelectedCustomer); // Make a copy
                var detailsView = new CustomerDetailsView(customerCopy, true);
                if (detailsView.ShowDialog() == true)
                {
                    // Update original customer with changes from the copy
                    var index = Customers.IndexOf(SelectedCustomer);
                    if (index != -1)
                    {
                        Customers[index] = customerCopy;
                        SaveCustomersToFile();
                    }
                }
            }
        }




        private void DeleteCustomer()
        {
            if (SelectedCustomer != null)
            {
                Customers.Remove(SelectedCustomer);
                SaveCustomersToFile();
            }
        }

        private bool CanEditDeleteCustomer()
        {
            return SelectedCustomer != null;
        }

        private string _emailToDelete;
        public string EmailToDelete
        {
            get => _emailToDelete;
            set
            {
                _emailToDelete = value;
                OnPropertyChanged(nameof(EmailToDelete));
            }
        }

        private void DeleteByEmail()
        {
            var customerToDelete = Customers.FirstOrDefault(c => c.Email == EmailToDelete);
            if (customerToDelete != null)
            {
                Customers.Remove(customerToDelete);
                SaveCustomersToFile();
            }
        }

        private void UpdateCustomer()
        {
            if (SelectedCustomer != null)
            {
                var index = Customers.IndexOf(SelectedCustomer);
                if (index != -1)
                {
                    Customers[index] = SelectedCustomer;
                    SaveCustomersToFile();
                }
            }
        }
    }
}