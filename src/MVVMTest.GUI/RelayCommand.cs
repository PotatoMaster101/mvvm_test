using System;
using System.Windows.Input;

namespace MVVMTest.GUI
{
    /// <summary>
    /// A simple implementation for <see cref="ICommand"/>.
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// The <see cref="Action"/> for executing the command.
        /// </summary>
        private readonly Action<object> _execute;

        /// <summary>
        /// The <see cref="Predicate{T}"/> to determine whether the command can be executed.
        /// </summary>
        private readonly Predicate<object> _canExecute;

        /// <summary>
        /// Occurs when state of <see cref="CanExecute(object)"/> changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Constructs a new instance of <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">The <see cref="Action"/> for executing the command.</param>
        public RelayCommand(Action<object> execute)
            : this(execute, null) { }

        /// <summary>
        /// Constructs a new instance of <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">The <see cref="Action"/> for executing the command.</param>
        /// <param name="canExecute">The <see cref="Predicate{T}"/> to determine whether the command can be executed.</param>
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        
        /// <summary>
        /// Whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        /// <returns><see langword="true"/> if this command can be executed; otherwise, <see langword="false"/>.</returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute is null || _canExecute(parameter);
        }

        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="parameter">Data used by the command.</param>
        public void Execute(object parameter)
        {
            _execute?.Invoke(parameter);
        }
    }
}
