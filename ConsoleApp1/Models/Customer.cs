namespace ConsoleApp1.Models
{
    public class Customer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public Customer() { }

        public Customer(string firstName, string lastName, string phoneNumber, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        public override string ToString()
        {
            return $"Namn: {FirstName} {LastName}\nTelefonnummer: {PhoneNumber}\nE-post: {Email}\nAdress: {Address}";
        }
    }
}
