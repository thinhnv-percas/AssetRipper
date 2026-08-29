using AssetRipper.Il2CppRestore.Emit;
using AssetRipper.Il2CppRestore.Metadata;

namespace AssetRipper.Il2CppRestore.Cli;

/// <summary>
/// Drives the whole pipeline end to end (guide §1-§12): read metadata, optionally read a binary and lift
/// its code, and write either a dummy assembly set ("fields only" mode) or a full Unity project with
/// lifted method bodies. See <c>--help</c> for arguments.
/// </summary>
/// <remarks>
/// This has never been run against a real IL2CPP binary — there is no way to build or execute it in the
/// sandbox this was written in (no NuGet access, no test binary). Treat a clean run as "the pipeline is
/// wired together correctly", not as "the output is correct" — that needs the guide's own §14 harness
/// (T3/T4) against a real game, ideally starting with the "fields only" checklist before ever touching
/// <c>--binary</c>.
/// <para>
/// The step-by-step pipeline itself lives in <see cref="RestorePipeline"/>, so AssetRipper's own
/// <c>Il2CppRestorePostExporter</c> (Script Content Level 4) can drive it in-process instead of shelling
/// out to this tool.
/// </para>
/// </remarks>
internal static class Program
{
	private static int Main(string[] args)
	{
		Options? options = Options.Parse(args);
		if (options is null)
		{
			Options.PrintUsage();
			return 1;
		}

		Il2CppMetadata metadata;
		using (FileStream metadataStream = File.OpenRead(options.MetadataPath))
		{
			metadata = Il2CppMetadata.Load(metadataStream);
		}

		Console.WriteLine($"Metadata version: {metadata.Header.Version}");
		RunMetadataInvariants(metadata);

		if (options.BinaryPath is null)
		{
			Console.WriteLine("No --binary given: running in \"fields only\" mode (guide's own recommended starting point).");
			WriteDummyAssemblies(metadata, options);
			return 0;
		}

		RestorePipeline pipeline = RestorePipeline.Build(options.MetadataPath, options.BinaryPath, options.StructDbDirectory, options.UnityVersion, Console.Out);
		if (pipeline.Lift is null)
		{
			// RestorePipeline itself already explained why (binary format not found, or registration structures not located).
			WriteDummyAssemblies(metadata, options);
			return 1;
		}

		WriteLiftedProject(pipeline, options);
		return 0;
	}

	private static void RunMetadataInvariants(Il2CppMetadata metadata)
	{
		// T1 from the guide's §14: cheap, and the strongest early signal that a version was misread.
		int failures = 0;
		void Check(bool condition, string message)
		{
			if (!condition)
			{
				Console.Error.WriteLine($"T1 invariant failed: {message}");
				failures++;
			}
		}

		Check(metadata.Header.Sanity == MetadataHeader.ExpectedSanity, "sanity value");
		foreach (Il2CppTypeDefinition td in metadata.TypeDefs)
		{
			if (td.nameIndex < 0)
			{
				failures++;
				break;
			}
		}
		Check(metadata.Images.Sum(i => (long)i.typeCount) <= metadata.TypeDefs.Length, "images' type counts exceed the type definition table");

		Console.WriteLine(failures == 0
			? "T1 metadata invariants: OK"
			: $"T1 metadata invariants: {failures} failure(s) — treat every downstream number with suspicion.");
	}

	private static void WriteDummyAssemblies(Il2CppMetadata metadata, Options options)
	{
		DummyAssemblyBuilder builder = new(metadata);
		List<Mono.Cecil.AssemblyDefinition> assemblies = builder.Build();

		Directory.CreateDirectory(options.OutputPath);
		int written = 0;
		foreach (Mono.Cecil.AssemblyDefinition assembly in assemblies)
		{
			string path = Path.Combine(options.OutputPath, assembly.Name.Name + ".dll");
			try
			{
				assembly.Write(path);
				written++;
			}
			catch (Exception exception)
			{
				Console.Error.WriteLine($"Could not write {path}: {exception.Message}");
			}
		}

		Console.WriteLine($"Types: {metadata.TypeDefs.Length}   Methods: {metadata.Methods.Length}   Assemblies written: {written}/{assemblies.Count}");
	}

	private static void WriteLiftedProject(RestorePipeline pipeline, Options options)
	{
		string assetsRoot = Path.Combine(options.OutputPath, "Assets");
		Directory.CreateDirectory(assetsRoot);

		int typesWritten = 0;
		int methodsWithCode = 0;
		int bodiesLifted = 0;

		foreach (LiftedType type in pipeline.EnumerateTopLevelTypes())
		{
			string code = pipeline.RenderType(type);
			UnityProjectWriter.WriteScript(assetsRoot, type.ModuleName, type.FullName, code);
			typesWritten++;

			Il2CppTypeDefinition td = pipeline.Metadata.TypeDefs[type.TypeDefIndex];
			for (int m = 0; m < td.method_count; m++)
			{
				Il2CppMethodDefinition method = pipeline.Metadata.Methods[td.methodStart + m];
				if (method.IsAbstract)
				{
					continue;
				}
				methodsWithCode++;
				if (pipeline.Lift!.Addresses.GetMethodPointer(type.ModuleName, method) != 0)
				{
					bodiesLifted++;
				}
			}
		}

		Console.WriteLine("--- Summary (guide §14, T4) ---");
		Console.WriteLine($"Types written:   {typesWritten}/{pipeline.Metadata.TypeDefs.Length}");
		Console.WriteLine($"Methods:         {pipeline.Metadata.Methods.Length}");
		Console.WriteLine($"Lifted:          {bodiesLifted}/{methodsWithCode} ({(methodsWithCode == 0 ? 0 : 100.0 * bodiesLifted / methodsWithCode):F1}%)");
	}
}
