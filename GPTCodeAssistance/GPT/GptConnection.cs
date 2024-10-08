using System;
using System.Threading.Tasks;
using Microsoft.SemanticKernel;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Kernel = Microsoft.SemanticKernel.Kernel;
using Microsoft.SemanticKernel.ChatCompletion;
using OpenAI.Chat;
using GPTCodeAssistance.GPT;

namespace GptCodeAssistant.GPT
{
    public class GptConnection
    {
        private readonly Kernel _kernel;

        public GptConnection()
        {
            // Set up the logger (optional)
            ILoggerFactory loggerFactory = NullLoggerFactory.Instance;

            // Create the kernel builder
            var builder = Kernel.CreateBuilder();
            builder.Services.AddSingleton(loggerFactory); // Register the logger

            // Build the kernel instance
            _kernel = builder.AddOpenAIChatCompletion(
                    modelId: GPTSettings.model,                   // OpenAI Model Name
                    apiKey : GPTSettings.ApiKey,     // OpenAI API Key
                    serviceId: "OpenAI_gpt4o"   // Service ID for reference
                ).Build();

        }

        // Asynchronous method for sending a prompt
    public async Task<string> SendPromptAsync(string prompt) {
            if (string.IsNullOrWhiteSpace(prompt))
                throw new ArgumentException("Prompt cannot be null or empty.");

            var chatCompletion = _kernel.Services.GetService<ChatCompletion>();
            var chatHistory = await chatCompletion.;
            chatHistory.AddUserMessage(prompt);

            string response = await chatCompletion.GenerateMessageAsync(chatHistory);
            return response;
        }
    }
}
