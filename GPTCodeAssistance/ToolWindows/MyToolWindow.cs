using Microsoft.VisualStudio.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GPTCodeAssistance {
    public class MyToolWindow:BaseToolWindow<MyToolWindow> {
        public override string GetTitle(int toolWindowId) => "My Tool Window";

        public override Type PaneType => typeof(Pane);

        public override Task<FrameworkElement> CreateAsync(int toolWindowId,CancellationToken cancellationToken) {
            return Task.FromResult<FrameworkElement>(new MyToolWindowControl());
        }

        [Guid("2cc52b88-e720-4d3c-b2d8-a27c9f040f8b")]
        internal class Pane:ToolkitToolWindowPane {
            public Pane() {
                BitmapImageMoniker = KnownMonikers.ToolWindow;
            }
        }
    }
}