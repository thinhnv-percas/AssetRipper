using Cpp2IL.Core.ISIL;
using Cpp2IL.Core.InstructionSets;
using Disarm;
using Disarm.InternalDisassembly;
using System.Numerics;

namespace AssetRipper.Tests;

/// <summary>
/// The rules iteration 068 added, tested on real decoded A64 instruction words where the rule is in the lifter.
/// </summary>
public class Il2CppIteration068Tests
{
	// ------------------------------------------------------------------------------------------------------------
	// §4 - the width of an immediate. A W register is a 32 bit data path, so its immediate is the int its bits are.
	// ------------------------------------------------------------------------------------------------------------

	private static Arm64Instruction Decode(uint word, ulong address = 0x1000)
	{
		var bytes = BitConverter.GetBytes(word);
		return Disassembler.Disassemble(bytes, address, new Disassembler.Options(true, true, false)).Single();
	}

	private static long FirstImmediate(Arm64Instruction instruction)
	{
		var kinds = new[] { instruction.Op0Kind, instruction.Op1Kind, instruction.Op2Kind, instruction.Op3Kind };
		var index = Array.FindIndex(kinds, k => k == Arm64OperandKind.Immediate);
		Assert.That(index, Is.GreaterThanOrEqualTo(0), $"no immediate in {instruction}");
		return NewArmV8InstructionSet.LiftImmediate(instruction, index);
	}

	[TestCase(0x12800008u, -1L, TestName = "mov w8, #-1 is the int -1")]
	[TestCase(0x92800008u, -1L, TestName = "mov x8, #-1 is the long -1")]
	[TestCase(0x52B00008u, (long)int.MinValue, TestName = "mov w8, #0x80000000 is int.MinValue, not 2147483648")]
	[TestCase(0xD2B00008u, 0x80000000L, TestName = "mov x8, #0x80000000 is 2147483648")]
	[TestCase(0x12081D08u, -16777216L, TestName = "and w8, w8, #0xff000000 is the int mask")]
	[TestCase(0x3100051Fu, 1L, TestName = "cmn w8, #1")]
	[TestCase(0xB100051Fu, 1L, TestName = "cmn x8, #1")]
	[TestCase(0x31000420u, 1L, TestName = "adds w0, w1, #1")]
	[TestCase(0xB1000420u, 1L, TestName = "adds x0, x1, #1")]
	[TestCase(0x71000420u, 1L, TestName = "subs w0, w1, #1")]
	[TestCase(0xF1000420u, 1L, TestName = "subs x0, x1, #1")]
	public void AnImmediateIsLiftedAtTheWidthOfItsDataPath(uint word, long expected)
	{
		Assert.That(FirstImmediate(Decode(word)), Is.EqualTo(expected));
	}

	[Test]
	public void AThirtyTwoBitImmediateAlwaysFitsAnInt()
	{
		// The generator types a local from the constant it is given: ldc.i4 for a value that fits an int, ldc.i8
		// otherwise. Every immediate of a W instruction must therefore fit an int, whatever its bits.
		foreach (var value in new long[] { 0xFFFFFFFF, 0x80000000, 0xFFFF0000, 0x7FFFFFFF, 0, 1 })
		{
			var lifted = NewArmV8InstructionSet.ImmediateAtWidth(value, is64: false);
			Assert.That(lifted, Is.InRange(int.MinValue, int.MaxValue), $"0x{value:X}");
			Assert.That(unchecked((uint)lifted), Is.EqualTo(unchecked((uint)value)), $"0x{value:X} keeps its bits");
		}

		Assert.That(NewArmV8InstructionSet.ImmediateAtWidth(0xFFFFFFFF, is64: true), Is.EqualTo(0xFFFFFFFFL), "an X immediate is not narrowed");
	}

