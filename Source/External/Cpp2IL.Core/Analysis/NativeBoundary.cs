using System;
using System.Collections.Generic;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: which side of the managed/native line a call target is on, and whose code it is.
/// </summary>
/// <remarks>
/// <para>
/// A call the analysis could not name reaches the generator as one placeholder however it got there,
/// and the causes behind it want opposite work. A managed method the model could not choose between
/// is a recovery defect. A function in another shared library is an external dependency that no
/// amount of decompiling makes managed. An il2cpp runtime helper is a boundary that has to be
/// <em>represented</em> rather than translated - inventing a C# body for one would be fabricating
/// behaviour. Counting them together says none of that, and treating them alike is how a native
/// boundary ends up written out as managed code that lies.
/// </para>
/// <para>
/// Every verdict is read off evidence the binary carries: a relocation that names the imported
/// symbol, a key function the runtime discovery located, how many managed methods sit on the
/// address, or an instruction sequence recognised for what it does. Where none of those answers, the
/// answer is <see cref="Unknown"/> - which is a verdict, not a failure, and must not be counted as
/// recovered.
/// </para>
/// </remarks>
public static class NativeBoundary
{
    /// <summary>A managed method: the model knows it, or knows several and could not choose.</summary>
    public const string Managed = "MANAGED";

    /// <summary>The il2cpp runtime itself - a codegen helper, a veneer, or an intrinsic.</summary>
    public const string Il2CppRuntime = "IL2CPP_RUNTIME";

    /// <summary>Unity's own native player.</summary>
    public const string UnityEngine = "UNITY_ENGINE";

    /// <summary>A function in some other shared library the game ships.</summary>
    public const string NativePlugin = "NATIVE_PLUGIN";

    /// <summary>The C library, the C++ ABI, or the platform's own API.</summary>
    public const string SystemApi = "SYSTEM_API";

    /// <summary>
    /// A managed P/Invoke wrapper's outbound call.
    /// </summary>
    /// <remarks>
    /// Declared because the taxonomy is part of what this reports, and deliberately never produced:
    /// nothing at a call site distinguishes a P/Invoke's target from any other imported symbol, and a
    /// verdict that cannot be evidenced is worse than one that is absent. It is here so that a later
    /// rule with real evidence - the wrapper's own <c>DllImport</c>, reached from the call - has a
    /// name to use rather than inventing one.
    /// </remarks>
    public const string PInvoke = "P_INVOKE";

    /// <summary>Resolved to a symbol, but to nothing this can place.</summary>
    public const string ExternalDependency = "EXTERNAL_DEPENDENCY";

    /// <summary>No evidence says what this is.</summary>
    public const string Unknown = "UNKNOWN";

    /// <summary>What a call target is, and the symbol naming it where one is known.</summary>
    public readonly record struct Verdict(string Kind, string? Symbol)
    {
        public override string ToString() => Symbol is null ? Kind : Kind + ":" + Symbol;
    }

    /// <summary>
    /// Classifies the target of a call that nothing resolved.
    /// </summary>
    /// <param name="appContext">The game, for the relocations, the key functions and the address map.</param>
    /// <param name="address">The address the call names.</param>
    public static Verdict Of(ApplicationAnalysisContext appContext, ulong address) => Of(appContext, address, 0);

