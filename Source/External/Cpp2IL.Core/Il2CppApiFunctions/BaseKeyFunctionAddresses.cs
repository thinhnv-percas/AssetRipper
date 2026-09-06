using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Cpp2IL.Core.Logging;
using Cpp2IL.Core.Model.Contexts;
using Cpp2IL.Core.Utils;
using Iced.Intel;
using LibCpp2IL;
using LibCpp2IL.Reflection;

namespace Cpp2IL.Core.Il2CppApiFunctions;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public abstract class BaseKeyFunctionAddresses
{
    public ulong il2cpp_codegen_initialize_method; //Either this
    public ulong il2cpp_codegen_initialize_runtime_metadata; //Or this, are present, depending on metadata version, but not exported.
    public ulong il2cpp_codegen_initialize_runtime_metadata_inline; //Thunk of the above without the memory barrier, and it hands the value back. Exception handlers use it.
    public ulong il2cpp_vm_metadatacache_initializemethodmetadata; //This is thunked from the above (but only pre-27?)
    public ulong il2cpp_runtime_class_init_export; //Api function (exported)
    public ulong il2cpp_runtime_class_init_actual; //Thunked from above
    public ulong il2cpp_codegen_runtime_class_init; //Thunked TO the above, called by managed method bodies
    public ulong il2cpp_object_new; //Api Function (exported)
    public ulong il2cpp_vm_object_new; //Thunked from above
    public ulong il2cpp_codegen_object_new; //Thunked TO above
    public ulong il2cpp_array_new_specific; //Api function (exported)
    public ulong il2cpp_vm_array_new_specific; //Thunked from above
    public ulong SzArrayNew; //Thunked TO above.
    public ulong il2cpp_type_get_object; //Api function (exported)
    public ulong il2cpp_vm_reflection_get_type_object; //Thunked from above
    public ulong il2cpp_resolve_icall; //Api function (exported)
    public ulong InternalCalls_Resolve; //Thunked from above.

    public ulong il2cpp_string_new; //Api function (exported)
    public ulong il2cpp_vm_string_new; //Thunked from above
    public ulong il2cpp_string_new_wrapper; //Api function
    public ulong il2cpp_vm_string_newWrapper; //Thunked from above
    public ulong il2cpp_codegen_string_new_wrapper; //Not sure if actual name, used in ARM64 attribute gens, thunks TO above.

    public ulong il2cpp_value_box; //Api function (exported)
    public ulong il2cpp_vm_object_box; //Thunked from above

    public ulong il2cpp_object_unbox; //Api function
    public ulong il2cpp_vm_object_unbox; //Thunked from above

    public ulong il2cpp_raise_exception; //Api function (exported)
    public ulong il2cpp_vm_exception_raise; //Thunked from above
    public ulong il2cpp_codegen_raise_exception; //Thunked TO above. don't know real name.

    public ulong il2cpp_class_is_assignable_from; //Api function (exported)
    public ulong il2cpp_vm_class_is_assignable_from; //Thunked from above
    public ulong il2cpp_vm_object_is_inst; //Not exported. Located as the busiest caller of the above; see FindObjectIsInstViaAssignableFrom.
    public ulong il2cpp_codegen_object_is_inst; //Thunked TO the above, called by managed method bodies

    public ulong il2cpp_codegen_write_barrier; //Not exported, not thunked. Located via corlib methods which store a reference into a field. Zero if the build has write barriers disabled.

    public ulong AddrPInvokeLookup; //TODO Re-find this and fix name

    public IEnumerable<KeyValuePair<string, ulong>> Pairs => resolvedAddressMap;

    protected ApplicationAnalysisContext _appContext = null!; //Always initialized before used

    protected LibCpp2IlReflectionCache ReflectionCache =>
        _appContext.LibCpp2IlContext.ReflectionCache;

