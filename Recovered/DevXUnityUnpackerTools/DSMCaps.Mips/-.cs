using APK;
using ARMD;
using @as;
using DevXForms;
using DevXUnityUnpackerTools._WinForm;
using DMP4;
using DSMCaps.X86;
using ICSharpCode.SharpZipLib.BZip2;
using SpirV;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Unreal;
using Wasm;

namespace DSMCaps.Mips
{
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020 : InstructionBuilder<MipsInstructionDetail, MipsDisassembleMode, MipsInstructionGroup, MipsInstructionGroupId, MipsInstruction, MipsInstructionId, MipsRegister, MipsRegisterId>
	{
		internal MipsInstruction Create()
		{
			return new MipsInstruction(this);
		}

		internal protected override MipsInstructionDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return MipsInstructionDetail.Create(disassembler, hInstruction);
		}

		internal protected override MipsDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (MipsDisassembleMode)nativeDisassembleMode;
		}

		internal protected override MipsInstructionId CreateId(int id)
		{
			return (MipsInstructionId)id;
		}
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_000A : InstructionDetailBuilder<MipsInstructionDetail, MipsDisassembleMode, MipsInstructionGroup, MipsInstructionGroupId, MipsInstruction, MipsInstructionId, MipsRegister, MipsRegisterId>
	{
		[CompilerGenerated]
		internal MipsOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		internal MipsOperand[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal override void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			base.Build(disassembler, hInstruction);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020 nativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020>(hInstruction).GetValueOrDefault();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = MipsOperand.Create(disassembler, ref nativeInstructionDetail);
		}

		internal MipsInstructionDetail Create()
		{
			return new MipsInstructionDetail(this);
		}

		internal protected override MipsDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (MipsDisassembleMode)nativeDisassembleMode;
		}

		internal protected override MipsInstructionGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId)
		{
			return MipsInstructionGroup.Create(disassembler, (MipsInstructionGroupId)instructionGroupId);
		}

		internal protected override MipsRegister CreateRegister(CapstoneDisassembler disassembler, short registerId)
		{
			return MipsRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (MipsRegisterId)registerId);
		}
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_0020
	{
		public byte OperandCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020[] Operands;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A
	{
		public MipsRegisterId Base;

		public long Displacement;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_0020
	{
		public MipsOperandType Type;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A Value;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020_000A
	{
		[FieldOffset(0)]
		public MipsRegisterId Register;

		[FieldOffset(0)]
		public long Immediate;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A_000A Memory;
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A_0020(_0020_0020_000A_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020 _0020)
		{
			string text = ((ManyCodeCls)null)._0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020;
			long num = ((_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A)null)._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_0020_0020_0020;
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_0020(bool _0020)
		{
			bool flag = ((_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020_000A)null)._0020_0020_000A_000A_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020;
			OutForm._0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_0020_0020_000A();
			((Type)null).GetTypeInfo();
			int num = ((_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A)null)._0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_000A_0020_0020_0020_000A;
			((MultiSelectTreeView2)null).SelectedImageKey = null;
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_0020(_0020_000A_0020_0020_0020_0020_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A _0020)
		{
			_0020_0020_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A_0020_0020_000A_0020._0020_0020_000A_000A_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_0020_0020();
			return 105515811;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020_0020(_0020_000A_0020_0020_0020_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_0020 _0020, string _0020_000A, ResizableLimits _0020_0020)
		{
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_0020()
		{
			return "470816090";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_0020_000A_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020_000A_0020_000A_0020_0020(OpCreatePipeFromPipeStorage _0020, object _0020_000A, bool _0020_0020, string _0020_000A_000A)
		{
			FileManager._0020_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020(null);
			_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_000A_000A_000A_0020_0020((object)null);
			((_0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_0020_000A_000A_0020_0020)null)._0020_0020_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_000A_0020_000A();
			((_0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020)null)._0020_000A_0020_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020((ImageResData)null);
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_000A_000A_0020_0020_000A_0020((object)null, (LabelEditEventArgs)null);
			return null;
		}
	}
}
