using System.ComponentModel;

namespace Views.Common
{
    /// <summary>
    /// Defines the base class for view-models.
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged
    {
        /// <inheritdoc/>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Raises the <c>OnPropertyChanged</c> event.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (propertyName != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
