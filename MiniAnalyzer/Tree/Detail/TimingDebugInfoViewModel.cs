using Common.Types;
using System.Threading.Tasks;
using System.Windows;
using Views.Common;

namespace MiniAnalyzer.Tree.Detail
{
    public class TimingDebugInfoViewModel : ViewModelBase
    {
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

        private async Task LoadContentCoreAsync(TimingDebugInfo timingDebugInfo)
        {
            await Task.Run(() =>
            {
                RichHtmlStack = timingDebugInfo.RichHtmlStack;
                CommonStackStart = timingDebugInfo.CommonStackStart;
            });
        }

        #region RichHtmlStack Property

        private string? richHtmlStack;

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
    }
}
