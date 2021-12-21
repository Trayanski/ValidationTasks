using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Q2
{
	class PolybiusSquare
	{
		private const string decryptionTemplate = "{0}{1}";
		private const string encryptExceptionMessageTemplate = "The provided char '{0}' is not contained in the English althabet.";
		private const string decryptExceptionMessageTemplate = "The provided encription '{0}' is not valid.";

		private readonly Dictionary<char, int> database = new Dictionary<char, int>
		{
			{ 'A', 11 },
			{ 'B', 12 },
			{ 'C', 13 },
			{ 'D', 14 },
			{ 'E', 15 },
			{ 'F', 21 },
			{ 'G', 22 },
			{ 'H', 23 },
			{ 'I', 24 },
			{ 'J', 24 },
			{ 'K', 25 },
			{ 'L', 31 },
			{ 'M', 32 },
			{ 'N', 33 },
			{ 'O', 34 },
			{ 'P', 35 },
			{ 'Q', 41 },
			{ 'R', 42 },
			{ 'S', 43 },
			{ 'T', 44 },
			{ 'U', 45 },
			{ 'V', 51 },
			{ 'W', 52 },
			{ 'X', 53 },
			{ 'Y', 54 },
			{ 'Z', 55 }
		};

		private int? EncryptChar(char input)
		{
			int? encryption = null;
			try
			{
				encryption = database[char.ToUpper(input)];
			}
			catch (KeyNotFoundException)
			{
				throw;
			}

			return encryption;
		}

		private char? DecryptChar(int input)
		{
			char? decryption = null;
			try
			{
				decryption = database.First(x => x.Value == input).Key;
			}
			catch (InvalidOperationException)
			{
				throw;
			}

			return decryption;
		}

		public string EncryptMessage(string input)
		{
			StringBuilder encryptedInput = new StringBuilder();
			char[] inputArray = input.ToCharArray();
			for (int i = 0; i < inputArray.Length; i++)
			{
				char currentChar = inputArray[i];
				int? encryptedChar = EncryptChar(currentChar);
				if (encryptedChar == null)
					throw new KeyNotFoundException(string.Format(encryptExceptionMessageTemplate, currentChar));

				encryptedInput.Append(encryptedChar);
			}

			return encryptedInput.ToString();
		}

		public string DecryptMessage(string encryptedInput)
		{
			StringBuilder decryptedInput = new StringBuilder();
			char[] encryptedInputArray = encryptedInput.ToCharArray();
			for (int i = 0; i < encryptedInput.Length; i += 2)
			{
				int.TryParse(string.Format(decryptionTemplate, encryptedInputArray[i], encryptedInputArray[i + 1]), out int encryptedChar);
				char? decryptedChar = DecryptChar(encryptedChar);
				if (decryptedChar == null)
					throw new ArgumentException(string.Format(decryptExceptionMessageTemplate, encryptedChar));

				decryptedInput.Append(decryptedChar);
			}

			return decryptedInput.ToString();
		}
	}
}
