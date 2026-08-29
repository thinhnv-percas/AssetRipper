namespace AssetRipper.Il2CppRestore.Binary;

/// <summary>
/// An iOS <c>libil2cpp.dylib</c> (or the IL2CPP slice of a fat/universal binary). Hand-written per the
/// guide §5.3 rather than pulled from a library — the format needed here is small: a Mach-O header, its
/// load commands, and the <c>LC_SEGMENT_64</c>/<c>section_64</c> pairs that give (address, size, offset).
/// </summary>
/// <remarks>
/// Only 64-bit Mach-O is handled (<c>MH_MAGIC_64</c>) — every IL2CPP iOS target is arm64 today, so 32-bit
/// support is left out rather than carried as untested dead code.
/// </remarks>
public sealed class MachOImage : IBinaryImage
{
	private const uint FatMagic = 0xcafebabe;
	private const uint MachMagic64 = 0xfeedfacf;
	private const int LcSegment64 = 0x19;
	private const int CpuTypeArm64 = 0x0100000C;

	private readonly byte[] _data;
	private readonly int _sliceOffset;
	private readonly List<(ulong Va, ulong Size, long Offset)> _segments = [];
	private readonly List<BinarySection> _sections = [];

	public MachOImage(string path)
	{
		_data = File.ReadAllBytes(path);
		_sliceOffset = FindArm64SliceOffset(_data);

		uint magic = ReadUInt32(_data, _sliceOffset, bigEndian: false);
		if (magic != MachMagic64)
		{
			throw new InvalidDataException("Not a 64-bit Mach-O image (or not an arm64 slice of a fat binary).");
		}

		int cpuType = BitConverter.ToInt32(_data, _sliceOffset + 4);
		Arch = cpuType == CpuTypeArm64 ? Architecture.Arm64 : Architecture.Unknown;
		Is32Bit = false;

		uint numCommands = BitConverter.ToUInt32(_data, _sliceOffset + 16);
		int commandOffset = _sliceOffset + 32; // sizeof(mach_header_64)

		for (uint i = 0; i < numCommands; i++)
		{
			uint cmd = BitConverter.ToUInt32(_data, commandOffset);
			uint cmdSize = BitConverter.ToUInt32(_data, commandOffset + 4);

			if (cmd == LcSegment64)
			{
				ReadSegment64(commandOffset);
			}

			commandOffset += (int)cmdSize;
		}

		_segments.Sort((a, b) => a.Va.CompareTo(b.Va));
	}

	private void ReadSegment64(int commandOffset)
	{
		// segment_command_64: cmd, cmdsize, segname[16], vmaddr, vmsize, fileoff, filesize, maxprot,
		// initprot, nsects, flags.
		ulong vmaddr = BitConverter.ToUInt64(_data, commandOffset + 24);
		ulong vmsize = BitConverter.ToUInt64(_data, commandOffset + 32);
		ulong fileoff = BitConverter.ToUInt64(_data, commandOffset + 40);
		uint nsects = BitConverter.ToUInt32(_data, commandOffset + 64);

		_segments.Add((vmaddr, vmsize, (long)fileoff));

		int sectionOffset = commandOffset + 72; // sizeof(segment_command_64)
		const int sectionSize = 80; // sizeof(section_64)
		for (uint s = 0; s < nsects; s++)
		{
			string name = ReadFixedString(_data, sectionOffset, 16);
			ulong addr = BitConverter.ToUInt64(_data, sectionOffset + 32);
			ulong size = BitConverter.ToUInt64(_data, sectionOffset + 40);
			uint offset = BitConverter.ToUInt32(_data, sectionOffset + 48);
			uint flags = BitConverter.ToUInt32(_data, sectionOffset + 64);
			const uint S_ATTR_SOME_INSTRUCTIONS = 0x00000400;
			const uint S_ATTR_PURE_INSTRUCTIONS = 0x80000000;
			bool executable = (flags & (S_ATTR_SOME_INSTRUCTIONS | S_ATTR_PURE_INSTRUCTIONS)) != 0;

			_sections.Add(new BinarySection(name, addr, offset, (long)size, executable));
			sectionOffset += sectionSize;
		}
	}

	/// <summary>
	/// If this is a fat/universal binary, finds the byte offset of its arm64 slice; otherwise returns 0
	/// (the file is already a single-architecture Mach-O).
	/// </summary>
	private static int FindArm64SliceOffset(byte[] data)
	{
		uint magic = ReadUInt32(data, 0, bigEndian: false);
		if (magic != FatMagic)
		{
			return 0;
		}

		// fat_header/fat_arch are always big-endian, regardless of host or slice endianness.
		uint archCount = ReadUInt32(data, 4, bigEndian: true);
		int archOffset = 8;
		for (uint i = 0; i < archCount; i++)
		{
			int cpuType = (int)ReadUInt32(data, archOffset, bigEndian: true);
			uint sliceOffset = ReadUInt32(data, archOffset + 8, bigEndian: true);
			if (cpuType == CpuTypeArm64)
			{
				return (int)sliceOffset;
			}
			archOffset += 20; // sizeof(fat_arch)
		}

		throw new InvalidDataException("No arm64 slice found in this fat Mach-O binary.");
	}

	private static uint ReadUInt32(byte[] data, int offset, bool bigEndian)
	{
		uint value = BitConverter.ToUInt32(data, offset);
		return bigEndian && BitConverter.IsLittleEndian ? System.Buffers.Binary.BinaryPrimitives.ReverseEndianness(value) : value;
	}

	private static string ReadFixedString(byte[] data, int offset, int length)
	{
		int end = Array.IndexOf(data, (byte)0, offset, length);
		int actualLength = end < 0 ? length : end - offset;
		return System.Text.Encoding.ASCII.GetString(data, offset, actualLength);
	}

	public bool Is32Bit { get; }
	public Architecture Arch { get; }
	public ReadOnlyMemory<byte> Data => _data;
	public IReadOnlyList<BinarySection> Sections => _sections;
	public IReadOnlyDictionary<ulong, string> SymbolsByVa => new Dictionary<ulong, string>();

	public long MapVaToOffset(ulong va)
	{
		foreach ((ulong segVa, ulong size, long offset) in _segments)
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
		foreach ((ulong segVa, ulong size, long segOffset) in _segments)
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
		if (fileOffset < 0 || fileOffset + 8 > _data.Length)
		{
			return 0;
		}
		return BitConverter.ToUInt64(_data, (int)fileOffset);
	}
}
