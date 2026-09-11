using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using LibCpp2IL.BinaryStructures;
using LibCpp2IL.Logging;
using LibCpp2IL.Metadata;

namespace LibCpp2IL;

public abstract class Il2CppBinary(Stream input) : ClassReadingBinaryReader(input)
{
    public delegate void RegistrationStructLocationFailureHandler(Il2CppBinary binary, Il2CppMetadata metadata, ref Il2CppCodeRegistration? codeReg, ref Il2CppMetadataRegistration? metaReg);

    public static event RegistrationStructLocationFailureHandler? OnRegistrationStructLocationFailure;

    protected const long VirtToRawInvalidNoMatch = long.MinValue + 1000;
    protected const long VirtToRawInvalidOutOfBounds = long.MinValue + 1001;

    public InstructionSetId InstructionSetId = null!;
    public readonly Dictionary<Il2CppMethodDefinition, List<Cpp2IlMethodRef>> ConcreteGenericMethods = new();
    public readonly Dictionary<ulong, List<Cpp2IlMethodRef>> ConcreteGenericImplementationsByAddress = new();
    public ulong[] TypeDefinitionSizePointers = [];

    private long _maxMetadataUsages = 0;

    private Il2CppMetadataRegistration _metadataRegistration = null!;
    private Il2CppCodeRegistration _codeRegistration = null!;

    private ulong[] _methodPointers = [];

    private ulong[] _genericMethodPointers = [];

    // private ulong[] _invokerPointers = Array.Empty<ulong>();
    private ulong[]? _customAttributeGenerators = []; //Pre-27 only
    private long[] _fieldOffsets = [];
    private ulong[] _metadataUsages = []; //Pre-27 only
    private ulong[][] _codeGenModuleMethodPointers = []; //24.2+

    private Il2CppType[] _types = [];
    private Il2CppGenericInst[] _genericInsts = [];
    private Il2CppCodeGenModule[] _codeGenModules = []; //24.2+
    private Il2CppTokenRangePair[][] _codegenModuleRgctxRanges = [];
    private Il2CppRGCTXDefinition[][] _codegenModuleRgctxs = [];

    private Dictionary<string, Il2CppCodeGenModule> _codeGenModulesByName = new(); //24.2+
    private Dictionary<Il2CppVariableWidthIndex<Il2CppMethodDefinition>, ulong> _genericMethodDictionary = new();
    private readonly Dictionary<ulong, Il2CppType> _typesByAddress = new();

    public abstract long RawLength { get; }

    public int PointerSizeBytes => is32Bit ? 4 : 8;

    public int NumTypes => _types.Length;

    public Il2CppType[] AllTypes => _types;

    /// <summary>
    /// Can be overriden if, like the wasm format, your data has to be unpacked and you need to use a different reader
    /// </summary>
    public virtual ClassReadingBinaryReader Reader => this;

    public sealed override float MetadataVersion =>
        _context?.Metadata.MetadataVersion ?? 0;

    public int InBinaryMetadataSize { get; private set; }

    protected LibCpp2IlContext? _context;

    protected override void OnReadableCreated(ReadableClass instance)
    {
        if (_context != null)
            instance.OwningContext = _context;
    }

    public void Init(LibCpp2IlContext context)
    {
        var metadata = context.Metadata ?? throw new InvalidOperationException("The metadata must be initialized before the binary.");
        context.Binary = this;
        _context = context;

        LibLogger.InfoNewline("Searching Binary for Required Data...");

        var start = DateTime.Now;

        var (codereg, metareg) = FindCodeAndMetadataReg(metadata);

        LibLogger.InfoNewline($"Got Binary codereg: 0x{codereg:X}, metareg: 0x{metareg:X} in {(DateTime.Now - start).TotalMilliseconds:F0}ms.");
        LibLogger.InfoNewline("Initializing Binary...");

        start = DateTime.Now;

        Init(codereg, metareg, metadata);

        LibLogger.InfoNewline($"Initialized Binary in {(DateTime.Now - start).TotalMilliseconds:F0}ms");
    }

