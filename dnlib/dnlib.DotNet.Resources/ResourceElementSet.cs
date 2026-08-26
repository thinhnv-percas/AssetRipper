using System;
using System.Collections.Generic;

namespace dnlib.DotNet.Resources;

public sealed class ResourceElementSet
{
	private readonly Dictionary<string, ResourceElement> dict = new Dictionary<string, ResourceElement>(StringComparer.Ordinal);

	public int Count => dict.Count;

	public IEnumerable<ResourceElement> ResourceElements => dict.Values;

	public void Add(ResourceElement elem)
	{
		dict[elem.Name] = elem;
	}
}
