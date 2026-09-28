using AssetRipper.Validation.Unity;

namespace AssetRipper.Tests;

/// <summary>
/// The Unity build pipeline, tested without an editor: every decision it makes is made from evidence
/// a test can supply - a log, an exit code, a file on disk.
/// </summary>
internal sealed class UnityBuildValidationTests
{
	private string project = "";

	[SetUp]
	public void CreateProject()
	{
		project = Path.Combine(Path.GetTempPath(), "ar-unity-" + Guid.NewGuid().ToString("N"));
		Directory.CreateDirectory(Path.Combine(project, "Assets", "Scripts"));
		Directory.CreateDirectory(Path.Combine(project, "ProjectSettings"));
		Directory.CreateDirectory(Path.Combine(project, "Packages"));
		File.WriteAllText(Path.Combine(project, "ProjectSettings", "ProjectVersion.txt"),
			"m_EditorVersion: 2022.3.62f2\nm_EditorVersionWithRevision: 2022.3.62f2 (7670c08855a9)\n");
		File.WriteAllText(Path.Combine(project, "Packages", "manifest.json"), "{\"dependencies\":{}}");
		File.WriteAllText(Path.Combine(project, "Assets", "Scripts", "Player.cs"), "class Player {}");
	}

	[TearDown]
	public void DeleteProject()
	{
		if (Directory.Exists(project))
		{
			Directory.Delete(project, recursive: true);
		}
	}

	[Test]
	public void TheEditorVersionIsReadFromTheProject()
	{
		ProjectVersion? version = ProjectVersion.Read(project);
		Assert.That(version, Is.EqualTo(new ProjectVersion("2022.3.62f2", "7670c08855a9")));
		Assert.That(ProjectVersion.Parse("m_EditorVersion: 2021.3.45f1\n"), Is.EqualTo(new ProjectVersion("2021.3.45f1", null)));
		Assert.That(ProjectVersion.Parse("nothing here"), Is.Null);
	}

	[Test]
	public void AFingerprintIsOfContentNotOfEnumerationOrderOrOfUnitysCaches()
	{
		RecoveredProjectFingerprint before = RecoveredProjectFingerprint.Compute(project);

		// Unity's own outputs and the injected validation script are not the recovery.
		Directory.CreateDirectory(Path.Combine(project, "Library"));
		File.WriteAllText(Path.Combine(project, "Library", "ArtifactDB"), "cache");
		Directory.CreateDirectory(Path.Combine(project, "Logs"));
		File.WriteAllText(Path.Combine(project, "Logs", "a.log"), "log");
		ValidationScript.Install(project);

		Assert.That(RecoveredProjectFingerprint.Compute(project), Is.EqualTo(before));

		File.WriteAllText(Path.Combine(project, "Assets", "Scripts", "Player.cs"), "class Player { int hp; }");
		RecoveredProjectFingerprint after = RecoveredProjectFingerprint.Compute(project);

		Assert.Multiple(() =>
		{
			Assert.That(after.Project, Is.Not.EqualTo(before.Project));
			Assert.That(after.Scripts, Is.Not.EqualTo(before.Scripts));
			Assert.That(after.PackageLock, Is.EqualTo(before.PackageLock), "a script change is not a package change");
		});
	}

	[Test]
	public void CompileErrorsAreACompileFailureWhateverTheExitCode()
	{
		const string log = "Compiling...\nAssets/Scripts/Player.cs(3,5): error CS0103: The name 'x' does not exist\nScripts have compiler errors.\n";
		UnityLogClassifier.Classification c = UnityLogClassifier.Classify(1, log, artifactExists: false);

		Assert.That(c.Status, Is.EqualTo(UnityBuildStatus.UnityCompileFailed));
		Assert.That(c.CompilerErrors, Has.Count.EqualTo(1));
	}

	[Test]
	public void AFailedImportIsReportedAtImportEvenWhenCompileErrorsFollow()
	{
		const string log = "An error occurred while resolving packages:\n  Project has invalid dependencies\nAssets/A.cs(1,1): error CS0246: missing\n";
		Assert.That(UnityLogClassifier.Classify(1, log, false).Status, Is.EqualTo(UnityBuildStatus.UnityImportFailed));
	}

	[Test]
	public void ANonZeroExitWithNoEvidenceIsNotCalledACompileFailure()
	{
		UnityLogClassifier.Classification c = UnityLogClassifier.Classify(1, "Loading...\nExiting.\n", false);
		Assert.That(c.Status, Is.EqualTo(UnityBuildStatus.UnityBuildFailed));
		Assert.That(c.Reason, Does.Contain("not called a compile failure"));
	}

