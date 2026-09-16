using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace LunarConsolePlugin
{
	[StructLayout((LayoutKind)0, Size = 8)]
	[Token(Token = "0x2000005")]
	public struct CVarValueRange
	{
		[Token(Token = "0x4000009")]
		public static readonly CVarValueRange Undefined;

		[Token(Token = "0x400000A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public readonly float min;

		[Token(Token = "0x400000B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public readonly float max;

		[Token(Token = "0x17000001")]
		public bool IsValid
		{
			[Token(Token = "0x6000007")]
			[Address(RVA = "0x85E1A8", Offset = "0x85E1A8", Length = "0xBC")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0x13D4BA8(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n\t// 3 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tX20 = X1;\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20]) = X0;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D8464(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+8]) = X0;\n\tX8 = *([X19+10]);\n\t*([X20+10]) = X8;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 23 ShiftStack 32\n\treturn X0;\n\t// 25 ShiftStack -32\n\tstack[0] = X20;\n\tstack[8] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tX20 = X1;\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20]) = X0;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D8470(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X20+8]) = X0;\n\tX8 = *([X19+10]);\n\t*([X20+10]) = X8;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX20 = stack[0];\n\tX19 = stack[8];\n\t// 45 ShiftStack 32\n\treturn X0;\n\t// 47 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19]);\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X19+8]);\n\t*([X19]) = 0;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 62 ShiftStack 32\n\treturn X0;\n")]
			get
			{
				CVarValueRange cVarValueRange = default(CVarValueRange);
				float num = cVarValueRange.min + 2.2E-44f;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @13D4BA8 (inside LunarConsolePlugin.CVar::get_HasRange +0x8)");
				bool result = default(bool);
				return result;
			}
		}

		[Token(Token = "0x6000006")]
		[Address(RVA = "0x85E1A0", Offset = "0x85E1A0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (LunarConsolePlugin.CVarValueRange)+10]) = min;\n\t*([this @ X0 (LunarConsolePlugin.CVarValueRange)+14]) = max;\n\treturn;\n")]
		public CVarValueRange(float min, float max)
		{
		}

		[Token(Token = "0x6000008")]
		[Address(RVA = "0x13D588C", Offset = "0x13D588C", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv14 = *([1ED9E90]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028A61]) = v35;\nL_0016:\n\tv40.Undefined = 0x7FC000007FC00000;\n\treturn;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static CVarValueRange()
		{
			//IL_0013: Expected O, but got I8
			Undefined = (CVarValueRange)9205357640488583168L;
		}
	}
}
