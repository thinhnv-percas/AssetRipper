using System.Collections.Generic;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// AssetRipper: recovers the type check il2cpp inlines in place of a call to
/// <c>il2cpp_codegen_class_is_assignable_from</c>, which is what every <c>is</c>, <c>as</c> and cast
/// in the source compiles to.
/// </summary>
/// <remarks>
/// <para>
/// The check walks the object's class hierarchy: <c>obj-&gt;klass-&gt;typeHierarchy[T-&gt;typeHierarchyDepth
/// - 1] == T</c>. That is five instructions reading three fields of <c>Il2CppClass</c>, none of which
/// has a managed meaning, so the whole thing arrived as a run of unnameable memory loads around a
/// comparison of two numbers — about 4500 of them on the test game.
/// </para>
/// <para>
/// The comparison is rewritten into a test of the result of an <c>isinst</c>, which is both what the
/// source said and what the surrounding branch already expects: a boolean.
/// </para>
/// </remarks>
public static class TypeCheckRecovery
{
    public static void Run(MethodAnalysisContext method)
    {
        var cfg = method.ControlFlowGraph!;
        var is32Bit = method.AppContext.Binary.is32Bit;
        var pointerSize = method.AppContext.Binary.PointerSizeBytes;

        if (!Il2CppClassUsefulOffsets.TryGetOffset("typeHierarchy", is32Bit, out var hierarchyOffset)
            || !Il2CppClassUsefulOffsets.TryGetOffset("typeHierarchyDepth", is32Bit, out var depthOffset))
            return;

        Il2CppClassUsefulOffsets.TryGetOffset("elementType", is32Bit, out var elementClassOffset);

        var definitions = new Dictionary<LocalVariable, Instruction>();

        foreach (var instruction in cfg.Instructions)
            if (instruction.Destination is LocalVariable destination)
                definitions[destination] = instruction;

        var changed = false;
        var walkedTargets = new HashSet<string>();

        foreach (var block in cfg.Blocks)
        {
            for (var i = 0; i < block.Instructions.Count; i++)
            {
                var instruction = block.Instructions[i];

                if (instruction.OpCode is not (OpCode.CheckEqual or OpCode.CheckNotEqual)
                    || instruction.Operands is not [LocalVariable result, _, _])
                    continue;

                var (left, right) = ComparedPair(instruction, definitions);

                IOperand? tested = null;
                TypeAnalysisContext? checkedType = null;

                // the compared type is whichever side names one, and the other side is the walk
                var (walk, wanted) = WantedType(right, definitions) is { } fromRight
                    ? (left, fromRight)
                    : WantedType(left, definitions) is { } fromLeft ? (right, fromLeft) : (null, null);

                if (walk is not null && wanted is not null)
                {
                    tested = MatchHierarchyWalk(walk, wanted, definitions, hierarchyOffset, depthOffset, pointerSize);
                    checkedType = wanted;
                }

                // an unbox names neither side outright: both read element_class, and the type is the
                // owner of the side that was not loaded off an object
                if (tested is null && MatchUnboxCheck(left, right, definitions, elementClassOffset) is var (unboxed, unboxedType) && unboxed is not null)
                {
                    tested = unboxed;
                    checkedType = unboxedType;
                }

                if (tested is null || checkedType is null)
                    continue;

                // `obj as T`, then the comparison becomes the null test the branch was already doing:
                // the walk found T when the object is one, so "walked != T" is "(obj as T) == null".
                var cast = new LocalVariable($"{result.Name}_asT", result.Register, checkedType);
                block.Instructions.Insert(i, new Instruction(-1, OpCode.IsInst, cast, checkedType, tested));
                definitions[cast] = block.Instructions[i];

                instruction.OpCode = instruction.OpCode == OpCode.CheckNotEqual ? OpCode.CheckEqual : OpCode.CheckNotEqual;
                instruction.SetOperands(result, cast, new Immediate(0));

                walkedTargets.Add(checkedType.FullName ?? checkedType.Name);
                i++;
                changed = true;
            }
        }

        // AssetRipper: every type this method performs a full check for, however that check was
        // recovered. The walk above is one route; the other is `Object::IsInst`, which
        // KeyFunctionRecovery rewrites into the same opcode from the call il2cpp makes when the
        // inlined fast path falls through. The shortcut below sits in front of *both*, so gating the
        // fold on the walk alone left it out of every body where the call was what got recovered -
        // which on the third game is most of them.
        foreach (var instruction in cfg.Instructions)
            if (instruction is { OpCode: OpCode.IsInst, Operands: [_, TypeAnalysisContext tested, ..] })
                walkedTargets.Add(tested.FullName ?? tested.Name);

        // Not gated on `changed`: the fold's precondition is that a full check for the type exists in
        // this method, not that this pass is what recovered it.
        changed |= FoldDepthRejections(cfg, definitions, walkedTargets, depthOffset);

        if (changed)
            DeadCodeEliminator.Run(cfg);
    }

