namespace dnSpy.Decompiler.MSBuild;

internal interface IMSBuildProgressListener
{
	void SetMaxProgress(int maxProgress);

	void SetProgress(int progress);
}
