using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: an inlined <c>List&lt;T&gt;.Clear()</c>, put back as the call.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 065. The framework's body is <c>_version++</c> and <c>_size = 0</c>, with, where <c>T</c>
/// holds references, <c>Array.Clear(_items, 0, size)</c> on the size read just before the zero store.
/// il2cpp inlines it, so the caller names three private fields of <c>List&lt;T&gt;</c>: 26 of
/// Merge-Room's body errors, in <c>RoomController</c>, <c>Outline</c> and <c>PlayerInput</c>.
/// </para>
/// <para>
/// The anchor is the store of the constant zero into <c>_size</c>. No other member of <c>List&lt;T&gt;</c>
/// writes a constant there - <c>RemoveAll</c> and <c>RemoveRange</c> write a computed size - so that store
/// names the operation, and the version bump on the <em>same receiver</em> in the same block is what ties
/// the rest of the region to it: a load of <c>_version</c>, an add of one, the store back. Short of all
/// of that the site is left alone and counted under the reason. The reference-type tail is removed only
/// where its array is that receiver's <c>_items</c> and its count is that receiver's <c>_size</c>.
/// </para>
/// </remarks>
public static class InlineListClearRecovery
{
    public static bool Run(ISILControlFlowGraph cfg, MethodAnalysisContext? method)
    {
        var rewroteAny = false;

        foreach (var block in cfg.Blocks.ToList())
        {
            foreach (var anchor in block.Instructions.ToList())
            {
                if (anchor is not { OpCode: OpCode.Move, Operands: [FieldReference { ContainingFields.Count: 0, ElementIndex: null } sizeField, Immediate { Value: 0 }] }
                    || !IsListField(sizeField, "_size", out var instance))
                    continue;

                InlineOperationRecovery.CountCandidate();

                if (TryRewrite(cfg, block, anchor, sizeField, instance, method))
                    rewroteAny = true;
            }
        }

        return rewroteAny;
    }

    private static bool TryRewrite(ISILControlFlowGraph cfg, Block block, Instruction anchor, FieldReference sizeField,
        GenericInstanceTypeAnalysisContext? instance, MethodAnalysisContext? method)
    {
        var receiver = sizeField.Local;
        var at = block.Instructions.IndexOf(anchor);

        // The version store back, on the same receiver, in the same block.
        var versionStore = block.Instructions.FirstOrDefault(i =>
            i is { OpCode: OpCode.Move, Operands: [FieldReference { ContainingFields.Count: 0 } stored, LocalVariable] }
            && ReferenceEquals(stored.Local, receiver) && IsListField(stored, "_version", out _));

        if (versionStore is null)
        {
            InlineOperationRecovery.CountRejection(InlineOperationRecovery.Family.ListClear, "NO_VERSION_STORE_ON_THE_RECEIVER", method);
            return false;
        }

        var bumped = (LocalVariable)versionStore.Operands[1];
        var bump = block.Instructions.FirstOrDefault(i => ReferenceEquals(i.Destination, bumped));

        if (bump is not { OpCode: OpCode.Add, Operands: [_, var left, var right] }
            || !(IsOne(right) && ReadsVersion(left, receiver, block) || IsOne(left) && ReadsVersion(right, receiver, block)))
        {
            InlineOperationRecovery.CountRejection(InlineOperationRecovery.Family.ListClear, "VERSION_STORE_IS_NOT_AN_INCREMENT", method);
            return false;
        }

        // Nothing between the region's first and last instruction may write the receiver's fields; a
        // store that is not part of the shape means the region is not the framework's body.
        var first = System.Math.Min(System.Math.Min(at, block.Instructions.IndexOf(versionStore)), block.Instructions.IndexOf(bump));
        var last = System.Math.Max(at, block.Instructions.IndexOf(versionStore));
        for (var index = first; index <= last; index++)
        {
            var between = block.Instructions[index];
            if (ReferenceEquals(between, anchor) || ReferenceEquals(between, versionStore))
                continue;

            if (between.Operands is [FieldReference other, ..] && between.OpCode == OpCode.Move && ReferenceEquals(other.Local, receiver))
            {
                InlineOperationRecovery.CountRejection(InlineOperationRecovery.Family.ListClear, "OTHER_STORE_INTO_THE_RECEIVER", method);
                return false;
            }
        }

        if (ClearOf(sizeField, instance) is not { } clear)
        {
            InlineOperationRecovery.CountRejection(InlineOperationRecovery.Family.ListClear, "NO_CLEAR_ON_THE_DEFINITION", method);
            return false;
        }

        // The reference-type tail: Array.Clear(receiver._items, 0, <receiver._size as read before>).
        foreach (var candidate in cfg.Blocks.SelectMany(b => b.Instructions))
        {
            if (candidate.OpCode is not (OpCode.CallVoid or OpCode.Call)
                || candidate.Operands is not [MethodAnalysisContext { Name: "Clear", IsStatic: true, Parameters.Count: 3, DeclaringType.FullName: "System.Array" }, ..])
                continue;

            var argumentStart = candidate.OpCode == OpCode.CallVoid ? 1 : 2;
            if (candidate.Operands.Count < argumentStart + 3
                || !IsReceiverField(candidate.Operands[argumentStart], receiver, "_items", cfg)
                || candidate.Operands[argumentStart + 1] is not Immediate { Value: 0 }
                || !IsReceiverField(candidate.Operands[argumentStart + 2], receiver, "_size", cfg))
                continue;

            candidate.OpCode = OpCode.Nop;
            candidate.SetOperands();
        }

        anchor.OpCode = OpCode.CallVoid;
        anchor.SetOperands(clear, receiver);
        versionStore.OpCode = OpCode.Nop;
        versionStore.SetOperands();

        if (method is not null)
            InlineOperationRecovery.CountMatch(InlineOperationRecovery.Family.ListClear, method);
        return true;
    }

