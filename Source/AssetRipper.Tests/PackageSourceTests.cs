using AssetRipper.Export.UnityProjects.PackageRemapping;

namespace AssetRipper.Tests;

/// <summary>
/// The sources an export looks in for the official packages.
/// </summary>
public sealed class PackageSourceTests
{
	private sealed class Fixture : IDisposable
	{
		public string Root { get; } = Directory.CreateTempSubdirectory("AssetRipperPackageSources").FullName;

		public string ConfigurationPath => Path.Combine(Root, PackageRemapConfiguration.FileName);

		public string WritePackage(string relativeDirectory, string name, string version)
		{
			string directory = Path.Combine(Root, relativeDirectory);
			Directory.CreateDirectory(directory);
			File.WriteAllText(Path.Combine(directory, "package.json"), $"{{\"name\":\"{name}\",\"version\":\"{version}\"}}\n");
			return directory;
		}

		public void Dispose()
		{
			try
			{
				Directory.Delete(Root, recursive: true);
			}
			catch (IOException)
			{
			}
		}
	}

	/// <summary>
	/// A package manager dependency carries the revision and the subfolder in the url, so the whole
	/// string can be pasted into one box.
	/// </summary>
	[Test]
	public void AGitDependencyIsReadWhole()
	{
		PackageSource source = PackageSource.FromGitUrl("https://github.com/owner/repo.git?path=/Packages/com.owner.thing#v1.2.3");

		Assert.Multiple(() =>
		{
			Assert.That(source.Kind, Is.EqualTo(PackageSourceKind.Git));
			Assert.That(source.Location, Is.EqualTo("https://github.com/owner/repo.git"));
			Assert.That(source.Revision, Is.EqualTo("v1.2.3"));
			Assert.That(source.Subfolder, Is.EqualTo("Packages/com.owner.thing"));
		});
	}

	[Test]
	public void APlainGitUrlHasNoRevisionOrSubfolder()
	{
		PackageSource source = PackageSource.FromGitUrl("  git@github.com:owner/repo.git  ");

		Assert.Multiple(() =>
		{
			Assert.That(source.Location, Is.EqualTo("git@github.com:owner/repo.git"));
			Assert.That(source.Revision, Is.Empty);
			Assert.That(source.Subfolder, Is.Empty);
		});
	}

	/// <summary>
	/// A folder is a package when it has a manifest of its own, and a folder of them otherwise. Both
	/// shapes are what someone points at, and neither says which it is.
	/// </summary>
	[Test]
	public void AFolderHoldingAManifestIsOnePackage()
	{
		using Fixture fixture = new();
		fixture.WritePackage("Lone", "com.owner.lone", "1.0.0");

		List<ResolvedPackage> packages = PackageSourceResolver.FindPackages(Path.Combine(fixture.Root, "Lone"));

		Assert.That(packages, Has.Count.EqualTo(1));
		Assert.That(packages[0].Name, Is.EqualTo("com.owner.lone"));
	}

	[Test]
	public void AFolderOfThemIsEveryPackageUnderIt()
	{
		using Fixture fixture = new();
		fixture.WritePackage(Path.Combine("Cache", "com.owner.first@1.0.0"), "com.owner.first", "1.0.0");
		fixture.WritePackage(Path.Combine("Cache", "com.owner.second@2.0.0"), "com.owner.second", "2.0.0");
		Directory.CreateDirectory(Path.Combine(fixture.Root, "Cache", "NotAPackage"));

		List<ResolvedPackage> packages = PackageSourceResolver.FindPackages(Path.Combine(fixture.Root, "Cache"));

		Assert.That(packages.Select(static package => package.Name), Is.EqualTo(new[] { "com.owner.first", "com.owner.second" }));
	}

	/// <summary>
	/// A cached package's folder is named after the version it holds, which is the answer when its own
	/// manifest does not carry one.
	/// </summary>
	[Test]
	public void TheFolderNameIsTheVersionWhenTheManifestHasNone()
	{
		using Fixture fixture = new();
		string directory = Path.Combine(fixture.Root, "Cache", "com.owner.thing@3.4.5");
		Directory.CreateDirectory(directory);
		File.WriteAllText(Path.Combine(directory, "package.json"), "{\"name\":\"com.owner.thing\"}\n");

		List<ResolvedPackage> packages = PackageSourceResolver.FindPackages(Path.Combine(fixture.Root, "Cache"));

		Assert.That(packages.Single().Version, Is.EqualTo("3.4.5"));
	}

	/// <summary>
	/// A repository that holds a whole project is the usual case, so the package is somewhere inside it.
	/// </summary>
	[Test]
	public void ASubfolderIsWhereTheSourceIsLookedIn()
	{
		using Fixture fixture = new();
		fixture.WritePackage(Path.Combine("Project", "Packages", "com.owner.thing"), "com.owner.thing", "1.0.0");

		PackageSourceResult result = PackageSourceResolver.Resolve(
			new PackageSource
			{
				Kind = PackageSourceKind.Folder,
				Location = Path.Combine(fixture.Root, "Project"),
				Subfolder = Path.Combine("Packages", "com.owner.thing"),
			},
			GitFetchMode.Never);

		Assert.Multiple(() =>
		{
			Assert.That(result.Error, Is.Null);
			Assert.That(result.Packages.Single().Name, Is.EqualTo("com.owner.thing"));
		});
	}

