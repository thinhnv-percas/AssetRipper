namespace dnSpy.Decompiler.MSBuild;

internal interface IFileJob : IJob
{
	string Filename { get; }
}
