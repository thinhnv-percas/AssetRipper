using System;
using System.Collections.Generic;
using System.Text;
using Cpp2IL.Core.ISIL;

namespace Cpp2IL.Core.Analysis;

/// <summary>What a pointer points into.</summary>
public enum PointerKind
{
    Unknown,
    This,
    Parameter,
    Local,
    Static,
    Field,

    /// <summary>The array object itself.</summary>
    Array,

    /// <summary>The address of one element of an array, which is not the array.</summary>
    ArrayElement,

    Stack,
    Object,
    ValueType,
    Rgctx,
}

/// <summary>Which coordinate an offset from this pointer is measured in.</summary>
public enum CoordinateFrame
{
    Unknown,

    /// <summary>Offsets include the object header, as they do from a managed reference.</summary>
    ObjectRelative,

    /// <summary>Offsets are from the value's own data, as they are from static storage or a slot.</summary>
    ValueRelative,
}

/// <summary>What a pointer is, how it was built, and what an offset from it means.</summary>
public readonly record struct PointerClassification(PointerKind Kind, CoordinateFrame Frame, string Path)
{
    public override string ToString() => $"{Kind}/{Frame} {Path}";
}

/// <summary>
/// AssetRipper: a first-class answer to "what does this pointer point into", built from the walk
/// rather than from a list of shapes each caller matches for itself.
/// </summary>
/// <remarks>
/// <para>
/// Three of this project's recurring defects are one question asked badly. <c>List&lt;T&gt;.Add</c>
/// rejects 159 sites whose receiver register holds <em>the address of an element of the backing
/// array</em> rather than the list; the unresolved-load breakdown needs to know whether an offset is
/// measured from an object or from a value; and the address-of family needs to know whether a local
/// is really a parameter. All three want the same thing: what the pointer is, and how it was built.
/// </para>
/// <para>
/// Three things are deliberately separate and must not be confused, because the first two share a
/// static type and the third is what the machine had in the register:
/// </para>
/// <list type="bullet">
/// <item>the <see cref="PointerKind.Array"/> object - <c>list._items</c>, a <c>T[]</c>;</item>
/// <item>the <see cref="PointerKind.ArrayElement"/> address - <c>&amp;list._items[i]</c>, which is a
/// pointer to one slot and has the same static type in the IR;</item>
/// <item>the list itself, which is an <see cref="PointerKind.Object"/> and is what
/// <c>List&lt;T&gt;.Add</c> takes.</item>
/// </list>
/// <para>
/// Written over the ISIL with the metadata questions passed in as delegates, so the rules are
/// testable with no game behind them - the same shape <c>BasePointerOrigin</c> and
/// <c>NestedFieldResolver</c> take.
/// </para>
/// </remarks>
public static class PointerClassifier
{
    /// <summary>
    /// What <paramref name="operand"/> points into.
    /// </summary>
    /// <param name="operand">The pointer to classify.</param>
    /// <param name="definitions">Every instruction defining a local, in program order.</param>
    /// <param name="isParameter">Whether a local is one of the method's parameters.</param>
    /// <param name="isStaticStorage">Whether a local's type is a class's static field storage.</param>
    /// <param name="isRuntimeContext">Whether a local's type is the runtime generic context table.</param>
    /// <param name="elementsOffset">
    /// Where an array's elements start, which is what separates the address of an element from the
    /// address of the array. Four pointers on the fixtures this runs against; passed rather than
    /// written down, because it is a property of the build.
    /// </param>
    public static PointerClassification Classify(IOperand? operand, Facts facts)
        => Classify(operand, facts, 0);

    /// <summary>
    /// What the caller knows that the ISIL alone does not say, passed in so the rules stay testable
    /// without a game behind them.
    /// </summary>
    /// <param name="Definitions">Every instruction defining a local, in program order.</param>
    /// <param name="IsParameter">Whether a local is one of the method's parameters.</param>
    /// <param name="IsStaticStorage">Whether a local's type is a class's static field storage.</param>
    /// <param name="IsRuntimeContext">Whether a local's type is the runtime generic context table.</param>
    /// <param name="IsArray">
    /// Whether a local holds an array. An array and the address of one of its elements share a static
    /// type once the address has been computed, so this is what the element rule is anchored on.
    /// </param>
    /// <param name="ElementsOffset">
    /// Where an array's elements start - a property of the build, four pointers on these fixtures -
    /// which is what separates the address of an element from the address of the array.
    /// </param>
    public readonly record struct Facts(
        Func<LocalVariable, IReadOnlyList<Instruction>> Definitions,
        Func<LocalVariable, bool> IsParameter,
        Func<LocalVariable, bool> IsStaticStorage,
        Func<LocalVariable, bool> IsRuntimeContext,
        Func<LocalVariable, bool> IsArray,
        int ElementsOffset);

    private static PointerClassification Classify(IOperand? operand, Facts facts, int depth)
    {
        if (depth > PointerProvenance.DepthLimit)
            return new PointerClassification(PointerKind.Unknown, CoordinateFrame.Unknown, "depth");

        switch (operand)
        {
            case null:
                return new PointerClassification(PointerKind.Unknown, CoordinateFrame.Unknown, "none");

            case FieldReference field:
                // A field's own storage. Read off an object, so an offset from it carries the header.
                return new PointerClassification(
                    PointerKind.Field, CoordinateFrame.ObjectRelative,
                    $"{Name(field.Local)}.{field.Field?.Name ?? "?"}");

            case ArrayAccess array:
                return new PointerClassification(
                    PointerKind.ArrayElement, CoordinateFrame.ObjectRelative, $"{Name(array.Array)}[index]");

            case AddressOf address:
                var inner = Classify(address.Target, facts, depth + 1);
                return inner with { Path = "&" + inner.Path };

            case StackOffset stack:
                return new PointerClassification(PointerKind.Stack, CoordinateFrame.ValueRelative, stack.ToString() ?? "stack");

            case LocalVariable local:
                return ClassifyLocal(local, facts, depth);
        }

        return new PointerClassification(PointerKind.Unknown, CoordinateFrame.Unknown, operand.GetType().Name);
    }

