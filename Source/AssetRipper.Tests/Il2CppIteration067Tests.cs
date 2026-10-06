using AsmResolver.PE.DotNet.Cil;
using Cpp2IL.Core;
using Cpp2IL.Core.Analysis;
using Cpp2IL.Core.Graphs;
using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.InstructionSets;
using Disarm;
using System.Numerics;

namespace AssetRipper.Tests;

/// <summary>
/// The rules iteration 067 added, each tested without metadata behind it.
/// </summary>
public class Il2CppIteration067Tests
{
	// ------------------------------------------------------------------------------------------------------------
	// §10 - A64 flags. The ISIL the lifter emits is evaluated directly and compared with the Arm ARM's AddWithCarry,
	// so a test fails if the emitted sequence is wrong, not only if a helper is.
	// ------------------------------------------------------------------------------------------------------------

	private static readonly Arm64ConditionCode[] AllConditions =
	[
		Arm64ConditionCode.EQ, Arm64ConditionCode.NE, Arm64ConditionCode.CS, Arm64ConditionCode.CC,
		Arm64ConditionCode.MI, Arm64ConditionCode.PL, Arm64ConditionCode.VS, Arm64ConditionCode.VC,
		Arm64ConditionCode.HI, Arm64ConditionCode.LS, Arm64ConditionCode.GE, Arm64ConditionCode.LT,
		Arm64ConditionCode.GT, Arm64ConditionCode.LE,
	];

	private readonly record struct Flags(bool N, bool Z, bool C, bool V);

	/// <summary>Arm ARM shared/functions/integer/AddWithCarry.</summary>
	private static Flags AddWithCarry(ulong x, ulong y, int carryIn, int width)
	{
		var mask = Mask(width);
		x &= mask;
		y &= mask;
		var unsignedSum = new BigInteger(x) + new BigInteger(y) + carryIn;
		var signedSum = new BigInteger(Signed(x, width)) + new BigInteger(Signed(y, width)) + carryIn;
		var result = (ulong)(unsignedSum & new BigInteger(mask));
		return new Flags(
			N: Signed(result, width) < 0,
			Z: result == 0,
			C: new BigInteger(result) != unsignedSum,
			V: new BigInteger(Signed(result, width)) != signedSum);
	}

	private static Flags ReferenceSubtract(ulong a, ulong b, int width) => AddWithCarry(a, ~b, 1, width);

	private static Flags ReferenceAdd(ulong a, ulong b, int width) => AddWithCarry(a, b, 0, width);

	/// <summary>Arm ARM ConditionHolds.</summary>
	private static bool ReferenceCondition(Arm64ConditionCode condition, Flags f) => condition switch
	{
		Arm64ConditionCode.EQ => f.Z,
		Arm64ConditionCode.NE => !f.Z,
		Arm64ConditionCode.CS => f.C,
		Arm64ConditionCode.CC => !f.C,
		Arm64ConditionCode.MI => f.N,
		Arm64ConditionCode.PL => !f.N,
		Arm64ConditionCode.VS => f.V,
		Arm64ConditionCode.VC => !f.V,
		Arm64ConditionCode.HI => f.C && !f.Z,
		Arm64ConditionCode.LS => !(f.C && !f.Z),
		Arm64ConditionCode.GE => f.N == f.V,
		Arm64ConditionCode.LT => f.N != f.V,
		Arm64ConditionCode.GT => !f.Z && f.N == f.V,
		Arm64ConditionCode.LE => !(!f.Z && f.N == f.V),
		_ => true,
	};

	private static ulong Mask(int width) => width == 64 ? ulong.MaxValue : (1UL << width) - 1;

	private static long Signed(ulong value, int width) => unchecked(width == 64 ? (long)value : (int)(uint)value);

	/// <summary>Executes flag ISIL at one register width: what the generated IL computes on operands of that width.</summary>
	private static Dictionary<string, ulong> Evaluate(List<Instruction> instructions, Dictionary<string, ulong> registers, int width)
	{
		var mask = Mask(width);

		ulong Value(IOperand operand) => operand switch
		{
			Register register => registers[register.Name],
			Immediate immediate => unchecked(immediate.UnsignedValue) & mask,
			_ => throw new NotSupportedException(operand.GetType().Name),
		};

		foreach (var instruction in instructions)
		{
			var destination = ((Register)instruction.Operands[0]).Name;
			ulong A() => Value(instruction.Operands[1]);
			ulong B() => Value(instruction.Operands[2]);
			registers[destination] = unchecked(instruction.OpCode switch
			{
				OpCode.Move => A(),
				OpCode.Add => (A() + B()) & mask,
				OpCode.Subtract => (A() - B()) & mask,
				OpCode.Xor => A() ^ B(),
				OpCode.And => A() & B(),
				OpCode.Or => A() | B(),
				OpCode.Not => A() == 0 ? 1UL : 0UL,
				OpCode.Negate => (0 - A()) & mask,
				OpCode.CheckEqual => A() == B() ? 1UL : 0UL,
				OpCode.CheckLess => (instruction.IsUnsigned ? A() < B() : Signed(A(), width) < Signed(B(), width)) ? 1UL : 0UL,
				_ => throw new NotSupportedException(instruction.OpCode.ToString()),
			});
		}

		return registers;
	}

