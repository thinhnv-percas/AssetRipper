using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.Mips
{
	public sealed class MipsOperand
	{
		private readonly long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;

		private readonly MipsMemoryOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		private readonly MipsRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		private readonly MipsOperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public long Immediate
		{
			get
			{
				if (Type != MipsOperandType.Immediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Immediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;
			}
		}

		public MipsMemoryOperandValue Memory
		{
			get
			{
				if (Type != MipsOperandType.Memory)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Memory", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;
			}
		}

		public MipsRegister Register
		{
			get
			{
				if (Type != MipsOperandType.Register)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Register", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;
			}
		}

		public MipsOperandType Type
		{
			get;
		}

		internal static MipsOperand[] Create(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020 nativeInstructionDetail)
		{
			MipsOperand[] array = new MipsOperand[nativeInstructionDetail.OperandCount];
			for (int i = 0; i < array.Length; i++)
			{
				ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020 nativeOperand = ref nativeInstructionDetail.Operands[i];
				array[i] = new MipsOperand(disassembler, ref nativeOperand);
			}
			return array;
		}

		internal MipsOperand(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020 nativeOperand)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperand.Type;
			switch (Type)
			{
			case MipsOperandType.Immediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case MipsOperandType.Memory:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new MipsMemoryOperandValue(disassembler, ref nativeOperand.Value.Memory);
				break;
			case MipsOperandType.Register:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 = MipsRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.Register);
				break;
			}
		}
	}
}
