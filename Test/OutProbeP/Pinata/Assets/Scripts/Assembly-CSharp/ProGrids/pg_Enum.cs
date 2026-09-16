using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace ProGrids
{
	[Token(Token = "0x200004B")]
	public static class pg_Enum
	{
		[Token(Token = "0x6000222")]
		[Address(RVA = "0xAFFD30", Offset = "0xAFFD30", Length = "0x148")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = v.y;\n\tv2 = v.z;\n\tgoto L_0026;\n\tv30 = *([1EB1AD8]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v, v0, v2, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20224A8]) = v47;\nL_0026:\n\tv59 = v45 > 8;\n\tif (v59) goto L_0045;\n\tv60 = v45 - 1;\n\tv61 = v60 < 7;\n\tv62 = ~v61;\n\tv63 = v60 - 7;\n\tv65 = v63 == 0;\n\tv70 = ~v65;\n\tv71 = v62 & v70;\n\tif (v71) goto L_008B;\n\tv82 = 0x1819000 + 0x170;\n\tv84 = *([v82 @ X9_v2 (System.Int32)+v60 @ X8_v9 (System.Int32)*4]) + v82;\n\t// 57 IndirectJump v84 @ X8_v11, v45 @ X0_v1 (ProGrids.Axis), v45 @ X0_v1 (ProGrids.Axis), methodInfo @ X1 (Il2CppMethodInfo), v34 @ X2, v35 @ X3, v36 @ X4, v37 @ X5, v38 @ X6, v39 @ X7, v @ V0 (UnityEngine.Vector3), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tV1 = 1f;\n\tstack[8] = 0;\n\tstack[0] = 0;\n\tX0 = &stack[0];\n\tV0 = 0;\n\tV2 = V1;\n\tgoto L_0064;\nL_0045:\n\tv76 = v45 == 0x16;\n\tif (v76) goto L_0062;\n\tv109 = v45 != 0x32;\n\tif (v109) goto L_008B;\n\tgoto L_0064;\nL_0062:\n\tv163 = 0;\nL_0064:\n\tv210 = 0x1586898(v207, 0, v34, v35, v36, v37, v38, v39, v206, v209, v208, v40, v41, v42, v43, v44);\n\tgoto L_0079;\n\tv217 = *([v213 @ X0_v5+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tgoto L_0079;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v213, v86, v34, v35, v36, v37, v38, v39, v206, v209, v208, v40, v41, v42, v43, v44);\nL_0079:\n\t// 121 MakeStruct v88 @ AGGAFFE44_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v163 @ stack_-50_v3, v222 @ stack_-4C, v103 @ stack_-48_v2 (System.Int32)\n\tv106 = UnityEngine.Vector3::Scale(v, v88);\nL_008B:\n\treturn v138;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 InverseAxisMask(Vector3 v, Axis axis)
		{
			//IL_013f: Expected O, but got I4
			//IL_0148: Expected O, but got I4
			//IL_0186: Expected F4, but got O
			//IL_0193: Expected F4, but got O
			//IL_00b6: Expected O, but got I
			float y = v.y;
			float z = v.z;
			Axis axis2 = default(Axis);
			Vector3 result;
			if (axis2 <= Axis.NegX)
			{
				int num = (int)(axis2 - 1);
				bool flag = num < 7;
				bool flag2 = !flag;
				int num2 = num - 7;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				bool flag5 = flag2 && flag4;
				result = v;
				if (flag5)
				{
					goto IL_01dc;
				}
				int num3 = 25268224 + 368;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X9_v2 (System.Int32)+v60 @ X8_v9 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v84 @ X8_v11 (should have been resolved before IL gen)");
			}
			int num4;
			object obj3 = default(object);
			if (axis2 != Axis.NegY)
			{
				bool flag6 = axis2 != Axis.NegZ;
				result = v;
				if (flag6)
				{
					goto IL_01dc;
				}
				num4 = 0;
				float num5 = 1f;
				object obj2 = obj3;
				float num6 = 0f;
				float num7 = 1f;
			}
			else
			{
				obj3 = 0;
				obj3 = 0;
				num4 = 0;
				float num5 = 1f;
				object obj2 = obj3;
				float num6 = 1f;
				float num7 = 0f;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 b = default(Vector3);
			b.x = (float)obj3;
			object obj4 = default(object);
			b.y = (float)obj4;
			b.z = num4;
			Vector3 vector = Vector3.Scale(v, b);
			result = vector;
			goto IL_01dc;
			IL_01dc:
			return result;
		}

		[Token(Token = "0x6000223")]
		[Address(RVA = "0xAFFE78", Offset = "0xAFFE78", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = v.y;\n\tv2 = v.z;\n\tgoto L_0026;\n\tv30 = *([1EE83D8]);\n\tv31 = *([v30 @ X8_v14]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v, v0, v2, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20224A9]) = v47;\nL_0026:\n\tv59 = v45 > 8;\n\tif (v59) goto L_0044;\n\tv60 = v45 - 1;\n\tv61 = v60 < 7;\n\tv62 = ~v61;\n\tv63 = v60 - 7;\n\tv65 = v63 == 0;\n\tv70 = ~v65;\n\tv71 = v62 & v70;\n\tif (v71) goto L_008A;\n\tv82 = 0x1819000 + 0x190;\n\tv84 = *([v82 @ X9_v2 (System.Int32)+v60 @ X8_v9 (System.Int32)*4]) + v82;\n\t// 57 IndirectJump v84 @ X8_v11, v45 @ X0_v1 (ProGrids.Axis), v45 @ X0_v1 (ProGrids.Axis), methodInfo @ X1 (Il2CppMethodInfo), v34 @ X2, v35 @ X3, v36 @ X4, v37 @ X5, v38 @ X6, v39 @ X7, v @ V0 (UnityEngine.Vector3), v0 @ V1_v1 (System.Single), v2 @ V2_v1 (System.Single), v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\tstack[8] = 0;\n\tstack[0] = 0;\n\tV0 = 1f;\n\tX0 = &stack[0];\n\tV1 = 0;\n\tgoto L_FFFFFFFF;\nL_0044:\n\tv76 = v45 == 0x16;\n\tif (v76) goto L_0060;\n\tv109 = v45 != 0x32;\n\tif (v109) goto L_008A;\n\tgoto L_0063;\nL_0060:\n\tv163 = 0;\nL_0063:\n\tv210 = 0x1586898(v207, 0, v34, v35, v36, v37, v38, v39, v206, v209, v208, v40, v41, v42, v43, v44);\n\tgoto L_0078;\n\tv217 = *([v213 @ X0_v5+E0]);\n\tv218 = v217 == 0;\n\tv219 = ~v218;\n\tgoto L_0078;\n\tv221 = \"il2cpp_codegen_runtime_class_init\"(v213, v86, v34, v35, v36, v37, v38, v39, v206, v209, v208, v40, v41, v42, v43, v44);\nL_0078:\n\t// 120 MakeStruct v88 @ AGGAFFF88_1_v2 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v163 @ stack_-50_v3, v222 @ stack_-4C, v105 @ stack_-48_v2 (System.Int32)\n\tv100 = UnityEngine.Vector3::Scale(v, v88);\nL_008A:\n\treturn v138;\n// 96 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector3 AxisMask(Vector3 v, Axis axis)
		{
			//IL_013f: Expected O, but got I4
			//IL_01be: Expected O, but got I4
			//IL_00b6: Expected O, but got I
			//IL_0151: Expected F4, but got O
			//IL_015e: Expected F4, but got O
			float y = v.y;
			float z = v.z;
			Axis axis2 = default(Axis);
			Vector3 result;
			if (axis2 <= Axis.NegX)
			{
				int num = (int)(axis2 - 1);
				bool flag = num < 7;
				bool flag2 = !flag;
				int num2 = num - 7;
				bool flag3 = num2 == 0;
				bool flag4 = !flag3;
				bool flag5 = flag2 && flag4;
				result = v;
				if (flag5)
				{
					goto IL_01a7;
				}
				int num3 = 25268224 + 400;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v82 @ X9_v2 (System.Int32)+v60 @ X8_v9 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v84 @ X8_v11 (should have been resolved before IL gen)");
			}
			int num5;
			object obj3 = default(object);
			if (axis2 != Axis.NegY)
			{
				bool flag6 = axis2 != Axis.NegZ;
				result = v;
				if (flag6)
				{
					goto IL_01a7;
				}
				int num4 = 0;
				num5 = 0;
				object obj2 = obj3;
				float num6 = 1f;
				float num7 = 0f;
			}
			else
			{
				obj3 = 0;
				int num4 = 0;
				obj3 = 0;
				num5 = 0;
				object obj2 = obj3;
				float num6 = 0f;
				float num7 = 1f;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @1586898 (inside UnityEngine.Transform::Rotate +0x4)");
			Vector3 b = default(Vector3);
			b.x = (float)obj3;
			object obj4 = default(object);
			b.y = (float)obj4;
			b.z = num5;
			Vector3 vector = Vector3.Scale(v, b);
			result = vector;
			goto IL_01a7;
			IL_01a7:
			return result;
		}

		[Token(Token = "0x6000224")]
		[Address(RVA = "0xAFFFBC", Offset = "0xAFFFBC", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = su - 1;\n\tv2 = v0 < 5;\n\tv3 = ~v2;\n\tv4 = v0 - 5;\n\tv6 = v4 == 0;\n\tv11 = ~v6;\n\tv12 = v3 & v11;\n\tif (v12) goto L_0012;\n\tv14 = 0x1819000 + 0x390;\n\treturn *([v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]);\nL_0012:\n\treturn 1f;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float SnapUnitValue(SnapUnit su)
		{
			//IL_0087: Expected F4, but got I
			int num = (int)(su - 1);
			bool flag = num < 5;
			bool flag2 = !flag;
			int num2 = num - 5;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25268224 + 912;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v14 @ X9_v2 (System.Int32)+v0 @ X8_v1 (System.Int32)*4]");
				return 0f;
			}
			return 1f;
		}
	}
}
