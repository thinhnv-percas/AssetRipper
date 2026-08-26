using System;
using System.Reflection;
using Microsoft.Internal;

namespace Microsoft.Composition.Diagnostics;

internal static class CompositionTrace
{
	internal static void Registration_ConstructorConventionOverridden(Type type)
	{
		Microsoft.Internal.Assumes.NotNull(type);
		if (CompositionTraceSource.CanWriteInformation)
		{
			CompositionTraceSource.WriteInformation(CompositionTraceId.Registration_ConstructorConventionOverridden, Microsoft.Internal.Strings.Registration_ConstructorConventionOverridden, type.FullName);
		}
	}

	internal static void Registration_TypeExportConventionOverridden(Type type)
	{
		Microsoft.Internal.Assumes.NotNull(type);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_TypeExportConventionOverridden, Microsoft.Internal.Strings.Registration_TypeExportConventionOverridden, type.FullName);
		}
	}

	internal static void Registration_MemberExportConventionOverridden(Type type, MemberInfo member)
	{
		Microsoft.Internal.Assumes.NotNull(type, member);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_MemberExportConventionOverridden, Microsoft.Internal.Strings.Registration_MemberExportConventionOverridden, member.Name, type.FullName);
		}
	}

	internal static void Registration_MemberImportConventionOverridden(Type type, MemberInfo member)
	{
		Microsoft.Internal.Assumes.NotNull(type, member);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_MemberImportConventionOverridden, Microsoft.Internal.Strings.Registration_MemberImportConventionOverridden, member.Name, type.FullName);
		}
	}

	internal static void Registration_OnSatisfiedImportNotificationOverridden(Type type, MemberInfo member)
	{
		Microsoft.Internal.Assumes.NotNull(type, member);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_OnSatisfiedImportNotificationOverridden, Microsoft.Internal.Strings.Registration_OnSatisfiedImportNotificationOverridden, member.Name, type.FullName);
		}
	}

	internal static void Registration_PartCreationConventionOverridden(Type type)
	{
		Microsoft.Internal.Assumes.NotNull(type);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_PartCreationConventionOverridden, Microsoft.Internal.Strings.Registration_PartCreationConventionOverridden, type.FullName);
		}
	}

	internal static void Registration_MemberImportConventionMatchedTwice(Type type, MemberInfo member)
	{
		Microsoft.Internal.Assumes.NotNull(type, member);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_MemberImportConventionMatchedTwice, Microsoft.Internal.Strings.Registration_MemberImportConventionMatchedTwice, member.Name, type.FullName);
		}
	}

	internal static void Registration_PartMetadataConventionOverridden(Type type)
	{
		Microsoft.Internal.Assumes.NotNull(type);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_PartMetadataConventionOverridden, Microsoft.Internal.Strings.Registration_PartMetadataConventionOverridden, type.FullName);
		}
	}

	internal static void Registration_ParameterImportConventionOverridden(ParameterInfo parameter, ConstructorInfo constructor)
	{
		Microsoft.Internal.Assumes.NotNull(parameter, constructor);
		if (CompositionTraceSource.CanWriteWarning)
		{
			CompositionTraceSource.WriteWarning(CompositionTraceId.Registration_ParameterImportConventionOverridden, Microsoft.Internal.Strings.Registration_ParameterImportConventionOverridden, parameter.Name, constructor.Name);
		}
	}
}
