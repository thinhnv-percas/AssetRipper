using AssetRipper.Il2CppRestore.Binary;
using AssetRipper.Il2CppRestore.Emit;
using AssetRipper.Il2CppRestore.Lift;
using AssetRipper.Il2CppRestore.Lift.Registration;
using AssetRipper.Il2CppRestore.Metadata;

namespace AssetRipper.Il2CppRestore.Cli;

/// <summary>
/// One lifted type, ready to be written wherever the caller wants: a new file (the Cli's own use case)
/// or overwriting an already-exported one (AssetRipper's own <c>Il2CppRestorePostExporter</c>, at Script
/// Content Level 4).
/// </summary>
/// <param name="Namespace">Empty for a type with no namespace.</param>
public readonly record struct LiftedType(int TypeDefIndex, string ModuleName, string Namespace, string TypeName, string FullName);

/// <summary>
/// The pipeline behind <see cref="Program"/>'s <c>Main</c>, factored out so it can be driven from code
/// too — originally so the Cli itself was not duplicated, now also used by AssetRipper's own
/// <c>Il2CppRestorePostExporter</c> so Level4 restoration runs in-process instead of shelling out to this
/// tool as a subprocess. See the guide's §1-§12 for what each step does.
/// </summary>
/// <remarks>
/// Never run against a real IL2CPP binary in this sandbox (no NuGet access, no test binary) — see
/// <see cref="Program"/>'s own remarks. Treat a clean run as "the pipeline is wired together correctly",
/// not as "the output is correct".
/// </remarks>
public sealed class RestorePipeline
{
	public Il2CppMetadata Metadata { get; }

	/// <summary>Null in "fields only" mode — no binary was given, so there is nothing to lift.</summary>
	public LiftEnvironment? Lift { get; }

	public CSharpWriter Writer { get; }

	private RestorePipeline(Il2CppMetadata metadata, LiftEnvironment? lift, CSharpWriter writer)
	{
		Metadata = metadata;
		Lift = lift;
		Writer = writer;
	}

	/// <summary>
	/// Loads metadata and, when <paramref name="binaryPath"/> is given, the binary too: locates the
	/// registration structures, decodes metadata usages, builds the method address table, and (for
	/// Arm64) learns runtime helper addresses. Everything <see cref="RenderType"/> needs afterwards.
	/// </summary>
	/// <param name="registrationOverride">
	/// The (CodeRegistration, MetadataRegistration) virtual addresses, when already known from
	/// elsewhere — AssetRipper's own <c>Il2CppRestorePostExporter</c> passes the addresses Cpp2IL/LibCpp2IL
	/// already found and verified while loading the same game, since that scan has real per-version field
	/// layout handling this pipeline's own count-constrained <see cref="RegistrationSearch"/> does not (see
	/// its own remarks): it is strictly more reliable whenever it is available. Only the standalone Cli,
	/// which has no such already-initialized context to borrow from, falls back to
	/// <see cref="RegistrationSearch"/> by leaving this null.
	/// </param>
	public static RestorePipeline Build(string metadataPath, string? binaryPath, string? structDbDirectory, string? unityVersion, TextWriter log, (ulong CodeRegistrationVa, ulong MetadataRegistrationVa)? registrationOverride = null)
	{
		Il2CppMetadata metadata;
		using (FileStream metadataStream = File.OpenRead(metadataPath))
		{
			metadata = Il2CppMetadata.Load(metadataStream);
		}

		if (binaryPath is null)
		{
			log.WriteLine("No binary given: running in \"fields only\" mode.");
			return new RestorePipeline(metadata, null, new CSharpWriter(metadata, null, unityVersion ?? "unknown", structDbIsApproximate: false));
		}

		IBinaryImage image = OpenBinary(binaryPath);
		log.WriteLine($"Binary: {binaryPath} ({image.Arch}, {(image.Is32Bit ? "32-bit" : "64-bit")})");
		if (image is ElfImage { SectionHeadersStripped: true })
		{
			log.WriteLine("This ELF has no section header table (common for hardened/obfuscated builds) — scanning PT_LOAD segments instead.");
		}
		log.WriteLine($"Sections/segments available to scan: {image.Sections.Count} ({string.Join(", ", image.Sections.Select(s => $"{s.Name}[{(s.Executable ? "x" : "-")}]:0x{s.Size:X}"))})");
		log.WriteLine($"Expected counts from metadata: images={metadata.Images.Length}, typeDefinitions={metadata.TypeDefs.Length}");

		ulong codeRegVa, metadataRegVa;
		if (registrationOverride is { } given)
		{
			(codeRegVa, metadataRegVa) = given;
			log.WriteLine($"Using CodeRegistration/MetadataRegistration addresses already resolved by Cpp2IL: 0x{codeRegVa:X} / 0x{metadataRegVa:X}");
		}
		else
		{
			void ScanLog(string message) => log.WriteLine($"  {message}");
			codeRegVa = RegistrationSearch.FindCodeRegistration(image, metadata.Images.Length, ScanLog);
			metadataRegVa = RegistrationSearch.FindMetadataRegistration(image, metadata.TypeDefs.Length, ScanLog);
		}
		if (codeRegVa == 0 || metadataRegVa == 0)
		{
			log.WriteLine("Could not locate Il2CppCodeRegistration/Il2CppMetadataRegistration in this binary. Falling back to fields-only output.");
			return new RestorePipeline(metadata, null, new CSharpWriter(metadata, null, unityVersion ?? "unknown", structDbIsApproximate: false));
		}
		log.WriteLine($"CodeRegistration: 0x{codeRegVa:X}   MetadataRegistration: 0x{metadataRegVa:X}");

		Dictionary<string, Il2CppCodeGenModule> codeGenModules = Il2CppCodeGenModule.ReadAll(image, codeRegVa, metadata.Images.Length);
		Il2CppMetadataRegistration metadataRegistration = Il2CppMetadataRegistration.Read(image, metadataRegVa);
		Dictionary<ulong, Usage> usages = UsageMap.Build(image, metadataRegistration);
		log.WriteLine($"Code-gen modules: {codeGenModules.Count}   Metadata usage slots decoded: {usages.Count}");

		MethodAddressTable addresses = new(image, codeGenModules);
		SortedDictionary<ulong, ulong> boundaries = addresses.BuildFunctionBoundaries();

		Dictionary<ulong, MethodRef> methodsByVa = BuildMethodsByVa(metadata, codeGenModules, addresses);

		StructDb.StructDb? structs = TryLoadStructDb(structDbDirectory, unityVersion, image.Is32Bit, log);

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
			log.WriteLine("Learning runtime helper addresses (one pass over every method)...");
			LearnHelpers(arm64Lifter, environment);
		}

