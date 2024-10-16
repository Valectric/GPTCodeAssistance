using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Microsoft.SemanticKernel;
using SKcode;

namespace GPTCodeAssistanceTests.SK {
    [TestFixture]
    internal class SemanticKernelManagerTests {
        [Test]
        public void SemanticKernelManager_ShouldInitializeKernel_OnCreation() {
            // Arrange & Act
            var kernelManager = new SemanticKernelManager();

            // Assert
            Assert.That(kernelManager.Kernel,Is.Not.Null,"The Kernel instance should be initialized on creation.");
        }
    }
}