    public void Init(ulong pCodeRegistration, ulong pMetadataRegistration, Il2CppMetadata metadata)
    {
        // Ensure any derived code that needs max metadata usages can access it without static metadata.
        _maxMetadataUsages = metadata.GetMaxMetadataUsages();

        var cr = pCodeRegistration > 0 ? ReadReadableAtVirtualAddress<Il2CppCodeRegistration>(pCodeRegistration) : null;
        var mr = pMetadataRegistration > 0 ? ReadReadableAtVirtualAddress<Il2CppMetadataRegistration>(pMetadataRegistration) : null;

        if (cr == null || mr == null)
        {
            LibLogger.WarnNewline("At least one of the registration structs was not able to be found. Attempting to use fallback locator delegate to find them (this will fail unless you have a plugin that helps with this!)...");
            OnRegistrationStructLocationFailure?.Invoke(this, metadata, ref cr, ref mr);
            LibLogger.VerboseNewline($"After fallback, code registration is {(cr == null ? "null" : "not null")} and metadata registration is {(mr == null ? "null" : "not null")}." );
        }

        if (cr == null || mr == null)
            throw new("Failed to find code registration or metadata registration!");

        _codeRegistration = cr;
        _metadataRegistration = mr;
        
        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        LibLogger.Verbose("\tReading generic instances...");
        var start = DateTime.Now;
        _genericInsts = Array.ConvertAll(ReadNUintArrayAtVirtualAddress(_metadataRegistration.genericInsts, _metadataRegistration.genericInstsCount), ReadReadableAtVirtualAddress<Il2CppGenericInst>);
        LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        if (_codeRegistration.genericMethodPointers != 0)
        {
            LibLogger.Verbose("\tReading generic method pointers...");
            start = DateTime.Now;
            _genericMethodPointers = ReadNUintArrayAtVirtualAddress(_codeRegistration.genericMethodPointers, (long)_codeRegistration.genericMethodPointersCount);
            LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");
        }
        else
        {
            LibLogger.WarnNewline("\tPointer to generic method array in CodeReg is null! This isn't inherently going to cause dumping to fail but there will be no generic method data in the dump.");
            _genericMethodPointers = [];
        }

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        // These aren't actually used right now, and if we have a limited code reg (e.g. heavily inlined linux games) we can't read them anyway
        // LibLogger.Verbose("\tReading invoker pointers...");
        // start = DateTime.Now;
        // _invokerPointers = ReadNUintArrayAtVirtualAddress(_codeRegistration.invokerPointers, (long)_codeRegistration.invokerPointersCount);
        // LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        if (metadata.MetadataVersion < 27)
        {
            LibLogger.Verbose("\tReading custom attribute generators...");
            start = DateTime.Now;
            _customAttributeGenerators = ReadNUintArrayAtVirtualAddress(_codeRegistration.customAttributeGeneratorListAddress, (long)_codeRegistration.customAttributeCount);
            LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");
        }

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        LibLogger.Verbose("\tReading field offsets...");
        start = DateTime.Now;
        _fieldOffsets = ReadClassArrayAtVirtualAddress<long>(_metadataRegistration.fieldOffsetListAddress, _metadataRegistration.fieldOffsetsCount);
        LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        LibLogger.Verbose("\tReading types...");
        start = DateTime.Now;
        var typePtrs = ReadNUintArrayAtVirtualAddress(_metadataRegistration.typeAddressListAddress, _metadataRegistration.numTypes);
        _types = new Il2CppType[_metadataRegistration.numTypes];
        for (var i = 0; i < _metadataRegistration.numTypes; ++i)
        {
            _types[i] = ReadReadableAtVirtualAddress<Il2CppType>(typePtrs[i]);
            _typesByAddress[typePtrs[i]] = _types[i];
        }

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");

        LibLogger.Verbose("\tReading type definition sizes...");
        start = DateTime.Now;
        TypeDefinitionSizePointers = ReadNUintArrayAtVirtualAddress(_metadataRegistration.typeDefinitionsSizes, _metadataRegistration.typeDefinitionsSizesCount);
        LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        if (_metadataRegistration.metadataUsages != 0)
        {
            //Empty in v27
            LibLogger.Verbose("\tReading metadata usages...");
            start = DateTime.Now;
            _metadataUsages = ReadNUintArrayAtVirtualAddress(_metadataRegistration.metadataUsages, (long)Math.Max((decimal)_metadataRegistration.metadataUsagesCount, _maxMetadataUsages));
            LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");
        }

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        ReportEncryptedRegistrationRegions();

        if (metadata.MetadataVersion >= 24.2f)
        {
            LibLogger.VerboseNewline("\tReading code gen modules...");
            start = DateTime.Now;

            var codeGenModulePtrs = ReadNUintArrayAtVirtualAddress(_codeRegistration.addrCodeGenModulePtrs, (long)_codeRegistration.codeGenModulesCount);
            _codeGenModules = new Il2CppCodeGenModule[codeGenModulePtrs.Length];
            _codeGenModuleMethodPointers = new ulong[codeGenModulePtrs.Length][];
            _codegenModuleRgctxRanges = new Il2CppTokenRangePair[codeGenModulePtrs.Length][];
            _codegenModuleRgctxs = new Il2CppRGCTXDefinition[codeGenModulePtrs.Length][];
            for (var i = 0; i < codeGenModulePtrs.Length; i++)
            {
                var codeGenModule = ReadReadableAtVirtualAddress<Il2CppCodeGenModule>(codeGenModulePtrs[i]);
                _codeGenModules[i] = codeGenModule;
                _codeGenModulesByName[codeGenModule.Name] = codeGenModule;
                var name = codeGenModule.Name;
                LibLogger.VerboseNewline($"\t\t-Read module data for {name}, contains {codeGenModule.methodPointerCount} method pointers starting at 0x{codeGenModule.methodPointers:X}");
                if (codeGenModule.methodPointerCount > 0)
                {
                    try
                    {
                        var ptrs = ReadNUintArrayAtVirtualAddress(codeGenModule.methodPointers, codeGenModule.methodPointerCount);
                        _codeGenModuleMethodPointers[i] = ptrs;
                        LibLogger.VerboseNewline($"\t\t\t-Read {codeGenModule.methodPointerCount} method pointers.");
                    }
                    catch (Exception e)
                    {
                        LibLogger.VerboseNewline($"\t\t\tWARNING: Unable to get function pointers for {name}: {e.Message}");
                        _codeGenModuleMethodPointers[i] = new ulong[codeGenModule.methodPointerCount];
                    }
                }
                else
                {
                    _codeGenModuleMethodPointers[i] = [];
                }

                if (codeGenModule.rgctxRangesCount > 0)
                {
                    try
                    {
                        var ranges = ReadReadableArrayAtVirtualAddress<Il2CppTokenRangePair>(codeGenModule.pRgctxRanges, codeGenModule.rgctxRangesCount);
                        _codegenModuleRgctxRanges[i] = ranges;
                        LibLogger.VerboseNewline($"\t\t\t-Read {codeGenModule.rgctxRangesCount} RGCTX ranges.");
                    }
                    catch (Exception e)
                    {
                        LibLogger.VerboseNewline($"\t\t\tWARNING: Unable to get RGCTX ranges for {name}: {e.Message}");
                        _codegenModuleRgctxRanges[i] = new Il2CppTokenRangePair[codeGenModule.rgctxRangesCount];
                    }
                }
                else
                {
                    _codegenModuleRgctxRanges[i] = [];
                }

                if (codeGenModule.rgctxsCount > 0)
                {
                    try
                    {
                        var rgctxs = ReadReadableArrayAtVirtualAddress<Il2CppRGCTXDefinition>(codeGenModule.rgctxs, codeGenModule.rgctxsCount);
                        _codegenModuleRgctxs[i] = rgctxs;
                        LibLogger.VerboseNewline($"\t\t\t-Read {codeGenModule.rgctxsCount} RGCTXs.");
                    }
                    catch (Exception e)
                    {
                        LibLogger.VerboseNewline($"\t\t\tWARNING: Unable to get RGCTXs for {name}: {e.Message}");
                        _codegenModuleRgctxs[i] = new Il2CppRGCTXDefinition[codeGenModule.rgctxsCount];
                    }
                }
                else
                {
                    _codegenModuleRgctxs[i] = [];
                }
            }

            LibLogger.VerboseNewline($"\tOK ({(DateTime.Now - start).TotalMilliseconds} ms)");
        }
        else
        {
            LibLogger.Verbose("\tReading method pointers...");
            start = DateTime.Now;
            _methodPointers = ReadNUintArrayAtVirtualAddress(_codeRegistration.methodPointers, (long)_codeRegistration.methodPointersCount);
            LibLogger.VerboseNewline($"Read {_methodPointers.Length} OK ({(DateTime.Now - start).TotalMilliseconds} ms)");
        }

        InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

        if (metadata.MetadataVersion < 108)
        {
            //On v108+ these are read from the metadata file instead, by the Il2CppMetadata constructor
            LibLogger.Verbose("\tReading generic method tables...");
            start = DateTime.Now;
            metadata.genericMethodTables = ReadReadableArrayAtVirtualAddress<Il2CppGenericMethodFunctionsDefinitions>(_metadataRegistration.genericMethodTable, _metadataRegistration.genericMethodTableCount);
            LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");

            InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();

            LibLogger.Verbose("\tReading method specifications...");
            start = DateTime.Now;
            metadata.methodSpecs = ReadReadableArrayAtVirtualAddress<Il2CppMethodSpec>(_metadataRegistration.methodSpecs, _metadataRegistration.methodSpecsCount);
            LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");

            InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();
        }

        if (_genericMethodPointers.Length > 0)
        {
            LibLogger.Verbose("\tReading generic methods...");
            start = DateTime.Now;
            _genericMethodDictionary = new();

            var maxAdjustorThunkIndex = metadata.genericMethodTables.Length == 0 ? -1 : metadata.genericMethodTables.Max(t => t.adjustorThunk);

            // AssetRipper: an adjustor thunk index is an index into a table of generic method
            // pointers, so it cannot exceed how many of those there are. A table read out of a
            // region this tool could not actually read - a FairPlay-encrypted __TEXT.__const on an
            // App Store iOS build is the case that found this - gives ciphertext, and the maximum of
            // ciphertext read as int32 is a number in the billions. Allocating on it threw
            // OutOfMemoryException out of initialization, which loses every declaration and every
            // field offset the readable half of the binary would still have given.
            if (maxAdjustorThunkIndex >= _genericMethodPointers.Length)
            {
                LibLogger.WarnNewline($"\tGeneric method table gives a maximum adjustor thunk index of {maxAdjustorThunkIndex}, "
                    + $"but there are only {_genericMethodPointers.Length} generic method pointers. The table this came from "
                    + "could not be read - on an encrypted binary it is ciphertext - so adjustor thunks are being skipped.");
                maxAdjustorThunkIndex = -1;
            }

            var adjustorThunkPointers = _codeRegistration.genericAdjustorThunks != 0 && maxAdjustorThunkIndex >= 0
                ? ReadNUintArrayAtVirtualAddress(_codeRegistration.genericAdjustorThunks, maxAdjustorThunkIndex + 1)
                : [];

            // AssetRipper: an entry of this table indexes the method specs, so an index outside them
            // is not a method this table describes - it is a table that could not be read. On an
            // App Store iOS build the generic method table and the method specs both live in
            // __TEXT.__const, which FairPlay encrypts, so every entry is ciphertext and the first
            // one threw out of initialization - losing every declaration and every field offset the
            // unencrypted half of the binary would still have given. Skipping the unreadable entries
            // is a no-op on a binary that reads, and the count says how many were lost.
            var unreadableEntries = 0;

            foreach (var table in metadata.genericMethodTables)
            {
                var genericMethodIndex = table.GenericMethodIndex;
                var genericMethodPointerIndex = table.methodIndex;

                if (genericMethodIndex < 0 || genericMethodIndex >= metadata.methodSpecs.Length || genericMethodPointerIndex < 0)
                {
                    unreadableEntries++;
                    continue;
                }

                var adjustorThunkPtr = table.adjustorThunk >= 0 && table.adjustorThunk < adjustorThunkPointers.Length
                    ? adjustorThunkPointers[table.adjustorThunk]
                    : 0;

                var methodDefIndex = GetGenericMethodFromIndex(metadata, genericMethodIndex, genericMethodPointerIndex, adjustorThunkPtr);

                if (!_genericMethodDictionary.ContainsKey(methodDefIndex) && genericMethodPointerIndex < _genericMethodPointers.Length)
                {
                    _genericMethodDictionary.TryAdd(methodDefIndex, _genericMethodPointers[genericMethodPointerIndex]);
                }
            }

            if (unreadableEntries > 0)
            {
                LibLogger.WarnNewline($"\t{unreadableEntries} of {metadata.genericMethodTables.Length} generic method table "
                    + "entries index outside the method specs, so that table could not be read - on an encrypted binary it is "
                    + "ciphertext. Generic method bodies from those entries are not mapped.");
            }

            LibLogger.VerboseNewline($"OK ({(DateTime.Now - start).TotalMilliseconds} ms)");
            InBinaryMetadataSize += GetNumBytesReadSinceLastCallAndClear();
        }
        else
        {
            LibLogger.WarnNewline("\tNo generic method pointer data found, skipping generic mapping.");
        }

        _hasFinishedInitialRead = true;
    }

