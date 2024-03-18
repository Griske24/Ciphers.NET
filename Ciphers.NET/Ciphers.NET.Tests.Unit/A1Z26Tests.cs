using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET.Tests.Unit
{
    public class A1Z26Tests
    {
        [Fact]
        public void Encrypt_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello World!";
            string expectedEncryptedMessage = "8 5 12 12 15 23 15 18 12 4";

            // Act
            string encryptedMessage = A1Z26.Encrypt(message);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        [Fact]
        public void Decrypt_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string encryptedMessage = "8 5 12 12 15 23 15 18 12 4";
            string expectedDecryptedMessage = "HELLOWORLD";

            // Act
            string decryptedMessage = A1Z26.Decrypt(encryptedMessage);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }

        [Fact]
        public void Encrypt_CustomAlphabetWithNumbers_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello World! 123";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string expectedEncryptedMessage = "8 5 12 12 15 23 15 18 12 4 28 29 30";

            // Act
            string encryptedMessage = A1Z26.Encrypt(message, alphabet:alphabet);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        [Fact]
        public void Decrypt_CustomAlphabetWithNumbers_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string encryptedMessage = "8 5 12 12 15 23 15 18 12 4 28 29 30";
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string expectedDecryptedMessage = "HELLOWORLD123";

            // Act
            string decryptedMessage = A1Z26.Decrypt(encryptedMessage, alphabet:alphabet);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }

        [Fact]
        public void Encrypt_CustomSeparator_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello World!";
            char separator = '-';
            string expectedEncryptedMessage = "8-5-12-12-15-23-15-18-12-4";

            // Act
            string encryptedMessage = A1Z26.Encrypt(message, separator: separator);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        [Fact]
        public void Decrypt_CustomSeparator_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string encryptedMessage = "8-5-12-12-15-23-15-18-12-4";
            char separator = '-';
            string expectedDecryptedMessage = "HELLOWORLD";

            // Act
            string decryptedMessage = A1Z26.Decrypt(encryptedMessage, separator: separator);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }

        [Fact]
        public void Encrypt_CustomKey_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello World!";
            int key = 3;
            string expectedEncryptedMessage = "11 8 15 15 18 26 18 21 15 7";

            // Act
            string encryptedMessage = A1Z26.Encrypt(message, key: key);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        [Fact]
        public void Decrypt_CustomKey_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string encryptedMessage = "11 8 15 15 18 26 18 21 15 7";
            int key = 3;
            string expectedDecryptedMessage = "HELLOWORLD";

            // Act
            string decryptedMessage = A1Z26.Decrypt(encryptedMessage, key: key);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }
    }
}
