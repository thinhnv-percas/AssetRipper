using @as;
using DevXForms;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression;
using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Unreal;
using Wasm;
using Wasm.Interpret;
using XmlBin;

namespace DSMCaps.XCore
{
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020
	{
		public byte OperandCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020[] Operands;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A
	{
		public byte Base;

		public byte Index;

		public int Displacement;

		public int Direct;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_0020
	{
		public XCoreOperandType Type;

		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A Value;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_000A_000A
	{
		[FieldOffset(0)]
		public XCoreRegisterId Register;

		[FieldOffset(0)]
		public int Immediate;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_000A Memory;
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_0020 : InstructionBuilder<XCoreInstructionDetail, XCoreDisassembleMode, XCoreInstructionGroup, XCoreInstructionGroupId, XCoreInstruction, XCoreInstructionId, XCoreRegister, XCoreRegisterId>
	{
		internal XCoreInstruction Create()
		{
			return new XCoreInstruction(this);
		}

		private protected override XCoreInstructionDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return XCoreInstructionDetail.Create(disassembler, hInstruction);
		}

		private protected override XCoreDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (XCoreDisassembleMode)nativeDisassembleMode;
		}

		private protected override XCoreInstructionId CreateId(int id)
		{
			return (XCoreInstructionId)id;
		}
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_000A_0020_000A : InstructionDetailBuilder<XCoreInstructionDetail, XCoreDisassembleMode, XCoreInstructionGroup, XCoreInstructionGroupId, XCoreInstruction, XCoreInstructionId, XCoreRegister, XCoreRegisterId>
	{
		[CompilerGenerated]
		private XCoreOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		internal XCoreOperand[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020
		{
			get;
			private set;
		}

		internal override void Build(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			base.Build(disassembler, hInstruction);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020 nativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_000A_0020_0020_0020_0020_0020>(hInstruction).GetValueOrDefault();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = XCoreOperand.Create(disassembler, ref nativeInstructionDetail);
		}

		internal XCoreInstructionDetail Create()
		{
			return new XCoreInstructionDetail(this);
		}

		private protected override XCoreDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (XCoreDisassembleMode)nativeDisassembleMode;
		}

		private protected override XCoreInstructionGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId)
		{
			return XCoreInstructionGroup.Create(disassembler, (XCoreInstructionGroupId)instructionGroupId);
		}

		private protected override XCoreRegister CreateRegister(CapstoneDisassembler disassembler, short registerId)
		{
			return XCoreRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (XCoreRegisterId)registerId);
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_0020_000A
	{
		private object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_0020()
		{
			OperatorImpls.Int32Const(null, null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_0020_000A_000A_000A_000A
	{
		private int _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A _0020)
		{
			((TableSection)null).Tables = null;
			((MultiSelectTreeView2)null).OnPaintOwn((PaintEventArgs)null);
			_0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020_0020.Start((_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020)null);
			((_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_000A_0020_000A_000A)null)._0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020_000A_000A_000A((string)null, (object)null);
			return 2098723879;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_0020_000A
	{
		private object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_0020(string _0020, string _0020_000A)
		{
			((MultiSelectTreeView2)null)._0020_0020_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020_0020_000A_0020 -= null;
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_0020_0020_0020_0020_0020_000A((string)null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A
	{
		private object _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_0020()
		{
			bool isNeedingInput = ((_0020_0020_000A_000A_000A_0020_0020_0020_000A_000A_0020_0020_0020_000A_000A_000A)null).IsNeedingInput;
			GlobalType type = ((GlobalVariable)null).Type;
			((_0020_0020_000A_000A_000A_0020_0020_000A_0020_000A_0020_0020_0020_0020_000A_0020)null).Close();
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_0020_000A
	{
		private string _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_0020(string _0020, Stream _0020_000A)
		{
			UseZip64 useZip = ((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A_000A)null).UseZip64;
			return "2139865921";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A_000A
	{
		private void _0020_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A_000A_000A_0020_0020_0020(short _0020, decimal _0020_000A, object _0020_0020, float _0020_000A_000A)
		{
			((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_0020_0020)null)._0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A((_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A_0020_000A_000A_0020_0020_000A)null, (string)null);
			((ConnectSettingsForm)null)._0020_000A_0020_0020_0020_0020_0020_0020_0020_000A_000A_0020_000A_000A_0020_0020();
			((ConnectSettingsForm)null)._0020_0020_000A_0020_000A_000A_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A((object)null, (EventArgs)null);
			string text = ((_0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_0020_0020_000A_0020_000A_000A)null)._0020_000A_0020_0020_0020_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020;
		}
	}
}
