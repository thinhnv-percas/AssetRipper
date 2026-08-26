using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.X86
{
	public sealed class X86Operand
	{
		private readonly OperandAccessType _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020;

		private readonly long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;

		private readonly X86MemoryOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		private readonly X86Register _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		private readonly X86AvxBroadcast _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A;

		[CompilerGenerated]
		private readonly bool _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		private readonly byte _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020;

		[CompilerGenerated]
		private readonly X86OperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public OperandAccessType AccessType
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020;
			}
		}

		public X86AvxBroadcast AvxBroadcast
		{
			get;
		}

		public bool AvxZeroOpMask
		{
			get;
		}

		public long Immediate
		{
			get
			{
				if (Type != X86OperandType.Immediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Immediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;
			}
		}

		public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

		public X86MemoryOperandValue Memory
		{
			get
			{
				if (Type != X86OperandType.Memory)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Memory", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;
			}
		}

		public X86Register Register
		{
			get
			{
				if (Type != X86OperandType.Register)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Register", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;
			}
		}

		public byte Size
		{
			get;
		}

		public X86OperandType Type
		{
			get;
		}

		internal static X86Operand[] Create(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020 nativeInstructionDetail)
		{
			X86Operand[] array = new X86Operand[nativeInstructionDetail.OperandCount];
			for (int i = 0; i < array.Length; i++)
			{
				ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020 nativeOperand = ref nativeInstructionDetail.Operands[i];
				array[i] = new X86Operand(disassembler, ref nativeOperand);
			}
			return array;
		}

		internal X86Operand(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020 nativeOperand)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 = ((!CapstoneDisassembler.IsDietModeEnabled) ? nativeOperand.AccessType : OperandAccessType.Invalid);
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_000A = nativeOperand.AvxBroadcast;
			_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020 = nativeOperand.AvxZeroOpMask;
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020 = nativeOperand.Size;
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperand.Type;
			switch (Type)
			{
			case X86OperandType.Immediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case X86OperandType.Memory:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new X86MemoryOperandValue(disassembler, ref nativeOperand.Value.Memory);
				break;
			case X86OperandType.Register:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 = X86Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.Register);
				break;
			}
		}
	}
}
