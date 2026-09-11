using LibCpp2IL.MachO;

namespace AssetRipper.Tests;

/// <summary>
/// Builds a minimal 64-bit ARM64 Mach-O in memory: a header, one <c>__TEXT</c> segment with the
/// sections it is given, and optionally an <c>LC_ENCRYPTION_INFO_64</c>.
/// </summary>
/// <remarks>
/// The Mach-O paths cannot be covered from a real game: an iOS player is tens of megabytes and an App
/// Store one is encrypted besides. Section enumeration and the encryption command are pure header
/// reading, though, so a synthetic file exercises exactly the code a real binary would.
/// </remarks>
internal sealed class MachOBinaryBuilder
{
	/// <summary>A section of the <c>__TEXT</c> segment, as it will be written.</summary>
	internal readonly record struct Section(string Name, ulong Address, byte[] Data, MachOSectionFlags Flags);

	private const uint LoadCommandSegment64 = 0x19;
	private const uint LoadCommandEncryptionInfo64 = 0x2C;
	private const uint CpuTypeArm64 = 0x0100000C;

	private const int HeaderSize = 32;
	private const int SegmentCommandSize = 72;
	private const int SectionSize = 80;
	private const int EncryptionCommandSize = 24;

	private readonly List<Section> sections = [];

	private (uint Offset, uint Size, uint Id)? encryption;

	public MachOBinaryBuilder AddSection(string name, ulong address, byte[] data, MachOSectionFlags flags = MachOSectionFlags.ATTR_PURE_INSTRUCTIONS | MachOSectionFlags.ATTR_SOME_INSTRUCTIONS)
	{
		sections.Add(new Section(name, address, data, flags));
		return this;
	}

	public MachOBinaryBuilder WithEncryption(uint offset, uint size, uint id)
	{
		encryption = (offset, size, id);
		return this;
	}

	public byte[] Build()
	{
		int commandCount = encryption is null ? 1 : 2;
		int segmentSize = SegmentCommandSize + (SectionSize * sections.Count);
		int commandsSize = segmentSize + (encryption is null ? 0 : EncryptionCommandSize);
		int dataStart = HeaderSize + commandsSize;

		// Lay the section bodies out back to back after the load commands.
		int[] sectionOffsets = new int[sections.Count];
		int cursor = dataStart;
		for (int i = 0; i < sections.Count; i++)
		{
			sectionOffsets[i] = cursor;
			cursor += sections[i].Data.Length;
		}

		byte[] raw = new byte[cursor];
		MemoryStream stream = new(raw);
		BinaryWriter writer = new(stream);

		writer.Write(MachOHeader.MAGIC_64_BIT);
		writer.Write(CpuTypeArm64);
		writer.Write(0u); // cpu subtype
		writer.Write((uint)MachOFileType.MH_EXECUTE);
		writer.Write((uint)commandCount);
		writer.Write((uint)commandsSize);
		writer.Write(0u); // flags
		writer.Write(0u); // reserved

		writer.Write(LoadCommandSegment64);
		writer.Write((uint)segmentSize);
		WriteFixedString(writer, "__TEXT", 16);
		writer.Write(sections.Count == 0 ? 0ul : sections[0].Address);
		writer.Write((ulong)cursor);
		writer.Write(0ul); // file offset
		writer.Write((ulong)cursor);
		writer.Write(5); // max protection: read + execute
		writer.Write(5); // initial protection
		writer.Write((uint)sections.Count);
		writer.Write(0u); // flags

		for (int i = 0; i < sections.Count; i++)
		{
			Section section = sections[i];
			WriteFixedString(writer, section.Name, 16);
			WriteFixedString(writer, "__TEXT", 16);
			writer.Write(section.Address);
			writer.Write((ulong)section.Data.Length);
			writer.Write((uint)sectionOffsets[i]);
			writer.Write(0u); // alignment
			writer.Write(0u); // relocation offset
			writer.Write(0u); // relocation count
			writer.Write((uint)section.Flags);
			writer.Write(0u); // reserved1
			writer.Write(0u); // reserved2
			writer.Write(0u); // reserved3
		}

		if (encryption is { } info)
		{
			writer.Write(LoadCommandEncryptionInfo64);
			writer.Write((uint)EncryptionCommandSize);
			writer.Write(info.Offset);
			writer.Write(info.Size);
			writer.Write(info.Id);
			writer.Write(0u); // padding
		}

		for (int i = 0; i < sections.Count; i++)
		{
			stream.Position = sectionOffsets[i];
			writer.Write(sections[i].Data);
		}

		return raw;
	}

	private static void WriteFixedString(BinaryWriter writer, string value, int length)
	{
		byte[] buffer = new byte[length];
		System.Text.Encoding.UTF8.GetBytes(value, buffer);
		writer.Write(buffer);
	}
}