    private static Verdict Of(ApplicationAnalysisContext appContext, ulong address, int depth)
    {
        if (address == 0)
        {
            return new Verdict(Unknown, null);
        }

        // A relocation naming the symbol is the strongest evidence there is: it is what the dynamic
        // linker itself will use, so it says both that the target is outside this binary and what it
        // is called.
        if (ImportedSymbol(appContext, address) is { } import)
        {
            return new Verdict(KindOfSymbol(import), import);
        }

        // Inside this binary. A managed method sitting here makes it managed whether or not the model
        // could choose between several.
        if (appContext.MethodsByAddress.TryGetValue(address, out var managed) && managed.Count > 0)
        {
            return new Verdict(Managed, managed.Count == 1 ? managed[0].FullName : null);
        }

        if (KeyFunctionNameAt(appContext, address) is { } keyFunction)
        {
            return new Verdict(Il2CppRuntime, keyFunction);
        }

        if (AtomicShapeAt(appContext, address) is { } atomic)
        {
            return new Verdict(Il2CppRuntime, atomic);
        }

        // A veneer is not the boundary, it is the way to it: a table of one-word branches sits
        // between the runtime and the generated code, and every call to a helper goes through one.
        // Classifying the stub says nothing, so take the hop and classify what it reaches - and only
        // once, because a verdict about a veneer's veneer would be a guess about the layout of a
        // table rather than about a function.
        if (depth == 0)
        {
            var target = appContext.InstructionSet.GetThunkTarget(appContext, address);

            if (target != 0 && target != address)
            {
                var beyond = Of(appContext, target, depth + 1);

                if (beyond.Kind != Unknown)
                {
                    return beyond;
                }
            }
        }

        return new Verdict(Unknown, null);
    }

    /// <summary>The symbol a procedure linkage table entry imports, when the target is one.</summary>
    private static string? ImportedSymbol(ApplicationAnalysisContext appContext, ulong address)
    {
        if (appContext.Binary is not LibCpp2IL.Elf.ElfFile elf)
        {
            return null;
        }

        var slot = appContext.InstructionSet.GetPltGotSlot(appContext, address);

        return slot != 0 && elf.TryGetPltImportName(slot, out var import) ? import : null;
    }

    /// <summary>
    /// Whose symbol this is, by the naming conventions each side actually uses.
    /// </summary>
    /// <remarks>
    /// The relocation names the symbol but not the library it will bind to - <c>DT_NEEDED</c> lists
    /// the libraries for the image, not per symbol - so the name is the evidence available. il2cpp
    /// and Unity both prefix their exports; the C library, the C++ ABI and the pthread API are
    /// recognisable families; and a mangled C++ symbol belongs to whoever compiled it, which is a
    /// plugin far more often than it is the platform.
    /// </remarks>
    public static string KindOfSymbol(string symbol)
    {
        if (symbol.StartsWith("il2cpp_", StringComparison.Ordinal))
        {
            return Il2CppRuntime;
        }

        if (symbol.StartsWith("UnityEngine", StringComparison.Ordinal)
            || symbol.StartsWith("Unity", StringComparison.Ordinal)
            || symbol.StartsWith("unity_", StringComparison.Ordinal))
        {
            return UnityEngine;
        }

        if (IsSystemSymbol(symbol))
        {
            return SystemApi;
        }

        // A mangled C++ name is somebody's compiled code rather than a C API, and the only compiled
        // code here that is not the runtime or the player is what the game shipped with it.
        return symbol.StartsWith("_Z", StringComparison.Ordinal) ? NativePlugin : ExternalDependency;
    }

    /// <summary>
    /// Whether a symbol belongs to the C library, the C++ ABI, the threading API or the platform.
    /// </summary>
    /// <remarks>
    /// Written as families rather than as a list of every function, because the point is to separate
    /// "the platform provides this" from "the game shipped this" and a family does that where an
    /// enumeration would go stale. A name that matches none of them is not asserted to be a plugin
    /// for that reason alone - it falls to <see cref="ExternalDependency"/>, which says only that the
    /// symbol was resolved and not placed.
    /// </remarks>
    private static bool IsSystemSymbol(string symbol)
    {
        foreach (var prefix in SystemPrefixes)
        {
            if (symbol.StartsWith(prefix, StringComparison.Ordinal))
            {
                return true;
            }
        }

        return CLibraryFunctions.Contains(symbol);
    }

    private static readonly string[] SystemPrefixes =
    [
        "__cxa_", "__gxx_", "_Unwind_", "__android_", "__aeabi_", "__errno", "__stack_chk",
        "pthread_", "sem_", "dl", "sig", "clock_", "gettime", "nano", "sys", "abort", "raise",
        "j_", "A", // ARM EABI helpers and Android's own.
    ];

