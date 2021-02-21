using System;
using System.Windows;
using MVVMTest.GUI.Interface;

namespace MVVMTest.GUI.Views
{
    /// <summary>
    /// Interaction logic for <c>AddCustomerView.xaml</c>.
    /// </summary>
    public partial class AddCustomerView : Window
    {
        /// <summary>
        /// Constructs a new instance of <see cref="AddCustomerView"/>.
        /// </summary>
        /// <param name="vm">The view model for this view.</param>
        /// <exception cref="ArgumentNullException">When <paramref name="vm"/> is <see langword="null"/>.</exception>
        public AddCustomerView(IViewModel vm)
        {
            InitializeComponent();
            DataContext = vm ?? throw new ArgumentNullException(nameof(vm));
        }
    }
}
