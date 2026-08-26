namespace Microsoft.Composition.Diagnostics;

internal enum CompositionTraceId : ushort
{
	Registration_ConstructorConventionOverridden = 101,
	Registration_TypeExportConventionOverridden,
	Registration_MemberExportConventionOverridden,
	Registration_MemberImportConventionOverridden,
	Registration_PartCreationConventionOverridden,
	Registration_MemberImportConventionMatchedTwice,
	Registration_PartMetadataConventionOverridden,
	Registration_ParameterImportConventionOverridden,
	Registration_OnSatisfiedImportNotificationOverridden
}
