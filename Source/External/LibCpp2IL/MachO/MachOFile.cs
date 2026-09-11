using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using LibCpp2IL.Logging;
using System.Diagnostics.CodeAnalysis;

namespace LibCpp2IL.MachO;

public class MachOFile : Il2CppBinary
{
    private byte[] _raw;

    private readonly MachOHeader _header;
    private readonly MachOLoadCommand[] _loadCommands;

    private readonly MachOSegmentCommand[] Segments64;
    private readonly MachOSection[] Sections64;
    private readonly Dictionary<string, ulong> _exportAddressesDict;

    /// <summary>AssetRipper: the encryption command, when the binary carries one.</summary>
    public MachOEncryptionInfoCommand? Encryption { get; }
    private readonly Dictionary<ulong, string> _exportNamesDict;

    public MachOFile(MemoryStream input) : base(input)
    {
        LibLogger.VerboseNewline("Reading Mach-O file...");
        _raw = input.GetBuffer();

        LibLogger.Verbose("\tReading Mach-O header...");
        _header = ReadReadable<MachOHeader>();

        switch (_header.Magic)
        {
            case MachOHeader.MAGIC_32_BIT:
                LibLogger.Verbose("Mach-O is 32-bit...");
                is32Bit = true;
                break;
            case MachOHeader.MAGIC_64_BIT:
                LibLogger.Verbose("Mach-O is 64-bit...");
                is32Bit = false;
                break;
            default:
                throw new($"Unknown Mach-O Magic: {_header.Magic}");
        }

        switch (_header.CpuType)
        {
            case MachOCpuType.CPU_TYPE_I386:
                LibLogger.VerboseNewline("Mach-O contains x86_32 instructions.");
                InstructionSetId = DefaultInstructionSets.X86_32;
                break;
            case MachOCpuType.CPU_TYPE_X86_64:
                LibLogger.VerboseNewline("Mach-O contains x86_64 instructions.");
                InstructionSetId = DefaultInstructionSets.X86_64;
                break;
            case MachOCpuType.CPU_TYPE_ARM:
                LibLogger.VerboseNewline("Mach-O contains ARM (32-bit) instructions.");
                InstructionSetId = DefaultInstructionSets.ARM_V7;
                break;
            case MachOCpuType.CPU_TYPE_ARM64:
                LibLogger.VerboseNewline("Mach-O contains ARM64 instructions.");
                InstructionSetId = DefaultInstructionSets.ARM_V8;
                break;
            default:
                throw new($"Don't know how to handle a Mach-O CPU Type of {_header.CpuType}");
        }

        if (_header.Magic == MachOHeader.MAGIC_32_BIT)
            LibLogger.ErrorNewline("32-bit MACH-O files have not been tested! Please report any issues.");
        else
            LibLogger.WarnNewline("Mach-O Support is experimental. Please open an issue if anything seems incorrect.");

        LibLogger.Verbose("\tReading Mach-O load commands...");
        _loadCommands = ReadReadableArrayAtRawAddr<MachOLoadCommand>(-1, _header.NumLoadCommands);
        LibLogger.VerboseNewline($"Read {_loadCommands.Length} load commands.");

        Segments64 = _loadCommands.Where(c => c.Command == LoadCommandId.LC_SEGMENT_64).Select(c => c.CommandData).Cast<MachOSegmentCommand>().ToArray();
        Sections64 = Segments64.SelectMany(s => s.Sections).ToArray();

        var dyldData = _loadCommands.FirstOrDefault(c => c.Command is LoadCommandId.LC_DYLD_INFO or LoadCommandId.LC_DYLD_INFO_ONLY)?.CommandData as MachODynamicLinkerCommand;
        var exports = dyldData?.Exports ?? [];
        
        _exportAddressesDict = exports.ToDictionary(e => e.Name[1..], e => e.Address); //Skip the first character, which is a leading underscore inserted by the compiler
        _exportNamesDict = new Dictionary<ulong, string>();
        foreach (var export in exports) // there may be duplicate names
        {
            _exportNamesDict[export.Address] = export.Name[1..];
        }

        LibLogger.VerboseNewline($"\tFound {_exportAddressesDict.Count} exports in the DYLD info load command.");
        
        var chainedFixups = _loadCommands.FirstOrDefault(c => c.Command == LoadCommandId.LC_DYLD_CHAINED_FIXUPS)?.CommandData as MachOLinkEditDataCommand;
        if (chainedFixups != null) 
            ApplyChainedFixups(chainedFixups);

        LibLogger.VerboseNewline($"\tMach-O contains {Segments64.Length} segments, split into {Sections64.Length} sections.");

        // AssetRipper: an App Store build's __TEXT is FairPlay ciphertext on disk. Say so here, where
        // it is true, rather than let it surface downstream as "No codegen modules found for
        // mscorlib" - a message about the metadata, which had already loaded perfectly. But do not
        // stop: __DATA is not encrypted, so the registration structs, the field offsets and the
        // instance sizes are all still readable, and everything short of the machine code can be
        // recovered. Only the method bodies are lost. DevXUnity-Unpacker reaches the same place and
        // also warns rather than failing - see reports/IOS_RESEARCH.md.
        Encryption = _loadCommands
            .FirstOrDefault(c => c.Command is LoadCommandId.LC_ENCRYPTION_INFO or LoadCommandId.LC_ENCRYPTION_INFO_64)
            ?.CommandData as MachOEncryptionInfoCommand;

        if (Encryption is { IsEncrypted: true } encryption)
        {
            LibLogger.WarnNewline($"Mach-O is encrypted: LC_ENCRYPTION_INFO names 0x{encryption.CryptSize:X} bytes "
                + $"from file offset 0x{encryption.CryptOffset:X} with cryptid {encryption.CryptId}. That range covers "
                + "__TEXT, so the machine code and the C strings are ciphertext on disk - this is how an App Store "
                + "(FairPlay) build is distributed, and no method body can be recovered from it. __DATA is not "
                + "encrypted, so metadata, the registration structs and field offsets still read. For method bodies, "
                + "supply a build that is not store-encrypted.");
        }

        LibLogger.VerboseNewline("Mach-O file read successfully.");
    }

