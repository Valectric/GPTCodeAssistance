using NUnit.Framework;
using GptCodeAssistant.GPT;

namespace GptCodeAssistant.Tests {
    [TestFixture]
    public class GptConnectionTests {
        [Test]
        public void SendPrompt_ShouldReturnNonEmptyString() {
            // Arrange
            var gptConnection = new GptConnection();
            string prompt = "Test prompt";

            // Act
            string result = gptConnection.SendPrompt(prompt);

            // Assert
            Assert.That(result,Is.Not.Empty,"The result should not be empty");
        }
    }
}
