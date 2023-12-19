using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using ConsoleApp1.Interfaces;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services
{
    internal class ContactManager
    {
        private readonly ICustomerService _customerService;
        private readonly IFileService _fileService;

        public ContactManager(ICustomerService customerService, IFileService fileService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            LoadContacts();
        }

        private void LoadContacts()
        {
            string json = _fileService.ReadFromFile("customers.json");
            // Assuming _customerService can manage a list internally or similar logic
            var customers = JsonSerializer.Deserialize<List<Customer>>(json) ?? new List<Customer>();
            foreach (var customer in customers)
            {
                _customerService.AddCustomer(customer);
            }
        }

        public void SaveContacts()
        {
            var customers = _customerService.GetAllCustomers(); // Assuming such a method exists
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(customers, options);
            _fileService.WriteToFile("customers.json", json);
        }

        public void AddContact(Customer customer)
        {
            _customerService.AddCustomer(customer);
            SaveContacts();
        }

        public void RemoveContact(string email)
        {
            // Assuming _customerService can handle removal logic
            if (_customerService.RemoveCustomerByEmail(email))
            {
                SaveContacts();
            }
            else
            {
                Console.WriteLine("Kund med e-postadress hittades inte.");
            }
        }

        public void ListContacts()
        {
            var customers = _customerService.GetAllCustomers(); // Assuming such a method exists
            foreach (var customer in customers)
            {
                Console.WriteLine(customer.ToString());
                Console.WriteLine("--");
            }
        }

        public void ShowContactDetail(string email)
        {
            var customer = _customerService.GetCustomerByEmail(email); // Assuming such a method exists
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
