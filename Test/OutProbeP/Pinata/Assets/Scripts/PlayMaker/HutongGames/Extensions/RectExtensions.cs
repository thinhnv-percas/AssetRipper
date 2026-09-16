using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.Extensions
{
	[Token(Token = "0x2000086")]
	public static class RectExtensions
	{
		[Token(Token = "0x600067D")]
		[Address(RVA = "0x9C715C", Offset = "0x9C715C", Length = "0x88")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = 0x10CD07C(&rect @ V0 (UnityEngine.Rect), 0, v25, v26, v27, v28, v29, v30, rect, rect.m_YMin, rect.m_Width, rect.m_Height, x, y, v31, v32);\n\tv42 = rect >= x;\n\tif (v42) goto L_FFFFFFFF;\n\tv45 = 0x10CD124(&rect @ V0 (UnityEngine.Rect), 0, v25, v26, v27, v28, v29, v30, rect, rect.m_YMin, rect.m_Width, rect.m_Height, x, y, v31, v32);\n\tv47 = rect <= x;\n\tif (v47) goto L_FFFFFFFF;\n\tv76 = 0x10CD084(&rect @ V0 (UnityEngine.Rect), 0, v25, v26, v27, v28, v29, v30, rect, rect.m_YMin, rect.m_Width, rect.m_Height, x, y, v31, v32);\n\tv48 = rect >= y;\n\tif (v48) goto L_FFFFFFFF;\n\tv113 = 0x10CD134(&rect @ V0 (UnityEngine.Rect), 0, v25, v26, v27, v28, v29, v30, rect, rect.m_YMin, rect.m_Width, rect.m_Height, x, y, v31, v32);\n\tv99 = rect - y;\n\tv97 = v99 < 0;\n\tv95 = v99 == 0;\n\tv93 = rect ^ y;\n\tv91 = rect ^ v99;\n\tv89 = v93 & v91;\n\tv87 = v89 < 0;\n\tv115 = v97 == v87;\n\tv83 = ~v95;\n\tv85 = v115 & v83;\n\tgoto L_0052;\nL_0052:\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Contains(this Rect rect, float x, float y)
		{
			//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
			//IL_00f1: Expected O, but got Unknown
			//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
			//IL_00fe: Expected O, but got Unknown
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			Rect rect2 = default(Rect);
			if (rect2.x < x)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
				if (rect2.x > x)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
					if (rect2.x < y)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
						float num = rect2.x - y;
						bool flag = num < 0f;
						bool flag2 = num == 0f;
						object obj = rect ^ y;
						object obj2 = rect ^ num;
						int num2 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
						bool flag3 = num2 < 0;
						bool flag4 = flag == flag3;
						bool flag5 = !flag2;
						return flag4 && flag5;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x600067E")]
		[Address(RVA = "0x9C71E4", Offset = "0x9C71E4", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = 0x10CD07C(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv36 = 0x10CD07C(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv37 = rect1 < rect1;\n\tv38 = ~v37;\n\tv39 = rect1 - rect1;\n\tv41 = v39 == 0;\n\tv46 = ~v41;\n\tv47 = v38 & v46;\n\tif (v47) goto L_FFFFFFFF;\n\tv50 = 0x10CD084(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv86 = 0x10CD084(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv116 = rect1 < rect1;\n\tv77 = ~v116;\n\tv74 = rect1 - rect1;\n\tv68 = v74 == 0;\n\tv117 = ~v68;\n\tv53 = v77 & v117;\n\tif (v53) goto L_FFFFFFFF;\n\tv120 = 0x10CD124(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv85 = 0x10CD124(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv52 = rect1 >= rect1;\n\tif (v52) goto L_0053;\nL_0050:\n\treturn returnVal1;\nL_0053:\n\tv125 = 0x10CD134(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv127 = 0x10CD134(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv104 = rect1 - rect1;\n\tv102 = v104 < 0;\n\tv98 = rect1 ^ rect1;\n\tv96 = rect1 ^ v104;\n\tv94 = v98 & v96;\n\tv92 = v94 < 0;\n\tv90 = v102 == v92;\n\tgoto L_0050;\n\treturn X0;\n// 67 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool Contains(this Rect rect1, Rect rect2)
		{
			//IL_01ee: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f3: Expected O, but got Unknown
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			Rect rect3 = default(Rect);
			bool flag = rect3.x < rect3.x;
			bool flag2 = !flag;
			float num = rect3.x - rect3.x;
			bool flag3 = num == 0f;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
				bool flag5 = rect3.x < rect3.x;
				bool flag6 = !flag5;
				float num2 = rect3.x - rect3.x;
				bool flag7 = num2 == 0f;
				bool flag8 = !flag7;
				if (!(flag6 && flag8))
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
					if (!(rect3.x < rect3.x))
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
						float num3 = rect3.x - rect3.x;
						bool flag9 = num3 < 0f;
						object obj = (object)rect1 ^ (object)rect1;
						object obj2 = rect1 ^ num3;
						int num4 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
						bool flag10 = num4 < 0;
						return flag9 == flag10;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x600067F")]
		[Address(RVA = "0x9C72AC", Offset = "0x9C72AC", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = 0x10CD07C(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv36 = 0x10CD124(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv37 = rect1 < rect1;\n\tv38 = ~v37;\n\tv39 = rect1 - rect1;\n\tv41 = v39 == 0;\n\tv46 = ~v41;\n\tv47 = v38 & v46;\n\tif (v47) goto L_FFFFFFFF;\n\tv50 = 0x10CD124(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv86 = 0x10CD07C(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv53 = rect1 < rect1;\n\tif (v53) goto L_FFFFFFFF;\n\tv120 = 0x10CD084(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv85 = 0x10CD134(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv122 = rect1 < rect1;\n\tv76 = ~v122;\n\tv73 = rect1 - rect1;\n\tv67 = v73 == 0;\n\tv123 = ~v76;\n\tv52 = v123 | v67;\n\tif (v52) goto L_0054;\nL_0051:\n\treturn returnVal1;\nL_0054:\n\tv126 = 0x10CD134(&rect2 @ V4 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv128 = 0x10CD084(&rect1 @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv104 = rect1 - rect1;\n\tv102 = v104 < 0;\n\tv98 = rect1 ^ rect1;\n\tv96 = rect1 ^ v104;\n\tv94 = v98 & v96;\n\tv92 = v94 < 0;\n\tv90 = v102 == v92;\n\tgoto L_0051;\n\treturn X0;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IntersectsWith(this Rect rect1, Rect rect2)
		{
			//IL_01eb: Unknown result type (might be due to invalid IL or missing references)
			//IL_01f0: Expected O, but got Unknown
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
			Rect rect3 = default(Rect);
			bool flag = rect3.x < rect3.x;
			bool flag2 = !flag;
			float num = rect3.x - rect3.x;
			bool flag3 = num == 0f;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
				if (!(rect3.x < rect3.x))
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
					bool flag5 = rect3.x < rect3.x;
					bool flag6 = !flag5;
					float num2 = rect3.x - rect3.x;
					bool flag7 = num2 == 0f;
					bool flag8 = !flag6;
					if (flag8 || flag7)
					{
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
						float num3 = rect3.x - rect3.x;
						bool flag9 = num3 < 0f;
						object obj = (object)rect1 ^ (object)rect1;
						object obj2 = rect1 ^ num3;
						int num4 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
						bool flag10 = num4 < 0;
						return flag9 == flag10;
					}
				}
			}
			return false;
		}

		[Token(Token = "0x6000680")]
		[Address(RVA = "0x9C7374", Offset = "0x9C7374", Length = "0x15C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0025;\n\tv38 = *([1EDB8D0]);\n\tv39 = *([v38 @ X8_v9]);\n\tv40 = \"il2cpp_codegen_initialize_method\"(v39, v41, v42, v43, v44, v45, v46, v47, rect1, v0, v2, v3, rect2, v4, v6, v7);\n\tv51 = 0 | 1;\n\t*([20219BC]) = v51;\nL_0025:\n\tv54 = 0x10CD07C(&rect1 @ V0 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv58 = 0x10CD07C(&rect2 @ V4 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, rect1, rect1.m_YMin, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tgoto L_003A;\n\tv66 = *([v62 @ X0_v6+E0]);\n\tv67 = v66 == 0;\n\tv68 = ~v67;\n\tgoto L_003A;\n\tv70 = \"il2cpp_codegen_runtime_class_init\"(v62, v56, v42, v43, v44, v45, v46, v47, rect1, v0, v2, v3, rect2, v4, v6, v7);\nL_003A:\n\tv76 = UnityEngine.Mathf::Min(rect1, rect1);\n\tv80 = 0x10CD084(&rect1 @ V0 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, v76, rect1, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv84 = 0x10CD084(&rect2 @ V4 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, v76, rect1, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv88 = UnityEngine.Mathf::Min(v76, v76);\n\tv92 = 0x10CD124(&rect1 @ V0 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, v88, v76, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv96 = 0x10CD124(&rect2 @ V4 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, v88, v76, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv100 = UnityEngine.Mathf::Max(v88, v88);\n\tv104 = 0x10CD134(&rect1 @ V0 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, v100, v88, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv108 = 0x10CD134(&rect2 @ V4 (UnityEngine.Rect), 0, v42, v43, v44, v45, v46, v47, v100, v88, rect1.m_Width, rect1.m_Height, rect2, rect2.m_YMin, rect2.m_Width, rect2.m_Height);\n\tv112 = UnityEngine.Mathf::Max(v100, v100);\n\trect1 = UnityEngine.Rect::MinMaxRect(v76, v88, v100, v112);\n\treturn rect1;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rect Union(this Rect rect1, Rect rect2)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD07C (inside UnityEngine.Rect::MinMaxRect +0xE0)");
			Rect rect3 = default(Rect);
			float num = Mathf.Min(rect3.x, rect3.x);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD084 (inside UnityEngine.Rect::MinMaxRect +0xE8)");
			float num2 = Mathf.Min(num, num);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD124 (inside UnityEngine.Rect::MinMaxRect +0x188)");
			float num3 = Mathf.Max(num2, num2);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD134 (inside UnityEngine.Rect::MinMaxRect +0x198)");
			float ymax = Mathf.Max(num3, num3);
			rect3 = Rect.MinMaxRect(num, num2, num3, ymax);
			return rect1;
		}

		[Token(Token = "0x6000681")]
		[Address(RVA = "0x9C74D0", Offset = "0x9C74D0", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv26 = 0x10CCFB4(&rect @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect, rect.m_YMin, rect.m_Width, rect.m_Height, scale, v33, v34, v35);\n\tv39 = 0x10CCFC4(&rect @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect, rect.m_YMin, rect.m_Width, rect.m_Height, scale, v33, v34, v35);\n\tv43 = 0x10CD178(&rect @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect, rect.m_YMin, rect.m_Width, rect.m_Height, scale, v33, v34, v35);\n\tv47 = 0x10CD188(&rect @ V0 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, rect, rect.m_YMin, rect.m_Width, rect.m_Height, scale, v33, v34, v35);\n\tv48 = rect * scale;\n\tv49 = rect * scale;\n\tv50 = rect * scale;\n\tv51 = rect * scale;\n\tv53 = 0;\n\tv57 = 0x10CCF64(&v53 @ stack_-40_v1 (UnityEngine.Rect), 0, v27, v28, v29, v30, v31, v32, v48, v49, v50, v51, v48, v33, v34, v35);\n\treturn 0;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rect Scale(this Rect rect, float scale)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			Rect rect2 = default(Rect);
			float num = rect2.x * scale;
			float num2 = rect2.x * scale;
			float num3 = rect2.x * scale;
			float num4 = rect2.x * scale;
			Rect rect3 = default(Rect);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			return default(Rect);
		}

		[Token(Token = "0x6000682")]
		[Address(RVA = "0x9C756C", Offset = "0x9C756C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv36 = *([1EDC438]);\n\tv37 = *([v36 @ X8_v9]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, v39, v40, v41, v42, v43, v44, v45, rect, v0, v2, v3, minWidth, minHeight, v46, v47);\n\tv51 = 0 | 1;\n\t*([20219BD]) = v51;\nL_0021:\n\tv54 = 0x10CCFB4(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect.m_YMin, rect.m_Width, rect.m_Height, minWidth, minHeight, v46, v47);\n\tv58 = 0x10CCFC4(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect.m_YMin, rect.m_Width, rect.m_Height, minWidth, minHeight, v46, v47);\n\tv62 = 0x10CD178(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect.m_YMin, rect.m_Width, rect.m_Height, minWidth, minHeight, v46, v47);\n\tgoto L_003A;\n\tv70 = *([v66 @ X0_v8+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_003A;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, v60, v40, v41, v42, v43, v44, v45, rect, v0, v2, v3, minWidth, minHeight, v46, v47);\nL_003A:\n\tv80 = UnityEngine.Mathf::Max(rect, minWidth);\n\tv84 = 0x10CD188(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v80, minWidth, rect.m_Width, rect.m_Height, minWidth, minHeight, v46, v47);\n\tv87 = UnityEngine.Mathf::Max(v80, minHeight);\n\tv90 = 0;\n\tv96 = 0x10CCF64(&v90 @ stack_-50_v1 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect, v80, v87, minWidth, minHeight, v46, v47);\n\treturn 0;\n// 68 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rect MinSize(this Rect rect, float minWidth, float minHeight)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Rect rect2 = default(Rect);
			float a = Mathf.Max(rect2.x, minWidth);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			float num = Mathf.Max(a, minHeight);
			Rect rect3 = default(Rect);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			return default(Rect);
		}

		[Token(Token = "0x6000683")]
		[Address(RVA = "0x9C767C", Offset = "0x9C767C", Length = "0x110")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv36 = *([1ED04C0]);\n\tv37 = *([v36 @ X8_v9]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, v39, v40, v41, v42, v43, v44, v45, rect, v0, v2, v3, minSize, v4, v46, v47);\n\tv51 = 0 | 1;\n\t*([20219BE]) = v51;\nL_0022:\n\tv54 = 0x10CCFB4(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect.m_YMin, rect.m_Width, rect.m_Height, minSize, minSize.y, v46, v47);\n\tv58 = 0x10CCFC4(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect.m_YMin, rect.m_Width, rect.m_Height, minSize, minSize.y, v46, v47);\n\tv62 = 0x10CD178(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect.m_YMin, rect.m_Width, rect.m_Height, minSize, minSize.y, v46, v47);\n\tgoto L_003B;\n\tv70 = *([v66 @ X0_v8+E0]);\n\tv71 = v70 == 0;\n\tv72 = ~v71;\n\tif (v72) goto L_003B;\n\tv74 = \"il2cpp_codegen_runtime_class_init\"(v66, v60, v40, v41, v42, v43, v44, v45, rect, v0, v2, v3, minSize, v4, v46, v47);\nL_003B:\n\tv80 = UnityEngine.Mathf::Max(rect, minSize);\n\tv84 = 0x10CD188(&rect @ V0 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, v80, minSize, rect.m_Width, rect.m_Height, minSize, minSize.y, v46, v47);\n\tv87 = UnityEngine.Mathf::Max(v80, minSize.y);\n\tv90 = 0;\n\tv96 = 0x10CCF64(&v90 @ stack_-50_v1 (UnityEngine.Rect), 0, v40, v41, v42, v43, v44, v45, rect, rect, v80, v87, minSize, minSize.y, v46, v47);\n\treturn 0;\n// 69 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Rect MinSize(this Rect rect, Vector2 minSize)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFB4 (inside UnityEngine.Rect::MinMaxRect +0x18)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCFC4 (inside UnityEngine.Rect::MinMaxRect +0x28)");
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD178 (inside UnityEngine.Rect::MinMaxRect +0x1DC)");
			Rect rect2 = default(Rect);
			Vector2 vector = default(Vector2);
			float a = Mathf.Max(rect2.x, vector.x);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CD188 (inside UnityEngine.Rect::MinMaxRect +0x1EC)");
			float num = Mathf.Max(a, minSize.y);
			Rect rect3 = default(Rect);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @10CCF64 (inside UnityEngine.RangeAttribute::.ctor +0x290)");
			return default(Rect);
		}
	}
}
