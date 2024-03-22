using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET.Tests.Unit
{
    public class AffineTests
    {
        [Fact]
        public void Encrypt_WithValidParameters_ReturnsEncryptedMessage()
        {
            // Arrange
            string message = "Hello";
            int a = 5;
            int b = 8;
            string expected = "Rclla";

            // Act
            string actual = Affine.Encrypt(message, a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Decrypt_WithValidParameters_ReturnsDecryptedMessage()
        {
            // Arrange
            string encryptedMessage = "Rclla";
            int a = 5;
            int b = 8;
            string expected = "Hello";

            // Act
            string actual = Affine.Decrypt(encryptedMessage, a, b);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Encrypt_WithInvalidParameters_ThrowsArgumentException()
        {
            // Arrange
            string message = "Hello";
            int a = 0;
            int b = 8;

            // Act
            Action act = () => Affine.Encrypt(message, a, b);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Decrypt_WithInvalidParameters_ThrowsArgumentException()
        {
            // Arrange
            string encryptedMessage = "Rclla";
            int a = 0;
            int b = 8;

            // Act
            Action act = () => Affine.Decrypt(encryptedMessage, a, b);

            // Assert
            Assert.Throws<ArgumentException>(act);
        }

        [Fact]
        public void Encrypt_ParametersNotProvided_ReturnsPossibleEncryptedMessages()
        {
            // Arrange
            string message = "Affine";
            Dictionary<Tuple<int, int>, string> expected = new Dictionary<Tuple<int, int>, string>
            {
                { Tuple.Create(1, 0), "Affine" },
                { Tuple.Create(1, 1), "Baainf" },
                { Tuple.Create(1, 2), "Cbbina" },
                { Tuple.Create(1, 3), "Dccinb" },
                { Tuple.Create(1, 4), "Eddinc" },
                { Tuple.Create(1, 5), "Feeind" },
                { Tuple.Create(5, 0), "Abbinc" },
                { Tuple.Create(5, 1), "Bccind" },
                { Tuple.Create(5, 2), "Cddine" },
                { Tuple.Create(5, 3), "Deeinf" },
                { Tuple.Create(5, 4), "Effina" },
                { Tuple.Create(5, 5), "Faainb" }
            };

            // Act
            Dictionary<Tuple<int, int>, string> actual = Affine.Encrypt(message, "abcdef");

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Decrypt_ParametersNotProvided_ReturnsPossibleDecryptedMessages()
        {
            // Arrange
            string encryptedMessage = "Baainf";
            Dictionary<Tuple<int, int>, string> expected = new Dictionary<Tuple<int, int>, string>
            {
                { Tuple.Create(1, 0), "Baainf" },
                { Tuple.Create(1, 1), "Affine" },
                { Tuple.Create(1, 2), "Feeind" },
                { Tuple.Create(1, 3), "Eddinc" },
                { Tuple.Create(1, 4), "Dccinb" },
                { Tuple.Create(1, 5), "Cbbina" },
                { Tuple.Create(5, 0), "Faainb" },
                { Tuple.Create(5, 1), "Abbinc" },
                { Tuple.Create(5, 2), "Bccind" },
                { Tuple.Create(5, 3), "Cddine" },
                { Tuple.Create(5, 4), "Deeinf" },
                { Tuple.Create(5, 5), "Effina" }
            };

            // Act
            Dictionary<Tuple<int, int>, string> actual = Affine.Decrypt(encryptedMessage, "abcdef");

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
