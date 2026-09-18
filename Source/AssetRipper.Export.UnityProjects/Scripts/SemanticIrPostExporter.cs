using AssetRipper.Export.Configuration;
using AssetRipper.Import.Logging;
using AssetRipper.Processing;
using Cpp2IL.Core.Analysis;

namespace AssetRipper.Export.UnityProjects.Scripts;

/// <summary>
/// AssetRipper: writes out the semantic IR the generator recorded while it emitted each body.
/// </summary>
/// <remarks>
/// <para>
/// Every semantic measurement in this project used to re-derive what a body does by parsing two
/// renderings of it - <c>[NativeSource(Body = …)]</c> on one side, the decompiled C# on the other -
/// and comparing the operations each seemed to name. Both were derivations, and both drifted: one
/// walked an instruction list the generator no longer emits from, and the other counted a field as
/// lost that the export had deliberately renamed to a property. Each cost an iteration to find, and
/// nothing structural stopped a third.
/// </para>
/// <para>
/// <see cref="RecoveredSemanticIr"/> is filed by the generator at the moment it emits, so it cannot
/// describe a different program from the one exported. This writes it beside the assemblies, keyed by
/// the same RVA the exported <c>[Address(RVA = "0x…")]</c> carries, so a measurement can find the
/// record for a method it is reading without matching names through a decompiler's renaming.
/// </para>
/// <para>
/// It is written after the export rather than during it, and nothing reads it back: a measurement
/// that can change the artefact it measures is worse than no measurement.
/// </para>
/// </remarks>
public sealed class SemanticIrPostExporter : IPostExporter
{
	private const string DirectoryName = "SemanticIR";

	public void DoPostExport(GameData gameData, FullConfiguration settings, FileSystem fileSystem)
	{
		if (RecoveredSemanticIr.Recorded.IsEmpty)
		{
			Logger.Info(LogCategory.Export,
				"Semantic IR: nothing was recorded, so no bodies were generated in this run.");
			return;
		}

		string outputDirectory = fileSystem.Path.Join(settings.AuxiliaryFilesPath, DirectoryName);
		fileSystem.Directory.Create(outputDirectory);

		int assemblies = 0;
		int methods = 0;

		foreach (string assembly in RecoveredSemanticIr.Recorded.Keys)
		{
			string path = fileSystem.Path.Join(outputDirectory, $"{FileSystem.FixInvalidFileNameCharacters(assembly)}.json");
			fileSystem.File.WriteAllText(path, RecoveredSemanticIr.ToJson(assembly));

			assemblies++;
			methods += RecoveredSemanticIr.Recorded[assembly].Count;
		}

		Logger.Info(LogCategory.Export,
			$"Semantic IR: {methods} method bodies across {assemblies} assemblies written to " +
			$"AuxiliaryFiles/{DirectoryName}, recorded by the generator as it emitted them.");
	}
}
