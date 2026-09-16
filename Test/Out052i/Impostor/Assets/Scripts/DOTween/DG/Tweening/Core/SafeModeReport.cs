using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000B2")]
	internal struct SafeModeReport
	{
		[Token(Token = "0x20000B3")]
		internal enum SafeModeReportType
		{
			[Token(Token = "0x400021B")]
			Unset = 0,
			[Token(Token = "0x400021C")]
			TargetOrFieldMissing = 1,
			[Token(Token = "0x400021D")]
			Callback = 2,
			[Token(Token = "0x400021E")]
			StartupFailure = 3
		}

		[Token(Token = "0x1700001C")]
		[field: Token(Token = "0x4000216")]
		[field: FieldOffset(Offset = "0x0")]
		public int totMissingTargetOrFieldErrors
		{
			[Token(Token = "0x6000420")]
			[Address(RVA = "0xC2E0E0", Offset = "0xC2E0E0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<totMissingTargetOrFieldErrors>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000421")]
			[Address(RVA = "0xC2E0E8", Offset = "0xC2E0E8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<totMissingTargetOrFieldErrors>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700001D")]
		[field: Token(Token = "0x4000217")]
		[field: FieldOffset(Offset = "0x4")]
		public int totCallbackErrors
		{
			[Token(Token = "0x6000422")]
			[Address(RVA = "0xC2E0F0", Offset = "0xC2E0F0", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<totCallbackErrors>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000423")]
			[Address(RVA = "0xC2E0F8", Offset = "0xC2E0F8", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<totCallbackErrors>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700001E")]
		[field: Token(Token = "0x4000218")]
		[field: FieldOffset(Offset = "0x8")]
		public int totStartupErrors
		{
			[Token(Token = "0x6000424")]
			[Address(RVA = "0xC2E100", Offset = "0xC2E100", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<totStartupErrors>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000425")]
			[Address(RVA = "0xC2E108", Offset = "0xC2E108", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<totStartupErrors>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x1700001F")]
		[field: Token(Token = "0x4000219")]
		[field: FieldOffset(Offset = "0xC")]
		public int totUnsetErrors
		{
			[Token(Token = "0x6000426")]
			[Address(RVA = "0xC2E110", Offset = "0xC2E110", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<totUnsetErrors>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000427")]
			[Address(RVA = "0xC2E118", Offset = "0xC2E118", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<totUnsetErrors>k__BackingField = value;\n\treturn;\n")]
			private set;
		}

		[Token(Token = "0x6000428")]
		[Address(RVA = "0xC2E120", Offset = "0xC2E120", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = type == 3;\n\tif (v5) goto L_0020;\n\tv14 = type == 2;\n\tif (v14) goto L_0022;\n\tv25 = type == 1;\n\tif (v25) goto L_0024;\n\tv31 = v31 + 0xC;\n\tgoto L_0024;\nL_0020:\n\tv31 = v31 + 8;\n\tgoto L_0024;\nL_0022:\n\tv31 = v31 + 4;\nL_0024:\n\tv42 = v31.<totMissingTargetOrFieldErrors>k__BackingField + 1;\n\tv31.<totMissingTargetOrFieldErrors>k__BackingField = v42;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Add(SafeModeReportType type)
		{
			//IL_0072: Expected O, but got Ref
			//IL_0082: Expected O, but got Ref
			//IL_0062: Expected O, but got Ref
			switch (type)
			{
			default:
			{
				SafeModeReport safeModeReport = (SafeModeReport)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 12));
				break;
			}
			case SafeModeReportType.StartupFailure:
			{
				SafeModeReport safeModeReport = (SafeModeReport)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 8));
				break;
			}
			case SafeModeReportType.Callback:
			{
				SafeModeReport safeModeReport = (SafeModeReport)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 4));
				break;
			}
			case SafeModeReportType.TargetOrFieldMissing:
				break;
			}
			int num = totMissingTargetOrFieldErrors + 1;
			totMissingTargetOrFieldErrors = num;
		}

		[Token(Token = "0x6000429")]
		[Address(RVA = "0xC2E15C", Offset = "0xC2E15C", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t// 1 NotImplemented \"Instruction UNIMPLEMENTED not yet implemented.\"\n\treturn this.<totMissingTargetOrFieldErrors>k__BackingField;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public int GetTotErrors()
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction UNIMPLEMENTED not yet implemented.\"");
			return totMissingTargetOrFieldErrors;
		}
	}
}
