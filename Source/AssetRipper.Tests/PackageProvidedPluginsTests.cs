using AssetRipper.Export.UnityProjects.PackageRemapping;
using AssetRipper.IO.Files;

namespace AssetRipper.Tests;

/// <summary>
/// Which plugin DLLs go once the manifest names the packages they come from.
/// </summary>
/// <remarks>
/// SandOut's URP 17.0.4 depends on Mathematics, Burst and Collections; the game shipped stripped copies of all three
/// as plugins, and URP's own source failed on an operator IL2CPP had removed from the copy.
/// </remarks>
public sealed class PackageProvidedPluginsTests
{
	private static string Package(string root, string name, string dependencies, params string[] asmdefNames)
	{
		string directory = Path.Combine(root, name);
		Directory.CreateDirectory(Path.Combine(directory, "Runtime"));
		File.WriteAllText(Path.Combine(directory, "package.json"), $"{{\"name\":\"{name}\",\"dependencies\":{{{dependencies}}}}}");
		foreach (string asmdef in asmdefNames)
		{
			File.WriteAllText(Path.Combine(directory, "Runtime", asmdef + ".asmdef"), $"{{\"name\":\"{asmdef}\"}}");
		}
		return directory;
	}

	[Test]
	public void TheClosureCoversLocalPackagesAndTheKnownRegistryOnes()
	{
		string root = Directory.CreateTempSubdirectory("AssetRipperProvided").FullName;
		try
		{
			string urp = Package(root, "com.unity.render-pipelines.universal", "\"com.unity.render-pipelines.core\":\"17.0.4\"", "Unity.RenderPipelines.Universal.Runtime");
			string core = Package(root, "com.unity.render-pipelines.core", "\"com.unity.mathematics\":\"1.3.2\",\"com.unity.burst\":\"1.8.20\"", "Unity.RenderPipelines.Core.Runtime");
			Directory.CreateDirectory(Path.Combine(core, "Documentation~"));
			File.WriteAllText(Path.Combine(core, "Documentation~", "Ignored.asmdef"), "{\"name\":\"Ignored\"}");

			HashSet<string> provided = PackageProvidedPlugins.ProvidedAssemblies(
				["com.unity.render-pipelines.universal"],
				new Dictionary<string, string> { ["com.unity.render-pipelines.universal"] = urp, ["com.unity.render-pipelines.core"] = core });

			Assert.That(provided, Is.EquivalentTo(new[]
			{
				"Unity.RenderPipelines.Universal.Runtime", "Unity.RenderPipelines.Core.Runtime",
				"Unity.Mathematics", "Unity.Burst", "Unity.Burst.Unsafe",
			}));
		}
		finally
		{
			Directory.Delete(root, recursive: true);
		}
	}

	[Test]
	public void OnlyThePluginsTheClosureProvidesAreRemoved()
	{
		string root = Directory.CreateTempSubdirectory("AssetRipperProvided").FullName;
		try
		{
			string plugins = Path.Combine(root, "Plugins");
			Directory.CreateDirectory(plugins);
			foreach (string name in new[] { "Unity.Mathematics", "Unity.Entities", "Game.Core" })
			{
				File.WriteAllText(Path.Combine(plugins, name + ".dll"), "");
				File.WriteAllText(Path.Combine(plugins, name + ".dll.meta"), "");
			}

			List<string> removed = PackageProvidedPlugins.RemoveFrom(plugins, new HashSet<string> { "Unity.Mathematics", "Unity.Burst" }, LocalFileSystem.Instance);

			Assert.Multiple(() =>
			{
				Assert.That(removed, Is.EqualTo(new[] { "Unity.Mathematics" }));
				Assert.That(File.Exists(Path.Combine(plugins, "Unity.Mathematics.dll")), Is.False);
				Assert.That(File.Exists(Path.Combine(plugins, "Unity.Mathematics.dll.meta")), Is.False);
				Assert.That(File.Exists(Path.Combine(plugins, "Unity.Entities.dll")), Is.True, "no package in the closure provides Entities");
				Assert.That(File.Exists(Path.Combine(plugins, "Game.Core.dll")), Is.True);
			});
		}
		finally
		{
			Directory.Delete(root, recursive: true);
		}
	}
}
