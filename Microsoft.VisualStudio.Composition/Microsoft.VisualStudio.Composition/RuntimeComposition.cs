using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class RuntimeComposition : IEquatable<RuntimeComposition>
{
	[DebuggerDisplay("{TypeRef.ResolvedType.FullName,nq}")]
	public class RuntimePart : IEquatable<RuntimePart>
	{
		private ConstructorInfo importingConstructor;

		private MethodInfo onImportsSatisfied;

		public TypeRef TypeRef { get; private set; }

		public ConstructorRef ImportingConstructorRef { get; private set; }

		public IReadOnlyList<RuntimeImport> ImportingConstructorArguments { get; private set; }

		public IReadOnlyList<RuntimeImport> ImportingMembers { get; private set; }

		public IReadOnlyList<RuntimeExport> Exports { get; set; }

		public MethodRef OnImportsSatisfiedRef { get; private set; }

		public string SharingBoundary { get; private set; }

		public bool IsShared => SharingBoundary != null;

		public bool IsInstantiable => !ImportingConstructorRef.IsEmpty;

		public ConstructorInfo ImportingConstructor
		{
			get
			{
				if (importingConstructor == null)
				{
					importingConstructor = ImportingConstructorRef.ConstructorInfo;
				}
				return importingConstructor;
			}
		}

		public MethodInfo OnImportsSatisfied
		{
			get
			{
				if (onImportsSatisfied == null)
				{
					onImportsSatisfied = OnImportsSatisfiedRef.MethodBase as MethodInfo;
				}
				return onImportsSatisfied;
			}
		}

		public RuntimePart(TypeRef type, ConstructorRef importingConstructor, IReadOnlyList<RuntimeImport> importingConstructorArguments, IReadOnlyList<RuntimeImport> importingMembers, IReadOnlyList<RuntimeExport> exports, MethodRef onImportsSatisfied, string sharingBoundary)
		{
			TypeRef = type;
			ImportingConstructorRef = importingConstructor;
			ImportingConstructorArguments = importingConstructorArguments;
			ImportingMembers = importingMembers;
			Exports = exports;
			OnImportsSatisfiedRef = onImportsSatisfied;
			SharingBoundary = sharingBoundary;
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as RuntimePart);
		}

		public override int GetHashCode()
		{
			return TypeRef.GetHashCode();
		}

		public bool Equals(RuntimePart other)
		{
			if (other == null)
			{
				return false;
			}
			if (TypeRef.Equals(other.TypeRef) && ImportingConstructorRef.Equals(other.ImportingConstructorRef) && ImportingConstructorArguments.SequenceEqual(other.ImportingConstructorArguments) && ByValueEquality.EquivalentIgnoreOrder<RuntimeImport>().Equals(ImportingMembers, other.ImportingMembers) && ByValueEquality.EquivalentIgnoreOrder<RuntimeExport>().Equals(Exports, other.Exports) && OnImportsSatisfiedRef.Equals(other.OnImportsSatisfiedRef))
			{
				return SharingBoundary == other.SharingBoundary;
			}
			return false;
		}
	}

	[DebuggerDisplay("{ImportingSiteElementType}")]
	public class RuntimeImport : IEquatable<RuntimeImport>
	{
		private bool? isLazy;

		private Type importingSiteType;

		private Type importingSiteTypeWithoutCollection;

		private Type importingSiteElementType;

		private Func<Func<object>, object, object> lazyFactory;

		private ParameterInfo importingParameter;

		private MemberInfo importingMember;

		private volatile bool isMetadataTypeInitialized;

		private Type metadataType;

		public MemberRef ImportingMemberRef { get; private set; }

		public ParameterRef ImportingParameterRef { get; private set; }

		public TypeRef ImportingSiteTypeRef { get; private set; }

		public ImportCardinality Cardinality { get; private set; }

		public IReadOnlyCollection<RuntimeExport> SatisfyingExports { get; private set; }

		public bool IsExportFactory { get; private set; }

		public bool IsNonSharedInstanceRequired { get; private set; }

		public IReadOnlyDictionary<string, object> Metadata { get; private set; }

		public Type ExportFactory
		{
			get
			{
				if (!IsExportFactory)
				{
					return null;
				}
				return ImportingSiteTypeWithoutCollection;
			}
		}

		public IReadOnlyCollection<string> ExportFactorySharingBoundaries { get; private set; }

		public MemberInfo ImportingMember
		{
			get
			{
				if (importingMember == null)
				{
					importingMember = ImportingMemberRef.MemberInfo;
				}
				return importingMember;
			}
		}

		public ParameterInfo ImportingParameter
		{
			get
			{
				if (importingParameter == null)
				{
					importingParameter = ImportingParameterRef.Resolve();
				}
				return importingParameter;
			}
		}

		public bool IsLazy
		{
			get
			{
				if (!isLazy.HasValue)
				{
					isLazy = ImportingSiteTypeWithoutCollection.IsAnyLazyType();
				}
				return isLazy.Value;
			}
		}

		public Type ImportingSiteType
		{
			get
			{
				if (importingSiteType == null)
				{
					importingSiteType = ImportingSiteTypeRef.Resolve();
				}
				return importingSiteType;
			}
		}

		public Type ImportingSiteTypeWithoutCollection
		{
			get
			{
				if (importingSiteTypeWithoutCollection == null)
				{
					importingSiteTypeWithoutCollection = ((Cardinality == ImportCardinality.ZeroOrMore) ? PartDiscovery.GetElementTypeFromMany(ImportingSiteType) : ImportingSiteType);
				}
				return importingSiteTypeWithoutCollection;
			}
		}

		public Type ImportingSiteElementType
		{
			get
			{
				if (importingSiteElementType == null)
				{
					importingSiteElementType = PartDiscovery.GetTypeIdentityFromImportingType(ImportingSiteType, Cardinality == ImportCardinality.ZeroOrMore);
				}
				return importingSiteElementType;
			}
		}

		public Type MetadataType
		{
			get
			{
				if (!isMetadataTypeInitialized)
				{
					metadataType = ((IsLazy && ImportingSiteTypeWithoutCollection.GenericTypeArguments.Length == 2) ? ImportingSiteTypeWithoutCollection.GenericTypeArguments[1] : null);
					isMetadataTypeInitialized = true;
				}
				return metadataType;
			}
		}

		public TypeRef DeclaringTypeRef
		{
			get
			{
				if (!ImportingParameterRef.IsEmpty)
				{
					return ImportingParameterRef.DeclaringType;
				}
				return ImportingMemberRef.DeclaringType;
			}
		}

		internal Func<Func<object>, object, object> LazyFactory
		{
			get
			{
				if (lazyFactory == null && IsLazy)
				{
					Type[] genericTypeArguments = ImportingSiteTypeWithoutCollection.GenericTypeArguments;
					lazyFactory = LazyServices.CreateStronglyTypedLazyFactory(ImportingSiteElementType, (genericTypeArguments.Length > 1) ? genericTypeArguments[1] : null);
				}
				return lazyFactory;
			}
		}

		private RuntimeImport(TypeRef importingSiteTypeRef, ImportCardinality cardinality, IReadOnlyList<RuntimeExport> satisfyingExports, bool isNonSharedInstanceRequired, bool isExportFactory, IReadOnlyDictionary<string, object> metadata, IReadOnlyCollection<string> exportFactorySharingBoundaries)
		{
			Requires.NotNull(importingSiteTypeRef, "importingSiteTypeRef");
			Requires.NotNull(satisfyingExports, "satisfyingExports");
			Cardinality = cardinality;
			SatisfyingExports = satisfyingExports;
			IsNonSharedInstanceRequired = isNonSharedInstanceRequired;
			IsExportFactory = isExportFactory;
			Metadata = metadata;
			ImportingSiteTypeRef = importingSiteTypeRef;
			ExportFactorySharingBoundaries = exportFactorySharingBoundaries;
		}

		public RuntimeImport(MemberRef importingMemberRef, TypeRef importingSiteTypeRef, ImportCardinality cardinality, IReadOnlyList<RuntimeExport> satisfyingExports, bool isNonSharedInstanceRequired, bool isExportFactory, IReadOnlyDictionary<string, object> metadata, IReadOnlyCollection<string> exportFactorySharingBoundaries)
			: this(importingSiteTypeRef, cardinality, satisfyingExports, isNonSharedInstanceRequired, isExportFactory, metadata, exportFactorySharingBoundaries)
		{
			ImportingMemberRef = importingMemberRef;
		}

		public RuntimeImport(ParameterRef importingParameterRef, TypeRef importingSiteTypeRef, ImportCardinality cardinality, IReadOnlyList<RuntimeExport> satisfyingExports, bool isNonSharedInstanceRequired, bool isExportFactory, IReadOnlyDictionary<string, object> metadata, IReadOnlyCollection<string> exportFactorySharingBoundaries)
			: this(importingSiteTypeRef, cardinality, satisfyingExports, isNonSharedInstanceRequired, isExportFactory, metadata, exportFactorySharingBoundaries)
		{
			ImportingParameterRef = importingParameterRef;
		}

		public override int GetHashCode()
		{
			return ImportingMemberRef.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as RuntimeImport);
		}

		public bool Equals(RuntimeImport other)
		{
			if (other == null)
			{
				return false;
			}
			if (EqualityComparer<TypeRef>.Default.Equals(ImportingSiteTypeRef, other.ImportingSiteTypeRef) && Cardinality == other.Cardinality && ByValueEquality.EquivalentIgnoreOrder<RuntimeExport>().Equals(SatisfyingExports, other.SatisfyingExports) && IsNonSharedInstanceRequired == other.IsNonSharedInstanceRequired && ByValueEquality.Metadata.Equals(Metadata, other.Metadata) && ByValueEquality.EquivalentIgnoreOrder<string>().Equals(ExportFactorySharingBoundaries, other.ExportFactorySharingBoundaries) && ImportingMemberRef.Equals(other.ImportingMemberRef))
			{
				return ImportingParameterRef.Equals(other.ImportingParameterRef);
			}
			return false;
		}
	}

	public class RuntimeExport : IEquatable<RuntimeExport>
	{
		private MemberInfo member;

		public string ContractName { get; private set; }

		public TypeRef DeclaringTypeRef { get; private set; }

		public MemberRef MemberRef { get; private set; }

		public TypeRef ExportedValueTypeRef { get; private set; }

		public IReadOnlyDictionary<string, object> Metadata { get; private set; }

		public MemberInfo Member
		{
			get
			{
				if (member == null)
				{
					member = MemberRef.MemberInfo;
				}
				return member;
			}
		}

		public RuntimeExport(string contractName, TypeRef declaringTypeRef, MemberRef memberRef, TypeRef exportedValueTypeRef, IReadOnlyDictionary<string, object> metadata)
		{
			Requires.NotNull(metadata, "metadata");
			Requires.NotNullOrEmpty(contractName, "contractName");
			ContractName = contractName;
			DeclaringTypeRef = declaringTypeRef;
			MemberRef = memberRef;
			ExportedValueTypeRef = exportedValueTypeRef;
			Metadata = metadata;
		}

		public override int GetHashCode()
		{
			return ContractName.GetHashCode() + DeclaringTypeRef.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			return Equals(obj as RuntimeExport);
		}

		public bool Equals(RuntimeExport other)
		{
			if (other == null)
			{
				return false;
			}
			if (ContractName == other.ContractName && EqualityComparer<TypeRef>.Default.Equals(DeclaringTypeRef, other.DeclaringTypeRef) && EqualityComparer<MemberRef>.Default.Equals(MemberRef, other.MemberRef) && EqualityComparer<TypeRef>.Default.Equals(ExportedValueTypeRef, other.ExportedValueTypeRef))
			{
				return ByValueEquality.Metadata.Equals(Metadata, other.Metadata);
			}
			return false;
		}
	}

	private readonly ImmutableHashSet<RuntimePart> parts;

	private readonly IReadOnlyDictionary<TypeRef, RuntimePart> partsByType;

	private readonly IReadOnlyDictionary<string, IReadOnlyCollection<RuntimeExport>> exportsByContractName;

	private readonly IReadOnlyDictionary<TypeRef, RuntimeExport> metadataViewsAndProviders;

	public IReadOnlyCollection<RuntimePart> Parts => parts;

	public IReadOnlyDictionary<TypeRef, RuntimeExport> MetadataViewsAndProviders => metadataViewsAndProviders;

	internal Resolver Resolver { get; }

	private RuntimeComposition(IEnumerable<RuntimePart> parts, IReadOnlyDictionary<TypeRef, RuntimeExport> metadataViewsAndProviders, Resolver resolver)
	{
		Requires.NotNull(parts, "parts");
		Requires.NotNull(metadataViewsAndProviders, "metadataViewsAndProviders");
		Requires.NotNull(resolver, "resolver");
		this.parts = ImmutableHashSet.CreateRange(parts);
		this.metadataViewsAndProviders = metadataViewsAndProviders;
		Resolver = resolver;
		partsByType = this.parts.ToDictionary((RuntimePart p) => p.TypeRef, this.parts.Count);
		IEnumerable<IGrouping<string, RuntimeExport>> source = from part in this.parts
			from export in part.Exports
			group export by export.ContractName into exportsByContract
			select (exportsByContract);
		exportsByContractName = source.ToDictionary((Func<IGrouping<string, RuntimeExport>, string>)((IGrouping<string, RuntimeExport> e) => e.Key), (Func<IGrouping<string, RuntimeExport>, IReadOnlyCollection<RuntimeExport>>)((IGrouping<string, RuntimeExport> e) => e.ToImmutableArray()));
	}

	public static RuntimeComposition CreateRuntimeComposition(CompositionConfiguration configuration)
	{
		Requires.NotNull(configuration, "configuration");
		IEnumerable<RuntimePart> enumerable = configuration.Parts.Select((ComposedPart part) => CreateRuntimePart(part, configuration));
		ImmutableDictionary<TypeRef, RuntimeExport> immutableDictionary = ImmutableDictionary.CreateRange(from viewAndProvider in configuration.MetadataViewsAndProviders
			let viewTypeRef = TypeRef.Get(viewAndProvider.Key, configuration.Resolver)
			let runtimeExport = CreateRuntimeExport(viewAndProvider.Value, configuration.Resolver)
			select new KeyValuePair<TypeRef, RuntimeExport>(viewTypeRef, runtimeExport));
		return new RuntimeComposition(enumerable, immutableDictionary, configuration.Resolver);
	}

	public static RuntimeComposition CreateRuntimeComposition(IEnumerable<RuntimePart> parts, IReadOnlyDictionary<TypeRef, RuntimeExport> metadataViewsAndProviders, Resolver resolver)
	{
		return new RuntimeComposition(parts, metadataViewsAndProviders, resolver);
	}

	public IExportProviderFactory CreateExportProviderFactory()
	{
		return new RuntimeExportProviderFactory(this);
	}

	public IReadOnlyCollection<RuntimeExport> GetExports(string contractName)
	{
		if (exportsByContractName.TryGetValue(contractName, out var value))
		{
			return value;
		}
		return ImmutableList<RuntimeExport>.Empty;
	}

	public RuntimePart GetPart(RuntimeExport export)
	{
		Requires.NotNull(export, "export");
		return partsByType[export.DeclaringTypeRef];
	}

	public RuntimePart GetPart(TypeRef partType)
	{
		Requires.NotNull(partType, "partType");
		return partsByType[partType];
	}

	public override bool Equals(object obj)
	{
		return Equals(obj as RuntimeComposition);
	}

	public override int GetHashCode()
	{
		int num = parts.Count;
		foreach (RuntimePart part in parts)
		{
			num += part.GetHashCode();
		}
		return num;
	}

	public bool Equals(RuntimeComposition other)
	{
		if (other == null)
		{
			return false;
		}
		if (parts.SetEquals(other.parts))
		{
			return ByValueEquality.Dictionary<TypeRef, RuntimeExport>().Equals(metadataViewsAndProviders, other.metadataViewsAndProviders);
		}
		return false;
	}

	internal static string GetDiagnosticLocation(RuntimeImport import)
	{
		Requires.NotNull(import, "import");
		return string.Format(CultureInfo.CurrentCulture, "{0}.{1}", new object[2]
		{
			import.DeclaringTypeRef.Resolve().FullName,
			(import.ImportingMember == null) ? ("ctor(" + import.ImportingParameter.Name + ")") : import.ImportingMember.Name
		});
	}

	internal static string GetDiagnosticLocation(RuntimeExport export)
	{
		Requires.NotNull(export, "export");
		if (export.Member != null)
		{
			return string.Format(CultureInfo.CurrentCulture, "{0}.{1}", new object[2]
			{
				export.DeclaringTypeRef.Resolve().FullName,
				export.Member.Name
			});
		}
		return export.DeclaringTypeRef.Resolve().FullName;
	}

	private static RuntimePart CreateRuntimePart(ComposedPart part, CompositionConfiguration configuration)
	{
		Requires.NotNull(part, "part");
		Type partDefinitionType = part.Definition.Type;
		ConstructorInfo importingConstructorInfo = part.Definition.ImportingConstructorInfo;
		MethodInfo onImportsSatisfied = part.Definition.OnImportsSatisfied;
		return new RuntimePart(TypeRef.Get(partDefinitionType, part.Resolver), (importingConstructorInfo != null) ? new ConstructorRef(importingConstructorInfo, part.Resolver) : default(ConstructorRef), (from kvp in part.GetImportingConstructorImports()
			select CreateRuntimeImport(kvp.Key, kvp.Value, part.Resolver)).ToImmutableArray(), part.Definition.ImportingMembers.Select((ImportDefinitionBinding idb) => CreateRuntimeImport(idb, part.SatisfyingExports[idb], part.Resolver)).ToImmutableArray(), part.Definition.ExportDefinitions.Select((KeyValuePair<MemberRef, ExportDefinition> ed) => CreateRuntimeExport(ed.Value, partDefinitionType, ed.Key, part.Resolver)).ToImmutableArray(), (onImportsSatisfied != null) ? new MethodRef(onImportsSatisfied, part.Resolver) : default(MethodRef), part.Definition.IsShared ? configuration.GetEffectiveSharingBoundary(part.Definition) : null);
	}

	private static RuntimeImport CreateRuntimeImport(ImportDefinitionBinding importDefinitionBinding, IReadOnlyList<ExportDefinitionBinding> satisfyingExports, Resolver resolver)
	{
		Requires.NotNull(importDefinitionBinding, "importDefinitionBinding");
		Requires.NotNull(satisfyingExports, "satisfyingExports");
		ImmutableArray<RuntimeExport> immutableArray = satisfyingExports.Select((ExportDefinitionBinding export) => CreateRuntimeExport(export, resolver)).ToImmutableArray();
		if (!importDefinitionBinding.ImportingMemberRef.IsEmpty)
		{
			return new RuntimeImport(importDefinitionBinding.ImportingMemberRef, importDefinitionBinding.ImportingSiteTypeRef, importDefinitionBinding.ImportDefinition.Cardinality, immutableArray, PartCreationPolicyConstraint.IsNonSharedInstanceRequired(importDefinitionBinding.ImportDefinition), importDefinitionBinding.IsExportFactory, importDefinitionBinding.ImportDefinition.Metadata, importDefinitionBinding.ImportDefinition.ExportFactorySharingBoundaries);
		}
		return new RuntimeImport(importDefinitionBinding.ImportingParameterRef, importDefinitionBinding.ImportingSiteTypeRef, importDefinitionBinding.ImportDefinition.Cardinality, immutableArray, PartCreationPolicyConstraint.IsNonSharedInstanceRequired(importDefinitionBinding.ImportDefinition), importDefinitionBinding.IsExportFactory, importDefinitionBinding.ImportDefinition.Metadata, importDefinitionBinding.ImportDefinition.ExportFactorySharingBoundaries);
	}

	private static RuntimeExport CreateRuntimeExport(ExportDefinition exportDefinition, Type partType, MemberRef exportingMemberRef, Resolver resolver)
	{
		Requires.NotNull(exportDefinition, "exportDefinition");
		MemberInfo memberInfo = exportingMemberRef.MemberInfo;
		return new RuntimeExport(exportDefinition.ContractName, TypeRef.Get(partType, resolver), exportingMemberRef, TypeRef.Get(ReflectionHelpers.GetExportedValueType(partType, memberInfo), resolver), exportDefinition.Metadata);
	}

	private static RuntimeExport CreateRuntimeExport(ExportDefinitionBinding exportDefinitionBinding, Resolver resolver)
	{
		Requires.NotNull(exportDefinitionBinding, "exportDefinitionBinding");
		Requires.NotNull(resolver, "resolver");
		Type partType = exportDefinitionBinding.PartDefinition.TypeRef.Resolve();
		return CreateRuntimeExport(exportDefinitionBinding.ExportDefinition, partType, exportDefinitionBinding.ExportingMemberRef, resolver);
	}
}
