using System;
using System.Windows.Input;

namespace Views.Common
{
    /// <summary>
    /// Defines a command class that executes the given action.
    /// </summary>
    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool>? canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">
        /// Delegate to execute when Execute is called on the command.
        /// This can be null to just hook up a CanExecute delegate.
        /// </param>
        /// <remarks><seealso cref="CanExecute"/> will always return true.</remarks>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand"/>.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action execute, Func<bool>? canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        #region ICommand Implementation

        /// <inheritdoc/>
        public bool CanExecute(object? parameter)
        {
            if (canExecute == null)
            {
                return true;
            }
            else
            {
                return canExecute();
            }
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
            execute();
        }

        #endregion
    }
}
