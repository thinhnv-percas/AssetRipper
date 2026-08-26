using System.Collections.Generic;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

internal class CycleBreakingExportDescriptor : ExportDescriptor
{
	private readonly Lazy<ExportDescriptor> _exportDescriptor;

	public override CompositeActivator Activator
	{
		get
		{
			if (!_exportDescriptor.IsValueCreated)
			{
				return Activate;
			}
			return _exportDescriptor.Value.Activator;
		}
	}

	public override IDictionary<string, object> Metadata
	{
		get
		{
			if (!_exportDescriptor.IsValueCreated)
			{
				return new CycleBreakingMetadataDictionary(_exportDescriptor);
			}
			return _exportDescriptor.Value.Metadata;
		}
	}

	public CycleBreakingExportDescriptor(Lazy<ExportDescriptor> exportDescriptor)
	{
		_exportDescriptor = exportDescriptor;
	}

	private object Activate(LifetimeContext context, CompositionOperation operation)
	{
		Microsoft.Internal.Assumes.IsTrue(_exportDescriptor.IsValueCreated, "Activation in progress before all descriptors fully initialized.");
		return _exportDescriptor.Value.Activator(context, operation);
	}
}
