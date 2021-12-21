using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Q4
{
	class Program
	{
		private const string message_result_template = "Provided {0} name(s) {1} is/are validated as {2}.";
		private const string message_issueInImplementation = "Error in the code!";
		private const string message_valid = "valid";
		private static readonly string message_invalid = $"in{message_valid}";

		private static readonly List<string> providedValidNames = new List<string>() { "H. Wells", "H. G. Wells", "Herbert G. Wells", "Herbert George Wells" }; 
		private static readonly List<string> providedInvalidNames = new List<string>()
		{ 
			// single names not allowed
			"Herbert", 
			"Wells", 
			// initials must end with dot
			"H Wells",
			"H. G Wells",
			// incorrect capitalization
			"h. Wells",
			"H. wells",
			"h. g. Wells",
			// middle name expanded, while first still left as initial
			"H. George Wells",
			// last name is not a word
			"H. G. W.",
			// dot only allowed after initial, not word
			"Herb. G. Wells"
		}; 
		static void Main(string[] args)
		{
			// NOTE FROM [TK]: I did this in 2:40h.
			try
			{
				NameValidator nameValidator = new NameValidator();
				// validate valid names
				Console.WriteLine("Summary:");
				bool areProvidedValidNamesValid = nameValidator.ValidateNames(providedValidNames);
				Console.WriteLine(string.Format(message_result_template, message_valid, string.Join(", ", providedValidNames), areProvidedValidNamesValid ? message_valid : message_invalid));
				if (areProvidedValidNamesValid)
					Console.WriteLine(message_issueInImplementation);

				Console.WriteLine("Specifications:");
				for (int i = 0; i < providedValidNames.Count; i++)
				{
					string currentValidName = providedValidNames[i];
					Console.WriteLine(string.Format(message_result_template, message_valid, currentValidName, nameValidator.ValidateName(currentValidName) ? message_valid : message_invalid));
				}

				Console.WriteLine();
				
				// validate invalid names
				Console.WriteLine("Summary:");
				bool areProvidedInvalidNamesValid = nameValidator.ValidateNames(providedInvalidNames);
				Console.WriteLine(string.Format(message_result_template, message_invalid, string.Join(", ", providedInvalidNames), areProvidedInvalidNamesValid ? message_valid : message_invalid));
				if (areProvidedInvalidNamesValid)
					Console.WriteLine(message_issueInImplementation);

				Console.WriteLine("Specifications:");
				for (int i = 0; i < providedInvalidNames.Count; i++)
				{
					string currentInvalidName = providedInvalidNames[i];
					Console.WriteLine(string.Format(message_result_template, message_invalid, currentInvalidName, nameValidator.ValidateName(currentInvalidName) ? message_valid : message_invalid));
				}

				Console.WriteLine("\nPlease write one name or many names separated by ',' and the program will validate it/them for you:");
				string names = Console.ReadLine();
				string[] namesArray = names.Split(',');
				foreach (var name in namesArray)
				{
					Console.WriteLine(string.Format(message_result_template, string.Empty, name, nameValidator.ValidateName(name) ? message_valid : message_invalid));
				}
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
		}
	}
}
