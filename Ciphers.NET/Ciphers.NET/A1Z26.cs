using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET
{
    public class A1Z26
    {
        /// <summary>
        /// Encrypts a message using the A1Z26 cipher with selected separator, key and alphabet.
        /// </summary>
        /// <param name="message">The message to encrypt.</param>
        /// <param name="alphabet">The alphabet to use for the encryption. Default is the English alphabet.</param>
        /// <param name="separator">The separator to use for encryption.</param>
        /// <param name="key">The key to use for the encryption.</param>
        /// <returns>The encrypted message.</returns>
        public static string Encrypt(string message, string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", char separator = ' ', int key = 0)
        {
            key = AdjustKey(key, alphabet.Length);

            StringBuilder encryptedMessage = new StringBuilder();
            foreach (char character in message.ToUpperInvariant())
            {
                int charIndex = alphabet.IndexOf(character);
                if (charIndex != -1)
                {
                    int newCharIndex = (charIndex + key) % alphabet.Length;
                    int encryptedChar = newCharIndex + 1;
                    encryptedMessage.Append(encryptedChar.ToString() + separator);
                }
                else
                {
                    encryptedMessage.Append("");
                }
            }

            if (encryptedMessage.Length > 0 && encryptedMessage[^1] == separator)
            {
                encryptedMessage.Length--;
            }

            return encryptedMessage.ToString();
        }

        /// <summary>
        /// Decrypts a message encrypted with the A1Z26 cipher with selected separator, key and alphabet.
        /// </summary>
        /// <param name="encryptedMessage">The message to decrypt.</param>
        /// <param name="alphabet">The alphabet to use for the decryption. Default is the English alphabet.</param>
        /// <param name="separator">The separator used in encrypted message.</param>
        /// <param name="key">The key to use for the decryption.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(string encryptedMessage, string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ", char separator = ' ', int key = 0)
        {
            key = AdjustKey(key, alphabet.Length);

            StringBuilder decryptedMessage = new StringBuilder();
            StringBuilder numericSequence = new StringBuilder();

            foreach (char character in encryptedMessage)
            {
                if (char.IsDigit(character))
                {
                    numericSequence.Append(character);
                }
                else if (character == separator)
                {
                    // Convert the numeric sequence to the corresponding characters and append to the decrypted message
                    string numericString = numericSequence.ToString();
                    if (!string.IsNullOrEmpty(numericString))
                    {
                        int encryptedChar = int.Parse(numericString);
                        int charIndex = (encryptedChar - 1 + alphabet.Length - key) % alphabet.Length;
                        decryptedMessage.Append(alphabet[charIndex]);
                        numericSequence.Clear();
                    }
                    
                    decryptedMessage.Append("");
                }
                else
                {
                    decryptedMessage.Append("");
                }
            }
            // Append the last numeric sequence if any
            string lastNumericSequence = numericSequence.ToString();
            if (!string.IsNullOrEmpty(lastNumericSequence))
            {
                int encryptedChar = int.Parse(lastNumericSequence);
                int charIndex = (encryptedChar - 1 + alphabet.Length - key) % alphabet.Length;
                decryptedMessage.Append(alphabet[charIndex]);
            }

            if (decryptedMessage.Length > 0 && decryptedMessage[^1] == separator)
            {
                decryptedMessage.Length--;
            }

            return decryptedMessage.ToString();
        }

        /// <summary>
        /// Adjusts the key to be within the range of the alphabet length.
        /// </summary>
        /// <param name="key">The key to adjust.</param>
        /// <param name="alphabetLength">The length of the alphabet.</param>
        /// <returns>The adjusted key.</returns>
        private static int AdjustKey(int key, int alphabetLength)
        {
            if (key < 0)
            {
                key += alphabetLength;
            }
            return key % alphabetLength;
        }
    }
}
