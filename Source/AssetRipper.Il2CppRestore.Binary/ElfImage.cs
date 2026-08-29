using ELFSharp.ELF;
using ELFSharp.ELF.Sections;
using ELFSharp.ELF.Segments;

namespace AssetRipper.Il2CppRestore.Binary;

/// <summary>
/// An Android/Linux <c>libil2cpp.so</c>, read with ELFSharp.
/// </summary>
/// <remarks>
/// The exact ELFSharp member names here (<see cref="ISymbolTable"/> in particular) could not be
/// checked against a real build in this environment — NuGet restore is blocked by network policy.
/// Verify this file compiles against whichever ELFSharp version actually resolves before trusting it.
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
		IELF elf = ELFReader.Load(path);

		Is32Bit = elf.Class == Class.Bit32;
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
		foreach (ISegment segment in elf.Segments)
		{
			if (segment.Type != SegmentType.Load)
			{
				continue;
			}
			_loadSegments.Add((segment.Address, segment.Size, segment.Offset));
		}
		_loadSegments.Sort((a, b) => a.Va.CompareTo(b.Va));

		foreach (ISection section in elf.Sections)
		{
			bool executable = (section.Flags & SectionFlags.Executable) != 0;
			_sections.Add(new BinarySection(section.Name, section.LoadAddress, section.Offset, (long)section.Size, executable));
		}

		try
		{
			foreach (ISection section in elf.Sections)
			{
				if (section is not ISymbolTable symbolTable)
				{
					continue;
				}
				foreach (ISymbolEntry entry in symbolTable.Entries)
				{
					if (!string.IsNullOrEmpty(entry.Name) && entry.Value != 0)
					{
						_symbols.TryAdd(entry.Value, entry.Name);
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

	public bool Is32Bit { get; }
	public Architecture Arch { get; }
	public ReadOnlyMemory<byte> Data => _data;
	public IReadOnlyList<BinarySection> Sections => _sections;
	public IReadOnlyDictionary<ulong, string> SymbolsByVa => _symbols;

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
