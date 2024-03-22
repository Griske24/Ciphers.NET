using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET
{
    public class Affine
    {
        /// <summary>
        /// Encrypts a given message using the Affine cipher.
        /// </summary>
        /// <param name="message">The message to be encrypted.</param>
        /// <param name="a">The 'a' coefficient in the affine cipher formula. Must be coprime with the length of the alphabet.</param>
        /// <param name="b">The 'b' coefficient in the affine cipher formula.</param>
        /// <param name="alphabet">The alphabet used for encryption. Default is the English alphabet in lowercase.</param>
        /// <returns>The encrypted message.</returns>
        public static string Encrypt(string message, int a, int b, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            ValidateParameters(a, b, alphabet.Length);

            StringBuilder encryptedMessage = new StringBuilder();
            foreach (char character in message)
            {
                if (char.IsLetter(character))
                {
                    bool isUpper = char.IsUpper(character);
                    int charIndex = alphabet.IndexOf(char.ToLower(character));

                    if (charIndex != -1)
                    {
                        int encryptedCharIndex = (a * charIndex + b) % alphabet.Length;
                        char encryptedChar = isUpper ? char.ToUpper(alphabet[encryptedCharIndex]) : alphabet[encryptedCharIndex];
                        encryptedMessage.Append(encryptedChar);
                    }
                    else
                    {
                        encryptedMessage.Append(character);
                    }
                }
                else
                {
                    encryptedMessage.Append(character);
                }
            }
            return encryptedMessage.ToString();
        }

        /// <summary>
        /// Decrypts a given message encrypted with the Affine cipher.
        /// </summary>
        /// <param name="encryptedMessage">The message to be decrypted.</param>
        /// <param name="a">The 'a' coefficient used in the affine cipher formula during encryption. Must be coprime with the length of the alphabet.</param>
        /// <param name="b">The 'b' coefficient used in the affine cipher formula during encryption.</param>
        /// <param name="alphabet">The alphabet used for decryption. Default is the English alphabet.</param>
        /// <returns>The decrypted message.</returns>
        public static string Decrypt(string encryptedMessage, int a, int b, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            ValidateParameters(a, b, alphabet.Length);

            int aInverse = ModInverse(a, alphabet.Length);
            StringBuilder decryptedMessage = new StringBuilder();
            foreach (char character in encryptedMessage)
            {
                if (char.IsLetter(character))
                {
                    bool isUpper = char.IsUpper(character);
                    int charIndex = alphabet.IndexOf(char.ToLower(character));

                    if (charIndex != -1)
                    {
                        int decryptedCharIndex = (aInverse * (charIndex - b + alphabet.Length)) % alphabet.Length;
                        char decryptedChar = isUpper ? char.ToUpper(alphabet[decryptedCharIndex]) : alphabet[decryptedCharIndex];
                        decryptedMessage.Append(decryptedChar);
                    }
                    else
                    {
                        decryptedMessage.Append(character);
                    }
                }
                else
                {
                    decryptedMessage.Append(character);
                }
            }
            return decryptedMessage.ToString();
        }

        /// <summary>
        /// Encrypts a given message using all possible (a, b) pairs in the Affine cipher where 'a' is coprime with the length of the alphabet.
        /// </summary>
        /// <param name="message">The message to be encrypted.</param>
        /// <param name="alphabet">The alphabet used for encryption. Default is the English alphabet.</param>
        /// <returns>A dictionary where the key is the (a, b) pair used for encryption and the value is the corresponding encrypted message.</returns>
        public static Dictionary<Tuple<int, int>, string> Encrypt(string message, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            Dictionary<Tuple<int, int>, string> encryptedMessages = new Dictionary<Tuple<int, int>, string>();
            for (int a = 1; a < alphabet.Length; a++)
            {
                if (IsCoprime(a, alphabet.Length))
                {
                    for (int b = 0; b < alphabet.Length; b++)
                    {
                        string encryptedMessage = Encrypt(message, a, b, alphabet);
                        encryptedMessages.Add(Tuple.Create(a, b), encryptedMessage);
                    }
                }
            }
            return encryptedMessages;
        }

        /// <summary>
        /// Decrypts a given message using all possible (a, b) pairs in the Affine cipher where 'a' is coprime with the length of the alphabet.
        /// </summary>
        /// <param name="encryptedMessage">The message to be decrypted.</param>
        /// <param name="alphabet">The alphabet used for decryption. Default is the English alphabet.</param>
        /// <returns>A dictionary where the key is the (a, b) pair used for decryption and the value is the corresponding decrypted message.</returns>
        public static Dictionary<Tuple<int, int>, string> Decrypt(string encryptedMessage, string alphabet = "abcdefghijklmnopqrstuvwxyz")
        {
            Dictionary<Tuple<int, int>, string> decryptedMessages = new Dictionary<Tuple<int, int>, string>();
            for (int a = 1; a < alphabet.Length; a++)
            {
                if (IsCoprime(a, alphabet.Length))
                {
                    for (int b = 0; b < alphabet.Length; b++)
                    {
                        string decryptedMessage = Decrypt(encryptedMessage, a, b, alphabet);
                        decryptedMessages.Add(Tuple.Create(a, b), decryptedMessage);
                    }
                }
            }
            return decryptedMessages;
        }

        /// <summary>
        /// Validates the parameters 'a' and 'b' used in the Affine cipher. Throws an exception if 'a' is not coprime with the length of the alphabet.
        /// </summary>
        /// <param name="a">The 'a' coefficient in the affine cipher formula.</param>
        /// <param name="b">The 'b' coefficient in the affine cipher formula.</param>
        /// <param name="alphabetLength">The length of the alphabet used in the cipher.</param>
        /// <exception cref="ArgumentException"></exception>
        private static void ValidateParameters(int a, int b, int alphabetLength)
        {
            if (!IsCoprime(a, alphabetLength))
            {
                throw new ArgumentException("Parameter 'a' must be coprime with the length of the alphabet.");
            }
        }

        /// <summary>
        /// Calculates the modular inverse of 'a' mod 'm'. Throws an exception if the modular inverse does not exist.
        /// </summary>
        /// <param name="a">The number to find the modular inverse of.</param>
        /// <param name="m">The modulus.</param>
        /// <returns>The modular inverse of 'a' mod 'm'.</returns>
        /// <exception cref="ArgumentException"></exception>
        private static int ModInverse(int a, int m)
        {
            a %= m;
            for (int x = 1; x < m; x++)
            {
                if ((a * x) % m == 1)
                {
                    return x;
                }
            }
            throw new ArgumentException("Modular inverse does not exist.");
        }

        /// <summary>
        /// Checks if two numbers 'a' and 'b' are coprime, i.e., their greatest common divisor (GCD) is 1
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>True if 'a' and 'b' are coprime, false otherwise.</returns>
        private static bool IsCoprime(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a == 1;
        }
    }
}
