namespace dnSpy.Decompiler.MSBuild;

internal sealed class NoMSBuildProgressListener : IMSBuildProgressListener
{
	public static readonly NoMSBuildProgressListener Instance = new NoMSBuildProgressListener();

	public void SetMaxProgress(int maxProgress)
	{
	}

	public void SetProgress(int progress)
	{
	}
}
