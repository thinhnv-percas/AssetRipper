using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: a call to the runtime's compare-and-swap whose location is a reference-typed field,
/// recovered as <c>Interlocked.CompareExchange&lt;T&gt;(ref field, value, comparand)</c>.
/// </summary>
/// <remarks>
/// <para>
/// Iteration 064. Every field-like event's accessors are a loop around a compare-and-swap of the event's
/// backing field, and il2cpp compiles that to a call to a runtime function no managed method sits at.
/// Left unresolved, the accessor is a placeholder, and a decompiler cannot recognise the accessor
/// pattern it would fold back into <c>public event Action&lt;T&gt; X;</c> - so it prints the field and
/// the event side by side, which is CS0102 the moment an interface requires the event to stay. That
/// is Merge-Room's <c>GameManager.OnStateChanged</c>, and the same unresolved call is 339 event
/// accessors on the test game.
/// </para>
/// <para>
/// Iteration 050 recorded the function's semantics as certain and refused to map it, for two reasons
/// that both still hold for a mapping keyed on an address: the address is one build's, and choosing an
/// overload is a second decision. Neither applies here. The callee is identified by its instructions
/// (<see cref="AtomicIntrinsicRecognizer.ReadCompareExchange"/>), which also say which argument register
/// is the location, which the value and which the comparand - so the argument order is read, not
/// assumed - and how wide the location is. The overload is settled by the call site: a location that is
/// the address of a field of reference type <c>T</c>, swapped at pointer width, type-checks against
/// <c>CompareExchange&lt;T&gt;(ref T, T, T)</c> and nothing else. Anything short of all three - a
/// narrower width, a location that is not provably a field, a field of value type - is left exactly as
/// it was and counted under the reason.
/// </para>
/// </remarks>
public static class CompareExchangeRecovery
{
    private static readonly ConcurrentDictionary<(ApplicationAnalysisContext, ulong), AtomicIntrinsicRecognizer.CompareExchangeOperands?> Callees = new();
    private static readonly ConcurrentDictionary<string, int> Rejections = new();

    /// <summary>How many calls were recovered as <c>Interlocked.CompareExchange&lt;T&gt;</c>.</summary>
    public static int Recovered;

    /// <summary>Calls to a proven compare-and-swap that were left alone, by the reason.</summary>
    public static IReadOnlyList<KeyValuePair<string, int>> Rejected => [.. Rejections.OrderByDescending(pair => pair.Value)];

    public static bool Run(MethodAnalysisContext method)
    {
        if (method.ControlFlowGraph is not { } graph)
            return false;

        var app = method.AppContext;

        // The sequence the recogniser reads is A64's; on any other instruction set the bytes mean
        // something else and the answer would be noise.
        if (app.Binary.InstructionSetId != LibCpp2IL.DefaultInstructionSets.ARM_V8)
            return false;

        var instructions = graph.Blocks.SelectMany(block => block.Instructions).ToList();
        var changed = false;
        int pointerSize = app.Binary.is32Bit ? 4 : 8;

        foreach (var call in instructions)
        {
            if (call.OpCode is not (OpCode.Call or OpCode.CallVoid) || call.Operands.Count < 5 || call.Operands[0] is not Immediate { Value: var address })
                continue;

            if (CalleeOf(app, (ulong)address) is not { } operands)
                continue;

            int argBase = call.OpCode == OpCode.Call ? 2 : 1;

            if (operands.Width != pointerSize)
            {
                Reject("WIDTH_IS_NOT_A_REFERENCE");
                continue;
            }

            if (argBase + new[] { operands.Location, operands.Value, operands.Comparand }.Max() >= call.Operands.Count)
            {
                Reject("ARGUMENT_REGISTERS_NOT_ON_THE_CALL");
                continue;
            }

            if (FieldAddressed(call.Operands[argBase + operands.Location], instructions, method) is not { } location)
            {
                Reject("LOCATION_IS_NOT_A_FIELD_ADDRESS");
                continue;
            }

            if (location.Field.FieldType is not { IsValueType: false } fieldType || fieldType is GenericParameterTypeAnalysisContext)
            {
                Reject("FIELD_IS_NOT_A_REFERENCE");
                continue;
            }

            if (CompareExchangeOf(app, fieldType) is not { } target)
            {
                Reject("NO_GENERIC_COMPAREEXCHANGE_IN_CORLIB");
                continue;
            }

            List<IOperand> rebuilt = [target];
            if (call.OpCode == OpCode.Call)
                rebuilt.Add(call.Operands[1]);
            rebuilt.Add(new AddressOf(location));
            rebuilt.Add(call.Operands[argBase + operands.Value]);
            rebuilt.Add(call.Operands[argBase + operands.Comparand]);
            call.SetOperands(rebuilt);

            System.Threading.Interlocked.Increment(ref Recovered);
            changed = true;
        }

        return changed;
    }

    private static void Reject(string reason) => Rejections.AddOrUpdate(reason, 1, (_, count) => count + 1);

