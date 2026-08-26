using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Microsoft.DiaSymReader.Tools;

internal static class ConverterResources
{
	internal static CultureInfo Culture { get; set; }

	internal static ResourceManager ResourceManager { get; } = new ResourceManager("Microsoft.DiaSymReader.Tools.ConverterResources", typeof(ConverterResources).GetTypeInfo().Assembly);

	internal static string MetadataNotAvailable => ResourceManager.GetString("MetadataNotAvailable", Culture);

	internal static string StreamMustBeReadable => ResourceManager.GetString("StreamMustBeReadable", Culture);

	internal static string StreamMustBeSeakable => ResourceManager.GetString("StreamMustBeSeakable", Culture);

	internal static string StreamMustBeWritable => ResourceManager.GetString("StreamMustBeWritable", Culture);
}
