using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace Microsoft.VisualStudio.Composition;

public class DiscoveredParts
{
	public static readonly DiscoveredParts Empty = new DiscoveredParts(ImmutableHashSet.Create<ComposablePartDefinition>(), ImmutableList.Create<PartDiscoveryException>());

	public ImmutableHashSet<ComposablePartDefinition> Parts { get; private set; }

	public ImmutableList<PartDiscoveryException> DiscoveryErrors { get; private set; }

	public DiscoveredParts(IEnumerable<ComposablePartDefinition> parts, IEnumerable<PartDiscoveryException> discoveryErrors)
	{
		Requires.NotNull(parts, "parts");
		Requires.NotNull(discoveryErrors, "discoveryErrors");
		Parts = ImmutableHashSet.CreateRange(parts);
		DiscoveryErrors = ImmutableList.CreateRange(discoveryErrors);
	}

	public DiscoveredParts ThrowOnErrors()
	{
		if (DiscoveryErrors.Count == 0)
		{
			return this;
		}
		throw new CompositionFailedException(Strings.ErrorsDuringDiscovery, new AggregateException(DiscoveryErrors));
	}

	internal DiscoveredParts Merge(DiscoveredParts other)
	{
		Requires.NotNull(other, "other");
		if (other.Parts.Count == 0 && other.DiscoveryErrors.Count == 0)
		{
			return this;
		}
		return new DiscoveredParts(Parts.Union(other.Parts), DiscoveryErrors.AddRange(other.DiscoveryErrors));
	}
}