    private Il2CppVariableWidthIndex<Il2CppMethodDefinition> GetGenericMethodFromIndex(Il2CppMetadata metadata, int genericMethodIndex, int genericMethodPointerIndex, ulong adjustorThunkPtr)
    {
        Cpp2IlMethodRef? genericMethodRef;
        var methodSpec = metadata.GetMethodSpec(genericMethodIndex);
        var methodDefIndex = methodSpec.methodDefinitionIndex;
        genericMethodRef = new Cpp2IlMethodRef(methodSpec);
        genericMethodRef.AdjustorThunkPtr = adjustorThunkPtr;

        if (genericMethodPointerIndex >= 0)
        {
            if (genericMethodPointerIndex < _genericMethodPointers.Length)
                genericMethodRef.GenericVariantPtr = _genericMethodPointers[genericMethodPointerIndex];
        }

        if (!ConcreteGenericMethods.ContainsKey(genericMethodRef.BaseMethod))
            ConcreteGenericMethods[genericMethodRef.BaseMethod] = [];

        ConcreteGenericMethods[genericMethodRef.BaseMethod].Add(genericMethodRef);

        if (genericMethodRef.GenericVariantPtr > 0)
        {
            if (!ConcreteGenericImplementationsByAddress.ContainsKey(genericMethodRef.GenericVariantPtr))
                ConcreteGenericImplementationsByAddress[genericMethodRef.GenericVariantPtr] = [];

            ConcreteGenericImplementationsByAddress[genericMethodRef.GenericVariantPtr].Add(genericMethodRef);
        }

        return methodDefIndex;
    }