	[Test]
	public void AFolderThatIsNotThereIsAnErrorRatherThanNothing()
	{
		using Fixture fixture = new();

		PackageSourceResult result = PackageSourceResolver.Resolve(
			new PackageSource { Kind = PackageSourceKind.Folder, Location = Path.Combine(fixture.Root, "Missing") },
			GitFetchMode.Never);

		Assert.That(result.Error, Is.Not.Null);
	}

	/// <summary>
	/// An export never clones, so a source nobody has fetched has to say so rather than look like a
	/// repository holding no packages.
	/// </summary>
	[Test]
	public void AGitSourceNobodyHasFetchedSaysSo()
	{
		PackageSourceResult result = PackageSourceResolver.Resolve(
			new PackageSource { Kind = PackageSourceKind.Git, Location = "https://example.invalid/owner/repo.git" },
			GitFetchMode.Never);

		Assert.Multiple(() =>
		{
			Assert.That(result.Error, Does.Contain("cloned"));
			Assert.That(result.Packages, Is.Empty);
		});
	}

	/// <summary>
	/// The clone folder has to be the same one the last run used, and two revisions of one repository
	/// have to be two folders rather than one that keeps changing underneath them.
	/// </summary>
	[Test]
	public void ACloneDirectoryIsStableAndRevisionSpecific()
	{
		PackageSource first = new() { Kind = PackageSourceKind.Git, Location = "https://github.com/owner/repo.git", Revision = "v1" };
		PackageSource second = new() { Kind = PackageSourceKind.Git, Location = "https://github.com/owner/repo.git", Revision = "v2" };
		string directory = GitPackageFetcher.GetCloneDirectory(first);

		Assert.Multiple(() =>
		{
			Assert.That(GitPackageFetcher.GetCloneDirectory(first), Is.EqualTo(directory));
			Assert.That(GitPackageFetcher.GetCloneDirectory(second), Is.Not.EqualTo(directory));
			Assert.That(Path.GetFileName(directory), Does.StartWith("repo-"));
		});
	}

	/// <summary>
	/// The whole git path, against a repository on disk so it needs no network. Cloning a local path is
	/// the same code as cloning a url, which is what makes this worth running.
	/// </summary>
	[Test]
	public void AGitSourceIsClonedAndRead()
	{
		using Fixture fixture = new();

		string repository = fixture.WritePackage("Repository", "com.owner.cloned", "1.0.0");
		if (!TryRunGit(repository, "init", "--initial-branch", "main")
			|| !TryRunGit(repository, "add", "package.json")
			|| !TryRunGit(repository, "-c", "user.email=t@t", "-c", "user.name=t", "commit", "--quiet", "-m", "The package"))
		{
			Assert.Ignore("git is not available");
			return;
		}

		PackageSource source = new() { Kind = PackageSourceKind.Git, Location = repository };
		string clone = GitPackageFetcher.GetCloneDirectory(source);

		try
		{
			PackageSourceResult result = PackageSourceResolver.Resolve(source, GitFetchMode.Always);

			Assert.Multiple(() =>
			{
				Assert.That(result.Error, Is.Null);
				Assert.That(result.Packages.Single().Name, Is.EqualTo("com.owner.cloned"));
				Assert.That(GitPackageFetcher.IsCloned(source), Is.True);
			});
		}
		finally
		{
			try
			{
				Directory.Delete(clone, recursive: true);
			}
			catch (IOException)
			{
			}
		}
	}

	private static bool TryRunGit(string workingDirectory, params string[] arguments)
	{
		try
		{
			System.Diagnostics.ProcessStartInfo startInfo = new()
			{
				FileName = "git",
				WorkingDirectory = workingDirectory,
				UseShellExecute = false,
				CreateNoWindow = true,
			};

			foreach (string argument in arguments)
			{
				startInfo.ArgumentList.Add(argument);
			}

			using System.Diagnostics.Process process = System.Diagnostics.Process.Start(startInfo)!;
			process.WaitForExit();
			return process.ExitCode == 0;
		}
		catch (Exception)
		{
			return false;
		}
	}

	/// <summary>
	/// The file is meant to be edited by hand, so the kind is written as its name.
	/// </summary>
	[Test]
	public void SourcesRoundTripThroughTheConfigurationFile()
	{
		using Fixture fixture = new();

		PackageRemapConfiguration written = new();
		written.Sources.Add(new PackageSource
		{
			Kind = PackageSourceKind.Git,
			Location = "https://github.com/owner/repo.git",
			Revision = "v1.2.3",
			Subfolder = "Packages/com.owner.thing",
			Enabled = false,
		});
		written.Save(fixture.ConfigurationPath);

		PackageRemapConfiguration read = PackageRemapConfiguration.Load(fixture.ConfigurationPath);
		PackageSource source = read.Sources.Single();

		Assert.Multiple(() =>
		{
			Assert.That(File.ReadAllText(fixture.ConfigurationPath), Does.Contain("\"Git\""));
			Assert.That(source.Kind, Is.EqualTo(PackageSourceKind.Git));
			Assert.That(source.Revision, Is.EqualTo("v1.2.3"));
			Assert.That(source.Subfolder, Is.EqualTo("Packages/com.owner.thing"));
			Assert.That(source.Enabled, Is.False);
		});
	}
}
