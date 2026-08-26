namespace dnSpy.Decompiler.MSBuild;

internal sealed class NoMSBuildProjectWriterLogger : IMSBuildProjectWriterLogger
{
	public static readonly NoMSBuildProjectWriterLogger Instance = new NoMSBuildProjectWriterLogger();

	public void Error(string message)
	{
	}
}
