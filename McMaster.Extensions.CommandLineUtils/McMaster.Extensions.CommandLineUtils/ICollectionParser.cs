using System.Collections.Generic;

namespace McMaster.Extensions.CommandLineUtils;

internal interface ICollectionParser
{
	object Parse(string argName, IReadOnlyList<string> values);
}
