using AsmResolver.DotNet;
using AsmResolver.DotNet.Signatures;
using AsmResolver.PE.DotNet.Metadata.Tables;
using AssetRipper.Export.UnityProjects.Scripts.AssemblyDefinitions;
using AssetRipper.Primitives;

namespace AssetRipper.Tests;

/// <summary>
/// An exported assembly definition names the assemblies it depends on, read from the image the project ships.
/// </summary>
/// <remarks>
/// An IL2Cpp game's assemblies are modules Cpp2IL builds in memory, and such a module's <c>AssemblyReferences</c> is
/// empty: the type references point at assembly references nobody added to it. Every asmdef therefore said
/// <c>"references": []</c>, and Unity compiled each assembly blind to the others - on the RunFromZombies rip, 3022
/// errors and Assembly-CSharp skipped altogether.
/// </remarks>
public sealed class AssemblyDefinitionReferenceTests
{
	private static (AssemblyDefinition Assembly, MemoryStream Image) BuildInMemory()
	{
		AssemblyDefinition assembly = new("Game.Core", new Version(0, 0, 0, 0));
		ModuleDefinition module = new("Game.Core.dll");
		assembly.Modules.Add(module);

		// The shape Cpp2IL leaves: a type reference whose scope is an assembly reference the module never lists.
		AssemblyReference library = new("Game.Library", new Version(0, 0, 0, 0));
		AssemblyReference unity = new("UnityEngine.CoreModule", new Version(0, 0, 0, 0));
		TypeReference baseType = new(module, library, "Game.Library", "Base");
		TypeReference component = new(module, unity, "UnityEngine", "Component");

		TypeDefinition type = new("Game", "Thing", AsmResolver.PE.DotNet.Metadata.Tables.TypeAttributes.Public, baseType);
		type.Fields.Add(new FieldDefinition("component", FieldAttributes.Public, new FieldSignature(component.ToTypeSignature(isValueType: false))));
		module.TopLevelTypes.Add(type);

		MemoryStream image = new();
		module.Write(image);
		return (assembly, image);
	}

	[Test]
	public void TheInMemoryModuleListsNoReferences()
	{
		// This is the defect itself: if AsmResolver ever starts filling the list, the image route becomes redundant.
		(AssemblyDefinition assembly, _) = BuildInMemory();
		// (A new module lists its core library and nothing else; the references the types use are not there.)
		Assert.That(assembly.ManifestModule!.AssemblyReferences.Select(static reference => reference.Name?.ToString()),
			Has.None.EqualTo("Game.Library").And.None.EqualTo("UnityEngine.CoreModule"));
	}

	[Test]
	public void TheWrittenImageListsThem()
	{
		(_, MemoryStream image) = BuildInMemory();
		image.Position = 17;

		IReadOnlyList<string> names = AssemblyReferenceNames.Read(image);

		Assert.That(names, Does.Contain("Game.Library"));
		Assert.That(names, Does.Contain("UnityEngine.CoreModule"));
		Assert.That(image.Position, Is.EqualTo(17), "the stream belongs to the assembly manager; its position is put back");
		Assert.That(image.CanRead, Is.True, "and it is left open");
	}

	[Test]
	public void NotAnImageReadsAsNoReferences()
	{
		Assert.That(AssemblyReferenceNames.Read(new MemoryStream([1, 2, 3, 4])), Is.Empty);
	}

	[Test]
	public void OnlyOtherProjectAssemblyDefinitionsAreNamed()
	{
		(AssemblyDefinition assembly, MemoryStream image) = BuildInMemory();
		AssemblyDefinitionDetails details = new(assembly, "Assets/Scripts/Game.Core");
		Dictionary<string, UnityGuid> unity = new() { ["UnityEngine.CoreModule"] = default };
		string[] names = ["Game.Library", "UnityEngine.CoreModule", "Game.Core", "Newtonsoft.Json", "Assembly-CSharp-firstpass", "Game.Library"];

		List<string> selected = AssemblyDefinitionExporter.Select(details, unity, names, static name => name is "Game.Library" or "Game.Core");

		// Unity's own assemblies are referenced implicitly, an assembly cannot reference itself, a precompiled plugin
		// (Newtonsoft.Json here) is referenced implicitly and a predefined assembly cannot be referenced at all.
		Assert.That(selected, Is.EqualTo(new[] { "Game.Library" }));
	}

	[Test]
	public void WithoutAnImageTheModulesOwnListIsUsed()
	{
		// A Mono game's assemblies are read from disk, and their list is complete; that path must not change.
		AssemblyDefinition assembly = new("Game.Core", new Version(0, 0, 0, 0));
		ModuleDefinition module = new("Game.Core.dll");
		assembly.Modules.Add(module);
		module.AssemblyReferences.Add(new AssemblyReference("Game.Library", new Version(0, 0, 0, 0)));

		Dictionary<string, UnityGuid> unity = new() { ["mscorlib"] = default };
		List<string> selected = AssemblyDefinitionExporter.Select(new AssemblyDefinitionDetails(assembly, "x"), unity, null, null);

		Assert.That(selected, Is.EqualTo(new[] { "Game.Library" }));
	}
}
