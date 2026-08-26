using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.Internal;

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
				ResourceManager resourceManager = new ResourceManager("System.Composition.Convention.Strings", typeof(Microsoft.Internal.Strings).GetTypeInfo().Assembly);
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

	internal static string Argument_ExpressionMustBeNew => ResourceManager.GetString("Argument_ExpressionMustBeNew", resourceCulture);

	internal static string Argument_ExpressionMustBePropertyMember => ResourceManager.GetString("Argument_ExpressionMustBePropertyMember", resourceCulture);

	internal static string Argument_ExpressionMustBeVoidMethodWithNoArguments => ResourceManager.GetString("Argument_ExpressionMustBeVoidMethodWithNoArguments", resourceCulture);

	internal static string ArgumentException_EmptyString => ResourceManager.GetString("ArgumentException_EmptyString", resourceCulture);

	internal static string ArgumentOutOfRange_InvalidEnumInSet => ResourceManager.GetString("ArgumentOutOfRange_InvalidEnumInSet", resourceCulture);

	internal static string InternalExceptionMessage => ResourceManager.GetString("InternalExceptionMessage", resourceCulture);

	internal static string Registration_ConstructorConventionOverridden => ResourceManager.GetString("Registration_ConstructorConventionOverridden", resourceCulture);

	internal static string Registration_MemberExportConventionOverridden => ResourceManager.GetString("Registration_MemberExportConventionOverridden", resourceCulture);

	internal static string Registration_MemberImportConventionMatchedTwice => ResourceManager.GetString("Registration_MemberImportConventionMatchedTwice", resourceCulture);

	internal static string Registration_MemberImportConventionOverridden => ResourceManager.GetString("Registration_MemberImportConventionOverridden", resourceCulture);

	internal static string Registration_OnSatisfiedImportNotificationOverridden => ResourceManager.GetString("Registration_OnSatisfiedImportNotificationOverridden", resourceCulture);

	internal static string Registration_ParameterImportConventionOverridden => ResourceManager.GetString("Registration_ParameterImportConventionOverridden", resourceCulture);

	internal static string Registration_PartCreationConventionOverridden => ResourceManager.GetString("Registration_PartCreationConventionOverridden", resourceCulture);

	internal static string Registration_PartMetadataConventionOverridden => ResourceManager.GetString("Registration_PartMetadataConventionOverridden", resourceCulture);

	internal static string Registration_TypeExportConventionOverridden => ResourceManager.GetString("Registration_TypeExportConventionOverridden", resourceCulture);

	internal Strings()
	{
	}
}
