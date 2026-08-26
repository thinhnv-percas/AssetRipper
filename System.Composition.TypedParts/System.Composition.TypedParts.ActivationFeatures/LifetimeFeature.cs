using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Reflection;

namespace System.Composition.TypedParts.ActivationFeatures;

internal class LifetimeFeature : ActivationFeature
{
	public const string SharingBoundaryPartMetadataName = "SharingBoundary";

	public override CompositeActivator RewriteActivator(TypeInfo partType, CompositeActivator activatorBody, IDictionary<string, object> partMetadata, IEnumerable<CompositionDependency> dependencies)
	{
		if (!ContractHelpers.IsShared(partMetadata))
		{
			return activatorBody;
		}
		if (!partMetadata.TryGetValue("SharingBoundary", out var value))
		{
			value = null;
		}
		string sharingBoundary = (string)value;
		int sharingKey = LifetimeContext.AllocateSharingId();
		return delegate(LifetimeContext c, CompositionOperation o)
		{
			LifetimeContext lifetimeContext = c.FindContextWithin(sharingBoundary);
			return (lifetimeContext == c) ? lifetimeContext.GetOrCreate(sharingKey, o, activatorBody) : CompositionOperation.Run(lifetimeContext, (LifetimeContext lifetimeContext2, CompositionOperation operation) => lifetimeContext2.GetOrCreate(sharingKey, operation, activatorBody));
		};
	}
}