    /// <summary>
    /// AssetRipper: how many of the per-type field offset tables lie in a region that is ciphertext
    /// on disk, and how many there are.
    /// </summary>
    /// <remarks>
    /// The pointers themselves are in __DATA and read perfectly; on a store-encrypted iOS build the
    /// offsets they address are in __TEXT. A caller that reports a layout mismatch needs to know the
    /// difference between a layout that came out wrong and one that was never legible.
    /// </remarks>
    public (int Encrypted, int Total) CountEncryptedFieldOffsetTables()
    {
        var encrypted = 0;
        var total = 0;

        foreach (var pointer in _fieldOffsets)
        {
            if (pointer <= 0)
                continue;

            total++;

            if (IsVirtualAddressEncrypted((ulong)pointer))
                encrypted++;
        }

        return (encrypted, total);
    }

    /// <summary>
    /// AssetRipper: says which of the registration's tables, and which of the structs they point to,
    /// sit in a region that is ciphertext on disk.
    /// </summary>
    /// <remarks>
    /// A store-encrypted iOS build reads its registration perfectly and then hands out ciphertext,
    /// because the tables are in __DATA and the structs they address are in __TEXT.__const. Stating
    /// that here, in one place and per table, is what stops it surfacing later as an implausible
    /// number - and it is the only way to tell a wrong registration candidate from a right one whose
    /// payload cannot be read. Silent on every platform that cannot encrypt.
    /// </remarks>
    private void ReportEncryptedRegistrationRegions()
    {
        if (!IsVirtualAddressEncrypted(_metadataRegistration.typeDefinitionsSizes)
            && !IsVirtualAddressEncrypted(_codeRegistration.addrCodeGenModulePtrs)
            && TypeDefinitionSizePointers.Length > 0
            && !IsVirtualAddressEncrypted(TypeDefinitionSizePointers[0])
            && (_types.Length == 0 || _typesByAddress.Keys.All(a => !IsVirtualAddressEncrypted(a))))
            return; //Nothing encrypted, or a format that cannot be

        LibLogger.WarnNewline("Some of the il2cpp registration lies in a region that is encrypted on disk. Per table:");

        void Report(string name, ulong tableAddress, IEnumerable<ulong>? targets)
        {
            var tableState = IsVirtualAddressEncrypted(tableAddress) ? "ENCRYPTED" : "readable";
            var targetList = targets?.ToArray();
            var targetState = targetList is null or { Length: 0 }
                ? "n/a"
                : $"{targetList.Count(IsVirtualAddressEncrypted)} of {targetList.Length} ENCRYPTED";

            LibLogger.WarnNewline($"\t{name,-24} table 0x{tableAddress:X} {tableState}, targets {targetState}");
        }

        Report("genericClasses", _metadataRegistration.genericClasses, null);
        Report("genericInsts", _metadataRegistration.genericInsts, null);
        Report("genericMethodTable", _metadataRegistration.genericMethodTable, null);
        Report("types", _metadataRegistration.typeAddressListAddress, _typesByAddress.Keys);
        Report("methodSpecs", _metadataRegistration.methodSpecs, null);
        Report("fieldOffsets", _metadataRegistration.fieldOffsetListAddress, null);
        Report("typeDefinitionsSizes", _metadataRegistration.typeDefinitionsSizes, TypeDefinitionSizePointers);
        Report("codeGenModules", _codeRegistration.addrCodeGenModulePtrs, null);

        LibLogger.WarnNewline("\tA readable table whose targets are encrypted is not a wrong registration - the "
            + "pointers are right and the structs they name cannot be read. Type sizes and method bodies are lost; "
            + "declarations are not.");
    }

