using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal class MetadataViewClassProvider : IMetadataViewProvider
{
	internal static readonly ComposablePartDefinition PartDefinition = Utilities.GetMetadataViewProviderPartDefinition(typeof(MetadataViewClassProvider), 1000000, Resolver.DefaultInstance);

	internal static readonly IMetadataViewProvider Default = new MetadataViewClassProvider();

	private MetadataViewClassProvider()
	{
	}

	public bool IsMetadataViewSupported(Type metadataType)
	{
		Requires.NotNull(metadataType, "metadataType");
		TypeInfo typeInfo = metadataType.GetTypeInfo();
		if (typeInfo.IsClass && !typeInfo.IsAbstract)
		{
			return FindConstructor(typeInfo) != null;
		}
		return false;
	}

	public object CreateProxy(IReadOnlyDictionary<string, object> metadata, IReadOnlyDictionary<string, object> defaultValues, Type metadataViewType)
	{
		return FindConstructor(metadataViewType.GetTypeInfo()).Invoke(new object[1] { ImmutableDictionary.CreateRange(metadata) });
	}

	private static ConstructorInfo FindConstructor(TypeInfo metadataType)
	{
		Requires.NotNull(metadataType, "metadataType");
		return (from ctor in metadataType.DeclaredConstructors
			where ctor.IsPublic
			let parameters = ctor.GetParameters()
			where parameters.Length == 1
			let paramInfo = parameters[0].ParameterType.GetTypeInfo()
			where paramInfo.IsAssignableFrom(typeof(ImmutableDictionary<string, object>).GetTypeInfo())
			select ctor).FirstOrDefault();
	}
}
