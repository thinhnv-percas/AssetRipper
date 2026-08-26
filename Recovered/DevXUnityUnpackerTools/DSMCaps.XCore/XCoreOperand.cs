using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.XCore
{
	public sealed class XCoreOperand
	{
		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;

		internal readonly XCoreMemoryOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		internal readonly XCoreRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		internal readonly XCoreOperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public long Immediate
		{
			get
			{
				if (Type != XCoreOperandType.Immediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Immediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;
			}
		}

		public XCoreMemoryOperandValue Memory
		{
			get
			{
				if (Type != XCoreOperandType.Memory)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Memory", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;
			}
		}

		public XCoreRegister Register
		{
			get
			{
				if (Type != XCoreOperandType.Register)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Register", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;
			}
		}

		public XCoreOperandType Type
		{
			get;
		}

		internal static XCoreOperand[] Create(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 nativeInstructionDetail)
		{
			XCoreOperand[] array = new XCoreOperand[nativeInstructionDetail.OperandCount];
			for (int i = 0; i < array.Length; i++)
			{
				ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020 nativeOperand = ref nativeInstructionDetail.Operands[i];
				array[i] = new XCoreOperand(disassembler, ref nativeOperand);
			}
			return array;
		}

		internal XCoreOperand(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020 nativeOperand)
		{
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperand.Type;
			switch (Type)
			{
			case XCoreOperandType.Immediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case XCoreOperandType.Memory:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new XCoreMemoryOperandValue(disassembler, ref nativeOperand.Value.Memory);
				break;
			case XCoreOperandType.Register:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 = XCoreRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.Register);
				break;
			}
		}
	}
}
