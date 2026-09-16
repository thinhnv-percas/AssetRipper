using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Plugins.Options
{
	[StructLayout((LayoutKind)0, Size = 4)]
	[Token(Token = "0x2000033")]
	public struct UintOptions : IPlugOptions
	{
		[Token(Token = "0x40000F2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public bool isNegativeChangeValue;

		[Token(Token = "0x6000224")]
		[Address(RVA = "0x8582A4", Offset = "0x8582A4", Length = "0xEC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Plugins.Options.UintOptions)+10]) = 0;\n\treturn;\n\t// 2 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX8 = *([X0]);\n\tX19 = X1;\n\t*([X19]) = X8;\n\tX8 = *([X0+4]);\n\t*([X19+4]) = X8;\n\tX1 = *([X0+8]);\n\tX0 = 0 | 4;\n\tX0 = 0x8D82E8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = X0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 19 ShiftStack 32\n\treturn;\n\t// 21 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([20274B1]);\n\tX19 = X1;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_002A;\n\tX8 = *([1EB1E60]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([20274B1]) = X8;\nL_002A:\n\tX8 = *([X20]);\n\tX0 = 0 | 4;\n\t*([X19]) = X8;\n\tX8 = *([X20+4]);\n\tX9 = *([1EE1A60]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X19+4]) = X8;\n\tX1 = *([X9]);\n\tX2 = *([X20+8]);\n\tX0 = 0x8D82EC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = X0;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 69 ShiftStack 48\n\treturn;\n\t// 71 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19+8]);\n\tX0 = 0x8D82F0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+8]) = 0;\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 83 ShiftStack 32\n\treturn;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			_ = 0;
		}
	}
}
