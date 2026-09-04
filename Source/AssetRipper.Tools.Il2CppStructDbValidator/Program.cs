using AssetRipper.Import.Logging;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.Recovery;
using AssetRipper.Import.Structure.Assembly.Il2Cpp.StructDb;
using AssetRipper.Primitives;

namespace AssetRipper.Tools.Il2CppStructDbValidator;

/// <summary>
/// Checks an IL2Cpp runtime struct layout database without opening a game, and answers offset
/// questions against it.
/// </summary>
/// <remarks>
/// The invariant sweep exists because a layout file that parses is not the same as a layout file that
/// is right: one wrong field width shifts everything after it, and the result is confidently wrong
/// field names in recovered method bodies.
/// </remarks>
internal static class Program
{
	private static int Main(string[] args)
	{
		Logger.Add(new ConsoleLogger());

		string? directory = null;
		UnityVersion? queryVersion = null;
		bool query32Bit = false;
		long? queryOffset = null;
		string queryStruct = "Il2CppClass";
		bool sweep = true;

		for (int i = 0; i < args.Length; i++)
		{
			switch (args[i])
			{
				case "--version" when i + 1 < args.Length:
					if (!UnityVersion.TryParse(args[++i], out UnityVersion parsed, out _))
					{
						Console.Error.WriteLine($"Not a Unity version: {args[i]}");
						return 2;
					}
					queryVersion = parsed;
					break;
				case "--x32":
					query32Bit = true;
					break;
				case "--struct" when i + 1 < args.Length:
					queryStruct = args[++i];
					break;
				case "--offset" when i + 1 < args.Length:
					string text = args[++i];
					if (!TryParseOffset(text, out long offset))
					{
						Console.Error.WriteLine($"Not an offset: {text}");
						return 2;
					}
					queryOffset = offset;
					break;
				case "--no-sweep":
					sweep = false;
					break;
				case "--help" or "-h":
					WriteUsage();
					return 0;
				default:
					if (args[i].StartsWith('-'))
					{
						Console.Error.WriteLine($"Unknown option: {args[i]}");
						WriteUsage();
						return 2;
					}
					directory = args[i];
					break;
			}
		}

		directory ??= StructDbLocator.Find();
		if (directory is null)
		{
			Console.Error.WriteLine("No struct database given, and none found in the default locations:");
			foreach (string candidate in StructDbLocator.EnumerateDefaultCandidates())
			{
				Console.Error.WriteLine($"  {candidate}");
			}
			return 1;
		}

		StructDbCatalog? catalog = StructDbCatalog.TryCreate(directory);
		if (catalog is null)
		{
			Console.Error.WriteLine($"'{directory}' holds no usable layout files. Each version needs both a -x32 and a -x64 file.");
			return 1;
		}

		Console.WriteLine($"{catalog.Count} Unity versions indexed from {directory}");
		WriteCoverage(catalog);

		int failures = 0;

		if (sweep)
		{
			failures += Sweep(directory, catalog);
		}

		if (queryVersion is not null)
		{
			failures += Query(catalog, queryVersion.Value, query32Bit, queryStruct, queryOffset);
		}

		Console.WriteLine(failures == 0 ? "OK" : $"{failures} problem(s) found");
		return failures == 0 ? 0 : 1;
	}

	private static void WriteUsage()
	{
		Console.WriteLine("""
			Usage: AssetRipper.Tools.Il2CppStructDbValidator [directory] [options]

			  directory          The struct database. Defaults to the same locations AssetRipper searches.

			  --version <ver>    Load the layout for this Unity version and report what it says.
			  --x32              Query the 32-bit layout instead of the 64-bit one.
			  --struct <name>    Struct to resolve --offset in. Default Il2CppClass.
			  --offset <n>       Byte offset to resolve. Accepts 0x notation.
			  --no-sweep         Skip the invariant sweep over every file.
			  -h, --help         This text.

			Exit code is 0 when every check passed.
			""");
	}

	private static void WriteCoverage(StructDbCatalog catalog)
	{
		List<UnityVersion> versions = [.. catalog.AvailableVersions];
		if (versions.Count == 0)
		{
			return;
		}

		Console.WriteLine($"  range: {versions[0]} .. {versions[^1]}");
	}

