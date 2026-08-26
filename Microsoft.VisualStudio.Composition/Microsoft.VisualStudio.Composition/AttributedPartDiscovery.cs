using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class AttributedPartDiscovery : PartDiscovery
{
	public bool IsNonPublicSupported { get; }

	protected BindingFlags PublicVsNonPublicFlags
	{
		get
		{
			BindingFlags bindingFlags = BindingFlags.Public;
			if (IsNonPublicSupported)
			{
				bindingFlags |= BindingFlags.NonPublic;
			}
			return bindingFlags;
		}
	}

	public AttributedPartDiscovery(Resolver resolver, bool isNonPublicSupported = false)
		: base(resolver)
	{
		IsNonPublicSupported = isNonPublicSupported;
	}

	protected override ComposablePartDefinition CreatePart(Type partType, bool typeExplicitlyRequested)
	{
		Requires.NotNull(partType, "partType");
		TypeInfo partTypeInfo = partType.GetTypeInfo();
		if (!typeExplicitlyRequested)
		{
			bool flag = (partType.IsNested ? partTypeInfo.IsNestedPublic : partTypeInfo.IsPublic);
			if (!IsNonPublicSupported && !flag)
			{
				return null;
			}
		}
		PropertyInfo[] properties = partTypeInfo.GetProperties(BindingFlags.Instance | PublicVsNonPublicFlags);
		IEnumerable<KeyValuePair<MemberInfo, ExportAttribute>> first = from member in properties
			from export in member.GetAttributes<ExportAttribute>()
			select new KeyValuePair<MemberInfo, ExportAttribute>(member, export);
		IEnumerable<KeyValuePair<MemberInfo, ExportAttribute>> second = from export in partTypeInfo.GetAttributes<ExportAttribute>()
			select new KeyValuePair<MemberInfo, ExportAttribute>(partTypeInfo, export);
		KeyValuePair<MemberInfo, ExportAttribute[]>[] array = (from export in first.Concat(second)
			group export.Value by export.Key into exportsByType
			select (exportsByType) into g
			select new KeyValuePair<MemberInfo, ExportAttribute[]>(g.Key, g.ToArray())).ToArray();
		if (array.Length == 0)
		{
			return null;
		}
		if (!typeExplicitlyRequested && partTypeInfo.IsAttributeDefined<PartNotDiscoverableAttribute>())
		{
			return null;
		}
		TypeRef.Get(partType, base.Resolver);
		Type type = (partTypeInfo.IsGenericType ? partType.GetGenericTypeDefinition() : null);
		string text = null;
		SharedAttribute firstAttribute = partTypeInfo.GetFirstAttribute<SharedAttribute>();
		if (firstAttribute != null)
		{
			text = firstAttribute.SharingBoundary ?? string.Empty;
		}
		CreationPolicy partCreationPolicy = ((text != null) ? CreationPolicy.Shared : CreationPolicy.NonShared);
		ImmutableDictionary<string, object> immutableDictionary = ImmutableDictionary.CreateRange(PartCreationPolicyConstraint.GetExportMetadata(partCreationPolicy));
		ImmutableList<ExportDefinition>.Builder builder = ImmutableList.CreateBuilder<ExportDefinition>();
		ImmutableDictionary<MemberRef, IReadOnlyCollection<ExportDefinition>>.Builder builder2 = ImmutableDictionary.CreateBuilder<MemberRef, IReadOnlyCollection<ExportDefinition>>();
		ImmutableList<ImportDefinitionBinding>.Builder builder3 = ImmutableList.CreateBuilder<ImportDefinitionBinding>();
		KeyValuePair<MemberInfo, ExportAttribute[]>[] array2 = array;
		for (int num = 0; num < array2.Length; num++)
		{
			KeyValuePair<MemberInfo, ExportAttribute[]> keyValuePair = array2[num];
			MemberInfo key = keyValuePair.Key;
			ImmutableDictionary<string, object> memberExportMetadata = immutableDictionary.AddRange(GetExportMetadata(key));
			ExportAttribute[] value;
			if (key is TypeInfo)
			{
				value = keyValuePair.Value;
				foreach (ExportAttribute exportAttribute in value)
				{
					Type exportedType = exportAttribute.ContractType ?? type ?? partType;
					ExportDefinition item = CreateExportDefinition(memberExportMetadata, exportAttribute, exportedType);
					builder.Add(item);
				}
				continue;
			}
			PropertyInfo propertyInfo = (PropertyInfo)key;
			Verify.Operation(!partTypeInfo.IsGenericTypeDefinition, Strings.ExportsOnMembersNotAllowedWhenDeclaringTypeGeneric);
			ImmutableList<ExportDefinition>.Builder builder4 = ImmutableList.CreateBuilder<ExportDefinition>();
			value = keyValuePair.Value;
			foreach (ExportAttribute exportAttribute2 in value)
			{
				Type exportedType2 = exportAttribute2.ContractType ?? propertyInfo.PropertyType;
				ExportDefinition item2 = CreateExportDefinition(memberExportMetadata, exportAttribute2, exportedType2);
				builder4.Add(item2);
			}
			builder2.Add(MemberRef.Get(key, base.Resolver), builder4.ToImmutable());
		}
		PropertyInfo[] array3 = properties;
		foreach (PropertyInfo propertyInfo2 in array3)
		{
			ImportAttribute firstAttribute2 = propertyInfo2.GetFirstAttribute<ImportAttribute>();
			ImportManyAttribute firstAttribute3 = propertyInfo2.GetFirstAttribute<ImportManyAttribute>();
			Requires.Argument(firstAttribute2 == null || firstAttribute3 == null, "partType", Strings.MemberContainsBothImportAndImportMany, propertyInfo2.Name);
			ImmutableHashSet<IImportSatisfiabilityConstraint> importConstraints = GetImportConstraints(propertyInfo2);
			if (TryCreateImportDefinition(ReflectionHelpers.GetMemberType(propertyInfo2), propertyInfo2, importConstraints, out var importDefinition))
			{
				builder3.Add(new ImportDefinitionBinding(importDefinition, TypeRef.Get(partType, base.Resolver), MemberRef.Get(propertyInfo2, base.Resolver)));
			}
		}
		MethodInfo methodInfo = null;
		MethodInfo[] methods = partTypeInfo.GetMethods(PublicVsNonPublicFlags | BindingFlags.Instance);
		foreach (MethodInfo methodInfo2 in methods)
		{
			if (methodInfo2.IsAttributeDefined<OnImportsSatisfiedAttribute>())
			{
				Verify.Operation(methodInfo2.GetParameters().Length == 0, Strings.OnImportsSatisfiedTakeNoParameters);
				Verify.Operation(methodInfo == null, Strings.OnlyOneOnImportsSatisfiedMethodIsSupported);
				methodInfo = methodInfo2;
			}
		}
		ImmutableList<ImportDefinitionBinding>.Builder builder5 = ImmutableList.CreateBuilder<ImportDefinitionBinding>();
		ConstructorInfo importingConstructor = PartDiscovery.GetImportingConstructor<ImportingConstructorAttribute>(partType, !IsNonPublicSupported);
		Verify.Operation(importingConstructor != null, Strings.NoImportingConstructorFound);
		ParameterInfo[] parameters = importingConstructor.GetParameters();
		foreach (ParameterInfo parameterInfo in parameters)
		{
			ImportDefinitionBinding importDefinitionBinding = CreateImport(parameterInfo, GetImportConstraints(parameterInfo));
			if (importDefinitionBinding.ImportDefinition.Cardinality == ImportCardinality.ZeroOrMore)
			{
				Verify.Operation(PartDiscovery.IsImportManyCollectionTypeCreateable(importDefinitionBinding), Strings.CollectionMustBePublicAndPublicCtorWhenUsingImportingCtor);
			}
			builder5.Add(importDefinitionBinding);
		}
		ImmutableDictionary<string, object>.Builder builder6 = ImmutableDictionary.CreateBuilder<string, object>();
		PartMetadataAttribute[] attributes = partTypeInfo.GetAttributes<PartMetadataAttribute>();
		foreach (PartMetadataAttribute partMetadataAttribute in attributes)
		{
			builder6[partMetadataAttribute.Name] = partMetadataAttribute.Value;
		}
		ImmutableHashSet<AssemblyName>.Builder builder7 = ImmutableHashSet.CreateBuilder(ByValueEquality.AssemblyName);
		array2 = array;
		foreach (KeyValuePair<MemberInfo, ExportAttribute[]> keyValuePair2 in array2)
		{
			PartDiscovery.GetAssemblyNamesFromMetadataAttributes<MetadataAttributeAttribute>(keyValuePair2.Key, builder7);
		}
		return new ComposablePartDefinition(TypeRef.Get(partType, base.Resolver), builder6.ToImmutable(), builder.ToImmutable(), builder2.ToImmutable(), builder3.ToImmutable(), text, MethodRef.Get(methodInfo, base.Resolver), ConstructorRef.Get(importingConstructor, base.Resolver), builder5.ToImmutable(), partCreationPolicy, builder7);
	}

	public override bool IsExportFactoryType(Type type)
	{
		if (type != null && type.GetTypeInfo().IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (genericTypeDefinition.Equals(typeof(ExportFactory<>)) || genericTypeDefinition.Equals(typeof(ExportFactory<, >)))
			{
				return true;
			}
		}
		return false;
	}

	protected override IEnumerable<Type> GetTypes(Assembly assembly)
	{
		Requires.NotNull(assembly, "assembly");
		if (!IsNonPublicSupported)
		{
			return assembly.GetExportedTypes();
		}
		return assembly.GetTypes();
	}

	private ImmutableDictionary<string, object> GetExportMetadata(ICustomAttributeProvider member)
	{
		Requires.NotNull(member, "member");
		ImmutableDictionary<string, object>.Builder builder = ImmutableDictionary.CreateBuilder<string, object>();
		HashSet<string> namesOfMetadataWithMultipleValues = new HashSet<string>(StringComparer.Ordinal);
		Attribute[] attributes = member.GetAttributes<Attribute>();
		foreach (Attribute attribute in attributes)
		{
			TypeInfo typeInfo = attribute.GetType().GetTypeInfo();
			if (attribute is ExportMetadataAttribute exportMetadataAttribute)
			{
				UpdateMetadataDictionary(builder, namesOfMetadataWithMultipleValues, exportMetadataAttribute.Name, exportMetadataAttribute.Value, null);
			}
			else
			{
				if (!(typeInfo != typeof(ExportAttribute).GetTypeInfo()) || !typeInfo.IsAttributeDefined<MetadataAttributeAttribute>())
				{
					continue;
				}
				foreach (PropertyInfo item in from p in typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
					where p.DeclaringType != typeof(Attribute)
					select p)
				{
					UpdateMetadataDictionary(builder, namesOfMetadataWithMultipleValues, item.Name, item.GetValue(attribute), ReflectionHelpers.GetMemberType(item));
				}
			}
		}
		return builder.ToImmutable();
	}

	private static void UpdateMetadataDictionary(IDictionary<string, object> result, HashSet<string> namesOfMetadataWithMultipleValues, string name, object value, Type elementType)
	{
		if (result.TryGetValue(name, out var value2))
		{
			if (namesOfMetadataWithMultipleValues.Add(name))
			{
				value2 = PartDiscovery.AddElement(null, value2, elementType);
			}
			result[name] = PartDiscovery.AddElement((Array)value2, value, elementType);
		}
		else
		{
			result.Add(name, value);
		}
	}

	private bool TryCreateImportDefinition(Type importingType, ICustomAttributeProvider member, ImmutableHashSet<IImportSatisfiabilityConstraint> importConstraints, out ImportDefinition importDefinition)
	{
		Requires.NotNull(importingType, "importingType");
		Requires.NotNull(member, "member");
		ImportAttribute importAttribute = member.GetFirstAttribute<ImportAttribute>();
		ImportManyAttribute firstAttribute = member.GetFirstAttribute<ImportManyAttribute>();
		if (importAttribute == null && firstAttribute == null && member is ParameterInfo)
		{
			importAttribute = new ImportAttribute();
		}
		ImmutableHashSet<string> immutableHashSet = ImmutableHashSet.Create<string>();
		SharingBoundaryAttribute firstAttribute2 = member.GetFirstAttribute<SharingBoundaryAttribute>();
		if (firstAttribute2 != null)
		{
			Verify.Operation(importingType.IsExportFactoryTypeV2(), Strings.IsExpectedOnlyOnImportsOfExportFactoryOfT, typeof(SharingBoundaryAttribute).Name);
			immutableHashSet = immutableHashSet.Union(firstAttribute2.SharingBoundaryNames);
		}
		if (importAttribute != null)
		{
			Type type = PartDiscovery.GetTypeIdentityFromImportingType(importingType, importMany: false);
			if (type.IsAnyLazyType() || type.IsExportFactoryTypeV2())
			{
				type = type.GetTypeInfo().GetGenericArguments()[0];
			}
			importConstraints = importConstraints.Union(GetMetadataViewConstraints(importingType, importMany: false)).Union(PartDiscovery.GetExportTypeIdentityConstraints(type));
			importDefinition = new ImportDefinition(string.IsNullOrEmpty(importAttribute.ContractName) ? PartDiscovery.GetContractName(type) : importAttribute.ContractName, importAttribute.AllowDefault ? ImportCardinality.OneOrZero : ImportCardinality.ExactlyOne, PartDiscovery.GetImportMetadataForGenericTypeImport(type), importConstraints, immutableHashSet);
			return true;
		}
		if (firstAttribute != null)
		{
			Type typeIdentityFromImportingType = PartDiscovery.GetTypeIdentityFromImportingType(importingType, importMany: true);
			importConstraints = importConstraints.Union(GetMetadataViewConstraints(importingType, importMany: true)).Union(PartDiscovery.GetExportTypeIdentityConstraints(typeIdentityFromImportingType));
			importDefinition = new ImportDefinition(string.IsNullOrEmpty(firstAttribute.ContractName) ? PartDiscovery.GetContractName(typeIdentityFromImportingType) : firstAttribute.ContractName, ImportCardinality.ZeroOrMore, PartDiscovery.GetImportMetadataForGenericTypeImport(typeIdentityFromImportingType), importConstraints, immutableHashSet);
			return true;
		}
		importDefinition = null;
		return false;
	}

	private ImportDefinitionBinding CreateImport(ParameterInfo parameter, ImmutableHashSet<IImportSatisfiabilityConstraint> importConstraints)
	{
		Assumes.True(TryCreateImportDefinition(parameter.ParameterType, parameter, importConstraints, out var importDefinition));
		return new ImportDefinitionBinding(importDefinition, TypeRef.Get(parameter.Member.DeclaringType, base.Resolver), ParameterRef.Get(parameter, base.Resolver));
	}

	private static ImmutableHashSet<IImportSatisfiabilityConstraint> GetImportConstraints(ICustomAttributeProvider importSite)
	{
		Requires.NotNull(importSite, "importSite");
		return ImmutableHashSet.CreateRange((IEnumerable<IImportSatisfiabilityConstraint>)(from importConstraint in importSite.GetAttributes<ImportMetadataConstraintAttribute>()
			select new ExportMetadataValueImportConstraint(importConstraint.Name, importConstraint.Value)));
	}

	private static ExportDefinition CreateExportDefinition(ImmutableDictionary<string, object> memberExportMetadata, ExportAttribute exportAttribute, Type exportedType)
	{
		string contractName = (string.IsNullOrEmpty(exportAttribute.ContractName) ? PartDiscovery.GetContractName(exportedType) : exportAttribute.ContractName);
		ImmutableDictionary<string, object> metadata = memberExportMetadata.Add("ExportTypeIdentity", ContractNameServices.GetTypeIdentity(exportedType));
		return new ExportDefinition(contractName, metadata);
	}
}
