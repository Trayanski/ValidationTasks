using System;
using System.Collections.Generic;

namespace Q2
{
	class Program
	{
		private const string providedEncryptionInput01 = "Hi";
		private const string providedEncryptionInput02 = "Xanthos";
		private const string providedDecryptionInput01 = "21422415331443";

		static void Main(string[] args)
		{
			// NOTE FROM [TK]: I did this in 45min.
			PolybiusSquare polybiusSquare = new PolybiusSquare();

			try
			{
				Console.Write("Provided Input 1: ");
				Console.WriteLine(providedEncryptionInput01);
				Console.Write("Encryption: ");
				string encryptedInput = polybiusSquare.EncryptMessage(providedEncryptionInput01);
				Console.WriteLine(encryptedInput);
				Console.Write("Decryption: ");
				string decryptedInput = polybiusSquare.DecryptMessage(encryptedInput);
				Console.WriteLine(decryptedInput);

				Console.WriteLine();

				Console.Write("Provided Input 2: ");
				Console.WriteLine(providedEncryptionInput02);
				Console.Write("Encryption: ");
				encryptedInput = polybiusSquare.EncryptMessage(providedEncryptionInput02);
				Console.WriteLine(encryptedInput);
				Console.Write("Decryption: ");
				decryptedInput = polybiusSquare.DecryptMessage(encryptedInput);
				Console.WriteLine(decryptedInput);

				Console.WriteLine();

				Console.Write("Provided Input 3: ");
				Console.WriteLine(providedDecryptionInput01);
				Console.Write("Decryption: ");
				decryptedInput = polybiusSquare.DecryptMessage(providedDecryptionInput01);
				Console.WriteLine(decryptedInput);
			}
			catch (KeyNotFoundException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (InvalidOperationException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (ArgumentException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}

			Console.ReadLine();
		}
	}
}
