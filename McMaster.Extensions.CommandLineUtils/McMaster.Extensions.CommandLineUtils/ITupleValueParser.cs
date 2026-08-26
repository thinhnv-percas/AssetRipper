using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils;

internal interface ITupleValueParser
{
	object Parse(bool hasValue, string argName, string value, CultureInfo culture);
}
