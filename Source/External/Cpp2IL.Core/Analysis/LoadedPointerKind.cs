using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: what a function pointer that was loaded out of memory actually is, named by where
/// the pointer it was loaded through came from.
/// </summary>
/// <remarks>
/// <para>
/// A call through a pointer read out of memory reaches the generator as one placeholder however the
/// pointer got there, and "loaded pointer" is a symptom rather than a cause - this project has had
/// to split four families named after their symptom, every one of which turned out to be several
/// unrelated causes with nothing to do about them in common. The ones behind this label want
/// opposite work: a slot of the runtime's own <c>MethodInfo</c> is a direct call, an entry of a
/// vtable needs the dispatch tables, a delegate's <c>invoke_impl</c> is a call this pipeline already
/// resolves, and a pointer that came out of a call into another shared library is an external
/// dependency that no amount of work makes managed.
/// </para>
/// <para>
/// So the question is not what the load looks like - it is what produced the pointer the load reads
/// through, which is <see cref="PointerProvenance"/>'s job, and what the offset means once that is
/// known. Nothing here rewrites an instruction: it is a measurement, and it stops at the evidence
/// rather than guessing past it. A producer the walk cannot settle on is reported as that, with the
/// reason, because the split between "several producers disagree" and "no rule for this opcode" is
/// exactly what says whether a rule is missing or whether there is nothing to say.
/// </para>
/// </remarks>
public static class LoadedPointerKind
{
    /// <summary>The pointer is a slot of a runtime <c>MethodInfo</c>, named by which slot.</summary>
    public const string MethodPointer = "METHOD_POINTER";

    public const string VirtualMethodPointer = "VIRTUAL_METHOD_POINTER";

    public const string InvokerPointer = "INVOKER_POINTER";

    /// <summary>An entry of a class's virtual dispatch table.</summary>
    public const string VtablePointer = "VTABLE_POINTER";

    /// <summary>A member of the runtime's <c>Il2CppClass</c> that is not the vtable.</summary>
    public const string Il2CppClassPointer = "IL2CPP_CLASS_POINTER";

    /// <summary>A delegate's own call slot.</summary>
    public const string DelegatePointer = "DELEGATE_POINTER";

    /// <summary>Read out of a managed field, which names it.</summary>
    public const string FieldPointer = "FIELD_POINTER";

    /// <summary>Read out of an array's data.</summary>
    public const string ArrayDataPointer = "ARRAY_DATA_POINTER";

    /// <summary>A member of some other runtime structure - the generic context table, static storage.</summary>
    public const string RuntimeStructPointer = "RUNTIME_STRUCT_POINTER";

    /// <summary>
    /// The pointer came back from a call the analysis could not name, so it is whatever that callee
    /// decided - a runtime boundary rather than a type-recovery failure.
    /// </summary>
    public const string NativePointer = "NATIVE_POINTER";

    /// <summary>Read out of this method's own frame.</summary>
    public const string StackPointer = "STACK_POINTER";

    public const string Unknown = "UNKNOWN";

    /// <summary>
    /// Which kind of pointer an indirect call reads its target from.
    /// </summary>
    /// <param name="load">The memory operand the target is read from.</param>
    /// <param name="definitions">Every definition of a local, for walking the base back.</param>
    /// <param name="fromType">
    /// What a typed base means, which is the only part of this that needs metadata behind it - the
    /// vtable's offset and the three <c>MethodInfo</c> pointers both come out of measured tables.
    /// Kept as a parameter so the walk can be tested without a game behind it, the same way
    /// <see cref="NestedFieldResolver"/> is.
    /// </param>
    public static string Of(
        MemoryOperand load,
        System.Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
        System.Func<TypeAnalysisContext, long, string?> fromType)
        => Of(load, definitions, fromType, 0);

    /// <summary>
    /// How far a chain of loads through loads is followed before the answer is unknown.
    /// </summary>
    /// <remarks>
    /// A pointer read through a pointer read through a pointer is the ordinary shape of reaching the
    /// runtime's structures - an object's class, then its vtable - so one level is not enough, and
    /// the chain has to end somewhere for the same reason every other walk in this file has a limit.
    /// </remarks>
    public const int DepthLimit = 8;

