using System;
using System.Collections.Generic;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal class PassthroughMetadataViewProvider : IMetadataViewProvider
{
	internal static readonly ComposablePartDefinition PartDefinition = Utilities.GetMetadataViewProviderPartDefinition(typeof(PassthroughMetadataViewProvider), 1001000, Resolver.DefaultInstance);

	internal static readonly IMetadataViewProvider Default = new PassthroughMetadataViewProvider();

	private PassthroughMetadataViewProvider()
	{
	}

	public bool IsMetadataViewSupported(Type metadataType)
	{
		Requires.NotNull(metadataType, "metadataType");
		if (!metadataType.GetTypeInfo().IsAssignableFrom(typeof(IReadOnlyDictionary<string, object>).GetTypeInfo()))
		{
			return metadataType.GetTypeInfo().IsAssignableFrom(typeof(IDictionary<string, object>).GetTypeInfo());
		}
		return true;
	}

	public object CreateProxy(IReadOnlyDictionary<string, object> metadata, IReadOnlyDictionary<string, object> defaultValues, Type metadataViewType)
	{
		Requires.NotNull(metadata, "metadata");
		return metadata;
	}
}
