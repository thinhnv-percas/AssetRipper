using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[CreateAssetMenu]
	[Token(Token = "0x2000066")]
	public class ObiRopeSection : ScriptableObject
	{
		[HideInInspector]
		[Token(Token = "0x40001DF")]
		[FieldOffset(Offset = "0x18")]
		public List<Vector2> vertices;

		[Token(Token = "0x40001E0")]
		[FieldOffset(Offset = "0x20")]
		public int snapX;

		[Token(Token = "0x40001E1")]
		[FieldOffset(Offset = "0x24")]
		public int snapY;

		[Token(Token = "0x170000B3")]
		public int Segments
		{
			[Token(Token = "0x600045B")]
			[Address(RVA = "0x102254C", Offset = "0x102254C", Length = "0x58")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EA45B0]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20261F4]) = v38;\nL_0013:\n\tv39 = this.vertices;\n\treturnVal1 = v39._size - 1;\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				List<Vector2> list = vertices;
				return list.Count - 1;
			}
		}

		[Token(Token = "0x600045C")]
		[Address(RVA = "0x10225A4", Offset = "0x10225A4", Length = "0x84")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = *([1EEA758]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20261F5]) = v38;\nL_0014:\n\tv40 = this.vertices == 0;\n\tif (v40) goto L_001F;\n\treturn;\nL_001F:\n\tv48 = new System.Collections.Generic.List`1<UnityEngine.Vector2>();\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::.ctor(v48);\n\tthis.vertices = v48;\n\tObi.ObiRopeSection::CirclePreset(this, 8);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void OnEnable()
		{
			if (vertices == null)
			{
				List<Vector2> list = new List<Vector2>();
				vertices = list;
				CirclePreset(8);
			}
		}

		[Token(Token = "0x600045D")]
		[Address(RVA = "0x1022628", Offset = "0x1022628", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv38 = *([1EF5890]);\n\tv39 = *([v38 @ X8_v17]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, segments, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54);\n\tv57 = 0 | 1;\n\t*([20261F6]) = v57;\nL_0023:\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::Clear(this.vertices);\n\tv140 = segments & 0x80000000;\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0095;\n\tv116 = 6.2831855f / segments;\nL_0036:\n\tv259 = v116 * v118;\n\tgoto L_0041;\n\tv263 = *([v257 @ X0_v7 (Il2CppClass<UnityEngine.Mathf>)+E0]);\n\tv264 = v263 == 0;\n\tv265 = ~v264;\n\tgoto L_0041;\n\tv267 = \"il2cpp_codegen_runtime_class_init\"(v257, v130, methodInfo, v42, v43, v44, v45, v46, v258, v251, v249, v248, v51, v52, v53, v54);\nL_0041:\n\tv271 = 0x6D3020(UnityEngine.Mathf, v130, methodInfo, v42, v43, v44, v45, v46, v259, v251, v305, v305.y, v51, v52, v53, v54);\n\tgoto L_004E;\n\tv277 = *([v272 @ X0_v10+E0]);\n\tv278 = v277 == 0;\n\tv279 = ~v278;\n\tif (v279) goto L_004E;\n\tv281 = \"il2cpp_codegen_runtime_class_init\"(v272, v130, methodInfo, v42, v43, v44, v45, v46, v270, v251, v249, v248, v51, v52, v53, v54);\nL_004E:\n\tv284 = UnityEngine.Vector2::get_right();\n\tv292 = UnityEngine.Vector2::op_Multiply(v259, v284);\n\tv295 = 0x6D2D20(0, v130, methodInfo, v42, v43, v44, v45, v46, v259, v292.y, v284.y, v284.y, v51, v52, v53, v54);\n\tv297 = UnityEngine.Vector2::get_up();\n\tv305 = UnityEngine.Vector2::op_Multiply(v259, v297);\n\tv128 = UnityEngine.Vector2::op_Addition(v292, v305);\n\tSystem.Collections.Generic.List`1<UnityEngine.Vector2>::Add(this.vertices, v128);\n\tv118 = v118 + 1;\n\tv151 = v118 <= segments;\n\tif (v151) goto L_0036;\nL_0095:\n\treturn;\n\tv132 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 114 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void CirclePreset(int segments)
		{
			//IL_0022: Expected I4, but got I8
			//IL_011f: Expected I4, but got F4
			vertices.Clear();
			if ((int)(segments & 0x80000000L) == 0)
			{
				float num = (float)Math.PI * 2f / (float)segments;
				int num2 = 0;
				int num3 = segments;
				IntPtr intPtr = (IntPtr)0;
				bool flag;
				do
				{
					float num4 = num * (float)num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D3020 (native cosf)");
					Vector2 right = Vector2.right;
					Vector2 vector = num4 * right;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2D20 (native sinf)");
					Vector2 up = Vector2.up;
					Vector2 vector2 = num4 * up;
					Vector2 item = vector + vector2;
					vertices.Add(item);
					num2++;
					flag = num2 <= segments;
					num3 = (int)item.y;
					intPtr = (IntPtr)0;
				}
				while (flag);
			}
		}

		[Token(Token = "0x600045E")]
		[Address(RVA = "0x10227C0", Offset = "0x10227C0", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv26 = *([1EC57F8]);\n\tv27 = *([v26 @ X8_v12]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, threshold, methodInfo, v30, v31, v32, v33, v34, val, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20261F7]) = v44;\nL_0022:\n\tv56 = snapInterval < 1;\n\tif (v56) goto L_FFFFFFFF;\n\tgoto L_0031;\n\tv64 = *([v59 @ X0_v4+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0031;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v59, threshold, methodInfo, v30, v31, v32, v33, v34, val, v35, v36, v37, v38, v39, v40, v41);\nL_0031:\n\tv72 = val / snapInterval;\n\tv74 = UnityEngine.Mathf::FloorToInt(v72);\n\treturnVal1 = v74 * snapInterval;\n\tv114 = val - returnVal1;\n\tv82 = v114 < threshold;\n\tif (v82) goto L_005D;\n\tv115 = returnVal1 + snapInterval;\n\tv80 = v115 - val;\n\tv77 = v80 < threshold;\n\tif (v77) goto L_FFFFFFFF;\n\tgoto L_0054;\nL_0054:\n\tgoto L_005D;\nL_005D:\n\treturn returnVal1;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static int SnapTo(float val, int snapInterval, int threshold)
		{
			//IL_00c1: Expected I4, but got F4
			//IL_00a7: Expected I4, but got F4
			int num2;
			if (snapInterval >= 1)
			{
				float f = val / (float)snapInterval;
				int num = Mathf.FloorToInt(f);
				num2 = num * snapInterval;
				float num3 = val - (float)num2;
				if (!(num3 < (float)threshold))
				{
					int num4 = num2 + snapInterval;
					float num5 = (float)num4 - val;
					num2 = ((num5 < (float)threshold) ? num4 : ((int)val));
				}
			}
			else
			{
				num2 = (int)val;
			}
			return num2;
		}

		[Token(Token = "0x600045F")]
		[Address(RVA = "0x102287C", Offset = "0x102287C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiRopeSection()
		{
		}
	}
}