    private static string Of(
        MemoryOperand load,
        System.Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
        System.Func<TypeAnalysisContext, long, string?> fromType,
        int depth)
    {
        if (depth > DepthLimit)
        {
            return Unknown + ":DEPTH";
        }

        if (load.Base is not LocalVariable baseLocal)
        {
            // No base at all is an absolute address, which is a constant rather than a pointer that
            // was loaded - and one that names no managed target is native.
            return load.Index is null && load.Scale == 0 ? NativePointer : Unknown;
        }

        // What the local is in its own right outranks what defined it, the same order
        // BasePointerOrigin uses: a typed base is evidence that survives every copy.
        if (baseLocal.Type is { } type && fromType(type, load.Addend) is { } typed)
        {
            return typed;
        }

        Instruction? producer = PointerProvenance.Producer(baseLocal, definitions);

        if (producer is null)
        {
            return definitions(baseLocal).Count switch
            {
                0 => Unknown + ":ENTRY_VALUE",
                1 => Unknown + ":UNSETTLED",
                _ => Unknown + ":PRODUCERS_DISAGREE",
            };
        }

        return FromProducer(producer, load.Addend, definitions, fromType, depth) ?? Unknown + ":PRODUCED_BY_" + producer.OpCode;
    }

    /// <summary>
    /// What a base's own type says, when it has one - the metadata half, supplied to the walk.
    /// </summary>
    public static string? FromType(TypeAnalysisContext type, long addend, MethodAnalysisContext method)
    {
        if (type is RuntimeMethodInfoAnalysisContext)
        {
            return MethodInfoSlot(addend, method.AppContext.Binary.is32Bit);
        }

        if (type is RuntimeClassTypeAnalysisContext)
        {
            long vtable = (long)Il2CppClassUsefulOffsets.GetVtableOffset(method.AppContext.MetadataVersion, method.AppContext.Binary.is32Bit);

            return addend >= vtable ? VtablePointer : Il2CppClassPointer;
        }

        if (type is StaticFieldStorageTypeAnalysisContext or RgctxTableTypeAnalysisContext or MethodRgctxTableTypeAnalysisContext)
        {
            return RuntimeStructPointer;
        }

        return type.IsDelegate ? DelegatePointer : null;
    }

    /// <summary>Which of the three function pointers a <c>MethodInfo</c> offset names.</summary>
    /// <remarks>
    /// Read from the measured table, never written down: 2022 inserted <c>virtualMethodPointer</c>
    /// as the second field, so the same offset names a different one of the three either side of it.
    /// </remarks>
    private static string MethodInfoSlot(long addend, bool is32Bit)
    {
        if (Named("methodPointer", MethodPointer) is { } first) return first;
        if (Named("virtualMethodPointer", VirtualMethodPointer) is { } second) return second;
        if (Named("invoker_method", InvokerPointer) is { } third) return third;

        return RuntimeStructPointer;

        string? Named(string field, string kind)
            => Il2CppMethodInfoUsefulOffsets.TryGetOffset(field, is32Bit, out long offset) && offset == addend ? kind : null;
    }

    /// <summary>What the instruction that produced the base says.</summary>
    private static string? FromProducer(
        Instruction producer,
        long addend,
        System.Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
        System.Func<TypeAnalysisContext, long, string?> fromType,
        int depth)
    {
        if (producer.OpCode is OpCode.Call or OpCode.CallVoid or OpCode.IndirectCall)
        {
            // A resolved call has a return type, which would have typed the base and been answered
            // above. So reaching here means the callee is unknown, and what it points into is its
            // business rather than this method's.
            return NativePointer;
        }

        if (producer.OpCode is OpCode.Move or OpCode.Add && producer.Operands.Count > 1)
        {
            return producer.Operands.Skip(1).Select(operand => FromOperand(operand, addend, definitions, fromType, depth)).FirstOrDefault(kind => kind is not null);
        }

        return null;
    }

    private static string? FromOperand(
        IOperand operand,
        long addend,
        System.Func<LocalVariable, IReadOnlyList<Instruction>> definitions,
        System.Func<TypeAnalysisContext, long, string?> fromType,
        int depth)
        => operand switch
        {
            FieldReference { Field.Name: "invoke_impl" or "method_ptr" } => DelegatePointer,
            FieldReference => FieldPointer,
            ArrayAccess => ArrayDataPointer,
            AddressOf => StackPointer,
            LocalVariable { Type: { } type } => fromType(type, addend),
            // A pointer loaded through a pointer: what the outer load reads is decided by what the
            // inner one pointed into, so the walk continues there rather than stopping at "a memory
            // operand", which is the whole of this label and would answer with itself.
            MemoryOperand inner => Of(inner, definitions, fromType, depth + 1),
            _ => null,
        };
}
