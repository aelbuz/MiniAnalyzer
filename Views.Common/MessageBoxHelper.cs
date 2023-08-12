using System.ComponentModel;
using System.Windows;

namespace Views.Common
{
    /// <summary>
    /// Defines static helper methods for message boxes.
    /// </summary>
    public static class MessageBoxHelper
    {
        /// <summary>
        /// Shows a message box with given message.
        /// </summary>
        /// <param name="message">Message enum for the message box.</param>
        public static void ShowMessageBox(MessageBoxMessage message)
        {
            string messageBoxText = GetMessageBoxText(message);
            string messageBoxCaption = GetMessageBoxCaption(message);
            var messageBoxImage = GetMessageBoxImage(message);

            MessageBox.Show(Application.Current.MainWindow,
                            messageBoxText,
                            messageBoxCaption,
                            MessageBoxButton.OK,
                            messageBoxImage);
        }

        private static string GetMessageBoxText(MessageBoxMessage message)
        {
            return message switch
            {
                MessageBoxMessage.InvalidJsonContent => MessageBoxConstants.InvalidJsonContentMessage,
                MessageBoxMessage.InvalidLineSeparatedJsonContent => MessageBoxConstants.InvalidJsonContentMessage,
                MessageBoxMessage.InvalidJsonLines => MessageBoxConstants.InvalidJsonLinesMessage,
                _ => throw new InvalidEnumArgumentException("Given enumeration value is not valid.",
                                                            (int)message,
                                                            typeof(MessageBoxMessage)),
            };
        }

        private static string GetMessageBoxCaption(MessageBoxMessage message)
        {
            return message switch
            {
                MessageBoxMessage.InvalidJsonContent => MessageBoxConstants.JsonErrorCaption,
                MessageBoxMessage.InvalidLineSeparatedJsonContent => MessageBoxConstants.LineSeparatedJsonErrorCaption,
                MessageBoxMessage.InvalidJsonLines => MessageBoxConstants.LineSeparatedJsonWarningCaption,
                _ => throw new InvalidEnumArgumentException("Given enumeration value is not valid.",
                                                            (int)message,
                                                            typeof(MessageBoxMessage)),
            };
        }

        private static MessageBoxImage GetMessageBoxImage(MessageBoxMessage message)
        {
            return message switch
            {
                MessageBoxMessage.InvalidJsonContent => MessageBoxImage.Error,
                MessageBoxMessage.InvalidLineSeparatedJsonContent => MessageBoxImage.Error,
                MessageBoxMessage.InvalidJsonLines => MessageBoxImage.Warning,
                _ => throw new InvalidEnumArgumentException("Given enumeration value is not valid.",
                                                            (int)message,
                                                            typeof(MessageBoxMessage)),
            };
        }
    }

    /// <summary>
    /// Defines messages for message boxes.
    /// </summary>
    internal static class MessageBoxConstants
    {
        // TODO: Move to resources file.

        internal const string InvalidJsonContentMessage = "Given JSON content is not valid.";
        internal const string InvalidJsonLinesMessage = "JSON content loaded but some JSON lines are not valid.";

        internal const string JsonErrorCaption = "JSON Error";
        internal const string LineSeparatedJsonErrorCaption = "Line Separated JSON Error";
        internal const string LineSeparatedJsonWarningCaption = "Line Separated JSON Warning";
    }

    /// <summary>
    /// Defines message box messages in order to inform the user.
    /// </summary>
    public enum MessageBoxMessage
    {
        /// <summary>
        /// Given JSON content is invalid.
        /// </summary>
        InvalidJsonContent,

        /// <summary>
        /// Given line separated JSON content is invalid.
        /// </summary>
        InvalidLineSeparatedJsonContent,

        /// <summary>
        /// Given line separated JSON content has invalid lines.
        /// </summary>
        InvalidJsonLines,
    }
}
