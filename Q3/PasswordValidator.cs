using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Q3
{
	class PasswordValidator
	{
		private const int minCharacterCount = 6;
		private const int maxCharacterCount = 24;
		private const int maxRepeatedCharactersCount = 2;

		private const string exceptionMessage_length_template = "Length between {0} and {1} characters.";
		private const string exceptionMessage_upperCase = "At least one uppercase letter (A-Z).";
		private const string exceptionMessage_lowerCase = "At least one lowercase letter (a-z).";
		private const string exceptionMessage_digit = "At least one digit (0-9).";
		private const string exceptionMessage_specialCharacters = "Supported special characters (! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; \" ' ? < > , .)";
		private const string exceptionMessage_maxRepeatedCharacters = "Maximum of 2 repeated characters.";

		private const string _regex_upperCase = "A-Z";
		private const string _regex_lowerCase = "a-z";
		private const string _regex_digit = "\\d";
		private const string _regex_specialCharacters = "!@#\\$%\\^&\\*\\(\\)\\+=_-{}\\[\\]:;\"'\\?<>,\\.";
		private const string regex_pattern_base_template = "^{0}.{1}";
		private const string regex_pattern_atLeastOneCharInSet_template = "(?=.*[{0}])";
		private const string regex_pattern_maxRepeatedCharacters_template = "(?!.*([{0}{1}{2}{3}])\\1{4})";

		private static readonly string regex_pattern_length = "{" + minCharacterCount + "," + maxCharacterCount + "}";
		private static readonly string regex_pattern_atLeastOneCharInSet_upperCase = string.Format(regex_pattern_atLeastOneCharInSet_template, _regex_upperCase);
		private static readonly string regex_pattern_atLeastOneCharInSet_lowerCase = string.Format(regex_pattern_atLeastOneCharInSet_template, _regex_lowerCase);
		private static readonly string regex_pattern_atLeastOneCharInSet_digit = string.Format(regex_pattern_atLeastOneCharInSet_template, _regex_digit);
		private static readonly string regex_pattern_atLeastOneCharInSet_specialCharacters = string.Format(regex_pattern_atLeastOneCharInSet_template, _regex_specialCharacters);
		private static readonly string _regex_pattern_maxRepeatedCharactersCount = "{" + maxRepeatedCharactersCount + "}";
		private static readonly string regex_pattern_maxRepeatedCharacters = string.Format(regex_pattern_maxRepeatedCharacters_template, _regex_upperCase, _regex_lowerCase, _regex_digit, _regex_specialCharacters, _regex_pattern_maxRepeatedCharactersCount);

		public bool ValidatePassword(string password)
		{
			password = password.Trim();

			// All in one
			//if (!Regex.IsMatch(password, "^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#\\$%\\^&\\*\\(\\)\\+=_-{}\\[\\]:;\"'\\?<>,\\.])(?!.*([A-Za-z\\d!@#\\$%\\^&\\*\\(\\)\\+=_-{}\\[\\]:;\"'\\?<>,\\.])\\1{2}).{6,24}"))
			//	return false;

			// "^.{6,24}"
			string regex_pattern = string.Format(regex_pattern_base_template, string.Empty, regex_pattern_length);
			if (!Regex.IsMatch(password, regex_pattern))
				throw new ValidationException(string.Format(exceptionMessage_length_template, minCharacterCount, maxCharacterCount));

			// "^(?=.*[A-Z])."
			regex_pattern = string.Format(regex_pattern_base_template, regex_pattern_atLeastOneCharInSet_upperCase, string.Empty);
			if (!Regex.IsMatch(password, regex_pattern))
				throw new ValidationException(exceptionMessage_upperCase);

			// "^(?=.*[a-z])."
			regex_pattern = string.Format(regex_pattern_base_template, regex_pattern_atLeastOneCharInSet_lowerCase, string.Empty);
			if (!Regex.IsMatch(password, regex_pattern))
				throw new ValidationException(exceptionMessage_lowerCase);

			// "^(?=.*[\\d])."
			regex_pattern = string.Format(regex_pattern_base_template, regex_pattern_atLeastOneCharInSet_digit, string.Empty);
			if (!Regex.IsMatch(password, regex_pattern))
				throw new ValidationException(exceptionMessage_digit);

			// "^(?=.*[!@#\\$%\\^&\\*\\(\\)\\+=_-{}\\[\\]:;\"'\\?<>,\\.])."
			regex_pattern = string.Format(regex_pattern_base_template, regex_pattern_atLeastOneCharInSet_specialCharacters, string.Empty);
			if (!Regex.IsMatch(password, regex_pattern))
				throw new ValidationException(exceptionMessage_specialCharacters);

			// "^(?!.*([A-Za-z\\d!@#\\$%\\^&\\*\\(\\)\\+=_-{}\\[\\]:;\"'\\?<>,\\.])\\1{2})."
			regex_pattern = string.Format(regex_pattern_base_template, regex_pattern_maxRepeatedCharacters, string.Empty);
			if (!Regex.IsMatch(password, regex_pattern))
				throw new ValidationException(exceptionMessage_maxRepeatedCharacters);

			return true;
		}
	}
}
