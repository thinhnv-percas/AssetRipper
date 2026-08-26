using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace System.Composition.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager("System.Composition.Properties.Resources", typeof(Resources).GetTypeInfo().Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	internal static string CompositionContext_NoExportFoundForContract => ResourceManager.GetString("CompositionContext_NoExportFoundForContract", resourceCulture);

	internal static string CompositionFailedDefaultExceptionMessage => ResourceManager.GetString("CompositionFailedDefaultExceptionMessage", resourceCulture);

	internal static string Formatter_ListSeparatorWithSpace => ResourceManager.GetString("Formatter_ListSeparatorWithSpace", resourceCulture);

	internal Resources()
	{
	}
}
