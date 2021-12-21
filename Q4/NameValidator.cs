using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Q4
{
	class NameValidator
	{
		private static readonly string regex_pattern_name = @"^(?:(?:(?:[A-Z])\.\ ){1,2}|(?:(?:[A-Z])(?:[a-z])+\ ){2}|(?:(?:[A-Z])(?:[a-z])+\ )(?:(?:[A-Z])\.\ ))(?:(?:[A-Z])(?:[a-z])+)";

		public bool ValidateName(string name)
		{
			name = name.Trim();

			Match match = Regex.Match(name, regex_pattern_name);
			if (!string.Equals(match.Value, name))
				return false;

			return true;
		}

		public bool ValidateNames(List<string> names)
		{
			for (int i = 0; i < names.Count; i++)
			{
				if (!ValidateName(names[i]))
					return false;
			}

			return true;
		}
	}
}
