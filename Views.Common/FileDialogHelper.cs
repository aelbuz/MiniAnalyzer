using Microsoft.Win32;

namespace Views.Common
{
    /// <summary>
    /// Defines static helper methods for file dialogs.
    /// </summary>
    public static class FileDialogHelper
    {
        /// <summary>
        /// Shows an <see cref="OpenFileDialog"/> with given filter and title.
        /// </summary>
        /// <param name="filter">Dialog filter.</param>
        /// <param name="title">Dialog title.</param>
        /// <param name="fileName">When this method returns, contains the file name selected by the user.</param>
        /// <returns>
        /// <c>true</c> if user selects the file and clicks the OK button; otherwise <c>false</c>.
        /// </returns>
        public static bool ShowOpenFileDialog(string filter, string title, ref string fileName)
        {
            var openFileDialog = new OpenFileDialog
            {
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = filter,
                Multiselect = false,
                Title = title
            };

            if (openFileDialog.ShowDialog() ?? false)
            {
                fileName = openFileDialog.FileName;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
