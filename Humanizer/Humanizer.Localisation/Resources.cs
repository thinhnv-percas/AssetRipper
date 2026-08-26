using System.Globalization;
using System.Reflection;
using System.Resources;

namespace Humanizer.Localisation;

public static class Resources
{
	private static readonly ResourceManager ResourceManager = new ResourceManager("Humanizer.Properties.Resources", typeof(Resources).GetTypeInfo().Assembly);

	public static string GetResource(string resourceKey, CultureInfo culture = null)
	{
		return ResourceManager.GetString(resourceKey, culture);
	}
}
