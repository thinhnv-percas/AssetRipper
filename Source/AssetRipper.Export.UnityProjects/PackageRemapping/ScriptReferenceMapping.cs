using AsmResolver.DotNet;
using System.Diagnostics.CodeAnalysis;
using AssetRipper.Export.UnityProjects.Scripts;
using AssetRipper.IO.Files;
using AssetRipper.Primitives;
using AssetRipper.SourceGenerated;
using System.Text;

namespace AssetRipper.Export.UnityProjects.PackageRemapping;

/// <summary>
/// One end of a reference: which file, and which object inside it.
/// </summary>
public readonly record struct AssetReference(long FileId, string Guid);

/// <summary>
/// Where a script reference has to be repointed when a decompiled copy is replaced by the assembly
/// the official package ships.
/// </summary>
/// <param name="TypeFullName">The type the reference resolves to, for the report.</param>
public readonly record struct ScriptRemap(string TypeFullName, AssetReference Old, AssetReference New);

/// <summary>
/// What a package's assemblies say about the scripts ripped out of them.
/// </summary>
/// <param name="AssemblyNames">
/// The assemblies, without their extension. AssetRipper writes a decompiled script under a folder
/// named after the assembly it came from, so this is also where the ripped copies are.
/// </param>
public readonly record struct PackageScripts(List<string> AssemblyNames, List<ScriptRemap> Remaps);

/// <summary>
/// Works out how script references change when a ripped package is swapped for the official one.
/// </summary>
/// <remarks>
/// Scripts are the case a GUID only remap gets wrong. A decompiled script is one file per type, so it
/// has its own guid and the constant fileID every script file has. In the official package the same
/// type lives inside an assembly, which has a single guid for all of it, and the fileID becomes a hash
/// of the namespace and class name. Both halves of the reference change, and rewriting only the guid
/// leaves it pointing at nothing inside the assembly: broken in the editor, but fixed in a diff.
/// <para>
/// Neither end has to be read out of the project. AssetRipper derives a decompiled script's guid from
/// the assembly name, namespace and class name, so enumerating the types in the official assembly
/// gives the old reference and the new one together.
/// </para>
/// </remarks>
public static class ScriptReferenceMapping
{
	/// <summary>
	/// The fileID every decompiled script file is referred to by.
	/// </summary>
	public static long DecompiledScriptFileId { get; } = ExportIdHandler.GetMainExportID((int)ClassIDType.MonoScript);

	private const string AssemblyExtension = ".dll";
	private const string MetaExtension = ".meta";

	/// <summary>
	/// Builds the remapping for every type in the assemblies an official package ships.
	/// </summary>
	/// <param name="officialPackageRoot">The official package, typically under Library/PackageCache.</param>
	public static PackageScripts Build(string officialPackageRoot)
	{
		List<ScriptRemap> remaps = [];
		List<string> assemblyNames = [];

		if (!Directory.Exists(officialPackageRoot))
		{
			return new PackageScripts(assemblyNames, remaps);
		}

		foreach (string assemblyPath in Directory.EnumerateFiles(officialPackageRoot, $"*{AssemblyExtension}", SearchOption.AllDirectories))
		{
			// An assembly with no meta file is not part of the project as far as Unity is concerned, so
			// nothing can refer to it and there is nothing to remap.
			if (!TryReadMetaGuid(assemblyPath + MetaExtension, out string? assemblyGuid))
			{
				continue;
			}

			ModuleDefinition module;
			try
			{
				module = ModuleDefinition.FromFile(assemblyPath);
			}
			catch (Exception)
			{
				// A native library or a managed assembly this version cannot read. Either way there are
				// no types to enumerate.
				continue;
			}

			string assemblyName = SpecialFileNames.FixAssemblyName(Path.GetFileName(assemblyPath));
			assemblyNames.Add(assemblyName);

			// Only top level types: Unity does not serialise a reference to a nested one.
			foreach (TypeDefinition type in module.TopLevelTypes)
			{
				remaps.Add(Build(assemblyName, assemblyGuid, type.Namespace ?? "", type.Name ?? ""));
			}
		}

		return new PackageScripts(assemblyNames, remaps);
	}

	/// <summary>
	/// Builds the remapping for one type.
	/// </summary>
	/// <param name="assemblyName">The assembly file name, with or without its extension.</param>
	/// <param name="assemblyGuid">The guid the official package's assembly meta file carries.</param>
	public static ScriptRemap Build(string assemblyName, string assemblyGuid, string @namespace, string name)
	{
		string fixedName = SpecialFileNames.FixAssemblyName(assemblyName);

		UnityGuid oldGuid = ScriptHashing.CalculateScriptGuid(
			Encoding.UTF8.GetBytes(fixedName),
			Encoding.UTF8.GetBytes(@namespace),
			Encoding.UTF8.GetBytes(name));

		AssetReference old = new(DecompiledScriptFileId, oldGuid.ToString());
		AssetReference @new = new(ScriptHashing.CalculateScriptFileID(@namespace, name), assemblyGuid);

		string fullName = @namespace.Length == 0 ? name : $"{@namespace}.{name}";
		return new ScriptRemap(fullName, old, @new);
	}

	private static bool TryReadMetaGuid(string metaPath, [NotNullWhen(true)] out string? guid)
	{
		guid = null;

		if (!File.Exists(metaPath))
		{
			return false;
		}

		try
		{
			using StreamReader reader = new(metaPath);
			return MetaGuidScanner.TryReadGuid(reader, out guid);
		}
		catch (IOException)
		{
			return false;
		}
	}
}
