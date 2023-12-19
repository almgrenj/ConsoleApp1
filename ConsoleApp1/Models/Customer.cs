using System;

namespace ConsoleApp1.Models
{
    /// <summary>
    /// Representerar en kund med grundläggande kontaktinformation.
    /// Innehåller egenskaper för förnamn, efternamn, telefonnummer, e-post och adress.
    /// </summary>
    public class Customer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Standardkonstruktor som skapar en tom kund.
        /// </summary>
        public Customer() { }

        /// <summary>
        /// Djup kopieringskonstruktor.
        /// Skapar en ny instans av Customer genom att kopiera egenskaperna från en annan Customer-instans.
        /// </summary>
        /// <param name="other">Kunden att kopiera från.</param>
        public Customer(Customer other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            FirstName = other.FirstName;
            LastName = other.LastName;
            PhoneNumber = other.PhoneNumber;
            Email = other.Email;
            Address = other.Address;
        }

        /// <summary>
        /// Metod för att uppdatera den aktuella instansen från en annan instans.
        /// </summary>
        /// <param name="copy">Kunden att kopiera från.</param>
        public void UpdateFromCopy(Customer copy)
        {
            if (copy == null)
                throw new ArgumentNullException(nameof(copy));

            FirstName = copy.FirstName;
            LastName = copy.LastName;
            PhoneNumber = copy.PhoneNumber;
            Email = copy.Email;
            Address = copy.Address;
        }

        /// <summary>
        /// Konstruktor som skapar en kund med specifika detaljer.
        /// </summary>
        /// <param name="firstName">Kundens förnamn.</param>
        /// <param name="lastName">Kundens efternamn.</param>
        /// <param name="phoneNumber">Kundens telefonnummer.</param>
        /// <param name="email">Kundens e-postadress.</param>
        /// <param name="address">Kundens adress.</param>
        public Customer(string firstName, string lastName, string phoneNumber, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        /// <summary>
        /// Returnerar en strängrepresentation av kunden.
        /// Inkluderar förnamn, efternamn, telefonnummer, e-post och adress.
        /// </summary>
        /// <returns>En sträng som beskriver kunden.</returns>
        public override string ToString()
        {
            return $"Namn: {FirstName} {LastName}\nTelefonnummer: {PhoneNumber}\nE-post: {Email}\nAdress: {Address}";
        }
    }
}
