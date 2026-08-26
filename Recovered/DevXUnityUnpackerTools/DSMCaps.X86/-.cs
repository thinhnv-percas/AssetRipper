using @as;
using ICSharpCode.SharpZipLib.Core;
using Org.Brotli.Dec;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Unity.SerializationLogic;
using WFTools3D;
using XmlBin;

namespace DSMCaps.X86
{
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020
	{
		public byte ModRmOffset;

		public byte DisplacementOffset;

		public byte DisplacementSize;

		public byte ImmediateOffset;

		public byte ImmediateSize;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A
	{
		[FieldOffset(0)]
		public long EFlags;

		[FieldOffset(0)]
		public long FpuFlags;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020
	{
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
		public X86Prefix[] Prefix;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
		public byte[] Opcode;

		public byte Rex;

		public byte AddressSize;

		public byte ModRm;

		public byte Sib;

		public long Displacement;

		public X86RegisterId SibIndex;

		public byte SibScale;

		public X86RegisterId SibBase;

		public X86XopConditionCode XopConditionCode;

		public X86SseConditionCode SseConditionCode;

		public X86AvxConditionCode AvxConditionCode;

		[MarshalAs(UnmanagedType.I1)]
		public bool AvxSuppressAllExceptions;

		public X86AvxRoundingMode AvxRoundingMode;

		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A Flag;

		public byte OperandCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020[] Operands;

		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A_0020 Encoding;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A
	{
		public X86RegisterId Segment;

		public X86RegisterId Base;

		public X86RegisterId Index;

		public int Scale;

		public long Displacement;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020
	{
		public X86OperandType Type;

		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A Value;

		public byte Size;

		[MarshalAs(UnmanagedType.I1)]
		public OperandAccessType AccessType;

		public X86AvxBroadcast AvxBroadcast;

		[MarshalAs(UnmanagedType.I1)]
		public bool AvxZeroOpMask;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A_000A
	{
		[FieldOffset(0)]
		public X86RegisterId Register;

		[FieldOffset(0)]
		public long Immediate;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_000A Memory;
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020 : InstructionBuilder<X86InstructionDetail, X86DisassembleMode, X86InstructionGroup, X86InstructionGroupId, X86Instruction, X86InstructionId, X86Register, X86RegisterId>
	{
		internal X86Instruction Create()
		{
			return new X86Instruction(this);
		}

		internal protected override X86InstructionDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return X86InstructionDetail.Create(disassembler, hInstruction);
		}

		internal protected override X86DisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (X86DisassembleMode)nativeDisassembleMode;
		}

		internal protected override X86InstructionId CreateId(int id)
		{
			return (X86InstructionId)id;
		}
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A : InstructionDetailBuilder<X86InstructionDetail, X86DisassembleMode, X86InstructionGroup, X86InstructionGroupId, X86Instruction, X86InstructionId, X86Register, X86RegisterId>
	{
		[CompilerGenerated]
		internal byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020;

		[CompilerGenerated]
		internal X86AvxConditionCode _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_000A;

		[CompilerGenerated]
		internal X86AvxRoundingMode _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_0020_0020;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A;

		[CompilerGenerated]
		internal long _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A;

		[CompilerGenerated]
		internal long _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A_0020;

		[CompilerGenerated]
		internal X86Encoding _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_000A;

		[CompilerGenerated]
		internal long _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_0020_0020;

		[CompilerGenerated]
		internal byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_000A;

		[CompilerGenerated]
		internal byte[] _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020;

		[CompilerGenerated]
		internal X86Operand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal X86Prefix[] _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_000A;

		[CompilerGenerated]
		internal byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_0020_0020;

		[CompilerGenerated]
		internal byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_000A;

		[CompilerGenerated]
		internal X86Register _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_000A_0020;

		[CompilerGenerated]
		internal X86Register _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A;

		[CompilerGenerated]
		internal byte _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020;

		[CompilerGenerated]
		internal X86SseConditionCode _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal X86XopConditionCode _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_0020_000A_0020_000A_0020;

		internal byte _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A
		{
			get;
			set;
		}

		internal X86AvxConditionCode _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020
		{
			get;
			set;
		}

		internal X86AvxRoundingMode _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A
		{
			get;
			set;
		}

		internal bool _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020
		{
			get;
			set;
		}

		internal long _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A
		{
			get;
			set;
		}

		internal long _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal X86Encoding _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A
		{
			get;
			set;
		}

		internal long _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020
		{
			get;
			set;
		}

		internal byte _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A
		{
			get;
			set;
		}

		internal byte[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020
		{
			get;
			set;
		}

		internal X86Operand[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal X86Prefix[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A
		{
			get;
			set;
		}

		internal byte _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020
		{
			get;
			set;
		}

		internal byte _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A
		{
			get;
			set;
		}

		internal X86Register _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020
		{
			get;
			set;
		}

		internal X86Register _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A
		{
			get;
			set;
		}

		internal byte _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020
		{
			get;
			set;
		}

		internal X86SseConditionCode _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A
		{
			get;
			set;
		}

		internal X86XopConditionCode _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020
		{
			get;
			set;
		}

		internal override void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			base.Build(disassembler, hInstruction);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020 nativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020_0020>(hInstruction).GetValueOrDefault();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A = nativeInstructionDetail.AddressSize;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020 = nativeInstructionDetail.AvxConditionCode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A = nativeInstructionDetail.AvxRoundingMode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020 = nativeInstructionDetail.AvxSuppressAllExceptions;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A = nativeInstructionDetail.Displacement;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020 = nativeInstructionDetail.Flag.EFlags;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_000A = new X86Encoding(ref nativeInstructionDetail.Encoding);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020 = nativeInstructionDetail.Flag.FpuFlags;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A = nativeInstructionDetail.ModRm;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020 = nativeInstructionDetail.Opcode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = X86Operand.Create(disassembler, ref nativeInstructionDetail);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A = nativeInstructionDetail.Prefix;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020 = nativeInstructionDetail.Rex;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A = nativeInstructionDetail.Sib;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020 = X86Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeInstructionDetail.SibBase);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A = X86Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, nativeInstructionDetail.SibIndex);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020 = nativeInstructionDetail.SibScale;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A = nativeInstructionDetail.SseConditionCode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020 = nativeInstructionDetail.XopConditionCode;
		}

		internal X86InstructionDetail Create()
		{
			return new X86InstructionDetail(this);
		}

		internal protected override X86DisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (X86DisassembleMode)nativeDisassembleMode;
		}

		internal protected override X86InstructionGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId)
		{
			return X86InstructionGroup.Create(disassembler, (X86InstructionGroupId)instructionGroupId);
		}

		internal protected override X86Register CreateRegister(CapstoneDisassembler disassembler, short registerId)
		{
			return X86Register._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (X86RegisterId)registerId);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_0020(string _0020, object _0020_000A, ref _0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_0020_0020._0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020 _0020_0020)
		{
			_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020(null);
			((_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020)null)._0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 += null;
			((_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A)null)._0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A((string)null);
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A((Action)null);
			return 95262433;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_0020(string _0020, object[] _0020_000A, ref bool _0020_0020, ref object _0020_000A_000A)
		{
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_0020()
		{
			return "1768401434";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_0020(short _0020, object _0020_000A, string _0020_0020, _0020_0020_000A_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A _0020_000A_000A)
		{
			((_0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_000A_000A)null)._0020_000A_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020();
			UnityEngineTypePredicates.IsColor32(null);
			return 229898922;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_0020()
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_0020(bool _0020, string _0020_000A, object _0020_0020, decimal _0020_000A_000A)
		{
			WFUtils.GetAllScreens();
			return "685311793";
		}
	}
}
