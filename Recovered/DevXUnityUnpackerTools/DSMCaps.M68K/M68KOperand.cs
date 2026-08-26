using System;
using System.Runtime.CompilerServices;

namespace DSMCaps.M68K
{
	public sealed class M68KOperand
	{
		private readonly M68KBranchDisplacementOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020;

		private readonly double _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A;

		private readonly long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;

		private readonly M68KMemoryOperandValue _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;

		private readonly M68KRegister _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;

		private readonly int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020;

		private readonly Tuple<M68KRegister, M68KRegister> _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A;

		private readonly float _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		private readonly M68KAddressMode _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		private readonly M68KOperandType _0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020;

		public M68KAddressMode AddressMode
		{
			get;
		}

		public M68KBranchDisplacementOperandValue BranchDisplacement
		{
			get
			{
				if (Type != M68KOperandType.BranchDisplacement)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "BranchDisplacement", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020;
			}
		}

		public double DImmediate
		{
			get
			{
				if (Type != M68KOperandType.DImmediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "DImmediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A;
			}
		}

		public long Immediate
		{
			get
			{
				if (Type != M68KOperandType.Immediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Immediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020;
			}
		}

		public M68KMemoryOperandValue Memory
		{
			get
			{
				if (Type != M68KOperandType.Memory)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Memory", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A;
			}
		}

		public M68KRegister Register
		{
			get
			{
				if (Type != M68KOperandType.Register)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "Register", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020;
			}
		}

		public int RegisterBits
		{
			get
			{
				if (Type != M68KOperandType.RegisterBits)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "RegisterBits", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020;
			}
		}

		public Tuple<M68KRegister, M68KRegister> RegisterPair
		{
			get
			{
				if (Type != M68KOperandType.RegisterPair)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "RegisterPair", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A;
			}
		}

		public float SImmediate
		{
			get
			{
				if (Type != M68KOperandType.SImmediate)
				{
					throw new InvalidOperationException(string.Format("A value ({0}) is invalid when the type is ({1}).", "SImmediate", Type));
				}
				return _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020;
			}
		}

		public M68KOperandType Type
		{
			get;
		}

		internal static M68KOperand[] Create(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020 nativeInstructionDetail)
		{
			M68KOperand[] array = new M68KOperand[nativeInstructionDetail.OperandCount];
			for (int i = 0; i < array.Length; i++)
			{
				ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020 nativeOperand = ref nativeInstructionDetail.Operands[i];
				array[i] = new M68KOperand(disassembler, ref nativeOperand);
			}
			return array;
		}

		internal M68KOperand(CapstoneDisassembler disassembler, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020 nativeOperand)
		{
			_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A = nativeOperand.AddressMode;
			_0020_000A_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020 = nativeOperand.Type;
			switch (Type)
			{
			case M68KOperandType.BranchDisplacement:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020 = new M68KBranchDisplacementOperandValue(ref nativeOperand.BranchDisplacement);
				break;
			case M68KOperandType.DImmediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_000A = nativeOperand.Value.DImmediate;
				break;
			case M68KOperandType.Immediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020 = nativeOperand.Value.Immediate;
				break;
			case M68KOperandType.Memory:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A = new M68KMemoryOperandValue(disassembler, ref nativeOperand.Memory);
				break;
			case M68KOperandType.Register:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020_0020 = M68KRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.Register);
				break;
			case M68KOperandType.RegisterBits:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A_0020 = nativeOperand.RegisterBits;
				break;
			case M68KOperandType.RegisterPair:
			{
				M68KRegister item = M68KRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.RegisterPair.Register0);
				M68KRegister item2 = M68KRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeOperand.Value.RegisterPair.Register1);
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A = Tuple.Create(item, item2);
				break;
			}
			case M68KOperandType.SImmediate:
				_0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020_0020 = nativeOperand.Value.SImmediate;
				break;
			}
		}
	}
}
