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

        [Guid("58b27c61-3293-4f02-bd74-84090bc7b95d")]
        internal class Pane:ToolkitToolWindowPane {
            public Pane() {
                BitmapImageMoniker = KnownMonikers.ToolWindow;
            }
        }
    }
}