using System.Windows;
using ConsoleApp1.Models;

namespace WpfApp1
{
    public partial class CustomerDetailsView : Window
    {
        // Deklarera en egenskap för Customer.
        public Customer Customer { get; private set; }

        // En flagga för att indikera om det är en uppdatering eller skapande av en Customer
        public bool IsUpdate { get; set; }

        /// <summary>
        /// Konstruktor för CustomerDetailsView, tar emot en Customer och en flagga för uppdatering.
        /// </summary>
        /// <param name="customer">Kunden som ska redigeras eller skapas.</param>
        /// <param name="isUpdate">Flagga som indikerar om det är en uppdatering eller skapande.</param>
        public CustomerDetailsView(Customer customer, bool isUpdate = false)
        {
            InitializeComponent();
            // Tilldela den tillhandahållna kunden till egenskapen eller skapa en ny om den är null
            Customer = customer ?? new Customer();
            this.DataContext = Customer;

            IsUpdate = isUpdate;
            // Uppdatera knappens innehåll baserat på om det är en uppdatering eller skapande
            SaveButton.Content = isUpdate ? "Update" : "Save";
        }

        /// <summary>
        /// Hanterar klickhändelsen för sparaknappen. Ställer DialogResult till true och stänger fönstret.
        /// </summary>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        /// <summary>
        /// Hanterar klickhändelsen för avbryt-knappen. Ställer DialogResult till false och stänger fönstret.
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}