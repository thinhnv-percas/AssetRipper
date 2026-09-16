using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace DG.Tweening.Plugins
{
	[StructLayout((LayoutKind)0, Size = 40)]
	[Token(Token = "0x2000008")]
	public struct SpiralOptions : IPlugOptions
	{
		[Token(Token = "0x400003D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public float depth;

		[Token(Token = "0x400003E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public float frequency;

		[Token(Token = "0x400003F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public float speed;

		[Token(Token = "0x4000040")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public SpiralMode mode;

		[Token(Token = "0x4000041")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public bool snapping;

		[Token(Token = "0x4000042")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		internal float unit;

		[Token(Token = "0x4000043")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		internal Quaternion axisQ;

		[Token(Token = "0x600001C")]
		[Address(RVA = "0x8658BC", Offset = "0x8658BC", Length = "0x458")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Plugins.SpiralOptions)+20]) = 0;\n\tthis.snapping = 0;\n\tthis.axisQ = 0;\n\treturn;\n\t// 4 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX20 = X0;\n\tX8 = *([X20+10]);\n\tX19 = X1;\n\t*([X19]) = X8;\n\tX8 = *([X20+14]);\n\t*([X19+4]) = X8;\n\tX8 = *([X20+18]);\n\t*([X19+8]) = X8;\n\tX8 = *([X20+1C]);\n\t*([X19+C]) = X8;\n\tX8 = *([X20+20]);\n\tX9 = *([X20+24]);\n\t*([X19+10]) = X8;\n\t*([X19+14]) = X9;\n\tX8 = *([X20+28]);\n\t*([X19+18]) = X8;\n\tX8 = *([X20+2C]);\n\t*([X19+1C]) = X8;\n\tX8 = *([X20+30]);\n\tif (TEMP) goto L_0059;\n\tX21 = *([X8+18]);\n\tX8 = 0 | 0x38;\n\tX0 = X21 * X8;\n\tX0 = 0x8D82B8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X21 < 1;\n\tC = ~C;\n\tTEMP1 = X21 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ 1;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X19+20]) = X0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_005A;\n\tX9 = *([X20+30]);\n\tX8 = X21 & 0xFFFFFFFF;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX8 = X8 - 1;\n\tV2 = *([X9+30]);\n\tV0 = *([X9+40]);\n\tV1 = *([X9+20]);\n\tX9 = *([X9+50]);\n\t*([X0+10]) = V2;\n\t*([X0+20]) = V0;\n\t*([X0]) = V1;\n\t*([X0+30]) = X9;\n\tif (Z) goto L_005A;\n\tX9 = 0x58;\nL_0047:\n\tX10 = *([X20+30]);\n\tX11 = *([X19+20]);\n\tX8 = X8 - 1;\n\tX10 = X10 + X9;\n\tX12 = *([X10+30]);\n\tV2 = *([X10+10]);\n\tV0 = *([X10+20]);\n\tV1 = *([X10]);\n\tX11 = X11 + X9;\n\tX9 = X9 + 0x38;\n\t*([X11+10]) = X12;\n\t*([X11-10]) = V2;\n\t*([X11]) = V0;\n\t*([X11-20]) = V1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0047;\n\tgoto L_005A;\nL_0059:\n\t*([X19+20]) = 0;\nL_005A:\n\tX8 = *([X20+38]);\n\tif (TEMP) goto L_0096;\n\tX21 = *([X8+18]);\n\tX8 = 0 | 0x38;\n\tX0 = X21 * X8;\n\tX0 = 0x8D82B8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tC = X21 < 1;\n\tC = ~C;\n\tTEMP1 = X21 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X21 ^ 1;\n\tTEMP3 = X21 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\t*([X19+28]) = X0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0097;\n\tX9 = *([X20+38]);\n\tX8 = X21 & 0xFFFFFFFF;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX8 = X8 - 1;\n\tV2 = *([X9+30]);\n\tV0 = *([X9+40]);\n\tV1 = *([X9+20]);\n\tX9 = *([X9+50]);\n\t*([X0+10]) = V2;\n\t*([X0+20]) = V0;\n\t*([X0]) = V1;\n\t*([X0+30]) = X9;\n\tif (Z) goto L_0097;\n\tX9 = 0x58;\nL_0084:\n\tX10 = *([X20+38]);\n\tX11 = *([X19+28]);\n\tX8 = X8 - 1;\n\tX10 = X10 + X9;\n\tX12 = *([X10+30]);\n\tV2 = *([X10+10]);\n\tV0 = *([X10+20]);\n\tV1 = *([X10]);\n\tX11 = X11 + X9;\n\tX9 = X9 + 0x38;\n\t*([X11+10]) = X12;\n\t*([X11-10]) = V2;\n\t*([X11]) = V0;\n\t*([X11-20]) = V1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0084;\n\tgoto L_0097;\nL_0096:\n\t*([X19+28]) = 0;\nL_0097:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 156 ShiftStack 48\n\treturn;\n\t// 158 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([202A8F8]);\n\tX19 = X1;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00B3;\n\tX8 = *([1EB6888]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([202A8F8]) = X8;\nL_00B3:\n\tX8 = *([X20]);\n\t*([X19+10]) = X8;\n\tX8 = *([X20+4]);\n\t*([X19+14]) = X8;\n\tX8 = *([X20+8]);\n\t*([X19+18]) = X8;\n\tX8 = *([X20+C]);\n\t*([X19+1C]) = X8;\n\tX8 = *([X20+10]);\n\tX9 = *([X20+14]);\n\t*([X19+20]) = X8;\n\t*([X19+24]) = X9;\n\tX8 = *([X20+18]);\n\t*([X19+28]) = X8;\n\tX8 = *([X20+1C]);\n\t*([X19+2C]) = X8;\n\tX8 = *([X20+20]);\n\tif (TEMP) goto L_0104;\n\tX0 = *([X19+30]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D0;\n\tX8 = *([1EFE138]);\n\tX1 = 0 | 1;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+30]) = X0;\nL_00D0:\n\tX8 = *([X0+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0104;\n\tX9 = *([X20+20]);\n\tX8 = X8 & 0xFFFFFFFF;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX8 = X8 - 1;\n\tV2 = *([X9+10]);\n\tV0 = *([X9+20]);\n\tV1 = *([X9]);\n\tX9 = *([X9+30]);\n\t*([X0+30]) = V2;\n\t*([X0+40]) = V0;\n\t*([X0+20]) = V1;\n\t*([X0+50]) = X9;\n\tif (Z) goto L_0104;\n\tX9 = 0x58;\nL_00F3:\n\tX10 = *([X20+20]);\n\tX11 = *([X19+30]);\n\tX8 = X8 - 1;\n\tX10 = X10 + X9;\n\tX12 = *([X10+10]);\n\tV2 = *([X10-10]);\n\tV0 = *([X10]);\n\tV1 = *([X10-20]);\n\tX11 = X11 + X9;\n\tX9 = X9 + 0x38;\n\t*([X11+30]) = X12;\n\t*([X11+10]) = V2;\n\t*([X11+20]) = V0;\n\t*([X11]) = V1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00F3;\nL_0104:\n\tX8 = *([X20+28]);\n\tif (TEMP) goto L_0145;\n\tX0 = *([X19+38]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0111;\n\tX8 = *([1EFE138]);\n\tX1 = 0 | 1;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+38]) = X0;\nL_0111:\n\tX8 = *([X0+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tif (TEMPCOND) goto L_0145;\n\tX9 = *([X20+28]);\n\tX8 = X8 & 0xFFFFFFFF;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tX8 = X8 - 1;\n\tV2 = *([X9+10]);\n\tV0 = *([X9+20]);\n\tV1 = *([X9]);\n\tX9 = *([X9+30]);\n\t*([X0+30]) = V2;\n\t*([X0+40]) = V0;\n\t*([X0+20]) = V1;\n\t*([X0+50]) = X9;\n\tif (Z) goto L_0145;\n\tX9 = 0x58;\nL_0134:\n\tX10 = *([X20+28]);\n\tX11 = *([X19+38]);\n\tX8 = X8 - 1;\n\tX10 = X10 + X9;\n\tX12 = *([X10+10]);\n\tV2 = *([X10-10]);\n\tV0 = *([X10]);\n\tV1 = *([X10-20]);\n\tX11 = X11 + X9;\n\tX9 = X9 + 0x38;\n\t*([X11+30]) = X12;\n\t*([X11+10]) = V2;\n\t*([X11+20]) = V0;\n\t*([X11]) = V1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0134;\nL_0145:\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 330 ShiftStack 48\n\treturn;\n\t// 332 ShiftStack -32\n\tstack[0] = X19;\n\tstack[10] = X29;\n\tstack[18] = X30;\n\tX29 = &stack[10];\n\tX19 = X0;\n\tX0 = *([X19+20]);\n\tif (TEMP) goto L_0157;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+20]) = 0;\nL_0157:\n\tX0 = *([X19+28]);\n\tif (TEMP) goto L_015C;\n\tX0 = 0x8D8480(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t*([X19+28]) = 0;\nL_015C:\n\tX29 = stack[10];\n\tX30 = stack[18];\n\tX19 = stack[0];\n\t// 351 ShiftStack 32\n\treturn;\n\tX8 = *([X0]);\n\t*([X1]) = X8;\n\tX8 = *([X0+1]);\n\t*([X1+4]) = X8;\n\tX8 = *([X0+2]);\n\t*([X1+8]) = X8;\n\tX8 = *([X0+3]);\n\t*([X1+C]) = X8;\n\tX8 = *([X0+4]);\n\t*([X1+10]) = X8;\n\tX8 = *([X0+5]);\n\t*([X1+14]) = X8;\n\tX8 = *([X0+8]);\n\t*([X1+18]) = X8;\n\tX8 = *([X0+C]);\n\t*([X1+1C]) = X8;\n\tX8 = *([X0+10]);\n\t*([X1+20]) = X8;\n\tX8 = *([X0+14]);\n\t*([X1+24]) = X8;\n\tX8 = *([X0+18]);\n\t*([X1+28]) = X8;\n\treturn;\n\tX8 = *([X0]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1]) = X8;\n\tX8 = *([X0+4]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1+1]) = X8;\n\tX8 = *([X0+8]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1+2]) = X8;\n\tX8 = *([X0+C]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1+3]) = X8;\n\tX8 = *([X0+10]);\n// ... 37 further instructions omitted\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Reset()
		{
			_ = 0;
			snapping = false;
			axisQ = default(Quaternion);
		}
	}
}
