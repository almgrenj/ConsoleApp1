using System;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace ConsoleApp1
{
    /// <summary>
    /// Huvuddprogrammet för att hantera kontadkter.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ContactManager contactManager = new ContactManager();
            bool exit = false;

            // Huvudloopen för programmet, visar användarmenyn och hanterar användarval.
            while (!exit)
            {
                // Visa menyn för användaren.
                Console.WriteLine("1. Lägga till kund");
                Console.WriteLine("2. Ta bort kunden");
                Console.WriteLine("3. Lista alla kunder");
                Console.WriteLine("4. Visa kundinfo");
                Console.WriteLine("5. Avsluta");

                Console.Write("Välj ett alternativ: ");
                var choice = Console.ReadLine();

                // Hanterar användarens val.
                switch (choice)
                {
                    case "1":
                        AddNewCustomer(contactManager);
                        break;
                    case "2":
                        RemoveCustomer(contactManager);
                        break;
                    case "3":
                        contactManager.ListContacts();
                        break;
                    case "4":
                        ShowCustomerDetails(contactManager);
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen");
                        break;
                }
            }
        }

        /// <summary>
        /// Lägger till en ny kund i kontaktlistan.
        /// </summary>
        static void AddNewCustomer(ContactManager contactManager)
        {
            // Samla in kundinformation från användaren.
            Console.Write("Ange förnamn: ");
            string firstName = Console.ReadLine() ?? string.Empty;

            Console.Write("Ange efternamn: ");
            string lastName = Console.ReadLine() ?? string.Empty;

            Console.Write("Ange telefonnummer: ");
            string phoneNumber = Console.ReadLine() ?? string.Empty;

            Console.Write("Ange e-postadress: ");
            string email = Console.ReadLine() ?? string.Empty;

            Console.Write("Ange adress: ");
            string address = Console.ReadLine() ?? string.Empty;

            var newCustomer = new Customer(firstName, lastName, phoneNumber, email, address);
            contactManager.AddContact(newCustomer);
        }

        /// <summary>
        /// Tar bort en befintlig kund från kontaktlistan.
        /// </summary>
        static void RemoveCustomer(ContactManager contactManager)
        {
            // Frågar efter e-postadress för att identifiera kunden som ska tas bort.
            Console.Write("Ange e-postadressen för den kund du vill ta bort: ");
            string email = Console.ReadLine() ?? string.Empty;
            contactManager.RemoveContact(email);
        }

        /// <summary>
        /// Visar detaljerad information för en specifik kund.
        /// </summary>
        static void ShowCustomerDetails(ContactManager contactManager)
        {
            // Frågar efter e-postadress för att visa detaljer om en specifik kund.
            Console.Write("Ange e-postadressen för den kund du vill se information om: ");
            string email = Console.ReadLine() ?? string.Empty;
            contactManager.ShowContactDetail(email);
        }
    }
}
