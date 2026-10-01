using System;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: what kind of value one recovered operand carries, and what a read or a write of it
/// means in IL.
/// </summary>
/// <remarks>
/// Iteration 064. The chain a value goes through - native instruction, SSA value, producer, storage,
/// runtime type, expression - had a rule at every step and no shared vocabulary, so two steps could
/// disagree about what the same value was without anything noticing. The <c>ref Color</c> defect is
/// the case that forced it: the analysis knew the base was a managed reference, the field search did
/// not look through it, and the generator wrote to the reference rather than through it.
/// </remarks>
public enum ValueKind
{
    /// <summary>Nothing establishes what the value is. Never guessed into anything else.</summary>
    Unknown,

    /// <summary>A value read and used as a value: an integer, a float, a bool.</summary>
    RValue,

    /// <summary>A storage location being written: a local, a field, an element.</summary>
    LValue,

    /// <summary>The address of a storage location this body names - <c>ldloca</c>, <c>ldarga</c>.</summary>
    Address,

    /// <summary>A managed reference re-pointed at other storage: <c>ref x = ref y</c>.</summary>
    RefAlias,

    /// <summary>A reference to a managed object.</summary>
    ObjectReference,

    /// <summary>A pointer the machine had that no managed type names.</summary>
    NativePointer,

    /// <summary>A managed reference (<c>T&amp;</c>): an address the type system tracks.</summary>
    ManagedReference,

    /// <summary>A value type held by value.</summary>
    StructValue,

    /// <summary>One element of an array.</summary>
    ArrayElement,

    /// <summary>The address of a field.</summary>
    FieldAddress,

    /// <summary>A pointer to the runtime's <c>MethodInfo</c>.</summary>
    MethodInfo,

    /// <summary>A pointer to the runtime's <c>Il2CppClass</c>, or to a class's static field storage.</summary>
    Il2CppClass,

    /// <summary>A pointer to a runtime generic context table.</summary>
    GenericContext,
}

/// <summary>What a store into an operand does, in IL terms.</summary>
public enum StoreSemantics
{
    /// <summary>The destination is not one this classification covers.</summary>
    Unknown,

    /// <summary><c>stloc</c>/<c>starg</c>: the local itself takes the value.</summary>
    AssignLocal,

    /// <summary><c>stobj</c>: the value is written to what a managed reference points at.</summary>
    WriteThroughReference,

    /// <summary><c>stfld</c>/<c>stsfld</c>, or a setter that does nothing else.</summary>
    StoreField,

    /// <summary><c>stelem</c>.</summary>
    StoreArrayElement,

    /// <summary>
    /// The managed reference itself is re-pointed. Legal only when the value stored is an address;
    /// a value stored this way is the <c>currentValue = ref *(Color*)newValue</c> defect.
    /// </summary>
    RebindReference,

    /// <summary>A write the generator has no IL for and drops (a store through a native pointer).</summary>
    Discarded,
}

/// <summary>What a load from an operand does, in IL terms.</summary>
public enum LoadSemantics
{
    Unknown,

    /// <summary><c>ldloc</c>/<c>ldarg</c>.</summary>
    ReadLocal,

    /// <summary><c>ldobj</c> through a managed reference.</summary>
    ReadThroughReference,

    /// <summary><c>ldfld</c>/<c>ldsfld</c>, or a getter that does nothing else.</summary>
    LoadField,

    /// <summary><c>ldelem</c>.</summary>
    LoadArrayElement,

    /// <summary><c>ldloca</c>/<c>ldarga</c>/<c>ldflda</c>.</summary>
    TakeAddress,

    /// <summary>A memory operand nothing resolved: reported, never invented.</summary>
    Unresolved,
}