    private readonly Dictionary<string, ulong> resolvedAddressMap = [];
    private readonly HashSet<ulong> resolvedAddressSet = [];

    public bool IsKeyFunctionAddress(ulong address)
    {
        return address != 0 && resolvedAddressSet.Contains(address);
    }

    private void FindExport(string name, out ulong ptr)
    {
        Logger.Verbose($"\tLooking for Exported {name} function...");
        ptr = _appContext.Binary.GetVirtualAddressOfExportedFunctionByName(name);

        Logger.VerboseNewline(ptr == 0 ? "Not found" : $"Found at 0x{ptr:X}");
    }

    public virtual void Find(ApplicationAnalysisContext applicationAnalysisContext)
    {
        _appContext = applicationAnalysisContext;
        Init(applicationAnalysisContext);

        //Try to find System.Exception (should always be there)
        TryGetInitMetadataFromException();

        //New Object
        FindExport("il2cpp_object_new", out il2cpp_object_new);

        //Type => Object
        FindExport("il2cpp_type_get_object", out il2cpp_type_get_object);

        //Resolve ICall
        FindExport("il2cpp_resolve_icall", out il2cpp_resolve_icall);

        //New String
        FindExport("il2cpp_string_new", out il2cpp_string_new);

        //New string wrapper
        FindExport("il2cpp_string_new_wrapper", out il2cpp_string_new_wrapper);

        //Box Value
        FindExport("il2cpp_value_box", out il2cpp_value_box);

        //Unbox Value
        FindExport("il2cpp_object_unbox", out il2cpp_object_unbox);

        //Raise Exception
        FindExport("il2cpp_raise_exception", out il2cpp_raise_exception);

        //Class Init
        FindExport("il2cpp_runtime_class_init", out il2cpp_runtime_class_init_export);

        //New array of fixed size
        FindExport("il2cpp_array_new_specific", out il2cpp_array_new_specific);

        //Class assignability, which is what Object::IsInst is found through
        FindExport("il2cpp_class_is_assignable_from", out il2cpp_class_is_assignable_from);

        if (il2cpp_class_is_assignable_from != 0)
            il2cpp_vm_class_is_assignable_from = FindFunctionThisIsAThunkOf(il2cpp_class_is_assignable_from);

        //Object IsInst
        il2cpp_vm_object_is_inst = FindObjectIsInstViaAssignableFrom();

        if (il2cpp_vm_object_is_inst == 0)
            il2cpp_vm_object_is_inst = GetObjectIsInstFromSystemType();

        //GC write barrier
        il2cpp_codegen_write_barrier = GetWriteBarrier();

        AttemptInstructionAnalysisToFillGaps();

        FindThunks();
        InitializeResolvedAddresses();
    }

    protected void TryGetInitMetadataFromException()
    {
        //Exception.get_Message() - first call is either to codegen_initialize_method (< v27) or codegen_initialize_runtime_metadata
        Logger.VerboseNewline("\tLooking for Type System.Exception, Method get_Message...");

        var type = ReflectionCache.GetType("Exception", "System")!;
        Logger.VerboseNewline("\t\tType Located. Ensuring method exists...");
        var targetMethod = type.Methods!.FirstOrDefault(m => m.Name == "get_Message");
        if (targetMethod != null) //Check struct contains valid data
        {
            Logger.VerboseNewline($"\t\tTarget Method Located at {targetMethod.MethodPointer}. Taking first CALL as the (version-specific) metadata initialization function...");

            var target = FindFirstCallTargetInMethod(targetMethod.MethodPointer);

            if (target == 0)
            {
                Logger.WarnNewline("Couldn't find any call instructions in the method body. This is not expected. Will not have metadata initialization function.");
                return;
            }

            if (_appContext.MetadataVersion < 27)
            {
                il2cpp_codegen_initialize_method = target;
                Logger.VerboseNewline($"\t\til2cpp_codegen_initialize_method => 0x{il2cpp_codegen_initialize_method:X}");
            }
            else
            {
                il2cpp_codegen_initialize_runtime_metadata = target;
                Logger.VerboseNewline($"\t\til2cpp_codegen_initialize_runtime_metadata => 0x{il2cpp_codegen_initialize_runtime_metadata:X}");
            }
        }
    }

