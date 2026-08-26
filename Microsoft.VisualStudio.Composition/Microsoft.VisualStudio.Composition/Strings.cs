using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Microsoft.VisualStudio.Composition;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
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
				resourceMan = new ResourceManager("Microsoft.VisualStudio.Composition.Strings", typeof(Strings).GetTypeInfo().Assembly);
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

	internal static string AllValuesMustBeNonNull => ResourceManager.GetString("AllValuesMustBeNonNull", resourceCulture);

	internal static string AssemblyNameMustBeSetFirst => ResourceManager.GetString("AssemblyNameMustBeSetFirst", resourceCulture);

	internal static string CannotBeEmpty => ResourceManager.GetString("CannotBeEmpty", resourceCulture);

	internal static string CannotDirectlyDisposeAnImport => ResourceManager.GetString("CannotDirectlyDisposeAnImport", resourceCulture);

	internal static string CannotImportBecauseExportingPartCannotBeInstantiated => ResourceManager.GetString("CannotImportBecauseExportingPartCannotBeInstantiated", resourceCulture);

	internal static string CollectionMustBePublicAndPublicCtorWhenUsingImportingCtor => ResourceManager.GetString("CollectionMustBePublicAndPublicCtorWhenUsingImportingCtor", resourceCulture);

	internal static string CollectionTypeMustDeriveFromICollectionOfT => ResourceManager.GetString("CollectionTypeMustDeriveFromICollectionOfT", resourceCulture);

	internal static string CompilerErrorsOccurred => ResourceManager.GetString("CompilerErrorsOccurred", resourceCulture);

	internal static string ContainerDisposalEncounteredExceptions => ResourceManager.GetString("ContainerDisposalEncounteredExceptions", resourceCulture);

	internal static string CustomImportSourceNotSupported => ResourceManager.GetString("CustomImportSourceNotSupported", resourceCulture);

	internal static string DiscoveredIdenticalPropertiesInMetadataAttributesForPart => ResourceManager.GetString("DiscoveredIdenticalPropertiesInMetadataAttributesForPart", resourceCulture);

	internal static string ErrorsDuringDiscovery => ResourceManager.GetString("ErrorsDuringDiscovery", resourceCulture);

	internal static string ErrorsInComposition => ResourceManager.GetString("ErrorsInComposition", resourceCulture);

	internal static string ErrorWhileSettingImport => ResourceManager.GetString("ErrorWhileSettingImport", resourceCulture);

	internal static string ExactlyOneEntryForEveryImport => ResourceManager.GetString("ExactlyOneEntryForEveryImport", resourceCulture);

	internal static string ExceptionThrownByPartUnderInitialization => ResourceManager.GetString("ExceptionThrownByPartUnderInitialization", resourceCulture);

	internal static string ExpectedExactlyOneExportButFound => ResourceManager.GetString("ExpectedExactlyOneExportButFound", resourceCulture);

	internal static string ExpectedOneOrZeroExportsButFound => ResourceManager.GetString("ExpectedOneOrZeroExportsButFound", resourceCulture);

	internal static string ExportedValueNotAssignableToImport => ResourceManager.GetString("ExportedValueNotAssignableToImport", resourceCulture);

	internal static string ExportOfExportProviderNotAllowed => ResourceManager.GetString("ExportOfExportProviderNotAllowed", resourceCulture);

	internal static string ExportsOnMembersNotAllowedWhenDeclaringTypeGeneric => ResourceManager.GetString("ExportsOnMembersNotAllowedWhenDeclaringTypeGeneric", resourceCulture);

	internal static string FailedToGenerateEmbeddableTypes => ResourceManager.GetString("FailedToGenerateEmbeddableTypes", resourceCulture);

	internal static string FailStableComposition => ResourceManager.GetString("FailStableComposition", resourceCulture);

	internal static string FailureWhileScanningType => ResourceManager.GetString("FailureWhileScanningType", resourceCulture);

	internal static string ImportConstraintTypeNotSupported => ResourceManager.GetString("ImportConstraintTypeNotSupported", resourceCulture);

	internal static string ImportingCtorHasUnsupportedParameterTypeForImportMany => ResourceManager.GetString("ImportingCtorHasUnsupportedParameterTypeForImportMany", resourceCulture);

	internal static string ImportsThatUseGenericTypeParametersNotSupported => ResourceManager.GetString("ImportsThatUseGenericTypeParametersNotSupported", resourceCulture);

	internal static string InstanceEmpty => ResourceManager.GetString("InstanceEmpty", resourceCulture);

	internal static string IsExpectedOnlyOnImportsOfExportFactoryOfT => ResourceManager.GetString("IsExpectedOnlyOnImportsOfExportFactoryOfT", resourceCulture);

	internal static string IsExportFactoryExpectedTrue => ResourceManager.GetString("IsExportFactoryExpectedTrue", resourceCulture);

	internal static string IsNotAssignableFromExportedMEFValue => ResourceManager.GetString("IsNotAssignableFromExportedMEFValue", resourceCulture);

	internal static string LoopBetweenNonSharedParts => ResourceManager.GetString("LoopBetweenNonSharedParts", resourceCulture);

	internal static string LoopInvolvingImportingCtorArgumentAndAllNonLazyImports => ResourceManager.GetString("LoopInvolvingImportingCtorArgumentAndAllNonLazyImports", resourceCulture);

	internal static string MemberContainsBothImportAndImportMany => ResourceManager.GetString("MemberContainsBothImportAndImportMany", resourceCulture);

	internal static string MetadataTypeNotSupported => ResourceManager.GetString("MetadataTypeNotSupported", resourceCulture);

	internal static string NoImportingConstructor => ResourceManager.GetString("NoImportingConstructor", resourceCulture);

	internal static string NoImportingConstructorFound => ResourceManager.GetString("NoImportingConstructorFound", resourceCulture);

	internal static string NoMemberToSatisfy => ResourceManager.GetString("NoMemberToSatisfy", resourceCulture);

	internal static string NotATypeSpec => ResourceManager.GetString("NotATypeSpec", resourceCulture);

	internal static string NotClosedFormOfOther => ResourceManager.GetString("NotClosedFormOfOther", resourceCulture);

	internal static string NotGenericTypeDefinition => ResourceManager.GetString("NotGenericTypeDefinition", resourceCulture);

	internal static string NotInitialized => ResourceManager.GetString("NotInitialized", resourceCulture);

	internal static string OnImportsSatisfiedTakeNoParameters => ResourceManager.GetString("OnImportsSatisfiedTakeNoParameters", resourceCulture);

	internal static string OnlyOneOnImportsSatisfiedMethodIsSupported => ResourceManager.GetString("OnlyOneOnImportsSatisfiedMethodIsSupported", resourceCulture);

	internal static string OnlySupportedOnWriteOperations => ResourceManager.GetString("OnlySupportedOnWriteOperations", resourceCulture);

	internal static string PartBelongsToAnotherSharingBoundary => ResourceManager.GetString("PartBelongsToAnotherSharingBoundary", resourceCulture);

	internal static string PartIsNotInstantiable => ResourceManager.GetString("PartIsNotInstantiable", resourceCulture);

	internal static string PartIsNotShared => ResourceManager.GetString("PartIsNotShared", resourceCulture);

	internal static string ReadableStreamRequired => ResourceManager.GetString("ReadableStreamRequired", resourceCulture);

	internal static string RecursiveRequestForPartConstruction => ResourceManager.GetString("RecursiveRequestForPartConstruction", resourceCulture);

	internal static string ReflectionTypeLoadExceptionWhileEnumeratingTypes => ResourceManager.GetString("ReflectionTypeLoadExceptionWhileEnumeratingTypes", resourceCulture);

	internal static string ScanningMEFAssemblies => ResourceManager.GetString("ScanningMEFAssemblies", resourceCulture);

	internal static string TypeMustDefineMemberInfoOrDerivedType => ResourceManager.GetString("TypeMustDefineMemberInfoOrDerivedType", resourceCulture);

	internal static string TypeOfMetadataViewUnsupported => ResourceManager.GetString("TypeOfMetadataViewUnsupported", resourceCulture);

	internal static string UnableToDeterminePrimarySharingBoundary => ResourceManager.GetString("UnableToDeterminePrimarySharingBoundary", resourceCulture);

	internal static string UnableToEnumerateTypes => ResourceManager.GetString("UnableToEnumerateTypes", resourceCulture);

	internal static string UnableToInstantiateCustomImportCollectionType => ResourceManager.GetString("UnableToInstantiateCustomImportCollectionType", resourceCulture);

	internal static string UnableToLoadAssembly => ResourceManager.GetString("UnableToLoadAssembly", resourceCulture);

	internal static string UnexpectedConstraintType => ResourceManager.GetString("UnexpectedConstraintType", resourceCulture);

	internal static string UnexpectedMemberType => ResourceManager.GetString("UnexpectedMemberType", resourceCulture);

	internal static string UnexpectedNumberOfExportsFound => ResourceManager.GetString("UnexpectedNumberOfExportsFound", resourceCulture);

	internal static string UnexpectedSharedPartState => ResourceManager.GetString("UnexpectedSharedPartState", resourceCulture);

	internal static string UnresolvableMetadataToken => ResourceManager.GetString("UnresolvableMetadataToken", resourceCulture);

	internal static string UnsupportedFormat => ResourceManager.GetString("UnsupportedFormat", resourceCulture);

	internal static string WritableStreamRequired => ResourceManager.GetString("WritableStreamRequired", resourceCulture);

	internal static string WrongLength => ResourceManager.GetString("WrongLength", resourceCulture);

	internal static string WrongType => ResourceManager.GetString("WrongType", resourceCulture);

	internal Strings()
	{
	}
}
