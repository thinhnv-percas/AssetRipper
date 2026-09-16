using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000015")]
public struct YandexAppMetricaPreloadInfo
{
	[Token(Token = "0x17000019")]
	public string TrackingId
	{
		[CompilerGenerated]
		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x85EB28", Offset = "0x85EB28", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaPreloadInfo)+10]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaPreloadInfo)+10]");
			return (string)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x85EB30", Offset = "0x85EB30", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaPreloadInfo)+10]) = value;\n\treturn;\n")]
		private set
		{
		}
	}

	[Token(Token = "0x1700001A")]
	public Dictionary<string, string> AdditionalInfo
	{
		[CompilerGenerated]
		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x85EB38", Offset = "0x85EB38", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn *([this @ X0 (YandexAppMetricaPreloadInfo)+18]);\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			//IL_000d: Expected O, but got I
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [this @ X0 (YandexAppMetricaPreloadInfo)+18]");
			return (Dictionary<string, string>)0;
		}
		[CompilerGenerated]
		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x85EB40", Offset = "0x85EB40", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (YandexAppMetricaPreloadInfo)+18]) = value;\n\treturn;\n")]
		private set
		{
		}
	}

	[Token(Token = "0x60000A6")]
	[Address(RVA = "0x85EB48", Offset = "0x85EB48", Length = "0xD0")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0x15C3938(v0, trackingId, methodInfo, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n\t// 3 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tX20 = X1;\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20]) = X0;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+8]) = X0;\n\tX0 = *([X19+10]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+10]) = X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 24 ShiftStack 32\n\treturn;\n\t// 26 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tX20 = X1;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20]) = X0;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+8]) = X0;\n\tX0 = *([X19+10]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+10]) = X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 47 ShiftStack 32\n\treturn;\n\t// 49 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+8]);\n\t*([X19]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+10]);\n\t*([X19+8]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+10]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 67 ShiftStack 32\n\treturn;\n")]
	public unsafe YandexAppMetricaPreloadInfo(string trackingId)
	{
		//IL_000b: Expected O, but got Ref
		object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
		Cpp2ILHelpers.NoteDecompilerIssue("Method not found @15C3938 (inside YandexAppMetricaNumberAttribute::WithValueReset +0x124)");
	}
}
