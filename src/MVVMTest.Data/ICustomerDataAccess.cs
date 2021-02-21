using System.Collections.Generic;
using MVVMTest.Core;

namespace MVVMTest.Data
{
    /// <summary>
    /// Represents a data access implementation.
    /// </summary>
    public interface ICustomerDataAccess
    {
        /// <summary>
        /// Returns a customer via ID.
        /// </summary>
        /// <param name="id">The ID of the customer.</param>
        /// <returns>The customer with the specified <paramref name="id"/>, <see langword="null"/> if not found.</returns>
        Customer GetById(int id);

        /// <summary>
        /// Returns all of the customers.
        /// </summary>
        /// <returns>All of the customers.</returns>
        IEnumerable<Customer> GetAll();

        /// <summary>
        /// Deletes a customer via ID.
        /// </summary>
        /// <param name="id">The ID of the customer to delete.</param>
        /// <returns>The deleted customer, or <see langword="null"/> if not found.</returns>
        Customer Delete(int id);

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        /// <returns>The added customer.</returns>
        Customer Add(Customer customer);

        /// <summary>
        /// Commits the changes made to database.
        /// </summary>
        /// <returns>The number of rows affected.</returns>
        int Commit();
    }
}
