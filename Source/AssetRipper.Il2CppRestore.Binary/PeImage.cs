using AsmResolver.PE.File;
using AsmResolver.PE.File.Headers;

namespace AssetRipper.Il2CppRestore.Binary;

/// <summary>
/// A Windows <c>GameAssembly.dll</c>, read with AsmResolver.PE.File.
/// </summary>
/// <remarks>
/// As with <see cref="ElfImage"/>, the exact AsmResolver.PE.File member names could not be checked
/// against a real build here (NuGet restore is blocked) — verify once this can actually compile.
/// </remarks>
public sealed class PeImage : IBinaryImage
{
	private readonly byte[] _data;
	private readonly PEFile _pe;
	private readonly List<BinarySection> _sections = [];

	public PeImage(string path)
	{
		_data = File.ReadAllBytes(path);
		_pe = PEFile.FromFile(path);

		Is32Bit = _pe.OptionalHeader.Magic == OptionalHeaderMagic.Pe32;
		Arch = _pe.FileHeader.Machine switch
		{
			MachineType.Amd64 => Architecture.X64,
			MachineType.I386 => Architecture.X86,
			MachineType.Arm64 => Architecture.Arm64,
			MachineType.Arm or MachineType.ArmNt => Architecture.Arm32,
			_ => Architecture.Unknown,
		};

		foreach (var section in _pe.Sections)
		{
			bool executable = (section.Characteristics & SectionFlags.MemoryExecute) != 0;
			ulong va = _pe.OptionalHeader.ImageBase + section.Rva;
			_sections.Add(new BinarySection(section.Name, va, section.FileOffset, section.GetPhysicalSize(), executable));
		}
	}

	public bool Is32Bit { get; }
	public Architecture Arch { get; }
	public ReadOnlyMemory<byte> Data => _data;
	public IReadOnlyList<BinarySection> Sections => _sections;

	// A shipped GameAssembly.dll carries no useful export table for game methods (only the fixed set of
	// il2cpp_* runtime entry points, if that) — no shortcut to skip the constrained scan for this format.
	public IReadOnlyDictionary<ulong, string> SymbolsByVa => new Dictionary<ulong, string>();

	public long MapVaToOffset(ulong va)
	{
		ulong imageBase = _pe.OptionalHeader.ImageBase;
		if (va < imageBase)
		{
			return -1;
		}
		uint rva = (uint)(va - imageBase);
		foreach (var section in _pe.Sections)
		{
			if (rva >= section.Rva && rva < section.Rva + section.GetVirtualSize())
			{
				return section.FileOffset + (rva - section.Rva);
			}
		}
		return -1;
	}

	public ulong MapOffsetToVa(long offset)
	{
		foreach (var section in _pe.Sections)
		{
			if (offset >= section.FileOffset && offset < section.FileOffset + section.GetPhysicalSize())
			{
				return _pe.OptionalHeader.ImageBase + section.Rva + (ulong)(offset - section.FileOffset);
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
