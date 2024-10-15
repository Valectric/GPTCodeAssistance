using Microsoft.SemanticKernel;
using SKcode.internalCode;

namespace SKcode {
    public class SemanticKernelManager {
        public Kernel Kernel { get; private set; }

        public SemanticKernelManager() {
            // Initialize the Kernel with a basic configuration for OpenAI (replace with actual settings)
            Kernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: SKSettings.model,                  // Example model name
                    apiKey: SKSettings.ApiKey)     // Replace with a real API key or configuration
                .Build();
        }
    }
}