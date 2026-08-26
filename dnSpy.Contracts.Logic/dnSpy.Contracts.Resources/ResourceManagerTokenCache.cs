using System.Reflection;

namespace dnSpy.Contracts.Resources;

internal abstract class ResourceManagerTokenCache
{
	public abstract bool TryGetResourceManagerGetMethodMetadataToken(Assembly assembly, out int getMethodMetadataToken);

	public abstract void SetResourceManagerGetMethodMetadataToken(Assembly assembly, int getMethodMetadataToken);
}
