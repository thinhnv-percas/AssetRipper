using System.Collections.Generic;
using System.Composition.Hosting.Core;
using System.Composition.Hosting.Providers.CurrentScope;
using System.Composition.Hosting.Providers.ExportFactory;
using System.Composition.Hosting.Providers.ImportMany;
using System.Composition.Hosting.Providers.Lazy;
using System.Linq;
using Microsoft.Internal;

namespace System.Composition.Hosting;

public sealed class CompositionHost : CompositionContext, IDisposable
{
	private static readonly string[] s_noBoundaries = EmptyArray<string>.Value;

	private readonly LifetimeContext _rootLifetimeContext;

	private CompositionHost(LifetimeContext rootLifetimeContext)
	{
		Microsoft.Internal.Requires.NotNull(rootLifetimeContext, "rootLifetimeContext");
		_rootLifetimeContext = rootLifetimeContext;
	}

	public static CompositionHost CreateCompositionHost(params ExportDescriptorProvider[] providers)
	{
		return CreateCompositionHost((IEnumerable<ExportDescriptorProvider>)providers);
	}

	public static CompositionHost CreateCompositionHost(IEnumerable<ExportDescriptorProvider> providers)
	{
		Microsoft.Internal.Requires.NotNull(providers, "providers");
		ExportDescriptorProvider[] exportDescriptorProviders = new ExportDescriptorProvider[6]
		{
			new LazyExportDescriptorProvider(),
			new ExportFactoryExportDescriptorProvider(),
			new ImportManyExportDescriptorProvider(),
			new LazyWithMetadataExportDescriptorProvider(),
			new CurrentScopeExportDescriptorProvider(),
			new ExportFactoryWithMetadataExportDescriptorProvider()
		}.Concat(providers).ToArray();
		LifetimeContext rootLifetimeContext = new LifetimeContext(new ExportDescriptorRegistry(exportDescriptorProviders), s_noBoundaries);
		return new CompositionHost(rootLifetimeContext);
	}

	public override bool TryGetExport(CompositionContract contract, out object export)
	{
		return _rootLifetimeContext.TryGetExport(contract, out export);
	}

	public void Dispose()
	{
		_rootLifetimeContext.Dispose();
	}
}
