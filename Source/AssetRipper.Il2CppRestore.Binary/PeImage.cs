using AsmResolver.PE.File;

namespace AssetRipper.Il2CppRestore.Binary;

/// <summary>
/// A Windows <c>GameAssembly.dll</c>, read with AsmResolver.PE.File.
/// </summary>
/// <remarks>
/// Verified against the real AsmResolver.PE.File API (github.com/Washi1337/AsmResolver) once NuGet
/// access made that possible: everything used here — <see cref="PEFile"/>, <see cref="PESection"/>,
/// <see cref="OptionalHeaderMagic"/>, <see cref="MachineType"/>, <see cref="SectionFlags"/> — lives
/// directly in the <c>AsmResolver.PE.File</c> namespace; there is no separate <c>.Headers</c>
/// sub-namespace. <see cref="PESection"/> also has no <c>FileOffset</c> member — the file offset is
/// just <see cref="PESection.Offset"/>.
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

		Is32Bit = _pe.OptionalHeader.Magic == OptionalHeaderMagic.PE32;
		Arch = _pe.FileHeader.Machine switch
		{
			MachineType.Amd64 => Architecture.X64,
			MachineType.I386 => Architecture.X86,
			MachineType.Arm64 => Architecture.Arm64,
			MachineType.Arm or MachineType.ArmNt => Architecture.Arm32,
			_ => Architecture.Unknown,
		};

		foreach (PESection section in _pe.Sections)
		{
			bool executable = (section.Characteristics & SectionFlags.MemoryExecute) != 0;
			ulong va = _pe.OptionalHeader.ImageBase + section.Rva;
			_sections.Add(new BinarySection(section.Name.ToString(), va, (long)section.Offset, section.GetPhysicalSize(), executable));
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
		foreach (PESection section in _pe.Sections)
		{
			if (rva >= section.Rva && rva < section.Rva + section.GetVirtualSize())
			{
				return (long)section.Offset + (rva - section.Rva);
			}
		}
		return -1;
	}

	public ulong MapOffsetToVa(long offset)
	{
		foreach (PESection section in _pe.Sections)
		{
			if (offset >= (long)section.Offset && offset < (long)section.Offset + section.GetPhysicalSize())
			{
				return _pe.OptionalHeader.ImageBase + section.Rva + (ulong)(offset - (long)section.Offset);
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
