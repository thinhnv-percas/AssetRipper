using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;

namespace Cpp2IL.Core.Analysis;

public static class LocalVariables
{
    public static int MaxTypePropagationLoopCount = 5000;

    private const long StaticFieldsOffset64 = 0xB8;
    private const long StaticFieldsOffset32 = 0x5C;

    public static void CreateAll(MethodAnalysisContext method)
    {
        var cfg = method.ControlFlowGraph!;
        var instructions = cfg.Instructions;

        // Get all registers
        var registers = new List<Register>();
        foreach (var instruction in instructions)
            registers.AddRange(GetRegisters(instruction));

        // Remove duplicates
        registers = registers.Distinct().ToList();

        // Map those to locals
        var locals = new Dictionary<Register, LocalVariable>();
        for (var i = 0; i < registers.Count; i++)
        {
            var register = registers[i];
            locals.Add(register, new LocalVariable($"v{i}", register));
        }

        // Replace registers with locals
        foreach (var instruction in instructions)
        {
            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                var operand = instruction.Operands[i];

                if (operand is Register register)
                    instruction.SetOperand(i, locals[register]);

                if (operand is AddressOf { Target: Register addressed })
                    instruction.SetOperand(i, new AddressOf(locals[addressed]));

                if (operand is MemoryOperand memory)
                {
                    if (memory.Base != null)
                    {
                        var baseRegister = (Register)memory.Base;
                        memory.Base = locals[baseRegister];
                    }

                    if (memory.Index != null)
                    {
                        var index = (Register)memory.Index;
                        memory.Index = locals[index];
                    }

                    instruction.SetOperand(i, memory);
                }
            }
        }

        method.Locals = locals.Select(kv => kv.Value).ToList();

        // Return local names
        var retValIndex = 0;
        foreach (var instruction in instructions)
        {
            if (instruction.OpCode != OpCode.Return || instruction.Operands.Count != 1) continue;

            var returnLocal = (LocalVariable)instruction.Sources[0];

            returnLocal.Name = $"returnVal{retValIndex + 1}";
            returnLocal.IsReturn = true;
            retValIndex++;
        }

        // Add parameter names
        var paramLocals = new List<LocalVariable>();

        var operandOffset = method.IsStatic ? 0 : 1; // 'this'

        // 'this' param
        if (!method.IsStatic && method.Locals.Count > 0 && method.ParameterOperands.Count > 0)
        {
            var thisOperand = (Register)method.ParameterOperands[0];
            var thisLocal = method.Locals.FirstOrDefault(l => l.Register.Number == thisOperand.Number && l.Register.Version == -1);

            if (thisLocal != null)
            {
                thisLocal.Name = "this";
                thisLocal.IsThis = true;
                paramLocals.Add(thisLocal);
            }
            else
            {
                method.AddWarning($"'this' local not found (operand: {thisOperand})");
            }
        }

        // Check if method has MethodInfo*
        var hasMethodInfo = (method.ParameterOperands.Count - operandOffset) > method.Parameters.Count;
        var methodInfoIndex = method.ParameterOperands.Count - 1;

        // Add normal parameter names
        for (var i = 0; i < method.Parameters.Count; i++)
        {
            var operandIndex = i + operandOffset;
            if (hasMethodInfo && operandIndex == methodInfoIndex)
                break; // Skip MethodInfo*

            if (operandIndex >= method.ParameterOperands.Count)
                break;

            if (method.ParameterOperands[operandIndex] is not Register reg)
                continue;

            var local = method.Locals.FirstOrDefault(l => l.Register.Number == reg.Number && l.Register.Version == -1);
            if (local == null)
                continue;

            local.Name = method.Parameters[i].ParameterName;
            paramLocals.Add(local);
        }

        // Add MethodInfo*
        if (hasMethodInfo)
        {
            var methodInfoOperand = (Register)method.ParameterOperands[methodInfoIndex];
            var methodInfoLocal = method.Locals.FirstOrDefault(l => l.Register.Number == methodInfoOperand.Number && l.Register.Version == -1);

            if (methodInfoLocal != null)
            {
                methodInfoLocal.Name = "methodInfo";
                methodInfoLocal.IsMethodInfo = true;
                paramLocals.Add(methodInfoLocal);
            }
        }

        method.ParameterLocals = paramLocals;

