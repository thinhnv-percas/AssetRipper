using System.Collections.Generic;
using Microsoft.Internal;

namespace System.Composition.Hosting.Core;

internal class ExportDescriptorRegistry
{
	private readonly object _thisLock = new object();

	private readonly ExportDescriptorProvider[] _exportDescriptorProviders;

	private volatile IDictionary<CompositionContract, ExportDescriptor[]> _partDefinitions = new Dictionary<CompositionContract, ExportDescriptor[]>();

	public ExportDescriptorRegistry(ExportDescriptorProvider[] exportDescriptorProviders)
	{
		_exportDescriptorProviders = exportDescriptorProviders;
	}

	public bool TryGetSingleForExport(CompositionContract exportKey, out ExportDescriptor defaultForExport)
	{
		if (!_partDefinitions.TryGetValue(exportKey, out var value))
		{
			lock (_thisLock)
			{
				if (!_partDefinitions.ContainsKey(exportKey))
				{
					Dictionary<CompositionContract, ExportDescriptor[]> partDefinitions = new Dictionary<CompositionContract, ExportDescriptor[]>(_partDefinitions);
					ExportDescriptorRegistryUpdate exportDescriptorRegistryUpdate = new ExportDescriptorRegistryUpdate(partDefinitions, _exportDescriptorProviders);
					exportDescriptorRegistryUpdate.Execute(exportKey);
					_partDefinitions = partDefinitions;
				}
			}
			value = _partDefinitions[exportKey];
		}
		if (value.Length == 0)
		{
			defaultForExport = null;
			return false;
		}
		if (value.Length != 1)
		{
			throw ThrowHelper.CardinalityMismatch_TooManyExports(exportKey.ToString());
		}
		defaultForExport = value[0];
		return true;
	}
}