	/// <summary>
	/// Reads every file and checks the invariants a correct layout must satisfy.
	/// </summary>
	private static int Sweep(string directory, StructDbCatalog catalog)
	{
		int problems = 0;
		int files = 0;
		int structs = 0;
		int fields = 0;

		foreach (UnityVersion version in catalog.AvailableVersions)
		{
			foreach (bool is32Bit in (bool[])[false, true])
			{
				RuntimeStructDb? db = catalog.Load(version, is32Bit);
				if (db is null)
				{
					Console.Error.WriteLine($"  {version} {(is32Bit ? "x32" : "x64")}: could not be loaded");
					problems++;
					continue;
				}

				files++;

				int expectedPointerSize = is32Bit ? 4 : 8;
				if (db.PointerSize != expectedPointerSize)
				{
					Report(version, is32Bit, $"pointerSize is {db.PointerSize}, expected {expectedPointerSize}");
					problems++;
				}

				foreach (string name in EnumerateStructNames(db))
				{
					if (!db.TryGetStruct(name, out StructDbStruct? layout))
					{
						continue;
					}

					structs++;
					problems += CheckStruct(version, is32Bit, name, layout, expectedPointerSize, ref fields);
				}
			}
		}

		Console.WriteLine($"  swept {files} files, {structs} structs, {fields} fields");
		return problems;
	}

	private static int CheckStruct(UnityVersion version, bool is32Bit, string name, StructDbStruct layout, int pointerSize, ref int fields)
	{
		int problems = 0;

		if (layout.Size <= 0)
		{
			Report(version, is32Bit, $"{name}: sizeof is {layout.Size}");
			problems++;
		}

		int previousOffset = -1;

		for (int i = 0; i < layout.Fields.Count; i++)
		{
			StructDbField field = layout.Fields[i];
			fields++;

			if (field.Offset < 0)
			{
				Report(version, is32Bit, $"{name}.{field.Name}: negative offset {field.Offset}");
				problems++;
			}

			if (field.IsFlexibleArray)
			{
				// C excludes a zero-length array from sizeof, so it legitimately starts at the end of the
				// struct. What it may not do is have anything declared after it.
				if (i != layout.Fields.Count - 1)
				{
					Report(version, is32Bit, $"{name}.{field.Name}: zero-length array is not the last member");
					problems++;
				}

				if (field.Offset > layout.Size)
				{
					Report(version, is32Bit, $"{name}.{field.Name}: starts at 0x{field.Offset:X}, past the end of sizeof {layout.Size}");
					problems++;
				}

				previousOffset = Math.Max(previousOffset, field.Offset);
				continue;
			}

			if (field.Offset >= layout.Size && layout.Size > 0)
			{
				Report(version, is32Bit, $"{name}.{field.Name}: offset 0x{field.Offset:X} is outside sizeof {layout.Size}");
				problems++;
			}

			// A union member may sit at or before its predecessor; anything else must move forward.
			if (!layout.Union && !field.Union && field.Offset < previousOffset)
			{
				Report(version, is32Bit, $"{name}.{field.Name}: offset 0x{field.Offset:X} goes backwards from 0x{previousOffset:X}");
				problems++;
			}
			previousOffset = Math.Max(previousOffset, field.Offset);

			if (field.IsBitField)
			{
				// A bitfield has to fit inside the storage unit it is declared in.
				if (field.Bits is <= 0 or > 64)
				{
					Report(version, is32Bit, $"{name}.{field.Name}: {field.Bits} bits");
					problems++;
				}

				if (field.BitOffset is < 0 or > 63)
				{
					Report(version, is32Bit, $"{name}.{field.Name}: bit offset {field.BitOffset}");
					problems++;
				}

				continue;
			}

			if (field.Size < 0)
			{
				Report(version, is32Bit, $"{name}.{field.Name}: negative size {field.Size}");
				problems++;
			}

			if (field.Offset + field.Size > layout.Size && layout.Size > 0 && !field.Union && !layout.Union)
			{
				Report(version, is32Bit, $"{name}.{field.Name}: 0x{field.Offset:X}+{field.Size} exceeds sizeof {layout.Size}");
				problems++;
			}

			// A pointer is exactly one machine word. A field claiming otherwise means the file was
			// read with the wrong architecture, and every offset after it is suspect.
			if (RuntimeStructDb.IsPointer(field.Type) && !field.Type.Contains('[') && field.Size != 0 && field.Size != pointerSize)
			{
				Report(version, is32Bit, $"{name}.{field.Name}: pointer is {field.Size} bytes, expected {pointerSize}");
				problems++;
			}
		}

		return problems;
	}