	[Test]
	public void SuccessNeedsTheMarkerTheExitCodeAndThePlayer()
	{
		string log = $"{ValidationScript.Marker} BUILD_RESULT Succeeded errors=0\n";

		Assert.Multiple(() =>
		{
			Assert.That(UnityLogClassifier.Classify(0, log, true).Status, Is.EqualTo(UnityBuildStatus.UnityBuildSucceeded));
			Assert.That(UnityLogClassifier.Classify(0, log, false).Status, Is.EqualTo(UnityBuildStatus.UnityBuildFailed), "no player on disk");
			Assert.That(UnityLogClassifier.Classify(1, log, true).Status, Is.EqualTo(UnityBuildStatus.UnityBuildFailed), "non-zero exit");
			// Unity exits 0 from a -quit run that never executed the method.
			Assert.That(UnityLogClassifier.Classify(0, "Exiting batchmode successfully now!\n", true).Status, Is.EqualTo(UnityBuildStatus.UnityBuildFailed));
		});
	}

	[Test]
	public void ALicenceProblemIsNotAvailableAndATimeoutIsTransient()
	{
		Assert.Multiple(() =>
		{
			var noLicence = UnityLogClassifier.Classify(1, "LICENSE SYSTEM [2022] No valid Unity Editor license found.\n", false);
			Assert.That(noLicence.Status, Is.EqualTo(UnityBuildStatus.UnityNotAvailable));
			Assert.That(noLicence.Transient, Is.False);

			var timeout = UnityLogClassifier.Classify(1, "Access token is unavailable; failed to update\n", false);
			Assert.That(timeout.Status, Is.EqualTo(UnityBuildStatus.UnityNotAvailable));
			Assert.That(timeout.Transient, Is.True);

			// Every Unity log starts with this line; alone it is not a licence failure.
			Assert.That(UnityLogClassifier.Classify(1, "LICENSE SYSTEM [2022] Checking for licenses\n", false).Status,
				Is.Not.EqualTo(UnityBuildStatus.UnityNotAvailable));
		});
	}

	[Test]
	public void WithNoEditorAnywhereTheResultIsBlockedNotFailed()
	{
		RecoveredUnityProject recovered = RecoveredUnityProject.Open(project);
		BuildRequest request = new() { ProjectPath = recovered.ProjectPath, TargetPlatform = "Android" };
		LocalUnityBuildProvider local = new(new RecordingRunner(), (_, _) => null);

		UnityBuildResult result = UnityBuildPipeline.Build(recovered, request, [local, new UnavailableUnityBuildProvider("no docker here")]);

		Assert.Multiple(() =>
		{
			Assert.That(result.Status, Is.EqualTo(UnityBuildStatus.UnityNotAvailable));
			Assert.That(result.ValidationLevel, Is.EqualTo("BLOCKED"));
			Assert.That(result.Reason, Does.Contain("2022.3.62f2").And.Contain("no docker here"));
			Assert.That(result.Fingerprint, Is.Not.Null);
		});
	}

	[Test]
	public void TheLocalProviderRunsHeadlessWithTheProjectsOwnVersionAndCleansUp()
	{
		RecoveredUnityProject recovered = RecoveredUnityProject.Open(project);
		RecordingRunner runner = new() { ExitCode = 0, WriteLog = $"{ValidationScript.Marker} BUILD_RESULT Succeeded\n", CreateArtifact = true };
		LocalUnityBuildProvider local = new(runner, (version, _) => version == "2022.3.62f2" ? "/fake/Unity" : null);
		BuildRequest request = new() { ProjectPath = recovered.ProjectPath, TargetPlatform = "Android", EnableGpu = false };

		UnityBuildResult result = UnityBuildPipeline.Build(recovered, request, [local]);

		Assert.Multiple(() =>
		{
			Assert.That(result.Status, Is.EqualTo(UnityBuildStatus.UnityBuildSucceeded));
			Assert.That(result.UnityVersion, Is.EqualTo("2022.3.62f2"));
			Assert.That(runner.Arguments, Does.Contain("-batchmode").And.Contain("-quit").And.Contain("-nographics"));
			Assert.That(runner.Arguments, Does.Contain("-executeMethod").And.Contain(ValidationScript.BuildMethod));
			Assert.That(runner.Arguments[runner.Arguments.IndexOf("-projectPath") + 1], Is.EqualTo(recovered.ProjectPath));
			Assert.That(runner.ScriptWasInstalled, Is.True, "the validation script is present while Unity runs");
			Assert.That(Directory.Exists(Path.Combine(project, ValidationScript.InstallFolder)), Is.False, "and gone afterwards");
			Assert.That(result.UnityLogPath, Is.Not.Null);
		});

		RecordingRunner gpu = new() { ExitCode = 0 };
		new LocalUnityBuildProvider(gpu, (_, _) => "/fake/Unity").Build(recovered, request with { EnableGpu = true });
		Assert.That(gpu.Arguments, Does.Not.Contain("-nographics"));
	}

