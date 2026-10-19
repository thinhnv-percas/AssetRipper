using AssetRipper.IO.Files;
using System.Text.Json;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// The plugin DLLs a project must not keep once its manifest names the packages they come from.
/// </summary>
/// <remarks>
/// <para>
/// An IL2CPP build ships every package's code as a stripped assembly, and an export that saves assemblies writes them
/// to <c>Assets/Plugins</c>. Once remapping puts a package in the manifest, Unity resolves that package's dependencies
/// too, so any assembly one of them provides is then declared twice - once by the package, once by the plugin - and the
/// plugin is the stripped one. On SandOut the Editor's URP 17.0.4 compiled against the game's <c>Unity.Mathematics</c>
/// plugin and failed on <c>int * uint3</c>, an operator the game never used and IL2CPP removed.
/// </para>
/// <para>
/// What a package provides is read from the package where it is on disk (its assembly definitions and precompiled
/// DLLs). A registry package that is only named by a dependency is not on disk, so the few every render pipeline
/// depends on are listed in <see cref="KnownRegistryAssemblies"/>; anything else stays, and is reported by nothing,
/// because nothing here can tell what it provides.
/// </para>
/// </remarks>
public static class PackageProvidedPlugins
{
	/// <summary>Assemblies of registry packages that the Editor's built-in packages depend on and do not ship.</summary>
	public static readonly IReadOnlyDictionary<string, string[]> KnownRegistryAssemblies = new Dictionary<string, string[]>(StringComparer.Ordinal)
	{
		["com.unity.mathematics"] = ["Unity.Mathematics"],
		["com.unity.burst"] = ["Unity.Burst", "Unity.Burst.Unsafe"],
		["com.unity.collections"] = ["Unity.Collections", "Unity.Collections.LowLevel.ILSupport"],
	};

	/// <summary>Every assembly the dependency closure of <paramref name="roots"/> provides.</summary>
	/// <param name="roots">The packages the manifest names.</param>
	/// <param name="packageDirectories">Packages on disk, by name.</param>
	public static HashSet<string> ProvidedAssemblies(IEnumerable<string> roots, IReadOnlyDictionary<string, string> packageDirectories)
	{
		HashSet<string> provided = new(StringComparer.Ordinal);
		HashSet<string> visited = new(StringComparer.Ordinal);
		Queue<string> pending = new(roots);

		while (pending.TryDequeue(out string? name))
		{
			if (!visited.Add(name))
			{
				continue;
			}

			if (packageDirectories.TryGetValue(name, out string? directory) && Directory.Exists(directory))
			{
				provided.UnionWith(AssembliesIn(directory));
				foreach (string dependency in DependenciesOf(directory))
				{
					pending.Enqueue(dependency);
				}
			}
			else if (KnownRegistryAssemblies.TryGetValue(name, out string[]? assemblies))
			{
				provided.UnionWith(assemblies);
			}
		}

		return provided;
	}

	/// <summary>Deletes the plugin DLLs (and their metas) under <paramref name="pluginsDirectory"/> that <paramref name="provided"/> names.</summary>
	/// <returns>The assembly names removed.</returns>
	public static List<string> RemoveFrom(string pluginsDirectory, IReadOnlySet<string> provided, FileSystem fileSystem)
	{
		List<string> removed = [];
		if (!fileSystem.Directory.Exists(pluginsDirectory))
		{
			return removed;
		}

		foreach (string assembly in provided.Order(StringComparer.Ordinal))
		{
			string dll = fileSystem.Path.Join(pluginsDirectory, assembly + ".dll");
			if (!fileSystem.File.Exists(dll))
			{
				continue;
			}

			fileSystem.File.Delete(dll);
			if (fileSystem.File.Exists(dll + ".meta"))
			{
				fileSystem.File.Delete(dll + ".meta");
			}
			removed.Add(assembly);
		}

		return removed;
	}

	private static IEnumerable<string> AssembliesIn(string directory)
	{
		foreach (string file in Directory.EnumerateFiles(directory, "*", SearchOption.AllDirectories))
		{
			// A folder ending in ~ is ignored by Unity (Documentation~, Samples~).
			if (file.Contains("~" + Path.DirectorySeparatorChar, StringComparison.Ordinal))
			{
				continue;
			}

			if (file.EndsWith(".asmdef", StringComparison.OrdinalIgnoreCase))
			{
				if (ReadName(file) is { } name)
				{
					yield return name;
				}
			}
			else if (file.EndsWith(".dll", StringComparison.OrdinalIgnoreCase))
			{
				yield return Path.GetFileNameWithoutExtension(file);
			}
		}
	}

	private static string? ReadName(string asmdef)
	{
		try
		{
			using JsonDocument document = JsonDocument.Parse(File.ReadAllText(asmdef));
			return document.RootElement.TryGetProperty("name", out JsonElement name) ? name.GetString() : null;
		}
		catch (Exception exception) when (exception is IOException or JsonException)
		{
			return null;
		}
	}

	private static IEnumerable<string> DependenciesOf(string directory)
	{
		string manifest = Path.Join(directory, PackageSourceResolver.PackageManifestName);
		if (!File.Exists(manifest))
		{
			return [];
		}

		try
		{
			using JsonDocument document = JsonDocument.Parse(File.ReadAllText(manifest));
			return document.RootElement.TryGetProperty("dependencies", out JsonElement dependencies) && dependencies.ValueKind is JsonValueKind.Object
				? dependencies.EnumerateObject().Select(property => property.Name).ToList()
				: [];
		}
		catch (Exception exception) when (exception is IOException or JsonException)
		{
			return [];
		}
	}
}