    /// <summary>
    /// AssetRipper: the two values a comparison actually compares.
    /// </summary>
    /// <remarks>
    /// On A64 a <c>cmp</c> lifts to a bundle of flag computations rather than to one comparison,
    /// and equality is the zero flag of a subtraction: <c>Subtract d, a, b</c> then
    /// <c>CheckEqual z, d, 0</c>. That is <c>a == b</c> - the substitution is exact, not a
    /// heuristic - and without taking it every pattern stated in terms of the two operands misses
    /// on this architecture. The hierarchy walk is compared this way in every body on the test
    /// game, which is why the walk was never folded even where the shortcut in front of it was.
    /// </remarks>
    private static (IOperand Left, IOperand Right) ComparedPair(Instruction comparison,
        Dictionary<LocalVariable, Instruction> definitions)
    {
        if (comparison.Operands is [_, LocalVariable difference, Immediate { Value: 0 }]
            && Definition(definitions, difference) is { OpCode: OpCode.Subtract, Operands: [_, var minuend, var subtrahend] })
            return (minuend, subtrahend);

        return (comparison.Operands[1], comparison.Operands[2]);
    }

    /// <summary>
    /// Folds away the depth comparison that lets the walk be skipped.
    /// </summary>
    /// <remarks>
    /// The check begins <c>if (obj-&gt;klass-&gt;typeHierarchyDepth &lt; T-&gt;typeHierarchyDepth) it is not
    /// one</c>, which is a shortcut: the walk that follows reaches the same answer on its own. Saying
    /// the shortcut never applies leaves the answer alone and takes two more unnameable reads and a
    /// branch out of the body. Only a comparison whose right hand side is the depth of a type this
    /// method really did walk for is touched, so the direction is not being guessed at.
    /// </remarks>
    private static bool FoldDepthRejections(ISILControlFlowGraph cfg, Dictionary<LocalVariable, Instruction> definitions,
        HashSet<string> walkedTargets, long depthOffset)
    {
        var folded = false;

        foreach (var instruction in cfg.Instructions)
        {
            if (instruction.OpCode != OpCode.CheckLess || instruction.Operands is not [LocalVariable result, var left, var right])
                continue;

            // AssetRipper: the left side is the *object's* class depth, and an object's class is not
            // known at compile time, so requiring it to name a type meant this only ever fired on the
            // rare shape where both sides are a named type's - never on the ordinary one, which left
            // three unnameable reads and a branch around every `as` the pass had just put back. 252
            // of them on the third game.
            //
            // Folding is answer-preserving whatever the object turns out to be: if it is a T the two
            // depths are equal, if it derives from T its depth is greater, and if it is unrelated the
            // walk below reaches "not a T" on its own. Only the right side has to be a type this
            // method really did walk for, which is what keeps the direction from being guessed at.

            if (!IsDepthRead(left, definitions, depthOffset)
                || DepthOwner(right, definitions, depthOffset) is not { } target
                || !walkedTargets.Contains(target.FullName ?? target.Name))
                continue;

            // Both sides naming the same type used to be rejected as "a type compared with itself,
            // which says nothing" - but `d < d` is false, so folding it to false is exactly right,
            // and the case is not even what it looks like: the left side is the object's klass, and
            // it reads as the same type only because something upstream over-typed it from a local
            // that a cast had already narrowed. Rejecting on it took out every check in
            // `AnimationState.Apply`, which is the busiest of them.

            instruction.OpCode = OpCode.Move;
            instruction.SetOperands(result, new Immediate(0));
            folded = true;
        }

        return folded;
    }