        // the hidden return buffer takes the first argument register. we type it as the return
        // type so stores into it resolve to fields
        if (method.AppContext.Binary.PointerSizeBytes == 8
            && method.AppContext.InstructionSet.CallingConventionResolver?.HiddenReturnBufferRegister(method) is { } bufferRegister
            && method.Locals.FirstOrDefault(l => l.Register.Number == bufferRegister.Number && l.Register.Version == -1) is { } bufferLocal)
        {
            bufferLocal.Name = "returnBuffer";
            bufferLocal.Type = method.ReturnType;
        }
    }

    public static void RemoveUnused(MethodAnalysisContext method)
    {
        var cfg = method.ControlFlowGraph!;
        cfg.BuildUseDefLists();

        var usedLocals = new HashSet<LocalVariable>();

        foreach (var block in cfg.Blocks)
        {
            foreach (var usedVar in block.Use.OfType<LocalVariable>())
                usedLocals.Add(usedVar);

            foreach (var definedVar in block.Def.OfType<LocalVariable>())
                usedLocals.Add(definedVar);
        }

        method.Locals.RemoveAll(x => !usedLocals.Contains(x));
    }

    private static List<Register> GetRegisters(Instruction instruction)
    {
        var registers = new List<Register>();

        foreach (var operand in instruction.Operands)
        {
            if (operand is AddressOf { Target: Register addressed })
            {
                if (!registers.Contains(addressed))
                    registers.Add(addressed);
            }

            if (operand is Register register)
            {
                if (!registers.Contains(register))
                    registers.Add(register);
            }

            if (operand is MemoryOperand memory)
            {
                if (memory.Base != null)
                {
                    var baseRegister = (Register)memory.Base;
                    if (!registers.Contains(baseRegister))
                        registers.Add(baseRegister);
                }

                if (memory.Index != null)
                {
                    var index = (Register)memory.Index;
                    if (!registers.Contains(index))
                        registers.Add(index);
                }
            }
        }

        return registers;
    }

    /// <summary>
    /// Resolves field accesses and propagates types together, to a fixpoint, while the method is
    /// still in SSA form (every local has a single, version-stable definition).
    ///
    /// The two are mutually enabling and so cannot be ordered as separate passes: a typed base lets
    /// <see cref="MetadataResolver.ResolveFieldOffsets"/> turn <c>[base + offset]</c> into a
    /// <see cref="FieldReference"/>, a resolved field load types its result with the field's type,
    /// and that result is in turn the base of the next access (directly, or after flowing through
    /// moves/phis). Both steps are monotonic - each only ever resolves an operand or fills a
    /// previously-unknown type - so the loop converges.
    /// </summary>
    public static void ResolveTypesAndFields(MethodAnalysisContext method)
    {
        // Seed types from fixed ground truth - the method's own signature, and type-metadata global
        // loads. Applied once up front and, being applied first, they win over anything inferred later.
        PropagateFromReturn(method);
        PropagateFromParameters(method);
        SeedRuntimeClassTypes(method);
        SeedNewobjResults(method);
        SeedMethodInfoTypes(method);
        SeedComparisonResults(method);
        SeedFloatLiterals(method);

        // Everywhere there's a CallVoid after a Newobj, we can resolve the constructor call.
        MetadataResolver.ResolveConstructorCalls(method);

        // Everything else is mutually enabling and so runs to a fixpoint: a typed receiver lets an
        // ambiguous call resolve, a resolved call types its return value and arguments, a typed base
        // lets a field offset resolve, a field load types its result, and any of those can be the
        // receiver/base of the next step. Every pass is monotonic - it only resolves an operand or
        // fills a previously-unknown type - so the loop converges.
        var changed = true;
        var loopCount = 0;

        while (changed)
        {
            if (MaxTypePropagationLoopCount != -1 && ++loopCount > MaxTypePropagationLoopCount)
                throw new DecompilerException($"Type and field resolution not settling! (looped {MaxTypePropagationLoopCount} times)");

            changed = false;
            changed |= MetadataResolver.ResolveCallsViaMethodInfo(method);
            changed |= MetadataResolver.ResolveAmbiguousCalls(method);
            changed |= MetadataResolver.ResolveVirtualCalls(method);
            changed |= PropagateFromCallParameters(method);
            changed |= MetadataResolver.ResolveFieldOffsets(method);
            changed |= MetadataResolver.ResolveElementClassLoads(method);
            changed |= RgctxResolver.Run(method);
            changed |= PropagateStaticFieldStorage(method);
            changed |= TypeAddressedLocals(method);
            // AssetRipper: inside the loop, because it needs the array typed and what it produces
            // types the element, which is the base of the next field access.
            changed |= ArrayRecovery.RecoverComputedAccesses(method);
            changed |= PropagateTypesOnce(method);
        }

        // AssetRipper: last, because it is a guess where everything above is a deduction - it only
        // looks at locals nothing else could name.
        if (TypeCounters(method))
            while (PropagateTypesOnce(method))
            {
            }
    }

    /// <summary>
    /// AssetRipper: types the locals that are only ever counted with as integers.
    /// </summary>
    /// <remarks>
    /// A loop counter has no signature to take a type from — it is a register the compiler set to a
    /// constant and decremented — so it stayed untyped and every appearance of it was a cast:
    /// <c>object obj = 20; obj--; while ((nint)obj != 1)</c> for a <c>for</c> loop over twenty items.
    /// A local that is only ever assigned integer constants and the results of arithmetic on itself,
    /// and is never used as an address, an object or an argument, is an integer, and saying so is
    /// what turns that back into a loop with a counter in it.
    /// </remarks>
    private static bool TypeCounters(MethodAnalysisContext method)
    {
        var candidates = new HashSet<LocalVariable>();
        var definitions = new Dictionary<LocalVariable, List<Instruction>>();

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.Destination is not LocalVariable { Type: null } destination)
                continue;

            candidates.Add(destination);

            if (!definitions.TryGetValue(destination, out var list))
                definitions[destination] = list = [];

            list.Add(instruction);
        }

        if (candidates.Count == 0)
            return false;

        // A local read from anywhere that wants an address, an object or a signature is not a counter.
        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            var isArithmetic = instruction.OpCode is OpCode.Add or OpCode.Subtract or OpCode.Multiply
                or OpCode.Divide or OpCode.Modulo or OpCode.ShiftLeft or OpCode.ShiftRight
                or OpCode.Phi or OpCode.Move or OpCode.ConditionalJump
                or (>= OpCode.CheckEqual and <= OpCode.CheckLessOrEqual);

            for (var i = 0; i < instruction.Operands.Count; i++)
            {
                switch (instruction.Operands[i])
                {
                    // anything but arithmetic, a comparison or a copy wants a value of a real type
                    case LocalVariable local when !isArithmetic:
                        candidates.Remove(local);
                        break;
                    case MemoryOperand { Base: LocalVariable memoryBase }:
                        candidates.Remove(memoryBase);
                        break;
                    case FieldReference { Local: { } fieldLocal }:
                        candidates.Remove(fieldLocal);
                        break;
                    case ArrayAccess access:
                        candidates.Remove(access.Array);
                        break;
                    case ArrayLength length:
                        candidates.Remove(length.Array);
                        break;
                    case AddressOf { Target: LocalVariable addressed }:
                        candidates.Remove(addressed);
                        break;
                }
            }
        }

        // Then keep only the ones whose every definition computes an integer from integers.
        bool removedAny;
        do
        {
            removedAny = false;

            foreach (var candidate in candidates.ToList())
            {
                if (!definitions.TryGetValue(candidate, out var candidateDefinitions) || !candidateDefinitions.All(IsIntegerDefinition))
                {
                    candidates.Remove(candidate);
                    removedAny = true;
                }
            }
        } while (removedAny);

        var typedAny = false;

        foreach (var candidate in candidates)
        {
            candidate.Type = method.AppContext.SystemTypes.SystemInt32Type;
            typedAny = true;
        }

        return typedAny;

        bool IsIntegerDefinition(Instruction definition)
        {
            if (definition.OpCode is not (OpCode.Move or OpCode.Phi or OpCode.Add or OpCode.Subtract
                or OpCode.Multiply or OpCode.Divide or OpCode.Modulo or OpCode.ShiftLeft or OpCode.ShiftRight))
                return false;

            var sawEvidence = false;

            for (var i = 1; i < definition.Operands.Count; i++)
            {
                switch (definition.Operands[i])
                {
                    case Immediate { Value: >= int.MinValue and <= int.MaxValue }:
                        sawEvidence = true;
                        break;
                    case LocalVariable source when candidates.Contains(source):
                        break;
                    case LocalVariable { Type: { } sourceType } when IsIntegerType(sourceType):
                        sawEvidence = true;
                        break;
                    default:
                        return false;
                }
            }

            // a phi merely joins versions, so the evidence has to come from one of them
            return sawEvidence || definition.OpCode == OpCode.Phi;
        }
    }

    private static bool IsIntegerType(TypeAnalysisContext type) => type.FullName is
        "System.Byte" or "System.SByte" or "System.Int16" or "System.UInt16"
        or "System.Int32" or "System.UInt32" or "System.Int64" or "System.UInt64" or "System.Char";

    // A type-metadata global load (Move local, typeof(T)) puts the runtime class pointer for T into
    // the local - an Il2CppClass*, not an instance of T. That is known exactly from the instruction,
    // so it is seeded as ground truth (overriding any prior guess) before the inference fixpoint,
    // rather than letting a monotonic pass first mistype the local as T itself.
    private static void SeedRuntimeClassTypes(MethodAnalysisContext method)
    {
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode != OpCode.Move || instruction.Operands.Count < 2)
                continue;

            if (instruction.Operands[0] is LocalVariable destination
                && instruction.Operands[1] is TypeAnalysisContext type and not (RuntimeMethodInfoAnalysisContext or RuntimeFieldInfoAnalysisContext))
                destination.Type = new RuntimeClassTypeAnalysisContext(type, type.DeclaringAssembly);
        }
    }

    private static void SeedNewobjResults(MethodAnalysisContext method)
    {
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            // AssetRipper: a composed aggregate is exactly the type it was composed as
            if (instruction is { OpCode: OpCode.MakeStruct, Operands: [LocalVariable composed, TypeAnalysisContext composedType, ..] })
                composed.Type = composedType;

            // AssetRipper: an isinst yields the type it tested, or null
            if (instruction is { OpCode: OpCode.IsInst, Operands: [LocalVariable cast, TypeAnalysisContext castType, ..] })
            {
                cast.Type = castType;
                continue;
            }

            if (instruction.OpCode != OpCode.Newobj || instruction.Operands.Count < 2)
                continue;

            if (instruction.Operands[0] is LocalVariable destination && InstantiatedType(instruction.Operands[1]) is { } type)
                destination.Type = type;
        }
    }

    private static TypeAnalysisContext? InstantiatedType(IOperand classOperand) =>
        classOperand switch
        {
            LocalVariable { Type: RuntimeClassTypeAnalysisContext { RepresentedType: var t } } => t,
            RuntimeClassTypeAnalysisContext { RepresentedType: var t } => t,
            TypeAnalysisContext type => type, //not sure this is actually valid but for completeness
            _ => null,
        };

    // A method/field-metadata global load (Move local, methodof(M) / fieldof(F)) puts a MethodInfo*
    // or FieldInfo* into the local. MetadataResolver already resolved the address to a context naming
    // the member; that same context is the local's type (a runtime handle, recoverable via its
    // RepresentedMethod/RepresentedField).
    private static void SeedMethodInfoTypes(MethodAnalysisContext method)
    {
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode != OpCode.Move || instruction.Operands.Count < 2)
                continue;

            if (instruction.Operands[0] is LocalVariable destination
                && instruction.Operands[1] is RuntimeMethodInfoAnalysisContext or RuntimeFieldInfoAnalysisContext)
                destination.Type = (TypeAnalysisContext)instruction.Operands[1];
        }
    }

    // A comparison (CheckEqual, CheckLess, ...) writes a 0/1 result into its destination, so that local
    // is a System.Boolean regardless of what the compared operands are.
    private static void SeedComparisonResults(MethodAnalysisContext method)
    {
        var booleanType = method.AppContext.SystemTypes.SystemBooleanType;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode is < OpCode.CheckEqual or > OpCode.CheckLessOrEqual)
                continue;

            if (instruction.Destination is LocalVariable destination)
                destination.Type = booleanType;
        }
    }
    
    //Handles typing of locals for ref/out params. Returns whether anything new was typed
    public static bool TypeAddressedLocals(MethodAnalysisContext method)
    {
        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (!instruction.IsCall || instruction.Operands[0] is not MethodAnalysisContext calledMethod)
                continue;

            var firstArg = instruction.OpCode == OpCode.CallVoid ? 1 : 2;

            // the receiver of a value type's instance method is a pointer to the value
            if (!calledMethod.IsStatic && firstArg < instruction.Operands.Count
                && instruction.Operands[firstArg] is AddressOf { Target: LocalVariable receiver }
                && calledMethod.DeclaringType is { IsValueType: true } declaringType)
                changed |= SetTypeIfUnknown(receiver, declaringType);

            var paramOffset = firstArg + (calledMethod.IsStatic ? 0 : 1);

            for (var i = paramOffset; i < instruction.Operands.Count; i++)
            {
                var parameterIndex = i - paramOffset;
                if (parameterIndex > calledMethod.Parameters.Count - 1) // Probably MethodInfo*
                    continue;

                if (instruction.Operands[i] is AddressOf { Target: LocalVariable referenced }
                    && calledMethod.Parameters[parameterIndex].ParameterType is ByRefTypeAnalysisContext { ElementType: { } referencedType })
                    changed |= SetTypeIfUnknown(referenced, referencedType);
            }
        }

        return changed;
    }

    // Fills in a local's type only when it is currently unknown, keeping propagation monotonic (a
    // type, once set, is never changed) so the fixpoint terminates. Returns whether it set anything.
    /// <summary>
    /// AssetRipper: whether the access that resolved to this field is wider than the field itself, which
    /// makes the value several fields packed side by side rather than this one. Only decidable for a
    /// primitive field; anything else, and any access of unknown width, is taken at face value.
    /// </summary>
    private static bool IsWiderThanItsField(FieldReference field)
    {
        var width = field.Field.FieldType.FullName switch
        {
            "System.Boolean" or "System.Byte" or "System.SByte" => 1,
            "System.Int16" or "System.UInt16" or "System.Char" => 2,
            "System.Int32" or "System.UInt32" or "System.Single" => 4,
            "System.Int64" or "System.UInt64" or "System.Double" => 8,
            _ => 0,
        };

        return width > 0 && field.AccessSize > width;
    }

    private static bool SetTypeIfUnknown(LocalVariable local, TypeAnalysisContext? type)
    {
        if (type == null || local.Type != null)
            return false;

        local.Type = type;
        return true;
    }

    private static bool PropagateStaticFieldStorage(MethodAnalysisContext method)
    {
        var staticFieldsOffset = method.AppContext.Binary.is32Bit ? StaticFieldsOffset32 : StaticFieldsOffset64;
        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode != OpCode.Move || instruction.Operands.Count < 2)
                continue;

            if (instruction.Operands[0] is not LocalVariable destination || destination.Type is StaticFieldStorageTypeAnalysisContext)
                continue;

            if (instruction.Operands[1] is not MemoryOperand { Index: null, Scale: 0 } memory || memory.Addend != staticFieldsOffset)
                continue;

            if (memory.Base is not LocalVariable holder || OwningClass(method, holder) is not { } owner)
                continue;

            destination.Type = new StaticFieldStorageTypeAnalysisContext(owner, owner.DeclaringAssembly);
            changed = true;
        }

        return changed;
    }

    /// <summary>
    /// AssetRipper: the class whose static storage this local points at.
    /// </summary>
    /// <remarks>
    /// Usually the local is the class pointer itself. Where the address in the code is a pointer to
    /// the metadata usage slot rather than the slot, both addresses resolve to the same usage, so the
    /// pointer is what gets named as the class and the code dereferences it once more before reading
    /// the storage off it. That extra hop is allowed for here, and only here: nothing else needs to
    /// know which of the two levels was named, and a load at offset zero of a class pointer means
    /// something different everywhere else.
    /// </remarks>
    private static TypeAnalysisContext? OwningClass(MethodAnalysisContext method, LocalVariable holder)
    {
        if (holder.Type is RuntimeClassTypeAnalysisContext { RepresentedType: var direct })
            return direct;

        if (holder.Type != null)
            return null;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction is { OpCode: OpCode.Move, Operands: [LocalVariable destination, MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable { Type: RuntimeClassTypeAnalysisContext { RepresentedType: var indirect } } }] }
                && ReferenceEquals(destination, holder))
                return indirect;
        }

        return null;
    }

    // A single propagation sweep over every move and phi. Returns whether it filled in any type.
    private static bool PropagateTypesOnce(MethodAnalysisContext method)
    {
        var changed = false;

        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            switch (instruction.OpCode)
            {
                case OpCode.Move:
                    changed |= PropagateMove(instruction, method.AppContext.Binary.PointerSizeBytes);
                    break;
                case OpCode.Phi:
                    changed |= PropagatePhi(instruction);
                    break;
                case OpCode.Add or OpCode.Subtract or OpCode.Multiply:
                    changed |= PropagateArithmetic(instruction, method) || PropagateIntegerResultOfIntegers(instruction, method);
                    break;
                case OpCode.Divide or OpCode.Modulo:
                    changed |= PropagateArithmetic(instruction, method) || PropagateIntegerResult(instruction, method);
                    break;
                case OpCode.And or OpCode.Or or OpCode.Xor or OpCode.Not or OpCode.Negate
                    or OpCode.ShiftLeft or OpCode.ShiftRight:
                    changed |= PropagateBooleanLogic(instruction, method) || PropagateIntegerResult(instruction, method)
                        || PropagateBitwiseResult(instruction, method);
                    break;
                case OpCode.IsInst:
                    changed |= PropagateTypeCheckResult(instruction);
                    break;
                case >= OpCode.CheckEqual and <= OpCode.CheckLessOrEqual:
                    changed |= PropagateIntegerComparison(instruction, method);
                    break;
            }
        }

        return changed;
    }

    // A local assigned a float/double literal (a lifted rodata constant load) is that float type
    private static void SeedFloatLiterals(MethodAnalysisContext method)
    {
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode != OpCode.Move || instruction.Operands[0] is not LocalVariable destination)
                continue;

            destination.Type = instruction.Operands[1] switch
            {
                FloatLiteral => method.AppContext.SystemTypes.SystemSingleType,
                DoubleLiteral => method.AppContext.SystemTypes.SystemDoubleType,
                // AssetRipper: a string literal is a string, and an array's length is an int. Both were
                // left untyped, so `object key = "MORPEH__SAVED_DATA"` and every use of it a cast.
                StringLiteral => method.AppContext.SystemTypes.SystemStringType,
                ArrayLength => method.AppContext.SystemTypes.SystemInt32Type,
                _ => destination.Type,
            };
        }
    }

    // Arithmetic on a float operand is float arithmetic, so the result is that float type.
    private static bool PropagateArithmetic(Instruction instruction, MethodAnalysisContext method)
    {
        if (instruction.Operands is not [LocalVariable { Type: null } destination, var left, var right])
            return false;

        if ((FloatOperandType(left, method) ?? FloatOperandType(right, method)) is not { } floatType)
            return false;

        return SetTypeIfUnknown(destination, floatType);
    }

    /// <summary>
    /// AssetRipper: logic over booleans produces a boolean.
    /// </summary>
    /// <remarks>
    /// A condition assembled from flags — an ARM64 <c>b.ls</c> is <c>!C || Z</c>, and each of those is
    /// a comparison result — reaches here as a Not and an Or over two booleans, which nothing typed.
    /// The destination then stayed untyped and the whole condition read as
    /// <c>object obj = ~flag1 | flag2; if (obj != null)</c> rather than as the comparison it is.
    /// </remarks>
    private static bool PropagateBooleanLogic(Instruction instruction, MethodAnalysisContext method)
    {
        if (instruction.Operands is not [LocalVariable { Type: null } destination, ..])
            return false;

        if (instruction.OpCode is not (OpCode.And or OpCode.Or or OpCode.Xor or OpCode.Not))
            return false;

        for (var i = 1; i < instruction.Operands.Count; i++)
        {
            if (instruction.Operands[i] is not LocalVariable { Type.FullName: "System.Boolean" })
                return false;
        }

        return SetTypeIfUnknown(destination, method.AppContext.SystemTypes.SystemBooleanType);
    }

    // An integer operand makes the result an integer. Excludes bool operands so flag logic stays boolean.
    private static bool PropagateIntegerResult(Instruction instruction, MethodAnalysisContext method)
    {
        if (instruction.Operands[0] is not LocalVariable { Type: null } destination)
            return false;

        for (var i = 1; i < instruction.Operands.Count; i++)
            if (IntegerResultType(instruction.Operands[i], method) is { } integerType)
                return SetTypeIfUnknown(destination, integerType);

        return false;
    }

    /// <summary>
    /// AssetRipper: types the result of an addition, subtraction or multiplication whose operands are
    /// <em>all</em> known integers.
    /// </summary>
    /// <remarks>
    /// All of them, not any: `[base + index]` address arithmetic has an integer index beside a base
    /// that is not one, and typing that result as an integer would be wrong. Two known integers cannot
    /// be an address computation, so the result of one is a number. Without this the difference in
    /// `num - list._size` stayed <c>object</c> and every use of it read `(nint)obj`.
    /// </remarks>
    private static bool PropagateIntegerResultOfIntegers(Instruction instruction, MethodAnalysisContext method)
    {
        if (instruction.Operands is not [LocalVariable { Type: null } destination, ..])
            return false;

        TypeAnalysisContext? widest = null;

        for (var i = 1; i < instruction.Operands.Count; i++)
        {
            if (instruction.Operands[i] is Immediate)
                continue;

            if (IntegerResultType(instruction.Operands[i], method) is not { } operandType)
                return false;

            if (widest == null || operandType.FullName == "System.Int64")
                widest = operandType;
        }

        return widest != null && SetTypeIfUnknown(destination, widest);
    }

    /// <summary>
    /// AssetRipper: types an untyped operand of a comparison from whichever other operand has an
    /// integer type.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This is the seed the integer side of the type fixpoint was missing. A loop counter that nothing
    /// typed stayed <c>object</c>, and every use of it a cast: <c>obj = (nint)obj + 1;</c> and
    /// <c>if ((nint)obj &gt;= gamePlayController.maxValueCols)</c>, neither of which is C# - a
    /// reference cannot be cast to a native integer. The comparison against a typed <c>int</c> field
    /// says what the counter is.
    /// </para>
    /// <para>
    /// Only comparisons seed this, deliberately. The equivalent on <c>Add</c> would type the base of
    /// every <c>[base + index]</c> address computation as an integer, since the index beside it is one.
    /// A comparison is never address arithmetic. A comparison against the immediate zero does not seed
    /// either, because that is the shape of a null check.
    /// </para>
    /// </remarks>
    private static bool PropagateIntegerComparison(Instruction instruction, MethodAnalysisContext method)
    {
        TypeAnalysisContext? integerType = null;

        for (var i = 1; i < instruction.Operands.Count && integerType == null; i++)
            integerType = IntegerResultType(instruction.Operands[i], method);

        if (integerType == null)
            return false;

        var changed = false;

        for (var i = 1; i < instruction.Operands.Count; i++)
            if (instruction.Operands[i] is LocalVariable { Type: null } untyped)
                changed |= SetTypeIfUnknown(untyped, integerType);

        return changed;
    }

    /// <summary>
    /// AssetRipper: a shift or a bitwise operation produces an integer whatever its operands were.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The integer rules above all need an operand that is already known to be one, and a shift by a
    /// constant of a register nothing typed has none: <c>ShiftLeft v317, v316, 4</c>. But there is no
    /// such thing as shifting anything other than an integer - a float shifted is its bit pattern, and
    /// il2cpp would have converted it first - so the result is one, and so is the operand.
    /// </para>
    /// <para>
    /// Boolean logic is handled before this, so a condition assembled from flags stays boolean. The
    /// width is taken from whichever operand has one and is Int32 otherwise, which is what a register
    /// the machine shifted by a small constant is.
    /// </para>
    /// </remarks>
    private static bool PropagateBitwiseResult(Instruction instruction, MethodAnalysisContext method)
    {
        if (instruction.Operands is not [LocalVariable { Type: null } destination, ..])
            return false;

        // Negate is arithmetic rather than bitwise and can be applied to a float, so it is left out.
        if (instruction.OpCode is not (OpCode.And or OpCode.Or or OpCode.Xor or OpCode.Not
            or OpCode.ShiftLeft or OpCode.ShiftRight))
            return false;

        // A float operand means this is a bit trick over one, and the result is not a number to name.
        for (var i = 1; i < instruction.Operands.Count; i++)
            if (FloatOperandType(instruction.Operands[i], method) != null)
                return false;

        var width = method.AppContext.SystemTypes.SystemInt32Type;

        for (var i = 1; i < instruction.Operands.Count; i++)
            if (IntegerResultType(instruction.Operands[i], method) is { FullName: "System.Int64" } wide)
                width = wide;

        return SetTypeIfUnknown(destination, width);
    }

    /// <summary>
    /// AssetRipper: the result of a type check is the type that was checked for.
    /// </summary>
    /// <remarks>
    /// <c>IsInst v99, typeof(System.String), "CN: "</c> leaves <c>v99</c> holding a string or null, and
    /// nothing said so: 1114 locals on the test game, each of them the subject of a cast at every use.
    /// </remarks>
    private static bool PropagateTypeCheckResult(Instruction instruction)
        => instruction.Operands is [LocalVariable { Type: null } destination, TypeAnalysisContext checked_, ..]
            && SetTypeIfUnknown(destination, checked_);

    private static TypeAnalysisContext? IntegerResultType(IOperand operand, MethodAnalysisContext method)
    {
        // AssetRipper: an array's length is an int, and saying so is what keeps arithmetic on it typed.
        // Without it `array.Length - index` stayed unknown, so comparing the difference against zero -
        // the zero flag of a bounds check - was emitted as a reference comparison and the guard read as
        // `(object)(array.Length - index) == null`, which is not even valid IL.
        if (operand is ArrayLength)
            return method.AppContext.SystemTypes.SystemInt32Type;

        var type = operand switch
        {
            LocalVariable { Type: { } localType } => localType,
            FieldReference field => field.Field.FieldType,
            // AssetRipper: a read through a local the analysis typed as an integer is a dereference of
            // a pointer to that integer, so the value is one - `[v62 (System.Int32)]` in a multiply of
            // two of them, which is how a loop over an int array reaches the generator.
            MemoryOperand { Index: null, Addend: 0, Scale: 0, Base: LocalVariable { Type: { } baseType } } => baseType,
            _ => null,
        };

        // AssetRipper: an enum is its underlying integer for every purpose arithmetic has. Without
        // this, `level - 3` on an `NtlmAuthLevel` left the difference untyped and every use of it a
        // cast - 1352 subtractions and 1204 bitwise ands on the test game began at an enum operand.
        if (type is { IsEnumType: true })
            type = type.Fields.FirstOrDefault(f => !f.IsStatic)?.FieldType ?? type;

        return type?.FullName switch
        {
            "System.Byte" or "System.SByte" or "System.Int16" or "System.UInt16"
                or "System.Int32" or "System.UInt32" or "System.Char" => method.AppContext.SystemTypes.SystemInt32Type,
            "System.Int64" or "System.UInt64" => method.AppContext.SystemTypes.SystemInt64Type,
            _ => null,
        };
    }

    private static TypeAnalysisContext? FloatOperandType(IOperand operand, MethodAnalysisContext method) =>
        operand switch
        {
            FloatLiteral => method.AppContext.SystemTypes.SystemSingleType,
            DoubleLiteral => method.AppContext.SystemTypes.SystemDoubleType,
            LocalVariable { Type: { FullName: "System.Single" } single } => single,
            LocalVariable { Type: { FullName: "System.Double" } @double } => @double,
            // AssetRipper: a value the ABI handed back in several vector registers is named by its
            // first register, which carries its first field — a float. Arithmetic on it is float
            // arithmetic, and without saying so the result stays untyped and every use of it a cast.
            LocalVariable { Type: { } aggregate } when FloatAggregate.MemberCount(aggregate) >= 2
                => method.AppContext.SystemTypes.SystemSingleType,
            FieldReference { Field.FieldType: { } fieldType } when FloatAggregate.MemberCount(fieldType) >= 2
                => method.AppContext.SystemTypes.SystemSingleType,
            FieldReference { Field.FieldType: { FullName: "System.Single" } fieldSingle } => fieldSingle,
            FieldReference { Field.FieldType: { FullName: "System.Double" } fieldDouble } => fieldDouble,
            _ => null,
        };

    private static bool PropagateMove(Instruction move, int pointerSize)
    {
        var destination = move.Operands[0];
        var source = move.Operands[1];

        // Move local, local: copy a known type in whichever direction is missing it.
        if (destination is LocalVariable destLocal && source is LocalVariable sourceLocal)
            return SetTypeIfUnknown(destLocal, sourceLocal.Type) || SetTypeIfUnknown(sourceLocal, destLocal.Type);

        // Move local, field: a field load types its result with the field's type. This is the edge
        // that lets the loaded value go on to be the base of a further field access.
        if (destination is LocalVariable loadDest && source is FieldReference loadField)
            return SetTypeIfUnknown(loadDest, loadField.Field.FieldType);

        // Move field, local: a field store types the stored value with the field's type - unless the
        // store is wider than the field, in which case the value is several fields packed side by side
        // and typing it as the first one loses the rest. Two adjacent bools written by one strh gave a
        // Boolean local, so the 0x100 that means "the second one" arrived as `true`.
        if (destination is FieldReference storeField && source is LocalVariable storeSource
            && !IsWiderThanItsField(storeField))
            return SetTypeIfUnknown(storeSource, storeField.Field.FieldType);

        // An element of T[] is a T, whether we loaded it (reference arrays) or only computed its address
        if (destination is LocalVariable { Type: null } elementDest
            && source is MemoryOperand { Base: LocalVariable { Type: SzArrayTypeAnalysisContext { ElementType: { } elementType } } } elementAccess
            && (elementAccess.Index != null || elementAccess.Addend >= 4L * pointerSize))
            return SetTypeIfUnknown(elementDest, elementType);

        // AssetRipper: the same, once the access has been recovered into an element operand rather than
        // an address. Without this the element of a Sound[] stayed an object and every field read on
        // it was an unnameable offset.
        if (destination is LocalVariable { Type: null } arrayElementDest
            && source is ArrayAccess { Array.Type: SzArrayTypeAnalysisContext { ElementType: { } accessElementType } })
            return SetTypeIfUnknown(arrayElementDest, accessElementType);

        // Move local, [byref]: dereferencing a managed pointer to a reference type yields that referent
        // (a struct byref accesses fields directly with no deref, so this only fires for class referents).
        if (destination is LocalVariable { Type: null } derefDest
            && source is MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable { Type: ByRefTypeAnalysisContext { ElementType: { IsValueType: false } referent } } })
            return SetTypeIfUnknown(derefDest, referent);

        // Move local, [obj]: offset 0 of a reference-typed value is its klass pointer.
        if (destination is LocalVariable { Type: null } klassDest
            && source is MemoryOperand { Index: null, Scale: 0, Addend: 0, Base: LocalVariable { Type: { } baseType } }
            && baseType is not (RuntimeClassTypeAnalysisContext or StaticFieldStorageTypeAnalysisContext or RuntimeMethodInfoAnalysisContext or RuntimeFieldInfoAnalysisContext or ByRefTypeAnalysisContext)
            && !baseType.IsValueType)
            return SetTypeIfUnknown(klassDest, new RuntimeClassTypeAnalysisContext(baseType, baseType.DeclaringAssembly));

        return false;
    }

    // A phi is a copy from each predecessor's value, so types flow both ways across it - mirroring
    // the bidirectional Move copies it decays into once SSA is destroyed.
    private static bool PropagatePhi(Instruction phi)
    {
        if (phi.Operands[0] is not LocalVariable destination)
            return false;

        var changed = false;

        // Forward: an untyped phi result takes the type of any typed input.
        if (destination.Type == null)
        {
            for (var i = 1; i < phi.Operands.Count; i++)
            {
                if (phi.Operands[i] is LocalVariable { Type: { } inputType })
                {
                    changed = SetTypeIfUnknown(destination, inputType);
                    break;
                }
            }
        }

        // Backward: a typed phi result types each of its still-untyped inputs.
        if (destination.Type != null)
        {
            for (var i = 1; i < phi.Operands.Count; i++)
            {
                if (phi.Operands[i] is LocalVariable input)
                    changed |= SetTypeIfUnknown(input, destination.Type);
            }
        }

        return changed;
    }

    private static bool PropagateFromCallParameters(MethodAnalysisContext method)
    {
        var changed = false;

        // A lea and the call it's passed to are still separate here. The address only gets folded into the
        // call later, so an argument's address-of has to be found through the local carrying it.
        var addressesOf = new Dictionary<LocalVariable, LocalVariable>();
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode == OpCode.Move
                && instruction.Operands[0] is LocalVariable pointer
                && instruction.Operands[1] is AddressOf { Target: LocalVariable pointee })
                addressesOf[pointer] = pointee;
        }

        LocalVariable? Addressed(IOperand operand) => operand switch
        {
            AddressOf { Target: LocalVariable direct } => direct,
            LocalVariable local when addressesOf.TryGetValue(local, out var indirect) => indirect,
            _ => null
        };

        foreach (var instruction in method.ControlFlowGraph.Instructions)
        {
            if (!instruction.IsCall)
                continue;

            if (instruction.Operands[0] is not MethodAnalysisContext calledMethod)
                continue;

            // Return value: a constructor yields its declaring type, otherwise the declared return type.
            if (instruction.Destination is LocalVariable returnValue)
            {
                var producedType = calledMethod.Name is ".ctor" or ".cctor" ? calledMethod.DeclaringType : calledMethod.ReturnType;

                if (producedType != method.AppContext.SystemTypes.SystemVoidType)
                    changed |= SetTypeIfUnknown(returnValue, producedType);
            }


            // Call operands
            // 0. Target
            // 1. ReturnValue
            // 2. thisParam
            // ... parameters

            // CallVoid operands
            // 0. Target
            // 1. thisParam
            // ... parameters
            var thisParamIndex = instruction.OpCode == OpCode.CallVoid ? 1 : 2;

            // 'this' param
            if (!calledMethod.IsStatic
                && instruction.Operands[thisParamIndex] is LocalVariable thisParam)
            {
                changed |= SetTypeIfUnknown(thisParam, calledMethod.DeclaringType);
            }

            // Value type instance method, first arg is address of value, but we need to type the value
            if (!calledMethod.IsStatic
                && Addressed(instruction.Operands[thisParamIndex]) is { } addressedReceiver
                && calledMethod.DeclaringType is { IsValueType: true } valueType)
            {
                changed |= SetTypeIfUnknown(addressedReceiver, valueType);
            }

            // Remaining arguments map positionally onto the callee's declared parameters.
            var paramOffset = calledMethod.IsStatic ? 1 : 2;
            if (instruction.OpCode == OpCode.Call) // Skip the return value operand
                paramOffset += 1;

            for (var i = paramOffset; i < instruction.Operands.Count; i++)
            {
                var parameterIndex = i - paramOffset;
                if (parameterIndex > calledMethod.Parameters.Count - 1) // Probably MethodInfo*
                    continue;

                var parameterType = calledMethod.Parameters[parameterIndex].ParameterType;

                if (parameterType is ByRefTypeAnalysisContext { ElementType: { } referencedType }
                    && Addressed(instruction.Operands[i]) is { } referenced)
                {
                    changed |= SetTypeIfUnknown(referenced, referencedType);
                    continue;
                }

                if (instruction.Operands[i] is LocalVariable local)
                    changed |= SetTypeIfUnknown(local, parameterType);
            }
        }

        return changed;
    }

    private static void PropagateFromParameters(MethodAnalysisContext method)
    {
        // 'this'
        if (!method.IsStatic)
        {
            var thisLocal = method.ParameterLocals.FirstOrDefault(p => p.IsThis);
            if (thisLocal != null)
                thisLocal.Type = method.DeclaringType is { GenericParameters.Count: > 0 } generic
                    ? new GenericInstanceTypeAnalysisContext(generic, generic.GenericParameters)
                    : method.DeclaringType;
        }

        if (method.ParameterLocals.FirstOrDefault(p => p.IsMethodInfo) is { } methodInfoLocal && method.DeclaringType is { } owner)
            methodInfoLocal.Type = new RuntimeMethodInfoAnalysisContext(method, owner.DeclaringAssembly);

        if (method.Parameters.Count == 0)
            return;

        // Normal params
        var paramIndex = 0;
        foreach (var local in method.ParameterLocals)
        {
            if (local.IsThis || local.IsMethodInfo)
                continue;

            if (paramIndex >= method.Parameters.Count)
                break;

            local.Type = method.Parameters[paramIndex].ParameterType;
            paramIndex++;
        }
    }

    private static void PropagateFromReturn(MethodAnalysisContext method)
    {
        var returns = method.ControlFlowGraph!.Instructions.Where(i => i.OpCode == OpCode.Return);

        foreach (var instruction in returns)
        {
            if (instruction.Operands.Count == 1 && instruction.Operands[0] is LocalVariable local)
                local.Type = method.ReturnType;
        }
    }
}
