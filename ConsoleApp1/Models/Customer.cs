namespace ConsoleApp1.Models
{
    /// <summary>
    /// Representerar en kund med grundläggande kontaktinformation.
    /// Innehåller egenskaper som förnamn, efternamn, telefonnummer, e-postadress och adress.
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
