using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine
{
	[Token(Token = "0x2000065")]
	public struct BoneMatrix
	{
		[Token(Token = "0x4000296")]
		[FieldOffset(Offset = "0x0")]
		public float a;

		[Token(Token = "0x4000297")]
		[FieldOffset(Offset = "0x4")]
		public float b;

		[Token(Token = "0x4000298")]
		[FieldOffset(Offset = "0x8")]
		public float c;

		[Token(Token = "0x4000299")]
		[FieldOffset(Offset = "0xC")]
		public float d;

		[Token(Token = "0x400029A")]
		[FieldOffset(Offset = "0x10")]
		public float x;

		[Token(Token = "0x400029B")]
		[FieldOffset(Offset = "0x14")]
		public float y;

		[Token(Token = "0x600046F")]
		[Address(RVA = "0x154FD74", Offset = "0x154FD74", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv11 = boneData == 0;\n\tif (v11) goto L_001D;\n\tv15 = boneData.parent == 0;\n\tif (v15) goto L_0021;\n\tv17 = Spine.BoneMatrix::CalculateSetupWorld(boneData.parent);\n\tv86 = v17.a;\n\tgoto L_0027;\nL_001D:\n\treturnBuffer.a = 0f;\n\treturnBuffer.c = 0f;\n\treturnBuffer.x = 0f;\n\tgoto L_0036;\nL_0021:\n\tv19 = 0;\nL_0027:\n\treturnVal1 = Spine.BoneMatrix::GetInheritedInternal(boneData, v58);\n\treturnBuffer.x = *([v99 @ X8_v2+10]);\n\treturnBuffer.a = *([v99 @ X8_v2]);\nL_0036:\n\treturn returnVal1;\n// 39 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe static BoneMatrix CalculateSetupWorld(BoneData boneData)
		{
			//IL_007c: Expected native int or pointer, but got O
			//IL_008a: Expected native int or pointer, but got O
			//IL_0098: Expected native int or pointer, but got O
			//IL_00b3: Expected O, but got I4
			//IL_00bb: Expected O, but got Ref
			//IL_00ee: Expected F4, but got I
			//IL_00e9: Expected native int or pointer, but got O
			//IL_00fb: Expected F4, but got O
			//IL_00f6: Expected native int or pointer, but got O
			//IL_0066: Expected O, but got Ref
			BoneMatrix result;
			BoneMatrix boneMatrix = default(BoneMatrix);
			if (boneData != null)
			{
				BoneMatrix parentMatrix;
				object obj;
				object obj2 = default(object);
				if (boneData.Parent != null)
				{
					float num = CalculateSetupWorld(boneData.Parent).a;
					parentMatrix = (BoneMatrix)(&num);
					obj = obj2;
				}
				else
				{
					object obj3 = 0;
					parentMatrix = (BoneMatrix)(&obj3);
					obj = obj2;
				}
				result = GetInheritedInternal(boneData, parentMatrix);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v99 @ X8_v2+10]");
				((BoneMatrix*)(nint)boneMatrix)->x = 0f;
				((BoneMatrix*)(nint)boneMatrix)->a = (float)obj;
			}
			else
			{
				((BoneMatrix*)(nint)boneMatrix)->a = 0f;
				((BoneMatrix*)(nint)boneMatrix)->c = 0f;
				((BoneMatrix*)(nint)boneMatrix)->x = 0f;
				result = (BoneMatrix)boneData;
			}
			return result;
		}

		[Token(Token = "0x6000470")]
		[Address(RVA = "0x154FE00", Offset = "0x154FE00", Length = "0x62C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv38 = Spine.MathUtils;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, parentMatrix, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv60 = System.Math;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, parentMatrix, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv55 = 1;\n\t*([1A37BC5]) = v55;\nL_0022:\n\tv62 = boneData.parent == 0;\n\tif (v62) goto L_00D5;\n\tv70 = boneData.transformMode;\n\tv72 = parentMatrix.a * boneData.x;\n\tv73 = parentMatrix.b * boneData.y;\n\tv74 = v72 + v73;\n\tv77 = parentMatrix.c * boneData.x;\n\tv78 = parentMatrix.d * boneData.y;\n\tv79 = v77 + v78;\n\tv80 = boneData.transformMode < 7;\n\tv81 = ~v80;\n\tv82 = boneData.transformMode - 7;\n\tv84 = v82 == 0;\n\tv89 = parentMatrix.x + v74;\n\tv90 = v79 + parentMatrix.y;\n\tv91 = ~v84;\n\tv92 = v81 & v91;\n\tif (v92) goto L_01A0;\n\tv109 = 0x44C000 + 0xD44;\n\tv112 = *([v109 @ X9_v3 (System.Int32)+v70 @ X8_v3 (Spine.TransformMode)*2]) << 2;\n\tv113 = 0x1553EC8 + v112;\n\t// 75 IndirectJump v113 @ X10_v2 (System.Int32), boneData @ X0 (Spine.BoneData), boneData @ X0 (Spine.BoneData), parentMatrix @ X1 (Spine.BoneMatrix), methodInfo @ X2 (Il2CppMethodInfo), v41 @ X3, v42 @ X4, v43 @ X5, v44 @ X6, v45 @ X7, 0, v78 @ V1_v2 (System.Single), v74 @ V2_v2 (System.Single), parentMatrix.x (System.Single), parentMatrix.y (System.Single), parentMatrix.c (System.Single), v52 @ V6, v53 @ V7\n\tstack[5C] = V5;\n\tX21 = *([1946708]);\n\tV12 = *([X20+34]);\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0056;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0056:\n\tV0 = V12;\n\tX0 = 0;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV1 = *([X20+34]);\n\tV12 = V0;\n\tX0 = 0;\n\tV0 = V1;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tX22 = *([19355D8]);\n\tV1 = V8 * V12;\n\tV2 = V15 * V0;\n\tstack[C] = V8;\n\tX0 = *([X22]);\n\tV8 = V1 + V2;\n\tV1 = stack[5C];\n\tV0 = V10 * V0;\n\tX8 = *([X0+E0]);\n\tV1 = V1 * V12;\n\tV9 = V1 + V0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0070;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X22]);\n\tX8 = *([X0+E0]);\nL_0070:\n\tX9 = 0x407000;\n\tV3 = 1E-05f;\n\tV0 = V8 * V8;\n\tV1 = V9 * V9;\n\tV0 = V0 + V1;\n\tV2 = 1f;\n\tV0 = UnityEngine.Mathf::Sqrt(V0);\n\tV1 = V2 / V0;\n\tC = V0 < V3;\n\tC = ~C;\n\tTEMP1 = V0 - V3;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V3;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = N == V;\n\tTEMPCOND2 = ~Z;\n\tTEMPCOND = TEMPCOND & TEMPCOND2;\n\tTEMPCSEL = ~TEMPCOND;\n\tif (TEMPCSEL) goto L_0088;\n\tV0 = V1;\n\tgoto L_0089;\nL_0088:\n\tV0 = V0;\nL_0089:\n\t;\n\tV13 = V8 * V0;\n\tV12 = V9 * V0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0090;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0090:\n\tX0 = *([X21]);\n\tV0 = V13 * V13;\n\tV1 = V12 * V12;\n\tV0 = V0 + V1;\n\tX8 = *([X0+E0]);\n\tV8 = UnityEngine.Mathf::Sqrt(V0);\n\tstack[58] = V10;\n\tstack[0] = V15;\n\tstack[4] = V11;\n\tstack[8] = V14;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009E;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_009E:\n\tV0 = V12;\n\tV1 = V13;\n\tX0 = 0;\n\tV0 = Spine.MathUtils::Atan2(V0, V1, X0);\n\tV1 = 1.5707964f;\n\tX0 = 0;\n\tV14 = V0 + V1;\n\tV0 = V14;\n\tV0 = Spine.MathUtils::Cos(V0, X0);\n\tV15 = V8 * V0;\n\tV0 = V14;\n\tX0 = 0;\n\tV0 = Spine.MathUtils::Sin(V0, X0);\n\tV1 = *([X20+40]);\n\tV14 = V8 * V0;\n\tX0 = 0;\n\tV0 = V1;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV1 = *([X20+38]);\n\tV2 = *([X20+44]);\n\tV11 = X8;\n\tV8 = V0 * V1;\n\tV0 = V2 + V11;\n\tX0 = 0;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV2 = *([X20+3C]);\n\tV1 = *([X20+40]);\n\tX0 = 0;\n\tV9 = V0 * V2;\n\tV0 = V1;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV1 = *([X20+38]);\n\tV2 = *([X20+44]);\n\tX0 = 0;\n\tV10 = V0 * V1;\n\tV0 = V2 + V11;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tX8 = *([X20+48]);\n\tV1 = *([X20+3C]);\n\tC = X8 < 6;\n\tC = ~C;\n\tTEMP1 = X8 - 6;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 6;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tV0 = V0 * V1;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_017B;\n\tV11 = stack[4];\n\tgoto L_0190;\nL_00D5:\n\treturnBuffer.a = 0f;\n\treturnBuffer.c = 0f;\n\treturnBuffer.x = 0f;\n\tSpine.BoneMatrix::.ctor(returnBuffer, boneData);\n\treturn returnBuffer;\n\tstack[58] = V10;\n\tstack[5C] = V5;\n\tX8 = *([1946708]);\n\tV13 = V8;\n\tV9 = *([X20+34]);\n\tV10 = *([X20+40]);\n\tV8 = *([X20+44]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00F8;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00F8:\n\tV0 = V9 + V10;\n\tX0 = 0;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV1 = *([X20+38]);\n\tV2 = X8;\n\tV2 = V9 + V2;\n\tV12 = V2 + V8;\n\tV9 = V0 * V1;\n\tV0 = V12;\n\tX0 = 0;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV1 = *([X20+34]);\n\tV2 = *([X20+3C]);\n\tV3 = *([X20+40]);\n\tX0 = 0;\n\tV8 = V0 * V2;\n\tV0 = V1 + V3;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV1 = *([X20+38]);\n\tX0 = 0;\n\tV10 = V0 * V1;\n\tV0 = V12;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV1 = *([X20+3C]);\n\tV2 = V13 * V9;\n\tV4 = V13 * V8;\n\tV16 = stack[58];\n\tV13 = stack[5C];\n\tV0 = V0 * V1;\n\tV3 = V15 * V10;\n\tV1 = V15 * V0;\n\tV5 = V13 * V9;\n\tV6 = V16 * V10;\n\tV7 = V13 * V8;\n\tV0 = V16 * V0;\n\tV12 = V2 + V3;\n\tV13 = V5 + V6;\n\tV9 = V4 + V1;\n\tgoto L_01EC;\n\tV0 = 0.0001f;\n\tV1 = V8 * V8;\n\tV2 = V5 * V5;\n\tstack[C] = V8;\n\tV8 = V1 + V2;\n\tC = V8 < V0;\n\tC = ~C;\n\tTEMP1 = V8 - V0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ V0;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tstack[5C] = V5;\n\tTEMPCOND = N == V;\n\tTEMPCOND = ~TEMPCOND;\n\tTEMPCOND = TEMPCOND | Z;\n\tif (TEMPCOND) goto L_01A1;\n\tX8 = *([19355D8]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_013C;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_013C:\n\tX8 = 0x1946000;\n\tX8 = *([1946708]);\n\tV12 = stack[C];\n\tV9 = stack[5C];\n\tX0 = *([X8]);\n\tV0 = V12 * V10;\n\tV1 = V15 * V9;\n\t// 323 NotImplemented \"Instruction FABD not yet implemented.\"\n\tX8 = *([X0+E0]);\n\tV8 = V0 / V8;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014A;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014A:\n\tV0 = V12 * V8;\n\tstack[58] = V0;\n\tV0 = V9;\n\tV1 = V12;\n\tX0 = 0;\n\tV15 = V9 * V8;\n\tV0 = Spine.MathUtils::Atan2(V0, V1, X0);\n\tV1 = 57.295776f;\n\tV8 = V0 * V1;\n\tgoto L_01B8;\n\tX8 = *([1946708]);\n\tV9 = *([X20+34]);\n\tV10 = *([X20+40]);\n\tV0 = *([X20+44]);\n\tX0 = *([X8]);\n\tV1 = X8;\n\tV1 = V9 + V1;\n\tX9 = *([X0+E0]);\n\tV8 = V1 + V0;\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0164;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0164:\n\tV0 = V9 + V10;\n\tX0 = 0;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV1 = *([X20+38]);\n\tX0 = 0;\n\tV12 = V0 * V1;\n\tV0 = V8;\n\tV0 = Spine.MathUtils::CosDeg(V0, X0);\n\tV1 = *([X20+34]);\n\tV2 = *([X20+3C]);\n\tV3 = *([X20+40]);\n\tX0 = 0;\n\tV9 = V0 * V2;\n\tV0 = V1 + V3;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV1 = *([X20+38]);\n\tX0 = 0;\n\tV13 = V0 * V1;\n\tV0 = V8;\n\tV0 = Spine.MathUtils::SinDeg(V0, X0);\n\tV1 = *([X20+3C]);\n\tV0 = V0 * V1;\n\tgoto L_01ED;\nL_017B:\n\tV1 = stack[58];\n\tV3 = stack[5C];\n\tV2 = stack[C];\n\tV1 = V2 * V1;\n\tV2 = stack[0];\n\tV11 = stack[4];\n\tV2 = V2 * V3;\n\tV1 = V1 - V2;\n\tC = V1 < 0;\n\tC = ~C;\n\tTEMP1 = V1 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V1 ^ 0;\n\tTEMP3 = V1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_0190;\n\tV15 = -V15;\n\tV14 = -V14;\nL_0190:\n\tV4 = V0 * V15;\n\tV6 = V10 * V14;\n\tV0 = V0 * V14;\n\tV14 = stack[8];\n\tV1 = V13 * V8;\n\tV2 = V10 * V15;\n\tV3 = V13 * V9;\n\tV5 = V12 * V8;\n\tV7 = V12 * V9;\n\tV12 = V1 + V2;\n\tV9 = V3 + V4;\n\tV13 = V5 + V6;\n\tgoto L_01EC;\nL_01A0:\n\tgoto L_01ED;\nL_01A1:\n\tX8 = 0x1946000;\n\tX8 = *([1946708]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A9;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01A9:\n\tV0 = V10;\n\tV1 = V15;\n\tX0 = 0;\n\tstack[58] = V10;\n\tV0 = Spine.MathUtils::Atan2(V0, V1, X0);\n\tV1 = -57.295776f;\n\tV2 = 0;\n\tstack[5C] = V2;\n\tV2 = X8;\n\tV0 = V0 * V1;\n\tV8 = V0 + V2;\n\tV0 = 0;\n\tstack[C] = V0;\nL_01B8:\n\tX8 = 0x1946000;\n\tX8 = *([1946708]);\n\tV9 = *([X20+34]);\n\tV0 = *([X20+40]);\n\tV10 = *([X20+44]);\n\tX0 = *([X8]);\n\tV0 = V9 + V0;\n\tV12 = V0 - V8;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01C5;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01C5\n// ... truncated")]
		private unsafe static BoneMatrix GetInheritedInternal(BoneData boneData, BoneMatrix parentMatrix)
		{
			//IL_018b: Expected native int or pointer, but got O
			//IL_0199: Expected native int or pointer, but got O
			//IL_01a7: Expected native int or pointer, but got O
			//IL_01b4: Expected native int or pointer, but got O
			//IL_01cc: Expected native int or pointer, but got O
			//IL_01da: Expected native int or pointer, but got O
			//IL_01e8: Expected native int or pointer, but got O
			//IL_01f6: Expected native int or pointer, but got O
			//IL_0203: Expected native int or pointer, but got O
			//IL_0210: Expected native int or pointer, but got O
			BoneMatrix boneMatrix = default(BoneMatrix);
			if (boneData.Parent != null)
			{
				TransformMode transformMode = boneData.TransformMode;
				float num = parentMatrix.a * boneData.X;
				float num2 = parentMatrix.b * boneData.Y;
				float num3 = num + num2;
				float num4 = parentMatrix.c * boneData.X;
				float num5 = parentMatrix.d * boneData.Y;
				float num6 = num4 + num5;
				bool flag = boneData.TransformMode < TransformMode.OnlyTranslation;
				bool flag2 = !flag;
				int num7 = (int)(boneData.TransformMode - 7);
				bool flag3 = num7 == 0;
				float num8 = parentMatrix.x + num3;
				float num9 = num6 + parentMatrix.y;
				bool flag4 = !flag3;
				if (flag2 && flag4)
				{
					((BoneMatrix*)(nint)boneMatrix)->a = 0f;
					((BoneMatrix*)(nint)boneMatrix)->b = 0f;
					((BoneMatrix*)(nint)boneMatrix)->c = 0f;
					((BoneMatrix*)(nint)boneMatrix)->d = 0f;
					((BoneMatrix*)(nint)boneMatrix)->x = num8;
					((BoneMatrix*)(nint)boneMatrix)->y = num9;
					return (BoneMatrix)boneData;
				}
				int num10 = 4505600 + 3396;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X9_v3 (System.Int32)+v70 @ X8_v3 (Spine.TransformMode)*2]");
				int num11 = (int)((nint)0 << 2);
				int num12 = 22363848 + num11;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v113 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			((BoneMatrix*)(nint)boneMatrix)->a = 0f;
			((BoneMatrix*)(nint)boneMatrix)->c = 0f;
			((BoneMatrix*)(nint)boneMatrix)->x = 0f;
			*(BoneMatrix*)(nint)boneMatrix = new BoneMatrix(boneData);
			return boneMatrix;
		}

		[Token(Token = "0x6000471")]
		[Address(RVA = "0x155042C", Offset = "0x155042C", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Spine.MathUtils;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, boneData, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37BC6]) = v40;\nL_001E:\n\tv50 = boneData.rotation + 0x42B40000;\n\tv52 = v50 + boneData.shearY;\n\tv53 = boneData.rotation + boneData.shearX;\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v47, boneData, methodInfo, v25, v26, v27, v28, v29, v44, v46, v45, v50, v34, v35, v36, v37);\nL_0028:\n\tv61 = Spine.MathUtils::CosDeg(v53);\n\tv64 = v61 * boneData.scaleX;\n\tthis.a = v64;\n\tv66 = Spine.MathUtils::SinDeg(v53);\n\tv93 = v66 * boneData.scaleX;\n\tthis.c = v93;\n\tv95 = Spine.MathUtils::CosDeg(v52);\n\tv97 = v95 * boneData.scaleY;\n\tthis.b = v97;\n\tv99 = Spine.MathUtils::SinDeg(v52);\n\tv100 = v99 * boneData.scaleY;\n\tthis.d = v100;\n\tthis.x = boneData.x;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoneMatrix(BoneData boneData)
		{
			float num = boneData.Rotation + 90f;
			float degrees = num + boneData.ShearY;
			float degrees2 = boneData.Rotation + boneData.ShearX;
			float num2 = MathUtils.CosDeg(degrees2);
			float num3 = num2 * boneData.ScaleX;
			a = num3;
			float num4 = MathUtils.SinDeg(degrees2);
			float num5 = num4 * boneData.ScaleX;
			c = num5;
			float num6 = MathUtils.CosDeg(degrees);
			float num7 = num6 * boneData.ScaleY;
			b = num7;
			float num8 = MathUtils.SinDeg(degrees);
			float num9 = num8 * boneData.ScaleY;
			d = num9;
			x = boneData.X;
		}

		[Token(Token = "0x6000472")]
		[Address(RVA = "0x1550514", Offset = "0x1550514", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = Spine.MathUtils;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, bone, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A37BC7]) = v40;\nL_001E:\n\tv50 = bone.rotation + 0x42B40000;\n\tv52 = v50 + bone.shearY;\n\tv53 = bone.rotation + bone.shearX;\n\tgoto L_0028;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v47, bone, methodInfo, v25, v26, v27, v28, v29, v44, v46, v45, v50, v34, v35, v36, v37);\nL_0028:\n\tv61 = Spine.MathUtils::CosDeg(v53);\n\tv64 = v61 * bone.scaleX;\n\tthis.a = v64;\n\tv66 = Spine.MathUtils::SinDeg(v53);\n\tv93 = v66 * bone.scaleX;\n\tthis.c = v93;\n\tv95 = Spine.MathUtils::CosDeg(v52);\n\tv97 = v95 * bone.scaleY;\n\tthis.b = v97;\n\tv99 = Spine.MathUtils::SinDeg(v52);\n\tv100 = v99 * bone.scaleY;\n\tthis.d = v100;\n\tthis.x = bone.x;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public BoneMatrix(Bone bone)
		{
			float num = bone.Rotation + 90f;
			float degrees = num + bone.ShearY;
			float degrees2 = bone.Rotation + bone.ShearX;
			float num2 = MathUtils.CosDeg(degrees2);
			float num3 = num2 * bone.ScaleX;
			a = num3;
			float num4 = MathUtils.SinDeg(degrees2);
			float num5 = num4 * bone.ScaleX;
			c = num5;
			float num6 = MathUtils.CosDeg(degrees);
			float num7 = num6 * bone.ScaleY;
			b = num7;
			float num8 = MathUtils.SinDeg(degrees);
			float num9 = num8 * bone.ScaleY;
			d = num9;
			x = bone.X;
		}

		[Token(Token = "0x6000473")]
		[Address(RVA = "0x15505FC", Offset = "0x15505FC", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = local.a * v11;\n\tv12 = local.a * v13;\n\tv14 = this.a * local.x;\n\tv15 = this.c * local.x;\n\tv16 = local.c * v17;\n\tv18 = local.c * v19;\n\tv20 = this.b * local.y;\n\tv21 = this.d * local.y;\n\tv22 = v10 + v16;\n\tv25 = v14 + v20;\n\tv26 = v15 + v21;\n\tv27 = v12 + v18;\n\tv28 = this.x + v25;\n\tv29 = v26 + this.y;\n\treturnBuffer.a = v22;\n\treturnBuffer.c = v27;\n\treturnBuffer.x = v28;\n\treturnBuffer.y = v29;\n\treturn this;\n// 10 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe BoneMatrix TransformMatrix(BoneMatrix local)
		{
			//IL_010e: Expected native int or pointer, but got O
			//IL_011b: Expected native int or pointer, but got O
			//IL_0128: Expected native int or pointer, but got O
			//IL_0135: Expected native int or pointer, but got O
			//IL_013c: Expected O, but got Ref
			object obj = default(object);
			float num = local.a * (float)obj;
			object obj2 = default(object);
			float num2 = local.a * (float)obj2;
			float num3 = a * local.x;
			float num4 = c * local.x;
			object obj3 = default(object);
			float num5 = local.c * (float)obj3;
			object obj4 = default(object);
			float num6 = local.c * (float)obj4;
			float num7 = b * local.y;
			float num8 = d * local.y;
			float num9 = num + num5;
			float num10 = num3 + num7;
			float num11 = num4 + num8;
			float num12 = num2 + num6;
			float num13 = x + num10;
			float num14 = num11 + y;
			BoneMatrix boneMatrix = default(BoneMatrix);
			((BoneMatrix*)(nint)boneMatrix)->a = num9;
			((BoneMatrix*)(nint)boneMatrix)->c = num12;
			((BoneMatrix*)(nint)boneMatrix)->x = num13;
			((BoneMatrix*)(nint)boneMatrix)->y = num14;
			return (BoneMatrix)System.Runtime.CompilerServices.Unsafe.AsPointer(ref this);
		}
	}
}
