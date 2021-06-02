using System;
using System.Windows.Input;
using MVVMTest.Core;
using MVVMTest.GUI.Interface;

namespace MVVMTest.GUI.ViewModels
{
    /// <summary>
    /// View model for <see cref="Views.AddCustomerView"/>.
    /// </summary>
    public class AddCustomerViewModel : IViewModel
    {
        /// <summary>
        /// Gets the new customer from user.
        /// </summary>
        /// <value>The new customer from user.</value>
        public Customer NewCustomer { get; private set; }

        /// <summary>
        /// Gets whether OK is clicked.
        /// </summary>
        /// <value>Whether OK is clicked.</value>
        public bool IsOk { get; private set; } = false;

        /// <summary>
        /// Gets or sets the OK command.
        /// </summary>
        /// <value>The OK command.</value>
        public ICommand OkCommand { get; set; }

        /// <summary>
        /// Gets or sets the cancel command.
        /// </summary>
        /// <value>The cancel command.</value>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Triggers when the window is closing.
        /// </summary>
        public event EventHandler OnClose;

        /// <summary>
        /// Constructs a new instance of <see cref="AddCustomerViewModel"/>.
        /// </summary>
        public AddCustomerViewModel()
        {
            InitialiseCommands();
        }

        /// <summary>
        /// Initialises all of the commands.
        /// </summary>
        private void InitialiseCommands()
        {
            OkCommand = new RelayCommand(OnOk);
            CancelCommand = new RelayCommand(OnCancel);
        }

        /// <summary>
        /// Invoked when OK is clicked.
        /// </summary>
        /// <param name="parameter">Always ignored.</param>
        private void OnOk(object parameter)
        {
            IsOk = true;
            OnClose?.Invoke(null, null);
        }

        /// <summary>
        /// Invoked when Cancel is clicked.
        /// </summary>
        /// <param name="parameter">Always ignored.</param>
        private void OnCancel(object parameter)
        {
            IsOk = false;
            OnClose?.Invoke(null, null);
        }
    }
}
