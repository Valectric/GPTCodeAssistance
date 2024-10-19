using NUnit.Framework;
using Microsoft.SemanticKernel.ChatCompletion;
using SKcode;
using System.Threading.Tasks;
using System;

namespace SKcode.Tests {
    [TestFixture]
    public class SemanticKernelManagerTests {
        [Test]
        public void TestKernelInitialization() {
            var manager = new SemanticKernelManager();
            Assert.That(manager.myKernel,Is.Not.Null,"Kernel should be initialized.");
        }

        [Test]
        public void TestAddUserMessage() {
            var manager = new SemanticKernelManager();

            manager.AddUserMessage("Hello, how are you?");

            var chatHistory = manager.GetChatHistory(); // Using the public getter
            Assert.That(chatHistory.Count,Is.EqualTo(1));
            Assert.That(chatHistory[0].Content,Is.EqualTo("Hello, how are you?"));
            Assert.That(chatHistory[0].Role,Is.EqualTo(AuthorRole.User));
        }

        [Test]
        public void TestGetMessagesByRole_UserMessagesOnly() {
            SemanticKernelManager manager = new SemanticKernelManager();

            // Adding messages of different roles
            manager.AddUserMessage("Hello, how are you?");
            manager.AddAssistantMessage("I'm here to help!");
            manager.AddUserMessage("What can you do?");

            // Act
            var userMessages = manager.GetMessagesByRole(AuthorRole.User);

            // Assert
            Assert.That(userMessages.Count,Is.EqualTo(2),"There should be two user messages.");
            Assert.That(userMessages[0].Content,Is.EqualTo("Hello, how are you?"),"The first user message should match.");
            Assert.That(userMessages[1].Content,Is.EqualTo("What can you do?"),"The second user message should match.");
        }

        [Test]
        public void TestAddAssistantMessage() {
            var manager = new SemanticKernelManager();

            manager.AddAssistantMessage("I'm here to help you!");

            var chatHistory = manager.GetChatHistory();
            Assert.That(chatHistory.Count,Is.EqualTo(1),"Chat history should contain one message.");
            Assert.That(chatHistory[0].Content,Is.EqualTo("I'm here to help you!"),"The message content should match.");
            Assert.That(chatHistory[0].Role,Is.EqualTo(AuthorRole.Assistant),"The message role should be Assistant.");
        }

        [Test]
        public async Task TestSendMessageToAIAsync_EndToEnd() {
            // Configure the SemanticKernelManager with actual API details
            SemanticKernelManager _manager = new SemanticKernelManager();

            // Arrange
            string userMessage = "What's the weather like today?";

            // Act
            string aiResponse = await _manager.SendMessageToAIAsync(userMessage);

            // Assert
            Assert.That(aiResponse,Is.Not.Null.And.Not.Empty,"The AI response should not be null or empty.");
            Assert.That(_manager.GetChatHistory().Count,Is.EqualTo(2),"Chat history should contain two messages.");

            // Print the interaction for verification
            var chatHistory = _manager.GetChatHistory();
            Console.WriteLine($"User: {chatHistory[0].Content}");
            Console.WriteLine($"AI: {chatHistory[1].Content}");
        }

    }
}
