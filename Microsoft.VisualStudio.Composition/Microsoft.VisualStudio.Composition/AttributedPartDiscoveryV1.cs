using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class AttributedPartDiscoveryV1 : PartDiscovery
{
	private static readonly MethodInfo OnImportsSatisfiedMethodInfo = typeof(IPartImportsSatisfiedNotification).GetMethod("OnImportsSatisfied", BindingFlags.Instance | BindingFlags.Public);

	public AttributedPartDiscoveryV1(Resolver resolver)
		: base(resolver)
	{
	}

	protected override ComposablePartDefinition CreatePart(Type partType, bool typeExplicitlyRequested)
	{
		Requires.NotNull(partType, "partType");
		if (partType.IsAbstract && !partType.IsSealed)
		{
			return null;
		}
		BindingFlags bindingFlags = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
		BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
		BindingFlags bindingFlags2 = bindingFlags;
		if (partType.IsAbstract)
		{
			bindingFlags2 &= ~BindingFlags.Instance;
		}
		MethodInfo[] methods = partType.GetMethods(bindingFlags2);
		PropertyInfo[] properties = partType.GetProperties(bindingFlags);
		FieldInfo[] fields = partType.GetFields(bindingFlags);
		IEnumerable<KeyValuePair<MemberInfo, ExportAttribute>> first = from member in ((IEnumerable<MemberInfo>)methods).Concat((IEnumerable<MemberInfo>)properties).Concat(fields)
			from export in member.GetAttributes<ExportAttribute>()
			select new KeyValuePair<MemberInfo, ExportAttribute>(member, export);
		IEnumerable<KeyValuePair<MemberInfo, ExportAttribute>> second = from export in partType.GetAttributes<ExportAttribute>()
			select new KeyValuePair<MemberInfo, ExportAttribute>(partType, export);
		KeyValuePair<MemberInfo, ExportAttribute[]>[] array = (from export in Enumerable.Concat(second: from baseTypeOrInterface in partType.GetInterfaces().Concat(partType.EnumTypeAndBaseTypes().Skip(1))
				where baseTypeOrInterface != typeof(object)
				from export in baseTypeOrInterface.GetAttributes<InheritedExportAttribute>()
				select new KeyValuePair<MemberInfo, ExportAttribute>(baseTypeOrInterface, export), first: first.Concat(second))
			group export.Value by export.Key into exportsByType
			select (exportsByType) into g
			select new KeyValuePair<MemberInfo, ExportAttribute[]>(g.Key, g.ToArray())).ToArray();
		if (array.Length == 0)
		{
			return null;
		}
		if (!typeExplicitlyRequested && partType.IsAttributeDefined<PartNotDiscoverableAttribute>())
		{
			return null;
		}
		TypeRef partTypeRef = TypeRef.Get(partType, base.Resolver);
		Type type = (partType.IsGenericType ? partType.GetGenericTypeDefinition() : null);
		ImmutableList<ImportDefinitionBinding>.Builder builder = ImmutableList.CreateBuilder<ImportDefinitionBinding>();
		AddImportsFromMembers(properties, fields, partTypeRef, builder);
		Type baseType = partType.BaseType;
		while (baseType != null && baseType != typeof(object))
		{
			AddImportsFromMembers(baseType.GetProperties(bindingAttr), baseType.GetFields(bindingAttr), partTypeRef, builder);
			baseType = baseType.BaseType;
		}
		CreationPolicy creationPolicy = CreationPolicy.Any;
		PartCreationPolicyAttribute firstAttribute = partType.GetFirstAttribute<PartCreationPolicyAttribute>();
		if (firstAttribute != null)
		{
			creationPolicy = (CreationPolicy)firstAttribute.CreationPolicy;
		}
		ImmutableDictionary<string, object> immutableDictionary = ImmutableDictionary.CreateRange(PartCreationPolicyConstraint.GetExportMetadata(creationPolicy));
		ImmutableHashSet<string>.Builder builder2 = ImmutableHashSet.CreateBuilder<string>();
		ImmutableList<KeyValuePair<MemberInfo, ExportDefinition>>.Builder builder3 = ImmutableList.CreateBuilder<KeyValuePair<MemberInfo, ExportDefinition>>();
		KeyValuePair<MemberInfo, ExportAttribute[]>[] array2 = array;
		for (int num = 0; num < array2.Length; num++)
		{
			KeyValuePair<MemberInfo, ExportAttribute[]> keyValuePair = array2[num];
			ImmutableDictionary<string, object> immutableDictionary2 = immutableDictionary.AddRange(GetExportMetadata(keyValuePair.Key));
			ExportAttribute[] array3;
			if (keyValuePair.Key is MethodInfo)
			{
				MethodInfo method = keyValuePair.Key as MethodInfo;
				ExportAttribute[] value = keyValuePair.Value;
				if (value.Any())
				{
					array3 = value;
					foreach (ExportAttribute exportAttribute in array3)
					{
						Type type2 = exportAttribute.ContractType ?? ReflectionHelpers.GetContractTypeForDelegate(method);
						string contractName = (string.IsNullOrEmpty(exportAttribute.ContractName) ? PartDiscovery.GetContractName(type2) : exportAttribute.ContractName);
						ImmutableDictionary<string, object> metadata = immutableDictionary2.Add("ExportTypeIdentity", ContractNameServices.GetTypeIdentity(type2));
						ExportDefinition value2 = new ExportDefinition(contractName, metadata);
						builder3.Add(new KeyValuePair<MemberInfo, ExportDefinition>(keyValuePair.Key, value2));
					}
				}
				continue;
			}
			MemberInfo key = keyValuePair.Key;
			Verify.Operation(keyValuePair.Key is Type || !partType.IsGenericTypeDefinition, Strings.ExportsOnMembersNotAllowedWhenDeclaringTypeGeneric);
			Type memberType = ReflectionHelpers.GetMemberType(key);
			array3 = keyValuePair.Value;
			foreach (ExportAttribute exportAttribute2 in array3)
			{
				Type type3 = exportAttribute2.ContractType ?? type ?? memberType;
				string text = (string.IsNullOrEmpty(exportAttribute2.ContractName) ? PartDiscovery.GetContractName(type3) : exportAttribute2.ContractName);
				if (keyValuePair.Key is Type && exportAttribute2 is InheritedExportAttribute)
				{
					if (builder2.Contains(text))
					{
						continue;
					}
					if (!((Type)keyValuePair.Key).IsInterface)
					{
						builder2.Add(text);
					}
				}
				ImmutableDictionary<string, object> metadata2 = immutableDictionary2.Add("ExportTypeIdentity", ContractNameServices.GetTypeIdentity(type3));
				ExportDefinition value3 = new ExportDefinition(text, metadata2);
				builder3.Add(new KeyValuePair<MemberInfo, ExportDefinition>(keyValuePair.Key, value3));
			}
		}
		MethodInfo method2 = null;
		if (typeof(IPartImportsSatisfiedNotification).IsAssignableFrom(partType))
		{
			method2 = OnImportsSatisfiedMethodInfo;
		}
		ImmutableList<ImportDefinitionBinding>.Builder builder4 = ImmutableList.CreateBuilder<ImportDefinitionBinding>();
		ConstructorInfo importingConstructor = PartDiscovery.GetImportingConstructor<ImportingConstructorAttribute>(partType, publicOnly: false);
		if (importingConstructor != null)
		{
			ParameterInfo[] parameters = importingConstructor.GetParameters();
			foreach (ParameterInfo parameter in parameters)
			{
				ImportDefinitionBinding importDefinitionBinding = CreateImport(parameter);
				if (importDefinitionBinding.ImportDefinition.Cardinality == ImportCardinality.ZeroOrMore)
				{
					Verify.Operation(PartDiscovery.IsImportManyCollectionTypeCreateable(importDefinitionBinding), Strings.CollectionMustBePublicAndPublicCtorWhenUsingImportingCtor);
				}
				builder4.Add(importDefinitionBinding);
			}
		}
		ImmutableDictionary<string, object>.Builder builder5 = ImmutableDictionary.CreateBuilder<string, object>();
		PartMetadataAttribute[] attributes = partType.GetAttributes<PartMetadataAttribute>();
		foreach (PartMetadataAttribute partMetadataAttribute in attributes)
		{
			builder5[partMetadataAttribute.Name] = partMetadataAttribute.Value;
		}
		ExportDefinition[] exportedTypes = (from kv in builder3
			where kv.Key is Type
			select kv.Value).ToArray();
		Dictionary<MemberRef, IReadOnlyCollection<ExportDefinition>> exportingMembers = (from kv in builder3
			where !(kv.Key is Type)
			group kv.Value by kv.Key into byMember
			select (byMember)).ToDictionary((Func<IGrouping<MemberInfo, ExportDefinition>, MemberRef>)((IGrouping<MemberInfo, ExportDefinition> g) => MemberRef.Get(g.Key, base.Resolver)), (Func<IGrouping<MemberInfo, ExportDefinition>, IReadOnlyCollection<ExportDefinition>>)((IGrouping<MemberInfo, ExportDefinition> g) => g.ToArray()));
		ImmutableHashSet<AssemblyName>.Builder builder6 = ImmutableHashSet.CreateBuilder(ByValueEquality.AssemblyName);
		array2 = array;
		foreach (KeyValuePair<MemberInfo, ExportAttribute[]> keyValuePair2 in array2)
		{
			PartDiscovery.GetAssemblyNamesFromMetadataAttributes<MetadataAttributeAttribute>(keyValuePair2.Key, builder6);
		}
		return new ComposablePartDefinition(TypeRef.Get(partType, base.Resolver), builder5.ToImmutable(), exportedTypes, exportingMembers, builder.ToImmutable(), (creationPolicy != CreationPolicy.NonShared) ? string.Empty : null, MethodRef.Get(method2, base.Resolver), ConstructorRef.Get(importingConstructor, base.Resolver), (importingConstructor != null) ? builder4.ToImmutable() : null, creationPolicy, builder6, creationPolicy != CreationPolicy.NonShared);
	}

	private void AddImportsFromMembers(PropertyInfo[] declaredProperties, FieldInfo[] declaredFields, TypeRef partTypeRef, IList<ImportDefinitionBinding> imports)
	{
		Requires.NotNull(declaredProperties, "declaredProperties");
		Requires.NotNull(declaredFields, "declaredFields");
		Requires.NotNull(partTypeRef, "partTypeRef");
		Requires.NotNull(imports, "imports");
		foreach (MemberInfo item in ((IEnumerable<MemberInfo>)declaredFields).Concat((IEnumerable<MemberInfo>)declaredProperties))
		{
			if (!item.IsStatic() && TryCreateImportDefinition(ReflectionHelpers.GetMemberType(item), item, out var importDefinition))
			{
				imports.Add(new ImportDefinitionBinding(importDefinition, partTypeRef, MemberRef.Get(item, base.Resolver)));
			}
		}
	}

	public override bool IsExportFactoryType(Type type)
	{
		if (type != null && type.GetTypeInfo().IsGenericType)
		{
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			if (genericTypeDefinition.Equals(typeof(ExportFactory<>)) || genericTypeDefinition.IsEquivalentTo(typeof(ExportFactory<, >)))
			{
				return true;
			}
		}
		return false;
	}

	protected override IEnumerable<Type> GetTypes(Assembly assembly)
	{
		Requires.NotNull(assembly, "assembly");
		return assembly.GetTypes();
	}

	private bool TryCreateImportDefinition(Type importingType, ICustomAttributeProvider member, out ImportDefinition importDefinition)
	{
		Requires.NotNull(importingType, "importingType");
		Requires.NotNull(member, "member");
		ImportAttribute importAttribute = member.GetFirstAttribute<ImportAttribute>();
		ImportManyAttribute firstAttribute = member.GetFirstAttribute<ImportManyAttribute>();
		if (importAttribute == null && firstAttribute == null && member is ParameterInfo)
		{
			importAttribute = new ImportAttribute();
		}
		if (importAttribute != null)
		{
			if (importAttribute.Source != ImportSource.Any)
			{
				throw new NotSupportedException(Strings.CustomImportSourceNotSupported);
			}
			System.ComponentModel.Composition.CreationPolicy requiredCreationPolicy = (importingType.IsExportFactoryTypeV1() ? System.ComponentModel.Composition.CreationPolicy.NonShared : importAttribute.RequiredCreationPolicy);
			Type type = importAttribute.ContractType ?? PartDiscovery.GetTypeIdentityFromImportingType(importingType, importMany: false);
			ImmutableHashSet<IImportSatisfiabilityConstraint> additionalConstraints = PartCreationPolicyConstraint.GetRequiredCreationPolicyConstraints((CreationPolicy)requiredCreationPolicy).Union(GetMetadataViewConstraints(importingType, importMany: false)).Union(PartDiscovery.GetExportTypeIdentityConstraints(type));
			importDefinition = new ImportDefinition(string.IsNullOrEmpty(importAttribute.ContractName) ? PartDiscovery.GetContractName(type) : importAttribute.ContractName, importAttribute.AllowDefault ? ImportCardinality.OneOrZero : ImportCardinality.ExactlyOne, PartDiscovery.GetImportMetadataForGenericTypeImport(type), additionalConstraints);
			return true;
		}
		if (firstAttribute != null)
		{
			if (firstAttribute.Source != ImportSource.Any)
			{
				throw new NotSupportedException(Strings.CustomImportSourceNotSupported);
			}
			System.ComponentModel.Composition.CreationPolicy requiredCreationPolicy2 = (PartDiscovery.GetElementTypeFromMany(importingType).IsExportFactoryTypeV1() ? System.ComponentModel.Composition.CreationPolicy.NonShared : firstAttribute.RequiredCreationPolicy);
			Type type2 = firstAttribute.ContractType ?? PartDiscovery.GetTypeIdentityFromImportingType(importingType, importMany: true);
			ImmutableHashSet<IImportSatisfiabilityConstraint> additionalConstraints2 = PartCreationPolicyConstraint.GetRequiredCreationPolicyConstraints((CreationPolicy)requiredCreationPolicy2).Union(GetMetadataViewConstraints(importingType, importMany: true)).Union(PartDiscovery.GetExportTypeIdentityConstraints(type2));
			importDefinition = new ImportDefinition(string.IsNullOrEmpty(firstAttribute.ContractName) ? PartDiscovery.GetContractName(type2) : firstAttribute.ContractName, ImportCardinality.ZeroOrMore, PartDiscovery.GetImportMetadataForGenericTypeImport(type2), additionalConstraints2);
			return true;
		}
		importDefinition = null;
		return false;
	}

	private ImportDefinitionBinding CreateImport(ParameterInfo parameter)
	{
		Assumes.True(TryCreateImportDefinition(parameter.ParameterType, parameter, out var importDefinition));
		return new ImportDefinitionBinding(importDefinition, TypeRef.Get(parameter.Member.DeclaringType, base.Resolver), ParameterRef.Get(parameter, base.Resolver));
	}

	private static IReadOnlyDictionary<string, object> GetExportMetadata(MemberInfo member)
	{
		Requires.NotNull(member, "member");
		ImmutableDictionary<string, object>.Builder builder = ImmutableDictionary.CreateBuilder<string, object>();
		Attribute[] attributes = member.GetAttributes<Attribute>();
		foreach (Attribute attribute in attributes)
		{
			if (attribute is ExportMetadataAttribute exportMetadataAttribute)
			{
				if (exportMetadataAttribute.IsMultiple)
				{
					builder[exportMetadataAttribute.Name] = PartDiscovery.AddElement(builder.GetValueOrDefault(exportMetadataAttribute.Name) as Array, exportMetadataAttribute.Value, null);
				}
				else
				{
					builder.Add(exportMetadataAttribute.Name, exportMetadataAttribute.Value);
				}
				continue;
			}
			Type type = attribute.GetType();
			if (!(type != typeof(ExportAttribute)) || !type.IsAttributeDefined<MetadataAttributeAttribute>(inherit: true))
			{
				continue;
			}
			AttributeUsageAttribute firstAttribute = type.GetFirstAttribute<AttributeUsageAttribute>(inherit: true);
			foreach (PropertyInfo item in from p in attribute.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
				where p.DeclaringType != typeof(Attribute) && p.DeclaringType != typeof(ExportAttribute)
				select p)
			{
				if (firstAttribute != null && firstAttribute.AllowMultiple)
				{
					builder[item.Name] = PartDiscovery.AddElement(builder.GetValueOrDefault(item.Name) as Array, item.GetValue(attribute), ReflectionHelpers.GetMemberType(item));
					continue;
				}
				if (builder.ContainsKey(item.Name))
				{
					string text = ((member.MemberType.HasFlag(MemberTypes.TypeInfo) || member.MemberType.HasFlag(MemberTypes.NestedType)) ? ((Type)member).FullName : $"{member.DeclaringType.FullName}.{member.Name}");
					throw new NotSupportedException(string.Format(CultureInfo.CurrentCulture, Strings.DiscoveredIdenticalPropertiesInMetadataAttributesForPart, new object[2] { text, item.Name }));
				}
				builder.Add(item.Name, item.GetValue(attribute));
			}
		}
		return builder.ToImmutable();
	}
}