	[Test]
	public void OnlyATransientFailureIsRetried()
	{
		RecoveredUnityProject recovered = RecoveredUnityProject.Open(project);
		BuildRequest request = new() { ProjectPath = recovered.ProjectPath, TargetPlatform = "Android", MaxAttempts = 3 };

		RecordingRunner transient = new() { ExitCode = 1, WriteLog = "Access token is unavailable\n" };
		UnityBuildResult retried = new LocalUnityBuildProvider(transient, (_, _) => "/fake/Unity").Build(recovered, request);

		RecordingRunner compile = new() { ExitCode = 1, WriteLog = "A.cs(1,1): error CS0103: x\n" };
		UnityBuildResult once = new LocalUnityBuildProvider(compile, (_, _) => "/fake/Unity").Build(recovered, request);

		Assert.Multiple(() =>
		{
			Assert.That(retried.Attempts, Is.EqualTo(3));
			Assert.That(once.Attempts, Is.EqualTo(1));
			Assert.That(once.Status, Is.EqualTo(UnityBuildStatus.UnityCompileFailed));
		});
	}

	[Test]
	public void ACachedVerdictIsReturnedOnlyForTheExactProjectItWasAbout()
	{
		string cacheDirectory = Path.Combine(project, "..", Path.GetFileName(project) + "-cache");
		try
		{
			UnityBuildResultCache cache = new(cacheDirectory);
			RecoveredUnityProject recovered = RecoveredUnityProject.Open(project);
			UnityBuildResult result = new LocalUnityBuildProvider(new RecordingRunner { ExitCode = 1, WriteLog = "A.cs(1,1): error CS0103: x\n" }, (_, _) => "/fake/Unity")
				.Build(recovered, new BuildRequest { ProjectPath = recovered.ProjectPath, TargetPlatform = "Android" });

			Assert.That(cache.Store(result), Is.True);
			BuildCacheKey key = BuildCacheKey.For(result);

			Assert.Multiple(() =>
			{
				Assert.That(cache.TryLoad(key, out _), Is.True);
				Assert.That(cache.TryLoad(key with { ProjectFingerprint = "different" }, out _), Is.False);
				Assert.That(cache.TryLoad(key with { Platform = "iOS" }, out _), Is.False);
				Assert.That(cache.Store(result with { Status = UnityBuildStatus.UnityNotAvailable }), Is.False, "blocked says nothing about the project");
			});
		}
		finally
		{
			if (Directory.Exists(cacheDirectory))
			{
				Directory.Delete(cacheDirectory, true);
			}
		}
	}

	[Test]
	public void DockerNeedsALicenceBeforeItStartsAContainer()
	{
		RecoveredUnityProject recovered = RecoveredUnityProject.Open(project);
		RecordingRunner runner = new() { ExitCode = 0 };
		DockerUnityBuildProvider docker = new(runner, _ => null);

		Assert.Multiple(() =>
		{
			Assert.That(docker.CanBuild(recovered, new BuildRequest { ProjectPath = project, TargetPlatform = "Android" }, out string reason), Is.False);
			Assert.That(reason, Does.Contain("licence"));
			Assert.That(runner.Arguments, Is.Empty, "no container was started");
			Assert.That(DockerUnityBuildProvider.ImageFor("2022.3.62f2", "Android"), Is.EqualTo("unityci/editor:ubuntu-2022.3.62f2-android-3"));
		});
	}

	[Test]
	public void AnOutputRootIsRefusedAsAProject()
	{
		Assert.Throws<DirectoryNotFoundException>(() => RecoveredUnityProject.Open(Path.GetTempPath()));
	}

	[Test]
	public void TheInjectedScriptIsTheOneTheBuildMethodNames()
	{
		string source = ValidationScript.Source;
		Assert.Multiple(() =>
		{
			Assert.That(source, Does.Contain("namespace AssetRipper.Validation"));
			Assert.That(source, Does.Contain("class RecoveredBuildValidation"));
			Assert.That(source, Does.Contain("public static void BuildPlayer()"));
			Assert.That(source, Does.Contain("BUILD_RESULT"));
		});
	}

	private sealed class RecordingRunner : IProcessRunner
	{
		public int? ExitCode { get; init; }

		public string? WriteLog { get; init; }

		public bool CreateArtifact { get; init; }

		public List<string> Arguments { get; } = [];

		public bool ScriptWasInstalled { get; private set; }

		public ProcessOutcome Run(string fileName, IReadOnlyList<string> arguments, string workingDirectory, TimeSpan timeout)
		{
			Arguments.Clear();
			Arguments.AddRange(arguments);
			ScriptWasInstalled = File.Exists(Path.Combine(workingDirectory, ValidationScript.InstallFolder, ValidationScript.FileName));

			int log = Arguments.IndexOf("-logFile");
			if (log >= 0 && WriteLog is not null)
			{
				File.WriteAllText(Arguments[log + 1], WriteLog);
			}

			int path = Arguments.IndexOf("-customBuildPath");
			if (path >= 0 && CreateArtifact)
			{
				Directory.CreateDirectory(Arguments[path + 1]);
			}

			return new ProcessOutcome(ExitCode, "", "", false);
		}
	}
}
