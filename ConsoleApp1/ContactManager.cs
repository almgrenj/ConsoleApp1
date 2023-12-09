using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    internal class ContactManager
    {
        private List<Customer> customers;
        private string filePath;

        public ContactManager()
        {
            customers = new List<Customer>();
            filePath = "customers.json";
            LoadContacts();
        }

        private void LoadContacts()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                customers = JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            }
        }

        public void SaveContacts()
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(customers, options);
            File.WriteAllText(filePath, json);
        }

        public void AddContact(Customer customer)
        {
            customers.Add(customer);
            SaveContacts();
        }

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

        public void ListContacts()
        {
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
                Console.WriteLine("--");
            }
        }

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