    public override long RawLength => _raw.Length;
    public override byte GetByteAtRawAddress(ulong addr) => _raw[addr];

    /// <summary>AssetRipper: whether this address falls inside the range <c>LC_ENCRYPTION_INFO</c> names.</summary>
    /// <remarks>
    /// The command names a range of <em>file offsets</em>, so the address has to be mapped before it
    /// can be tested. It is mapped through the segments rather than the sections deliberately:
    /// segments are what carry the file-to-memory mapping, and a byte that lies in a segment but in
    /// none of its sections is still encrypted.
    /// </remarks>
    public override bool IsVirtualAddressEncrypted(ulong virtualAddress)
    {
        if (Encryption is not { IsEncrypted: true } encryption)
            return false;

        foreach (var segment in Segments64)
        {
            if (virtualAddress < segment.VirtualAddress || virtualAddress >= segment.VirtualAddress + segment.VirtualSize)
                continue;

            var offsetIntoSegment = virtualAddress - segment.VirtualAddress;

            if (offsetIntoSegment >= segment.FileSize)
                return false; //Zero-filled, so it is not on disk at all and cannot be ciphertext

            var fileOffset = segment.FileOffset + offsetIntoSegment;

            return fileOffset >= encryption.CryptOffset && fileOffset < encryption.CryptOffset + encryption.CryptSize;
        }

        return false;
    }

