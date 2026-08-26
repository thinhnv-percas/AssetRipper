namespace dnSpy.Decompiler.MSBuild;

internal interface IJob
{
	string Description { get; }

	void Create(DecompileContext ctx);
}
