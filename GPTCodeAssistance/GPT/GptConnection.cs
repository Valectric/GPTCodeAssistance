using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GptCodeAssistant.GPT {
    public class GptConnection {
        // Method for sending a prompt
        public string SendPrompt(string prompt) {
            // For now, we return a mock non-empty response
            return "This is a simulated response to: " + prompt;
        }
    }
}
