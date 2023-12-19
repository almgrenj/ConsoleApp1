using System.Windows;
using WpfApp1.ViewModels;

namespace WpfApp1
{
    /// <summary>
    /// Huvudfönstret för applikationen.
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Skapar en ny instans av MainWindow-fönstret.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}
