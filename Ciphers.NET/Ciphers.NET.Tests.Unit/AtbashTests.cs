using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET.Tests.Unit
{
    public class AtbashTests
    {
        [Fact]
        public void Encrypt_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello, World!";
            string expectedEncryptedMessage = "Svool, Dliow!";

            // Act
            string encryptedMessage = Atbash.Encrypt(message);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        [Fact]
        public void Decrypt_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string message = "Svool, Dliow!";
            string expectedDecryptedMessage = "Hello, World!";

            // Act
            string decryptedMessage = Atbash.Decrypt(message);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }

        [Fact]
        public void Encrypt_CustomAlphabet_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello, World!123";
            string expectedEncryptedMessage = "Vyrro, Golrz!cba";
            string customAlphabet = "abcdefghijklmnopqrstuvwxyz123";

            // Act
            string encryptedMessage = Atbash.Encrypt(message, customAlphabet);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        [Fact]
        public void Decrypt_CustomAlphabet_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string message = "Vyrro, Golrz!cba";
            string expectedDecryptedMessage = "Hello, World!123";
            string customAlphabet = "abcdefghijklmnopqrstuvwxyz123";

            // Act
            string decryptedMessage = Atbash.Decrypt(message, customAlphabet);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }
    }
}
