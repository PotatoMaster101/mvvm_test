using System;

namespace MVVMTest.Core
{
    /// <summary>
    /// Represents a customer.
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>The customer ID.</value>
        public int Id { get; set; } = 0;

        /// <summary>
        /// Gets or sets the customer first name.
        /// </summary>
        /// <value>The customer first name.</value>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the customer last name.
        /// </summary>
        /// <value>The customer last name.</value>
        public string LastName { get; set; }

        /// <summary>
        /// Gets the customer full name.
        /// </summary>
        /// <value>The customer full name.</value>
        public string FullName => $"{FirstName} {LastName}";

        /// <summary>
        /// Constructs a new instance of <see cref="Customer"/>.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <param name="firstName">The first name of the customer.</param>
        /// <param name="lastName">The last name of the customer.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="firstName"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="lastName"/> is <see langword="null"/>.</exception>
        public Customer(int id, string firstName, string lastName) 
        {
            Id = id;
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }
    }
}
