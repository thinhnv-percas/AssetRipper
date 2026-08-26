using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.VisualStudio.Composition;

public interface IRuntimeCompositionCacheManager
{
	Task SaveAsync(RuntimeComposition composition, Stream cacheStream, CancellationToken cancellationToken = default(CancellationToken));

	Task<RuntimeComposition> LoadRuntimeCompositionAsync(Stream cacheStream, Resolver resolver, CancellationToken cancellationToken = default(CancellationToken));
}
