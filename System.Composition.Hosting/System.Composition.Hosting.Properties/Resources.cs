using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace System.Composition.Hosting.Properties;

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
				ResourceManager resourceManager = new ResourceManager("Properties.Resources", typeof(Resources).GetTypeInfo().Assembly);
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

	internal static string CardinalityMismatch_TooManyExports => ResourceManager.GetString("CardinalityMismatch_TooManyExports", resourceCulture);

	internal static string Component_NotCreatableOutsideSharingBoundary => ResourceManager.GetString("Component_NotCreatableOutsideSharingBoundary", resourceCulture);

	internal static string CompositionOperation_SharingLockRequired => ResourceManager.GetString("CompositionOperation_SharingLockRequired", resourceCulture);

	internal static string Dependency_ExportNotFound => ResourceManager.GetString("Dependency_ExportNotFound", resourceCulture);

	internal static string Dependency_QuoteParameter => ResourceManager.GetString("Dependency_QuoteParameter", resourceCulture);

	internal static string Dependency_TooManyExports => ResourceManager.GetString("Dependency_TooManyExports", resourceCulture);

	internal static string Dependency_ToStringFormat => ResourceManager.GetString("Dependency_ToStringFormat", resourceCulture);

	internal static string Diagnostic_ThrowingException => ResourceManager.GetString("Diagnostic_ThrowingException", resourceCulture);

	internal static string ExportDescriptor_DependencyErrorContract => ResourceManager.GetString("ExportDescriptor_DependencyErrorContract", resourceCulture);

	internal static string ExportDescriptor_DependencyErrorLine => ResourceManager.GetString("ExportDescriptor_DependencyErrorLine", resourceCulture);

	internal static string ExportDescriptor_ToStringFormat => ResourceManager.GetString("ExportDescriptor_ToStringFormat", resourceCulture);

	internal static string ExportDescriptor_UnsupportedCycle => ResourceManager.GetString("ExportDescriptor_UnsupportedCycle", resourceCulture);

	internal static string ExportDescriptorNull => ResourceManager.GetString("ExportDescriptorNull", resourceCulture);

	internal static string Formatter_ListSeparatorWithSpace => ResourceManager.GetString("Formatter_ListSeparatorWithSpace", resourceCulture);

	internal static string Formatter_None => ResourceManager.GetString("Formatter_None", resourceCulture);

	internal static string Keyword_MetadataViewProvider => ResourceManager.GetString("Keyword_MetadataViewProvider", resourceCulture);

	internal static string MetadataViewProvider_InvalidViewImplementation => ResourceManager.GetString("MetadataViewProvider_InvalidViewImplementation", resourceCulture);

	internal static string MetadataViewProvider_MissingMetadata => ResourceManager.GetString("MetadataViewProvider_MissingMetadata", resourceCulture);

	internal static string NotImplemented_MetadataCycles => ResourceManager.GetString("NotImplemented_MetadataCycles", resourceCulture);

	internal Resources()
	{
	}
}
