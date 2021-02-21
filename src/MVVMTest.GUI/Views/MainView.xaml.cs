using System.Windows;
using MVVMTest.Data;
using MVVMTest.GUI.Factory;
using MVVMTest.GUI.ViewModels;

namespace MVVMTest.GUI.Views
{
    /// <summary>
    /// Interaction logic for <c>MainView.xaml</c>.
    /// </summary>
    public partial class MainView : Window
    {
        /// <summary>
        /// Constructs a new instance of <see cref="MainView"/>.
        /// </summary>
        public MainView()
        {
            InitializeComponent();

            // put this here since need DI, normally put it in XAML
            DataContext = new MainViewModel(new InMemoryDataAccess(), new AddCustomerViewFactory());
        }
    }
}
