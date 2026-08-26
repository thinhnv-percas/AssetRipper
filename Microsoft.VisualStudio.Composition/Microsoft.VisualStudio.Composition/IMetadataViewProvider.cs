using System;
using System.Collections.Generic;

namespace Microsoft.VisualStudio.Composition;

internal interface IMetadataViewProvider
{
	bool IsMetadataViewSupported(Type metadataType);

	object CreateProxy(IReadOnlyDictionary<string, object> metadata, IReadOnlyDictionary<string, object> defaultValues, Type metadataViewType);
}
