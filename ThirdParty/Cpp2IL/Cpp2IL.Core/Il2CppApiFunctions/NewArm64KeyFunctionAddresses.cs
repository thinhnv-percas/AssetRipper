using System.Collections.Generic;
using System.Linq;
using Disarm;
using Cpp2IL.Core.Logging;
using Cpp2IL.Core.Utils;

namespace Cpp2IL.Core.Il2CppApiFunctions;

public class NewArm64KeyFunctionAddresses : BaseKeyFunctionAddresses
{
    private List<Arm64Instruction>? _cachedDisassembledBytes;

    private List<Arm64Instruction> DisassembleTextSection()
    {
        if (_cachedDisassembledBytes == null)
        {
            var binary = _appContext.Binary;
            var toDisasm = binary.GetEntirePrimaryExecutableSection();
            _cachedDisassembledBytes = Disassembler.Disassemble(toDisasm, binary.GetVirtualAddressOfPrimaryExecutableSection(), new(true, true, false)).ToList();
        }

        return _cachedDisassembledBytes;
    }

    /// <remarks>
    /// The managed method bodies do not live in the section the thunk search disassembles, so this
    /// disassembles the one method rather than looking it up there. A body ends at its first return, and
    /// anything past that belongs to the next method.
    /// </remarks>
    protected override ulong FindFirstCallTargetInMethod(ulong methodPointer)
    {
        foreach (var instruction in NewArm64Utils.GetArm64MethodBodyAtVirtualAddress(_appContext.Binary, methodPointer))
        {
            if (instruction.Mnemonic == Arm64Mnemonic.BL)
                return instruction.BranchTarget;

            if (instruction.Mnemonic == Arm64Mnemonic.RET)
                return 0;
        }

        return 0;
    }

    protected override IEnumerable<ulong> FindAllThunkFunctions(ulong addr, uint maxBytesBack = 0, params ulong[] addressesToIgnore)
    {
        //Disassemble .text
        var disassembly = DisassembleTextSection();

        //Find all jumps to the target address
        var matchingJmps = disassembly.Where(i => i.Mnemonic is Arm64Mnemonic.B or Arm64Mnemonic.BL && i.BranchTarget == addr).ToList();

        foreach (var matchingJmp in matchingJmps)
        {
            if (addressesToIgnore.Contains(matchingJmp.Address)) continue;

            //Find this instruction in the raw file
            var binary = _appContext.Binary;
            var offsetInPe = (ulong)binary.MapVirtualAddressToRaw(matchingJmp.Address);
            if (offsetInPe == 0 || offsetInPe == (ulong)(binary.RawLength - 1))
                continue;

            //get next and previous bytes
            var previousByte = binary.GetByteAtRawAddress(offsetInPe - 1);
            var nextByte = binary.GetByteAtRawAddress(offsetInPe + 4);

            //Double-cc = thunk
            if (previousByte == 0xCC && nextByte == 0xCC)
            {
                yield return matchingJmp.Address;
                continue;
            }

            if (nextByte == 0xCC && maxBytesBack > 0)
            {
                for (ulong backtrack = 1; backtrack < maxBytesBack && offsetInPe - backtrack > 0; backtrack++)
                {
                    if (addressesToIgnore.Contains(matchingJmp.Address - (backtrack - 1)))
                        //Move to next jmp
                        break;

                    if (binary.GetByteAtRawAddress(offsetInPe - backtrack) == 0xCC)
                    {
                        yield return matchingJmp.Address - (backtrack - 1);
                        break;
                    }
                }
            }
        }
    }

    protected override ulong GetObjectIsInstFromSystemType()
    {
        Logger.Verbose("\tTrying to use System.Type::IsInstanceOfType to find il2cpp::vm::Object::IsInst...");
        var typeIsInstanceOfType = ReflectionCache.GetType("Type", "System")?.Methods?.FirstOrDefault(m => m.Name == "IsInstanceOfType");
        if (typeIsInstanceOfType == null)
        {
            Logger.VerboseNewline("Type or method not found, aborting.");
            return 0;
        }

        //IsInstanceOfType is a very simple ICall, that looks like this:
        //  Il2CppClass* klass = vm::Class::FromIl2CppType(type->type.type);
        //  return il2cpp::vm::Object::IsInst(obj, klass) != NULL;
        //The last call is to Object::IsInst

        Logger.Verbose($"IsInstanceOfType found at 0x{typeIsInstanceOfType.MethodPointer:X}...");
        var instructions = NewArm64Utils.GetArm64MethodBodyAtVirtualAddress(_appContext.Binary, typeIsInstanceOfType.MethodPointer, true);

        var lastCall = instructions.LastOrDefault(i => i.Mnemonic == Arm64Mnemonic.BL);

        if (lastCall.Mnemonic == Arm64Mnemonic.INVALID)
        {
            Logger.VerboseNewline("Method does not match expected signature. Aborting.");
            return 0;
        }

        // Object::IsInst is part of the runtime and so is not a managed method. Landing on one means
        // this build does not write IsInstanceOfType the way the rule above assumes - on the measured
        // game it calls one method and then tail branches - and a name on the wrong function is worse
        // than no name at all.
        if (_appContext.MethodsByAddress.ContainsKey(lastCall.BranchTarget))
        {
            Logger.VerboseNewline($"Last call is to the managed method at 0x{lastCall.BranchTarget:X}, so this is not IsInst. Aborting.");
            return 0;
        }

        Logger.VerboseNewline($"Success. IsInst found at 0x{lastCall.BranchTarget:X}");
        return lastCall.BranchTarget;
    }

    protected override ulong FindFunctionThisIsAThunkOf(ulong thunkPtr, bool prioritiseCall = false)
    {
        var instructions = NewArm64Utils.GetArm64MethodBodyAtVirtualAddress(_appContext.Binary, thunkPtr, true);

        var target = prioritiseCall ? Arm64Mnemonic.BL : Arm64Mnemonic.B;
        var matchingCall = instructions.FirstOrDefault(i => i.Mnemonic == target);

        if (matchingCall.Mnemonic == Arm64Mnemonic.INVALID)
        {
            target = target == Arm64Mnemonic.BL ? Arm64Mnemonic.B : Arm64Mnemonic.BL;
            matchingCall = instructions.FirstOrDefault(i => i.Mnemonic == target);
        }

        return matchingCall.Mnemonic != Arm64Mnemonic.INVALID ? matchingCall.BranchTarget : 0;
    }

    protected override int GetCallerCount(ulong toWhere)
    {
        //Disassemble .text
        var disassembly = DisassembleTextSection();

        //Find all jumps to the target address
        return disassembly.Count(i => i.Mnemonic is Arm64Mnemonic.B or Arm64Mnemonic.BL && i.BranchTarget == toWhere);
    }
}
