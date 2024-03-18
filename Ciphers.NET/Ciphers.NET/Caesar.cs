using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET
{
    public class Caesar
    {
        /// <summary>
        /// Encrypts a message using the Caesar cipher with selected key and alphabet.
        /// </summary>
        /// <param name="message">The message to encrypt.</param>
        /// <param name="key">The key to use for the encryption. The key value will be adjusted to be within the range of the alphabet length.</param>
        /// <param name="alphabet">The alphabet to use for the encryption. Default is the English alphabet.</param>
        /// <returns>The encrypted message.</returns>
        public static string Encrypt(string message, int key, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            key = AdjustKey(key, alphabet.Length);

            return Shift(message, key, alphabet);
        }

        /// <summary>
        /// Encrypts a message using all possible keys of the Caesar cipher with selected alphabet.
        /// </summary>
        /// <param name="message">The message to encrypt.</param>
        /// <param name="alphabet">The alphabet to use for the encryption. Default is the English alphabet.</param>
        /// <returns>A dictionary where the key is the encryption key and the value is the encrypted message.</returns>
        public static Dictionary<int, string> Encrypt(string message, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            Dictionary<int, string> encryptedMessages = new Dictionary<int, string>();
            for (int key = 0; key < alphabet.Length; key++)
            {
                encryptedMessages.Add(key, Shift(message, key, alphabet));
            }
            return encryptedMessages;
        }

        /// <summary>
        /// Decrypts a message encrypted with the Caesar cipher with selected key and alphabet.
        /// </summary>
        /// <param name="message">The message to decrypt.</param>
        /// <param name="key">The key to use for the decryption. The key value will be adjusted to be within the range of the alphabet length.</param>
        /// <param name="alphabet">The alphabet to use for the decryption. Default is the English alphabet.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(string message, int key, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            key = AdjustKey(key, alphabet.Length);

            return Shift(message, -key, alphabet);
        }

        /// <summary>
        /// Decrypts a message using all possible keys of the Caesar cipher with selected alphabet.
        /// </summary>
        /// <param name="message">The message to decrypt.</param>
        /// <param name="alphabet">The alphabet to use for the decryption. Default is the English alphabet.</param>
        /// <returns>A dictionary where the key is the decryption key and the value is the decrypted message.</returns>
        public static Dictionary<int, string> Decrypt(string message, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            Dictionary<int, string> decryptedMessages = new Dictionary<int, string>();
            for (int key = 0; key < alphabet.Length; key++)
            {
                decryptedMessages.Add(key, Shift(message, -key, alphabet));
            }
            return decryptedMessages;
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

        /// <summary>
        /// Shifts the characters in a message by a certain amount.
        /// </summary>
        /// <param name="message">The message to shift.</param>
        /// <param name="shift">The amount to shift the characters by.</param>
        /// <param name="alphabet">The alphabet to use for the shift.</param>
        /// <returns>The shifted message.</returns>
        private static string Shift(string message, int shift, string alphabet)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            foreach (char character in message)
            {
                int charIndex = alphabet.IndexOf(char.ToLower(character));
                if (charIndex != -1)
                {
                    int newCharIndex = (charIndex + shift + alphabet.Length) % alphabet.Length;
                    char shiftedChar = alphabet[newCharIndex];
                    encryptedMessage.Append(char.IsUpper(character) ? char.ToUpper(shiftedChar) : shiftedChar);
                }
                else
                {
                    encryptedMessage.Append(character);
                }
            }
            return encryptedMessage.ToString();
        }
    }
}
