using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    /// <summary>
    /// Defines functionalities of the timing debug info view-model.
    /// </summary>
    public class TimingDebugInfoViewModel : ViewModelBase
    {
        /// <summary>
        /// Loads the content with given timing debug info model asynchronously.
        /// </summary>
        /// <param name="timingDebugInfo">Timing debug info model.</param>
        /// <returns>A task.</returns>
        public async Task LoadContentAsync(TimingDebugInfo? timingDebugInfo)
        {
            if (timingDebugInfo == null)
            {
                Visibility = Visibility.Collapsed;
            }
            else
            {
                await LoadContentCoreAsync(timingDebugInfo);

                Visibility = Visibility.Visible;
            }
        }

        #region RichHtmlStack Property

        private string? richHtmlStack;

        /// <summary>
        /// Gets the (already-encoded) HTML representation of the call stack (MiniProfiler property).
        /// </summary>
        public string? RichHtmlStack
        {
            get => richHtmlStack;
            private set
            {
                if (value != richHtmlStack)
                {
                    richHtmlStack = value;
                    OnPropertyChanged(nameof(RichHtmlStack));
                }
            }
        }

        #endregion

        #region CommonStackStart Property

        private int? commonStackStart;

        /// <summary>
        /// Gets the index of the stack frame that common frames with parent start at (MiniProfiler property).
        /// </summary>
        public int? CommonStackStart
        {
            get => commonStackStart;
            private set
            {
                if (value != commonStackStart)
                {
                    commonStackStart = value;
                    OnPropertyChanged(nameof(CommonStackStart));
                }
            }
        }

        #endregion 

        #region Visibility Property

        private Visibility visibility;

        /// <summary>
        /// Gets the visibility state of this view-model.
        /// </summary>
        public Visibility Visibility
        {
            get => visibility;
            private set
            {
                if (value != visibility)
                {
                    visibility = value;
                    OnPropertyChanged(nameof(Visibility));
                }
            }
        }

        #endregion 

        private async Task LoadContentCoreAsync(TimingDebugInfo timingDebugInfo)
        {
            await Task.Run(() =>
            {
                RichHtmlStack = timingDebugInfo.RichHtmlStack;
                CommonStackStart = timingDebugInfo.CommonStackStart;
            });
        }
    }
}