    private static bool IsOne(IOperand operand) => operand is Immediate { Value: 1 };

    private static bool ReadsVersion(IOperand operand, LocalVariable receiver, Block block)
        => operand switch
        {
            FieldReference loaded => ReferenceEquals(loaded.Local, receiver) && IsListField(loaded, "_version", out _),
            LocalVariable local => block.Instructions.Any(i => ReferenceEquals(i.Destination, local)
                && i is { OpCode: OpCode.Move, Operands: [_, FieldReference loaded] }
                && ReferenceEquals(loaded.Local, receiver) && IsListField(loaded, "_version", out _)),
            _ => false,
        };

    // An operand that is the receiver's field by that name, directly or through one local loaded from it.
    private static bool IsReceiverField(IOperand operand, LocalVariable receiver, string name, ISILControlFlowGraph cfg)
        => operand switch
        {
            FieldReference direct => ReferenceEquals(direct.Local, receiver) && IsListField(direct, name, out _),
            LocalVariable local => cfg.Blocks.SelectMany(b => b.Instructions).Where(i => ReferenceEquals(i.Destination, local)).ToList() is [{ OpCode: OpCode.Move, Operands: [_, FieldReference loaded] }]
                && ReferenceEquals(loaded.Local, receiver) && IsListField(loaded, name, out _),
            _ => false,
        };

    /// <summary>Whether a field reference names <paramref name="name"/> of the framework's <c>List&lt;T&gt;</c>.</summary>
    public static bool IsListField(FieldReference reference, string name, out GenericInstanceTypeAnalysisContext? instance)
    {
        instance = reference.Field.DeclaringType as GenericInstanceTypeAnalysisContext;
        var definition = instance?.GenericType ?? reference.Field.DeclaringType;

        return reference.Field.Name == name && !reference.Field.IsStatic
            && definition is { FullName: "System.Collections.Generic.List`1" }
            && definition.DeclaringAssembly?.Name is "mscorlib" or "System.Private.CoreLib" or "netstandard";
    }

    private static MethodAnalysisContext? ClearOf(FieldReference sizeField, GenericInstanceTypeAnalysisContext? instance)
    {
        var definition = instance?.GenericType ?? sizeField.Field.DeclaringType;
        if (definition?.Methods.FirstOrDefault(m => m is { Name: "Clear", IsStatic: false, Parameters.Count: 0 }) is not { } found)
            return null;

        return instance is null ? found : new ConcreteGenericMethodAnalysisContext(found, instance.GenericArguments, []);
    }
}
