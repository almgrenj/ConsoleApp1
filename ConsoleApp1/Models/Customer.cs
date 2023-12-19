using System;

namespace ConsoleApp1.Models
{
    /// <summary>
    /// Represents a customer with basic contact information.
    /// Contains properties for first name, last name, phone number, email, and address.
    /// </summary>
    public class Customer
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        /// <summary>
        /// Default constructor that creates an empty customer.
        /// </summary>
        public Customer() { }

        /// <summary>
        /// Deep copy constructor.
        /// Creates a new instance of Customer by copying the properties from another Customer instance.
        /// </summary>
        /// <param name="other">The customer to copy.</param>
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
        /// Method to update the current instance from another instance.
        /// </summary>
        /// <param name="copy">The customer to copy from.</param>
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
        /// Constructor that creates a customer with specific details.
        /// </summary>
        /// <param name="firstName">The customer's first name.</param>
        /// <param name="lastName">The customer's last name.</param>
        /// <param name="phoneNumber">The customer's phone number.</param>
        /// <param name="email">The customer's email address.</param>
        /// <param name="address">The customer's address.</param>
        public Customer(string firstName, string lastName, string phoneNumber, string email, string address)
        {
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            Address = address;
        }

        /// <summary>
        /// Returns a string representation of the customer.
        /// Includes first name, last name, phone number, email, and address.
        /// </summary>
        /// <returns>A string describing the customer.</returns>
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}\nPhone Number: {PhoneNumber}\nEmail: {Email}\nAddress: {Address}";
        }
    }
}