    /// <summary>The type whose <c>typeHierarchyDepth</c> this operand reads.</summary>
    /// <summary>
    /// AssetRipper: whether <paramref name="operand"/> is a read of some class's
    /// <c>typeHierarchyDepth</c>, whether or not the class it is read off is a known one.
    /// </summary>
    private static bool IsDepthRead(IOperand operand, Dictionary<LocalVariable, Instruction> definitions, long depthOffset)
        => MemoryOperandOf(operand, definitions) is { Index: null, Scale: 0, Base: LocalVariable } memory
            && memory.Addend == depthOffset;

    private static TypeAnalysisContext? DepthOwner(IOperand operand, Dictionary<LocalVariable, Instruction> definitions, long depthOffset)
        => MemoryOperandOf(operand, definitions) is { Index: null, Scale: 0, Base: LocalVariable owner } memory && memory.Addend == depthOffset
            ? WantedType(owner, definitions)
            : null;

    /// <summary>
    /// The object this compares the boxed element class of, when that is what it compares.
    /// </summary>
    /// <remarks>
    /// Unboxing checks the class the box holds rather than walking a hierarchy: a value type is
    /// sealed, so <c>obj-&gt;klass-&gt;element_class == T-&gt;element_class</c> settles it in one comparison.
    /// Both sides read that field, which is what tells this shape apart from an array store check,
    /// where only one side does.
    /// </remarks>
    private static (IOperand? Subject, TypeAnalysisContext? Type) MatchUnboxCheck(IOperand left, IOperand right,
        Dictionary<LocalVariable, Instruction> definitions, long elementClassOffset)
    {
        if (elementClassOffset == 0)
            return (null, null);

        if (ElementClassOwner(left, definitions, elementClassOffset) is not { } leftOwner
            || ElementClassOwner(right, definitions, elementClassOffset) is not { } rightOwner)
            return (null, null);

        // the subject is the class read off an object; the other side names the type
        if (SubjectOf(leftOwner, definitions) is { } fromLeft && WantedType(rightOwner, definitions) is { } rightType)
            return (fromLeft, rightType);

        if (SubjectOf(rightOwner, definitions) is { } fromRight && WantedType(leftOwner, definitions) is { } leftType)
            return (fromRight, leftType);

        return (null, null);
    }