	private static (Flags Flags, Dictionary<Arm64ConditionCode, bool> Conditions, List<Instruction> Emitted) Lift(bool add, IOperand op0, IOperand op1, Dictionary<string, ulong> registers, int width)
	{
		List<Instruction> emitted = [];
		Instruction Emit(OpCode opCode, params List<IOperand> operands)
		{
			var instruction = new Instruction(emitted.Count, opCode, operands);
			emitted.Add(instruction);
			return instruction;
		}

		if (add)
			Arm64FlagLifting.Add(Emit, op0, op1);
		else
			Arm64FlagLifting.Subtract(Emit, op0, op1);
		var flagCount = emitted.Count;

		var conditionOperands = AllConditions.ToDictionary(c => c, c => Arm64FlagLifting.Condition(Emit, c));
		// each condition reuses TEMPCOND, so evaluate the flags once and every condition on its own
		var state = Evaluate(emitted.Take(flagCount).ToList(), registers, width);
		var flags = new Flags(state["N"] != 0, state["Z"] != 0, state["C"] != 0, state["V"] != 0);

		Dictionary<Arm64ConditionCode, bool> conditions = [];
		foreach (var condition in AllConditions)
		{
			List<Instruction> own = [];
			var result = Arm64FlagLifting.Condition((opCode, operands) =>
			{
				var instruction = new Instruction(own.Count, opCode, operands);
				own.Add(instruction);
				return instruction;
			}, condition);
			var after = Evaluate(own, new Dictionary<string, ulong>(state), width);
			conditions[condition] = (result is Register r ? after[r.Name] : ((Immediate)result).UnsignedValue) != 0;
		}

		return (flags, conditions, emitted);
	}

	private static void AssertMatchesArm(bool add, ulong a, ulong b, int width, bool immediate = false)
	{
		var registers = new Dictionary<string, ulong> { ["X0"] = a & Mask(width), ["X1"] = b & Mask(width) };
		IOperand op1 = immediate ? new Immediate(unchecked((long)b)) : new Register(null, "X1");
		var (flags, conditions, _) = Lift(add, new Register(null, "X0"), op1, registers, width);
		var expected = add ? ReferenceAdd(a, b, width) : ReferenceSubtract(a, b, width);

		var label = $"{(add ? "adds" : "subs")} 0x{a:X} {(immediate ? "#" : "")}0x{b:X} at {width} bits";
		Assert.That(flags, Is.EqualTo(expected), label);
		foreach (var condition in AllConditions)
			Assert.That(conditions[condition], Is.EqualTo(ReferenceCondition(condition, expected)), $"{label}: {condition}");
	}

	[TestCase(0xFFFFFFFFUL, 1UL)]
	[TestCase(0xFFFFFFFFUL, 0xFFFFFFFFUL)]
	[TestCase(0x7FFFFFFFUL, 1UL)]
	[TestCase(0x80000000UL, 0x80000000UL)]
	[TestCase(0UL, 0UL)]
	[TestCase(5UL, 0UL)]
	[TestCase(0xFFFFFFF6UL, 10UL)]
	[TestCase(0UL, 10UL)]
	public void ThirtyTwoBitAddsSetsEveryFlagAsTheArchitectureDoes(ulong a, ulong b)
	{
		AssertMatchesArm(add: true, a, b, 32);
	}

	[Test]
	public void TheAdditionOfTwoMostNegativeValuesOverflows()
	{
		// The vector the iteration 066 lifting got wrong: a - (-b) with b = 0x80000000 negates to itself, so the
		// subtraction is 0 - 0 and reports no overflow. -2^31 + -2^31 does overflow, and carries.
		AssertMatchesArm(add: true, 0x80000000UL, 0x80000000UL, 32);
		var (flags, _, _) = Lift(true, new Register(null, "X0"), new Register(null, "X1"),
			new Dictionary<string, ulong> { ["X0"] = 0x80000000UL, ["X1"] = 0x80000000UL }, 32);
		Assert.That(flags, Is.EqualTo(new Flags(N: false, Z: true, C: true, V: true)));
	}

