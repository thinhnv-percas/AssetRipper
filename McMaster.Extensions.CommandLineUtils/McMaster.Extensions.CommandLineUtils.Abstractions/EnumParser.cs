using System;
using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils.Abstractions;

internal static class EnumParser
{
	public static IValueParser Create(Type enumType)
	{
		return ValueParser.Create(enumType, delegate(string argName, string value, CultureInfo culture)
		{
			if (value == null)
			{
				return Enum.ToObject(enumType, 0);
			}
			try
			{
				return Enum.Parse(enumType, value, ignoreCase: true);
			}
			catch
			{
				throw new FormatException("Invalid value specified for " + argName + ". Allowed values are: " + string.Join(", ", Enum.GetNames(enumType)) + ".");
			}
		});
	}
}
