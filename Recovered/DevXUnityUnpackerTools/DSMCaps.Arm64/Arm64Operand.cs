using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.Arm64
{
	public sealed class Arm64Operand
	{
		internal readonly OperandAccessType _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020;

		internal readonly Arm64AtOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A;

		internal readonly Arm64BarrierOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020;

		internal readonly Arm64DcOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A;

		internal readonly double _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;

		internal readonly Arm64IcOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A;

		internal readonly long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;

		internal readonly Arm64MemoryOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		internal readonly Arm64MrsSystemRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020;

		internal readonly Arm64MsrSystemRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A;

		internal readonly Arm64PrefetchOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020;

		internal readonly Arm64PStateField _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A;

		internal readonly Arm64Register _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;

		internal readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A;

		internal readonly Arm64TlbiOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020;

		[CompilerGenerated]
		internal readonly Arm64ExtendOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A;

		[CompilerGenerated]
		internal readonly Arm64ShiftOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020;

		[CompilerGenerated]
		internal readonly Arm64OperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		[CompilerGenerated]
		internal readonly Arm64VectorArrangementSpecifier _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A;

		[CompilerGenerated]
		internal readonly Arm64VectorElementSizeSpecifier _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020;

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

		public Arm64AtOperation AtOperation
		{
			get
			{
				if (Type != Arm64OperandType.AtOperation)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "AtOperation", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A;
			}
		}

		public Arm64BarrierOperation BarrierOperation
		{
			get
			{
				if (Type != Arm64OperandType.BarrierOperation)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "BarrierOperation", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020;
			}
		}

		public Arm64DcOperation DcOperation
		{
			get
			{
				if (Type != Arm64OperandType.DcOperation)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "DcOperation", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A;
			}
		}

		public Arm64ExtendOperation ExtendOperation
		{
			get;
		}

		public double FloatingPoint
		{
			get
			{
				if (Type != Arm64OperandType.FloatingPoint)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "FloatingPoint", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020;
			}
		}

		public Arm64IcOperation IcOperation
		{
			get
			{
				if (Type != Arm64OperandType.IcOperation)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "IcOperation", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A;
			}
		}

		public long Immediate
		{
			get
			{
				if (Type != Arm64OperandType.CImmediate && Type != Arm64OperandType.Immediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Immediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;
			}
		}

		public bool IsDietModeEnabled => CapstoneDisassembler.IsDietModeEnabled;

		public Arm64MemoryOperandValue Memory
		{
			get
			{
				if (Type != Arm64OperandType.Memory)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Memory", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;
			}
		}

		public Arm64MrsSystemRegister MrsSystemRegister
		{
			get
			{
				if (Type != Arm64OperandType.MrsSystemRegister)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "MrsSystemRegister", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020;
			}
		}

		public Arm64MsrSystemRegister MsrSystemRegister
		{
			get
			{
				if (Type != Arm64OperandType.MsrSystemRegister)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "MsrSystemRegister", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A;
			}
		}

		public Arm64PrefetchOperation PrefetchOperation
		{
			get
			{
				if (Type != Arm64OperandType.PrefetchOperation)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "PrefetchOperation", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020;
			}
		}

		public Arm64PStateField PStateField
		{
			get
			{
				if (Type != Arm64OperandType.PStateField)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "PStateField", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A;
			}
		}

		public Arm64Register Register
		{
			get
			{
				if (Type != Arm64OperandType.Register)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Register", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;
			}
		}

		public Arm64ShiftOperation ShiftOperation
		{
			get;
		}

		public int ShiftValue
		{
			get
			{
				if (ShiftOperation == Arm64ShiftOperation.Invalid)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "ShiftValue", ShiftOperation));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A;
			}
		}

		public Arm64TlbiOperation TlbiOperation
		{
			get
			{
				if (Type != Arm64OperandType.TlbiOperation)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "TlbiOperation", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020;
			}
		}

		public Arm64OperandType Type
		{
			get;
		}

		public Arm64VectorArrangementSpecifier VectorArrangementSpecifier
		{
			get;
		}

		public Arm64VectorElementSizeSpecifier VectorElementSizeSpecifier
		{
			get;
		}

		public int VectorIndex
		{
			get;
		}

		internal static Arm64Operand[] Create(CapstoneDisassembler disassembler, Arm64InstructionId instructionId, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 nativeInstructionDetail)
		{
			Arm64Operand[] array = new Arm64Operand[nativeInstructionDetail.OperandCount];
			for (int i = 0; i < array.Length; i++)
			{
				ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 nativeOperand = ref nativeInstructionDetail.Operands[i];
				array[i] = new Arm64Operand(disassembler, instructionId, ref nativeOperand);
			}
			return array;
		}

		internal Arm64Operand(CapstoneDisassembler disassembler, Arm64InstructionId instructionId, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 nativeOperand)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020_0020 = ((!CapstoneDisassembler.IsDietModeEnabled) ? nativeOperand.AccessType : OperandAccessType.Invalid);
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A = nativeOperand.ExtendOperation;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020 = nativeOperand.Shift.Operation;
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperand.Type;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A = nativeOperand.VectorArrangementSpecifier;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020 = nativeOperand.VectorElementSizeSpecifier;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A = nativeOperand.VectorIndex;
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A = _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020(this, ref nativeOperand);
			switch (Type)
			{
			case Arm64OperandType.BarrierOperation:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_0020 = nativeOperand.Value.BarrierOperation;
				break;
			case Arm64OperandType.CImmediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case Arm64OperandType.FloatingPoint:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 = nativeOperand.Value.FloatingPoint;
				break;
			case Arm64OperandType.Immediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case Arm64OperandType.Memory:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new Arm64MemoryOperandValue(disassembler, ref nativeOperand.Value.Memory);
				break;
			case Arm64OperandType.MrsSystemRegister:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 = (Arm64MrsSystemRegister)nativeOperand.Value.Register;
				break;
			case Arm64OperandType.MsrSystemRegister:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_000A = (Arm64MsrSystemRegister)nativeOperand.Value.Register;
				break;
			case Arm64OperandType.PrefetchOperation:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020 = nativeOperand.Value.PrefetchOperation;
				break;
			case Arm64OperandType.PStateField:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_000A = nativeOperand.Value.PStateField;
				break;
			case Arm64OperandType.Register:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 = Arm64Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.Register);
				break;
			case Arm64OperandType.SystemOperation:
				switch (instructionId)
				{
				case Arm64InstructionId.ARM64_INS_AT:
					_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A = (Arm64AtOperation)nativeOperand.Value.SystemOperation;
					_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = Arm64OperandType.AtOperation;
					break;
				case Arm64InstructionId.ARM64_INS_DC:
					_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A = (Arm64DcOperation)nativeOperand.Value.SystemOperation;
					_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = Arm64OperandType.DcOperation;
					break;
				case Arm64InstructionId.ARM64_INS_IC:
					_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_000A = (Arm64IcOperation)nativeOperand.Value.SystemOperation;
					_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = Arm64OperandType.IcOperation;
					break;
				case Arm64InstructionId.ARM64_INS_TLBI:
					_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020 = (Arm64TlbiOperation)nativeOperand.Value.SystemOperation;
					_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = Arm64OperandType.TlbiOperation;
					break;
				}
				break;
			}
		}

		[CompilerGenerated]
		internal static int _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020(Arm64Operand _0020, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020 _0020_000A)
		{
			int result = 0;
			if (_0020.ShiftOperation != 0)
			{
				result = _0020_000A.Shift.Value;
			}
			return result;
		}
	}
}
