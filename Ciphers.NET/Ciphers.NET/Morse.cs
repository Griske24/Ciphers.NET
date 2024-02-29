using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ciphers.NET
{
    public class Morse
    {
        /// <summary>
        /// Dictionary to map each character to its corresponding Morse code
        /// </summary>
        private static readonly Dictionary<char, string> _morseCodeMap = new Dictionary<char, string>()
        {
            {'A', ".-"}, {'B', "-..."}, {'C', "-.-."}, {'D', "-.."}, {'E', "."},
            {'F', "..-."}, {'G', "--."}, {'H', "...."}, {'I', ".."}, {'J', ".---"},
            {'K', "-.-"}, {'L', ".-.."}, {'M', "--"}, {'N', "-."}, {'O', "---"},
            {'P', ".--."}, {'Q', "--.-"}, {'R', ".-."}, {'S', "..."}, {'T', "-"},
            {'U', "..-"}, {'V', "...-"}, {'W', ".--"}, {'X', "-..-"}, {'Y', "-.--"},
            {'Z', "--.."}, { '0', "-----"}, { '1', ".----"}, { '2', "..---"}, { '3', "...--"},
            { '4', "....-"}, { '5', "....."}, { '6', "-...."}, { '7', "--..." }, { '8', "---.." },
            { '9', "----." }, { '.', ".-.-.-"}, { ',', "--..--"}, { ' ', "/" }, { '?', "..--.."},
            { '!', "-.-.--"}, { '@', ".--.-."}, { '&', ".-..."}, { ':', "---..."}, { ';', "-.-.-."},
            { '(', "-.--."}, { ')', "-.--.-"}, { '=', "-...-"}, { '+', ".-.-."}, { '-', "-....-"},
            { '_', "..--.-"}, { '"', ".-..-."}, { '$', "...-..-"}, { '%', "-..-.--"}, { '/', "-..-."},
            { '\'', ".----." }
        };

        /// <summary>
        /// Encrypts a message into Morse code.
        /// </summary>
        /// <param name="message">The message to encrypt.</param>
        /// <returns>The encrypted message in Morse code. Unknown characters are replaced with '/'.</returns>
        public static string Encrypt(string message)
        {
            StringBuilder encryptedMessage = new StringBuilder();
            foreach (char character in message.ToUpperInvariant())
            {
                if (_morseCodeMap.ContainsKey(character))
                {
                    encryptedMessage.Append(_morseCodeMap[character]).Append(' ');
                }
                else
                {
                    encryptedMessage.Append("/");
                }
            }
            return encryptedMessage.ToString().TrimEnd();
        }

        /// <summary>
        /// Decrypts a Morse code message back into English.
        /// </summary>
        /// <param name="morseCode">The Morse code message to decrypt.</param>
        /// <returns>The decrypted message in English. Unknown Morse code units are replaced with '?'.</returns>
        public static string Decrypt(string morseCode)
        {
            string[] codeUnits = morseCode.Split(' ');
            StringBuilder decryptedMessage = new StringBuilder();
            foreach (string codeUnit in codeUnits)
            {
                if (codeUnit.Equals("/"))
                {
                    decryptedMessage.Append(' ');
                }
                else
                {
                    char character = _morseCodeMap.FirstOrDefault(kvp => kvp.Value.Equals(codeUnit)).Key;
                    if (character != default(char))
                    {
                        decryptedMessage.Append(character);
                    }
                    else
                    {
                        decryptedMessage.Append("?");
                    }
                }
            }
            return decryptedMessage.ToString().Trim();
        }
    }
}
