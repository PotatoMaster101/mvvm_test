using System;
using MVVMTest.GUI.ViewModels;
using MVVMTest.GUI.Views;

namespace MVVMTest.GUI.Factory
{
    /// <summary>
    /// A factory for creating <see cref="AddCustomerView"/>.
    /// </summary>
    public class AddCustomerViewFactory : IWindowFactory
    {
        /// <summary>
        /// Opens <see cref="AddCustomerView"/> as a dialog.
        /// </summary>
        /// <returns>The result of the dialog.</returns>
        public bool ShowDialog()
        {
            var vm = new AddCustomerViewModel();
            var view = new AddCustomerView(vm);

            vm.OnClose += (s, e) => view.Close();
            view.ShowDialog();
            return vm.IsOk;
        }

        /// <summary>
        /// Opens <see cref="AddCustomerView"/> as a normal window.
        /// </summary>
        public void ShowWindow()
        {
            new AddCustomerView(new AddCustomerViewModel()).Show();
        }
    }
}