    public override long MapVirtualAddressToRaw(ulong uiAddr, bool throwOnError = true)
    {
        var sec = Sections64.FirstOrDefault(s => s.Address <= uiAddr && uiAddr < s.Address + s.Size);

        if (sec == null)
            if (throwOnError)
                throw new($"Could not find section for virtual address 0x{uiAddr:X}. Lowest section address is 0x{Sections64.Min(s => s.Address):X}, highest section address is 0x{Sections64.Max(s => s.Address + s.Size):X}");
            else
                return VirtToRawInvalidNoMatch;

        return (long)(sec.Offset + (uiAddr - sec.Address));
    }

    public override ulong MapRawAddressToVirtual(uint offset, bool throwOnError = true)
    {
        var sec = Sections64.FirstOrDefault(s => s.Offset <= offset && offset < s.Offset + s.Size);

        if (sec == null)
            if (throwOnError)
                throw new($"Could not find section for raw address 0x{offset:X}");
            else
                return 0;

        return sec.Address + (offset - sec.Offset);
    }

    public override ulong GetRva(ulong pointer)
    {
        // Mach-O doesn't have RVAs and instead uses virtual addresses, so we can just return the pointer as-is.
        return pointer;
    }

    public override ReadOnlySpan<byte> GetRawBinaryContent() => _raw;

    public override ulong GetVirtualAddressOfExportedFunctionByName(string toFind)
    {
        if (!_exportAddressesDict.TryGetValue(toFind, out var addr))
            return 0;

        return addr;
    }

    public override bool IsExportedFunction(ulong addr) => _exportNamesDict.ContainsKey(addr);

    public override bool TryGetExportedFunctionName(ulong addr, [NotNullWhen(true)] out string? name)
    {
        return _exportNamesDict.TryGetValue(addr, out name);
    }

    public override IEnumerable<KeyValuePair<string, ulong>> GetExportedFunctions()
    {
        return _exportAddressesDict.Select(pair => new KeyValuePair<string, ulong>(pair.Key, pair.Value));
    }

    private MachOSection GetTextSection64()
    {
        var textSection = Sections64.FirstOrDefault(s => s.SectionName == "__text");

        if (textSection == null)
            throw new("Could not find __text section");

        return textSection;
    }

    public override ReadOnlySpan<byte> GetEntirePrimaryExecutableSection()
    {
        var textSection = GetTextSection64();

        return _raw.AsSpan((int)textSection.Offset, (int)textSection.Size);
    }

    public override ulong GetVirtualAddressOfPrimaryExecutableSection() => GetTextSection64().Address;
    
    /// <summary>
    /// AssetRipper: the address the linker laid this image out at - the <c>__TEXT</c> segment's
    /// <c>vmaddr</c>, which is what <c>DYLD_CHAINED_PTR_64_OFFSET</c> counts its targets from.
    /// </summary>
    /// <remarks>
    /// <c>__PAGEZERO</c> is excluded because it has no file content; a dylib has no <c>__PAGEZERO</c>
    /// and links at zero, which is why the two 64-bit pointer formats look identical on one.
    /// </remarks>
    private ulong PreferredLoadAddress => Segments64
        .FirstOrDefault(s => s.SegmentName == "__TEXT")?.VirtualAddress
        ?? Segments64
            .Where(s => s.FileSize > 0 && s.SegmentName != "__PAGEZERO")
            .Select(s => s.VirtualAddress)
            .DefaultIfEmpty(0ul)
            .Min();

