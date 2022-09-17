using System.ComponentModel;
using System.Windows;

namespace Views.Common
{
    public static class MessageBoxHelper
    {
        public static void ShowMessageBox(MessageBoxMessage message)
        {
            string messageBoxText = GetMessageBoxText(message);
            string messageBoxCaption = GetMessageBoxCaption(message);
            var messageBoxImage = GetMessageBoxImage(message);

            MessageBox.Show(Application.Current.MainWindow, messageBoxText, messageBoxCaption, MessageBoxButton.OK, messageBoxImage);
        }

        private static string GetMessageBoxText(MessageBoxMessage message)
        {
            switch (message)
            {
                case MessageBoxMessage.InvalidJsonContent:
                case MessageBoxMessage.InvalidLineSeparatedJsonContent:
                    return MessageBoxConstants.InvalidJsonContentMessage;
                case MessageBoxMessage.InvalidJsonLines:
                    return MessageBoxConstants.InvalidJsonLinesMessage;
                default:
                    throw new InvalidEnumArgumentException("Given enumeration value is not valid.", (int)message, typeof(MessageBoxMessage));
            }
        }

        private static string GetMessageBoxCaption(MessageBoxMessage message)
        {
            switch (message)
            {
                case MessageBoxMessage.InvalidJsonContent:
                    return MessageBoxConstants.JsonErrorCaption;
                case MessageBoxMessage.InvalidLineSeparatedJsonContent:
                    return MessageBoxConstants.LineSeparatedJsonErrorCaption;
                case MessageBoxMessage.InvalidJsonLines:
                    return MessageBoxConstants.LineSeparatedJsonWarningCaption;
                default:
                    throw new InvalidEnumArgumentException("Given enumeration value is not valid.", (int)message, typeof(MessageBoxMessage));
            }
        }

        private static MessageBoxImage GetMessageBoxImage(MessageBoxMessage message)
        {
            switch (message)
            {
                case MessageBoxMessage.InvalidJsonContent:
                case MessageBoxMessage.InvalidLineSeparatedJsonContent:
                    return MessageBoxImage.Error;
                case MessageBoxMessage.InvalidJsonLines:
                    return MessageBoxImage.Warning;
                default:
                    throw new InvalidEnumArgumentException("Given enumeration value is not valid.", (int)message, typeof(MessageBoxMessage));
            }
        }
    }

    internal static class MessageBoxConstants
    {
        internal const string InvalidJsonContentMessage = "Given JSON content is not valid.";
        internal const string InvalidJsonLinesMessage = "JSON content loaded but some JSON lines are not valid.";

        internal const string JsonErrorCaption = "JSON Error";
        internal const string LineSeparatedJsonErrorCaption = "Line Separated JSON Error";
        internal const string LineSeparatedJsonWarningCaption = "Line Separated JSON Warning";
    }

    public enum MessageBoxMessage
    {
        InvalidJsonContent,
        InvalidLineSeparatedJsonContent,
        InvalidJsonLines
    }
}
