using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core
{
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000050")]
	internal struct SafeModeReport
	{
		[Token(Token = "0x20000BA")]
		internal enum SafeModeReportType
		{
			[Token(Token = "0x4000253")]
			Unset = 0,
			[Token(Token = "0x4000254")]
			TargetOrFieldMissing = 1,
			[Token(Token = "0x4000255")]
			Callback = 2,
			[Token(Token = "0x4000256")]
			StartupFailure = 3
		}

		[Token(Token = "0x17000008")]
		public int totMissingTargetOrFieldErrors
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A0")]
			[Address(RVA = "0x856710", Offset = "0x856710", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (DG.Tweening.Core.SafeModeReport)+10]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+10]");
				return 0;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A1")]
			[Address(RVA = "0x856718", Offset = "0x856718", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Core.SafeModeReport)+10]) = value;\n\treturn;\n")]
			private set
			{
			}
		}

		[Token(Token = "0x17000009")]
		public int totCallbackErrors
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A2")]
			[Address(RVA = "0x856720", Offset = "0x856720", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (DG.Tweening.Core.SafeModeReport)+14]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+14]");
				return 0;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A3")]
			[Address(RVA = "0x856728", Offset = "0x856728", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Core.SafeModeReport)+14]) = value;\n\treturn;\n")]
			private set
			{
			}
		}

		[Token(Token = "0x1700000A")]
		public int totStartupErrors
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A4")]
			[Address(RVA = "0x856730", Offset = "0x856730", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (DG.Tweening.Core.SafeModeReport)+18]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+18]");
				return 0;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A5")]
			[Address(RVA = "0x856738", Offset = "0x856738", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Core.SafeModeReport)+18]) = value;\n\treturn;\n")]
			private set
			{
			}
		}

		[Token(Token = "0x1700000B")]
		public int totUnsetErrors
		{
			[CompilerGenerated]
			[Token(Token = "0x60002A6")]
			[Address(RVA = "0x856740", Offset = "0x856740", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (DG.Tweening.Core.SafeModeReport)+1C]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+1C]");
				return 0;
			}
			[CompilerGenerated]
			[Token(Token = "0x60002A7")]
			[Address(RVA = "0x856748", Offset = "0x856748", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Core.SafeModeReport)+1C]) = value;\n\treturn;\n")]
			private set
			{
			}
		}

		[Token(Token = "0x60002A8")]
		[Address(RVA = "0x856750", Offset = "0x856750", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = type == 3;\n\tif (v5) goto L_0021;\n\tv14 = type == 2;\n\tv32 = this + 0x10;\n\tif (v14) goto L_0023;\n\tv26 = type == 1;\n\tif (v26) goto L_0025;\n\tv32 = v32 + 0xC;\n\tgoto L_0025;\nL_0021:\n\tv32 = this + 0x18;\n\tgoto L_0025;\nL_0023:\n\tv32 = v32 + 4;\nL_0025:\n\tv43 = *([v32 @ X8_v1]) + 1;\n\t*([v32 @ X8_v1]) = v43;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Add(SafeModeReportType type)
		{
			//IL_0081: Expected O, but got Ref
			//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
			//IL_00a8: Expected O, but got Unknown
			//IL_0037: Expected O, but got Ref
			//IL_0095: Expected O, but got I
			//IL_0071: Expected O, but got I
			object obj;
			if (type != SafeModeReportType.StartupFailure)
			{
				bool flag = type == SafeModeReportType.Callback;
				obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
				if (!flag)
				{
					if (type != SafeModeReportType.TargetOrFieldMissing)
					{
						obj = (long)(IntPtr)obj + 12L;
					}
				}
				else
				{
					obj = (long)(IntPtr)obj + 4L;
				}
			}
			else
			{
				obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 24));
			}
			object obj2 = obj + 1;
			obj = obj2;
		}

		[Token(Token = "0x60002A9")]
		[Address(RVA = "0x856790", Offset = "0x856790", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = *([this @ X0 (DG.Tweening.Core.SafeModeReport)+14]) + *([this @ X0 (DG.Tweening.Core.SafeModeReport)+10]);\n\tv6 = v5 + *([this @ X0 (DG.Tweening.Core.SafeModeReport)+18]);\n\treturnVal1 = v6 + *([this @ X0 (DG.Tweening.Core.SafeModeReport)+1C]);\n\treturn returnVal1;\n\tX8 = *([X0+28]);\n\tX0 = *([X8]);\n\t// 10 IndirectJump X0, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\treturn X0;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetTotErrors()
		{
			//IL_001d: Expected O, but got I
			//IL_0033: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+14]");
			IntPtr intPtr = (IntPtr)0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+10]");
			object obj = (long)intPtr + 0L;
			IntPtr intPtr2 = (IntPtr)obj;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+18]");
			object obj2 = (long)intPtr2 + 0L;
			IntPtr intPtr3 = (IntPtr)obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (DG.Tweening.Core.SafeModeReport)+1C]");
			return (int)((long)intPtr3 + 0L);
		}
	}
}
