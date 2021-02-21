using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using MVVMTest.Core;
using MVVMTest.Data;
using MVVMTest.GUI.Factory;
using MVVMTest.GUI.Interface;

namespace MVVMTest.GUI.ViewModels
{
    /// <summary>
    /// View model for <see cref="Views.MainView"/>.
    /// </summary>
    public class MainViewModel : IViewModel
    {
        /// <summary>
        /// Gets or sets the collection of customers to display.
        /// </summary>
        /// <value>The collection of customers to display.</value>
        public ObservableCollection<Customer> Customers { get; set; }

        /// <summary>
        /// Gets or sets the currently selected customer.
        /// </summary>
        /// <value>The currently selected customer.</value>
        public Customer SelectedCustomer { get; set; }

        /// <summary>
        /// Gets or sets the add command.
        /// </summary>
        /// <value>The add command.</value>
        public ICommand AddCommand { get; set; }

        /// <summary>
        /// Gets or sets the delete command.
        /// </summary>
        /// <value>The delete command.</value>
        public ICommand DeleteCommand { get; set; }

        /// <summary>
        /// Data access implementation.
        /// </summary>
        private readonly ICustomerDataAccess _dataAccess;

        /// <summary>
        /// Factory for creating add customer window.
        /// </summary>
        private readonly IWindowFactory _addCustomer;

        /// <summary>
        /// Constructs a new instance of <see cref="MainViewModel"/>.
        /// </summary>
        /// <param name="dataAccess">The data access implementation.</param>
        /// <param name="addCustomer">The factory for opening add customer window.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="dataAccess"/> is <see langword="null"/>.</exception>
        /// <exception cref="ArgumentNullException">When <paramref name="addCustomer"/> is <see langword="null"/>.</exception>
        public MainViewModel(ICustomerDataAccess dataAccess, IWindowFactory addCustomer)
        {
            _dataAccess = dataAccess ?? throw new ArgumentNullException(nameof(dataAccess));
            _addCustomer = addCustomer ?? throw new ArgumentNullException(nameof(addCustomer));
            Customers = new ObservableCollection<Customer>(_dataAccess.GetAll());
            InitialiseCommands();
        }

        /// <summary>
        /// Initialises all of the commands.
        /// </summary>
        void InitialiseCommands()
        {
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            AddCommand = new RelayCommand(OnAdd);
        }

        /// <summary>
        /// Invoked when Add is clicked.
        /// </summary>
        /// <param name="parameter">Always ignored.</param>
        void OnAdd(object parameter)
        {
            if (_addCustomer.ShowDialog())
            {
                // TODO
            }
        }

        /// <summary>
        /// Invoked when Delete is clicked.
        /// </summary>
        /// <param name="parameter">Always ignored.</param>
        void OnDelete(object parameter)
        {
            if (SelectedCustomer is null)
                return;

            _dataAccess.Delete(SelectedCustomer.Id);
            Customers.Remove(SelectedCustomer);
        }

        /// <summary>
        /// Determines if can delete a customer.
        /// </summary>
        /// <param name="parameter">Always ignored.</param>
        /// <returns><see langword="true"/> if can delete a customer; otherwise, <see langword="false"/>.</returns>
        bool CanDelete(object parameter)
        {
            return SelectedCustomer is not null;
        }
    }
}