	[TestCase(Arm64Register.W0, true)]
	[TestCase(Arm64Register.W31, true)]
	[TestCase(Arm64Register.X0, false)]
	[TestCase(Arm64Register.X31, false)]
	[TestCase(Arm64Register.S0, false)]
	public void OnlyAWRegisterIsAThirtyTwoBitDataPath(Arm64Register register, bool expected)
	{
		Assert.That(NewArmV8InstructionSet.IsWRegister(register), Is.EqualTo(expected));
	}

	// The defect end to end: `mov w8, #-1; cmn w8, w9; b.hs`. The carry of the add is `(a + b) <u a`
	// (Arm64FlagLifting.Add), and the generator evaluates it at the width the operands' types give it -
	// 32 bits when every constant fits an int, 64 when one does not.

	private static int IlWidth(params long[] constants) => constants.All(c => c is >= int.MinValue and <= int.MaxValue) ? 32 : 64;

	private static bool EmittedCarry(long a, long b, int width)
	{
		var mask = width == 64 ? ulong.MaxValue : 0xFFFFFFFFUL;
		List<Instruction> emitted = [];
		Instruction Emit(OpCode opCode, params List<IOperand> operands)
		{
			var instruction = new Instruction(emitted.Count, opCode, operands);
			emitted.Add(instruction);
			return instruction;
		}

		Arm64FlagLifting.Add(Emit, new Register(null, "X8"), new Register(null, "X9"));

		// at the IL width: an int sign-extends nothing and a long holds the value as given
		var registers = new Dictionary<string, ulong>
		{
			["X8"] = unchecked((ulong)a) & mask,
			["X9"] = unchecked((ulong)b) & mask,
		};
		long Signed(ulong v) => unchecked(width == 64 ? (long)v : (int)(uint)v);
		ulong Value(IOperand operand) => operand switch
		{
			Register r => registers[r.Name],
			Immediate i => i.UnsignedValue & mask,
			_ => throw new NotSupportedException(),
		};
		foreach (var instruction in emitted)
		{
			ulong A() => Value(instruction.Operands[1]);
			ulong B() => Value(instruction.Operands[2]);
			registers[((Register)instruction.Operands[0]).Name] = unchecked(instruction.OpCode switch
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
				OpCode.CheckLess => (instruction.IsUnsigned ? A() < B() : Signed(A()) < Signed(B())) ? 1UL : 0UL,
				_ => throw new NotSupportedException(instruction.OpCode.ToString()),
			});
		}

		return registers["C"] != 0;
	}

	/// <summary>Arm ARM AddWithCarry's carry at 32 bits: what the machine computed.</summary>
	private static bool MachineCarry32(long a, long b)
		=> new BigInteger(unchecked((uint)a)) + new BigInteger(unchecked((uint)b)) > uint.MaxValue;

	[TestCase(0L)]
	[TestCase(1L)]
	[TestCase(5L)]
	[TestCase(0x7FFFFFFFL)]
	public void TheCarryOfMinusOnePlusACountIsThirtyTwoBit(long count)
	{
		var minusOne = FirstImmediate(Decode(0x12800008)); // mov w8, #-1
		var width = IlWidth(minusOne, count);

		Assert.That(width, Is.EqualTo(32), "the lifted constant must keep the expression at 32 bits");
		Assert.That(EmittedCarry(minusOne, count, width), Is.EqualTo(MachineCarry32(-1, count)), $"-1 + {count}");
	}

	[Test]
	public void TheOldRepresentationGaveTheWrongCarry()
	{
		// What 067 shipped: 0xFFFFFFFF kept as a long made the comparison 64 bit, and -1 + 5 stopped carrying.
		// This is the measurement the regression test above rests on; it must say the old form was wrong.
		const long old = 0xFFFFFFFF;
		Assert.Multiple(() =>
		{
			Assert.That(IlWidth(old, 5), Is.EqualTo(64));
			Assert.That(EmittedCarry(old, 5, 64), Is.Not.EqualTo(MachineCarry32(-1, 5)));
		});
	}
}
