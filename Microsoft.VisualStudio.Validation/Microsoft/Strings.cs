using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
internal class Strings
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
				resourceMan = new ResourceManager("Microsoft.Strings", typeof(Strings).Assembly);
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

	internal static string Argument_EmptyArray => ResourceManager.GetString("Argument_EmptyArray", resourceCulture);

	internal static string Argument_EmptyGuid => ResourceManager.GetString("Argument_EmptyGuid", resourceCulture);

	internal static string Argument_EmptyString => ResourceManager.GetString("Argument_EmptyString", resourceCulture);

	internal static string Argument_NullElement => ResourceManager.GetString("Argument_NullElement", resourceCulture);

	internal static string Argument_Whitespace => ResourceManager.GetString("Argument_Whitespace", resourceCulture);

	internal static string InternalExceptionMessage => ResourceManager.GetString("InternalExceptionMessage", resourceCulture);

	internal static string ServiceMissing => ResourceManager.GetString("ServiceMissing", resourceCulture);

	internal Strings()
	{
	}
}
