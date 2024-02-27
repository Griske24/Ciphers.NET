using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET.Tests.Unit
{
    public class CaesarTests
    {
        /// <summary>
        /// Test to verify that the Encrypt function returns the correct encrypted message.
        /// </summary>
        [Fact]
        public void Encrypt_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello, World!";
            int key = 3;
            string expectedEncryptedMessage = "Khoor, Zruog!";

            // Act
            string encryptedMessage = Caesar.Encrypt(message, key);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        /// <summary>
        /// Test to verify that the Decrypt function returns the correct decrypted message.
        /// </summary>
        [Fact]
        public void Decrypt_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string message = "Khoor, Zruog!";
            int key = 3;
            string expectedDecryptedMessage = "Hello, World!";

            // Act
            string decryptedMessage = Caesar.Decrypt(message, key);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }

        /// <summary>
        /// Test to verify that the Encrypt function returns the correct encrypted message when a custom alphabet with numbers is used.
        /// </summary>
        [Fact]
        public void Encrypt_CustomAlphabetWithNumbers_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello, Earth-616!";
            int key = 3;
            string alphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
            string expectedEncryptedMessage = "Khoor, Hduwk-949!";

            // Act
            string encryptedMessage = Caesar.Encrypt(message, key, alphabet);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        /// <summary>
        /// Test to verify that the Decrypt function returns the correct decrypted message when a custom alphabet with special characters is used.
        /// </summary>
        [Fact]
        public void Decrypt_CustomAlphabetWithSpecialCharacters_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string message = "Khoor, Hduwk-616!";
            int key = 3;
            string alphabet = "abcdefghijklmnopqrstuvwxyz@$#&*{}[],=-().+;'/ ";
            string expectedDecryptedMessage = "Hello};Earth]616!";

            // Act
            string decryptedMessage = Caesar.Decrypt(message, key, alphabet);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }

        /// <summary>
        /// Test to verify that the Encrypt function returns the correct encrypted message when an invalid key is provided.
        /// </summary>
        [Fact]
        public void Encrypt_InvalidKeyProvided_ShouldReturnEncryptedMessage()
        {
            // Arrange
            string message = "Hello, World!";
            int key = -3;
            string expectedEncryptedMessage = "Ebiil, Tloia!";

            // Act
            string encryptedMessage = Caesar.Encrypt(message, key);

            // Assert
            Assert.Equal(expectedEncryptedMessage, encryptedMessage);
        }

        /// <summary>
        /// Test to verify that the Decrypt function returns the correct decrypted message when an invalid key is provided.
        /// </summary>
        [Fact]
        public void Decrypt_InvalidKeyProvided_ShouldReturnDecryptedMessage()
        {
            // Arrange
            string message = "Ebiil, Tloia!";
            int key = 49;
            string expectedDecryptedMessage = "Hello, World!";

            // Act
            string decryptedMessage = Caesar.Decrypt(message, key);

            // Assert
            Assert.Equal(expectedDecryptedMessage, decryptedMessage);
        }

        /// <summary>
        /// Test to verify that the Encrypt function returns all possible encrypted messages when a key is not provided.
        /// </summary>
        [Fact]
        public void Encrypt_KeyNotProvided_ShouldReturnPossibleEncryptedMessages()
        {
            // Arrange
            string message = "Hello, World!";
            Dictionary<int, string> expectedEncryptedMessages = new Dictionary<int, string>
            {
                { 0, "Hello, World!" },
                { 1, "Ifmmp, Xpsme!" },
                { 2, "Jgnnq, Yqtnf!" },
                { 3, "Khoor, Zruog!" },
                { 4, "Lipps, Asvph!" },
                { 5, "Mjqqt, Btwqi!" },
                { 6, "Nkrru, Cuxrj!" },
                { 7, "Olssv, Dvysk!" },
                { 8, "Pmttw, Ewztl!" },
                { 9, "Qnuux, Fxaum!" },
                { 10, "Rovvy, Gybvn!" },
                { 11, "Spwwz, Hzcwo!" },
                { 12, "Tqxxa, Iadxp!" },
                { 13, "Uryyb, Jbeyq!" },
                { 14, "Vszzc, Kcfzr!" },
                { 15, "Wtaad, Ldgas!" },
                { 16, "Xubbe, Mehbt!" },
                { 17, "Yvccf, Nficu!" },
                { 18, "Zwddg, Ogjdv!" },
                { 19, "Axeeh, Phkew!" },
                { 20, "Byffi, Qilfx!" },
                { 21, "Czggj, Rjmgy!" },
                { 22, "Dahhk, Sknhz!" },
                { 23, "Ebiil, Tloia!" },
                { 24, "Fcjjm, Umpjb!" },
                { 25, "Gdkkn, Vnqkc!" }
            };

            // Act
            Dictionary<int, string> encryptedMessages = Caesar.Encrypt(message);

            // Assert
            Assert.Equal(expectedEncryptedMessages.Count, encryptedMessages.Count);
            foreach (var kvp in expectedEncryptedMessages)
            {
                Assert.True(encryptedMessages.ContainsKey(kvp.Key));
                Assert.Equal(kvp.Value, encryptedMessages[kvp.Key]);
            }
            Assert.Equal(expectedEncryptedMessages, encryptedMessages);
        }

        /// <summary>
        /// Test to verify that the Decrypt function returns all possible decrypted messages when a key is not provided.
        /// </summary>
        [Fact]
        public void Decrypt_KeyNotProvided_ShouldReturnPossibleDecryptedMessages()
        {
            // Arrange
            string message = "Khoor, Zruog!";
            Dictionary<int, string> expectedDecryptedMessages = new Dictionary<int, string>
            {
                { 0, "Khoor, Zruog!" },
                { 1, "Jgnnq, Yqtnf!" },
                { 2, "Ifmmp, Xpsme!" },
                { 3, "Hello, World!" },
                { 4, "Gdkkn, Vnqkc!" },
                { 5, "Fcjjm, Umpjb!" },
                { 6, "Ebiil, Tloia!" },
                { 7, "Dahhk, Sknhz!" },
                { 8, "Czggj, Rjmgy!" },
                { 9, "Byffi, Qilfx!" },
                { 10, "Axeeh, Phkew!" },
                { 11, "Zwddg, Ogjdv!" },
                { 12, "Yvccf, Nficu!" },
                { 13, "Xubbe, Mehbt!" },
                { 14, "Wtaad, Ldgas!" },
                { 15, "Vszzc, Kcfzr!" },
                { 16, "Uryyb, Jbeyq!" },
                { 17, "Tqxxa, Iadxp!" },
                { 18, "Spwwz, Hzcwo!" },
                { 19, "Rovvy, Gybvn!" },
                { 20, "Qnuux, Fxaum!" },
                { 21, "Pmttw, Ewztl!" },
                { 22, "Olssv, Dvysk!" },
                { 23, "Nkrru, Cuxrj!" },
                { 24, "Mjqqt, Btwqi!" },
                { 25, "Lipps, Asvph!" }
            };

            // Act
            Dictionary<int, string> decryptedMessages = Caesar.Decrypt(message);

            // Assert
            Assert.Equal(expectedDecryptedMessages, decryptedMessages);
        }
    }
}