	[Test]
	public void AddingZeroNeverCarries()
	{
		// The other vector a - (-b) gets wrong: subtracting zero never borrows, so C would read 1.
		AssertMatchesArm(add: true, 0x1234UL, 0UL, 32, immediate: true);
		AssertMatchesArm(add: true, 0xFFFFFFFFUL, 0UL, 32);
	}

	[TestCase(0xFFFFFFFFFFFFFFFFUL, 1UL)]
	[TestCase(0xFFFFFFFFFFFFFFFFUL, 0xFFFFFFFFFFFFFFFFUL)]
	[TestCase(0x7FFFFFFFFFFFFFFFUL, 1UL)]
	[TestCase(0x8000000000000000UL, 0x8000000000000000UL)]
	[TestCase(0x00000000FFFFFFFFUL, 1UL)]
	public void SixtyFourBitAddsSetsEveryFlagAsTheArchitectureDoes(ulong a, ulong b)
	{
		AssertMatchesArm(add: true, a, b, 64);
	}

	[TestCase(0UL, 1UL)]
	[TestCase(1UL, 0UL)]
	[TestCase(5UL, 5UL)]
	[TestCase(0x80000000UL, 1UL)]
	[TestCase(0x7FFFFFFFUL, 0xFFFFFFFFUL)]
	[TestCase(0xFFFFFFFFUL, 0UL)]
	[TestCase(0UL, 0x80000000UL)]
	[TestCase(0xFFFFFFFFUL, 0x7FFFFFFFUL)]
	public void ThirtyTwoBitSubsSetsEveryFlagAsTheArchitectureDoes(ulong a, ulong b)
	{
		AssertMatchesArm(add: false, a, b, 32);
	}

	[TestCase(0UL, 1UL)]
	[TestCase(0x8000000000000000UL, 1UL)]
	[TestCase(0xFFFFFFFFFFFFFFFFUL, 0UL)]
	[TestCase(0x7FFFFFFFFFFFFFFFUL, 0xFFFFFFFFFFFFFFFFUL)]
	public void SixtyFourBitSubsSetsEveryFlagAsTheArchitectureDoes(ulong a, ulong b)
	{
		AssertMatchesArm(add: false, a, b, 64);
	}

	[Test]
	public void ASmallImmediateAdditionIsExactInItsReadableForm()
	{
		// `cmn w12, #0xa; b.lo` is `(uint)(c - '0') < 10`. The immediate path is lifted as a comparison against -10,
		// which reads like the source; it must agree with the architecture for every first operand.
		ulong[] firstOperands = [0, 1, 9, 10, 0x7FFFFFFF, 0x80000000, 0xFFFFFFF5, 0xFFFFFFF6, 0xFFFFFFFF];
		foreach (var a in firstOperands)
			foreach (var b in new ulong[] { 1, 10, 0xFFF, 0xFFF000 })
				AssertMatchesArm(add: true, a, b, 32, immediate: true);
	}

	[Test]
	public void TheDigitTestAcceptsDigitsAndRejectsTheCharacterAfterNine()
	{
		// sub w12, w11, #0x3a; cmn w12, #0xa; b.lo reject
		foreach (var c in "0123456789:/A")
		{
			var w12 = unchecked((ulong)(uint)(c - 0x3A));
			var (_, conditions, _) = Lift(true, new Register(null, "X0"), new Immediate(10),
				new Dictionary<string, ulong> { ["X0"] = w12 }, 32);
			Assert.That(conditions[Arm64ConditionCode.CC], Is.EqualTo(!char.IsAsciiDigit(c)), c.ToString());
		}
	}

	[Test]
	public void TheCarryOfASubtractionIsAnUnsignedComparisonAndNothingElseIs()
	{
		var (_, _, emitted) = Lift(false, new Register(null, "X0"), new Register(null, "X1"),
			new Dictionary<string, ulong> { ["X0"] = 0, ["X1"] = 0 }, 64);
		var flagSetters = emitted.Where(i => i.OpCode == OpCode.CheckLess).ToList();

		Assert.That(flagSetters.Single(i => ((Register)i.Operands[0]).Name == "C").IsUnsigned, Is.True);
		Assert.That(flagSetters.Where(i => ((Register)i.Operands[0]).Name is "N" or "V").All(i => !i.IsUnsigned), Is.True);
	}