    /// <summary>The operands of the compare-and-swap at <paramref name="address"/>, following one veneer.</summary>
    private static AtomicIntrinsicRecognizer.CompareExchangeOperands? CalleeOf(ApplicationAnalysisContext app, ulong address)
        => Callees.GetOrAdd((app, address), key =>
        {
            var (context, at) = key;

            if (Read(context, at) is { } direct)
                return direct;

            var thunk = context.InstructionSet.GetThunkTarget(context, at);
            return thunk != 0 && thunk != at ? Read(context, thunk) : null;
        });

    private static AtomicIntrinsicRecognizer.CompareExchangeOperands? Read(ApplicationAnalysisContext app, ulong address)
    {
        try
        {
            if (!app.Binary.TryMapVirtualAddressToRaw(address, out var offset) || offset <= 0)
                return null;

            var content = app.Binary.GetRawBinaryContent();
            var window = System.Math.Min(AtomicIntrinsicRecognizer.WindowInstructions * 4, content.Length - (int)offset);
            return window <= 0 ? null : AtomicIntrinsicRecognizer.ReadCompareExchange(content.Slice((int)offset, window));
        }
        catch (System.Exception)
        {
            return null;
        }
    }

    /// <summary>
    /// The instance field whose address <paramref name="operand"/> is, when that is provable: a local
    /// defined once, by <c>object + constant</c>, where the object's class has a field at exactly that
    /// offset.
    /// </summary>
    /// <remarks>
    /// Only a class receiver. A struct's field address depends on whether the pointer is to the boxed
    /// object or the value's data, and nothing here needs that case. Generic owners are left out too:
    /// their recorded offsets are zero and a field taken from the computed layout has to be closed on
    /// the instance, which is a separate piece of work rather than a reason to guess.
    /// </remarks>
    public static FieldReference? FieldAddressed(IOperand operand, IReadOnlyList<Instruction> instructions, MethodAnalysisContext method)
    {
        // A class's static field storage pointer, which StaticFieldStorageHead names as the field at
        // offset zero: the pointer *is* that field's address. A load of a static field has its local
        // typed as the storage, never as the class, so the two cannot be confused.
        if (operand is FieldReference { Field.IsStatic: true, Offset: 0, Local.Type: RuntimeClassTypeAnalysisContext } head)
            return head;

        if (operand is not LocalVariable pointer)
            return null;

        var definitions = instructions.Where(i => ReferenceEquals(i.Destination, pointer)).ToList();

        if (definitions is [{ OpCode: OpCode.Move, Operands: [_, FieldReference { Field.IsStatic: true, Offset: 0, Local.Type: RuntimeClassTypeAnalysisContext } moved] }])
            return moved;

        // Another static field: the storage pointer plus the field's offset in the storage.
        if (definitions is [{ OpCode: OpCode.Add, Operands: [_, LocalVariable { Type: StaticFieldStorageTypeAnalysisContext { OwnerType: { } staticOwner } } storage, Immediate { Value: var staticOffset }] }]
            && staticOwner.GenericParameters.Count == 0
            && MetadataResolver.SearchFieldAtOffset(staticOwner, staticOffset, wantStatic: true) is { } staticField)
            return new FieldReference(staticField, storage, (int)staticOffset);

        if (definitions is not [{ OpCode: OpCode.Add, Operands: [_, LocalVariable owner, Immediate { Value: var offset }] }])
            return null;

        if (owner.Type is not { IsValueType: false } ownerType
            || ownerType is GenericInstanceTypeAnalysisContext or ByRefTypeAnalysisContext or PointerTypeAnalysisContext
            || ownerType.GenericParameters.Count > 0
            || ValueFlow.KindOf(ownerType) != ValueKind.ObjectReference)
            return null;

        if (MetadataResolver.SearchFieldAtOffset(ownerType, offset, wantStatic: false) is not { } field
            || field.DeclaringType is null
            || field.DeclaringType.GenericParameters.Count > 0)
            return null;

        return new FieldReference(field, owner, (int)offset);
    }

    private static readonly ConcurrentDictionary<ApplicationAnalysisContext, MethodAnalysisContext?> GenericCompareExchange = new();

    /// <summary><c>System.Threading.Interlocked.CompareExchange&lt;T&gt;</c> closed on <paramref name="type"/>.</summary>
    private static MethodAnalysisContext? CompareExchangeOf(ApplicationAnalysisContext app, TypeAnalysisContext type)
    {
        var definition = GenericCompareExchange.GetOrAdd(app, context =>
            context.GetAssemblyByName("mscorlib")?.GetTypeByFullName("System.Threading.Interlocked")?.Methods
                .FirstOrDefault(m => m is { Name: "CompareExchange", IsStatic: true, GenericParameters.Count: 1, Parameters.Count: 3 }));

        return definition is null ? null : new ConcreteGenericMethodAnalysisContext(definition, [], [type]);
    }
}