public static class ValueFlow
{
    /// <summary>The kind of value a local of <paramref name="type"/> carries.</summary>
    public static ValueKind KindOf(TypeAnalysisContext? type) => type switch
    {
        null => ValueKind.Unknown,
        ByRefTypeAnalysisContext => ValueKind.ManagedReference,
        PointerTypeAnalysisContext => ValueKind.NativePointer,
        RuntimeClassTypeAnalysisContext or StaticFieldStorageTypeAnalysisContext => ValueKind.Il2CppClass,
        RuntimeMethodInfoAnalysisContext => ValueKind.MethodInfo,
        RgctxTableTypeAnalysisContext or MethodRgctxTableTypeAnalysisContext => ValueKind.GenericContext,
        SzArrayTypeAnalysisContext or ArrayTypeAnalysisContext => ValueKind.ObjectReference,
        { IsValueType: true } when IsPrimitive(type) => ValueKind.RValue,
        { IsValueType: true } => ValueKind.StructValue,
        // A generic parameter is neither known to be a reference nor known not to be one.
        GenericParameterTypeAnalysisContext => ValueKind.Unknown,
        _ => ValueKind.ObjectReference,
    };

    /// <summary>
    /// Whether a memory operand at offset zero off a local of this kind is the storage the local
    /// points at - so a store there writes through it - rather than the local itself.
    /// </summary>
    public static bool WritesThrough(ValueKind baseKind) => baseKind == ValueKind.ManagedReference;

    /// <inheritdoc cref="WritesThrough(ValueKind)"/>
    public static bool WritesThrough(TypeAnalysisContext? baseType) => WritesThrough(KindOf(baseType));

    /// <summary>
    /// What a store into <paramref name="destination"/> means, given the kind of each local.
    /// </summary>
    /// <remarks>
    /// The one rule the generator's store path and every measurement of it share. A memory operand at
    /// offset zero off a managed reference is the referent, so the store is <c>stobj</c>; off anything
    /// else the generator has no IL for it. A <em>local</em> of managed reference kind is re-pointed
    /// only when the value is itself an address; any other value stored into it is a rebinding that
    /// C# would have written as a store through it.
    /// </remarks>
    public static StoreSemantics StoreInto(IOperand destination, Func<LocalVariable, ValueKind> kindOf, IOperand? value = null)
    {
        switch (destination)
        {
            case LocalVariable local:
                if (kindOf(local) == ValueKind.ManagedReference && value is not null && !IsAddress(value, kindOf))
                    return StoreSemantics.RebindReference;
                return StoreSemantics.AssignLocal;

            case FieldReference:
                return StoreSemantics.StoreField;

            case ArrayAccess:
                return StoreSemantics.StoreArrayElement;

            case MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable pointer }:
                return WritesThrough(kindOf(pointer)) ? StoreSemantics.WriteThroughReference : StoreSemantics.Discarded;

            case MemoryOperand:
                return StoreSemantics.Discarded;

            default:
                return StoreSemantics.Unknown;
        }
    }

    /// <summary>What a load from <paramref name="source"/> means, given the kind of each local.</summary>
    public static LoadSemantics LoadFrom(IOperand source, Func<LocalVariable, ValueKind> kindOf) => source switch
    {
        LocalVariable => LoadSemantics.ReadLocal,
        FieldReference => LoadSemantics.LoadField,
        ArrayAccess => LoadSemantics.LoadArrayElement,
        AddressOf => LoadSemantics.TakeAddress,
        MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable pointer } when WritesThrough(kindOf(pointer))
            => LoadSemantics.ReadThroughReference,
        MemoryOperand => LoadSemantics.Unresolved,
        _ => LoadSemantics.Unknown,
    };

    /// <summary>Whether a value is an address, which is the only thing a managed reference may be re-pointed at.</summary>
    public static bool IsAddress(IOperand value, Func<LocalVariable, ValueKind> kindOf) => value switch
    {
        AddressOf => true,
        LocalVariable local => kindOf(local) is ValueKind.ManagedReference or ValueKind.Address or ValueKind.FieldAddress,
        _ => false,
    };

    private static bool IsPrimitive(TypeAnalysisContext type) => type.FullName switch
    {
        "System.Boolean" or "System.Char" or "System.SByte" or "System.Byte" or "System.Int16" or "System.UInt16"
            or "System.Int32" or "System.UInt32" or "System.Int64" or "System.UInt64" or "System.Single"
            or "System.Double" or "System.IntPtr" or "System.UIntPtr" => true,
        _ => type.IsEnumType,
    };
}
