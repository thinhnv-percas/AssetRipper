using APK;
using @as;
using DSMCaps.Arm64;
using LZ4ps;
using SpirV;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Wasm;
using WFTools3D;

namespace DSMCaps.M68K
{
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_0020 : InstructionBuilder<M68KInstructionDetail, M68KDisassembleMode, M68KInstructionGroup, M68KInstructionGroupId, M68KInstruction, M68KInstructionId, M68KRegister, M68KRegisterId>
	{
		internal M68KInstruction Create()
		{
			return new M68KInstruction(this);
		}

		internal protected override M68KInstructionDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return M68KInstructionDetail.Create(disassembler, hInstruction);
		}

		internal protected override M68KDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (M68KDisassembleMode)nativeDisassembleMode;
		}

		internal protected override M68KInstructionId CreateId(int id)
		{
			return (M68KInstructionId)id;
		}
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_000A_000A : InstructionDetailBuilder<M68KInstructionDetail, M68KDisassembleMode, M68KInstructionGroup, M68KInstructionGroupId, M68KInstruction, M68KInstructionId, M68KRegister, M68KRegisterId>
	{
		[CompilerGenerated]
		internal M68KOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal M68KOperationSize _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020;

		internal M68KOperand[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal M68KOperationSize _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal override void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			base.Build(disassembler, hInstruction);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020 nativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020>(hInstruction).GetValueOrDefault();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = M68KOperand.Create(disassembler, ref nativeInstructionDetail);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_0020 = new M68KOperationSize(ref nativeInstructionDetail.OperationSize);
		}

		internal M68KInstructionDetail Create()
		{
			return new M68KInstructionDetail(this);
		}

		internal protected override M68KDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (M68KDisassembleMode)nativeDisassembleMode;
		}

		internal protected override M68KInstructionGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId)
		{
			return M68KInstructionGroup.Create(disassembler, (M68KInstructionGroupId)instructionGroupId);
		}

		internal protected override M68KRegister CreateRegister(CapstoneDisassembler disassembler, short registerId)
		{
			return M68KRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (M68KRegisterId)registerId);
		}
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A
	{
		public int Displacement;

		[MarshalAs(UnmanagedType.I1)]
		public M68KBranchDisplacementSize DisplacementSize;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020[] Operands;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020 OperationSize;

		public byte OperandCount;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A
	{
		public M68KRegisterId Base;

		public M68KRegisterId Index;

		public M68KRegisterId IndirectBase;

		public int IndirectDisplacement;

		public int OutDisplacement;

		public short Displacement;

		public byte Scale;

		public byte BitField;

		public byte Width;

		public byte Offset;

		public byte IndexSize;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_0020
	{
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A Value;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_000A Memory;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A BranchDisplacement;

		public int RegisterBits;

		public M68KOperandType Type;

		public M68KAddressMode AddressMode;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A
	{
		[FieldOffset(0)]
		public long Immediate;

		[FieldOffset(0)]
		public double DImmediate;

		[FieldOffset(0)]
		public float SImmediate;

		[FieldOffset(0)]
		public M68KRegisterId Register;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020 RegisterPair;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020
	{
		public M68KOperationSizeType Type;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A Value;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A
	{
		[FieldOffset(0)]
		public M68KCpuOperationSize CpuOperationSize;

		[FieldOffset(0)]
		public M68KFpuOperationSize FpuOperationSize;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_0020
	{
		public M68KRegisterId Register0;

		public M68KRegisterId Register1;
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_0020(GroupOperation _0020, object _0020_000A)
		{
			return 1196293062;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_0020()
		{
			((_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020)null)._0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_000A((byte[])null);
			((_0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020)null)._0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_0020();
			return 208057933;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_0020(_0020_000A_0020_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020 _0020, _0020_000A_0020_0020_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A _0020_000A, NameSection _0020_0020, decimal _0020_000A_000A)
		{
			((_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A)null)._0020_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A();
			((_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A)null)._0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020();
			return "595365701";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020(float _0020, int _0020_000A, _0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 _0020_0020)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020(float _0020)
		{
			string formatString = ((NumberBox)null).FormatString;
			Arm64IcOperation icOperation = ((Arm64Operand)null).IcOperation;
			return "1253291595";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_0020()
		{
		}
	}
}
