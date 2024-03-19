using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET
{
    public class Atbash
    {
        /// <summary>
        /// Encrypts a message using the Atbash cipher with selected alphabet.
        /// </summary>
        /// <param name="message">The message to encrypt.</param>
        /// <param name="alphabet">The alphabet to use for the encryption. Default is the English alphabet.</param>
        /// <returns>The encrypted message.</returns>
        public static string Encrypt(string message, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            StringBuilder encryptedMessage = new StringBuilder();
            foreach (char character in message)
            {
                int charIndex = alphabet.IndexOf(char.ToLower(character));
                if (charIndex != -1)
                {
                    int reversedIndex = alphabet.Length - charIndex - 1;
                    encryptedMessage.Append(char.IsUpper(character) ? char.ToUpper(alphabet[reversedIndex]) : alphabet[reversedIndex]);
                }
                else
                {
                    encryptedMessage.Append(character);
                }
            }
            return encryptedMessage.ToString();
        }

        /// <summary>
        /// Decrypts a message encrypted with the Atbash cipher with selected alphabet.
        /// </summary>
        /// <param name="encryptedMessage">The message to decrypt.</param>
        /// <param name="alphabet">The alphabet to use for the decryption. Default is the English alphabet.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(string encryptedMessage, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            return Encrypt(encryptedMessage, alphabet);
        }
    }
}
