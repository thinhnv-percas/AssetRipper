using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Reflection;

namespace System.Composition.TypedParts.ActivationFeatures;

internal class DisposalFeature : ActivationFeature
{
	public override CompositeActivator RewriteActivator(TypeInfo partType, CompositeActivator activator, IDictionary<string, object> partMetadata, IEnumerable<CompositionDependency> dependencies)
	{
		if (!typeof(IDisposable).GetTypeInfo().IsAssignableFrom(partType))
		{
			return activator;
		}
		return delegate(LifetimeContext c, CompositionOperation o)
		{
			IDisposable disposable = (IDisposable)activator(c, o);
			c.AddBoundInstance(disposable);
			return disposable;
		};
	}
}
