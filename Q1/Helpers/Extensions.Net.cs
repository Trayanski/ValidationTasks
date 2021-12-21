using System;
using System.Linq;

namespace Q1.Helpers
{
	#region IntegerExtensions

	public static class IntegerExtensions
	{
		public static bool IsEven(this int value)
		{
			return value % 2 == 0;
		}

		//public static bool IsOdd(this int value)
		//{
		//	return !value.IsEven();
		//}
	}

	#endregion // IntegerExtensions

	////////////////////////////////////////////////////////////////////////////////////////////////////
	#region StringExtensions

	public static class StringExtensions
	{
		public static bool IsContaiedIntEven(this string value)
		{
			try
			{
				if (!value.Any(char.IsDigit))
					throw new FormatException("The provided string must contain only digits.");

				int.TryParse(value, out int valueAsInt);
				return valueAsInt.IsEven();
			}
			catch (FormatException ex)
			{
				Console.WriteLine(ex.Message);
				throw;
			}
		}
	}

	#endregion // StringExtensions
}