    public abstract byte GetByteAtRawAddress(ulong addr);

    /// <summary>
    /// AssetRipper: whether the bytes at <paramref name="virtualAddress"/> are ciphertext on disk.
    /// </summary>
    /// <remarks>
    /// This is a question about a region, not about a file. An App Store iOS build encrypts exactly
    /// one file-offset range - in practice the whole of __TEXT - and leaves __DATA alone, so the
    /// registration structs, the type table and every pointer table read perfectly while the structs
    /// those tables point *into* do not. Asking per address is what lets a reader say "this datum was
    /// never readable" instead of handing ciphertext on as a number. Formats that cannot be encrypted
    /// answer false.
    /// </remarks>
    public virtual bool IsVirtualAddressEncrypted(ulong virtualAddress) => false;

    public abstract long MapVirtualAddressToRaw(ulong uiAddr, bool throwOnError = true);
    public abstract ulong MapRawAddressToVirtual(uint offset, bool throwOnError = true);
    public abstract ulong GetRva(ulong pointer);

    public bool TryMapRawAddressToVirtual(in uint offset, out ulong va)
    {
        va = MapRawAddressToVirtual(offset, false);
        return va != 0;
    }

    public bool TryMapVirtualAddressToRaw(ulong virtAddr, out long result)
    {
        result = MapVirtualAddressToRaw(virtAddr, false);

        // Negative results indicate error codes
        if (result >= 0)
            return true;

        result = 0;
        return false;
    }