    private static PointerClassification ClassifyLocal(LocalVariable local, Facts facts, int depth)
    {
        // What the IR states about the local itself comes first: it is a fact, where the walk back
        // through its definition is an inference.
        if (local.IsThis)
            return new PointerClassification(PointerKind.This, CoordinateFrame.ObjectRelative, "this");

        if (facts.IsStaticStorage(local))
            return new PointerClassification(PointerKind.Static, CoordinateFrame.ValueRelative, local.Name);

        if (facts.IsRuntimeContext(local))
            return new PointerClassification(PointerKind.Rgctx, CoordinateFrame.ValueRelative, local.Name);

        if (facts.IsArray(local))
            return new PointerClassification(PointerKind.Array, CoordinateFrame.ObjectRelative, local.Name);

        if (facts.IsParameter(local))
        {
            var frame = local.Type is { IsValueType: true }
                ? CoordinateFrame.ValueRelative
                : CoordinateFrame.ObjectRelative;
            return new PointerClassification(PointerKind.Parameter, frame, local.Name);
        }

        var defining = facts.Definitions(local);

        if (defining.Count != 1)
        {
            // Several definitions is not a disagreement to resolve here. It is the shape SSA
            // destruction leaves at every join, and picking one is the guess this file avoids.
            return new PointerClassification(
                PointerKind.Unknown, CoordinateFrame.Unknown,
                defining.Count == 0 ? $"{local.Name}:no definition" : $"{local.Name}:merged");
        }

        var instruction = defining[0];

        switch (instruction.OpCode)
        {
            case OpCode.Move when instruction.Operands.Count > 1:
                var moved = Classify(instruction.Operands[1], facts, depth + 1);
                return moved;

            case OpCode.Add when instruction.Operands.Count > 2:
                return ClassifyAdd(instruction, facts, depth);

            case OpCode.Newobj:
                return new PointerClassification(PointerKind.Object, CoordinateFrame.ObjectRelative, $"new {Describe(instruction.Operands.Count > 1 ? instruction.Operands[1] : null)}");

            case OpCode.Call or OpCode.CallVoid:
                return new PointerClassification(PointerKind.Object, CoordinateFrame.ObjectRelative, "call result");
        }

        return new PointerClassification(
            PointerKind.Unknown, CoordinateFrame.Unknown, $"{local.Name}:{instruction.OpCode}");
    }

    /// <summary>
    /// An <c>Add</c> is where an element address is built, and it is the one shape that must not be
    /// confused with the array it is built from.
    /// </summary>
    /// <remarks>
    /// <c>array + (index &lt;&lt; k)</c> then <c>+ elementsOffset</c>, or the two folded into one
    /// addend, is the address of one slot. The compiler writes it exactly this way on an architecture
    /// with no scaled-index addressing mode, and the result carries the array's static type - which is
    /// why it reaches a receiver register and reads as a list.
    /// </remarks>
    private static PointerClassification ClassifyAdd(Instruction instruction, Facts facts, int depth)
    {
        var left = instruction.Operands[1];
        var right = instruction.Operands[2];

        var baseKind = Classify(left, facts, depth + 1);

        if (right is Immediate immediate)
        {
            var addend = ToInt(immediate);

            // The elements offset added to something that is already an index computation is the last
            // step of an element address; added to an array outright it is the address of element
            // zero, which is still an element and not the array.
            if (addend == facts.ElementsOffset && (baseKind.Kind is PointerKind.Array or PointerKind.ArrayElement))
                return new PointerClassification(PointerKind.ArrayElement, CoordinateFrame.ValueRelative, baseKind.Path + "[i]");

            if (baseKind.Kind is PointerKind.ArrayElement)
                return baseKind with { Path = baseKind.Path + $"+{addend}" };

            return baseKind with { Path = baseKind.Path + $"+{addend}" };
        }

        // `array + scaled index`: whichever side is the scaled index, the other is the base, and the
        // result addresses one element.
        if (IsScaledIndex(left, facts) || IsScaledIndex(right, facts))
        {
            var arraySide = IsScaledIndex(left, facts) ? right : left;
            var side = Classify(arraySide, facts, depth + 1);
            return new PointerClassification(PointerKind.ArrayElement, CoordinateFrame.ValueRelative, side.Path + "[i]");
        }

        return baseKind with { Path = baseKind.Path + "+?" };
    }

    private static bool IsScaledIndex(IOperand operand, Facts facts)
    {
        if (operand is not LocalVariable local)
            return false;

        var defining = facts.Definitions(local);

        return defining.Count == 1
            && defining[0].OpCode is OpCode.ShiftLeft or OpCode.Multiply;
    }

    private static long ToInt(Immediate immediate)
    {
        try
        {
            return Convert.ToInt64(immediate.Value);
        }
        catch (Exception)
        {
            return long.MinValue;
        }
    }

    private static string Name(LocalVariable? local) => local?.Name ?? "?";

    private static string Describe(IOperand? operand)
    {
        if (operand is null)
            return "?";

        StringBuilder builder = new();
        builder.Append(operand);
        return builder.ToString();
    }
}
