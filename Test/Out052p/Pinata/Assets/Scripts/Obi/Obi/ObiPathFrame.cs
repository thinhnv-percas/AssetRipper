using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[StructLayout((LayoutKind)0, Size = 68)]
	[Token(Token = "0x2000079")]
	public struct ObiPathFrame
	{
		[Token(Token = "0x20000CB")]
		public enum Axis
		{
			[Token(Token = "0x4000354")]
			X = 0,
			[Token(Token = "0x4000355")]
			Y = 1,
			[Token(Token = "0x4000356")]
			Z = 2
		}

		[Token(Token = "0x40001FD")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public Vector3 position;

		[Token(Token = "0x40001FE")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public Vector3 tangent;

		[Token(Token = "0x40001FF")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public Vector3 normal;

		[Token(Token = "0x4000200")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public Vector3 binormal;

		[Token(Token = "0x4000201")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public Vector4 color;

		[Token(Token = "0x4000202")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public float thickness;

		[Token(Token = "0x60004B4")]
		[Address(RVA = "0x84BEA0", Offset = "0x84BEA0", Length = "0x40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = this + 0x10;\n\tv41 = 0xC2DC30(v28, methodInfo, v43, v44, v45, v46, v47, v48, position, position.y, position.z, tangent, tangent.y, tangent.z, normal, v13);\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe ObiPathFrame(Vector3 position, Vector3 tangent, Vector3 normal, Vector3 binormal, Vector4 color, float thickness)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC30 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x4)");
		}

		[Token(Token = "0x60004B5")]
		[Address(RVA = "0x84BEE0", Offset = "0x84BEE0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0xC2DC74(v0, methodInfo, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
		public unsafe void Reset()
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC74 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x48)");
		}

		[Token(Token = "0x60004B6")]
		[Address(RVA = "0xC2DD30", Offset = "0xC2DD30", Length = "0x214")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv28 = &v29 @ stack_-10_v2;\n\tgoto L_002B;\n\tv42 = *([1EFB240]);\n\tv43 = *([v42 @ X8_v13]);\n\tv44 = \"il2cpp_codegen_initialize_method\"(v43, c2, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([2023166]) = v61;\nL_002B:\n\tgoto L_003A;\n\tv74 = *([v70 @ X0_v2+E0]);\n\tv75 = v74 == 0;\n\tv76 = ~v75;\n\tgoto L_003A;\n\tv78 = \"il2cpp_codegen_runtime_class_init\"(v70, c2, methodInfo, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58);\nL_003A:\n\tv90 = UnityEngine.Vector3::op_Addition(c1.position, c2.position);\n\t*([v28 @ X29_v1-64]) = v90;\n\tv105 = UnityEngine.Vector3::op_Addition(c1.tangent, c2.tangent);\n\tv121 = UnityEngine.Vector3::op_Addition(c1.normal, c2.normal);\n\tv137 = UnityEngine.Vector3::op_Addition(c1.binormal, c2.binormal);\n\tgoto L_008F;\n\tv157 = *([v152 @ X0_v8+E0]);\n\tv158 = v157 == 0;\n\tv159 = ~v158;\n\tif (v159) goto L_008F;\n\tv161 = \"il2cpp_codegen_runtime_class_init\"(v152, c2, methodInfo, v46, v47, v48, v49, v50, v137, v138, v139, v129, v130, v131, v126, v58);\nL_008F:\n\tv175 = UnityEngine.Vector4::op_Addition(c1.color, c2.color);\n\tv188 = 0x6D26F0(returnBuffer, 0, 0x44, v46, v47, v48, v49, v50, v175, v175.y, v175.z, v175.w, c2.color, *([c2 @ X1 (Obi.ObiPathFrame)+34]), *([c2 @ X1 (Obi.ObiPathFrame)+38]), *([c2 @ X1 (Obi.ObiPathFrame)+3C]));\n\treturnVal1 = 0xC2DC30(returnBuffer, 0, 0x44, v46, v47, v48, v49, v50, *([v28 @ X29_v1-64]), v90.y, v90.z, v105, v105.y, v105.z, *([c2 @ X1 (Obi.ObiPathFrame)+38]), *([c2 @ X1 (Obi.ObiPathFrame)+3C]));\n\treturn returnVal1;\n// 171 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static ObiPathFrame operator +(ObiPathFrame c1, ObiPathFrame c2)
		{
			object obj2 = default(object);
			object obj = obj2;
			Vector3 vector = c1.position + c2.position;
			Vector3 vector2 = c1.tangent + c2.tangent;
			Vector3 vector3 = c1.normal + c2.normal;
			Vector3 vector4 = c1.binormal + c2.binormal;
			Vector4 vector5 = c1.color + c2.color;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC30 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x4)");
			ObiPathFrame result = default(ObiPathFrame);
			return result;
		}

		[Token(Token = "0x60004B7")]
		[Address(RVA = "0xC2DF44", Offset = "0xC2DF44", Length = "0xC98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = &v27 @ stack_-10_v2;\n\tgoto L_0027;\n\tv40 = *([1EF0BB0]);\n\tv41 = *([v40 @ X8_v13]);\n\tv42 = \"il2cpp_codegen_initialize_method\"(v41, methodInfo, v44, v45, v46, v47, v48, v49, f, v50, v51, v52, v53, v54, v55, v56);\n\tv59 = 0 | 1;\n\t*([2023167]) = v59;\nL_0027:\n\tgoto L_0033;\n\tv69 = *([v65 @ X0_v2+E0]);\n\tv70 = v69 == 0;\n\tv71 = ~v70;\n\tgoto L_0033;\n\tv73 = \"il2cpp_codegen_runtime_class_init\"(v65, methodInfo, v44, v45, v46, v47, v48, v49, f, v50, v51, v52, v53, v54, v55, v56);\nL_0033:\n\tv82 = UnityEngine.Vector3::op_Multiply(c.position, f);\n\t*([v26 @ X29_v1-18]) = v82.y;\n\t*([v26 @ X29_v1-14]) = v82;\n\tv93 = UnityEngine.Vector3::op_Multiply(c.tangent, f);\n\tv106 = UnityEngine.Vector3::op_Multiply(c.normal, f);\n\tv119 = UnityEngine.Vector3::op_Multiply(c.binormal, f);\n\tgoto L_0077;\n\tv135 = *([v130 @ X0_v8+E0]);\n\tv136 = v135 == 0;\n\tv137 = ~v136;\n\tif (v137) goto L_0077;\n\tv139 = \"il2cpp_codegen_runtime_class_init\"(v130, methodInfo, v44, v45, v46, v47, v48, v49, v119, v120, v121, v117, v53, v54, v55, v56);\nL_0077:\n\tv149 = UnityEngine.Vector4::op_Multiply(c.color, f);\n\tv161 = 0x6D26F0(returnBuffer, 0, 0x44, v45, v46, v47, v48, v49, v149, v149.y, v149.z, v149.w, f, v54, v55, v56);\n\treturnVal1 = 0xC2DC30(returnBuffer, 0, 0x44, v45, v46, v47, v48, v49, *([v26 @ X29_v1-14]), *([v26 @ X29_v1-18]), v82.z, v93, v93.y, v93.z, v55, v56);\n\treturn returnVal1;\n\t// 171 ShiftStack -64\n\tstack[0] = V11;\n\tstack[8] = V10;\n\tstack[10] = V9;\n\tstack[18] = V8;\n\tstack[20] = X20;\n\tstack[28] = X19;\n\tstack[30] = X29;\n\tstack[38] = X30;\n\tX29 = &stack[30];\n\tX8 = *([2023168]);\n\tV8 = V0;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C3;\n\tX8 = *([1EDD710]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023168]) = X8;\nL_00C3:\n\tX8 = 0x1EC5000;\n\tX8 = *([1EC5B90]);\n\tV11 = *([X19+C]);\n\tV9 = *([X19+10]);\n\tV10 = *([X19+14]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_00D2;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D2;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00D2:\n\tV0 = V8;\n\tV1 = V11;\n\tV2 = V9;\n\tV3 = V10;\n\tX0 = 0;\n\t// 215 MakeStruct AGGC2E194_1, typeof(UnityEngine.Vector3), V1, V2, V3\n\tV0 = UnityEngine.Quaternion::AngleAxis(V0, AGGC2E194_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = *([X19+18]);\n\tV5 = *([X19+1C]);\n\tV6 = *([X19+20]);\n\tX0 = 0;\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tV11 = V3;\n\t// 228 MakeStruct AGGC2E1B4_0, typeof(UnityEngine.Quaternion), V0, V1, V2, V3\n\t// 229 MakeStruct AGGC2E1B4_1, typeof(UnityEngine.Vector3), V4, V5, V6\n\tV0 = UnityEngine.Quaternion::op_Multiply(AGGC2E1B4_0, AGGC2E1B4_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV4 = *([X19+24]);\n\tV5 = *([X19+28]);\n\tV6 = *([X19+2C]);\n\t*([X19+18]) = V0;\n\t*([X19+1C]) = V1;\n\t*([X19+20]) = V2;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tV3 = V11;\n\tX0 = 0;\n\t// 244 MakeStruct AGGC2E1DC_0, typeof(UnityEngine.Quaternion), V0, V1, V2, V3\n\t// 245 MakeStruct AGGC2E1DC_1, typeof(UnityEngine.Vector3), V4, V5, V6\n\tV0 = UnityEngine.Quaternion::op_Multiply(AGGC2E1DC_0, AGGC2E1DC_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t*([X19+24]) = V0;\n\t*([X19+28]) = V1;\n\t*([X19+2C]) = V2;\n\tX29 = stack[30];\n\tX30 = stack[38];\n\tX20 = stack[20];\n\tX19 = stack[28];\n\tV9 = stack[10];\n\tV8 = stack[18];\n\tV11 = stack[0];\n\tV10 = stack[8];\n\t// 260 ShiftStack 64\n\treturn X0;\n\t// 262 ShiftStack -128\n\tstack[20] = V14;\n\tstack[30] = V13;\n\tstack[38] = V12;\n\tstack[40] = V11;\n\tstack[48] = V10;\n\tstack[50] = V9;\n\tstack[58] = V8;\n\tstack[60] = X20;\n\tstack[68] = X19;\n\tstack[70] = X29;\n\tstack[78] = X30;\n\tX29 = &stack[70];\n\tX8 = *([2023169]);\n\tV8 = V3;\n\tV9 = V2;\n\tV10 = V1;\n\tV11 = V0;\n\tX19 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0124;\n\tX8 = *([1EC48F0]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023169]) = X8;\nL_0124:\n\tX0 = &stack[0];\n\tV2 = 0;\n\tV0 = V9;\n\tV1 = V10;\n\tX1 = 0;\n\tstack[18] = 0;\n\tstack[10] = 0;\n\t*([X19+C]) = V10;\n\t*([X19+10]) = V9;\n\t*([X19+14]) = V8;\n\tstack[8] = 0;\n\tstack[0] = 0;\n\tX0 = 0x1586898(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = stack[8];\n\tX9 = stack[0];\n\tX0 = &stack[10];\n\tX1 = 0;\n\tstack[18] = X8;\n\tstack[10] = X9;\n\tX0 = 0x158A710(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV12 = V0;\n\tV13 = V1;\n\tV14 = V2;\n\t*([X19+18]) = V12;\n\t*([X19+1C]) = V13;\n\t*([X19+20]) = V14;\n\tX8 = *([1EE1550]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_014A;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014A;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014A:\n\tV0 = V12;\n\tV1 = V13;\n\tV2 = V14;\n\tV3 = V10;\n\tV4 = V9;\n\tV5 = V8;\n\tX0 = 0;\n\t// 337 MakeStruct AGGC2E2F0_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 338 MakeStruct AGGC2E2F0_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Vector3::Cross(AGGC2E2F0_0, AGGC2E2F0_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t*([X19+24]) = V0;\n\t*([X19+28]) = V1;\n\t*([X19+2C]) = V2;\n\tX8 = *([1EC5B90]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0165;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0165;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0165:\n\tV0 = V11;\n\tV1 = V10;\n\tV2 = V9;\n\tV3 = V8;\n\tX0 = 0;\n\t// 362 MakeStruct AGGC2E330_1, typeof(UnityEngine.Vector3), V1, V2, V3\n\tV0 = UnityEngine.Quaternion::AngleAxis(V0, AGGC2E330_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = *([X19+18]);\n\tV5 = *([X19+1C]);\n\tV6 = *([X19+20]);\n\tX0 = 0;\n\tV8 = V0;\n\tV9 = V1;\n\tV10 = V2;\n\tV11 = V3;\n\t// 375 MakeStruct AGGC2E350_0, typeof(UnityEngine.Quaternion), V0, V1, V2, V3\n\t// 376 MakeStruct AGGC2E350_1, typeof(UnityEngine.Vector3), V4, V5, V6\n\tV0 = UnityEngine.Quaternion::op_Multiply(AGGC2E350_0, AGGC2E350_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV4 = *([X19+24]);\n\tV5 = *([X19+28]);\n\tV6 = *([X19+2C]);\n\t*([X19+18]) = V0;\n\t*([X19+1C]) = V1;\n\t*([X19+20]) = V2;\n\tV0 = V8;\n\tV1 = V9;\n\tV2 = V10;\n\tV3 = V11;\n\tX0 = 0;\n\t// 391 MakeStruct AGGC2E378_0, typeof(UnityEngine.Quaternion), V0, V1, V2, V3\n\t// 392 MakeStruct AGGC2E378_1, typeof(UnityEngine.Vector3), V4, V5, V6\n\tV0 = UnityEngine.Quaternion::op_Multiply(AGGC2E378_0, AGGC2E378_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\t*([X19+24]) = V0;\n\t*([X19+28]) = V1;\n\t*([X19+2C]) = V2;\n\tX29 = stack[70];\n\tX30 = stack[78];\n\tX20 = stack[60];\n\tX19 = stack[68];\n\tV9 = stack[50];\n\tV8 = stack[58];\n\tV11 = stack[40];\n\tV10 = stack[48];\n\tV13 = stack[30];\n\tV12 = stack[38];\n\tV14 = stack[20];\n\t// 410 ShiftStack 128\n\treturn X0;\n\t// 412 ShiftStack -96\n\tstack[0] = V14;\n\tstack[8] = V13;\n\tstack[10] = V12;\n\tstack[18] = V11;\n\tstack[20] = V10;\n\tstack[28] = V9;\n\tstack[30] = V8;\n\tstack[38] = X21;\n\tstack[40] = X20;\n\tstack[48] = X19;\n\tstack[50] = X29;\n\tstack[58] = X30;\n\tX29 = &stack[50];\n\tX8 = *([202316A]);\n\tV8 = V0;\n\tX19 = X1;\n\tX20 = X0;\n\tTEMP = X8 & 1;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01B9;\n\tX8 = *([1EA9FA8]);\n\tX0 = *([X8]);\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([202316A]) = X8;\nL_01B9:\n\tX8 = 0x1EC5000;\n\tV9 = *([X20+C]);\n\tV10 = *([X20+10]);\n\tX8 = *([1EC5B90]);\n\tV14 = *([X20+14]);\n\tV13 = *([X19+C]);\n\tV11 = *([X19+10]);\n\tV12 = *([X19+14]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01CB;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01CB;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01CB:\n\tV0 = V9;\n\tV1 = V10;\n\tV2 = V14;\n\tV3 = V13;\n\tV4 = V11;\n\tV5 = V12;\n\tX0 = 0;\n\t// 466 MakeStruct AGGC2E440_0, typeof(UnityEngine.Vector3), V0, V1, V2\n\t// 467 MakeStruct AGGC2E440_1, typeof(UnityEngine.Vector3), V3, V4, V5\n\tV0 = UnityEngine.Quaternion::FromToRotation(AGGC2E440_0, AGGC2E440_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n\tV4 = *([X19+14]);\n\tV10 = V1;\n\tV11 = V2;\n\tV1 = *([X19+C]);\n\tV2 = *([X19+10]);\n\tV9 = V0;\n\tV12 = V3;\n\tV0 = V8;\n\tV3 = V4;\n\tX0 = 0;\n\t// 482 MakeStruct AGGC2E468_1, typeof(UnityEngine.Vector3), V1, V2, V3\n\tV0 = UnityEngine.Quaternion::AngleAxis(V0, AGGC2E468_1, X0);\n\tV1 = *([V0+4]);\n\tV2 = *([V0+8]);\n\tV3 = *([V0+C]);\n// ... truncated")]
		public static ObiPathFrame operator *(float f, ObiPathFrame c)
		{
			object obj2 = default(object);
			object obj = obj2;
			_ = (c.position * f).y;
			Vector3 vector = c.tangent * f;
			Vector3 vector2 = c.normal * f;
			Vector3 vector3 = c.binormal * f;
			Vector4 vector4 = c.color * f;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D26F0 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2DC30 (inside Obi.ObiPath+<GetDataChannels>d__17::System.Collections.IEnumerable.GetEnumerator +0x4)");
			ObiPathFrame result = default(ObiPathFrame);
			return result;
		}

		[Token(Token = "0x60004B8")]
		[Address(RVA = "0x84BEE8", Offset = "0x84BEE8", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0xC2E118(v0, methodInfo, v4, v5, v6, v7, v8, v9, twist, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n")]
		public unsafe void SetTwist(float twist)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E118 (inside Obi.ObiPathFrame::op_Multiply +0x1D4)");
		}

		[Token(Token = "0x60004B9")]
		[Address(RVA = "0x84BEF0", Offset = "0x84BEF0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv3 = this + 0x10;\n\tv5 = 0xC2E1FC(v3, methodInfo, v7, v8, v9, v10, v11, v12, twist, tangent, tangent.y, tangent.z, v14, v15, v16, v17);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void SetTwistAndTangent(float twist, Vector3 tangent)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E1FC (inside Obi.ObiPathFrame::op_Multiply +0x2B8)");
		}

		[Token(Token = "0x60004BA")]
		[Address(RVA = "0x84BEF8", Offset = "0x84BEF8", Length = "0x4C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = this + 0x10;\n\tv17 = 0x6D2410(&v13 @ stack_-68, frame, 0x44, v19, v20, v21, v22, v23, twist, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 0xC2E3A4(v10, &v13 @ stack_-68, 0x44, v19, v20, v21, v22, v23, twist, v24, v25, v26, v27, v28, v29, v30);\n\treturn;\n// 17 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Transport(ObiPathFrame frame, float twist)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2410 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E3A4 (inside Obi.ObiPathFrame::op_Multiply +0x460)");
		}

		[Token(Token = "0x60004BB")]
		[Address(RVA = "0x84BF44", Offset = "0x84BF44", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = this + 0x10;\n\tv8 = 0xC2E534(v6, methodInfo, v10, v11, v12, v13, v14, v15, newPosition, newPosition.y, newPosition.z, newTangent, newTangent.y, newTangent.z, twist, v17);\n\treturn;\n// 4 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Transport(Vector3 newPosition, Vector3 newTangent, float twist)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E534 (inside Obi.ObiPathFrame::op_Multiply +0x5F0)");
		}

		[Token(Token = "0x60004BC")]
		[Address(RVA = "0x84BF4C", Offset = "0x84BF4C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = this + 0x10;\n\tv20 = 0xC2E6A8(v14, methodInfo, v22, v23, v24, v25, v26, v27, newPosition, newPosition.y, newPosition.z, newTangent, newTangent.y, newTangent.z, newNormal, v9);\n\treturn;\n// 12 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void Transport(Vector3 newPosition, Vector3 newTangent, Vector3 newNormal, float twist)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2E6A8 (inside Obi.ObiPathFrame::op_Multiply +0x764)");
		}

		[Token(Token = "0x60004BD")]
		[Address(RVA = "0x84BF6C", Offset = "0x84BF6C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = new System.TypeLoadException();\n\treturn returnVal1;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public Matrix4x4 ToMatrix(Axis mainAxis)
		{
			return (Matrix4x4)new TypeLoadException();
		}

		[Token(Token = "0x60004BE")]
		[Address(RVA = "0x84BF74", Offset = "0x84BF74", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = this + 0x10;\n\tv2 = 0xC2EA04(v0, methodInfo, v4, v5, v6, v7, v8, v9, size, v11, v12, v13, v14, v15, v16, v17);\n\treturn;\n\tX8 = *([X0+28]);\n\tX0 = *([X8]);\n\t// 5 IndirectJump X0, X0, X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7\n\t// 6 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x224;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\t// 16 ShiftStack -16\n\tstack[0] = X29;\n\tstack[8] = X30;\n\tX29 = &stack[0];\n\tX0 = X0 + 0x224;\n\tX0 = 0x8D82DC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX1 = 0;\n\tX2 = 0;\n\tX0 = TypeLoadException /* throw helper */(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n// 2 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe void DebugDraw(float size)
		{
			//IL_000b: Expected O, but got Ref
			object obj = (object)System.Runtime.CompilerServices.Unsafe.AsPointer(ref System.Runtime.CompilerServices.Unsafe.AddByteOffset(ref this, 16));
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @C2EA04 (inside Obi.ObiPathFrame::op_Multiply +0xAC0)");
		}
	}
}
