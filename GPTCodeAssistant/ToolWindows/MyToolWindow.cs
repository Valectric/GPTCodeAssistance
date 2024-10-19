using Microsoft.VisualStudio.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace GPTCodeAssistant {
    public class MyToolWindow:BaseToolWindow<MyToolWindow> {
        public override string GetTitle(int toolWindowId) => "My Tool Window";

        public override Type PaneType => typeof(Pane);

        public override Task<FrameworkElement> CreateAsync(int toolWindowId,CancellationToken cancellationToken) {
            return Task.FromResult<FrameworkElement>(new MyToolWindowControl());
        }

        [Guid("b2b15857-971e-4dd9-ac4e-808c140c552f")]
        internal class Pane:ToolkitToolWindowPane {
            public Pane() {
                BitmapImageMoniker = KnownMonikers.ToolWindow;
            }
        }
    }
}