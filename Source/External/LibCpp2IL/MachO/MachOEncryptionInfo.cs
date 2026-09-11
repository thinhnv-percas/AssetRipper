using System;
using System.IO;

namespace LibCpp2IL.MachO;

/// <summary>
/// AssetRipper: the payload of an <c>LC_ENCRYPTION_INFO</c> / <c>LC_ENCRYPTION_INFO_64</c> load command.
/// </summary>
/// <remarks>
/// A binary downloaded from the App Store carries this with a non-zero <see cref="CryptId"/>, and the
/// bytes it covers — which on an il2cpp build is the whole <c>__TEXT</c> segment, the generated method
/// bodies included — are FairPlay ciphertext on disk. Nothing can be lifted from them, and the
/// difference between that and a lifter that simply failed is not visible anywhere downstream, so it
/// is read here to be reported outright.
/// </remarks>
public readonly struct MachOEncryptionInfo(uint cryptOffset, uint cryptSize, uint cryptId)
{
    /// <summary>File offset of the encrypted range.</summary>
    public uint CryptOffset { get; } = cryptOffset;

    /// <summary>Length of the encrypted range, in bytes.</summary>
    public uint CryptSize { get; } = cryptSize;

    /// <summary>The encryption system in use. Zero means the range is present but not encrypted.</summary>
    public uint CryptId { get; } = cryptId;

    /// <summary>The <c>FAT_MAGIC</c> of a universal binary, which is big-endian on every host.</summary>
    private const uint UniversalMagic = 0xCAFEBABE;

    /// <summary><c>FAT_MAGIC_64</c>, whose entries carry 64-bit offsets.</summary>
    private const uint UniversalMagic64 = 0xCAFEBABF;

    public bool IsEncrypted => CryptId != 0 && CryptSize > 0;

    /// <summary>True when <paramref name="offset"/> falls inside the encrypted range.</summary>
    public bool Covers(ulong offset) => IsEncrypted && offset >= CryptOffset && offset < CryptOffset + CryptSize;

    /// <summary>
    /// Reads the command body, which both the 32-bit and the 64-bit form begin with. The 64-bit form
    /// adds a padding word after it that nothing needs.
    /// </summary>
    public static MachOEncryptionInfo? FromCommandData(byte[]? data)
    {
        if (data is null || data.Length < 12)
            return null;

        return new MachOEncryptionInfo(
            BitConverter.ToUInt32(data, 0),
            BitConverter.ToUInt32(data, 4),
            BitConverter.ToUInt32(data, 8));
    }

    /// <summary>
    /// AssetRipper: the encrypted range declared by the Mach-O at <paramref name="path"/>, or null when
    /// it is not a Mach-O, declares none, or declares one with <c>cryptid</c> zero.
    /// </summary>
    /// <remarks>
    /// Walks the load commands off the front of the file rather than parsing it. A caller that wants
    /// this wants it <em>before</em> deciding to load the binary at all, and on an iOS player that is a
    /// fifty megabyte read to answer a question the first few kilobytes settle. Never throws: a file
    /// that is not a Mach-O, or is truncated, is simply not encrypted as far as this is concerned.
    /// </remarks>
    public static MachOEncryptionInfo? ReadFromFile(string path)
    {
        try
        {
            using var stream = File.OpenRead(path);
            return ReadFrom(stream);
        }
        catch
        {
            return null;
        }
    }

    /// <summary>See <see cref="ReadFromFile"/>. <paramref name="stream"/> must be positioned at the header.</summary>
    public static MachOEncryptionInfo? ReadFrom(Stream stream)
    {
        var start = stream.Position;
        var header = new byte[32];

        if (!ReadExactly(stream, header, 32))
            return null;

        var magic = BitConverter.ToUInt32(header, 0);

        // A fat binary holds one Mach-O per architecture. Its header and offsets are big-endian.
        if (magic is UniversalMagic or UniversalMagic64)
            return ReadFromUniversal(stream, start, header, magic == UniversalMagic64);

        var is64Bit = magic == MachOHeader.MAGIC_64_BIT;
        if (!is64Bit && magic != MachOHeader.MAGIC_32_BIT)
            return null;

        var numLoadCommands = BitConverter.ToUInt32(header, 16);

        // The 32-bit header is four bytes shorter, so its commands start four bytes earlier.
        stream.Position = start + (is64Bit ? 32 : 28);

        var commandHeader = new byte[8];
        for (var i = 0; i < numLoadCommands; i++)
        {
            var commandStart = stream.Position;

            if (!ReadExactly(stream, commandHeader, 8))
                return null;

            var command = (LoadCommandId)BitConverter.ToUInt32(commandHeader, 0);
            var commandSize = BitConverter.ToUInt32(commandHeader, 4);

            if (commandSize < 8)
                return null;

            if (command is LoadCommandId.LC_ENCRYPTION_INFO or LoadCommandId.LC_ENCRYPTION_INFO_64)
            {
                var body = new byte[12];
                if (!ReadExactly(stream, body, 12))
                    return null;

                if (FromCommandData(body) is { IsEncrypted: true } info)
                    return info;
            }

            stream.Position = commandStart + commandSize;
        }

        return null;
    }

    private static MachOEncryptionInfo? ReadFromUniversal(Stream stream, long start, byte[] header, bool is64Bit)
    {
        var numArchitectures = ReadUInt32BigEndian(header, 4);
        var entrySize = is64Bit ? 32 : 20;
        var entry = new byte[entrySize];

        for (var i = 0; i < numArchitectures; i++)
        {
            stream.Position = start + 8 + (long)i * entrySize;

            if (!ReadExactly(stream, entry, entrySize))
                return null;

            var offset = is64Bit
                ? (long)ReadUInt64BigEndian(entry, 16)
                : ReadUInt32BigEndian(entry, 8);

            stream.Position = start + offset;

            if (ReadFrom(stream) is { } info)
                return info;
        }

        return null;
    }

    private static bool ReadExactly(Stream stream, byte[] buffer, int count)
    {
        var read = 0;
        while (read < count)
        {
            var got = stream.Read(buffer, read, count - read);
            if (got <= 0)
                return false;
            read += got;
        }

        return true;
    }

    private static uint ReadUInt32BigEndian(byte[] data, int offset)
        => (uint)((data[offset] << 24) | (data[offset + 1] << 16) | (data[offset + 2] << 8) | data[offset + 3]);

    private static ulong ReadUInt64BigEndian(byte[] data, int offset)
        => ((ulong)ReadUInt32BigEndian(data, offset) << 32) | ReadUInt32BigEndian(data, offset + 4);
}
