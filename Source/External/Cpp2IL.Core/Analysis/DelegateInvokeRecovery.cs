using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;

namespace Cpp2IL.Core.Analysis;

//Recovers IndirectCall (call reg) for delegate invoke back to actual calls on Invoke
public static class DelegateInvokeRecovery
{
    public static void Run(MethodAnalysisContext method)
    {
        var instructions = method.ControlFlowGraph!.Blocks.SelectMany(block => block.Instructions).ToList();

        var invokeImplOffset = InvokeImplOffset(method.AppContext.Binary.is32Bit);

        foreach (var block in method.ControlFlowGraph.Blocks)
        {
            // A copy, because a tail call gains a Return in the block it sits in.
            foreach (var instruction in block.Instructions.ToList())
            {
                if (instruction.OpCode is not (OpCode.IndirectCall or OpCode.IndirectJump))
                    continue;

                if (GetDelegateBeingInvoked(instruction, instructions, invokeImplOffset) is not { } delegateLocal)
                    continue;

                if (InvokeOf(delegateLocal.Type) is not { } invoke)
                    continue;

                var isTailCall = instruction.OpCode == OpCode.IndirectJump;

                if (!RewriteAsInvoke(instruction, delegateLocal, invoke, method))
                    continue;

                if (isTailCall)
                    AppendReturn(block, instruction, invoke, method);
            }
        }
    }

    /// <summary>
    /// AssetRipper: a tail-called delegate invoke is a call followed by a return, and the return has
    /// to be written out because the jump that used to end the block is gone.
    /// </summary>
    /// <remarks>
    /// <para>
    /// A delegate invoke in tail position is the majority of what survives as
    /// <c>OpCode.IndirectJump</c> - 288 of 515 on the test game, against 135 vtable slots and 60
    /// computed targets - so this is the same recovery as the call case and not a separate family.
    /// </para>
    /// <para>
    /// The return cannot be left implicit. The generator bridges a block that does not end in a jump
    /// or a return to its successor, and an indirect jump's block has none, so without this the block
    /// would end with no terminator at all.
    /// </para>
    /// </remarks>
    private static void AppendReturn(Block block, Instruction call, MethodAnalysisContext invoke, MethodAnalysisContext caller)
    {
        var index = block.Instructions.IndexOf(call);

        if (index < 0)
            return;

        // The caller returns what the delegate returned, unless one of the two is void - in which
        // case there is nothing to carry across and the return stands alone.
        List<IOperand> operands = !caller.IsVoid && !invoke.IsVoid && call.Operands.Count > 1
            ? [call.Operands[1]]
            : [];

        block.Instructions.Insert(index + 1, new Instruction(call.Index, OpCode.Return, operands));
    }

    /// <summary>
    /// The delegate whose <c>invoke_impl</c> this call goes through, or null if it does not.
    /// </summary>
    /// <remarks>
    /// <para>
    /// AssetRipper: the address being called reaches this pass in <em>two</em> shapes, because
    /// <see cref="MetadataResolver"/> turns a memory operand it can place into a
    /// <see cref="FieldReference"/> - and this pass only ever matched the raw one. So a delegate
    /// invoke in a method whose field offsets resolved, which is the ordinary case, was never
    /// recognised: 117 of the 350 <c>Indirect call</c> placeholders on the test game were a call
    /// through a field literally named <c>invoke_impl</c> on a value the analysis had already typed
    /// as a delegate.
    /// </para>
    /// <para>
    /// The resolved shape needs no offset arithmetic at all - the field is named - which is why it is
    /// matched on the name rather than on <paramref name="invokeImplOffset"/>. Either shape may also
    /// be one <c>Move</c> away, before copy propagation folds it into the call.
    /// </para>
    /// </remarks>
    private static LocalVariable? GetDelegateBeingInvoked(Instruction call, List<Instruction> instructions, int invokeImplOffset)
    {
        if (call.Operands.Count == 0)
            return null;

        var target = call.Operands[0];

        if (target is LocalVariable local)
        {
            var definition = instructions.FirstOrDefault(i => ReferenceEquals(i.Destination, local));
            if (definition is { OpCode: OpCode.Move, Operands: [_, var moved] })
                target = moved;
        }

        return target switch
        {
            FieldReference resolved => DelegateFromResolvedField(
                resolved.Field.Name, resolved.Local, resolved.ElementIndex is not null, resolved.ContainingFields.Count),
            MemoryOperand { Index: null, Scale: 0 } memory when memory.Addend == invokeImplOffset => memory.Base as LocalVariable,
            _ => null,
        };
    }

