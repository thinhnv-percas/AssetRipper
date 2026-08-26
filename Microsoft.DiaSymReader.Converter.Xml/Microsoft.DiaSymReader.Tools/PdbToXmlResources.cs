using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Microsoft.DiaSymReader.Tools;

internal static class PdbToXmlResources
{
	internal static CultureInfo Culture { get; set; }

	internal static ResourceManager ResourceManager { get; } = new ResourceManager("Microsoft.DiaSymReader.Tools.PdbToXmlResources", typeof(PdbToXmlResources).GetTypeInfo().Assembly);

	internal static string UnexpectedTokenKind => ResourceManager.GetString("UnexpectedTokenKind", Culture);
}