    /// <summary>The object a class pointer was read off, if it was read off one.</summary>
    private static LocalVariable? SubjectOf(LocalVariable classPointer, Dictionary<LocalVariable, Instruction> definitions)
        => Definition(definitions, classPointer) is { OpCode: OpCode.Move, Operands: [_, MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable subject }] }
            ? subject
            : null;

    /// <summary>The class pointer whose <c>element_class</c> this operand reads.</summary>
    private static LocalVariable? ElementClassOwner(IOperand operand, Dictionary<LocalVariable, Instruction> definitions, long elementClassOffset)
        => MemoryOperandOf(operand, definitions) is { Index: null, Scale: 0, Base: LocalVariable owner } memory && memory.Addend == elementClassOffset
            ? owner
            : null;

    /// <summary>
    /// The object whose hierarchy this operand walked, when it is that walk.
    /// </summary>
    private static IOperand? MatchHierarchyWalk(IOperand walked, TypeAnalysisContext wanted,
        Dictionary<LocalVariable, Instruction> definitions, long hierarchyOffset, long depthOffset, int pointerSize)
    {
        // [entry - pointerSize]: the last entry of the hierarchy, which is the type itself
        if (MemoryOperandOf(walked, definitions) is not { Index: null, Scale: 0, Base: LocalVariable entryLocal } entry
            || entry.Addend != -pointerSize)
            return null;

        if (Definition(definitions, entryLocal) is not { OpCode: OpCode.Add, Operands: [_, var left, var right] })
            return null;

        // one side is the hierarchy array, the other the depth shifted to an element offset
        var hierarchy = HierarchyBase(left, definitions, hierarchyOffset) ?? HierarchyBase(right, definitions, hierarchyOffset);
        var depth = ReferenceEquals(hierarchy, HierarchyBase(left, definitions, hierarchyOffset)) ? right : left;

        if (hierarchy is null || !IsDepthOf(depth, wanted, definitions, depthOffset))
            return null;

        // the class pointer came from the object, which is what the check is about
        if (Definition(definitions, hierarchy) is not { OpCode: OpCode.Move, Operands: [_, MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable subject }] })
            return null;

        return subject;
    }

    /// <summary>The class pointer whose <c>typeHierarchy</c> this operand loads.</summary>
    private static LocalVariable? HierarchyBase(IOperand operand, Dictionary<LocalVariable, Instruction> definitions, long hierarchyOffset)
        => MemoryOperandOf(operand, definitions) is { Index: null, Scale: 0, Base: LocalVariable owner } memory && memory.Addend == hierarchyOffset
            ? owner
            : null;

    /// <summary>Whether this operand is the wanted type's <c>typeHierarchyDepth</c>, shifted to an element offset.</summary>
    private static bool IsDepthOf(IOperand operand, TypeAnalysisContext wanted, Dictionary<LocalVariable, Instruction> definitions, long depthOffset)
    {
        if (operand is not LocalVariable shifted
            || Definition(definitions, shifted) is not { OpCode: OpCode.ShiftLeft, Operands: [_, var depth, Immediate] })
            return false;

        if (MemoryOperandOf(depth, definitions) is not { Index: null, Scale: 0, Base: LocalVariable owner } memory || memory.Addend != depthOffset)
            return false;

        // by name: the same type reached through two metadata usages is two contexts
        return WantedType(owner, definitions)?.FullName == wanted.FullName;
    }

    /// <summary>
    /// The type this operand names, whether it names it outright or holds its runtime class pointer.
    /// </summary>
    /// <remarks>
    /// At the point this pass runs the comparison is still against the local the class pointer was
    /// loaded into; only copy propagation, later, folds the type into the comparison itself.
    /// </remarks>
    private static TypeAnalysisContext? WantedType(IOperand operand, Dictionary<LocalVariable, Instruction> definitions)
        => operand switch
        {
            RuntimeMethodInfoAnalysisContext or RuntimeFieldInfoAnalysisContext => null,
            RuntimeClassTypeAnalysisContext { RepresentedType: { } represented } => represented,
            TypeAnalysisContext named => named,
            LocalVariable { Type: RuntimeClassTypeAnalysisContext { RepresentedType: { } typed } } => typed,
            LocalVariable local when Definition(definitions, local) is { OpCode: OpCode.Move, Operands: [_, var source] } && source != operand
                => WantedType(source, definitions),
            _ => null,
        };

    /// <summary>The memory operand this is, or the one the move that defined it read.</summary>
    private static MemoryOperand? MemoryOperandOf(IOperand operand, Dictionary<LocalVariable, Instruction> definitions)
        => operand switch
        {
            MemoryOperand memory => memory,
            LocalVariable local when Definition(definitions, local) is { OpCode: OpCode.Move, Operands: [_, MemoryOperand loaded] } => loaded,
            _ => null,
        };

    private static Instruction? Definition(Dictionary<LocalVariable, Instruction> definitions, LocalVariable local)
        => definitions.TryGetValue(local, out var definition) ? definition : null;
}
