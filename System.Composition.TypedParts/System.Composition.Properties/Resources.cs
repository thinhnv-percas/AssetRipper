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
				ResourceManager resourceManager = new ResourceManager("System.Composition.Properties.Resources", typeof(System.Composition.Properties.Resources).GetTypeInfo().Assembly);
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

	internal static string CompositionContextExtensions_MissingDependency => ResourceManager.GetString("CompositionContextExtensions_MissingDependency", resourceCulture);

	internal static string ContainerConfiguration_DefaultConventionSet => ResourceManager.GetString("ContainerConfiguration_DefaultConventionSet", resourceCulture);

	internal static string ContractHelpers_TooManyImports => ResourceManager.GetString("ContractHelpers_TooManyImports", resourceCulture);

	internal static string DiscoveredPart_MultipleImportingConstructorsFound => ResourceManager.GetString("DiscoveredPart_MultipleImportingConstructorsFound", resourceCulture);

	internal static string DiscoveredPart_NoImportingConstructorsFound => ResourceManager.GetString("DiscoveredPart_NoImportingConstructorsFound", resourceCulture);

	internal static string OnImportsSatisfiedFeature_AttributeError => ResourceManager.GetString("OnImportsSatisfiedFeature_AttributeError", resourceCulture);

	internal static string TypeInspector_ArgumentMissmatch => ResourceManager.GetString("TypeInspector_ArgumentMissmatch", resourceCulture);

	internal static string TypeInspector_ContractNotAssignable => ResourceManager.GetString("TypeInspector_ContractNotAssignable", resourceCulture);

	internal static string TypeInspector_ExportedContractTypeNotAssignable => ResourceManager.GetString("TypeInspector_ExportedContractTypeNotAssignable", resourceCulture);

	internal static string TypeInspector_ExportNotCompatible => ResourceManager.GetString("TypeInspector_ExportNotCompatible", resourceCulture);

	internal static string TypeInspector_NoExportNonGenericContract => ResourceManager.GetString("TypeInspector_NoExportNonGenericContract", resourceCulture);

	internal Resources()
	{
	}
}