    /// <summary>
    /// The C and C++ library functions an il2cpp binary actually imports, by name.
    /// </summary>
    /// <remarks>
    /// These have no prefix to key on, so they are named. The list covers what generated code calls -
    /// memory, string and math - rather than everything libc exports; a name not here is reported as
    /// resolved-but-unplaced rather than guessed into a family.
    /// </remarks>
    private static readonly HashSet<string> CLibraryFunctions =
    [
        "malloc", "calloc", "realloc", "free", "memcpy", "memmove", "memset", "memcmp", "memchr",
        "strlen", "strcmp", "strncmp", "strcpy", "strncpy", "strcat", "strchr", "strstr", "strdup",
        "snprintf", "sprintf", "vsnprintf", "printf", "fprintf", "puts", "putchar",
        "fopen", "fclose", "fread", "fwrite", "fseek", "ftell", "fflush", "open", "close", "read", "write",
        "sin", "sinf", "cos", "cosf", "tan", "tanf", "asin", "asinf", "acos", "acosf",
        "atan", "atanf", "atan2", "atan2f", "exp", "expf", "log", "logf", "log2", "log2f", "log10", "log10f",
        "pow", "powf", "sqrt", "sqrtf", "fmod", "fmodf", "floor", "floorf", "ceil", "ceilf",
        "round", "roundf", "trunc", "truncf", "fabs", "fabsf", "ldexp", "frexp", "modf",
        "qsort", "bsearch", "rand", "srand", "time", "getenv", "exit", "atoi", "atof", "strtol", "strtod",
        "isnan", "isinf", "gettimeofday", "usleep", "mmap", "munmap", "mprotect",
        // Not a standard C name but a libm one every Android toolchain provides, and calling it a
        // plugin's symbol would say the game shipped it.
        "sincos", "sincosf", "hypot", "hypotf", "cbrt", "cbrtf", "sinh", "cosh", "tanh",
        "sinhf", "coshf", "tanhf", "asinh", "acosh", "atanh", "expm1", "log1p", "remainder", "fma",
    ];

    /// <summary>The name of the located key function sitting at an address, if one does.</summary>
    private static string? KeyFunctionNameAt(ApplicationAnalysisContext appContext, ulong address)
    {
        var keyFunctions = appContext.GetOrCreateKeyFunctionAddresses();

        foreach (var field in keyFunctions.GetType().GetFields())
        {
            if (field.FieldType == typeof(ulong) && field.GetValue(keyFunctions) is ulong located && located == address)
            {
                return field.Name;
            }
        }

        return null;
    }

    /// <summary>
    /// The name of the atomic operation the code at an address performs, when it performs one.
    /// </summary>
    /// <remarks>
    /// A compare-and-swap loop is the runtime's, however it got there and whatever address it is at -
    /// which is the whole point of naming it by its instructions. The recogniser is the one iteration
    /// 051 built and tested; this is the second place its answer is used.
    /// </remarks>
    private static string? AtomicShapeAt(ApplicationAnalysisContext appContext, ulong address)
    {
        try
        {
            var offset = appContext.Binary.MapVirtualAddressToRaw(address);

            if (offset <= 0)
            {
                return null;
            }

            var content = appContext.Binary.GetRawBinaryContent();
            var window = Math.Min(AtomicIntrinsicRecognizer.WindowInstructions * 4, content.Length - (int)offset);

            if (window <= 0)
            {
                return null;
            }

            return AtomicIntrinsicRecognizer.Classify(content.Slice((int)offset, window)) switch
            {
                AtomicIntrinsicRecognizer.Shape.CompareExchange => "AtomicCompareExchange",
                AtomicIntrinsicRecognizer.Shape.ExchangeWithoutComparison => "AtomicExchange",
                _ => null,
            };
        }
        catch (Exception)
        {
            // An address that cannot be mapped or read says nothing about what is there.
            return null;
        }
    }
}
