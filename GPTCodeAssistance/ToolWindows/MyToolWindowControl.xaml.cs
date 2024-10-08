using GptCodeAssistant.GPT;
using System.Windows;
using System.Windows.Controls;

namespace GPTCodeAssistance {
    public partial class MyToolWindowControl:UserControl {

        private readonly GptConnection _gptConnection;
        public MyToolWindowControl() {
            InitializeComponent();
            _gptConnection = new GptConnection(); // Initialize the GptConnection instance
        }

        private void button1_Click(object sender,RoutedEventArgs e) {
            VS.MessageBox.Show("GPTCodeAssistance","Button clicked");
        }

        private async void SendButton_Click(object sender,RoutedEventArgs e) {
            string userMessage = txtChatInput.Text;

            if (!string.IsNullOrWhiteSpace(userMessage)) {
                // Append the user's message to the chat history
                txtChatHistory.Text += $"You: {userMessage}\n";

                // Clear the chat input box
                txtChatInput.Clear();

                // Call the GPT-4 API using Semantic Kernel and get the response
                string response;
                try {
                    response = await _gptConnection.SendPromptAsync(userMessage);
                } catch (Exception ex) {
                    // Handle any errors (e.g., network issues, API errors)
                    response = "Error: Unable to process the request.";
                }

                // Append the GPT-4 response to the chat history
                txtChatHistory.Text += $"Bot: {response}\n";
            }
        }
    }
}