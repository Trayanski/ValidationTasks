using Q1.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Q1
{
	class Program
	{
		private const string providedInput01 = "594127169973391692147228678476";
		private const string providedInput02 = "498275991861592742273244667214";
		private const string outputTemplate_LongestSubstring = "Longest Substring :\"{0}\"";
		private const string outputTemplate_OtherSubstrings = "Other Substrings: {0}";
		private const int otherSubStringsMinimumCharacterCount = 1;

		static void Main(string[] args)
		{
			// NOTE FROM [TK]: I did this in 2h.
			Console.WriteLine("First provided input breakdown:");
			FindLongestSubString(providedInput01);
			Console.WriteLine("Second provided input breakdown:");
			FindLongestSubString(providedInput02);
			Console.ReadLine();
		}

		public static string FindLongestSubString(string input)
		{
			char[] inputArray = input.ToCharArray();
			bool nextCharShouldBeOdd = false;
			StringBuilder longestStringWannabe = new StringBuilder();
			string longestSubString = string.Empty;
			List<string> otherSubStrings = new List<string>();

			for (int i = 0; i < inputArray.Length; i++)
			{
				string currentCharAsString = inputArray[i].ToString();
				// check if current character is an even integer
				bool isCurrentIntegerEven = currentCharAsString.IsContaiedIntEven();
				// check if current character is the last one of the provided "input"
				bool isLastChar = i == inputArray.Length - 1;
				// check if current char will be the first in the current substring
				bool isFirstStoredChar = longestStringWannabe.Length == 0;
				// check if we can treat current integer as valid
				bool isValid = isCurrentIntegerEven != nextCharShouldBeOdd;
				if (isFirstStoredChar || isValid || isLastChar){
					longestStringWannabe.Append(currentCharAsString);
					nextCharShouldBeOdd = isCurrentIntegerEven;
				}

				if (!isFirstStoredChar && (!isValid || isLastChar))
				{
					string currentLongestSubString = longestStringWannabe.ToString();

					// Validation
					// - check if "currentLongestSubString" contains more than one digit
					// TODO [AS] FROM [TK]: Why are single characters not treated as a valid substring? 
					if (currentLongestSubString.Length > otherSubStringsMinimumCharacterCount)
						otherSubStrings.Add(currentLongestSubString);
					// - length check
					if (currentLongestSubString.Length > longestSubString.Length)
						longestSubString = currentLongestSubString;

					if (isLastChar)
						continue;
					
					// variable setup for next char
					longestStringWannabe.Clear();
					i--;
				}
			}

			Console.WriteLine(string.Format(outputTemplate_LongestSubstring, longestSubString));
			Console.WriteLine(string.Format(outputTemplate_OtherSubstrings, string.Join(",", otherSubStrings)));
			// returns the "longestSubString" for further future functionalities
			return longestSubString;
		}
	}
}
