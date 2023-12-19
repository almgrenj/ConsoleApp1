using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Hanterar kontakter och deras lagring i en JSON-fil.
    /// </summary>
    internal class ContactManager
    {
        private readonly ICustomerService _customerService;
        private readonly IFileService _fileService;

        /// <summary>
        /// Konstruktor för ContactManager.
        /// </summary>
        /// <param name="customerService">En tjänst för kunder.</param>
        /// <param name="fileService">En tjänst för filhantering.</param>
        public ContactManager(ICustomerService customerService, IFileService fileService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            LoadContacts();
        }

        // Ladda kontakter från en JSON-fil vid skapande av ContactManager
        private void LoadContacts()
        {
            string json = _fileService.ReadFromFile("customers.json");
            // Antagande: _customerService kan hantera en lista internt eller liknande logik
            var customers = JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            foreach (var customer in customers)
            {
                _customerService.AddCustomer(customer);
            }
        }

        // Spara kontakter till en JSON-fil
        public void SaveContacts()
        {
            var customers = _customerService.GetAllCustomers(); // Antagande: en sådan metod finns
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(customers, options);
            _fileService.WriteToFile("customers.json", json);
        }

        // Lägg till en ny kontakt och spara ändringar
        public void AddContact(Customer customer)
        {
            _customerService.AddCustomer(customer);
            SaveContacts();
        }

        // Ta bort en kontakt med en given e-postadress och spara ändringar
        public void RemoveContact(string email)
        {
            // Antagande: _customerService kan hantera borttagningslogik
            if (_customerService.RemoveCustomerByEmail(email))
            {
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Kund med e-postadress hittades inte.");
            }
        }

        // Lista alla kontakter
        public void ListContacts()
        {
            var customers = _customerService.GetAllCustomers(); // Antagande: en sådan metod finns
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
                Console.WriteLine("--");
            }
        }

        // Visa detaljer för en kontakt med en given e-postadress
        public void ShowContactDetail(string email)
        {
            var customer = _customerService.GetCustomerByEmail(email); // Antagande: en sådan metod finns
            if (customer != null)
            {
                Console.WriteLine(customer.ToString());
            }
            else
            {
                Console.WriteLine("Kund med e-postadress hittades inte.");
            }
        }
    }
}
