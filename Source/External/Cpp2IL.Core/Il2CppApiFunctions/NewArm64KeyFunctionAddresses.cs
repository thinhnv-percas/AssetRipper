using System.Buffers.Binary;
using System.Collections.Generic;
using System.Linq;
using Disarm;
using Disarm.InternalDisassembly;
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

    private HashSet<ulong> CallTargets => field ??=
    [
        .. DisassembleTextSection()
            .Where(i => i.Mnemonic == Arm64Mnemonic.BL)
            .Select(i => i.BranchTarget)
    ];

    private bool IsFunctionStart(List<Arm64Instruction> disassembly, int index)
    {
        if (CallTargets.Contains(disassembly[index].Address))
            return true;

        if (index == 0)
            return true;

        // it's a function start if the previous instruction can't fall through into it
        var previous = disassembly[index - 1];
        return previous.Mnemonic is Arm64Mnemonic.RET or Arm64Mnemonic.RETAA or Arm64Mnemonic.RETAB or Arm64Mnemonic.BR or Arm64Mnemonic.BRK or Arm64Mnemonic.INVALID
               || (previous.Mnemonic == Arm64Mnemonic.B && previous.MnemonicConditionCode is Arm64ConditionCode.NONE or Arm64ConditionCode.AL);
    }

    protected override IEnumerable<ulong> FindAllThunkFunctions(ulong addr, uint maxBytesBack = 0, params ulong[] addressesToIgnore)
    {
        //Disassemble .text
        var disassembly = DisassembleTextSection();

        for (var index = 0; index < disassembly.Count; index++)
        {
            var instruction = disassembly[index];

            // a thunk ends by tail-calling the real function
            if (instruction.Mnemonic != Arm64Mnemonic.B || instruction.MnemonicConditionCode is not (Arm64ConditionCode.NONE or Arm64ConditionCode.AL) || instruction.BranchTarget != addr)
                continue;

            if (addressesToIgnore.Contains(instruction.Address))
                continue;

            // walk back over any setup instructions to the start of the function containing the branch,
            // bailing if it's too far away to be a thunk
            var maxInstructionsBack = (int)(maxBytesBack / 4);
            for (var back = 0; back <= maxInstructionsBack && index - back >= 0; back++)
            {
                if (!IsFunctionStart(disassembly, index - back))
                    continue;

                var start = disassembly[index - back].Address;
                if (!addressesToIgnore.Contains(start))
                    yield return start;

                break;
            }
        }
    }

    protected override ulong FindFirstCallTargetInMethod(ulong methodVa)
    {
        var instructions = NewArm64Utils.GetArm64MethodBodyAtVirtualAddress(_appContext.Binary, methodVa, false);
        var call = instructions.FirstOrDefault(i => i.Mnemonic == Arm64Mnemonic.BL);
        return call.Mnemonic == Arm64Mnemonic.BL ? call.BranchTarget : 0;
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
        var instructions = NewArm64Utils.GetArm64MethodBodyAtVirtualAddress(_appContext.Binary, typeIsInstanceOfType.MethodPointer, false);

        var lastCall = instructions.LastOrDefault(i => i.Mnemonic == Arm64Mnemonic.BL);

        if (lastCall.Mnemonic == Arm64Mnemonic.INVALID)
        {
            Logger.VerboseNewline("Method does not match expected signature. Aborting.");
            return 0;
        }

        Logger.VerboseNewline($"Success. IsInst found at 0x{lastCall.BranchTarget:X}");
        return lastCall.BranchTarget;
    }

    protected override ulong FindFunctionThisIsAThunkOf(ulong thunkPtr, bool prioritiseCall = false)
    {
        var instructions = NewArm64Utils.GetArm64MethodBodyAtVirtualAddress(_appContext.Binary, thunkPtr, false);

        var target = prioritiseCall ? Arm64Mnemonic.BL : Arm64Mnemonic.B;
        var matchingCall = instructions.FirstOrDefault(i => i.Mnemonic == target);

        if (matchingCall.Mnemonic == Arm64Mnemonic.INVALID)
        {
            target = target == Arm64Mnemonic.BL ? Arm64Mnemonic.B : Arm64Mnemonic.BL;
            matchingCall = instructions.FirstOrDefault(i => i.Mnemonic == target);
        }

        return matchingCall.Mnemonic != Arm64Mnemonic.INVALID ? matchingCall.BranchTarget : 0;
    }

    /// <summary>
    /// AssetRipper: every function containing a <c>BL</c> to <paramref name="target"/>, by walking back
    /// from the call site to the start of the function it sits in.
    /// </summary>
    protected override IEnumerable<ulong> FindCallersOf(ulong target)
    {
        var disassembly = DisassembleTextSection();

        for (var index = 0; index < disassembly.Count; index++)
        {
            if (disassembly[index].Mnemonic != Arm64Mnemonic.BL || disassembly[index].BranchTarget != target)
                continue;

            for (var back = 0; back <= MaxInstructionsInAFunction && index - back >= 0; back++)
            {
                if (!IsFunctionStart(disassembly, index - back))
                    continue;

                yield return disassembly[index - back].Address;
                break;
            }
        }
    }

    // A runtime function long enough to exceed this is not one anything here is looking for.
    private const int MaxInstructionsInAFunction = 4096;

    protected override int GetCallerCount(ulong toWhere)
        => BranchTargetCounts.GetValueOrDefault(toWhere);

    /// <summary>
    /// AssetRipper: how many <c>B</c> or <c>BL</c> instructions in the binary branch to each address.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This used to count over the disassembly of <c>.text</c>, which on an il2cpp .so holds the
    /// runtime and none of the generated method bodies — those are in a section of their own, called
    /// <c>il2cpp</c>. So a helper called 7999 times from managed code counted as 1, and every "which
    /// of these is the one managed code calls" decision was made on noise.
    /// </para>
    /// <para>
    /// The counts do not need a disassembler: on A64 both branches are one word with a signed 26 bit
    /// word displacement, so the histogram is a scan. Disarm over 14MB of generated code, for a
    /// number, would not be.
    /// </para>
    /// </remarks>
    private Dictionary<ulong, int> BranchTargetCounts => field ??= BuildBranchTargetCounts();

    private Dictionary<ulong, int> BuildBranchTargetCounts()
    {
        var counts = new Dictionary<ulong, int>();

        foreach (var (virtualAddress, data) in _appContext.Binary.GetExecutableSections())
        {
            var words = data.Span;

            for (var offset = 0; offset + 4 <= words.Length; offset += 4)
            {
                var word = BinaryPrimitives.ReadUInt32LittleEndian(words[offset..]);

                // B is 000101iiii..., BL is 100101iiii...; the immediate is a signed word count
                if ((word >> 26) is not (0b000101 or 0b100101))
                    continue;

                var displacement = (int)(word & 0x3FFFFFF);

                if ((displacement & 0x2000000) != 0)
                    displacement -= 0x4000000;

                var target = (ulong)((long)virtualAddress + offset + displacement * 4L);
                counts[target] = counts.GetValueOrDefault(target) + 1;
            }
        }

        return counts;
    }

    /// <summary>
    /// AssetRipper: locates <c>Il2CppCodeGenWriteBarrier</c> on A64.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The base class returned 0 for every architecture but x86, so on every ARM64 fixture the
    /// barrier was never found and every call to it stayed a <c>Method not found</c> placeholder -
    /// taking the field address it is handed with it, which then arrives in whatever register the
    /// next call reads. A <c>List&lt;T&gt;.Add</c> receiver on Merge-Room reads
    /// <c>this + 0x20</c> for exactly this reason.
    /// </para>
    /// <para>
    /// The barrier is not exported and no managed method sits on it, so it is found by its call
    /// sites. It is called immediately after a reference is stored into a heap object, with the
    /// address of the slot just written: <c>str x2, [x0, #0x20]; add x0, x0, #0x20; bl barrier</c>.
    /// Two routes agree on it. The corlib anchors are the x86 route, precise but strippable; the
    /// histogram is a decoder-free scan of every executable section for that shape, which separates
    /// the barrier from anything else by orders of magnitude because every reference store in the
    /// program performs it. Where both answer and disagree, neither is trusted.
    /// </para>
    /// </remarks>
    protected override ulong GetWriteBarrier()
    {
        var anchored = AnchoredWriteBarrierVotes();
        var scanned = ScannedWriteBarrierCounts();

        var anchorBest = Busiest(anchored);
        var scanBest = Busiest(scanned);

        if (anchorBest != 0 && scanBest != 0 && anchorBest != scanBest)
        {
            WriteBarrierEvidence = $"the corlib anchors say 0x{anchorBest:X} and the call-site scan "
                + $"says 0x{scanBest:X}; neither is taken";
            return 0;
        }

        var best = anchorBest != 0 ? anchorBest : scanBest;

        if (best == 0)
        {
            WriteBarrierEvidence = "no call site has the shape of a barrier; write barriers disabled?";
            return 0;
        }

        var sites = scanned.GetValueOrDefault(best);
        var runnerUp = 0;

        foreach (var candidate in scanned)
        {
            if (candidate.Key != best && candidate.Value > runnerUp)
                runnerUp = candidate.Value;
        }

        var evidence = $"0x{best:X}: {sites} call sites have the shape (next busiest {runnerUp}), "
            + $"{anchored.GetValueOrDefault(best)} of {WriteBarrierAnchors.Length} corlib anchors agree";

        // A leader is not evidence; a margin is. Every reference store in the program performs the
        // barrier, so a real one is called thousands of times and stands orders of magnitude clear:
        // Merge-Room measures 4064 against 459. A build with write barriers disabled has no such
        // call at all, and then the busiest target of a shape that also matches ordinary code is
        // noise - Impostor and RunFromZombies both measure 76 against 75, one site of margin, with
        // no corlib anchor agreeing. Taking that would map a helper onto whatever function happened
        // to win a coin toss, which is silent in exactly the way a wrong mapping always is.
        if (anchorBest == 0 && (sites < 500 || sites < runnerUp * 4))
        {
            WriteBarrierEvidence = evidence + "; not decisive, so not taken";
            return 0;
        }

        WriteBarrierEvidence = evidence;

        return best;
    }

    private static ulong Busiest(Dictionary<ulong, int> counts)
    {
        var best = 0ul;
        var bestCount = 0;

        foreach (var candidate in counts)
        {
            if (candidate.Value > bestCount)
            {
                best = candidate.Key;
                bestCount = candidate.Value;
            }
        }

        return best;
    }

    /// <summary>The barrier call in each corlib method known to store a reference into a field.</summary>
    private Dictionary<ulong, int> AnchoredWriteBarrierVotes()
    {
        var votes = new Dictionary<ulong, int>();

        foreach (var (@namespace, typeName, methodName) in WriteBarrierAnchors)
        {
            var method = ReflectionCache.GetType(typeName, @namespace)?.Methods?.FirstOrDefault(m => m.Name == methodName);

            if (method == null || method.MethodPointer == 0)
                continue;

            var body = NewArm64Utils.GetArm64MethodBodyAtVirtualAddress(_appContext.Binary, method.MethodPointer, false);

            foreach (var target in GuardedCallTargets(body).Distinct())
                votes[target] = votes.GetValueOrDefault(target) + 1;
        }

        return votes;
    }

    /// <summary>
    /// Every <c>BL</c> in <paramref name="body"/> preceded by a store into a slot and an
    /// <c>ADD X0</c> of that same slot's address.
    /// </summary>
    private static IEnumerable<ulong> GuardedCallTargets(List<Arm64Instruction> body)
    {
        const int window = 6;

        for (var index = 0; index < body.Count; index++)
        {
            if (body[index].Mnemonic != Arm64Mnemonic.BL)
                continue;

            var start = index - window < 0 ? 0 : index - window;

            for (var a = start; a < index; a++)
            {
                var add = body[a];

                if (add.Mnemonic != Arm64Mnemonic.ADD || add.Op0Reg != Arm64Register.X0
                    || add.Op1Kind != Arm64OperandKind.Register || add.Op2Kind != Arm64OperandKind.Immediate)
                    continue;

                for (var storeIndex = start; storeIndex < index; storeIndex++)
                {
                    var store = body[storeIndex];

                    if (store.Mnemonic != Arm64Mnemonic.STR || store.MemBase != add.Op1Reg
                        || store.MemAddendReg != Arm64Register.INVALID
                        || store.MemIndexMode != Arm64MemoryIndexMode.Offset
                        || store.MemOffset != add.Op2Imm)
                        continue;

                    yield return body[index].BranchTarget;
                    goto next;
                }
            }

            next: ;
        }
    }

    /// <summary>
    /// How many call sites in the whole binary have the barrier's shape, per target.
    /// </summary>
    /// <remarks>
    /// A64 encodings are fixed width, so this needs no disassembler and can cover every executable
    /// section - which matters, because the generated code is in a section called <c>il2cpp</c>
    /// rather than in <c>.text</c> and that is where every reference store in the program is.
    /// <c>STR Xt, [Xn, #imm12]</c> is <c>1111100100</c>, <c>ADD Xd, Xn, #imm12</c> with no shift is
    /// <c>1001000100</c>, and the store's immediate is scaled by eight where the add's is not.
    /// </remarks>
    private Dictionary<ulong, int> ScannedWriteBarrierCounts()
    {
        const int window = 6;
        var counts = new Dictionary<ulong, int>();

        foreach (var (virtualAddress, data) in _appContext.Binary.GetExecutableSections())
        {
            var words = data.Span;
            var count = words.Length / 4;

            for (var index = 0; index < count; index++)
            {
                var word = BinaryPrimitives.ReadUInt32LittleEndian(words[(index * 4)..]);

                if (word >> 26 != 0b100101)
                    continue;

                var start = index - window < 0 ? 0 : index - window;

                for (var a = start; a < index; a++)
                {
                    var add = BinaryPrimitives.ReadUInt32LittleEndian(words[(a * 4)..]);

                    // ADD X0, Xn, #imm12
                    if (add >> 22 != 0b1001000100 || (add & 0x1F) != 0)
                        continue;

                    var offset = (add >> 10) & 0xFFF;
                    var register = (add >> 5) & 0x1F;

                    for (var storeIndex = start; storeIndex < index; storeIndex++)
                    {
                        var store = BinaryPrimitives.ReadUInt32LittleEndian(words[(storeIndex * 4)..]);

                        // STR Xt, [Xn, #imm12 * 8], the same base and the same slot
                        if (store >> 22 != 0b1111100100 || ((store >> 5) & 0x1F) != register
                            || ((store >> 10) & 0xFFF) * 8 != offset)
                            continue;

                        var displacement = (int)(word & 0x3FFFFFF);

                        if ((displacement & 0x2000000) != 0)
                            displacement -= 0x4000000;

                        var target = (ulong)((long)virtualAddress + index * 4L + displacement * 4L);
                        counts[target] = counts.GetValueOrDefault(target) + 1;
                        goto next;
                    }
                }

                next: ;
            }
        }

        return counts;
    }
}
