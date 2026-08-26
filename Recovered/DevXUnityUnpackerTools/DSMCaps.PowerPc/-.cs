using APK;
using @as;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using JpegEncoder;
using ProtoBuf;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Wasm.Interpret;
using WFTools3D;

namespace DSMCaps.PowerPc
{
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020
	{
		public int Scale;

		public PowerPcRegisterId Register;

		public PowerPcBranchCode BranchCode;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A
	{
		public PowerPcBranchCode BranchCode;

		public PowerPcBranchHint BranchHint;

		[MarshalAs(UnmanagedType.I1)]
		public bool UpdateCr0;

		public byte OperandCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A[] Operands;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020
	{
		public PowerPcRegisterId Base;

		public int Displacement;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A
	{
		public PowerPcOperandType Type;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020 Value;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020
	{
		[FieldOffset(0)]
		public PowerPcRegisterId Register;

		[FieldOffset(0)]
		public long Immediate;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_000A_0020 Memory;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020 ConditionRegister;
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A : InstructionBuilder<PowerPcInstructionDetail, PowerPcDisassembleMode, PowerPcInstructionGroup, PowerPcInstructionGroupId, PowerPcInstruction, PowerPcInstructionId, PowerPcRegister, PowerPcRegisterId>
	{
		internal PowerPcInstruction Create()
		{
			return new PowerPcInstruction(this);
		}

		internal protected override PowerPcInstructionDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return PowerPcInstructionDetail.Create(disassembler, hInstruction);
		}

		internal protected override PowerPcDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (PowerPcDisassembleMode)nativeDisassembleMode;
		}

		internal protected override PowerPcInstructionId CreateId(int id)
		{
			return (PowerPcInstructionId)id;
		}
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020 : InstructionDetailBuilder<PowerPcInstructionDetail, PowerPcDisassembleMode, PowerPcInstructionGroup, PowerPcInstructionGroupId, PowerPcInstruction, PowerPcInstructionId, PowerPcRegister, PowerPcRegisterId>
	{
		[CompilerGenerated]
		internal PowerPcBranchCode _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal PowerPcBranchHint _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_0020_0020_0020_0020_0020;

		[CompilerGenerated]
		internal PowerPcOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A;

		internal PowerPcBranchCode _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A
		{
			get;
			set;
		}

		internal PowerPcBranchHint _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020
		{
			get;
			set;
		}

		internal PowerPcOperand[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal bool _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A
		{
			get;
			set;
		}

		internal override void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			base.Build(disassembler, hInstruction);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A nativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A>(hInstruction).GetValueOrDefault();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_000A = nativeInstructionDetail.BranchCode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A_0020 = nativeInstructionDetail.BranchHint;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = PowerPcOperand.Create(disassembler, ref nativeInstructionDetail);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020_000A = nativeInstructionDetail.UpdateCr0;
		}

		internal PowerPcInstructionDetail Create()
		{
			return new PowerPcInstructionDetail(this);
		}

		internal protected override PowerPcDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (PowerPcDisassembleMode)nativeDisassembleMode;
		}

		internal protected override PowerPcInstructionGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId)
		{
			return PowerPcInstructionGroup.Create(disassembler, (PowerPcInstructionGroupId)instructionGroupId);
		}

		internal protected override PowerPcRegister CreateRegister(CapstoneDisassembler disassembler, short registerId)
		{
			return PowerPcRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (PowerPcRegisterId)registerId);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_0020(byte[] _0020)
		{
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A((object)null, (LabelEditEventArgs)null);
			long count = ((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A)null).Count;
			return "531504929";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_000A_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_0020(_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020 _0020)
		{
			return 851230008;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_0020()
		{
			ManyCodeCls manyCodeCl = ((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_000A;
			_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A._0020_000A_0020_0020_0020_000A_000A_0020_0020_000A_0020_000A_000A_0020_000A_000A(null);
			((_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020)null)._0020_0020_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020 -= null;
			return 941871988;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_0020_000A_000A
	{
		internal unsafe string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_0020(bool _0020, float _0020_000A, Object3D _0020_0020, object _0020_000A_000A)
		{
			((_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020)null)._0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_000A();
			_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A._0020_0020_000A_000A_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020();
			_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A._0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_0020_000A_000A_000A(ref *(_0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_000A._0020_0020_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_000A_000A_000A*)null);
			return "2017415649";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_0020_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020()
		{
			((_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020)null)._0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_000A_0020_000A((_0020_000A_0020_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020)null);
			ProtoReader._0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A((ProtoReader)null);
			OperatorImpls.Int32LeU(null, null);
			DateTime createTime = ((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020)null).CreateTime;
			((_0020_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020)null)._0020_0020_000A_000A_000A_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020();
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_000A_000A_000A_000A
	{
		internal void _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_0020_0020(string _0020)
		{
		}
	}
}
