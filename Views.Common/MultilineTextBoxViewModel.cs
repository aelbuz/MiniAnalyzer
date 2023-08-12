using System;
using System.Windows.Input;

namespace Views.Common
{
    /// <summary>
    /// Defines functionalities of a window and view-model that contains a textbox with multiline feature.
    /// </summary>
    public class MultilineTextBoxViewModel : IDisposable
    {
        private readonly MultilineTextBoxWindow window;

        /// <summary>
        /// Initializes a new instance of the <see cref="MultilineTextBoxViewModel"/> class.
        /// </summary>
        /// <param name="title">Title of the textbox window.</param>
        public MultilineTextBoxViewModel(string title)
        {
            IsCanceled = true;
            OkButtonCommand = new RelayCommand(Ok);
            CancelButtonCommand = new RelayCommand(Cancel);

            window = new MultilineTextBoxWindow
            {
                DataContext = this,
                Title = title,
            };

            window.ShowDialog();
        }

        /// <summary>
        /// Gets the OK button command.
        /// </summary>
        public ICommand OkButtonCommand { get; private set; }

        /// <summary>
        /// Gets the cancel button command.
        /// </summary>
        public ICommand CancelButtonCommand { get; private set; }

        /// <summary>
        /// Gets or sets the text of the multiline textbox.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Gets the value indicating whether the user clicked the cancel button on the window.
        /// </summary>
        public bool IsCanceled { get; private set; }

        private void Ok()
        {
            IsCanceled = false;
            Dispose();
        }

        private void Cancel()
        {
            window.Close();
        }

        #region Dispose Methods

        /// <summary>
        /// Gets a value indicating whether this instance is disposed.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is disposed; otherwise, <c>false</c>.
        /// </value>
        protected bool IsDisposed { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="nongc">
        /// <c>true</c> to release both managed and unmanaged resources;
        /// <c>false</c> to release only unmanaged resources.
        /// </param>
        protected virtual void Dispose(bool nongc)
        {
            if (!IsDisposed && nongc)
            {
                window.Close();
            }

            IsDisposed = true;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="MultilineTextBoxViewModel"/> class.
        /// </summary>
        ~MultilineTextBoxViewModel()
        {
            Dispose(false);
        }

        #endregion
    }
}