    public T[] ReadClassArrayAtVirtualAddress<T>(ulong addr, long count) where T : new() => Reader.ReadClassArrayAtRawAddr<T>(MapVirtualAddressToRaw(addr), count);

    public T[] ReadReadableArrayAtVirtualAddress<T>(ulong va, long count) where T : ReadableClass, new() => Reader.ReadReadableArrayAtRawAddr<T>(MapVirtualAddressToRaw(va), count);

    public T ReadReadableAtVirtualAddress<T>(ulong va) where T : ReadableClass, new() => Reader.ReadReadable<T>(MapVirtualAddressToRaw(va));

    public ulong[] ReadNUintArrayAtVirtualAddress(ulong addr, long count) => Reader.ReadNUintArrayAtRawAddress(MapVirtualAddressToRaw(addr), (int)count);

    public override long ReadNInt() => is32Bit ? Reader.ReadInt32() : Reader.ReadInt64();

    public override ulong ReadNUint() => is32Bit ? Reader.ReadUInt32() : Reader.ReadUInt64();

    public ulong ReadPointerAtVirtualAddress(ulong addr)
    {
        return Reader.ReadNUintAtRawAddress(MapVirtualAddressToRaw(addr));
    }

    public Il2CppGenericInst GetGenericInst(Il2CppVariableWidthIndex<Il2CppGenericInst> index) => _genericInsts[index.Value];

    public Il2CppType GetType(Il2CppVariableWidthIndex<Il2CppType> index) => _types[index.Value];
    public ulong GetRawMetadataUsage(uint index) => _metadataUsages[index];
    public ulong[] GetCodegenModuleMethodPointers(int codegenModuleIndex) => _codeGenModuleMethodPointers[codegenModuleIndex];
    // AssetRipper: the return is already nullable, but indexing threw on a miss. A codegen module's
    // name is a C string in a read-only section, so on a FairPlay-encrypted iOS build every name is
    // ciphertext and no lookup can succeed - which threw out of initialization and cost every
    // declaration and every field offset the unencrypted half of the binary still had. A miss means
    // the method pointer is unknown, not that nothing can be recovered.
    public Il2CppCodeGenModule? GetCodegenModuleByName(string name) => _codeGenModulesByName.GetValueOrDefault(name);
    public int GetCodegenModuleIndex(Il2CppCodeGenModule module) => Array.IndexOf(_codeGenModules, module);
    public int GetCodegenModuleIndexByName(string name) => GetCodegenModuleByName(name) is { } module ? GetCodegenModuleIndex(module) : -1;
    public Il2CppTokenRangePair[] GetRgctxRangePairsForModule(Il2CppCodeGenModule module) => _codegenModuleRgctxRanges[GetCodegenModuleIndex(module)];
    public Il2CppRGCTXDefinition[] GetRgctxDataForPair(Il2CppCodeGenModule module, Il2CppTokenRangePair rangePair) => _codegenModuleRgctxs[GetCodegenModuleIndex(module)].Skip(rangePair.start).Take(rangePair.length).ToArray();

