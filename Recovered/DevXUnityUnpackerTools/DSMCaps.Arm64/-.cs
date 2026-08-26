using @as;
using DevXForms;
using DSMCaps.Arm;
using FMOD;
using ICSharpCode.SharpZipLib.Checksum;
using ICSharpCode.SharpZipLib.Zip;
using LZ4.Services;
using SpirV;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unreal;
using Wasm.Instructions;
using Wasm.Interpret;

namespace DSMCaps.Arm64
{
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020 : InstructionBuilder<Arm64InstructionDetail, Arm64DisassembleMode, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64Instruction, Arm64InstructionId, Arm64Register, Arm64RegisterId>
	{
		internal Arm64Instruction Create()
		{
			return new Arm64Instruction(this);
		}

		internal protected override Arm64InstructionDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return Arm64InstructionDetail.Create(disassembler, hInstruction);
		}

		internal protected override Arm64DisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (Arm64DisassembleMode)nativeDisassembleMode;
		}

		internal protected override Arm64InstructionId CreateId(int id)
		{
			return (Arm64InstructionId)id;
		}
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A : InstructionDetailBuilder<Arm64InstructionDetail, Arm64DisassembleMode, Arm64InstructionGroup, Arm64InstructionGroupId, Arm64Instruction, Arm64InstructionId, Arm64Register, Arm64RegisterId>
	{
		[CompilerGenerated]
		internal Arm64ConditionCode _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal Arm64Operand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020;

		internal Arm64ConditionCode _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A
		{
			get;
			set;
		}

		internal Arm64Operand[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal bool _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A
		{
			get;
			set;
		}

		internal bool _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020
		{
			get;
			set;
		}

		internal override void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			base.Build(disassembler, hInstruction);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020(hInstruction);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020 nativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020>(hInstruction).GetValueOrDefault();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A = nativeInstructionDetail.ConditionCode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = Arm64Operand.Create(disassembler, (Arm64InstructionId)_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A.Id, ref nativeInstructionDetail);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = nativeInstructionDetail.UpdateFlags;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020 = nativeInstructionDetail.WriteBack;
		}

		internal Arm64InstructionDetail Create()
		{
			return new Arm64InstructionDetail(this);
		}

		internal protected override Arm64DisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (Arm64DisassembleMode)nativeDisassembleMode;
		}

		internal protected override Arm64InstructionGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId)
		{
			return Arm64InstructionGroup.Create(disassembler, (Arm64InstructionGroupId)instructionGroupId);
		}

		internal protected override Arm64Register CreateRegister(CapstoneDisassembler disassembler, short registerId)
		{
			return Arm64Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (Arm64RegisterId)registerId);
		}
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_0020
	{
		public Arm64ConditionCode ConditionCode;

		[MarshalAs(UnmanagedType.I1)]
		public bool UpdateFlags;

		[MarshalAs(UnmanagedType.I1)]
		public bool WriteBack;

		public byte OperandCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020[] Operands;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A
	{
		public Arm64RegisterId Base;

		public Arm64RegisterId Index;

		public int Displacement;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020
	{
		public int VectorIndex;

		public Arm64VectorArrangementSpecifier VectorArrangementSpecifier;

		public Arm64VectorElementSizeSpecifier VectorElementSizeSpecifier;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A Shift;

		public Arm64ExtendOperation ExtendOperation;

		public Arm64OperandType Type;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020 Value;

		public OperandAccessType AccessType;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A
	{
		public Arm64ShiftOperation Operation;

		public int Value;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020
	{
		[FieldOffset(0)]
		public Arm64RegisterId Register;

		[FieldOffset(0)]
		public long Immediate;

		[FieldOffset(0)]
		public double FloatingPoint;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_000A_000A Memory;

		[FieldOffset(0)]
		public Arm64PStateField PStateField;

		[FieldOffset(0)]
		public int SystemOperation;

		[FieldOffset(0)]
		public Arm64PrefetchOperation PrefetchOperation;

		[FieldOffset(0)]
		public Arm64BarrierOperation BarrierOperation;
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_0020()
		{
			((_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A)null)._0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020((byte[])null);
			((MainForm)null)._0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020((RapackInfo)null);
			return 1282762619;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020(string _0020, string _0020_000A, string _0020_0020)
		{
			_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020.Create(null);
			((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020_000A_0020_0020_000A((string)null, (string)null);
			((_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020)null).Create();
			_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A I_0 = ((_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020)null)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020;
			return "1557672893";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020(string _0020, string _0020_000A)
		{
			((RapackInfo)null)._0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020_000A();
			return 1698441269;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020()
		{
			((TreeNode)null).SetData((object[])null);
			((_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A)null)._0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020 += null;
			((_0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A)null)._0020_0020_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020((Stream)null);
			((_0020_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020)null)._0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020 = null;
			((_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A)null)._0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020((string)null);
			string text = _0020_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020_0020_000A;
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_0020(Wasm.Instructions.Instruction _0020, InterpreterContext _0020_000A)
		{
			long num = ((ShaderInfo)null)._0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A_000A;
			PRESET.SEWERPIPE();
			bool flag = ((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020;
			((PredefinedImporter)null).DefineTable((string)null, (FunctionTable)null);
			((_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A)null)._0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A_0020_0020_0020_0020();
			return "875480727";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020(bool _0020, OpGroupSMax _0020_000A, float _0020_0020, short _0020_000A_000A)
		{
			_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_000A_000A_000A(null);
			((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A)null).ForceZip64();
			bool flag = (_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A)null == (_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A)null;
			return null;
		}
	}
}
