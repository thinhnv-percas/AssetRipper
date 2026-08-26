using System.Threading;

namespace dnSpy.Decompiler.MSBuild;

internal sealed class DecompileContext
{
	public CancellationToken CancellationToken { get; }

	public IMSBuildProjectWriterLogger Logger { get; }

	public DecompileContext(CancellationToken ct, IMSBuildProjectWriterLogger logger)
	{
		CancellationToken = ct;
		Logger = logger ?? NoMSBuildProjectWriterLogger.Instance;
	}
}
