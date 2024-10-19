using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using OpenAI.Chat;
using SKcode.internalCode;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SKcode {
    public class SemanticKernelManager {
        public Kernel myKernel { get; private set; }
        private ChatHistory _chatHistory = [];

        public SemanticKernelManager() {
            _chatHistory = new ChatHistory();

            // Initialize the Kernel with a basic configuration for OpenAI (replace with actual settings)
            myKernel = Kernel.CreateBuilder()
                .AddOpenAIChatCompletion(
                    modelId: SKSettings.model,                  // Example model name
                    apiKey: SKSettings.ApiKey)     // Replace with a real API key or configuration
                .Build();
        }

        public void AddUserMessage(string message) {
            _chatHistory.AddUserMessage(message);
        }

        public void AddAssistantMessage(string message) {
            _chatHistory.AddAssistantMessage(message);
        }

        public ChatHistory GetChatHistory() {
            return _chatHistory;
        }

        public List<Microsoft.SemanticKernel.ChatMessageContent> GetMessagesByRole(AuthorRole role) {
            return _chatHistory
                .Where(message => message.Role == role)
                .ToList();
        }

        public async Task<string> SendMessageToAIAsync(string message) {
            // Add the user message to the chat history
            _chatHistory.AddUserMessage(message);

            // Pass the complete chat history to the AI model
            IChatCompletionService chatService = myKernel.GetRequiredService<IChatCompletionService>();
            Microsoft.SemanticKernel.ChatMessageContent response = await chatService.GetChatMessageContentAsync(chatHistory: _chatHistory,kernel: myKernel);

            // Extract the response and add it to chat history
            ChatMessageContentItemCollection responseText = response.Items;
            _chatHistory.AddAssistantMessage(responseText[0].ToString());

            return responseText[0].ToString();
        }

    }
}