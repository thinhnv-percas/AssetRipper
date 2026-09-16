using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000018")]
public struct YandexAppMetricaRevenue
{
	[CompilerGenerated]
	[Token(Token = "0x4000036")]
	[FieldOffset(Offset = "0x10")]
	private string _003CCurrency_003Ek__BackingField;

	[CompilerGenerated]
	[Token(Token = "0x4000038")]
	[FieldOffset(Offset = "0x20")]
	internal YandexAppMetricaReceipt? _003CReceipt_003Ek__BackingField;

	[Token(Token = "0x1700001D")]
	public double Price
	{
		[CompilerGenerated]
		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x85EC8C", Offset = "0x85EC8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Currency>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000a: Expected F8, but got O
			return (double)Currency;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x85EC94", Offset = "0x85EC94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Currency>k__BackingField = value;\n\treturn;\n")]
		private set
		{
			//IL_000a: Expected O, but got F8
			Currency = (string)value;
		}
	}

	[Token(Token = "0x1700001E")]
	public int? Quantity
	{
		[CompilerGenerated]
		[Token(Token = "0x60000BA")]
		[Address(RVA = "0x85EC9C", Offset = "0x85EC9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<ProductID>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return (int?)ProductID;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000BB")]
		[Address(RVA = "0x85ECA4", Offset = "0x85ECA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<ProductID>k__BackingField = value;\n\treturn;\n")]
		set
		{
			ProductID = (string)value;
		}
	}

	[Token(Token = "0x1700001F")]
	public string Currency
	{
		[CompilerGenerated]
		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x85ECAC", Offset = "0x85ECAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.<Receipt>k__BackingField;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return (string)Receipt;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000BD")]
		[Address(RVA = "0x85ECB4", Offset = "0x85ECB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Receipt>k__BackingField = value;\n\treturn;\n")]
		private set
		{
			Receipt = (YandexAppMetricaReceipt?)value;
		}
	}

	[Token(Token = "0x17000020")]
	public string ProductID
	{
		[CompilerGenerated]
		[Token(Token = "0x60000BE")]
		[Address(RVA = "0x85ECBC", Offset = "0x85ECBC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaRevenue)+28]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaRevenue)+28]");
			return (string)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000BF")]
		[Address(RVA = "0x85ECC4", Offset = "0x85ECC4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaRevenue)+28]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x17000021")]
	public unsafe YandexAppMetricaReceipt? Receipt
	{
		[CompilerGenerated]
		[Token(Token = "0x60000C0")]
		[Address(RVA = "0x85ECCC", Offset = "0x85ECCC", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([v2 @ X8+10]) = this.<Payload>k__BackingField;\n\t*([v2 @ X8]) = *([this @ X0 (YandexAppMetricaRevenue)+30]);\n\treturn this;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_001a: Expected O, but got I
			//IL_001c: Expected O, but got Ref
			_ = Payload;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaRevenue)+30]");
			object obj = 0;
			return (YandexAppMetricaReceipt?)(object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
		}
		[CompilerGenerated]
		[Token(Token = "0x60000C1")]
		[Address(RVA = "0x85ECE0", Offset = "0x85ECE0", Length = "0xC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaRevenue)+30]) = *([value @ X1 (System.Nullable`1<YandexAppMetricaReceipt>)]);\n\tthis.<Payload>k__BackingField = value.value;\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		set
		{
			Payload = (string)value.value;
		}
	}

	[Token(Token = "0x17000022")]
	public string Payload
	{
		[CompilerGenerated]
		[Token(Token = "0x60000C2")]
		[Address(RVA = "0x85ECEC", Offset = "0x85ECEC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaRevenue)+50]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaRevenue)+50]");
			return (string)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000C3")]
		[Address(RVA = "0x85ECF4", Offset = "0x85ECF4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaRevenue)+50]) = value;\n\treturn;\n")]
		set
		{
		}
	}

	[Token(Token = "0x60000C4")]
	[Address(RVA = "0x85ECFC", Offset = "0x85ECFC", Length = "0x60")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.<Currency>k__BackingField = price;\n\tthis.<ProductID>k__BackingField = 0;\n\tthis.<Receipt>k__BackingField = currency;\n\t*([this @ X0 (YandexAppMetricaRevenue)+48]) = 0;\n\t*([this @ X0 (YandexAppMetricaRevenue)+38]) = 0;\n\t*([this @ X0 (YandexAppMetricaRevenue)+28]) = 0;\n\treturn;\n\t// 8 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xE45;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 18 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0xE45;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 3 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public YandexAppMetricaRevenue(double price, string currency)
	{
		//IL_000a: Expected O, but got F8
		Currency = (string)price;
		ProductID = null;
		Receipt = (YandexAppMetricaReceipt?)currency;
		_ = 0;
		_ = 0;
		_ = 0;
	}
}
