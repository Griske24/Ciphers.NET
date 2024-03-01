using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET.Tests.Unit
{
    public class MorseTests
    {
        [Fact]
        public void Encrypt_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello, World!";
            string expectedEncryptedMessage = ".... . .-.. .-.. --- --..-- / .-- --- .-. .-.. -.. -.-.--";

            // Act
            string encryptedMessage = Morse.Encrypt(message);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        [Fact]
        public void Decrypt_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string message = ".... . .-.. .-.. --- --..-- / .-- --- .-. .-.. -.. -.-.--";
            string expectedDecryptedMessage = "HELLO, WORLD!";

            // Act
            string decryptedMessage = Morse.Decrypt(message);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }
    }
}