    // the address the first call instruction in the method at methodVa targets, or 0 if there is none or this isn't supported
    protected virtual ulong FindFirstCallTargetInMethod(ulong methodVa) => 0;

    protected virtual void AttemptInstructionAnalysisToFillGaps()
    {
    }

    private void FindThunks()
    {
        if (il2cpp_object_new != 0)
        {
            Logger.Verbose("\tMapping il2cpp_object_new to vm::Object::New...");
            il2cpp_vm_object_new = FindFunctionThisIsAThunkOf(il2cpp_object_new, true);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_object_new:X}");
        }

        if (il2cpp_vm_object_new != 0)
        {
            Logger.Verbose("\tLooking for il2cpp_codegen_object_new as a thunk of vm::Object::New...");

            var potentialThunks = FindAllThunkFunctions(il2cpp_vm_object_new, 16);

            //Sort by caller count in ascending order
            var list = potentialThunks.Select(ptr => (ptr, count: GetCallerCount(ptr))).ToList();
            list.SortByExtractedKey(pair => pair.count);

            //Sort in descending order - most called first
            list.Reverse();

            //Take first as the target
            il2cpp_codegen_object_new = list.FirstOrDefault().ptr;

            Logger.VerboseNewline($"Found at 0x{il2cpp_codegen_object_new:X}");
        }

        if (il2cpp_vm_object_is_inst != 0)
        {
            Logger.Verbose("\tLooking for il2cpp_codegen_object_is_inst as a thunk of vm::Object::IsInst...");

            // AssetRipper: generated code calls the thunk, never the function, so without this every
            // isinst, castclass and array store check in the game is an unresolved address.
            il2cpp_codegen_object_is_inst = MostCalledThunkOf(il2cpp_vm_object_is_inst);

            Logger.VerboseNewline($"Found at 0x{il2cpp_codegen_object_is_inst:X}");
        }

