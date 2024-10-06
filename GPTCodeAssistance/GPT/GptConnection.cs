using System;
using System.Threading.Tasks;

namespace GptCodeAssistant.GPT {
    public class GptConnection {
        // Asynchronous method for sending a prompt
        public async Task<string> SendPromptAsync(string prompt) {
            // Validate the input
            if (string.IsNullOrEmpty(prompt)) {
                throw new ArgumentException("Prompt cannot be null or empty");
            }

            // Simulate a delay to represent an async API call
            await Task.Delay(100); // Simulate network delay or API call

            // Simulate an error response for testing purposes
            if (prompt.Contains("error")) {
                throw new ApplicationException("An error occurred while calling the GPT API asynchronously");
            }

            // Return a simulated response
            return "This is a simulated async response to: " + prompt;
        }
    }
}
