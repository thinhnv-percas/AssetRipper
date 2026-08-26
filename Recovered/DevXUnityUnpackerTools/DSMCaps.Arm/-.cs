using @as;
using DevXUnityUnpackerTools._WinForm;
using DevXUnityUnpackerTools.Properties;
using DMP4;
using DSMCaps.Arm64;
using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Unity.IO.Compression;
using Unreal;
using Wasm;
using Wasm.Binary;
using XmlBin;

namespace DSMCaps.Arm
{
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A_000A : InstructionBuilder<ArmInstructionDetail, ArmDisassembleMode, ArmInstructionGroup, ArmInstructionGroupId, ArmInstruction, ArmInstructionId, ArmRegister, ArmRegisterId>
	{
		internal ArmInstruction Create()
		{
			return new ArmInstruction(this);
		}

		internal protected override ArmInstructionDetail CreateDetails(CapstoneDisassembler disassembler, _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_000A_0020_000A_000A hInstruction)
		{
			return ArmInstructionDetail.Create(disassembler, hInstruction);
		}

		internal protected override ArmDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (ArmDisassembleMode)nativeDisassembleMode;
		}

		internal protected override ArmInstructionId CreateId(int id)
		{
			return (ArmInstructionId)id;
		}
	}
	internal sealed class _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_0020_000A_000A_0020_0020 : InstructionDetailBuilder<ArmInstructionDetail, ArmDisassembleMode, ArmInstructionGroup, ArmInstructionGroupId, ArmInstruction, ArmInstructionId, ArmRegister, ArmRegisterId>
	{
		[CompilerGenerated]
		internal ArmConditionCode _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A_0020;

		[CompilerGenerated]
		internal ArmCpsFlag _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_000A_0020_0020_0020;

		[CompilerGenerated]
		internal ArmCpsMode _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_000A_0020;

		[CompilerGenerated]
		internal ArmMemoryBarrierOperation _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_000A;

		[CompilerGenerated]
		internal ArmOperand[] _0020_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_000A_0020_000A_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_000A;

		[CompilerGenerated]
		internal ArmVectorDataType _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_000A_0020_0020;

		[CompilerGenerated]
		internal int _0020_000A_0020_000A_000A_0020_0020_000A_000A_0020_000A_0020_0020_000A_000A;

		[CompilerGenerated]
		internal bool _0020_000A_0020_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_0020_0020;

		internal ArmConditionCode _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A
		{
			get;
			set;
		}

		internal ArmCpsFlag _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020
		{
			get;
			set;
		}

		internal ArmCpsMode _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A
		{
			get;
			set;
		}

		internal bool _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020
		{
			get;
			set;
		}

		internal ArmMemoryBarrierOperation _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A
		{
			get;
			set;
		}

		internal ArmOperand[] _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020
		{
			get;
			set;
		}

		internal bool _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A
		{
			get;
			set;
		}

		internal ArmVectorDataType _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020
		{
			get;
			set;
		}

		internal int _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A
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
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A nativeInstructionDetail = _0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A<_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A>(hInstruction).GetValueOrDefault();
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_000A = nativeInstructionDetail.ConditionCode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_000A_0020 = nativeInstructionDetail.CpsFlag;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_000A = nativeInstructionDetail.CpsMode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_000A_0020_0020 = nativeInstructionDetail.IsUserMode;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_000A = nativeInstructionDetail.MemoryBarrierOperation;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020 = ArmOperand.Create(disassembler, ref nativeInstructionDetail);
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A = nativeInstructionDetail.UpdateFlags;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_000A_0020 = nativeInstructionDetail.VectorDataType;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_0020_000A_000A_0020_0020_000A = nativeInstructionDetail.VectorSize;
			_0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020 = nativeInstructionDetail.WriteBack;
		}

		internal ArmInstructionDetail Create()
		{
			return new ArmInstructionDetail(this);
		}

		internal protected override ArmDisassembleMode CreateDisassembleMode(NativeDisassembleMode nativeDisassembleMode)
		{
			return (ArmDisassembleMode)nativeDisassembleMode;
		}

		internal protected override ArmInstructionGroup CreateInstructionGroup(CapstoneDisassembler disassembler, byte instructionGroupId)
		{
			return ArmInstructionGroup.Create(disassembler, (ArmInstructionGroupId)instructionGroupId);
		}

		internal protected override ArmRegister CreateRegister(CapstoneDisassembler disassembler, short registerId)
		{
			return ArmRegister._0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_000A_0020_000A_0020_000A(disassembler, (ArmRegisterId)registerId);
		}
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_0020_000A
	{
		[MarshalAs(UnmanagedType.I1)]
		public bool IsUserMode;

		public int VectorSize;

		public ArmVectorDataType VectorDataType;

		public ArmCpsMode CpsMode;

		public ArmCpsFlag CpsFlag;

		public ArmConditionCode ConditionCode;

		[MarshalAs(UnmanagedType.I1)]
		public bool UpdateFlags;

		[MarshalAs(UnmanagedType.I1)]
		public bool WriteBack;

		public ArmMemoryBarrierOperation MemoryBarrierOperation;

		public byte OperandCount;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 36)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A[] Operands;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020
	{
		public ArmRegisterId Base;

		public ArmRegisterId Index;

		public int Scale;

		public int Displacement;

		public int LeftShift;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A
	{
		public int VectorIndex;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020 Shift;

		public ArmOperandType Type;

		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A Value;

		[MarshalAs(UnmanagedType.I1)]
		public bool IsSubtracted;

		[MarshalAs(UnmanagedType.I1)]
		public OperandAccessType AccessType;

		public sbyte NeonLane;
	}
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020
	{
		public ArmShiftOperation Operation;

		public int Value;
	}
	[StructLayout(LayoutKind.Explicit)]
	internal struct _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_000A_0020_000A
	{
		[FieldOffset(0)]
		public int Register;

		[FieldOffset(0)]
		public int Immediate;

		[FieldOffset(0)]
		public double FloatingPoint;

		[FieldOffset(0)]
		public _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_0020 Memory;

		[FieldOffset(0)]
		public ArmSetEndOperation SetEndOperation;
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_0020_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_0020(bool _0020)
		{
			return "973683935";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A
	{
		internal unsafe object _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_0020(VersionHeader _0020)
		{
			string text = ((_0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_0020_0020_000A_0020)null)._0020_000A_0020_0020_0020_000A_0020_000A_0020_0020_000A_000A_000A_000A_0020_0020;
			int nameIndex = ((_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020*)(byte*)null)->NameIndex;
			((BinaryWasmReader)null).ReadFile();
			_0020_000A_0020_0020_0020_000A_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020 I_0 = ((_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020)null)._0020_000A_0020_0020_0020_000A_0020_000A_0020_000A_000A_0020_0020_000A_000A_000A;
			byte[] assetRawSubContent = ((_0020_0020_000A_000A_000A_000A_000A_0020_0020_000A_0020_0020_0020_000A_0020_0020)null).AssetRawSubContent;
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_0020_000A
	{
		internal object _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_0020(ArmOperand _0020, CapstoneDisassembler _0020_000A, ref _0020_0020_000A_000A_0020_000A_000A_000A_000A_000A_000A_0020_0020_0020_000A_000A _0020_0020)
		{
			Bitmap imageUpload = Resources.ImageUpload16;
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_000A_0020_000A_000A_000A_0020_000A_000A((object)null, (EventArgs)null);
			return null;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_0020_000A_000A_000A
	{
		internal string _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_0020(int _0020)
		{
			int num = ((_0020_0020_000A_000A_000A_000A_0020_000A_0020_000A_0020_0020_0020_000A_000A_0020)null)._0020_000A_0020_0020_0020_0020_000A_0020_0020_0020_0020_000A_000A_000A_000A_000A;
			((_0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_0020_000A_0020_000A_000A_0020)null)._0020_000A_0020_0020_0020_000A_000A_0020_000A_000A_000A_0020_0020_0020_0020_0020();
			((_0020_0020_000A_000A_0020_000A_000A_0020_000A_000A_000A_0020_0020_000A_0020_0020)null).GetRGCTXDefinition((string)null, (Il2CppTypeDefinition)null);
			return "1420896070";
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_0020_000A
	{
		internal int _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_0020(int _0020, float _0020_000A, _0020_0020_000A_0020_000A_0020_000A_000A_000A_000A_0020_0020_0020_000A_000A_000A _0020_0020, short _0020_000A_000A)
		{
			((APKSignDialog)null).ShowAsDialog((IWin32Window)null);
			_0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_0020_0020_000A_000A_0020._0020_0020_000A_000A_0020_000A_000A_000A_0020_000A_0020_000A_0020_0020_000A_000A(null, null);
			return 1552728742;
		}
	}
	internal class _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_0020_000A_000A
	{
		internal unsafe string _0020_000A_0020_0020_000A_000A_000A_0020_0020_000A_000A_000A_000A_000A_0020_0020(_0020_0020_000A_000A_000A_000A_0020_0020_0020_0020_000A_000A_000A_0020_000A_000A _0020, bool _0020_000A)
		{
			int nameIndex = ((_0020_000A_0020_0020_0020_0020_000A_0020_0020_000A_0020_0020_000A_0020_000A_0020*)(byte*)null)->NameIndex;
			((MainForm)null)._0020_0020_000A_0020_000A_000A_0020_0020_0020_000A_0020_0020_000A_000A_000A_0020((object)null, (EventArgs)null);
			Arm64DcOperation dcOperation = ((Arm64Operand)null).DcOperation;
			return "991933619";
		}
	}
}