    public Il2CppType GetIl2CppTypeFromPointer(ulong pointer)
        => _typesByAddress[pointer];

    public int GetFieldOffsetFromIndex(Il2CppVariableWidthIndex<Il2CppTypeDefinition> typeIndex, int fieldIndexInType, Il2CppVariableWidthIndex<Il2CppFieldDefinition> fieldIndex, bool isValueType, bool isStatic)
    {
        try
        {
            var offset = -1;
            if (MetadataVersion > 21)
            {
                var ptr = (ulong)_fieldOffsets[typeIndex.Value];

                // AssetRipper: the pointer is in __DATA and reads fine; on a store-encrypted iOS
                // build the offsets it addresses are in __TEXT and are ciphertext. -1 is this
                // method's own "not known", and not knowing is the truth here - reading the bytes
                // anyway lays every field of the type out at a random offset and nothing downstream
                // can tell. Provenance decides this, not how plausible the number looks.
                if (ptr > 0 && !IsVirtualAddressEncrypted(ptr))
                {
                    var offsetOffset = (ulong)MapVirtualAddressToRaw(ptr) + 4ul * (ulong)fieldIndexInType;
                    GetLockOrThrow();
                    try
                    {
                        Position = (long)offsetOffset;
                        offset = (int)ReadPrimitive(typeof(int))!; //Read 4 bytes. We can't just use ReadInt32 because that breaks e.g. Wasm. Hoping the JIT can optimize this as it knows the type.
                    }
                    finally
                    {
                        ReleaseLock();
                    }
                }
            }
            else
            {
                offset = (int)_fieldOffsets[fieldIndex.Value];
            }

            if (offset > 0)
            {
                if (isValueType && !isStatic)
                {
                    if (is32Bit)
                    {
                        offset -= 8;
                    }
                    else
                    {
                        offset -= 16;
                    }
                }
            }

            return offset;
        }
        catch
        {
            return -1;
        }
    }

    public ulong GetMethodPointer(int methodIndex, Il2CppVariableWidthIndex<Il2CppMethodDefinition> methodDefinitionIndex, int imageIndex, uint methodToken)
    {
        if (MetadataVersion >= 24.2f)
        {
            if (_genericMethodDictionary.TryGetValue(methodDefinitionIndex, out var methodPointer))
            {
                return methodPointer;
            }

            // AssetRipper: zero means "this method's body address is not known", which is the honest
            // answer when the codegen module could not be identified - its name is a C string in a
            // read-only section, and on a FairPlay-encrypted iOS build that section is ciphertext.
            // Throwing here cost every declaration in the assembly, and the declarations come from
            // the metadata, which read perfectly.
            if (imageIndex < 0 || imageIndex >= _codeGenModuleMethodPointers.Length)
                return 0;

            var ptrs = _codeGenModuleMethodPointers[imageIndex];
            var methodPointerIndex = methodToken & 0x00FFFFFFu;

            if (methodPointerIndex == 0 || methodPointerIndex > ptrs.Length)
                return 0;

            return ptrs[methodPointerIndex - 1];
        }
        else
        {
            if (methodIndex >= 0)
            {
                return _methodPointers[methodIndex];
            }

            _genericMethodDictionary.TryGetValue(methodDefinitionIndex, out var methodPointer);
            return methodPointer;
        }
    }

    public ulong GetCustomAttributeGenerator(int index) => _customAttributeGenerators![index];

    public ulong[] AllCustomAttributeGenerators => MetadataVersion >= 29 ? [] : MetadataVersion >= 27 ? AllCustomAttributeGeneratorsV27 : _customAttributeGenerators!;

    private ulong[] AllCustomAttributeGeneratorsV27 =>
        (_context?.Metadata ?? throw new InvalidOperationException("Binary not initialized"))
            .imageDefinitions
            .Select(i => (image: i, cgm: GetCodegenModuleByName(i.Name!)!))
            .SelectMany(tuple => LibCpp2ILUtils.Range(0, (int)tuple.image.customAttributeCount).Select(o => tuple.cgm.customAttributeCacheGenerator + (ulong)o * PointerSize))
            .Select(ReadPointerAtVirtualAddress)
            .ToArray();