		CSharpWriter writer = new(metadata, environment, unityVersion ?? "unknown", structDbIsApproximate: false);
		return new RestorePipeline(metadata, environment, writer);
	}

	/// <summary>
	/// Every top-level type (nested types are written as part of their declaring type by
	/// <see cref="CSharpWriter.WriteType"/>), in metadata order.
	/// </summary>
	public IEnumerable<LiftedType> EnumerateTopLevelTypes()
	{
		for (int imageIndex = 0; imageIndex < Metadata.Images.Length; imageIndex++)
		{
			Il2CppImageDefinition image = Metadata.Images[imageIndex];
			string moduleName = Metadata.GetString(image.nameIndex);

			for (int i = 0; i < image.typeCount; i++)
			{
				int typeDefIndex = image.typeStart + i;
				Il2CppTypeDefinition td = Metadata.TypeDefs[typeDefIndex];
				if (td.declaringTypeIndex >= 0)
				{
					continue;
				}

				string ns = Metadata.GetString(td.namespaceIndex);
				string typeName = Metadata.GetString(td.nameIndex);
				string fullName = ns.Length == 0 ? typeName : $"{ns}.{typeName}";
				yield return new LiftedType(typeDefIndex, moduleName, ns, typeName, fullName);
			}
		}
	}

	/// <summary>Renders one type's C# source — signature and, when a binary was given, lifted method bodies.</summary>
	public string RenderType(LiftedType type)
	{
		using StringWriter code = new();
		Writer.WriteType(type.TypeDefIndex, type.ModuleName, code);
		return code.ToString();
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

	private static StructDb.StructDb? TryLoadStructDb(string? structDbDirectory, string? unityVersion, bool is32Bit, TextWriter log)
	{
		if (structDbDirectory is null)
		{
			log.WriteLine("No struct DB given: field accesses inside lifted bodies will only resolve for managed types (best-effort offsets), never native runtime structs.");
			return null;
		}

		try
		{
			return StructDb.StructDb.LoadNearest(structDbDirectory, unityVersion ?? "", is32Bit);
		}
		catch (Exception exception)
		{
			log.WriteLine($"Could not load a struct DB: {exception.Message}");
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
	}
}
