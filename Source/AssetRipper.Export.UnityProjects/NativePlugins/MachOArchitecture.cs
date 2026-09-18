using System.Buffers.Binary;

namespace AssetRipper.Export.UnityProjects.NativePlugins;

/// <summary>
/// AssetRipper: the architectures a Mach-O binary carries, read from the binary rather than guessed
/// from where it sits.
/// </summary>
/// <remarks>
/// An iOS package has no per-architecture directory the way an APK's <c>lib/&lt;abi&gt;/</c> does, so
/// there is no path to read an architecture out of - a framework is one file that may be thin or fat.
/// Writing <c>arm64</c> down instead would be the "a pass that names an offset must read it from the
/// tables" mistake in another place: a package built for the simulator, or an older one carrying
/// armv7, would be recorded wrongly and nothing downstream could tell.
/// </remarks>
public static class MachOArchitecture
{
	private const uint MagicLittle64 = 0xFEEDFACF;
	private const uint MagicLittle32 = 0xFEEDFACE;
	private const uint MagicBig64 = 0xCFFAEDFE;
	private const uint MagicBig32 = 0xCEFAEDFE;
	private const uint FatMagic = 0xCAFEBABE;
	private const uint FatMagic64 = 0xCAFEBABF;

	private const int Abi64 = 0x0100_0000;

	/// <summary>The architecture names, or an empty list when the file is not a Mach-O at all.</summary>
	public static IReadOnlyList<string> Read(Stream stream)
	{
		Span<byte> header = stackalloc byte[8];

		if (!TryFill(stream, header))
		{
			return [];
		}

		uint magic = BinaryPrimitives.ReadUInt32BigEndian(header);

		if (magic is FatMagic or FatMagic64)
		{
			return ReadFat(stream, magic == FatMagic64);
		}

		uint little = BinaryPrimitives.ReadUInt32LittleEndian(header);

		if (little is MagicLittle64 or MagicLittle32)
		{
			return [NameOf(BinaryPrimitives.ReadInt32LittleEndian(header[4..]))];
		}

		if (little is MagicBig64 or MagicBig32)
		{
			return [NameOf(BinaryPrimitives.ReadInt32BigEndian(header[4..]))];
		}

		return [];
	}

	/// <summary>A fat binary's entries, whose header is big-endian whatever the slices are.</summary>
	private static IReadOnlyList<string> ReadFat(Stream stream, bool sixtyFour)
	{
		Span<byte> countBytes = stackalloc byte[4];
		stream.Position = 4;

		if (!TryFill(stream, countBytes))
		{
			return [];
		}

		uint count = BinaryPrimitives.ReadUInt32BigEndian(countBytes);

		// A fat header names at most a handful of slices; anything else is not one.
		if (count is 0 or > 32)
		{
			return [];
		}

		int entrySize = sixtyFour ? 32 : 20;
		List<string> architectures = new((int)count);
		Span<byte> entry = stackalloc byte[32];

		for (uint index = 0; index < count; index++)
		{
			stream.Position = 8 + (index * entrySize);

			if (!TryFill(stream, entry[..entrySize]))
			{
				break;
			}

			architectures.Add(NameOf(BinaryPrimitives.ReadInt32BigEndian(entry)));
		}

		return architectures;
	}

	private static bool TryFill(Stream stream, Span<byte> buffer)
	{
		int read = 0;

		while (read < buffer.Length)
		{
			int got = stream.Read(buffer[read..]);

			if (got == 0)
			{
				return false;
			}

			read += got;
		}

		return true;
	}

	/// <summary>
	/// The Mach-O CPU type as the name Unity and Apple use for it. An unrecognised type is reported
	/// as the number it is, never as a guess.
	/// </summary>
	internal static string NameOf(int cpuType) => cpuType switch
	{
		7 => "x86",
		7 | Abi64 => "x86_64",
		12 => "armv7",
		12 | Abi64 => "arm64",
		_ => $"cpu_{cpuType}",
	};
}
