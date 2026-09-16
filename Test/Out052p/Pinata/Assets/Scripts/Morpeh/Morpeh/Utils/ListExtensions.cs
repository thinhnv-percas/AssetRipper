using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using Unity.IL2CPP.CompilerServices;

namespace Morpeh.Utils
{
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DB1C", Offset = "0x73DB1C")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DB1C", Offset = "0x73DB1C")]
	[AttributeAttribute(Type = typeof(Il2CppSetOptionAttribute), RVA = "0x73DB1C", Offset = "0x73DB1C")]
	[Token(Token = "0x2000034")]
	public static class ListExtensions
	{
		[Token(Token = "0x60000E1")]
		[Address(RVA = "0x9E9EA0", Offset = "0x9E9EA0", Length = "0x234")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv30 = v25;\n\tv31 = 0x8907BC(v30, index, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0016:\n\tv46 = list->klass;\n\tv48 = *([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v48) goto L_0039;\n\tv103 = *([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0022:\n\tv108 = *([v103 @ X11_v23-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v108) goto L_003B;\n\tv102 = v102 + 1;\n\tv113 = v102 < *([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv80 = ~v113;\n\tv103 = v103 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0022;\nL_0039:\n\tgoto L_0041;\nL_003B:\n\t;\nL_0041:\n\tv140 = System.Collections.Generic.ICollection`1<T>::get_Count(list);\n\tgoto L_004C;\n\tv148 = v143;\n\tv149 = 0x8907BC(v148, v138, v121, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_004C:\n\tv151 = list->klass;\n\tv152 = v140 - 1;\n\tv154 = *([v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v154) goto L_0070;\n\tv197 = *([v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0059:\n\tv202 = *([v197 @ X11_v18-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v202) goto L_0072;\n\tv196 = v196 + 1;\n\tv207 = v196 < *([v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv177 = ~v207;\n\tv197 = v197 + 0x10;\n\tv161 = ~v177;\n\tif (v161) goto L_0059;\nL_0070:\n\tgoto L_0079;\nL_0072:\n\t;\nL_0079:\n\tv234 = System.Collections.Generic.IList`1<T>::get_Item(list, v152);\n\tgoto L_0084;\n\tv242 = v237;\n\tv243 = 0x8907BC(v242, v233, v231, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0084:\n\tv245 = list->klass;\n\tv247 = *([v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v247) goto L_00A7;\n\tv290 = *([v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0090:\n\tv295 = *([v290 @ X11_v13-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v295) goto L_00A9;\n\tv289 = v289 + 1;\n\tv300 = v289 < *([v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv270 = ~v300;\n\tv290 = v290 + 0x10;\n\tv254 = ~v270;\n\tif (v254) goto L_0090;\nL_00A7:\n\tgoto L_00B2;\nL_00A9:\n\tv302 = *([v290 @ X11_v13]) + 1;\n\tv303 = v302 << 4;\n\tv304 = v245 + v303;\n\tv322 = v304 + 0x130;\nL_00B2:\n\tv329 = System.Collections.Generic.IList`1<T>::set_Item(list, index, v234);\n\tgoto L_00BC;\n\tv336 = v331;\n\tv337 = 0x8907BC(v336, v327, v328, v325, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00BC:\n\tv339 = list->klass;\n\tv341 = *([v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v341) goto L_00DE;\n\tv384 = *([v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_00C8:\n\tv389 = *([v384 @ X11_v8-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v389) goto L_00E1;\n\tv383 = v383 + 1;\n\tv394 = v383 < *([v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv364 = ~v394;\n\tv384 = v384 + 0x10;\n\tv348 = ~v364;\n\tif (v348) goto L_00C8;\nL_00DE:\n\tv416 = 0x8909C4(list, Il2CppClass<System.Collections.Generic.IList`1<T>>, 4, *([v322 @ X0_v10+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_00E5;\nL_00E1:\n\tv396 = *([v384 @ X11_v8]) + 4;\n\tv397 = v396 << 4;\n\tv398 = v339 + v397;\n\tv416 = v398 + 0x130;\nL_00E5:\n\tv418 = *([v416 @ X0_v14]);\n\tv419 = *([v416 @ X0_v14+8]);\n\t// 242 IndirectJump v418 @ X3_v2, list @ X0 (System.Collections.Generic.IList`1<T>), list @ X0 (System.Collections.Generic.IList`1<T>), v152 @ X22_v3, v419 @ X2_v7, v418 @ X3_v2, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\treturn;\n// 161 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoveAtFast<T>(this IList<T> list, int index)
		{
			//IL_000d: Expected I, but got O
			//IL_038f: Expected O, but got I4
			//IL_0048: Expected O, but got I
			//IL_00c2: Expected I, but got O
			//IL_00d1: Expected O, but got I
			//IL_03c3: Expected I4, but got O
			//IL_010c: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0186: Expected I, but got O
			//IL_01c1: Expected O, but got I
			//IL_0158: Expected O, but got I
			//IL_0272: Expected I, but got O
			//IL_0234: Unknown result type (might be due to invalid IL or missing references)
			//IL_0239: Expected O, but got Unknown
			//IL_0256: Expected O, but got I
			//IL_0265: Expected O, but got I
			//IL_043e: Expected O, but got I
			//IL_02ad: Expected O, but got I
			//IL_020d: Expected O, but got I
			//IL_032a: Unknown result type (might be due to invalid IL or missing references)
			//IL_032f: Expected O, but got Unknown
			//IL_034c: Expected O, but got I
			//IL_035b: Expected O, but got I
			//IL_02f9: Expected O, but got I
			IntPtr intPtr = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v23-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					break;
				}
				while (!flag2);
			}
			object obj2 = list.Count;
			IntPtr intPtr2 = (IntPtr)list;
			object obj3 = (long)(IntPtr)obj2 - 1L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj4 = 0L + 8L;
				int num3 = 0;
				bool flag4;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v197 @ X11_v18-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag3 = (long)num4 < 0L;
						flag4 = !flag3;
						obj4 = (long)(IntPtr)obj4 + 16L;
						continue;
					}
					break;
				}
				while (!flag4);
			}
			object value = list.get_Item((int)obj3);
			IntPtr intPtr3 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj5 = 0L + 8L;
				int num5 = 0;
				bool flag6;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v290 @ X11_v13-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag5 = (long)num6 < 0L;
						flag6 = !flag5;
						obj5 = (long)(IntPtr)obj5 + 16L;
						continue;
					}
					object obj6 = obj5 + 1;
					int num7 = (int)((long)(IntPtr)obj6 << 4);
					object obj7 = (long)intPtr3 + (long)num7;
					object obj8 = (long)(IntPtr)obj7 + 304L;
					break;
				}
				while (!flag6);
			}
			list.set_Item(index, (T)value);
			IntPtr intPtr4 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_0312;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj9 = 0L + 8L;
			int num8 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ X11_v8-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num8++;
				int num9 = num8;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
				bool flag7 = (long)num9 < 0L;
				bool flag8 = !flag7;
				obj9 = (long)(IntPtr)obj9 + 16L;
				if (!flag8)
				{
					continue;
				}
				goto IL_0312;
			}
			object obj10 = obj9 + 4;
			int num10 = (int)((long)(IntPtr)obj10 << 4);
			object obj11 = (long)intPtr4 + (long)num10;
			object obj12 = (long)(IntPtr)obj11 + 304L;
			goto IL_0426;
			IL_0426:
			object obj13 = obj12;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v416 @ X0_v14+8]");
			object obj14 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v418 @ X3_v2 (should have been resolved before IL gen)");
			return;
			IL_0312:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0426;
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x9EA308", Offset = "0x9EA308", Length = "0x2B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv30 = v25;\n\tv31 = 0x8907BC(v30, item, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0016:\n\tv46 = list->klass;\n\tv48 = *([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v48) goto L_0039;\n\tv103 = *([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0022:\n\tv108 = *([v103 @ X11_v29-8]) == Il2CppClass<System.Collections.Generic.ICollection`1<T>>;\n\tif (v108) goto L_003B;\n\tv102 = v102 + 1;\n\tv113 = v102 < *([v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv80 = ~v113;\n\tv103 = v103 + 0x10;\n\tv56 = ~v80;\n\tif (v56) goto L_0022;\nL_0039:\n\tgoto L_0041;\nL_003B:\n\t;\nL_0041:\n\tv140 = System.Collections.Generic.ICollection`1<T>::get_Count(list);\n\tgoto L_004C;\n\tv148 = v143;\n\tv149 = 0x8907BC(v148, v138, v121, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_004C:\n\tv151 = list->klass;\n\tv153 = *([v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v153) goto L_006F;\n\tv196 = *([v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0058:\n\tv201 = *([v196 @ X11_v24-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v201) goto L_0071;\n\tv195 = v195 + 1;\n\tv206 = v195 < *([v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv176 = ~v206;\n\tv196 = v196 + 0x10;\n\tv160 = ~v176;\n\tif (v160) goto L_0058;\nL_006F:\n\tgoto L_0079;\nL_0071:\n\t;\nL_0079:\n\tv234 = System.Collections.Generic.IList`1<T>::IndexOf(list, item);\n\tgoto L_0084;\n\tv242 = v237;\n\tv243 = 0x8907BC(v242, v233, v231, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_0084:\n\tv245 = list->klass;\n\tv246 = v140 - 1;\n\tv248 = *([v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v248) goto L_00A8;\n\tv291 = *([v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0091:\n\tv296 = *([v291 @ X11_v19-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v296) goto L_00AA;\n\tv290 = v290 + 1;\n\tv301 = v290 < *([v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv271 = ~v301;\n\tv291 = v291 + 0x10;\n\tv255 = ~v271;\n\tif (v255) goto L_0091;\nL_00A8:\n\tgoto L_00B1;\nL_00AA:\n\t;\nL_00B1:\n\tv328 = System.Collections.Generic.IList`1<T>::get_Item(list, v246);\n\tgoto L_00BC;\n\tv336 = v331;\n\tv337 = 0x8907BC(v336, v327, v325, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00BC:\n\tv339 = list->klass;\n\tv341 = *([v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v341) goto L_00DF;\n\tv384 = *([v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_00C8:\n\tv389 = *([v384 @ X11_v14-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v389) goto L_00E1;\n\tv383 = v383 + 1;\n\tv394 = v383 < *([v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv364 = ~v394;\n\tv384 = v384 + 0x10;\n\tv348 = ~v364;\n\tif (v348) goto L_00C8;\nL_00DF:\n\tgoto L_00EA;\nL_00E1:\n\tv396 = *([v384 @ X11_v14]) + 1;\n\tv397 = v396 << 4;\n\tv398 = v339 + v397;\n\tv416 = v398 + 0x130;\nL_00EA:\n\tv423 = System.Collections.Generic.IList`1<T>::set_Item(list, v234, v328);\n\tgoto L_00F4;\n\tv430 = v425;\n\tv431 = 0x8907BC(v430, v421, v422, v419, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\nL_00F4:\n\tv433 = list->klass;\n\tv435 = *([v433 @ X8_v23 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]) == 0;\n\tif (v435) goto L_0116;\n\tv478 = *([v433 @ X8_v23 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]) + 8;\nL_0100:\n\tv483 = *([v478 @ X11_v9-8]) == Il2CppClass<System.Collections.Generic.IList`1<T>>;\n\tif (v483) goto L_0119;\n\tv477 = v477 + 1;\n\tv488 = v477 < *([v433 @ X8_v23 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]);\n\tv458 = ~v488;\n\tv478 = v478 + 0x10;\n\tv442 = ~v458;\n\tif (v442) goto L_0100;\nL_0116:\n\tv510 = 0x8909C4(list, Il2CppClass<System.Collections.Generic.IList`1<T>>, 4, *([v416 @ X0_v14+8]), v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tgoto L_011D;\nL_0119:\n\tv490 = *([v478 @ X11_v9]) + 4;\n\tv491 = v490 << 4;\n\tv492 = v433 + v491;\n\tv510 = v492 + 0x130;\nL_011D:\n\tv512 = *([v510 @ X0_v18]);\n\tv513 = *([v510 @ X0_v18+8]);\n\t// 298 IndirectJump v512 @ X3_v2, list @ X0 (System.Collections.Generic.IList`1<T>), list @ X0 (System.Collections.Generic.IList`1<T>), v246 @ X21_v2, v513 @ X2_v9, v512 @ X3_v2, v33 @ X4, v34 @ X5, v35 @ X6, v36 @ X7, v37 @ V0, v38 @ V1, v39 @ V2, v40 @ V3, v41 @ V4, v42 @ V5, v43 @ V6, v44 @ V7\n\treturn;\n// 199 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void RemoveFast<T>(this IList<T> list, T item)
		{
			//IL_000d: Expected I, but got O
			//IL_0445: Expected O, but got I4
			//IL_0048: Expected O, but got I
			//IL_00c2: Expected I, but got O
			//IL_047d: Expected O, but got I4
			//IL_00fd: Expected O, but got I
			//IL_0094: Expected O, but got I
			//IL_0178: Expected I, but got O
			//IL_0187: Expected O, but got I
			//IL_04b1: Expected I4, but got O
			//IL_01c2: Expected O, but got I
			//IL_0149: Expected O, but got I
			//IL_023c: Expected I, but got O
			//IL_04ed: Expected I4, but got O
			//IL_0277: Expected O, but got I
			//IL_020e: Expected O, but got I
			//IL_0328: Expected I, but got O
			//IL_02ea: Unknown result type (might be due to invalid IL or missing references)
			//IL_02ef: Expected O, but got Unknown
			//IL_030c: Expected O, but got I
			//IL_031b: Expected O, but got I
			//IL_052c: Expected O, but got I
			//IL_0363: Expected O, but got I
			//IL_02c3: Expected O, but got I
			//IL_03e0: Unknown result type (might be due to invalid IL or missing references)
			//IL_03e5: Expected O, but got Unknown
			//IL_0402: Expected O, but got I
			//IL_0411: Expected O, but got I
			//IL_03af: Expected O, but got I
			IntPtr intPtr = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				bool flag2;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X11_v29-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num++;
						int num2 = num;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v3 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag = (long)num2 < 0L;
						flag2 = !flag;
						obj = (long)(IntPtr)obj + 16L;
						continue;
					}
					break;
				}
				while (!flag2);
			}
			object obj2 = list.Count;
			IntPtr intPtr2 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj3 = 0L + 8L;
				int num3 = 0;
				bool flag4;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v196 @ X11_v24-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num3++;
						int num4 = num3;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v151 @ X8_v8 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag3 = (long)num4 < 0L;
						flag4 = !flag3;
						obj3 = (long)(IntPtr)obj3 + 16L;
						continue;
					}
					break;
				}
				while (!flag4);
			}
			object obj4 = list.IndexOf(item);
			IntPtr intPtr3 = (IntPtr)list;
			object obj5 = (long)(IntPtr)obj2 - 1L;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj6 = 0L + 8L;
				int num5 = 0;
				bool flag6;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v291 @ X11_v19-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num5++;
						int num6 = num5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X8_v13 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag5 = (long)num6 < 0L;
						flag6 = !flag5;
						obj6 = (long)(IntPtr)obj6 + 16L;
						continue;
					}
					break;
				}
				while (!flag6);
			}
			object value = list.get_Item((int)obj5);
			IntPtr intPtr4 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 != (IntPtr)0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
				object obj7 = 0L + 8L;
				int num7 = 0;
				bool flag8;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v384 @ X11_v14-8]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						num7++;
						int num8 = num7;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v339 @ X8_v18 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
						bool flag7 = (long)num8 < 0L;
						flag8 = !flag7;
						obj7 = (long)(IntPtr)obj7 + 16L;
						continue;
					}
					object obj8 = obj7 + 1;
					int num9 = (int)((long)(IntPtr)obj8 << 4);
					object obj9 = (long)intPtr4 + (long)num9;
					object obj10 = (long)(IntPtr)obj9 + 304L;
					break;
				}
				while (!flag8);
			}
			list.set_Item((int)obj4, (T)value);
			IntPtr intPtr5 = (IntPtr)list;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ X8_v23 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_03c8;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ X8_v23 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+B0]");
			object obj11 = 0L + 8L;
			int num10 = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v478 @ X11_v9-8]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					break;
				}
				num10++;
				int num11 = num10;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v433 @ X8_v23 (Il2CppClass<System.Collections.Generic.IList`1<T>>)+126]");
				bool flag9 = (long)num11 < 0L;
				bool flag10 = !flag9;
				obj11 = (long)(IntPtr)obj11 + 16L;
				if (!flag10)
				{
					continue;
				}
				goto IL_03c8;
			}
			object obj12 = obj11 + 4;
			int num12 = (int)((long)(IntPtr)obj12 << 4);
			object obj13 = (long)intPtr5 + (long)num12;
			object obj14 = (long)(IntPtr)obj13 + 304L;
			goto IL_0514;
			IL_0514:
			object obj15 = obj14;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v510 @ X0_v18+8]");
			object obj16 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v512 @ X3_v2 (should have been resolved before IL gen)");
			return;
			IL_03c8:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_0514;
		}
	}
}