	[Test]
	public void AnUnsignedComparisonIsWrittenWithTheUnsignedOpcodesOnlyForIntegers()
	{
		var unsigned = new Instruction(0, OpCode.CheckLess, new Register(null, "C"), new Register(null, "X0"), new Register(null, "X1")) { IsUnsigned = true };
		var signed = new Instruction(0, OpCode.CheckLess, new Register(null, "N"), new Register(null, "X0"), new Register(null, "X1"));

		Assert.Multiple(() =>
		{
			Assert.That(IlGenerator.ComparisonOpCodes(unsigned, isFloat: false), Is.EqualTo((CilOpCodes.Clt_Un, CilOpCodes.Cgt_Un)));
			Assert.That(IlGenerator.ComparisonOpCodes(signed, isFloat: false), Is.EqualTo((CilOpCodes.Clt, CilOpCodes.Cgt)));
			// on floats .un means "or unordered", which the flag does not
			Assert.That(IlGenerator.ComparisonOpCodes(unsigned, isFloat: true), Is.EqualTo((CilOpCodes.Clt, CilOpCodes.Cgt)));
		});
	}

	[Test]
	public void TheX86SignFlagRuleDoesNotReadAnUnsignedCarryAsASign()
	{
		// C of `cmp t, #0` is `t <u 0`, which has the shape of x86's sign flag `t < 0`; FlagConditionRecovery must not
		// rewrite the branch into a signed `a < b` off it.
		var a = new LocalVariable("a", new Register(null, "X0"));
		var b = new LocalVariable("b", new Register(null, "X1"));
		var t = new LocalVariable("t", new Register(null, "X2"));
		var carry = new LocalVariable("c", new Register(null, "C"));

		Block entry = new() { ID = 0 };
		entry.AddInstruction(new Instruction(0, OpCode.Subtract, t, a, b));
		var carryCheck = new Instruction(1, OpCode.CheckLess, carry, t, new Immediate(0)) { IsUnsigned = true };
		entry.AddInstruction(carryCheck);
		Block target = new() { ID = 1 };
		target.AddInstruction(new Instruction(3, OpCode.Return));
		entry.AddInstruction(new Instruction(2, OpCode.ConditionalJump, target, carry));
		entry.Successors.Add(target);
		target.Predecessors.Add(entry);
		var graph = new ISILControlFlowGraph([]) { EntryBlock = entry, ExitBlock = target, Blocks = [entry, target] };

		FlagConditionRecovery.Run(graph);

		Assert.Multiple(() =>
		{
			Assert.That(carryCheck.Operands[1], Is.EqualTo(t));
			Assert.That(carryCheck.IsUnsigned, Is.True);
		});
	}

	// ------------------------------------------------------------------------------------------------------------
	// Parameter typing: each parameter local takes its own parameter's type, not the n-th one's.
	// ------------------------------------------------------------------------------------------------------------

	[Test]
	public void AParameterLocalIsTypedFromItsOwnParameterWhenAnEarlierOneHasNoLocal()
	{
		// TryConvert(T instance, ConvertBinder binder, out object result): nothing reads `instance`, so it has no local.
		var binder = new LocalVariable("binder", new Register(null, "X2")) { ParameterIndex = 1 };
		var result = new LocalVariable("result", new Register(null, "X3")) { ParameterIndex = 2 };
		var self = new LocalVariable("this", new Register(null, "X0")) { IsThis = true };
		List<(string Local, int Parameter)> asked = [];
		var current = "";

		LocalVariables.AssignParameterTypes(Track(self, binder, result), index => { asked.Add((current, index)); return null; }, 3);

		Assert.That(asked, Is.EqualTo(new[] { ("binder", 1), ("result", 2) }));

		IEnumerable<LocalVariable> Track(params LocalVariable[] locals)
		{
			foreach (var local in locals)
			{
				current = local.Name;
				yield return local;
			}
		}
	}

	// ------------------------------------------------------------------------------------------------------------
	// Write barrier: the pre-indexed store Apple clang folds the slot's address into.
	// ------------------------------------------------------------------------------------------------------------

	[TestCase(0xF8028C01u, true, Description = "str x1, [x0, #0x28]! - JellyBlastV2 0xFBC5D8")]
	[TestCase(0xF8020C14u, true, Description = "str x20, [x0, #0x20]!")]
	[TestCase(0xF8010C1Fu, true, Description = "str xzr, [x0, #0x10]! - a null stored with a barrier")]
	[TestCase(0xF8018E7Fu, false, Description = "str xzr, [x19, #0x18]! - not into X0")]
	[TestCase(0xF9000278u, false, Description = "str x24, [x19] - unsigned offset, no writeback")]
	[TestCase(0xF8028401u, false, Description = "str x1, [x0], #0x28 - post-index leaves the old address")]
	[TestCase(0xB8028C01u, false, Description = "str w1, [x0, #0x28]! - a 32-bit store is never a reference")]
	public void APreIndexedStoreIntoX0IsTheBarriersShape(uint word, bool expected)
	{
		Assert.That(Cpp2IL.Core.Il2CppApiFunctions.NewArm64KeyFunctionAddresses.IsPreIndexedStoreIntoX0(word), Is.EqualTo(expected));
	}
}