    /// <summary>
    /// AssetRipper: Il2CppObject is two pointers (klass, monitor), then <c>method_ptr</c>, then
    /// <c>invoke_impl</c>.
    /// </summary>
    public static int InvokeImplOffset(bool is32Bit) => (is32Bit ? 4 : 8) * 3;

    /// <summary>
    /// AssetRipper: the delegate a resolved field access is reaching <c>invoke_impl</c> on, or null
    /// if it is reaching something else.
    /// </summary>
    /// <remarks>
    /// Split out so the rule can be tested without metadata behind it. The two disqualifiers are not
    /// decoration: an element index means the access went through an array element, and a containing
    /// field means the offset landed inside a value type rather than on the delegate's own slot, and
    /// in neither case is the local the delegate being invoked.
    /// </remarks>
    public static LocalVariable? DelegateFromResolvedField(string fieldName, LocalVariable local, bool hasElementIndex, int containingFieldCount)
        => fieldName == InvokeImpl && !hasElementIndex && containingFieldCount == 0 ? local : null;

    private const string InvokeImpl = "invoke_impl";

    /// <summary>
    /// AssetRipper: the <c>Invoke</c> a delegate-typed value would be called through, instantiated
    /// where the delegate is a generic instance.
    /// </summary>
    /// <remarks>
    /// A generic instance context carries its arguments and its definition and declares no members of
    /// its own, so asking it for <c>Invoke</c> - or even whether it is a delegate, since that is read
    /// off the base type - answers nothing. Every generic delegate therefore went unrecognised, and
    /// those are most of them: <c>DOGetter&lt;Vector2&gt;</c>, <c>Predicate&lt;T&gt;</c>,
    /// <c>Action&lt;T&gt;</c>. The instantiation matters rather than being cosmetic, because the
    /// argument remapping that follows reads the callee's signature, and the open definition's
    /// return type is a type parameter.
    /// </remarks>
    private static MethodAnalysisContext? InvokeOf(TypeAnalysisContext? type)
    {
        var instance = type as GenericInstanceTypeAnalysisContext;
        var definition = instance?.GenericType ?? type;

        if (definition is not { IsDelegate: true })
            return null;

        if (definition.Methods.FirstOrDefault(m => m.Name == "Invoke") is not { } invoke)
            return null;

        return instance is null ? invoke : new ConcreteGenericMethodAnalysisContext(invoke, instance.GenericArguments, []);
    }

    private static bool RewriteAsInvoke(Instruction call, LocalVariable delegateLocal, MethodAnalysisContext invoke, MethodAnalysisContext caller)
    {
        if (invoke.AppContext.InstructionSet.CallingConventionResolver is not { } callingConventions
            || !callingConventions.HasRawArgumentLayout(call, invoke.AppContext))
            return false;

        if (invoke.IsVoid)
            call.RemoveOperandAt(1);

        call.OpCode = invoke.IsVoid ? OpCode.CallVoid : OpCode.Call;
        call.SetOperand(0, invoke);

        // the receiver register holds invoke_impl_this rather than the delegate itself
        call.SetOperand(invoke.IsVoid ? 1 : 2, delegateLocal);

        callingConventions.RemapRawArguments(call, invoke, caller);
        return true;
    }
}
