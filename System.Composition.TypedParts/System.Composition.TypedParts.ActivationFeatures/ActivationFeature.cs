using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Reflection;
using Microsoft.Internal;

namespace System.Composition.TypedParts.ActivationFeatures;

internal abstract class ActivationFeature
{
	protected static readonly CompositionDependency[] NoDependencies = Microsoft.Internal.EmptyArray<CompositionDependency>.Value;

	public abstract CompositeActivator RewriteActivator(TypeInfo partType, CompositeActivator activator, IDictionary<string, object> partMetadata, IEnumerable<CompositionDependency> dependencies);

	public virtual IEnumerable<CompositionDependency> GetDependencies(TypeInfo partType, DependencyAccessor definitionAccessor)
	{
		return NoDependencies;
	}
}