    public abstract ReadOnlySpan<byte> GetRawBinaryContent();
    public abstract ulong GetVirtualAddressOfExportedFunctionByName(string toFind);
    public virtual bool IsExportedFunction(ulong addr) => false;

    public virtual bool TryGetExportedFunctionName(ulong addr, [NotNullWhen(true)] out string? name)
    {
        name = null;
        return false;
    }

    public virtual IEnumerable<KeyValuePair<string, ulong>> GetExportedFunctions() => [];

    public abstract ReadOnlySpan<byte> GetEntirePrimaryExecutableSection();

    public abstract ulong GetVirtualAddressOfPrimaryExecutableSection();

    /// <summary>
    /// AssetRipper: every executable region of the binary, virtual address first.
    /// </summary>
    /// <remarks>
    /// An il2cpp .so puts the runtime in <c>.text</c> and the generated method bodies in a section of
    /// its own, called <c>il2cpp</c>. Anything counting how often a runtime helper is called has to
    /// look at both, because every one of those calls is in the second.
    /// </remarks>
    public virtual IEnumerable<(ulong VirtualAddress, ReadOnlyMemory<byte> Data)> GetExecutableSections()
    {
        var primary = GetEntirePrimaryExecutableSection();

        return primary.Length > 0
            ? [(GetVirtualAddressOfPrimaryExecutableSection(), (ReadOnlyMemory<byte>)primary.ToArray())]
            : [];
    }

    public virtual (ulong pCodeRegistration, ulong pMetadataRegistration) FindCodeAndMetadataReg(Il2CppMetadata metadata)
    {
        if (MetadataVersion == 0)
            throw new InvalidOperationException("MetadataVersion must be set before searching for code and metadata registration.");

        LibLogger.VerboseNewline("\tAttempting to locate code and metadata registration functions...");

        var methodCount = metadata.methodDefs.Count(x => x.methodIndex >= 0);
        var typeDefinitionsCount = metadata.TypeDefinitionCount;

        var plusSearch = new BinarySearcher(this, metadata, methodCount, typeDefinitionsCount);

        LibLogger.VerboseNewline("\t\t-Searching for MetadataReg...");

        var pMetadataRegistration = metadata.MetadataVersion < 24.5f
            ? plusSearch.FindMetadataRegistrationPre24_5()
            : plusSearch.FindMetadataRegistrationPost24_5();

        LibLogger.VerboseNewline("\t\t-Searching for CodeReg...");

        ulong pCodeRegistration;
        if (metadata.MetadataVersion >= 24.2f)
        {
            LibLogger.VerboseNewline("\t\t\tUsing mscorlib full-disassembly approach to get codereg, this may take a while...");
            pCodeRegistration = plusSearch.FindCodeRegistrationPost2019();

            // AssetRipper: the route above needs the codegen module names, which are C strings in a
            // read-only section. An App Store iOS build has that section encrypted while its data
            // section is not, so fall back to finding the struct by the one count in it the metadata
            // already tells us. See BinarySearcher.FindCodeRegistrationByModuleCount.
            if (pCodeRegistration == 0)
            {
                LibLogger.VerboseNewline("\t\t\tThat found nothing; trying the module count instead...");
                pCodeRegistration = plusSearch.FindCodeRegistrationByModuleCount();
            }
        }
        else
            pCodeRegistration = plusSearch.FindCodeRegistrationPre2019();

        if (pCodeRegistration == 0 && LibCpp2IlMain.Settings.AllowManualMetadataAndCodeRegInput)
        {
            LibLogger.Info("Couldn't identify a CodeRegistration address. If you know it, enter it now, otherwise enter nothing or zero to fail: ");
            var crInput = Console.ReadLine();
            ulong.TryParse(crInput, NumberStyles.HexNumber, null, out pCodeRegistration);
        }

        if (pMetadataRegistration == 0 && LibCpp2IlMain.Settings.AllowManualMetadataAndCodeRegInput)
        {
            LibLogger.Info("Couldn't identify a MetadataRegistration address. If you know it, enter it now, otherwise enter nothing or zero to fail: ");
            var mrInput = Console.ReadLine();
            ulong.TryParse(mrInput, NumberStyles.HexNumber, null, out pMetadataRegistration);
        }

        return (pCodeRegistration, pMetadataRegistration);
    }
}
