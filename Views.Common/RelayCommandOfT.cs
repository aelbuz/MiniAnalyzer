using System;
using System.Windows.Input;

namespace Views.Common
{
    /// <summary>
    /// Defines a generic command class that executes the given action.
    /// </summary>
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;
        private readonly Predicate<T>? canExecute = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/>.
        /// </summary>
        /// <param name="execute">
        /// Delegate to execute when Execute is called on the command.
        /// This can be null to just hook up a CanExecute delegate.
        /// </param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/>.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T>? canExecute)
        {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        #region ICommand Implementation

        /// <inheritdoc/>
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || (parameter != null && canExecute((T)parameter));
        }

        /// <inheritdoc/>
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <inheritdoc/>
        public void Execute(object? parameter)
        {
            if (parameter != null)
            {
                execute?.Invoke((T)parameter);
            }
        }

        #endregion
    }
}
