using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.Arm
{
	public sealed class ArmOperand
	{
		internal readonly OperandAccessType _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020;

		internal readonly double _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;

		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;

		internal readonly ArmMemoryOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		internal readonly ArmRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;

		internal readonly ArmSetEndOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A;

		internal readonly ArmRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020;

		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A;

		internal readonly ArmSystemRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A;

		[CompilerGenerated]
		internal readonly bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal readonly sbyte _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A;

		[CompilerGenerated]
		internal readonly ArmShiftOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020;

		[CompilerGenerated]
		internal readonly ArmOperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A;

		public OperandAccessType AccessType
		{
			get
			{
				CapstoneDisassembler.ThrowIfDietModeIsEnabled();
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020;
			}
		}

		public double FloatingPoint
		{
			get
			{
				if (Type != ArmOperandType.FloatingPoint)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "FloatingPoint", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;
			}
		}

		public int Immediate
		{
			get
			{
				if (Type != ArmOperandType.CImmediate && Type != ArmOperandType.Immediate && Type != ArmOperandType.PImmediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Immediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;
			}
		}

		public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

		public bool IsSubtracted
		{
			get;
		}

		public ArmMemoryOperandValue Memory
		{
			get
			{
				if (Type != ArmOperandType.Memory)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Memory", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;
			}
		}

		public sbyte NeonLane
		{
			get;
		}

		public ArmRegister Register
		{
			get
			{
				if (Type != ArmOperandType.Register)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Register", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;
			}
		}

		public ArmSetEndOperation SetEndOperation
		{
			get
			{
				if (Type != ArmOperandType.SetEndOperation)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "SetEndOperation", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A;
			}
		}

		public ArmShiftOperation ShiftOperation
		{
			get;
		}

		public ArmRegister ShiftRegister
		{
			get
			{
				if (ShiftOperation == ArmShiftOperation.Invalid)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "ShiftRegister", ShiftOperation));
				}
				if (ShiftOperation < ArmShiftOperation.ARM_SFT_ASR_REG)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "ShiftRegister", ShiftOperation));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020;
			}
		}

		public int ShiftValue
		{
			get
			{
				if (ShiftOperation == ArmShiftOperation.Invalid)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "ShiftValue", ShiftOperation));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A;
			}
		}

		public ArmSystemRegister SystemRegister
		{
			get
			{
				if (Type != ArmOperandType.SystemRegister)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "SystemRegister", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A;
			}
		}

		public ArmOperandType Type
		{
			get;
		}

		public int VectorIndex
		{
			get;
		}

		internal static ArmOperand[] Create(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A nativeInstructionDetail)
		{
			ArmOperand[] array = new ArmOperand[nativeInstructionDetail.OperandCount];
			for (int i = 0; i < array.Length; i++)
			{
				ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A nativeOperand = ref nativeInstructionDetail.Operands[i];
				array[i] = new ArmOperand(disassembler, ref nativeOperand);
			}
			return array;
		}

		internal ArmOperand(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A nativeOperand)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 = ((!CapstoneDisassembler.IsDietModeEnabled) ? nativeOperand.AccessType : OperandAccessType.Invalid);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020 = nativeOperand.IsSubtracted;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A = nativeOperand.NeonLane;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020 = nativeOperand.Shift.Operation;
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperand.Type;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A = nativeOperand.VectorIndex;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020 = _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A(this, disassembler, ref nativeOperand);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A = _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020(this, ref nativeOperand);
			switch (Type)
			{
			case ArmOperandType.CImmediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case ArmOperandType.FloatingPoint:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 = nativeOperand.Value.FloatingPoint;
				break;
			case ArmOperandType.Immediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case ArmOperandType.Memory:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new ArmMemoryOperandValue(disassembler, ref nativeOperand.Value.Memory);
				break;
			case ArmOperandType.PImmediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case ArmOperandType.Register:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 = ArmRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (ArmRegisterId)nativeOperand.Value.Register);
				break;
			case ArmOperandType.SetEndOperation:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A = nativeOperand.Value.SetEndOperation;
				break;
			case ArmOperandType.SystemRegister:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A = (ArmSystemRegister)nativeOperand.Value.Register;
				break;
			}
		}

		[CompilerGenerated]
		internal static int _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_0020(ArmOperand _0020, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A _0020_000A)
		{
			int result = 0;
			if (_0020.ShiftOperation != 0)
			{
				result = _0020_000A.Shift.Value;
			}
			return result;
		}

		[CompilerGenerated]
		internal static ArmRegister _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A(ArmOperand _0020, CapstoneDisassembler _0020_000A, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A _0020_0020)
		{
			ArmRegister result = null;
			if (_0020.ShiftOperation != 0 && _0020.ShiftOperation >= ArmShiftOperation.ARM_SFT_ASR_REG)
			{
				result = ArmRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(_0020_000A, (ArmRegisterId)_0020_0020.Shift.Value);
			}
			return result;
		}
	}
}
