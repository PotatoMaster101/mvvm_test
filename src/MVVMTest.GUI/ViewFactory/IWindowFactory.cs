namespace MVVMTest.GUI.Factory
{
    /// <summary>
    /// Represents a factory for creating windows.
    /// </summary>
    public interface IWindowFactory
    {
        /// <summary>
        /// Opens the window as a dialog.
        /// </summary>
        /// <returns>The result of the dialog.</returns>
        bool ShowDialog();

        /// <summary>
        /// Opens the window as a normal window.
        /// </summary>
        void ShowWindow();
    }
}
