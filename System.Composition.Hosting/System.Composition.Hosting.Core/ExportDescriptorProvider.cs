using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace System.Composition.Hosting.Core;

public abstract class ExportDescriptorProvider
{
	protected static readonly IEnumerable<ExportDescriptorPromise> NoExportDescriptors = Enumerable.Empty<ExportDescriptorPromise>();

	protected static readonly IDictionary<string, object> NoMetadata = new ReadOnlyDictionary<string, object>(new Dictionary<string, object>());

	protected static readonly Func<IEnumerable<CompositionDependency>> NoDependencies = () => Enumerable.Empty<CompositionDependency>();

	public abstract IEnumerable<ExportDescriptorPromise> GetExportDescriptors(CompositionContract contract, DependencyAccessor descriptorAccessor);
}
