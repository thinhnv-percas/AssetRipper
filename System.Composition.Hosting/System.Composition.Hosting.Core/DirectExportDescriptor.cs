using System.Collections.Generic;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

internal class DirectExportDescriptor : ExportDescriptor
{
	private readonly CompositeActivator _activator;

	private readonly IDictionary<string, object> _metadata;

	public override CompositeActivator Activator => _activator;

	public override IDictionary<string, object> Metadata => _metadata;

	public DirectExportDescriptor(CompositeActivator activator, IDictionary<string, object> metadata)
	{
		Microsoft.Internal.Requires.NotNull(activator, "activator");
		Microsoft.Internal.Requires.NotNull(metadata, "metadata");
		_activator = activator;
		_metadata = metadata;
	}
}
