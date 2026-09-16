using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Plugins.Core.PathCore
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 24)]
	[Token(Token = "0x2000042")]
	public struct ControlPoint
	{
		[Token(Token = "0x4000114")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector3 a;

		[Token(Token = "0x4000115")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public Vector3 b;

		[Token(Token = "0x6000246")]
		[Address(RVA = "0x8567B4", Offset = "0x8567B4", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]) = a;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+14]) = a.y;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+18]) = a.z;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+1C]) = b;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+20]) = b.y;\n\t*([this @ X0 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+24]) = b.z;\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ControlPoint(Vector3 a, Vector3 b)
		{
			_ = a.y;
			_ = a.z;
			_ = b.y;
			_ = b.z;
		}

		[Token(Token = "0x6000247")]
		[Address(RVA = "0x1080FDC", Offset = "0x1080FDC", Length = "0x280")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0029;\n\tv40 = *([1EAF380]);\n\tv41 = *([v40 @ X8_v8]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, v, v0, v2, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([2026A49]) = v57;\nL_0029:\n\tgoto L_0038;\n\tv67 = *([v63 @ X0_v2+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tgoto L_0038;\n\tv71 = \"il2cpp_codegen_runtime_class_init\"(v63, methodInfo, v44, v45, v46, v47, v48, v49, v, v0, v2, v50, v51, v52, v53, v54);\nL_0038:\n\tv83 = UnityEngine.Vector3::op_Addition(cp.a, v);\n\tv99 = UnityEngine.Vector3::op_Addition(cp.b, v);\n\treturnBuffer.a = v83;\n\t*([returnBuffer @ X8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+4]) = v83.y;\n\t*([returnBuffer @ X8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+8]) = v83.z;\n\treturnBuffer.b = v99;\n\t*([returnBuffer @ X8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+10]) = v99.y;\n\t*([returnBuffer @ X8 (DG.Tweening.Plugins.Core.PathCore.ControlPoint)+14]) = v99.z;\n\treturn 0;\n\t// 94 ShiftStack -48\n\tstack[0] = X21;\n\tstack[10] = X20;\n\tstack[18] = X19;\n\tstack[20] = X29;\n\tstack[28] = X30;\n\tX29 = &stack[20];\n\tX8 = *([2026A4A]);\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0072;\n\tX8 = *([1EEDC58]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2026A4A]) = X8;\nL_0072:\n\tX8 = 0x1ED7000;\n\tX8 = *([1ED7A60]);\n\tX1 = 5;\n\tX0 = *([X8]);\n\tX0 = 0x8D8214(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX19 = X0;\n\tif (TEMP) goto L_00FF;\n\tX21 = *([1EEE028]);\n\tX0 = *([X21]);\n\tif (TEMP) goto L_0084;\n\tX8 = *([X19]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00FB;\nL_0084:\n\tX8 = *([X19+18]);\n\tif (TEMP) goto L_00F9;\n\tX8 = *([X21]);\n\tX0 = X20;\n\tX1 = 0;\n\t*([X19+20]) = X8;\n\tX0 = 0x158B294(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = X0;\n\tif (TEMP) goto L_0095;\n\tX8 = *([X19]);\n\tX0 = X21;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00FB;\nL_0095:\n\tX8 = *([X19+18]);\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\t*([X19+28]) = X21;\n\tX21 = *([1ECACD0]);\n\tX0 = *([X21]);\n\tif (TEMP) goto L_00AE;\n\tX8 = *([X19]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00FB;\n\tX8 = *([X19+18]);\nL_00AE:\n\tC = X8 < 2;\n\tC = ~C;\n\tTEMP1 = X8 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 2;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\tX8 = *([X21]);\n\tX0 = X20 + 0xC;\n\tX1 = 0;\n\t*([X19+30]) = X8;\n\tX0 = 0x158B294(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = X0;\n\tif (TEMP) goto L_00C8;\n\tX8 = *([X19]);\n\tX0 = X20;\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00FB;\nL_00C8:\n\tX8 = *([X19+18]);\n\tC = X8 < 3;\n\tC = ~C;\n\tTEMP1 = X8 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 3;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\t*([X19+38]) = X20;\n\tX20 = *([1EBF208]);\n\tX0 = *([X20]);\n\tif (TEMP) goto L_00E1;\n\tX8 = *([X19]);\n\tX1 = *([X8+40]);\n\tX0 = 0x8D82A4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tif (TEMP) goto L_00FB;\n\tX8 = *([X19+18]);\nL_00E1:\n\tC = X8 < 4;\n\tC = ~C;\n\tTEMP1 = X8 - 4;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 4;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~C;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_00F9;\n\tX8 = *([X20]);\n\tX0 = X19;\n\tX1 = 0;\n\t*([X19+40]) = X8;\n\tX29 = stack[20];\n\tX30 = stack[28];\n\tX20 = stack[10];\n\tX19 = stack[18];\n\tX21 = stack[0];\n\t// 246 ShiftStack 48\n\tX0 = System.String::Concat(X0, X1);\n\treturn X0;\nL_00F9:\n\tX0 = 0x8D82E4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_00FC;\nL_00FB:\n\tX0 = 0x8D82D8(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FC:\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FF:\n\tX0 = NullReferenceException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn X0;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static ControlPoint operator +(ControlPoint cp, Vector3 v)
		{
			//IL_003e: Expected native int or pointer, but got O
			//IL_005f: Expected native int or pointer, but got O
			Vector3 vector = cp.a + v;
			Vector3 vector2 = cp.b + v;
			ControlPoint controlPoint = default(ControlPoint);
			((ControlPoint*)(IntPtr)controlPoint)->a = vector;
			_ = vector.y;
			_ = vector.z;
			((ControlPoint*)(IntPtr)controlPoint)->b = vector2;
			_ = vector2.y;
			_ = vector2.z;
			return default(ControlPoint);
		}

		[Token(Token = "0x6000248")]
		[Address(RVA = "0x8567C4", Offset = "0x8567C4", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\treturnVal1 = 0x10810CC(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn returnVal1;\n\tX8 = *([X0]);\n\t*([X1]) = X8;\n\treturn X0;\n\tX8 = *([X0]);\n\tC = X8 < 0;\n\tC = ~C;\n\tTEMP1 = X8 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 0;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tX8 = TEMPCOND;\n\t*([X1]) = X8;\n\treturn X0;\n\treturn X0;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe override string ToString()
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10810CC (inside DG.Tweening.Plugins.Core.PathCore.ControlPoint::op_Addition +0xF0)");
			string result = default(string);
			return result;
		}
	}
}
