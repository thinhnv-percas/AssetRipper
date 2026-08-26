using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Reflection;

namespace Microsoft.VisualStudio.Composition;

internal class MetadataViewImplProxy : IMetadataViewProvider
{
	internal static readonly ComposablePartDefinition PartDefinition = Utilities.GetMetadataViewProviderPartDefinition(typeof(MetadataViewImplProxy), 100, Resolver.DefaultInstance);

	public bool IsMetadataViewSupported(Type metadataType)
	{
		return FindImplClassConstructor(metadataType) != null;
	}

	public object CreateProxy(IReadOnlyDictionary<string, object> metadata, IReadOnlyDictionary<string, object> defaultValues, Type metadataViewType)
	{
		return FindImplClassConstructor(metadataViewType).Invoke(new object[1] { metadata });
	}

	private static ConstructorInfo FindImplClassConstructor(Type metadataType)
	{
		Requires.NotNull(metadataType, "metadataType");
		MetadataViewImplementationAttribute firstAttribute = metadataType.GetFirstAttribute<MetadataViewImplementationAttribute>();
		if (firstAttribute != null && metadataType.IsAssignableFrom(firstAttribute.ImplementationType))
		{
			return (from ctor in firstAttribute.ImplementationType.GetConstructors(BindingFlags.Instance | BindingFlags.Public)
				let parameters = ctor.GetParameters()
				where parameters.Length == 1 && (parameters[0].ParameterType.IsAssignableFrom(typeof(IDictionary<string, object>)) || parameters[0].ParameterType.IsAssignableFrom(typeof(IReadOnlyDictionary<string, object>)))
				select ctor).FirstOrDefault();
		}
		return null;
	}
}
