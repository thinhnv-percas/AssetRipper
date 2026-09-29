using AssetRipper.Validation.Unity;

namespace AssetRipper.Tools.UnityBuildValidator;

/// <summary>
/// Headless Unity build of a recovered project, with a status that says what actually happened.
/// </summary>
/// <remarks>
/// <code>
/// UnityBuildValidator build &lt;project&gt; --target Android [--unity 2022.3.62f2] [--editor path]
///                     [--gpu] [--attempts 2] [--docker] [--out result.json] [--cache dir]
/// UnityBuildValidator fingerprint &lt;project&gt;
/// </code>
/// Exit code 0 is a build that Unity really ran and that produced a player; 2 is
/// <c>UNITY_NOT_AVAILABLE</c> - blocked, not failed - and 1 is every other status. A caller that
/// treats 2 as a pass is making the mistake this tool exists to prevent.
/// </remarks>
internal static class Program
{
	private static int Main(string[] args)
	{
		if (args.Length < 2)
		{
			Console.Error.WriteLine("usage: UnityBuildValidator build <project> --target <BuildTarget> [options] | fingerprint <project>");
			return 64;
		}

		RecoveredUnityProject project;
		try
		{
			project = RecoveredUnityProject.Open(args[1]);
		}
		catch (DirectoryNotFoundException ex)
		{
			Console.Error.WriteLine(ex.Message);
			return 64;
		}

		if (args[0] == "fingerprint")
		{
			RecoveredProjectFingerprint fingerprint = RecoveredProjectFingerprint.Compute(project.ProjectPath);
			Console.WriteLine($"project        {fingerprint.Project}");
			Console.WriteLine($"projectSettings {fingerprint.ProjectSettings}");
			Console.WriteLine($"packages       {fingerprint.Packages}");
			Console.WriteLine($"packageLock    {fingerprint.PackageLock}");
			Console.WriteLine($"scripts        {fingerprint.Scripts}");
			Console.WriteLine($"assets         {fingerprint.Assets}");
			Console.WriteLine($"files          {fingerprint.FileCount}");
			Console.WriteLine($"unityVersion   {project.Version?.EditorVersion ?? "(no ProjectVersion.txt)"}");
			return 0;
		}

		string? Option(string name)
		{
			int i = Array.IndexOf(args, name);
			return i >= 0 && i + 1 < args.Length ? args[i + 1] : null;
		}

		string? target = Option("--target");
		if (target is null)
		{
			Console.Error.WriteLine("--target is required: a Unity BuildTarget name such as Android, iOS or StandaloneLinux64");
			return 64;
		}

		BuildRequest request = new()
		{
			ProjectPath = project.ProjectPath,
			TargetPlatform = target,
			UnityVersion = Option("--unity"),
			EditorPath = Option("--editor"),
			EnableGpu = args.Contains("--gpu"),
			MaxAttempts = int.TryParse(Option("--attempts"), out int attempts) ? attempts : 1,
			BuildPath = Option("--build-path"),
		};

		List<IUnityBuildProvider> providers = [new LocalUnityBuildProvider()];
		if (args.Contains("--docker"))
		{
			providers.Add(new DockerUnityBuildProvider());
		}

		UnityBuildResult result = UnityBuildPipeline.Build(project, request, providers);

		if (Option("--cache") is { } cacheDirectory && new UnityBuildResultCache(cacheDirectory).Store(result))
		{
			Console.WriteLine($"cached under {BuildCacheKey.For(result)}");
		}

		string json = result.ToJson();
		if (Option("--out") is { } output)
		{
			File.WriteAllText(output, json);
		}

		Console.WriteLine($"{result.Status.ToReportName()}  {result.ValidationLevel}  {result.Reason}");
		Console.WriteLine($"unity {result.UnityVersion ?? "?"}  provider {result.Provider}  fingerprint {result.Fingerprint?.Project}");
		foreach (UnityStageResult stage in result.Stages)
		{
			Console.WriteLine($"  {stage.Stage.ToReportName(),-18} {stage.Outcome.ToReportName(),-12} {stage.Evidence}");
		}

		return result.Status switch
		{
			UnityBuildStatus.UnityBuildSucceeded => 0,
			UnityBuildStatus.UnityNotAvailable => 2,
			_ => 1,
		};
	}
}
