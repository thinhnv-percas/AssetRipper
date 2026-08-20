using System.Collections.Generic;
using System.Linq;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.Model.Contexts;

namespace Cpp2IL.Core.Analysis;

/// <summary>
/// Maps calls to KeyFunctionAddresses to their underlying IL opcodes. E.g. il2cpp_codegen_object_new => newobj.
/// Eventually will include box/unbox/throw/etc
/// </summary>
public static class KeyFunctionRecovery
{
    //All of these have the same params in the same order so we treat them as equal.
    private static readonly HashSet<string> ObjectNewFunctions =
    [
        "il2cpp_object_new",
        "il2cpp_vm_object_new",
        "il2cpp_codegen_object_new",
    ];

    /// <summary>
    /// The runtime calls that do bookkeeping and mean nothing in managed terms.
    /// </summary>
    /// <remarks>
    /// Metadata initialization fills in the globals the method is about to read, and a class init runs
    /// a static constructor, which C# does not write either. Left alone they are the single largest
    /// source of noise in a recovered body: the compiler emits them before nearly every metadata use.
    /// </remarks>
    private static readonly HashSet<string> BookkeepingFunctions =
    [
        "il2cpp_codegen_initialize_method",
        "il2cpp_codegen_initialize_runtime_metadata",
        "il2cpp_vm_metadatacache_initializemethodmetadata",
        "il2cpp_runtime_class_init_export",
        "il2cpp_runtime_class_init_actual",
    ];

    /// <summary>
    /// Drops the bookkeeping calls, which has to happen after the metadata init guards are removed,
    /// since those are recognised by the very calls this deletes.
    /// </summary>
    /// <remarks>
    /// Only the void form is dropped. The same functions are sometimes called for their return value,
    /// which is the pointer they initialized, and deleting one of those would leave the value it
    /// produced undefined.
    /// </remarks>
    public static void RemoveBookkeepingCalls(MethodAnalysisContext method)
    {
        foreach (var instruction in method.ControlFlowGraph!.Instructions)
        {
            if (instruction.OpCode != OpCode.CallVoid || instruction.Operands is not [string name, ..])
                continue;

            if (!BookkeepingFunctions.Contains(name))
                continue;

            instruction.OpCode = OpCode.Nop;
            instruction.Operands = [];
        }
    }

    public static void Run(MethodAnalysisContext method)
    {
        foreach (var instruction in method.ControlFlowGraph!.Blocks.SelectMany(block => block.Instructions))
        {
            if (instruction.Operands is not [string keyFunction, ..])
                continue;

            if (ObjectNewFunctions.Contains(keyFunction))
                RewriteObjectNew(instruction);
        }
    }
    
    private static void RewriteObjectNew(Instruction instruction)
    {
        // Needs the function name, the result, and the class argument.
        if (instruction.OpCode != OpCode.Call || instruction.Operands.Count < 3)
            return;

        var result = instruction.Operands[1];
        var klass = instruction.Operands[2];

        instruction.OpCode = OpCode.Newobj;
        instruction.Operands = [result, klass];
    }
}
