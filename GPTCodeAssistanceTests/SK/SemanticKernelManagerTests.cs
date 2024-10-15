using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPTCodeAssistanceTests.SK {
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
