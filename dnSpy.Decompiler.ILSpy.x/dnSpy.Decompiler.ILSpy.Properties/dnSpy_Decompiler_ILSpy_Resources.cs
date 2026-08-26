using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace dnSpy.Decompiler.ILSpy.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class dnSpy_Decompiler_ILSpy_Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				ResourceManager resourceManager = new ResourceManager("dnSpy.Decompiler.ILSpy.Properties.dnSpy.Decompiler.ILSpy.Resources", typeof(dnSpy_Decompiler_ILSpy_Resources).Assembly);
				resourceMan = resourceManager;
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
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

	public static string CSharpDecompilerSettingsTabName => ResourceManager.GetString("CSharpDecompilerSettingsTabName", resourceCulture);

	public static string DecompilationOrder_Events => ResourceManager.GetString("DecompilationOrder_Events", resourceCulture);

	public static string DecompilationOrder_Fields => ResourceManager.GetString("DecompilationOrder_Fields", resourceCulture);

	public static string DecompilationOrder_Methods => ResourceManager.GetString("DecompilationOrder_Methods", resourceCulture);

	public static string DecompilationOrder_NestedTypes => ResourceManager.GetString("DecompilationOrder_NestedTypes", resourceCulture);

	public static string DecompilationOrder_Properties => ResourceManager.GetString("DecompilationOrder_Properties", resourceCulture);

	public static string ILDecompilerSettingsTabName => ResourceManager.GetString("ILDecompilerSettingsTabName", resourceCulture);

	public static string Plugin_ShortDescription => ResourceManager.GetString("Plugin_ShortDescription", resourceCulture);

	internal dnSpy_Decompiler_ILSpy_Resources()
	{
	}
}
