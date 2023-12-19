using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Fönster som visar en kontaktlista.
    /// </summary>
    public partial class ContactListView : Window
    {
        /// <summary>
        /// Skapar en ny instans av ContactListView-fönstret.
        /// </summary>
        public ContactListView()
        {
            InitializeComponent();
            DataContext = new ContactListViewModel();
        }
    }
}
