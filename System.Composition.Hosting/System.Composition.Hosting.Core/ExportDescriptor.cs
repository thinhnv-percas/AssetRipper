using System.Collections.Generic;

namespace System.Composition.Hosting.Core;

public abstract class ExportDescriptor
{
	public abstract CompositeActivator Activator { get; }

	public abstract IDictionary<string, object> Metadata { get; }

	public static ExportDescriptor Create(CompositeActivator activator, IDictionary<string, object> metadata)
	{
		return new DirectExportDescriptor(activator, metadata);
	}
}
