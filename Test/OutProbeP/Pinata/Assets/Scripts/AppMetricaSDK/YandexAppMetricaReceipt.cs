using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[StructLayout((LayoutKind)0, Size = 24)]
[Token(Token = "0x2000019")]
public struct YandexAppMetricaReceipt
{
	[CompilerGenerated]
	[Token(Token = "0x400003C")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
	private string _003CTransactionID_003Ek__BackingField;

	[Token(Token = "0x17000023")]
	public string Data
	{
		[CompilerGenerated]
		[Token(Token = "0x60000C5")]
		[Address(RVA = "0x85EC18", Offset = "0x85EC18", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<TransactionID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return TransactionID;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000C6")]
		[Address(RVA = "0x85EC20", Offset = "0x85EC20", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<TransactionID>k__BackingField = value;\n\treturn;\n")]
		set
		{
			TransactionID = value;
		}
	}

	[Token(Token = "0x17000024")]
	public string Signature
	{
		[CompilerGenerated]
		[Token(Token = "0x60000C7")]
		[Address(RVA = "0x85EC28", Offset = "0x85EC28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaReceipt)+18]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaReceipt)+18]");
			return (string)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000C8")]
		[Address(RVA = "0x85EC30", Offset = "0x85EC30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaReceipt)+18]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x17000025")]
	public string TransactionID
	{
		[CompilerGenerated]
		[Token(Token = "0x60000C9")]
		[Address(RVA = "0x85EC38", Offset = "0x85EC38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaReceipt)+20]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaReceipt)+20]");
			return (string)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000CA")]
		[Address(RVA = "0x85EC40", Offset = "0x85EC40", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaReceipt)+20]) = value;\n\treturn;\n\t// 2 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xDF1;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 12 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xDF1;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
		}
	}
}