        if (il2cpp_type_get_object != 0)
        {
            Logger.Verbose("\tMapping il2cpp_resolve_icall to Reflection::GetTypeObject...");
            il2cpp_vm_reflection_get_type_object = FindFunctionThisIsAThunkOf(il2cpp_type_get_object);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_reflection_get_type_object:X}");
        }

        if (il2cpp_resolve_icall != 0)
        {
            Logger.Verbose("\tMapping il2cpp_resolve_icall to InternalCalls::Resolve...");
            InternalCalls_Resolve = FindFunctionThisIsAThunkOf(il2cpp_resolve_icall);
            Logger.VerboseNewline($"Found at 0x{InternalCalls_Resolve:X}");
        }

        if (il2cpp_string_new != 0)
        {
            Logger.Verbose("\tMapping il2cpp_string_new to String::New...");
            il2cpp_vm_string_new = FindFunctionThisIsAThunkOf(il2cpp_string_new);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_string_new:X}");
        }

        if (il2cpp_string_new_wrapper != 0)
        {
            Logger.Verbose("\tMapping il2cpp_string_new_wrapper to String::NewWrapper...");
            il2cpp_vm_string_newWrapper = FindFunctionThisIsAThunkOf(il2cpp_string_new_wrapper);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_string_newWrapper:X}");
        }

        if (il2cpp_vm_string_newWrapper != 0)
        {
            Logger.Verbose("\tMapping String::NewWrapper to il2cpp_codegen_string_new_wrapper...");
            il2cpp_codegen_string_new_wrapper = FindAllThunkFunctions(il2cpp_vm_string_newWrapper, 0, il2cpp_string_new_wrapper).FirstOrDefault();
            Logger.VerboseNewline($"Found at 0x{il2cpp_codegen_string_new_wrapper:X}");
        }

        if (il2cpp_value_box != 0)
        {
            Logger.Verbose("\tMapping il2cpp_value_box to Object::Box...");
            il2cpp_vm_object_box = FindFunctionThisIsAThunkOf(il2cpp_value_box);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_object_box:X}");
        }

        if (il2cpp_object_unbox != 0)
        {
            Logger.Verbose("\tMapping il2cpp_object_unbox to Object::Unbox...");
            il2cpp_vm_object_unbox = FindFunctionThisIsAThunkOf(il2cpp_object_unbox);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_object_unbox:X}");
        }

        if (il2cpp_raise_exception != 0)
        {
            Logger.Verbose("\tMapping il2cpp_raise_exception to il2cpp::vm::Exception::Raise...");
            il2cpp_vm_exception_raise = FindFunctionThisIsAThunkOf(il2cpp_raise_exception, true);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_exception_raise:X}");
        }

        if (il2cpp_vm_exception_raise != 0)
        {
            Logger.Verbose("\tMapping il2cpp::vm::Exception::Raise to il2cpp_codegen_raise_exception...");
            il2cpp_codegen_raise_exception = FindAllThunkFunctions(il2cpp_vm_exception_raise, 4, il2cpp_raise_exception).FirstOrDefault();
            Logger.VerboseNewline($"Found at 0x{il2cpp_codegen_raise_exception:X}");
        }

        if (il2cpp_codegen_initialize_runtime_metadata != 0)
        {
            Logger.Verbose("\tLooking for il2cpp_codegen_initialize_runtime_metadata_inline as a thunk of the metadata init...");
            il2cpp_codegen_initialize_runtime_metadata_inline = FindAllThunkFunctions(il2cpp_codegen_initialize_runtime_metadata).FirstOrDefault();
            Logger.VerboseNewline($"Found at 0x{il2cpp_codegen_initialize_runtime_metadata_inline:X}");
        }

        if (il2cpp_runtime_class_init_export != 0)
        {
            Logger.Verbose("\tMapping il2cpp_runtime_class_init to il2cpp:vm::Runtime::ClassInit...");
            il2cpp_runtime_class_init_actual = FindFunctionThisIsAThunkOf(il2cpp_runtime_class_init_export);
            Logger.VerboseNewline($"Found at 0x{il2cpp_runtime_class_init_actual:X}");
        }

        if (il2cpp_runtime_class_init_actual != 0)
        {
            Logger.Verbose("\tLooking for il2cpp_codegen_runtime_class_init as a thunk of Runtime::ClassInit...");

            var potentialThunks = FindAllThunkFunctions(il2cpp_runtime_class_init_actual, 16, il2cpp_runtime_class_init_export)
                .Select(ptr => (ptr, count: GetCallerCount(ptr)))
                .ToList();
            potentialThunks.SortByExtractedKey(pair => pair.count);
            potentialThunks.Reverse();

            // don't clobber a value an instruction-set-specific pass already found (wasm finds no thunks here)
            if (potentialThunks.FirstOrDefault().ptr is var thunk && thunk != 0)
                il2cpp_codegen_runtime_class_init = thunk;

            Logger.VerboseNewline($"Found at 0x{il2cpp_codegen_runtime_class_init:X}");
        }

        if (il2cpp_array_new_specific != 0)
        {
            Logger.Verbose("\tMapping il2cpp_array_new_specific to vm::Array::NewSpecific...");
            il2cpp_vm_array_new_specific = FindFunctionThisIsAThunkOf(il2cpp_array_new_specific);
            Logger.VerboseNewline($"Found at 0x{il2cpp_vm_array_new_specific:X}");
        }

        if (il2cpp_vm_array_new_specific != 0)
        {
            Logger.Verbose("\tLooking for SzArrayNew as a thunk function proxying Array::NewSpecific...");
            SzArrayNew = FindAllThunkFunctions(il2cpp_vm_array_new_specific, 4, il2cpp_array_new_specific).FirstOrDefault();
            Logger.VerboseNewline($"Found at 0x{SzArrayNew:X}");
        }
    }

    protected abstract ulong GetObjectIsInstFromSystemType();

    /// <summary>
    /// AssetRipper: the functions containing a call to <paramref name="target"/>. Empty where the
    /// instruction set has no way to look.
    /// </summary>
    protected virtual IEnumerable<ulong> FindCallersOf(ulong target) => [];

    /// <summary>
    /// AssetRipper: <c>il2cpp::vm::Object::IsInst</c>, found as the busiest caller of
    /// <c>Class::IsAssignableFrom</c>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// <see cref="GetObjectIsInstFromSystemType"/> assumes <c>System.Type::IsInstanceOfType</c> is the
    /// one-line icall that ends in a call to IsInst. On Unity 2019.2 it is managed code that ends in a
    /// virtual dispatch instead, and the heuristic — the last <c>BL</c> in the body — reads past the
    /// end of the method and returns whatever the next function calls. On the game measured that was
    /// the class-init thunk, which is not merely a miss: the address then collides with
    /// <c>il2cpp_codegen_runtime_class_init</c> and whichever name comes first wins.
    /// </para>
    /// <para>
    /// <c>il2cpp_class_is_assignable_from</c> is exported, so <c>Class::IsAssignableFrom</c> is known
    /// exactly. IsInst is one of about a dozen functions that call it, and the only one managed code
    /// calls at all — every <c>isinst</c>, <c>castclass</c> and array store check goes through it —
    /// so counting callers separates it by three orders of magnitude. The count has to include the
    /// thunks, because generated code calls those and not the function.
    /// </para>
    /// </remarks>
    private ulong FindObjectIsInstViaAssignableFrom()
    {
        if (il2cpp_vm_class_is_assignable_from == 0)
            return 0;

        Logger.Verbose("\tLooking for vm::Object::IsInst as the busiest caller of Class::IsAssignableFrom...");

        var best = 0ul;
        var bestCount = 0;

        foreach (var caller in FindCallersOf(il2cpp_vm_class_is_assignable_from).Distinct())
        {
            if (caller == 0 || caller == il2cpp_vm_class_is_assignable_from)
                continue; // it calls itself recursively

            var count = GetCallerCount(caller) + FindAllThunkFunctions(caller).Sum(GetCallerCount);

            if (count > bestCount)
            {
                bestCount = count;
                best = caller;
            }
        }

        // Every cast in the game goes through it. Anything less is one of the runtime-internal callers
        // and naming it IsInst would be worse than not finding it.
        if (bestCount < MinimumIsInstCallers)
        {
            Logger.VerboseNewline($"Busiest caller has only {bestCount} callers of its own, which is too few. Aborting.");
            return 0;
        }

        Logger.VerboseNewline($"Found at 0x{best:X} with {bestCount} callers.");
        return best;
    }

    private const int MinimumIsInstCallers = 32;

    /// <summary>AssetRipper: the thunk of <paramref name="function"/> that is called the most.</summary>
    private ulong MostCalledThunkOf(ulong function)
    {
        var best = 0ul;
        var bestCount = 0;

        foreach (var thunk in FindAllThunkFunctions(function))
        {
            var count = GetCallerCount(thunk);

            if (count > bestCount)
            {
                bestCount = count;
                best = thunk;
            }
        }

        return best;
    }

    /// <summary>
    /// Locates Il2CppCodeGenWriteBarrier, the GC write barrier emitted after every reference store into a
    /// heap object. Returns 0 where it can't be found, including builds which have write barriers disabled.
    /// </summary>
    protected virtual ulong GetWriteBarrier() => 0;

    /// <summary>
    /// Given a function at addr, find a function which serves no purpose other than to call addr.
    /// </summary>
    /// <param name="addr">The address of the function to call.</param>
    /// <param name="maxBytesBack">The maximum number of bytes to go back from any branching instructions to find the actual start of the thunk function.</param>
    /// <param name="addressesToIgnore">A list of function addresses which this function must not return</param>
    /// <returns>The address of the first function in the file which thunks addr, starts within maxBytesBack bytes of the branch, and is not contained within addressesToIgnore, else 0 if none can be found.</returns>
    protected abstract IEnumerable<ulong> FindAllThunkFunctions(ulong addr, uint maxBytesBack = 0, params ulong[] addressesToIgnore);

    /// <summary>
    /// Given a function at thunkPtr, return the address of the function that said function exists only to call.
    /// That is, given a function which performs no meaningful operations other than to call x, return the address of x.
    /// </summary>
    /// <param name="thunkPtr">The address of the thunk function</param>
    /// <param name="prioritiseCall">True to prioritise "call" statements - conditional flow transfer - over "jump" statements - unconditional flow transfer. False for the inverse.</param>
    /// <returns>The address of the thunked function, if it can be found, else 0</returns>
    protected abstract ulong FindFunctionThisIsAThunkOf(ulong thunkPtr, bool prioritiseCall = false);

    protected abstract int GetCallerCount(ulong toWhere);

    protected virtual void Init(ApplicationAnalysisContext context)
    {
        _appContext = context;
    }

    private void InitializeResolvedAddresses()
    {
        resolvedAddressMap.Clear();
        resolvedAddressSet.Clear();

        AddResolved(il2cpp_codegen_initialize_method);
        AddResolved(il2cpp_codegen_initialize_runtime_metadata);
        AddResolved(il2cpp_codegen_initialize_runtime_metadata_inline);
        AddResolved(il2cpp_vm_metadatacache_initializemethodmetadata);
        AddResolved(il2cpp_runtime_class_init_export);
        AddResolved(il2cpp_runtime_class_init_actual);
        AddResolved(il2cpp_codegen_runtime_class_init);
        AddResolved(il2cpp_object_new);
        AddResolved(il2cpp_vm_object_new);
        AddResolved(il2cpp_codegen_object_new);
        AddResolved(il2cpp_array_new_specific);
        AddResolved(il2cpp_vm_array_new_specific);
        AddResolved(SzArrayNew);
        AddResolved(il2cpp_type_get_object);
        AddResolved(il2cpp_vm_reflection_get_type_object);
        AddResolved(il2cpp_resolve_icall);
        AddResolved(InternalCalls_Resolve);

        AddResolved(il2cpp_string_new);
        AddResolved(il2cpp_vm_string_new);
        AddResolved(il2cpp_string_new_wrapper);
        AddResolved(il2cpp_vm_string_newWrapper);
        AddResolved(il2cpp_codegen_string_new_wrapper);

        AddResolved(il2cpp_value_box);
        AddResolved(il2cpp_vm_object_box);

        AddResolved(il2cpp_object_unbox);
        AddResolved(il2cpp_vm_object_unbox);

        AddResolved(il2cpp_raise_exception);
        AddResolved(il2cpp_vm_exception_raise);
        AddResolved(il2cpp_codegen_raise_exception);

        AddResolved(il2cpp_class_is_assignable_from);
        AddResolved(il2cpp_vm_class_is_assignable_from);
        AddResolved(il2cpp_vm_object_is_inst);
        AddResolved(il2cpp_codegen_object_is_inst);

        AddResolved(il2cpp_codegen_write_barrier);

        AddResolved(AddrPInvokeLookup);

        void AddResolved(ulong address, [CallerArgumentExpression(nameof(address))] string name = "")
        {
            resolvedAddressSet.Add(address);
            resolvedAddressMap[name] = address;
        }
    }
}
