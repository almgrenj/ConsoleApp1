using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Hanterar kontaktinformation för kunder.
    /// Inkluderar funktionalitet för att ladda, spara, lägga till, ta bort, och lista kunder.
    /// </summary>
    internal class ContactManager
    {
        private List<Customer> customers;
        private string filePath;

        /// <summary>
        /// Konstruerar en ContactManager och laddar befintliga kontakter från fil.
        /// </summary>
        public ContactManager()
        {
            customers = new List<Customer>();
            filePath = "customers.json";
            LoadContacts();
        }

        /// <summary>
        /// Laddar kontakter från en fil.
        /// </summary>
        private void LoadContacts()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                customers = JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            }
        }

        /// <summary>
        /// Sparar nuvarande kontaskter till en fil.
        /// </summary>
        public void SaveContacts()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(customers, options);
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Lägger till en ny kontakt och sparar ändringen.
        /// </summary>
        /// <param name="customer">Kunden som ska läggas till.</param>
        public void AddContact(Customer customer)
        {
            customers.Add(customer);
            SaveContacts();
        }

        /// <summary>
        /// Tar bort en kontakt baserat på e-postadress och sparar ändringen.
        /// </summary>
        /// <param name="email">E-postadressen för kunden som ska tas bort.</param>
        public void RemoveContact(string email)
        {
            var customerToRemove = customers.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (customerToRemove != null)
            {
                customers.Remove(customerToRemove);
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Kund med e-postadress hittades inte.");
            }
        }

        /// <summary>
        /// Listar alla sparade kontakter.
        /// </summary>
        public void ListContacts()
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
                Console.WriteLine("--");
            }
        }

        /// <summary>
        /// Visar detaljer för en specifik kontakt baserat på e-postadress.
        /// </summary>
        /// <param name="email">E-postadressen för den kund vars detaljer ska visas.</param>
        public void ShowContactDetail(string email)
        {
            var customer = customers.FirstOrDefault(c => c.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if (customer != null)
            {
                Console.WriteLine(customer.ToString());
            }
            else
            {
                Console.WriteLine("Kund med e-postadress hittade inte.");
            }
        }
    }
}
