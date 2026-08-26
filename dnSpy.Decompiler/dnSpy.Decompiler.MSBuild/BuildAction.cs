namespace dnSpy.Decompiler.MSBuild;

internal enum BuildAction
{
	DontIncludeInProjectFile,
	None,
	Compile,
	EmbeddedResource,
	ApplicationDefinition,
	Page,
	Resource,
	SplashScreen
}
