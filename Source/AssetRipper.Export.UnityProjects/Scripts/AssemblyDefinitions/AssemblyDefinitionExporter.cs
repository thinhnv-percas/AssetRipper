using AsmResolver.DotNet;
using System.Text.Json;

namespace AssetRipper.Export.UnityProjects.Scripts.AssemblyDefinitions;

public static class AssemblyDefinitionExporter
{
	public static void Export(AssemblyDefinitionDetails details, FileSystem fileSystem, Dictionary<string, UnityGuid> referenceAssemblies)
	{
		Export(details, fileSystem, referenceAssemblies, referencedAssemblyNames: null, isProjectAssembly: null);
	}

	/// <param name="referencedAssemblyNames">
	/// The assembly's references as its written image records them (<see cref="AssemblyReferenceNames"/>). When null,
	/// the in-memory module's own list is used, which is complete for a Mono game and empty for an IL2Cpp one.
	/// </param>
	/// <param name="isProjectAssembly">
	/// Whether a referenced name is an assembly definition of this project. An asmdef's <c>references</c> names other
	/// asmdefs; a precompiled plugin is referenced implicitly and a predefined assembly cannot be referenced at all, so
	/// both are left out. When null, every name that is not a Unity reference assembly is kept, as before.
	/// </param>
	public static void Export(
		AssemblyDefinitionDetails details,
		FileSystem fileSystem,
		Dictionary<string, UnityGuid> referenceAssemblies,
		IReadOnlyList<string>? referencedAssemblyNames,
		Func<string, bool>? isProjectAssembly)
	{
		string assetPath = fileSystem.Path.Join(details.OutputFolder, $"{details.AssemblyName}.asmdef");

		AssemblyDefinitionAsset asset = new AssemblyDefinitionAsset(details.AssemblyName);
		foreach (string name in Select(details, referenceAssemblies, referencedAssemblyNames, isProjectAssembly))
		{
			asset.References.Add(name);
		}

		string assetData = JsonSerializer.Serialize(asset, AssemblyDefinitionSerializerContext.Default.AssemblyDefinitionAsset);
		fileSystem.File.WriteAllText(assetPath, assetData);
	}

	public static List<string> Select(
		AssemblyDefinitionDetails details,
		Dictionary<string, UnityGuid> referenceAssemblies,
		IReadOnlyList<string>? referencedAssemblyNames,
		Func<string, bool>? isProjectAssembly)
	{
		IEnumerable<string?> candidates = referencedAssemblyNames
			?? details.Assembly?.ManifestModule?.AssemblyReferences.Select(static reference => (string?)reference.Name)
			?? [];

		List<string> references = [];
		foreach (string? name in candidates)
		{
			if (name is null
				|| name == details.AssemblyName
				|| referenceAssemblies.ContainsKey(name)
				|| references.Contains(name)
				|| (isProjectAssembly is not null && !isProjectAssembly(name)))
			{
				continue;
			}

			references.Add(name);
		}
		return references;
	}
}
