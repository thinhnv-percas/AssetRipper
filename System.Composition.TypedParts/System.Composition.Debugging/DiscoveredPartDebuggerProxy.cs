using System.Collections.Generic;
using System.Composition.TypedParts.Discovery;
using System.Linq;
using System.Reflection;

namespace System.Composition.Debugging;

internal class DiscoveredPartDebuggerProxy
{
	private readonly DiscoveredPart _discoveredPart;

	public Type PartType => _discoveredPart.PartType.AsType();

	public DiscoveredExport[] Exports => _discoveredPart.DiscoveredExports.ToArray();

	public IDictionary<string, object> PartMetadata => _discoveredPart.GetPartMetadata(PartType.GetTypeInfo());

	public DiscoveredPartDebuggerProxy(DiscoveredPart discoveredPart)
	{
		_discoveredPart = discoveredPart;
	}
}
