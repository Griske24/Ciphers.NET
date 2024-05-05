# Ciphers.NET
A .NET package for text encryption and decryption using classic ciphers.

Supported ciphers:
- [A1Z26](#a1z26)
- [Affine](#affine)
- [Atbash](#atbash)
- [Caesar](#caesar)
- [Morse](#morse)

Features:
* Supports optional custom parameters, such as Alphabet, Key, A and B coefficients.
* Supports most cases where invalid (out of bounds) parameters are being provided e.g. encrypting a message with Caesar cipher with the Key bigger than the alphabet length - Key will be adjusted to fit the length.
* When encrypting/decrypting a message using `Caesar` cipher and not providing the `Key` - a dictionary (`Dictionary<int, string>`) is returned that contains all of the messages for every possible Key.
* When encrypting/decrypting a message using `Affine` cipher and not providing `A` and `B` coefficients - a dictionary (`Dictionary<Tuple<int, int>, string>`) is returned that contains all of the messages for every possible A and B combination.

## Installation
Package Manager
```powershell
Install-Package Ciphers.NET
```

.NET CLI
```powershell
dotnet add package Ciphers.NET
```

PackageReference (Add to your `.csproj` file)
```cs
<PackageReference Include="Ciphers.NET" Version="1.0.0" />
```

## Usage
### A1Z26
Basic Encryption and Decryption:
```cs
string message = "Hello World!";
string encryptedMessage = A1Z26.Encrypt(message);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = A1Z26.Decrypt(encryptedMessage);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with a Custom Alphabet:
```cs
string message = "Hello World! 123";
string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
string encryptedMessage = A1Z26.Encrypt(message, alphabet: alphabet);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = A1Z26.Decrypt(encryptedMessage, alphabet: alphabet);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with a Custom Key:
```cs
string message = "Hello World!";
int key = 3;
string encryptedMessage = A1Z26.Encrypt(message, key: key);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = A1Z26.Decrypt(encryptedMessage, key: key);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with a Custom Separator:
```cs
string message = "Hello World!";
char separator = '-';
string encryptedMessage = A1Z26.Encrypt(message, separator: separator);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = A1Z26.Decrypt(encryptedMessage, separator: separator);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

### Affine
Basic Encryption and Decryption:
```cs
string message = "Hello";
int a = 5;
int b = 8;
string encryptedMessage = Affine.Encrypt(message, a, b);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = Affine.Decrypt(encryptedMessage, a, b);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with All Possible (a, b) Pairs:
```cs
string message = "Affine";
Dictionary<Tuple<int, int>, string> encryptedMessages = Affine.Encrypt(message);
foreach (var pair in encryptedMessages)
{
    Console.WriteLine($"a: {pair.Key.Item1}, b: {pair.Key.Item2}, Encrypted Message: {pair.Value}");
}

string encryptedMessage = "Baainf";
Dictionary<Tuple<int, int>, string> decryptedMessages = Affine.Decrypt(encryptedMessage);
foreach (var pair in decryptedMessages)
{
    Console.WriteLine($"a: {pair.Key.Item1}, b: {pair.Key.Item2}, Decrypted Message: {pair.Value}");
}
```

### Atbash
Basic Encryption and Decryption:
```cs
string message = "Hello, World!";
string encryptedMessage = Atbash.Encrypt(message);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = Atbash.Decrypt(encryptedMessage);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with a Custom Alphabet:
```cs
string message = "Hello, World!123";
string customAlphabet = "abcdefghijklmnopqrstuvwxyz123";
string encryptedMessage = Atbash.Encrypt(message, customAlphabet);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = Atbash.Decrypt(encryptedMessage, customAlphabet);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

### Caesar
Basic Encryption and Decryption:
```cs
string message = "Hello, World!";
int key = 3;
string encryptedMessage = Caesar.Encrypt(message, key);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = Caesar.Decrypt(encryptedMessage, key);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with a Custom Alphabet:
```cs
string message = "Hello, Earth-616!";
int key = 3;
string customAlphabet = "abcdefghijklmnopqrstuvwxyz0123456789";
string encryptedMessage = Caesar.Encrypt(message, key, customAlphabet);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = Caesar.Decrypt(encryptedMessage, key, customAlphabet);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with an Invalid Key:
```cs
string message = "Hello, World!";
int key = -3;
string encryptedMessage = Caesar.Encrypt(message, key);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

key = 49;
string decryptedMessage = Caesar.Decrypt(encryptedMessage, key);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

Encryption and Decryption with All Possible Keys:
```cs
string message = "Hello, World!";
Dictionary<int, string> encryptedMessages = Caesar.Encrypt(message);
foreach (var pair in encryptedMessages)
{
    Console.WriteLine($"Key: {pair.Key}, Encrypted Message: {pair.Value}");
}

string encryptedMessage = "Khoor, Zruog!";
Dictionary<int, string> decryptedMessages = Caesar.Decrypt(encryptedMessage);
foreach (var pair in decryptedMessages)
{
    Console.WriteLine($"Key: {pair.Key}, Decrypted Message: {pair.Value}");
}
```

### Morse
Basic Encryption and Decryption:
```cs
string message = "Hello, World!";
string encryptedMessage = Morse.Encrypt(message);
Console.WriteLine($"Encrypted Message: {encryptedMessage}");

string decryptedMessage = Morse.Decrypt(encryptedMessage);
Console.WriteLine($"Decrypted Message: {decryptedMessage}");
```

## Licensing
This project is licensed under the MIT license.
Copyright (c) 2024 Griske24
