using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace GptCodeAssistant.GPT {
    public class GptConnection {
        // Asynchronous method for sending a prompt
        public async Task<string> SendPromptAsync(string prompt) {
            // Validate the input
            if (string.IsNullOrEmpty(prompt)) {
                throw new ArgumentException("Prompt cannot be null or empty");
            }

            try {
                // Simulate a delay to represent an async API call
                await Task.Delay(100); // Simulate network delay or API call

                // Simulate different error scenarios
                if (prompt.Contains("timeout")) {
                    throw new TimeoutException("The request timed out.");
                } else if (prompt.Contains("network")) {
                    throw new HttpRequestException("Network error occurred.");
                } else if (prompt.Contains("rate limit")) {
                    throw new ApplicationException("Rate limit exceeded.");
                } else if (prompt.Contains("server error")) {
                    throw new ApplicationException("An error occurred on the server.");
                }

                // Return a simulated response
                return "This is a simulated async response to: " + prompt;
            } catch (TimeoutException) {
                throw;  // Pass the timeout exception to be handled at a higher level
            } catch (HttpRequestException) {
                throw;  // Pass the network exception
            } catch (ApplicationException ex) {
                throw new ApplicationException(ex.Message,ex);  // Pass the specific error messages
            } catch (Exception) {
                throw new ApplicationException("An unknown error occurred while calling the GPT API asynchronously.");
            }
        }
    }
}
