using System;
using System.ComponentModel.DataAnnotations;

namespace Q3
{
	class Program
	{
		private const string passwordMessageTemplate = "Password {0}{1}";
		private const string _validMessageSuffixTemplate = " is valid!";
		private const string _invalidMessageSuffixTemplate = " is NOT valid!";

		static void Main(string[] args)
		{
			// NOTE FROM [TK]: I did this in 2h.
			// print initial message and provide a password
			Console.WriteLine("Write a password. Example: \"Test123$\"");
			string password = Console.ReadLine();
			Console.WriteLine(string.Format(passwordMessageTemplate, password, string.Empty));
			bool isValid = false;
			try
			{
				PasswordValidator passwordValidator = new PasswordValidator();
				// validate password
				isValid = passwordValidator.ValidatePassword(password);
			}
			catch (ValidationException ex)
			{
				Console.WriteLine(ex.Message);
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
			finally
			{
				// print validation message
				Console.WriteLine(string.Format(passwordMessageTemplate, password, isValid ? _validMessageSuffixTemplate : _invalidMessageSuffixTemplate));
			}

			Console.ReadLine();
		}
	}
}
