using NUnit.Framework;
using GptCodeAssistant.GPT;
using System.Threading.Tasks;
using System;

namespace GptCodeAssistant.Tests {
    [TestFixture]
    public class GptConnectionTests {
        [Test]
        public async Task SendPromptAsync_ShouldReturnNonEmptyString() {
            // Arrange
            var gptConnection = new GptConnection();
            string prompt = "Test prompt";

            // Act
            string result = await gptConnection.SendPromptAsync(prompt);

            // Assert
            Assert.That(result,Is.Not.Empty,"The result should not be empty");
        }

        [Test]
        public async Task SendPromptAsync_ShouldThrowArgumentException_ForNullPrompt() {
            // Arrange
            var gptConnection = new GptConnection();

            // Act & Assert
            var ex = Assert.ThrowsAsync<ArgumentException>(async () => await gptConnection.SendPromptAsync(null));
            Assert.That(ex.Message,Is.EqualTo("Prompt cannot be null or empty"));
        }

        [Test]
        public async Task SendPromptAsync_ShouldHandleApiResponseCorrectly() {
            // Arrange
            var gptConnection = new GptConnection();
            string prompt = "Test prompt";

            // Act
            string result = await gptConnection.SendPromptAsync(prompt);

            // Assert
            Assert.That(result,Is.EqualTo("This is a simulated async response to: Test prompt"),"The response should match the expected output");
        }

        [Test]
        public async Task SendPromptAsync_ShouldHandleApiErrorResponses() {
            // Arrange
            var gptConnection = new GptConnection();
            string prompt = "Test prompt that causes an error";

            // Act & Assert
            var ex = Assert.ThrowsAsync<ApplicationException>(async () => await gptConnection.SendPromptAsync(prompt));
            Assert.That(ex.Message,Is.EqualTo("An error occurred while calling the GPT API asynchronously"));
        }
    }
}
