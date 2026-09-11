namespace LibCpp2IL.MachO;

/// <summary>
/// AssetRipper: <c>LC_ENCRYPTION_INFO</c> / <c>LC_ENCRYPTION_INFO_64</c>.
/// </summary>
/// <remarks>
/// An App Store build carries this with <see cref="CryptId"/> set, and the range it names - which on
/// a Unity framework is the whole of __TEXT, code and C strings alike - is FairPlay ciphertext on
/// disk. Nothing static can read it. Reading the command is the only way to say so at the input
/// rather than to fail later looking like a metadata problem.
/// </remarks>
public class MachOEncryptionInfoCommand : ReadableClass
{
    public uint CryptOffset;
    public uint CryptSize;
    public uint CryptId;

    /// <summary>Bytes this class reads, so the caller can consume the padding the 64-bit form adds.</summary>
    public const int ReadSize = 12;

    public bool IsEncrypted => CryptId != 0 && CryptSize > 0;

    public override void Read(ClassReadingBinaryReader reader)
    {
        CryptOffset = reader.ReadUInt32();
        CryptSize = reader.ReadUInt32();
        CryptId = reader.ReadUInt32();
    }
}
