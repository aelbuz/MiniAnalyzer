using Microsoft.Win32;

namespace Views.Common
{
    public static class FileDialogHelper
    {
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
