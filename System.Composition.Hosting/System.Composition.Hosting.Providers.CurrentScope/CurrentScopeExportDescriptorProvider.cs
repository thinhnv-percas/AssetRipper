using System.Collections.Generic;
using System.Composition.Hosting.Core;

namespace System.Composition.Hosting.Providers.CurrentScope;

internal class CurrentScopeExportDescriptorProvider : ExportDescriptorProvider
{
	private static readonly CompositionContract s_currentScopeContract = new CompositionContract(typeof(CompositionContext));

	public override IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract contract, DependencyAccessor definitionAccessor)
	{
		if (!contract.Equals(s_currentScopeContract))
		{
			return ExportDescriptorProvider.NoExportDescriptors;
		}
		return new ExportDescriptorPromise[1]
		{
			new ExportDescriptorPromise(contract, typeof(CompositionContext).Name, isShared: true, ExportDescriptorProvider.NoDependencies, (IEnumerable<CompositionDependency> _) => ExportDescriptor.Create((LifetimeContext c, CompositionOperation o) => c, ExportDescriptorProvider.NoMetadata))
		};
	}
}
