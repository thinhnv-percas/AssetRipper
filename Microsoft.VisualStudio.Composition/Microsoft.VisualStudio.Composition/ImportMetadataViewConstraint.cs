using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.Composition.Reflection;

namespace Microsoft.VisualStudio.Composition;

public class ImportMetadataViewConstraint : IImportSatisfiabilityConstraint, IEquatable<IImportSatisfiabilityConstraint>, IDescriptiveToString
{
	public struct MetadatumRequirement
	{
		public TypeRef MetadatumValueTypeRef { get; private set; }

		public Type MetadatumValueType => MetadatumValueTypeRef.Resolve();

		public bool IsMetadataumValueRequired { get; private set; }

		public MetadatumRequirement(TypeRef valueType, bool required)
		{
			this = default(MetadatumRequirement);
			MetadatumValueTypeRef = valueType;
			IsMetadataumValueRequired = required;
		}
	}

	private static readonly ImportMetadataViewConstraint EmptyInstance = new ImportMetadataViewConstraint(ImmutableDictionary<string, MetadatumRequirement>.Empty);

	public ImmutableDictionary<string, MetadatumRequirement> Requirements { get; private set; }

	public ImportMetadataViewConstraint(IReadOnlyDictionary<string, MetadatumRequirement> metadataNamesAndTypes)
	{
		Requires.NotNull(metadataNamesAndTypes, "metadataNamesAndTypes");
		Requirements = ImmutableDictionary.CreateRange(metadataNamesAndTypes);
	}

	public static ImportMetadataViewConstraint GetConstraint(TypeRef metadataTypeRef, Resolver resolver)
	{
		if (metadataTypeRef == null)
		{
			return EmptyInstance;
		}
		ImmutableDictionary<string, MetadatumRequirement> requiredMetadata = GetRequiredMetadata(metadataTypeRef, resolver);
		if (requiredMetadata.IsEmpty)
		{
			return EmptyInstance;
		}
		return new ImportMetadataViewConstraint(requiredMetadata);
	}

	public bool IsSatisfiedBy(ExportDefinition exportDefinition)
	{
		Requires.NotNull(exportDefinition, "exportDefinition");
		if (Requirements.IsEmpty)
		{
			return true;
		}
		foreach (KeyValuePair<string, MetadatumRequirement> requirement in Requirements)
		{
			if (!exportDefinition.Metadata.TryGetValue(requirement.Key, out var value))
			{
				if (requirement.Value.IsMetadataumValueRequired)
				{
					return false;
				}
				continue;
			}
			Type metadatumValueType = requirement.Value.MetadatumValueType;
			if (value == null)
			{
				if (metadatumValueType.GetTypeInfo().IsValueType)
				{
					return false;
				}
			}
			else if (typeof(object[]).IsEquivalentTo(value.GetType()) && (requirement.Value.MetadatumValueTypeRef.IsArray || (metadatumValueType.GetTypeInfo().IsGenericType && typeof(IEnumerable<>).GetTypeInfo().IsAssignableFrom(metadatumValueType.GetTypeInfo().GetGenericTypeDefinition().GetTypeInfo()))))
			{
				TypeInfo typeInfo = PartDiscovery.GetElementTypeFromMany(metadatumValueType).GetTypeInfo();
				object[] array = (object[])value;
				foreach (object obj in array)
				{
					if (obj == null)
					{
						if (typeInfo.IsValueType)
						{
							return false;
						}
					}
					else if (!typeInfo.IsAssignableFrom(obj.GetType().GetTypeInfo()))
					{
						return false;
					}
				}
			}
			else if (!metadatumValueType.GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo()))
			{
				return false;
			}
		}
		return true;
	}

	public void ToString(TextWriter writer)
	{
		IndentingTextWriter indentingTextWriter = IndentingTextWriter.Get(writer);
		foreach (KeyValuePair<string, MetadatumRequirement> requirement in Requirements)
		{
			indentingTextWriter.WriteLine("{0} = {1} (required: {2})", requirement.Key, ReflectionHelpers.GetTypeName(requirement.Value.MetadatumValueType, genericTypeDefinition: false, evenNonPublic: true, null, null), requirement.Value.IsMetadataumValueRequired);
		}
	}

	public bool Equals(IImportSatisfiabilityConstraint obj)
	{
		if (!(obj is ImportMetadataViewConstraint importMetadataViewConstraint))
		{
			return false;
		}
		return ByValueEquality.Dictionary<string, MetadatumRequirement>().Equals(Requirements, importMetadataViewConstraint.Requirements);
	}

	private static ImmutableDictionary<string, MetadatumRequirement> GetRequiredMetadata(TypeRef metadataViewRef, Resolver resolver)
	{
		Requires.NotNull(metadataViewRef, "metadataViewRef");
		Requires.NotNull(resolver, "resolver");
		Type type = metadataViewRef.Resolve();
		if (type.GetTypeInfo().IsInterface && !type.Equals(typeof(IDictionary<string, object>)) && !type.Equals(typeof(IReadOnlyDictionary<string, object>)))
		{
			ImmutableDictionary<string, MetadatumRequirement>.Builder builder = ImmutableDictionary.CreateBuilder<string, MetadatumRequirement>();
			foreach (PropertyInfo item in type.EnumProperties().WherePublicInstance())
			{
				bool required = !item.IsAttributeDefined<DefaultValueAttribute>();
				builder.Add(item.Name, new MetadatumRequirement(TypeRef.Get(ReflectionHelpers.GetMemberType(item), resolver), required));
			}
			return builder.ToImmutable();
		}
		return ImmutableDictionary<string, MetadatumRequirement>.Empty;
	}
}
