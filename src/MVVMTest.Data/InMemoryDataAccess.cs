using System.Collections.Generic;
using System.Linq;
using MVVMTest.Core;

namespace MVVMTest.Data
{
    /// <summary>
    /// An implementation of customer data access where the data is stored in memory. Use for testing purpose only.
    /// </summary>
    public class InMemoryDataAccess : ICustomerDataAccess
    {
        /// <summary>
        /// Collection of in memory customers.
        /// </summary>
        private readonly List<Customer> _customers = new()
        {
            new Customer(0, "John", "Smith"),
            new Customer(1, "John", "Johnson"),
            new Customer(2, "John", "Williams"),
            new Customer(3, "John", "Brown"),
        };

        /// <summary>
        /// Returns a customer via ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer with the specified <paramref name="id"/>, <see langword="null"/> if not found.</returns>
        public Customer GetById(int id)
        {
            return _customers.Find(c => c.Id == id);
        }

        /// <summary>
        /// Returns all of the customers.
        /// </summary>
        /// <returns>All of the customers.</returns>
        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }

        /// <summary>
        /// Deletes a customer via ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>The deleted customer, or <see langword="null"/> if not found.</returns>
        public Customer Delete(int id)
        {
            var c = GetById(id);
            _customers.Remove(c);
            return c;
        }

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        /// <returns>The added customer.</returns>
        public Customer Add(Customer customer)
        {
            if (customer is null)
                return null;

            customer.Id = _customers.Max(c => c.Id) + 1;
            _customers.Add(customer);
            return customer;
        }

        /// <summary>
        /// Commits the changes made to database. Always return 0 for in memory data.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        public int Commit()
        {
            return 0;
        }
    }
}
