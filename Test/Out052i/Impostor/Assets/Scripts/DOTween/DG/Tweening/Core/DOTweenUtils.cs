using System;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core
{
	[Token(Token = "0x20000B8")]
	public static class DOTweenUtils
	{
		[Token(Token = "0x400024C")]
		private static Assembly[] _loadedAssemblies;

		[Token(Token = "0x400024D")]
		private static readonly string[] _defAssembliesToQuery = new string[3] { "DOTween.Modules", "Assembly-CSharp", "Assembly-CSharp-firstpass" };

		[Token(Token = "0x6000459")]
		[Address(RVA = "0xC32754", Offset = "0xC32754", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv12 = degrees * 0.017453292f;\n\tv14 = 0x1854F30(&v9 @ stack_-14_v1, &v11 @ stack_-18_v1, v15, v16, v17, v18, v19, v20, v12, 0.017453292f, v21, v22, v23, v24, v25, v26);\n\treturnVal1 = v11 * magnitude;\n\treturn returnVal1;\n// 15 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Vector3 Vector3FromAngle(float degrees, float magnitude)
		{
			//IL_0022: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Expected F4, but got Unknown
			float num = degrees * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F30 (native sincosf)");
			object obj = default(object);
			float x = obj * magnitude;
			Vector3 result = default(Vector3);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600045A")]
		[Address(RVA = "0xC3279C", Offset = "0xC3279C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv31 = UnityEngine.Vector2;\n\tv32 = \"il2cpp_codegen_initialize_runtime_metadata\"(v31, v33, v34, v35, v36, v37, v38, v39, from, v0, v2, to, v3, v5, v40, v41);\n\tv45 = 1;\n\t*([1A35823]) = v45;\nL_001F:\n\tv50 = to - from;\n\tv51 = UnityEngine.Vector2;\n\tv52 = to.y - from.y;\n\tv53 = *([v51 @ X8_v5 (Il2CppClass<UnityEngine.Vector2>)+B8]);\n\tgoto L_002F;\n\tv59 = System.Math;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, v33, v34, v35, v36, v37, v38, v39, from, v0, v2, to, v3, v5, v40, v41);\n\tv63 = 1;\n\t*([1A35824]) = v63;\nL_002F:\n\tv66 = v53.rightVector * v53.rightVector;\n\tv67 = *([v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]) * *([v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]);\n\tv68 = v66 + v67;\n\tv70 = v50 * v50;\n\tv71 = v52 * v52;\n\tv72 = v70 + v71;\n\tgoto L_003D;\n\tv76 = \"il2cpp_codegen_runtime_class_init\"(v69, v33, v34, v35, v36, v37, v38, v39, v70, v71, v2, to, v3, v5, v40, v41);\nL_003D:\n\tv80 = v72 * v68;\n\tv81 = UnityEngine.Mathf::Sqrt(v80);\n\tv85 = v81 < 1E-15f;\n\tif (v85) goto L_006D;\n\tv93 = v50 * v53.rightVector;\n\tv94 = v52 * *([v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]);\n\tv95 = v93 + v94;\n\tv97 = v95 / v81;\n\tv100 = UnityEngine.Mathf::Min(v97, 1f);\n\tv120 = v97 - -1f;\n\tv118 = v120 < 0;\n\tv105 = ~v118;\n\tv102 = ~v105;\n\tif (v102) goto L_FFFFFFFF;\n\tgoto L_0065;\nL_0065:\n\tgoto L_0068;\n\tv171 = \"il2cpp_codegen_runtime_class_init\"(v92, v33, v34, v35, v36, v37, v38, v39, v97, v100, v99, to, v3, v5, v40, v41);\nL_0068:\n\tv126 = 0x1854F40(System.Math, v33, v34, v35, v36, v37, v38, v39, v130, v100, -1f, to, to.y, to.z, v40, v41);\n\tv134 = v130 * 57.29578f;\nL_006D:\n\tv136 = v52 * v53.rightVector;\n\tv137 = v50 * *([v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]);\n\tv139 = v136 - v137;\n\tv147 = 0x43B40000 - v134;\n\tv151 = v139 < 0;\n\tv152 = v139 == 0;\n\tv154 = v139 ^ v139;\n\tv155 = v139 & v154;\n\tv156 = v155 < 0;\n\tv157 = v151 == v156;\n\tv158 = ~v152;\n\tv159 = v157 & v158;\n\tv160 = ~v159;\n\tif (v160) goto L_FFFFFFFF;\n\tgoto L_008B;\nL_008B:\n\treturnVal1 = -v166;\n\treturn returnVal1;\n// 86 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static float Angle2D(Vector3 from, Vector3 to)
		{
			//IL_0165: Expected I, but got O
			//IL_0187: Expected I, but got O
			//IL_02ad: Expected O, but got I
			//IL_0206: Expected O, but got F4
			//IL_020f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0214: Expected I4, but got Unknown
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float num = vector.x - vector2.x;
			nint num2 = (nint)typeof(Vector2);
			float num3 = to.y - from.y;
			nint num4 = (nint)Vector2.zero;
			float num5 = Vector2.right.x * Vector2.right.x;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
			nint num6 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
			object obj = num6 * 0;
			float num7 = num5 + (float)obj;
			float num8 = num * num;
			float num9 = num3 * num3;
			float num10 = num8 + num9;
			float f = num10 * num7;
			float num11 = Mathf.Sqrt(f);
			bool flag = num11 < 1E-15f;
			float num12 = 0f;
			if (!flag)
			{
				float num13 = num * Vector2.right.x;
				float num14 = num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
				float num15 = num14 * 0f;
				float num16 = num13 + num15;
				float num17 = num16 / num11;
				float num18 = Mathf.Min(num17, 1f);
				float num19 = num17 - -1f;
				float num20 = ((num19 < 0f) ? (-1f) : num18);
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F40 (native acos)");
				num12 = num20 * 57.29578f;
			}
			float num21 = num3 * Vector2.right.x;
			float num22 = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X8_v6 (Il2CppStaticFields<UnityEngine.Vector2>)+2C]");
			float num23 = num22 * 0f;
			float num24 = num21 - num23;
			float num25 = 360f - num12;
			bool flag2 = num24 < 0f;
			bool flag3 = num24 == 0f;
			object obj2 = num24 ^ num24;
			int num26 = num24 & (nint)obj2;
			bool flag4 = num26 < 0;
			bool flag5 = flag2 == flag4;
			bool flag6 = !flag3;
			float num27 = ((!(flag5 && flag6)) ? num12 : num25);
			return 0f - num27;
		}

		[Token(Token = "0x600045B")]
		[Address(RVA = "0xC328E8", Offset = "0xC328E8", Length = "0x5C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = point - pivot;\n\tv26 = point.y - pivot.y;\n\tv27 = point.z - pivot.z;\n\t// 23 MakeStruct v32 @ AGGC36924_0_v1 (UnityEngine.Quaternion), typeof(UnityEngine.Quaternion), rotation @ stack_0 (UnityEngine.Quaternion), v18 @ stack_4, v20 @ stack_8, v22 @ stack_C\n\t// 24 MakeStruct v33 @ AGGC36924_1_v1 (UnityEngine.Vector3), typeof(UnityEngine.Vector3), v25 @ V4_v2 (System.Single), v26 @ V5_v2 (System.Single), v27 @ V6_v1 (System.Single)\n\tv34 = UnityEngine.Quaternion::op_Multiply(v32, v33);\n\treturnVal1 = pivot + v34;\n\treturn returnVal1;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Vector3 RotateAroundPivot(Vector3 point, Vector3 pivot, Quaternion rotation)
		{
			//IL_006a: Expected F4, but got O
			//IL_0077: Expected F4, but got O
			//IL_0084: Expected F4, but got O
			Vector3 vector = default(Vector3);
			Vector3 vector2 = default(Vector3);
			float x = vector.x - vector2.x;
			float y = point.y - pivot.y;
			float z = point.z - pivot.z;
			Quaternion quaternion = default(Quaternion);
			Quaternion quaternion2 = default(Quaternion);
			quaternion.x = quaternion2.x;
			object obj = default(object);
			quaternion.y = (float)obj;
			object obj2 = default(object);
			quaternion.z = (float)obj2;
			object obj3 = default(object);
			quaternion.w = (float)obj3;
			Vector3 vector3 = default(Vector3);
			vector3.x = x;
			vector3.y = y;
			vector3.z = z;
			Vector3 vector4 = quaternion * vector3;
			return pivot + vector4;
		}

		[Token(Token = "0x600045C")]
		[Address(RVA = "0xC32944", Offset = "0xC32944", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv16 = 0x42B40000 - degrees;\n\tv18 = v16 * 0.017453292f;\n\tv25 = 0x1854F30(&v20 @ stack_-24_v1, &v22 @ stack_-28_v1, v26, v27, v28, v29, v30, v31, v18, v16, radius, degrees, v32, v33, v34, v35);\n\tv39 = v22 * radius;\n\treturnVal1 = center + v39;\n\treturn returnVal1;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Vector2 GetPointOnCircle(Vector2 center, float radius, float degrees)
		{
			float num = 90f - degrees;
			float num2 = num * ((float)Math.PI / 180f);
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F30 (native sincosf)");
			object obj = default(object);
			float num3 = (float)obj * radius;
			Vector2 vector = default(Vector2);
			float x = vector.x + num3;
			Vector2 result = default(Vector2);
			result.x = x;
			return result;
		}

		[Token(Token = "0x600045D")]
		[Address(RVA = "0xC329AC", Offset = "0xC329AC", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv33 = UnityEngine.Mathf;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v33, v35, v36, v37, v38, v39, v40, v41, a, v0, v2, b, v3, v5, v42, v43);\n\tv47 = 1;\n\t*([1A357E1]) = v47;\nL_0021:\n\tv70 = UnityEngine.Mathf::Abs(a);\n\tv54 = UnityEngine.Mathf::Abs(b);\n\tv57 = v70 - v54;\n\tv58 = v57 < 0;\n\tv59 = v57 == 0;\n\tv60 = v70 ^ v54;\n\tv61 = v70 ^ v57;\n\tv62 = v60 & v61;\n\tv63 = v62 < 0;\n\tv64 = v58 == v63;\n\tv65 = ~v59;\n\tv66 = v64 & v65;\n\tv67 = ~v66;\n\tif (v67) goto L_FFFFFFFF;\n\tgoto L_0038;\nL_0038:\n\tv73 = v70 * 1E-06f;\n\tv75 = v71.Epsilon * 8f;\n\tv78 = v73 - v75;\n\tv79 = v78 < 0;\n\tv80 = v78 == 0;\n\tv81 = v73 ^ v75;\n\tv82 = v73 ^ v78;\n\tv83 = v81 & v82;\n\tv84 = v83 < 0;\n\tv85 = v79 == v84;\n\tv86 = ~v80;\n\tv87 = v85 & v86;\n\tv88 = ~v87;\n\tif (v88) goto L_FFFFFFFF;\n\tgoto L_004D;\nL_004D:\n\t// 77 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv101 = v71.Epsilon >= v91;\n\tif (v101) goto L_FFFFFFFF;\n\tv183 = UnityEngine.Mathf::Abs(a.y);\n\tv104 = UnityEngine.Mathf::Abs(b.y);\n\tv170 = v183 - v104;\n\tv171 = v170 < 0;\n\tv172 = v170 == 0;\n\tv173 = v183 ^ v104;\n\tv174 = v183 ^ v170;\n\tv175 = v173 & v174;\n\tv176 = v175 < 0;\n\tv177 = v171 == v176;\n\tv178 = ~v172;\n\tv179 = v177 & v178;\n\tv180 = ~v179;\n\tif (v180) goto L_FFFFFFFF;\n\tgoto L_006D;\nL_006D:\n\tv128 = v183 * 1E-06f;\n\tv187 = v128 - v75;\n\tv188 = v187 < 0;\n\tv189 = v187 == 0;\n\tv190 = v128 ^ v75;\n\tv191 = v128 ^ v187;\n\tv192 = v190 & v191;\n\tv193 = v192 < 0;\n\tv194 = v188 == v193;\n\tv108 = ~v189;\n\tv195 = v194 & v108;\n\tv106 = ~v195;\n\tif (v106) goto L_FFFFFFFF;\n\tgoto L_0080;\nL_0080:\n\t// 128 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv110 = v104 >= v128;\n\tif (v110) goto L_FFFFFFFF;\n\tv159 = UnityEngine.Mathf::Abs(a.z);\n\tv133 = UnityEngine.Mathf::Abs(b.z);\n\tv202 = v159 - v133;\n\tv203 = v202 < 0;\n\tv204 = v202 == 0;\n\tv205 = v159 ^ v133;\n\tv206 = v159 ^ v202;\n\tv207 = v205 & v206;\n\tv208 = v207 < 0;\n\tv209 = v203 == v208;\n\tv210 = ~v204;\n\tv211 = v209 & v210;\n\tv212 = ~v211;\n\tif (v212) goto L_FFFFFFFF;\n\tgoto L_00A0;\nL_00A0:\n\tv131 = v159 * 1E-06f;\n\tv218 = v131 - v75;\n\tv219 = v218 < 0;\n\tv220 = v218 == 0;\n\tv221 = v131 ^ v75;\n\tv222 = v131 ^ v218;\n\tv223 = v221 & v222;\n\tv224 = v223 < 0;\n\tv225 = v219 == v224;\n\tv137 = ~v220;\n\tv139 = v225 & v137;\n\tv135 = ~v139;\n\tif (v135) goto L_FFFFFFFF;\n\tgoto L_00B3;\nL_00B3:\n\t// 179 NotImplemented \"Instruction FABD not yet implemented.\"\n\tv153 = v75 - v131;\n\tv151 = v153 < 0;\n\tgoto L_00C9;\nL_00C9:\n\treturn returnVal1;\n// 98 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool Vector3AreApproximatelyEqual(Vector3 a, Vector3 b)
		{
			//IL_028b: Expected O, but got F4
			//IL_0298: Expected O, but got F4
			//IL_0354: Expected O, but got F4
			//IL_0361: Expected O, but got F4
			//IL_0098: Expected O, but got F4
			//IL_00a5: Expected O, but got F4
			//IL_0438: Expected O, but got F4
			//IL_0445: Expected O, but got F4
			//IL_018d: Expected O, but got F4
			//IL_019a: Expected O, but got F4
			//IL_051b: Expected O, but got F4
			//IL_0528: Expected O, but got F4
			Vector3 vector = default(Vector3);
			float num = Mathf.Abs(vector.x);
			Vector3 vector2 = default(Vector3);
			float num2 = Mathf.Abs(vector2.x);
			float num3 = num - num2;
			bool flag = num3 < 0f;
			bool flag2 = num3 == 0f;
			object obj = num ^ num2;
			object obj2 = num ^ num3;
			int num4 = (int)((nint)obj & (nint)obj2);
			bool flag3 = num4 < 0;
			bool flag4 = flag == flag3;
			bool flag5 = !flag2;
			if (!(flag4 && flag5))
			{
				num = num2;
			}
			float num5 = num * 1E-06f;
			float num6 = Mathf.Epsilon * 8f;
			float num7 = num5 - num6;
			bool flag6 = num7 < 0f;
			bool flag7 = num7 == 0f;
			object obj3 = num5 ^ num6;
			object obj4 = num5 ^ num7;
			int num8 = (int)((nint)obj3 & (nint)obj4);
			bool flag8 = num8 < 0;
			bool flag9 = flag6 == flag8;
			bool flag10 = !flag7;
			float num9 = ((!(flag9 && flag10)) ? num6 : num5);
			Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
			if (Mathf.Epsilon < num9)
			{
				float num10 = Mathf.Abs(a.y);
				float num11 = Mathf.Abs(b.y);
				float num12 = num10 - num11;
				bool flag11 = num12 < 0f;
				bool flag12 = num12 == 0f;
				object obj5 = num10 ^ num11;
				object obj6 = num10 ^ num12;
				int num13 = (int)((nint)obj5 & (nint)obj6);
				bool flag13 = num13 < 0;
				bool flag14 = flag11 == flag13;
				bool flag15 = !flag12;
				if (!(flag14 && flag15))
				{
					num10 = num11;
				}
				float num14 = num10 * 1E-06f;
				float num15 = num14 - num6;
				bool flag16 = num15 < 0f;
				bool flag17 = num15 == 0f;
				object obj7 = num14 ^ num6;
				object obj8 = num14 ^ num15;
				int num16 = (int)((nint)obj7 & (nint)obj8);
				bool flag18 = num16 < 0;
				bool flag19 = flag16 == flag18;
				bool flag20 = !flag17;
				if (!(flag19 && flag20))
				{
					num14 = num6;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
				if (num11 < num14)
				{
					float num17 = Mathf.Abs(a.z);
					float num18 = Mathf.Abs(b.z);
					float num19 = num17 - num18;
					bool flag21 = num19 < 0f;
					bool flag22 = num19 == 0f;
					object obj9 = num17 ^ num18;
					object obj10 = num17 ^ num19;
					int num20 = (int)((nint)obj9 & (nint)obj10);
					bool flag23 = num20 < 0;
					bool flag24 = flag21 == flag23;
					bool flag25 = !flag22;
					if (!(flag24 && flag25))
					{
						num17 = num18;
					}
					float num21 = num17 * 1E-06f;
					float num22 = num21 - num6;
					bool flag26 = num22 < 0f;
					bool flag27 = num22 == 0f;
					object obj11 = num21 ^ num6;
					object obj12 = num21 ^ num22;
					int num23 = (int)((nint)obj11 & (nint)obj12);
					bool flag28 = num23 < 0;
					bool flag29 = flag26 == flag28;
					bool flag30 = !flag27;
					if (!(flag29 && flag30))
					{
						num21 = num6;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Not implemented instruction: \"Instruction FABD not yet implemented.\"");
					float num24 = num6 - num21;
					return num24 < 0f;
				}
			}
			return false;
		}

		[Token(Token = "0x600045E")]
		[Address(RVA = "0xC32AAC", Offset = "0xC32AAC", Length = "0x258")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_FFFFFFFF;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv59 = DG.Tweening.Core.DOTweenUtils;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv118 = Il2CppMethodInfo;\n\tv119 = \"il2cpp_codegen_initialize_runtime_metadata\"(v118, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv127 = System.Type;\n\tv128 = \"il2cpp_codegen_initialize_runtime_metadata\"(v127, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv213 = \"{0}, {1}\";\n\tv44 = \"il2cpp_codegen_initialize_runtime_metadata\"(v213, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv46 = 1;\n\t*([1A35810]) = v46;\nL_0031:\n\tgoto L_0035;\n\tv120 = \"il2cpp_codegen_runtime_class_init\"(v113, v68, v70, v66, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv122 = DG.Tweening.Core.DOTweenUtils;\nL_0035:\n\tv124 = v123._defAssembliesToQuery;\n\tgoto L_0049;\n\tv214 = \"il2cpp_codegen_runtime_class_init\"(v121, v68, v70, v66, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv243 = DG.Tweening.Core.DOTweenUtils;\n\tv216 = *([v243 @ X8_v31+B8]);\nL_0049:\n\tv63 = v64 >= v124.Length;\n\tif (v63) goto L_0071;\n\tv204 = v215._defAssembliesToQuery;\n\tv318 = System.String::Format(\"{0}, {1}\", typeName, v204[v64 @ X26_v2 (System.Int32)]);\n\tgoto L_006B;\n\tv341 = v110;\n\tv342 = \"il2cpp_codegen_runtime_class_init\"(v341, v317, v315, v67, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_006B:\n\treturnVal2 = 0xAD98B4(v318, Il2CppMethodInfo, Il2CppMethodInfo, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv64 = v64 + 1;\n\tv108 = returnVal2 == 0;\n\tif (v108) goto L_0031;\n\tgoto L_00DC;\nL_0071:\n\tv244 = v215._loadedAssemblies == 0;\n\tv245 = ~v244;\n\tif (v245) goto L_FFFFFFFF;\n\tv193 = System.AppDomain::get_CurrentDomain();\n\tv337 = System.AppDomain::GetAssemblies(v193);\n\tgoto L_0084;\n\tv349 = v345;\n\tv350 = \"il2cpp_codegen_runtime_class_init\"(v349, v249, v70, v66, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv352 = DG.Tweening.Core.DOTweenUtils;\nL_0084:\n\tv257._loadedAssemblies = v337;\n\tgoto L_008E;\n\tv338 = \"il2cpp_codegen_runtime_class_init\"(v331, v140, v142, v138, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv339 = DG.Tweening.Core.DOTweenUtils;\nL_008E:\n\tv240 = v340._loadedAssemblies;\n\tv134 = v136 >= v240.Length;\n\tif (v134) goto L_FFFFFFFF;\n\tv353 = *([v194 @ X0_v14 (Il2CppClass<DG.Tweening.Core.DOTweenUtils>)+E0]) == 0;\n\tv354 = ~v353;\n\tif (v354) goto L_00BA;\n\tv240 = v360._loadedAssemblies;\nL_00BA:\n\tv364 = System.Reflection.Assembly::GetName(v240[v136 @ X26_v8 (System.Int32)]);\n\tv369 = System.String::Format(\"{0}, {1}\", typeName, v364);\n\tgoto L_00CC;\n\tv372 = v329;\n\tv373 = \"il2cpp_codegen_runtime_class_init\"(v372, v367, v366, v320, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00CC:\n\treturnVal2 = 0xAD98B4(v369, Il2CppMethodInfo, Il2CppMethodInfo, 0, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv136 = v136 + 1;\n\tv327 = returnVal2 == 0;\n\tif (v327) goto L_FFFFFFFF;\n\tgoto L_00DC;\nL_00DC:\n\treturn returnVal2;\n\tv211 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 157 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static Type GetLooseScriptType(string typeName)
		{
			//IL_01f6: Expected I, but got O
			int num = 0;
			Type type = default(Type);
			do
			{
				string[] defAssembliesToQuery = _defAssembliesToQuery;
				if (num < defAssembliesToQuery.Length)
				{
					string[] defAssembliesToQuery2 = _defAssembliesToQuery;
					string text = $"{typeName}, {defAssembliesToQuery2[num]}";
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD98B4");
					num++;
					continue;
				}
				if (_loadedAssemblies == null)
				{
					AppDomain currentDomain = AppDomain.CurrentDomain;
					Assembly[] assemblies = currentDomain.GetAssemblies();
					_loadedAssemblies = assemblies;
				}
				int num2 = 0;
				do
				{
					nint num3 = (nint)typeof(DOTweenUtils);
					Assembly[] loadedAssemblies = _loadedAssemblies;
					if (num2 < loadedAssemblies.Length)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v194 @ X0_v14 (Il2CppClass<DG.Tweening.Core.DOTweenUtils>)+E0]");
						if ((nint)0 == 0)
						{
							loadedAssemblies = _loadedAssemblies;
						}
						AssemblyName name = loadedAssemblies[num2].GetName();
						string text2 = $"{typeName}, {name}";
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @AD98B4");
						num2++;
						continue;
					}
					return null;
				}
				while ((object)type == null);
				break;
			}
			while ((object)type == null);
			return type;
		}
	}
}
