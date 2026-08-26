using System.Globalization;

namespace McMaster.Extensions.CommandLineUtils;

internal interface IInternalCommandParamOfT
{
	void Parse(CultureInfo culture);
}
