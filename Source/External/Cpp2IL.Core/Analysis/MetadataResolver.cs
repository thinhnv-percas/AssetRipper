using Cpp2IL.Core;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Cpp2IL.Core.Extensions;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.Il2CppApiFunctions;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;
using LibCpp2IL;

namespace Cpp2IL.Core.Analysis;

public static class MetadataResolver
{
    public static void ResolveAll(MethodAnalysisContext method)
    {
        ResolveStringLiteralAccessors(method);
        ResolveCalls(method);
        ResolveGetter(method);
        ResolveMetadataUsages(method);
    }

    private static void ResolveStringLiteralAccessors(MethodAnalysisContext method)
    {
        var libContext = method.AppContext.LibCpp2IlContext;

        var definitions = new Dictionary<LocalVariable, Instruction>();
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
            if (instruction.Destination is LocalVariable destination)
                definitions[destination] = instruction;

        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            if (instruction.OpCode != OpCode.Call || instruction.Operands[1] is not LocalVariable result)
                continue;

            for (var i = 2; i < instruction.Operands.Count; i++)
            {
                if (LiteralSlotAddress(instruction.Operands[i], definitions) is not { } address
                    || libContext.GetLiteralByAddress(address) is not { } literal)
                    continue;

                instruction.OpCode = OpCode.Move;
                instruction.SetOperands(result, new StringLiteral(literal));
                break;
            }
        }
    }

    private static ulong? LiteralSlotAddress(IOperand operand, Dictionary<LocalVariable, Instruction> definitions) =>
        operand switch
        {
            Immediate immediate => immediate.UnsignedValue,
            LocalVariable local when definitions.TryGetValue(local, out var definition)
                && definition is { OpCode: OpCode.Move, Operands: [_, Immediate immediate] } => immediate.UnsignedValue,
            _ => null,
        };

    /// <summary>
    /// Resolves <c>Move local, [absoluteAddress]</c> loads of IL2CPP metadata-usage globals into a
    /// strongly-typed operand: a string literal, a <see cref="TypeAnalysisContext"/> (an Il2CppType*/
    /// Il2CppClass* usage) or, for a MethodInfo* usage, a <see cref="RuntimeMethodInfoAnalysisContext"/>
    /// naming the method it refers to (also used to type the local - see <see cref="LocalVariables"/>),
    /// or likewise a <see cref="RuntimeFieldInfoAnalysisContext"/> for a FieldInfo* usage.
    /// </summary>
    private static void ResolveMetadataUsages(MethodAnalysisContext method)
    {
        var libContext = method.AppContext.LibCpp2IlContext;
        var slotHolders = FindUsageSlotHolders(method);

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode != OpCode.Move)
                continue;

            if (instruction.Operands[0] is not LocalVariable)
                continue;

            var address = instruction.Operands[1] switch
            {
                MemoryOperand { Base: null, Index: null, Scale: 0 } memory => (ulong)memory.Addend,
                MemoryOperand { Base: LocalVariable holder, Index: null, Scale: 0 } memory
                    when slotHolders.TryGetValue(holder, out var slot) => (ulong)((long)slot + memory.Addend),
                Immediate immediate => immediate.UnsignedValue,
                _ => 0ul,
            };

            if (address == 0)
                continue;

            // String literal.
            var stringLiteral = libContext.GetLiteralByAddress(address);
            if (stringLiteral != null)
            {
                instruction.SetOperand(1, new StringLiteral(stringLiteral));
                continue;
            }

            // Type metadata usage (Il2CppType* / Il2CppClass*).
            if (method.DeclaringType is { } declaringType)
            {
                var typeGlobal = libContext.GetTypeGlobalByAddress(address);
                if (typeGlobal != null)
                {
                    instruction.SetOperand(1, declaringType.AppContext.ResolveIl2CppType(typeGlobal));
                    continue;
                }
            }

            // Method metadata usage (MethodInfo*). On metadata v27+ GetMethodGlobalByAddress can return
            // any global, so confirm it is actually a method before resolving - the resolver's switch
            // throws on other usage kinds.
            var methodUsage = libContext.GetMethodGlobalByAddress(address);
            if (methodUsage?.Type is MetadataUsageType.MethodDef or MetadataUsageType.MethodRef
                && method.AppContext.ResolveContextForMethod(methodUsage) is { DeclaringType: { } methodDeclaringType } methodContext)
            {
                instruction.SetOperand(1, new RuntimeMethodInfoAnalysisContext(methodContext, methodDeclaringType.DeclaringAssembly));
                continue;
            }

            // Field metadata usage (FieldInfo*), e.g. the RuntimeFieldHandle passed to InitializeArray.
            if (libContext.GetRawFieldGlobalByAddress(address) is { Type: MetadataUsageType.FieldInfo } fieldUsage
                && method.AppContext.ResolveContextForField(fieldUsage.AsField()) is { DeclaringType.DeclaringAssembly: { } fieldAssembly } fieldContext)
                instruction.SetOperand(1, new RuntimeFieldInfoAnalysisContext(fieldContext, fieldAssembly));
        }
    }

    /// <summary>
    /// AssetRipper: locals holding the address of a metadata usage slot rather than the slot's value.
    /// </summary>
    /// <remarks>
    /// Position independent code does not name a usage slot directly. The address baked into the
    /// method body is a pointer to the slot, so reaching the slot takes two loads: one to get its
    /// address and one to read it. Only the second is the usage, and without knowing that the first
    /// one produced an address, the second reads as a load through an untyped pointer — which is how
    /// a static field access lost the class it belonged to, and with it the field.
    ///
    /// A hop is only taken when the address in the code is not itself a usage and the address it
    /// holds is, so nothing that already resolves is touched. The load of the address is left as the
    /// constant it is, since it is bookkeeping the source never had.
    /// </remarks>
    private static Dictionary<LocalVariable, ulong> FindUsageSlotHolders(MethodAnalysisContext method)
    {
        var libContext = method.AppContext.LibCpp2IlContext;
        var holders = new Dictionary<LocalVariable, ulong>();

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction is not { OpCode: OpCode.Move, Operands: [LocalVariable destination, MemoryOperand { Base: null, Index: null, Scale: 0 } memory] })
                continue;

            var address = (ulong)memory.Addend;

            if (address == 0 || IsUsage(address))
                continue;

            if (!libContext.Binary.TryMapVirtualAddressToRaw(address, out var raw) || raw < 0 || raw >= libContext.Binary.RawLength)
                continue;

            ulong slot;
            try
            {
                slot = libContext.Binary.ReadPointerAtVirtualAddress(address);
            }
            catch
            {
                continue;
            }

            if (slot == 0 || !IsUsage(slot))
                continue;

            holders[destination] = slot;
            instruction.SetOperand(1, new Immediate(unchecked((long)slot)));
        }

        return holders;

        bool IsUsage(ulong address)
        {
            try
            {
                return libContext.GetAnyGlobalByAddress(address)?.IsValid == true || libContext.GetLiteralByAddress(address) != null;
            }
            catch
            {
                return false;
            }
        }
    }

    /// <summary>
    /// Replaces every <c>[base + addend]</c> memory operand whose base is a typed local with a
    /// <see cref="FieldReference"/> to the field at that offset. Returns whether any operand was
    /// resolved this pass, so the type/field fixpoint can detect convergence: as more bases become
    /// typed (a field load types its result, which is the base of the next load), more offsets
    /// resolve, so this is re-run until it stops finding new fields.
    /// </summary>
    /// <summary>
    /// AssetRipper: <c>[Il2CppClass&lt;T[]&gt; + element_class]</c> is the runtime class of T, which the
    /// metadata already names.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the array store check: <c>stelem.ref</c> compiles to a call testing the value against
    /// the array's element class, and the element class is reached through the array's own class
    /// rather than named by a metadata usage, because the array type is only known at runtime. The
    /// load has no managed meaning on its own, so it reached the generator as an unresolved memory
    /// operand — the largest single group of them on the game measured, at 2365.
    /// </para>
    /// <para>
    /// Once the base is typed the element class is not unknown at all: it is exactly the runtime class
    /// of the array's element type, which is what a metadata usage of that type would have produced.
    /// </para>
    /// </remarks>
    public static bool ResolveElementClassLoads(MethodAnalysisContext method)
    {
        if (!Il2CppClassUsefulOffsets.TryGetOffset("elementType", method.AppContext.Binary.is32Bit, out var elementClassOffset))
            return false;

        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                if (instruction.Operands[i] is not MemoryOperand { Index: null, Scale: 0, Base: LocalVariable arrayClass } memory
                    || memory.Addend != elementClassOffset
                    || arrayClass.Type is not RuntimeClassTypeAnalysisContext { RepresentedType: SzArrayTypeAnalysisContext { ElementType: { } elementType } })
                    continue;

                instruction.SetOperand(i, elementType);
                changed = true;

                // the same ground truth SeedRuntimeClassTypes applies to a metadata usage load, which
                // has already run by the time this can fire
                if (i == 1 && instruction.OpCode == OpCode.Move && instruction.Operands[0] is LocalVariable loaded)
                    loaded.Type = new RuntimeClassTypeAnalysisContext(elementType, elementType.DeclaringAssembly);
            }
        }

        return changed;
    }

    public static bool ResolveFieldOffsets(MethodAnalysisContext method)
    {
        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                var operand = instruction.Operands[i];

                if (operand is not MemoryOperand memory)
                    continue;

                // Has to be [base (local) + addend (field offset)]
                if (memory.Index != null || memory.Scale != 0)
                    continue;

                if (memory.Base is not LocalVariable local || local?.Type == null)
                    continue;

                // check if static field access
                var staticOwner = (local.Type as StaticFieldStorageTypeAnalysisContext)?.OwnerType;
                var owner = staticOwner ?? local.Type;
                var genericOwner = owner as GenericInstanceTypeAnalysisContext;

                FieldAnalysisContext? field;
                if (genericOwner != null && staticOwner == null)
                {
                    // metadata has all-0 offsets for generic definitions, so recompute layout.
                    // AssetRipper: with the instance's arguments, so a field of the type's own generic
                    // parameter is sized as what it is. This used to bail whenever any argument was a
                    // value type, which lost every field of a List<int> - none of whose fields is of
                    // type T, so nothing about the layout depended on the argument at all.
                    field = GenericInstanceFieldLayout.FindFieldAtOffset(genericOwner.GenericType, memory.Addend, genericOwner.GenericArguments);
                }
                else if (staticOwner == null && owner.GenericParameters.Count > 0)
                {
                    field = GenericInstanceFieldLayout.FindFieldAtOffset(owner, memory.Addend);
                }
                else
                {
                    // an inherited field exists on the base type but sits at the same offset in the
                    // derived layout, so the whole chain is searched
                    field = null;
                    for (var candidateOwner = genericOwner?.GenericType ?? owner; candidateOwner != null && field == null; candidateOwner = candidateOwner.BaseType)
                        field = candidateOwner.Fields.FirstOrDefault(f => f.IsStatic == (staticOwner != null)
                            && (f.Attributes & FieldAttributes.Literal) == 0 // consts have no storage but their metadata offset is 0, which would match
                            && f.BackingData?.FieldOffset == memory.Addend);
                }

                // The offset can land inside a value type field rather than on a field boundary, which
                // is a nested access: a Color at 0x38 makes a load from 0x3C its g component. And an
                // offset that lands exactly on a field is not by itself proof that the whole field was
                // accessed - four bytes written at the offset of a twenty-four byte struct reached its
                // first member, and calling that a write of the struct gives an int assigned to a
                // struct. Only a reference typed base is taken, because a store through the chain needs
                // the address of the outer field and a value typed local on the stack is a copy.
                if ((field == null || NarrowerThan(field, memory.Size, method))
                    && staticOwner == null && genericOwner == null && !owner.IsValueType && owner.GenericParameters.Count == 0)
                {
                    var path = FindNestedFieldPath(owner, memory.Addend, memory.Size, method);

                    if (path is { Count: > 1 })
                    {
                        if (field != null)
                            System.Threading.Interlocked.Increment(ref NarrowWritesRefined);

                        instruction.SetOperand(i, new FieldReference(path[^1], local, (int)memory.Addend)
                        {
                            ContainingFields = path.GetRange(0, path.Count - 1),
                            AccessSize = memory.Size,
                        });
                        changed = true;
                        continue;
                    }

                    if (field != null)
                        System.Threading.Interlocked.Increment(ref NarrowWritesUnresolved);

                    if (field == null)
                    {
                        if (path is not null)
                        {
                            instruction.SetOperand(i, new FieldReference(path[0], local, (int)memory.Addend) { AccessSize = memory.Size });
                            changed = true;
                        }

                        continue;
                    }
                }

                // No field at this offset and no chain reaching it, so there is nothing to name. This
                // has to hold whether or not the search above was allowed to run: the code below
                // instantiates the field on the owner's generic arguments and cannot take a null.
                if (field == null)
                    continue;

                // make sure we have a full GIT for field access. open type is bad.
                if (genericOwner != null)
                    field = new ConcreteGenericFieldAnalysisContext(field, genericOwner);

                instruction.SetOperand(i, new FieldReference(field, local, (int)memory.Addend) { AccessSize = memory.Size });
                changed = true;
            }
        }

        return changed;
    }

    /// <summary>
    /// AssetRipper: whether the access is narrower than the field its offset lands on, so that what it
    /// reached may be a member inside rather than the field itself.
    /// </summary>
    /// <summary>AssetRipper: writes narrower than the field their offset lands on that named a member inside it.</summary>
    public static int NarrowWritesRefined;

    /// <summary>AssetRipper: the same, but where no member accounted for the width, so the field stood.</summary>
    public static int NarrowWritesUnresolved;

    private static bool NarrowerThan(FieldAnalysisContext field, int accessSize, MethodAnalysisContext method)
    {
        if (accessSize <= 0)
            return false; //The lifter did not say, so the width is no evidence either way

        var size = SizeOf(field, method);
        return size > 0 && accessSize < size;
    }

    private static long SizeOf(FieldAnalysisContext field, MethodAnalysisContext method)
    {
        var pointerSize = method.AppContext.Binary.is32Bit ? 4 : 8;
        var type = field.FieldType;

        if (!type.IsValueType)
            return pointerSize;

        var unboxed = TypeSizes.UnboxedSize(type, pointerSize);
        return unboxed > 0 ? unboxed : 0;
    }

    /// <summary>
    /// Finds the chain of fields that an access of <paramref name="accessSize"/> bytes at
    /// <paramref name="targetOffset"/> reaches, outermost first. Null when the offset reaches none.
    /// </summary>
    private static List<FieldAnalysisContext>? FindNestedFieldPath(TypeAnalysisContext owner, long targetOffset,
        int accessSize, MethodAnalysisContext method)
        => NestedFieldResolver.Find<TypeAnalysisContext, FieldAnalysisContext>(
            owner,
            targetOffset,
            accessSize,
            InstanceFieldsWithOffsets,
            field => SizeOf(field, method),
            InteriorOf);

    /// <summary>
    /// Every instance field of the type and of everything it inherits from, at its offset in this
    /// layout - an inherited field sits at its own offset in the derived layout, so the chain is
    /// walked rather than the offsets added.
    /// </summary>
    private static IEnumerable<(FieldAnalysisContext Field, long Offset)> InstanceFieldsWithOffsets(TypeAnalysisContext owner)
    {
        for (var candidate = owner; candidate != null; candidate = candidate.BaseType)
        {
            foreach (var field in candidate.Fields)
            {
                if (field.IsStatic || (field.Attributes & FieldAttributes.Literal) != 0)
                    continue;

                if (field.BackingData is { } data)
                    yield return (field, data.FieldOffset);
            }
        }
    }

    /// <summary>
    /// The type to descend into for a field, or null when it has no interior an offset can land in.
    /// An enum is its underlying integer and a generic parameter has no layout here.
    /// </summary>
    private static TypeAnalysisContext? InteriorOf(FieldAnalysisContext field)
    {
        var type = field.FieldType;

        return type.IsValueType && !type.IsEnumType && type.GenericParameters.Count == 0 ? type : null;
    }

    private static void ResolveCalls(MethodAnalysisContext method)
    {
        foreach (var block in method.ControlFlowGraph!.Blocks)
        {
            if (block.BlockType != BlockType.Call && block.BlockType != BlockType.TailCall)
                continue;

            var callInstruction = block.Instructions[^1];
            if (callInstruction.Operands[0] is not Immediate dest)
                continue;

            var target = dest.UnsignedValue;

            var keyFunctionAddresses = method.AppContext.GetOrCreateKeyFunctionAddresses();

            if (keyFunctionAddresses.IsKeyFunctionAddress(target))
            {
                HandleKeyFunction(method.AppContext, callInstruction, target, keyFunctionAddresses);

                if (target == keyFunctionAddresses.il2cpp_codegen_initialize_runtime_metadata_inline
                    && callInstruction is { OpCode: OpCode.Call, Operands: [_, var initResult, var handle, ..] })
                {
                    callInstruction.OpCode = OpCode.Move;
                    callInstruction.SetOperands(initResult, handle);
                }

                continue;
            }

            //Non-key function call. Try to find a single match
            if (!method.AppContext.MethodsByAddress.TryGetValue(target, out var targetMethods))
            {
                // AssetRipper: a generated body reaches a runtime helper through a veneer — one branch
                // instruction sitting between the runtime and the generated code — so the address in
                // the call is never the helper's. Nothing that looks an address up finds anything
                // without the hop, which is why the busiest unresolved call targets in a game all sit
                // in one small range. Take it, then ask all the same questions again.
                var thunked = FollowThunks(method.AppContext, target);

                if (thunked != target)
                {
                    if (keyFunctionAddresses.IsKeyFunctionAddress(thunked))
                    {
                        HandleKeyFunction(method.AppContext, callInstruction, thunked, keyFunctionAddresses);
                        continue;
                    }

                    if (method.AppContext.MethodsByAddress.ContainsKey(thunked))
                        target = thunked;
                }

                if (!method.AppContext.MethodsByAddress.TryGetValue(target, out targetMethods))
                {
                    // Not a managed method at all. It may be one of the runtime helpers built around an
                    // exception type, which either throw it themselves or build it and hand it back for
                    // the caller to raise.
                    if (TryRewriteAsThrow(method, callInstruction, target) || (thunked != target && TryRewriteAsThrow(method, callInstruction, thunked)))
                        continue;

                    continue;
                }
            }

            // Duplicated/Shared method bodies are resolved later in ResolveCallsViaMethodInfo/ResolveAmbiguousCalls.
            if (targetMethods is not [{ } singleTargetMethod])
                continue;

            callInstruction.SetOperand(0, singleTargetMethod);
            singleTargetMethod.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(callInstruction, singleTargetMethod, method);
        }

        method.ControlFlowGraph.MergeCallBlocks();
    }

    /// <summary>
    /// Resolves calls whose address maps to more than one method by matching the receiver's known
    /// type against the candidates' declaring types. Runs inside the type/field fixpoint and so
    /// re-fires as receivers become typed - a resolved call types its return value, which can type
    /// the receiver of a further call. Returns whether any call was resolved this pass.
    ///
    /// Conservative by design: it commits only when exactly one non-static candidate's declaring
    /// type matches the receiver's type. Anything still untyped or ambiguous is left for a later
    /// pass, or left unresolved - it never guesses.
    /// </summary>
    public static bool ResolveAmbiguousCalls(MethodAnalysisContext method)
    {
        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (!instruction.IsCall)
                continue;

            // A resolved call's target is a method/key-function name; only unresolved ones are still numeric.
            if (instruction.Operands[0] is not Immediate target)
                continue;

            if (!method.AppContext.MethodsByAddress.TryGetValue(target.UnsignedValue, out var candidates) || candidates.Count < 2)
                continue;

            // e.g. string.Equals and string.op_Equality, identical params, instance type, and bodies are shared
            // we can't differentiate which is being called but it doesn't matter
            if (AreInterchangeable(candidates))
            {
                var preferred = PreferredOf(candidates);
                instruction.SetOperand(0, preferred);
                preferred.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(instruction, preferred, method);
                changed = true;
                continue;
            }

            if (GetReceiver(instruction) is not { Type: { } receiverType } receiver)
                continue;

            // Prefer picking base ctor if we are a ctor
            var callerIsCtor = method.Name == ".ctor" && receiver.IsThis;

            // Handle methods with shared bodies
            var match = default(MethodAnalysisContext);

            for (var type = receiverType; type != null && match == null; type = type.BaseType)
            {
                var matches = candidates.Where(c => !c.IsStatic && IsSameType(c.DeclaringType, type)).ToList();

                if (matches.Count > 1 && callerIsCtor)
                    matches = matches.Where(c => c.Name == ".ctor").ToList();

                if (matches.Count > 1)
                    break;

                match = matches.SingleOrDefault();
            }

            if (match == null)
                continue;

            instruction.SetOperand(0, match);
            match.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(instruction, match, method);
            changed = true;
        }

        return changed;
    }

    private static bool AreInterchangeable(List<MethodAnalysisContext> candidates)
    {
        var first = candidates[0];

        return candidates.All(c => c.IsStatic == first.IsStatic
            && ReferenceEquals(c.DeclaringType, first.DeclaringType)
            && ReferenceEquals(c.ReturnType, first.ReturnType)
            && c.Parameters.Count == first.Parameters.Count
            && SameParameterTypes(c, first));
    }

    private static bool SameParameterTypes(MethodAnalysisContext a, MethodAnalysisContext b)
    {
        for (var i = 0; i < a.Parameters.Count; i++)
        {
            if (!ReferenceEquals(a.Parameters[i].ParameterType, b.Parameters[i].ParameterType))
                return false;
        }

        return true;
    }

    // Prefer operators if possible
    private static MethodAnalysisContext PreferredOf(List<MethodAnalysisContext> candidates) =>
        candidates.FirstOrDefault(c => c.Name.StartsWith("op_")) ?? candidates[0];

    // The receiver ('this') of a call is the first integer-slot argument: operand 1 for CallVoid
    // (after the target), operand 2 for Call (after the target and the return value).
    // A value type receiver is passed byref, so it arrives as an AddressOf over the local.
    private static LocalVariable? GetReceiver(Instruction call)
    {
        var index = call.OpCode == OpCode.CallVoid ? 1 : 2;

        return index < call.Operands.Count
            ? call.Operands[index] switch
            {
                LocalVariable local => local,
                AddressOf { Target: LocalVariable addressed } => addressed,
                _ => null
            }
            : null;
    }

    // Concrete generic method contexts build their declaring type fresh rather than via the
    // GetOrCreate cache, so generic instances also need comparing structurally.
    // TODO Fix this, concrete generic methods should use GetOrCreate
    private static bool IsSameType(TypeAnalysisContext? a, TypeAnalysisContext? b)
    {
        if (ReferenceEquals(a, b))
            return true;

        if (a is not GenericInstanceTypeAnalysisContext leftInstance
            || b is not GenericInstanceTypeAnalysisContext rightInstance
            || !ReferenceEquals(leftInstance.GenericType, rightInstance.GenericType)
            || leftInstance.GenericArguments.Count != rightInstance.GenericArguments.Count)
            return false;

        for (var i = 0; i < leftInstance.GenericArguments.Count; i++)
        {
            if (!IsSameType(leftInstance.GenericArguments[i], rightInstance.GenericArguments[i]))
                return false;
        }

        return true;
    }

    /// <summary>
    /// Resolves any Call (theoretically should always be a CallVoid) target directly after a Newobj to a constructor call.
    /// </summary>
    public static bool ResolveConstructorCalls(MethodAnalysisContext method)
    {
        var definitions = new Dictionary<LocalVariable, Instruction>();
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
            if (instruction.Destination is LocalVariable definition)
                definitions[definition] = instruction;

        var changed = false;

        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            if (!instruction.IsCall || instruction.Operands[0] is not Immediate callTarget)
                continue;

            if (!method.AppContext.MethodsByAddress.TryGetValue(callTarget.UnsignedValue, out var candidates))
                continue;

            if (GetReceiver(instruction) is not { } receiver || AllocatedType(receiver, definitions) is not { } allocatedType)
                continue;

            var constructor = candidates.FirstOrDefault(c => !c.IsStatic && c.Name == ".ctor" && ReferenceEquals(c.DeclaringType, allocatedType))
                              ?? FindConstructorForSharedBody(allocatedType, candidates);
            if (constructor == null)
                continue;

            instruction.SetOperand(0, constructor);
            constructor.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(instruction, constructor, method);
            changed = true;
        }

        return changed;
    }

    private static MethodAnalysisContext? FindConstructorForSharedBody(TypeAnalysisContext allocatedType, List<MethodAnalysisContext> candidates)
    {
        var candidateParamCounts = new HashSet<int>(candidates
            .Where(c => c is { IsStatic: false, Name: ".ctor" })
            .Select(c => c.Parameters.Count));

        if (candidateParamCounts.Count == 0)
            return null;

        var definition = allocatedType is GenericInstanceTypeAnalysisContext genericInstance ? genericInstance.GenericType : allocatedType;
        var matches = definition.Methods
            .Where(m => m is { IsStatic: false, Name: ".ctor" } && candidateParamCounts.Contains(m.Parameters.Count))
            .ToList();

        if (matches is not [{ } match])
            return null;

        return allocatedType is GenericInstanceTypeAnalysisContext instance
            ? new ConcreteGenericMethodAnalysisContext(match, instance.GenericArguments, [])
            : match;
    }

    // Follow SSA copies from a local back to the Newobj that produced the value
    private static TypeAnalysisContext? AllocatedType(LocalVariable local, Dictionary<LocalVariable, Instruction> definitions)
    {
        var visited = new HashSet<LocalVariable>();

        while (visited.Add(local) && definitions.TryGetValue(local, out var definition))
        {
            switch (definition.OpCode)
            {
                case OpCode.Newobj:
                    return (definition.Operands[0] as LocalVariable)?.Type;
                case OpCode.Move when definition.Operands[1] is LocalVariable source:
                    local = source;
                    continue;
            }

            break;
        }

        return null;
    }

    /// <summary>
    /// Resolves calls whose address maps to more than one method by reading the runtime
    /// <c>MethodInfo*</c> the caller passes in, if there is one.
    /// </summary>
    public static bool ResolveCallsViaMethodInfo(MethodAnalysisContext method)
    {
        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (!instruction.IsCall)
                continue;

            if (instruction.Operands[0] is not Immediate target)
                //Already resolved
                continue;

            if (GetMethodInfoArgument(instruction) is not { RepresentedMethod: { } representedMethod })
                //No MethodInfo to work with
                continue;

            if (!method.AppContext.MethodsByAddress.TryGetValue(target.UnsignedValue, out var candidates))
            {
                // Some shared generic bodies aren't in the address map at all (todo investigate?).
                // Il2cpp still passes the concrete MethodInfo as the hidden final parameter, so we can use a methodof there if we have one.
                // However, make sure it isn't our OWN hidden MethodInfo arg, because that would turn all unknown calls into recursion
                if (ReferenceEquals(representedMethod, method))
                    continue;

                var firstArg = instruction.OpCode == OpCode.CallVoid ? 1 : 2;
                var hiddenParamIndex = firstArg
                    + (representedMethod.AppContext.InstructionSet.CallingConventionResolver?.ReturnsViaHiddenBuffer(representedMethod) == true ? 1 : 0)
                    + (representedMethod.IsStatic ? 0 : 1) + representedMethod.Parameters.Count;

                if (hiddenParamIndex >= instruction.Operands.Count
                    || AsMethodInfo(instruction.Operands[hiddenParamIndex]) == null)
                    continue;

                instruction.SetOperand(0, representedMethod);
                representedMethod.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(instruction, representedMethod, method);
                changed = true;
                continue;
            }

            if (candidates.Count < 2)
                continue;

            //Try to actually match on the method name so we don't just replace a call with something else.
            var representedBase = BaseMethodOf(representedMethod);
            if (!candidates.Any(candidate => ReferenceEquals(BaseMethodOf(candidate), representedBase)))
                continue;

            instruction.SetOperand(0, representedMethod);
            representedMethod.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(instruction, representedMethod, method);
            changed = true;
        }

        return changed;
    }

    // Offset of Il2CppClass::vtable, VirtualInvokeData entries of {methodPtr, MethodInfo*}.
    // TODO this is almost certainly not correct on every version
    
    // Resolves virtual dispatch through <c>[klass + vtableOffset + slot * sizeof(VirtualInvokeData)]</c>
    // as long as the klass local's represented type is known.
    public static bool ResolveVirtualCalls(MethodAnalysisContext method)
    {
        var pointerSize = method.AppContext.Binary.PointerSizeBytes;

        // AssetRipper: was a hardcoded 0x138, which is where the vtable starts on 2022.3 and not on
        // 2019.2, where it is at 0x130. Eight bytes out is not a near miss: the slot index stops
        // dividing evenly and every virtual call through a vtable goes unresolved, which is how
        // `sb.Append(x)` came out as a call to an offset off an Il2CppClass.
        var vtableOffset = (long)Il2CppClassUsefulOffsets.GetVtableOffset(method.AppContext.MetadataVersion, method.AppContext.Binary.is32Bit);
        var invokeDataSize = 2L * pointerSize;
        var changed = false;

        var loads = new Dictionary<LocalVariable, MemoryOperand>();
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode == OpCode.Move
                && instruction.Operands[0] is LocalVariable destination
                && instruction.Operands[1] is MemoryOperand { Index: null, Scale: 0 } load)
                loads[destination] = load;
        }

        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            if (instruction.OpCode != OpCode.IndirectCall)
                continue;

            if (SlotLoad(instruction.Operands[0]) is not { } target
                || target.Base is not LocalVariable { Type: RuntimeClassTypeAnalysisContext { RepresentedType: { } receiverType } } klassLocal)
                continue;

            var offset = target.Addend - vtableOffset;
            if (offset < 0 || offset % invokeDataSize != 0)
                continue;

            var slot = (int)(offset / invokeDataSize);
            if (ResolveVTableSlot(method.AppContext, receiverType, slot) is not { } resolved)
                continue;

            var assembly = resolved.DeclaringType?.DeclaringAssembly ?? method.DeclaringType?.DeclaringAssembly;

            instruction.OpCode = OpCode.Call; // same operand layout as IndirectCall, and we've resolved it now
            instruction.SetOperand(0, resolved);
            resolved.AppContext.InstructionSet.CallingConventionResolver?.RemapRawArguments(instruction, resolved, method);

            // the MethodInfo field is also the same method, name it, for cleanliness and so it can
            // serve as a hidden final parameter if needed
            for (var i = 1; i < instruction.Operands.Count && assembly != null; i++)
            {
                if (SlotLoad(instruction.Operands[i]) is { } methodInfoLoad
                    && ReferenceEquals(methodInfoLoad.Base, klassLocal)
                    && methodInfoLoad.Addend == target.Addend + pointerSize)
                    instruction.SetOperand(i, new RuntimeMethodInfoAnalysisContext(resolved, assembly));
            }

            changed = true;
        }

        return changed;

        MemoryOperand? SlotLoad(IOperand operand) => operand switch
        {
            MemoryOperand { Index: null, Scale: 0 } inlined => inlined,
            LocalVariable local when loads.TryGetValue(local, out var load) => load,
            _ => null
        };
    }

    private static MethodAnalysisContext? ResolveVTableSlot(ApplicationAnalysisContext appContext, TypeAnalysisContext type, int slot)
    {
        var definition = (type as GenericInstanceTypeAnalysisContext)?.GenericType.Definition ?? type.Definition;

        if (definition == null || slot >= definition.VtableCount)
            return null;

        if (appContext.ResolveContextForMethod(definition.VTable[slot]) is { } implementation)
            return implementation;

        // an abstract method has no implementation, try to resolve it
        for (var declarer = type; declarer != null; declarer = declarer.BaseType)
        {
            if (declarer.Methods.FirstOrDefault(m => m.Definition?.slot == slot) is { } declaration)
                return declaration;
        }

        return null;
    }

    private static MethodAnalysisContext BaseMethodOf(MethodAnalysisContext method) =>
        method is ConcreteGenericMethodAnalysisContext { BaseMethodContext: { } baseMethod } ? baseMethod : method;

    private static RuntimeMethodInfoAnalysisContext? GetMethodInfoArgument(Instruction call)
    {
        var firstArg = call.OpCode == OpCode.CallVoid ? 1 : 2;

        for (var i = call.Operands.Count - 1; i >= firstArg; i--)
        {
            if (AsMethodInfo(call.Operands[i]) is { } methodInfo)
                return methodInfo;
        }

        return null;
    }

    /// <summary>
    /// AssetRipper: how many loads were folded back onto the base whose address an earlier
    /// instruction computed.
    /// </summary>
    public static int ComputedFieldAddressesFolded;

    private const int MaximumAddressFoldDepth = 4;

    /// <summary>
    /// AssetRipper: <c>[t + K]</c> where <c>t = base + J</c> is <c>[base + (J + K)]</c>, which is how a
    /// field is reached when the machine computes its address before loading through it.
    /// </summary>
    /// <remarks>
    /// The compiler does this whenever the address is wanted for more than one load, or is passed on,
    /// and nothing typed the intermediate - so the load off it did not resolve, and neither did the
    /// load off *what it produced*, because that had no type either. One missing rule cost three
    /// resolutions in <c>GamePlayController.RewindPlay</c>:
    /// <code>
    /// 54 Add      v73, this (GamePlayController), 88
    /// 69 Move     v104, [v73]
    /// 77 CallVoid GameObject.SetActive, [v104+58], 0
    /// </code>
    /// which came out as <c>(nint)this + 88</c> and <c>((GameObject)0).SetActive(false)</c> for what
    /// the source writes as one field access.
    ///
    /// This is the same shape <see cref="ArrayRecovery.RecoverComputedAccesses"/> handles for an
    /// element, and it belongs in the same place - inside the type resolution fixpoint, because it
    /// needs the base typed and what it produces types the next base. Only a constant is folded: an
    /// <c>Add</c> of two locals is an index computation, which is the array path's business. Nothing
    /// here decides which field the combined offset names; it only presents the base and the addend
    /// that the machine really used, and <see cref="ResolveFieldOffsets"/> validates the rest as it
    /// always did.
    /// </remarks>
    public static bool FoldComputedFieldAddresses(MethodAnalysisContext method)
    {
        var definitions = new Dictionary<LocalVariable, Instruction>();

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
            if (instruction.Destination is LocalVariable destination)
                definitions[destination] = instruction;

        var changed = false;

        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                // Only a base nothing typed: a typed one already resolves, and rewriting it would
                // move an access that is already right.
                if (instruction.Operands[i] is not MemoryOperand { Index: null, Scale: 0, Base: LocalVariable { Type: null } computed } memory)
                    continue;

                if (ComputedBase(computed, memory.Addend, definitions) is not var (folded, addend))
                    continue;

                instruction.SetOperand(i, new MemoryOperand(folded, null, addend, 0, memory.Size));
                System.Threading.Interlocked.Increment(ref ComputedFieldAddressesFolded);
                changed = true;
            }
        }

        return changed;
    }

    /// <summary>
    /// AssetRipper: the operand a chain of constant additions started from, and the total offset,
    /// or null when the chain does not start at something with a type.
    /// </summary>
    private static (IOperand Base, long Addend)? ComputedBase(LocalVariable computed, long addend,
        Dictionary<LocalVariable, Instruction> definitions)
    {
        for (var depth = 0; depth < MaximumAddressFoldDepth; depth++)
        {
            if (!definitions.TryGetValue(computed, out var definition)
                || definition is not { OpCode: OpCode.Add, Operands: [_, var left, var right] })
                return null;

            // One side is the constant; the other carries the address. Two locals is an index
            // computation and not this.
            var (carried, constant) = (left, right) switch
            {
                (_, Immediate immediateRight) => (left, immediateRight.Value),
                (Immediate immediateLeft, _) => (right, immediateLeft.Value),
                _ => (null, 0L),
            };

            if (carried == null)
                return null;

            addend += constant;

            if (addend < 0)
                return null;

            switch (carried)
            {
                // A base with a type is where the chain ends and the access can be resolved from.
                case LocalVariable { Type: not null }:
                case FieldReference:
                    return (carried, addend);

                // Another computed address: keep folding.
                case LocalVariable untyped:
                    computed = untyped;
                    continue;

                default:
                    return null;
            }
        }

        return null;
    }

    /// <summary>
    /// AssetRipper: the arguments il2cpp uses when it shares one generic body across instantiations.
    /// </summary>
    /// <remarks>
    /// A reference type argument shares as <c>System.Object</c>, an int-backed enum as
    /// <c>System.Int32Enum</c>, and a fully shared parameter as the metadata type named below. A
    /// declaring type built from these says which instantiation the linker happened to emit, not
    /// which one the call site meant, so it is not evidence about the receiver.
    /// </remarks>
    private static readonly HashSet<string> SharingPlaceholders =
    [
        "System.Object",
        "System.Int32Enum",
        "Unity.IL2CPP.Metadata.__Il2CppFullySharedGenericType",
    ];

    /// <summary>
    /// AssetRipper: whether <paramref name="type"/> is a generic instantiation il2cpp shares a body
    /// for, rather than one the call site actually named.
    /// </summary>
    public static bool IsSharedInstantiation(TypeAnalysisContext? type)
        => type is GenericInstanceTypeAnalysisContext { GenericArguments: { } arguments }
            && arguments.Any(argument => SharingPlaceholders.Contains(argument.FullName));

    /// <summary>
    /// AssetRipper: whether <paramref name="type"/> is, or is built out of, a type sharing put
    /// there rather than the source.
    /// </summary>
    /// <remarks>
    /// Only a type the substitution touched is unreliable. A shared body's <c>MoveNext</c> still
    /// returns <see langword="bool"/> whatever the declaring type says, so refusing every type a
    /// shared method mentions throws away evidence that is perfectly good - and an untyped local is
    /// not free: SSA destruction merges it with whatever register version sits beside it, which is
    /// how a <c>bool</c> return came back typed as the enclosing <c>MonoBehaviour</c>.
    /// </remarks>
    public static bool ContainsSharingPlaceholder(TypeAnalysisContext? type) => type switch
    {
        null => false,
        GenericInstanceTypeAnalysisContext { GenericArguments: { } arguments }
            => arguments.Any(ContainsSharingPlaceholder),
        WrappedTypeAnalysisContext wrapped => ContainsSharingPlaceholder(wrapped.ElementType),
        _ => SharingPlaceholders.Contains(type.FullName ?? string.Empty),
    };

    /// <summary>
    /// AssetRipper: <paramref name="called"/> re-instantiated on the receiver's generic arguments,
    /// when the two are instantiations of one definition and disagree.
    /// </summary>
    /// <remarks>
    /// il2cpp compiles one body per generic definition and shares it, so the method a call resolves
    /// to is whichever instantiation that address was attributed to. The receiver's type is the
    /// stronger evidence - it comes from a field or parameter signature - so where the two disagree
    /// the receiver wins. Nothing has to know which arguments are placeholders: when the two agree
    /// this is a no-op. Only the declaring type is re-instantiated, since the receiver says nothing
    /// about the method's own generic arguments.
    /// </remarks>
    public static MethodAnalysisContext? ReceiverInstantiationOf(MethodAnalysisContext called, IOperand receiver)
    {
        if (called.IsStatic
            || called is not ConcreteGenericMethodAnalysisContext { TypeGenericParameters.Count: > 0 } concrete
            || concrete.BaseMethodContext.DeclaringType is not { } definition)
            return null;

        if (ReceiverType(receiver) is not GenericInstanceTypeAnalysisContext { GenericArguments: { } arguments } instance
            || instance.GenericType.FullName != definition.FullName
            || arguments.Count != concrete.TypeGenericParameters.Count)
            return null;

        var sameAlready = true;
        for (var i = 0; i < arguments.Count && sameAlready; i++)
            sameAlready = arguments[i].FullName == concrete.TypeGenericParameters[i].FullName;

        if (sameAlready)
            return null;

        return new ConcreteGenericMethodAnalysisContext(concrete.BaseMethodContext, arguments, concrete.MethodGenericParameters);
    }

    private static TypeAnalysisContext? ReceiverType(IOperand receiver) => receiver switch
    {
        LocalVariable { Type: { } local } => local,
        FieldReference { Field.FieldType: { } fieldType } => fieldType,
        _ => null,
    };

    /// <summary>
    /// AssetRipper: how many calls the analysis retargeted onto the receiver's instantiation.
    /// </summary>
    public static int SharedGenericCallsRetargetedInAnalysis;

    /// <summary>
    /// AssetRipper: retargets a shared generic call onto the instantiation the receiver names, inside
    /// the type fixpoint so that what it produces can be typed.
    /// </summary>
    /// <remarks>
    /// Doing this only at generation time, as it was first done, fixed the call that was written out
    /// and nothing downstream of it: during the analysis the call still returned the shared
    /// instantiation's type, so `foreach (Box box in Boxes)` kept an element typed
    /// <c>System.Object</c> and every field read off it failed. In the fixpoint the retarget types
    /// the return value, which types the next base, which resolves the next field.
    /// </remarks>
    public static bool RetargetSharedGenericCalls(MethodAnalysisContext method)
    {
        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode is not (OpCode.Call or OpCode.CallVoid)
                || instruction.Operands.Count == 0
                || instruction.Operands[0] is not MethodAnalysisContext called)
                continue;

            var receiverIndex = instruction.OpCode == OpCode.CallVoid ? 1 : 2;

            if (receiverIndex >= instruction.Operands.Count
                || ReceiverInstantiationOf(called, instruction.Operands[receiverIndex]) is not { } reinstantiated)
                continue;

            instruction.SetOperand(0, reinstantiated);
            System.Threading.Interlocked.Increment(ref SharedGenericCallsRetargetedInAnalysis);
            changed = true;
        }

        return changed;
    }

    private static RuntimeMethodInfoAnalysisContext? AsMethodInfo(IOperand operand) =>
        operand switch
        {
            RuntimeMethodInfoAnalysisContext methodInfo => methodInfo,
            LocalVariable { Type: RuntimeMethodInfoAnalysisContext methodInfoLocal } => methodInfoLocal,
            _ => null
        };

    /// <summary>AssetRipper: the function a chain of one-instruction veneers ends at.</summary>
    private static ulong FollowThunks(ApplicationAnalysisContext appContext, ulong address)
    {
        for (var hop = 0; hop < 4; hop++)
        {
            var next = appContext.InstructionSet.GetThunkTarget(appContext, address);

            if (next == 0 || next == address)
                return address;

            address = next;
        }

        return address;
    }

    /// <summary>
    /// Whether the call is to a helper built around an exception type — one that throws it, or builds
    /// it and hands it back for the caller to raise — and was rewritten accordingly.
    /// </summary>
    private static bool TryRewriteAsThrow(MethodAnalysisContext method, Instruction callInstruction, ulong target)
    {
        var raisedIndex = callInstruction.OpCode == OpCode.CallVoid ? 1 : 2;

        // AssetRipper: a helper that is handed an exception raises that exception, and what it is
        // handed is a fact from this body. The name below is a guess about the callee: it is the first
        // string ending in "Exception" that the helper's own instructions or its callees reference, and
        // the generic raiser's implementation references the out-of-memory one - both it and the
        // out-of-memory helper wrap the object in a C++ exception and hand the same type_info to
        // __cxa_throw. So `throw new UnityException(message)` came back as
        // `throw new OutOfMemoryException()`, 563 times on the third game, with the constructed
        // exception left in a dead local beside it. A helper that builds its own exception has no use
        // for one, so an allocation in the argument slot settles which of the two this is.
        if (callInstruction.Operands.Count > raisedIndex
            && AllocatedInThisMethod(method, callInstruction.Operands[raisedIndex])
            && ThrowHelperRecovery.IsExceptionRaiser(method.AppContext, target))
        {
            var raised = callInstruction.Operands[raisedIndex];
            callInstruction.OpCode = OpCode.Throw;
            callInstruction.SetOperands(raised);
            return true;
        }

        if (ThrowHelperRecovery.GetThrownException(method.AppContext, target) is { } thrown)
        {
            if (callInstruction.Destination is LocalVariable produced && method.ControlFlowGraph!.Instructions.Any(i => i.Sources.Any(s => ReferenceEquals(s, produced))))
            {
                callInstruction.OpCode = OpCode.Newobj;
                callInstruction.SetOperands(produced, thrown);
            }
            else
            {
                callInstruction.OpCode = OpCode.Throw;
                callInstruction.SetOperands(thrown);
            }

            return true;
        }

        // Otherwise it may be one of the raisers, which throw the exception they are given
        if (callInstruction.Operands.Count > raisedIndex && ThrowHelperRecovery.IsExceptionRaiser(method.AppContext, target))
        {
            callInstruction.OpCode = OpCode.Throw;
            callInstruction.SetOperands(callInstruction.Operands[raisedIndex]);
            return true;
        }

        return false;
    }

    /// <summary>
    /// AssetRipper: whether <paramref name="operand"/> is a value this method allocated, following the
    /// copies and merges between the allocation and the use.
    /// </summary>
    /// <remarks>
    /// An object reaches a raiser through a couple of register moves, because the compiler keeps the
    /// exception in a callee-saved register across the constructor call. Only the allocation matters
    /// here, not its type: nothing has typed anything yet at this point in the analysis.
    ///
    /// Straight copies, and a phi only when every one of its inputs is an allocation too. Following a
    /// phi's *first* input found an allocation from elsewhere in the method at a bounds check call
    /// site, so the check stopped being recognised and `throw new IndexOutOfRangeException()` became
    /// `throw <an uninitialised local>` with the check left standing around it. Requiring all of them
    /// keeps the merge honest: an injected check merges the register file of an unresolved call, which
    /// is not an allocation on any path.
    /// </remarks>
    private static bool AllocatedInThisMethod(MethodAnalysisContext method, IOperand operand)
    {
        if (method.ControlFlowGraph is not { } graph)
            return false;

        return Allocated(graph, operand, 0, new HashSet<IOperand>(ReferenceEqualityComparer.Instance));
    }

    private const int MaximumAllocationHops = 8;

    private static bool Allocated(ISILControlFlowGraph graph, IOperand operand, int depth, HashSet<IOperand> seen)
    {
        if (depth >= MaximumAllocationHops || operand is not LocalVariable || !seen.Add(operand))
            return false;

        var definition = graph.Instructions.FirstOrDefault(i =>
            i.Destination is { } destination && ReferenceEquals(destination, operand));

        if (definition == null)
            return false;

        if (definition.OpCode == OpCode.Newobj)
            return true;

        // The allocation before KeyFunctionRecovery rewrites it into Newobj, by the name
        // MetadataResolver has already given it.
        if (definition.OpCode == OpCode.Call && definition.Operands is [StringLiteral { Value: var named }, ..]
            && KeyFunctionRecovery.ObjectNewFunctions.Contains(named))
            return true;

        if (definition.OpCode == OpCode.Move && definition.Sources.Count == 1)
            return Allocated(graph, definition.Sources[0], depth + 1, seen);

        if (definition.OpCode == OpCode.Phi && definition.Sources.Count > 0)
            return definition.Sources.All(source => Allocated(graph, source, depth + 1, seen));

        return false;
    }

    private static void HandleKeyFunction(ApplicationAnalysisContext appContext, Instruction instruction, ulong target, BaseKeyFunctionAddresses kFA)
    {
        var method = "";
        if (target == kFA.il2cpp_codegen_initialize_method || target == kFA.il2cpp_codegen_initialize_runtime_metadata)
        {
            if (appContext.MetadataVersion < 27)
            {
                method = nameof(kFA.il2cpp_codegen_initialize_method);
            }
            else
            {
                method = nameof(kFA.il2cpp_codegen_initialize_runtime_metadata);
            }
        }
        else
        {
            var pairs = kFA.Pairs.ToList();
            var key = pairs.FirstOrDefault(pair => pair.Value == target).Key;
            if (key == null)
                return;
            method = key;
        }

        if (method != "")
        {
            instruction.SetOperand(0, new StringLiteral(method));
        }
    }

    // Because of il2cpp fields (like cctor_finished_or_no_cctor) [local @ reg+offset] sometimes can't be resolved, but this works for now
    private static void ResolveGetter(MethodAnalysisContext method)
    {
        if (!method.Name.StartsWith("get_"))
            return;

        // Default get: Return [this @ reg+offset]
        var instructions = method.ControlFlowGraph!.Instructions;
        if (instructions.Count == 1)
        {
            var instr = instructions[0];

            if (instr.OpCode != OpCode.Return
                || instr.Operands.Count < 1
                || instr.Operands[0] is not MemoryOperand memory
                || memory.Index != null || memory.Scale != 0
                || memory.Base is not LocalVariable local)
                return;

            var fieldName = $"<{method.Name[4..]}>k__BackingField";

            var field = method.DeclaringType!.Fields.Find(f => f.Name == fieldName);
            if (field == null)
                return;

            instr.SetOperand(0, new FieldReference(field, local, (int)memory.Addend));
        }
    }
}
