using AssetRipper.Il2CppRestore.Binary;
using AssetRipper.Il2CppRestore.Emit;
using AssetRipper.Il2CppRestore.Lift;
using AssetRipper.Il2CppRestore.Lift.Registration;
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

		IBinaryImage image = OpenBinary(options.BinaryPath);
		Console.WriteLine($"Binary: {options.BinaryPath} ({image.Arch}, {(image.Is32Bit ? "32-bit" : "64-bit")})");

		ulong codeRegVa = RegistrationSearch.FindCodeRegistration(image, metadata.Images.Length);
		ulong metadataRegVa = RegistrationSearch.FindMetadataRegistration(image, metadata.TypeDefs.Length);
		if (codeRegVa == 0 || metadataRegVa == 0)
		{
			Console.Error.WriteLine("Could not locate Il2CppCodeRegistration/Il2CppMetadataRegistration in this binary. Falling back to fields-only output.");
			WriteDummyAssemblies(metadata, options);
			return 1;
		}
		Console.WriteLine($"CodeRegistration: 0x{codeRegVa:X}   MetadataRegistration: 0x{metadataRegVa:X}");

		Dictionary<string, Il2CppCodeGenModule> codeGenModules = Il2CppCodeGenModule.ReadAll(image, codeRegVa, metadata.Images.Length);
		Il2CppMetadataRegistration metadataRegistration = Il2CppMetadataRegistration.Read(image, metadataRegVa);
		Dictionary<ulong, Usage> usages = UsageMap.Build(image, metadataRegistration);
		Console.WriteLine($"Code-gen modules: {codeGenModules.Count}   Metadata usage slots decoded: {usages.Count}");

		MethodAddressTable addresses = new(image, codeGenModules);
		SortedDictionary<ulong, ulong> boundaries = addresses.BuildFunctionBoundaries();

		Dictionary<ulong, MethodRef> methodsByVa = BuildMethodsByVa(metadata, codeGenModules, addresses);

		StructDb.StructDb? structs = TryLoadStructDb(options);

		IArchLifter lifter = new Arm64Lifter();
		LiftEnvironment environment = new()
		{
			Metadata = metadata,
			Image = image,
			Structs = structs,
			Usages = usages,
			MethodsByVa = methodsByVa,
			CodeGenModules = codeGenModules,
			Addresses = addresses,
			FunctionBoundaries = boundaries,
			Lifter = lifter,
		};

		if (image.Arch == Architecture.Arm64 && lifter is Arm64Lifter arm64Lifter)
		{
			Console.WriteLine("Learning runtime helper addresses (one pass over every method)...");
			LearnHelpers(arm64Lifter, environment);
		}

		WriteLiftedProject(metadata, environment, options);
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

	private static IBinaryImage OpenBinary(string path)
	{
		string extension = Path.GetExtension(path).ToLowerInvariant();
		return extension switch
		{
			".so" => new ElfImage(path),
			".dll" or ".exe" => new PeImage(path),
			".dylib" => new MachOImage(path),
			_ => ProbeBinaryFormat(path),
		};
	}

	private static IBinaryImage ProbeBinaryFormat(string path)
	{
		byte[] header = new byte[4];
		using (FileStream stream = File.OpenRead(path))
		{
			_ = stream.Read(header, 0, 4);
		}

		if (header[0] == 0x7F && header[1] == 'E' && header[2] == 'L' && header[3] == 'F')
		{
			return new ElfImage(path);
		}
		if (header[0] == 'M' && header[1] == 'Z')
		{
			return new PeImage(path);
		}
		return new MachOImage(path); // Also covers fat/universal binaries (0xCAFEBABE) — see MachOImage.
	}

	private static Dictionary<ulong, MethodRef> BuildMethodsByVa(Il2CppMetadata metadata, Dictionary<string, Il2CppCodeGenModule> codeGenModules, MethodAddressTable addresses)
	{
		Dictionary<ulong, MethodRef> result = [];
		for (int imageIndex = 0; imageIndex < metadata.Images.Length; imageIndex++)
		{
			Il2CppImageDefinition image = metadata.Images[imageIndex];
			string moduleName = metadata.GetString(image.nameIndex);
			if (!codeGenModules.ContainsKey(moduleName))
			{
				continue;
			}

			for (int i = 0; i < image.typeCount; i++)
			{
				Il2CppTypeDefinition td = metadata.TypeDefs[image.typeStart + i];
				for (int m = 0; m < td.method_count; m++)
				{
					int methodIndex = td.methodStart + m;
					ulong va = addresses.GetMethodPointer(moduleName, metadata.Methods[methodIndex]);
					if (va != 0)
					{
						result[va] = MethodRef.Create(metadata, methodIndex, moduleName, va);
					}
				}
			}
		}
		return result;
	}

	private static StructDb.StructDb? TryLoadStructDb(Options options)
	{
		if (options.StructDbDirectory is null)
		{
			Console.WriteLine("No --structdb given: field accesses inside lifted bodies will only resolve for managed types (best-effort offsets), never native runtime structs.");
			return null;
		}

		try
		{
			return StructDb.StructDb.LoadNearest(options.StructDbDirectory, options.UnityVersion ?? "", is32Bit: false);
		}
		catch (Exception exception)
		{
			Console.Error.WriteLine($"Could not load a struct DB: {exception.Message}");
			return null;
		}
	}

	private static void LearnHelpers(Arm64Lifter lifter, LiftEnvironment environment)
	{
		LiftContext context = new()
		{
			Metadata = environment.Metadata,
			Image = environment.Image,
			Structs = environment.Structs,
			Usages = environment.Usages,
			MethodsByVa = environment.MethodsByVa,
			Current = environment.MethodsByVa.Values.FirstOrDefault() ?? throw new InvalidOperationException("No methods with resolved addresses; nothing to learn helpers from."),
		};

		List<(MethodRef Method, IReadOnlyList<DecodedInstruction> Instructions)> decoded = [];
		foreach (MethodRef method in environment.MethodsByVa.Values)
		{
			if (!environment.FunctionBoundaries.TryGetValue(method.Va, out ulong nextVa))
			{
				continue;
			}
			long offset = environment.Image.MapVaToOffset(method.Va);
			if (offset < 0)
			{
				continue;
			}
			int length = (int)Math.Min(nextVa - method.Va, (ulong)(environment.Image.Data.Length - offset));
			if (length is <= 0 or > Arm64Lifter.MaxInstructions * 4)
			{
				continue;
			}
			decoded.Add((method, lifter.Disassemble(environment.Image.Data.Slice((int)offset, length), method.Va)));
		}

		lifter.LearnHelpers(context, decoded);
		foreach ((ulong va, string name) in context.KnownHelpers)
		{
			environment.KnownHelpers[va] = name;
		}
		Console.WriteLine($"Learned {environment.KnownHelpers.Count} runtime helper address(es).");
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

	private static void WriteLiftedProject(Il2CppMetadata metadata, LiftEnvironment environment, Options options)
	{
		string assetsRoot = Path.Combine(options.OutputPath, "Assets");
		Directory.CreateDirectory(assetsRoot);

		CSharpWriter writer = new(metadata, environment, options.UnityVersion ?? "unknown", structDbIsApproximate: false);

		int typesWritten = 0;
		int methodsWithCode = 0;
		int bodiesLifted = 0;

		for (int imageIndex = 0; imageIndex < metadata.Images.Length; imageIndex++)
		{
			Il2CppImageDefinition image = metadata.Images[imageIndex];
			string moduleName = metadata.GetString(image.nameIndex);
			string assemblyFileName = moduleName;

			for (int i = 0; i < image.typeCount; i++)
			{
				int typeDefIndex = image.typeStart + i;
				Il2CppTypeDefinition td = metadata.TypeDefs[typeDefIndex];
				// Nested types are written as part of their declaring type's file by WriteType walking
				// the metadata directly; only top-level types get their own file.
				if (td.declaringTypeIndex >= 0)
				{
					continue;
				}

				using StringWriter code = new();
				writer.WriteType(typeDefIndex, moduleName, code);

				string ns = metadata.GetString(td.namespaceIndex);
				string typeName = metadata.GetString(td.nameIndex);
				string fullName = ns.Length == 0 ? typeName : $"{ns}.{typeName}";
				UnityProjectWriter.WriteScript(assetsRoot, assemblyFileName, fullName, code.ToString());
				typesWritten++;

				for (int m = 0; m < td.method_count; m++)
				{
					Il2CppMethodDefinition method = metadata.Methods[td.methodStart + m];
					if (method.IsAbstract)
					{
						continue;
					}
					methodsWithCode++;
					if (environment.Addresses.GetMethodPointer(moduleName, method) != 0)
					{
						bodiesLifted++;
					}
				}
			}
		}

		Console.WriteLine("--- Summary (guide §14, T4) ---");
		Console.WriteLine($"Types written:   {typesWritten}/{metadata.TypeDefs.Length}");
		Console.WriteLine($"Methods:         {metadata.Methods.Length}");
		Console.WriteLine($"Lifted:          {bodiesLifted}/{methodsWithCode} ({(methodsWithCode == 0 ? 0 : 100.0 * bodiesLifted / methodsWithCode):F1}%)");
	}
}