	private static IEnumerable<string> EnumerateStructNames(RuntimeStructDb db)
	{
		// The database exposes lookup rather than enumeration, so the well-known names carry the sweep.
		foreach (string name in (string[])
		[
			"Il2CppClass", "Il2CppObject", "Il2CppString", "Il2CppArray", "Il2CppArrayBounds",
			"Il2CppType", "Il2CppGenericClass", "Il2CppGenericInst", "Il2CppGenericContext",
			"Il2CppImage", "Il2CppAssembly", "Il2CppAssemblyName", "Il2CppReflectionType",
			"MethodInfo", "FieldInfo", "PropertyInfo", "EventInfo", "ParameterInfo",
			"VirtualInvokeData", "Il2CppClass_1", "Il2CppClass_0", "Il2CppRuntimeInterfaceOffsetPair",
		])
		{
			if (db.Contains(name))
			{
				yield return name;
			}
		}
	}

	private static int Query(StructDbCatalog catalog, UnityVersion version, bool is32Bit, string structName, long? offset)
	{
		RuntimeStructDb? db = catalog.Load(version, is32Bit);
		if (db is null)
		{
			Console.Error.WriteLine($"No layout available for {version}");
			return 1;
		}

		string width = is32Bit ? "x32" : "x64";
		string match = db.IsExactMatch ? "exact" : $"substituted for {version}";
		Console.WriteLine($"{db.Version} {width} ({match})");
		Console.WriteLine($"  pointerSize            {db.PointerSize}");
		Console.WriteLine($"  sizeof(Il2CppClass)    {db.GetSize("Il2CppClass")}");
		Console.WriteLine($"  sizeof(MethodInfo)     {db.GetSize("MethodInfo")}");
		Console.WriteLine($"  sizeof(Il2CppType)     {db.GetSize("Il2CppType")}");

		StructDbClassOffsets offsets = new(db);
		Console.WriteLine($"  Il2CppClass.vtable     0x{offsets.VTableOffset:X} (slot size {offsets.VTableSlotSize})");
		Console.WriteLine($"  .static_fields         0x{offsets.StaticFieldsOffset:X}");
		Console.WriteLine($"  .interfaceOffsets      0x{offsets.InterfaceOffsetsOffset:X}");
		Console.WriteLine($"  .element_class         0x{offsets.ElementClassOffset:X}");

		int patched = Il2CppClassOffsetPatcher.Apply(db);
		Il2CppClassOffsetPatcher.Restore();
		Console.WriteLine($"  offsets fed to Cpp2IL  {patched}");

		if (offset is null)
		{
			return 0;
		}

		if (db.TryResolveField(structName, offset.Value, out RuntimeFieldAccess access))
		{
			string pointee = access.PointeeStruct is null ? "" : $" -> {access.PointeeStruct}";
			string bits = access.IsBitField ? $" [{access.Bits} bits at bit {access.BitOffset}]" : "";
			Console.WriteLine($"  {structName}+0x{offset.Value:X} = {access} ({access.Type}){pointee}{bits}");
			return 0;
		}

		Console.WriteLine($"  {structName}+0x{offset.Value:X} does not resolve");
		return 0;
	}

	private static void Report(UnityVersion version, bool is32Bit, string message)
		=> Console.Error.WriteLine($"  {version} {(is32Bit ? "x32" : "x64")}: {message}");

	private static bool TryParseOffset(string text, out long value)
	{
		text = text.Trim();
		return text.StartsWith("0x", StringComparison.OrdinalIgnoreCase)
			? long.TryParse(text.AsSpan(2), System.Globalization.NumberStyles.HexNumber, null, out value)
			: long.TryParse(text, out value);
	}
}
