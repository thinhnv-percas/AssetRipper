using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using ELFSharp.ELF.Segments;

namespace AssetRipper.Il2CppRestore.Binary;

/// <summary>
/// An Android/Linux <c>libil2cpp.so</c>, read with ELFSharp.
/// </summary>
/// <remarks>
/// ELFSharp's non-generic <see cref="IELF"/>/<see cref="ISegment"/>/<see cref="ISection"/> only expose
/// <c>Type</c>/<c>Flags</c> — the actual address/offset/size fields live on the generic
/// <see cref="Segment{T}"/>/<see cref="Section{T}"/> classes (<c>T</c> is <c>uint</c> for a 32-bit ELF,
/// <c>ulong</c> for 64-bit), which is why this loads through <see cref="ELFReader.Load{T}(string)"/>
/// rather than the untyped <c>ELFReader.Load(path)</c> overload.
/// </remarks>
public sealed class ElfImage : IBinaryImage
{
	private readonly byte[] _data;
	private readonly List<(ulong Va, ulong Size, long Offset)> _loadSegments = [];
	private readonly List<BinarySection> _sections = [];
	private readonly Dictionary<ulong, string> _symbols = [];

	public ElfImage(string path)
	{
		_data = File.ReadAllBytes(path);

		Class elfClass = ELFReader.CheckELFType(path);
		Is32Bit = elfClass == Class.Bit32;

		if (Is32Bit)
		{
			Load(ELFReader.Load<uint>(path));
		}
		else
		{
			Load(ELFReader.Load<ulong>(path));
		}
	}

	private void Load<T>(ELF<T> elf) where T : struct
	{
		Arch = elf.Machine switch
		{
			Machine.AArch64 => Architecture.Arm64,
			Machine.ARM => Architecture.Arm32,
			Machine.AMD64 => Architecture.X64,
			Machine.Intel386 => Architecture.X86,
			_ => Architecture.Unknown,
		};

		// Mapped by PROGRAM header (PT_LOAD), not section header: a stripped .so keeps its program
		// headers (the loader needs them) even when the section headers are gone, and PT_LOAD is what
		// actually decides where bytes land in memory at runtime.
		foreach (Segment<T> segment in elf.Segments)
		{
			if (segment.Type != SegmentType.Load)
			{
				continue;
			}
			_loadSegments.Add((ToUInt64(segment.Address), ToUInt64(segment.Size), segment.Offset));
		}
		_loadSegments.Sort((a, b) => a.Va.CompareTo(b.Va));

		foreach (Section<T> section in elf.Sections)
		{
			bool executable = (section.Flags & SectionFlags.Executable) != 0;
			_sections.Add(new BinarySection(section.Name, ToUInt64(section.LoadAddress), ToInt64(section.Offset), ToInt64(section.Size), executable));
		}

		// Some protected/obfuscated builds strip the section header table entirely (the loader only
		// needs program headers to run) while leaving it in elf.Sections as an empty list. Without a
		// fallback, RegistrationSearch would have nothing to scan at all — silently, no error — so each
		// PT_LOAD segment becomes its own pseudo-section instead, using its own read/write/execute flags.
		if (_sections.Count == 0)
		{
			SectionHeadersStripped = true;
			foreach (Segment<T> segment in elf.Segments)
			{
				if (segment.Type != SegmentType.Load)
				{
					continue;
				}
				bool executable = (segment.Flags & SegmentFlags.Execute) != 0;
				_sections.Add(new BinarySection($"LOAD@0x{ToUInt64(segment.Address):X}", ToUInt64(segment.Address), segment.Offset, ToInt64(segment.Size), executable));
			}
		}

		try
		{
			foreach (Section<T> section in elf.Sections)
			{
				if (section is not SymbolTable<T> symbolTable)
				{
					continue;
				}
				foreach (SymbolEntry<T> entry in symbolTable.Entries)
				{
					ulong value = ToUInt64(entry.Value);
					if (!string.IsNullOrEmpty(entry.Name) && value != 0)
					{
						_symbols.TryAdd(value, entry.Name);
					}
				}
			}
		}
		catch
		{
			// Symbols are a shortcut, not a requirement (guide §6) — a shipped build is usually
			// stripped anyway, so falling back to an empty symbol table is the expected common case.
		}
	}

	private static ulong ToUInt64(object value) => Convert.ToUInt64(value);

	private static long ToInt64(object value) => Convert.ToInt64(value);

	public bool Is32Bit { get; }
	public Architecture Arch { get; private set; }
	public ReadOnlyMemory<byte> Data => _data;
	public IReadOnlyList<BinarySection> Sections => _sections;
	public IReadOnlyDictionary<ulong, string> SymbolsByVa => _symbols;

	/// <summary>True when this ELF has no section header table, so <see cref="Sections"/> was built from PT_LOAD segments instead.</summary>
	public bool SectionHeadersStripped { get; private set; }

	public long MapVaToOffset(ulong va)
	{
		foreach ((ulong segVa, ulong size, long offset) in _loadSegments)
		{
			if (va >= segVa && va < segVa + size)
			{
				return offset + (long)(va - segVa);
			}
		}
		return -1;
	}

	public ulong MapOffsetToVa(long offset)
	{
		foreach ((ulong segVa, ulong size, long segOffset) in _loadSegments)
		{
			if (offset >= segOffset && offset < segOffset + (long)size)
			{
				return segVa + (ulong)(offset - segOffset);
			}
		}
		return 0;
	}

	public ulong ReadPointer(long fileOffset)
	{
		if (fileOffset < 0 || fileOffset + (Is32Bit ? 4 : 8) > _data.Length)
		{
			return 0;
		}
		return Is32Bit
			? BitConverter.ToUInt32(_data, (int)fileOffset)
			: BitConverter.ToUInt64(_data, (int)fileOffset);
	}
}