    //Thanks to LukeFZ for this
    private void ApplyChainedFixups(MachOLinkEditDataCommand cmd)
    {
        LibLogger.Verbose("\tApplying chained fixups...");
        var chainedFixupsHeader = ReadReadable<MachODyldChainedFixupsHeader>(cmd.Offset);
        if (chainedFixupsHeader.FixupsVersion != MachODyldChainedFixupsHeader.SupportedFixupsVersion)
        {
            LibLogger.ErrorNewline($"Mach-O: Unsupported fixups version {chainedFixupsHeader.FixupsVersion}, expecting {MachODyldChainedFixupsHeader.SupportedFixupsVersion}");
            return;
        }

        if (chainedFixupsHeader.ImportsFormat != MachODyldChainedFixupsHeader.SupportedImportsFormat)
        {
            LibLogger.ErrorNewline($"Mach-O: Unsupported imports format {chainedFixupsHeader.ImportsFormat}, expecting {MachODyldChainedFixupsHeader.SupportedImportsFormat}");
            return;
        }

        var posBack = Position;
        
        var startsBase = cmd.Offset + chainedFixupsHeader.StartsOffset;
        
        Position = startsBase;
        var segmentCount = ReadUInt32();
        var segmentStartOffsets = ReadClassArrayAtRawAddr<uint>(startsBase + 4, segmentCount);

        Position = posBack;

        var count = 0;
        foreach (var startOffset in segmentStartOffsets)
        {
            if (startOffset == 0)
                continue;
            
            var startsInfo = ReadReadable<MachODyldChainedStartsInSegment>(startsBase + startOffset);
            if (startsInfo.SegmentOffset == 0)
                continue;
            
            var pointerFormat = (MachODyldChainedPtr)startsInfo.PointerFormat;
            var pages = ReadClassArrayAtRawAddr<ushort>(startsBase + startOffset + MachODyldChainedStartsInSegment.Size, startsInfo.PageCount);

            // AssetRipper: DYLD_CHAINED_PTR_64 and DYLD_CHAINED_PTR_64_OFFSET share a struct and
            // differ in exactly one respect - the first format's target is the unslid virtual
            // address, the second's is an offset from the image base. They therefore agree on a
            // dylib, which links at zero, and disagree by the whole image base on an executable.
            // See reports/IOS_TYPE_DEFINITIONS_SIZES_ANALYSIS.md for the specification this comes
            // from; do not collapse the two arms back together because a dylib cannot tell them
            // apart.
            var targetBias = pointerFormat switch
            {
                MachODyldChainedPtr.DYLD_CHAINED_PTR_64 => 0ul,
                MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET => PreferredLoadAddress,
                _ => 0ul,
            };

            for (var i = 0; i < pages.Length; i++)
            {
                var page = pages[i];
                if (page == MachODyldChainedStartsInSegment.DYLD_CHAINED_PTR_START_NONE)
                    continue;

                // AssetRipper: a chain is confined to its page, so the walk has a bound. Without one
                // a `next` that points past the page end runs into the following page's chain and
                // rewrites pointers that were already correct, which is silent.
                var pageStart = startsInfo.SegmentOffset + (ulong)i * startsInfo.PageSize;
                var pageEnd = pageStart + startsInfo.PageSize;
                var chainOffset = pageStart + page;

                while (chainOffset + 8 <= pageEnd)
                {
                    var currentEntry = ReadReadable<MachODyldChainedPtr64Rebase>((long)chainOffset);
                    if (currentEntry.Bind)
                    {
                        //TODO: Bind.
                    }
                    else if (pointerFormat is MachODyldChainedPtr.DYLD_CHAINED_PTR_64 or MachODyldChainedPtr.DYLD_CHAINED_PTR_64_OFFSET)
                    {
                        // Composed first, biased second, which is the order dyld, LLVM and LIEF all
                        // use. It happens to agree with biasing the 36-bit target directly, because
                        // bits 36 to 55 of an unpacked value are empty and no real image base
                        // carries that far - but the spec's order is the one to write down.
                        var unpackedTarget = currentEntry.High8 << 56 | currentEntry.Target;
                        WriteWord((int)chainOffset, unpackedTarget + targetBias);
                        count++;
                    }

                    if (currentEntry.Next == 0)
                        break;
                    chainOffset += currentEntry.Next * 4;
                }
            }
        }
        
        LibLogger.VerboseNewline($"Applied {count} chained fixups.");
    }
}
