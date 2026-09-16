using System;
using System.Collections;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Spine.Collections
{
	[Token(Token = "0x20000D5")]
	public static class CollectionExtensions
	{
		[Token(Token = "0x6000790")]
		[Address(RVA = "0xDA58CC", Offset = "0xDA58CC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_000F;\n\tv18 = 0xB3490C(methodInfo, keySelector, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_000F:\n\tv36 = Il2CppMethodInfo;\n\tv41 = *([v36 @ X3_v1 (Il2CppMethodInfo)]);\n\t// 25 IndirectJump v41 @ X4_v1, source @ X0 (System.Collections.Generic.IEnumerable`1<TSource>), source @ X0 (System.Collections.Generic.IEnumerable`1<TSource>), keySelector @ X1 (System.Func`2<TSource, TKey>), 0, methodof(Spine.Collections.CollectionExtensions::ToOrderedDictionary), v41 @ X4_v1, v21 @ X5, v22 @ X6, v23 @ X7, v24 @ V0, v25 @ V1, v26 @ V2, v27 @ V3, v28 @ V4, v29 @ V5, v30 @ V6, v31 @ V7\n\treturn X0;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static OrderedDictionary<TKey, TSource> ToOrderedDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			//IL_0022: Expected O, but got I
			nint num = 0;
			object obj = num;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v41 @ X4_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000791")]
		[Address(RVA = "0xDA5914", Offset = "0xDA5914", Length = "0x568")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv24 = &v25 @ stack_-60_v2;\n\t*([v24 @ X29_v1-28]) = keySelector;\n\t*([v24 @ X29_v1-20]) = comparer;\n\t*([v24 @ X29_v1-50]) = v29;\n\t*([v24 @ X29_v1-8]) = *([v29 @ SYSREG+28]);\n\t*([v24 @ X29_v1-48]) = source;\n\tgoto L_0028;\n\tgoto L_0028;\n\tv53 = 0xB3490C(v445, keySelector, comparer, v445, v450, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0028:\n\tv60 = Il2CppClass<TSource>;\n\tv61 = Il2CppClass<TKey>;\n\tv66 = *([v60 @ X8_v3 (Il2CppClass<TSource>)+FC]) + 0xF;\n\tv67 = v66 & 0x1FFFFFFF0;\n\tv68 = &v65 @ stack_-B0_v1 - v67;\n\tv408 = &v65 @ stack_-B0_v1 - v67;\n\tv76 = &v65 @ stack_-B0_v1 - v67;\n\t*([v24 @ X29_v1-40]) = v76;\n\tv78 = *([v61 @ X9_v1 (Il2CppClass<TKey>)+FC]) + 0xF;\n\tv81 = v78 & 0x1FFFFFFF0;\n\tv82 = &v65 @ stack_-B0_v1 - v81;\n\tv86 = &v65 @ stack_-B0_v1 - v81;\n\tv90 = &v65 @ stack_-B0_v1 - v67;\n\tv95 = 0x1854F20(v90, 0, *([v60 @ X8_v3 (Il2CppClass<TSource>)+FC]), v445, v450, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv100 = &v65 @ stack_-B0_v1 - v81;\n\t*([v24 @ X29_v1-38]) = v100;\n\t*([v24 @ X29_v1-30]) = *([v61 @ X9_v1 (Il2CppClass<TKey>)+FC]);\n\tv104 = 0x1854F20(v100, 0, *([v61 @ X9_v1 (Il2CppClass<TKey>)+FC]), v445, v450, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv106 = *([v24 @ X29_v1-48]);\n\tv107 = *([v24 @ X29_v1-48]) == 0;\n\tif (v107) goto L_01A2;\n\tv110 = *([v24 @ X29_v1-28]) == 0;\n\tif (v110) goto L_01AA;\n\tgoto L_005D;\n\tv184 = 0xB348B0(v175, v102, v103, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_005D:\n\tv187 = new Il2CppClass<Spine.Collections.OrderedDictionary`2<TKey, TSource>>();\n\t*([v24 @ X29_v1-20]) = v187;\n\tv196 = Spine.Collections.OrderedDictionary`2<TKey, TSource>::.ctor(v187, *([v24 @ X29_v1-20]));\n\tgoto L_006E;\n\tv233 = v198;\n\tv234 = 0xB348B0(v233, v198, v194, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv236 = v234;\nL_006E:\n\tv238 = *([v106 @ X24_v2]);\n\tv278 = *([v238 @ X8_v36+12E]);\n\tv240 = *([v238 @ X8_v36+12E]) == 0;\n\tif (v240) goto L_FFFFFFFF;\n\tv287 = *([v238 @ X8_v36+B0]) + 8;\nL_0079:\n\tv292 = *([v287 @ X10_v49-8]) == Il2CppClass<System.Collections.Generic.IEnumerable`1<TSource>>;\n\tif (v292) goto L_0091;\n\tv251 = v278 - 1;\n\tv287 = v287 + 0x10;\n\tv249 = v278 != 1;\n\tif (v249) goto L_0079;\n\tgoto L_0097;\nL_0091:\n\t;\nL_0097:\n\tv334 = System.Collections.Generic.IEnumerable`1<TSource>::GetEnumerator(*([v24 @ X29_v1-48]));\nL_00A1:\n\tgoto L_00C7;\n\tv483 = *([v439 @ X8_v40+B0]);\n\tv484 = v483 + 8;\n\tv486 = *([v523 @ X10_v44-8]);\n\tv528 = v486 == v443;\n\tif (v528) goto L_00C0;\n\tv490 = v514 - 1;\n\tv508 = v523 + 0x10;\n\tv488 = v514 != 1;\n\tif (v488) goto L_FFFFFFFF;\n\tv509 = v167;\n\tv510 = 0;\n\tv511 = 0xB349B4(v509, v443, v510, v404, v410, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00C7;\nL_00C0:\n\tv545 = *([v523 @ X10_v44]);\n\tv546 = v545 << 4;\n\tv547 = v439 + v546;\n\tv548 = v547 + 0x138;\nL_00C7:\n\tv393 = System.Collections.IEnumerator::MoveNext(v334);\n\tv570 = v393 == 0;\n\tif (v570) goto L_FFFFFFFF;\n\tgoto L_00D5;\n\tv584 = v575;\n\tv585 = 0xB348B0(v584, v575, v562, v404, v410, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv587 = v585;\nL_00D5:\n\tv589 = *([v334 @ X0_v63 (System.Collections.IEnumerator)]);\n\tv744 = *([v589 @ X8_v45 (Il2CppClass<System.Collections.IEnumerator>)+12E]);\n\tv591 = *([v589 @ X8_v45 (Il2CppClass<System.Collections.IEnumerator>)+12E]) == 0;\n\tif (v591) goto L_00F5;\n\tv753 = *([v589 @ X8_v45 (Il2CppClass<System.Collections.IEnumerator>)+B0]) + 8;\nL_00DB:\n\t;\n\tv758 = *([v753 @ X10_v39-8]) == Il2CppClass<System.Collections.Generic.IEnumerator`1<TSource>>;\n\tif (v758) goto L_00F7;\n\tv661 = v744 - 1;\n\tv753 = v753 + 0x10;\n\tv659 = v744 != 1;\n\tif (v659) goto L_00DB;\nL_00F5:\n\tv824 = 0xB349B4(v334, Il2CppClass<System.Collections.Generic.IEnumerator`1<TSource>>, 0, v445, *([v24 @ X29_v1-40]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00FB;\nL_00F7:\n\t;\n\tv818 = *([v753 @ X10_v39]) << 4;\n\tv819 = v589 + v818;\n\tv824 = v819 + 0x138;\nL_00FB:\n\t*([v24 @ X29_v1-18]) = v68;\n\tv826 = *([v824 @ X0_v69+8]);\n\tv829 = &v25 @ stack_-60_v2 - 0x18;\n\t*([v826 @ X1_v26+10])(v832, *([v826 @ X1_v26+8]), v826, v334, v829, v68, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv836 = 0x1854F10(v90, v68, *([v60 @ X8_v3 (Il2CppClass<TSource>)+FC]), v829, v68, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv892 = 0x1854F10(v408, v90, *([v60 @ X8_v3 (Il2CppClass<TSource>)+FC]), v829, v68, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0114;\n\tv939 = *([v408 @ X26_v9]);\nL_0114:\n\tv940 = Il2CppMethodInfo;\n\t*([v24 @ X29_v1-18]) = v408;\n\t*([v24 @ X29_v1-10]) = v82;\n\tv112 = &v25 @ stack_-60_v2 - 0x18;\n\t*([v940 @ X1_v29 (Il2CppMethodInfo)+10])(v944, *([v940 @ X1_v29 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v24 @ X29_v1-28]), v112, v82, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv949 = 0x1854F10(*([v24 @ X29_v1-38]), v82, *([v24 @ X29_v1-30]), v112, v82, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv953 = 0x1854F10(v86, *([v24 @ X29_v1-38]), *([v24 @ X29_v1-30]), v112, v82, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv955 = 0x1854F10(*([v24 @ X29_v1-40]), v90, *([v60 @ X8_v3 (Il2CppClass<TSource>)+FC]), v112, v82, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0142;\n\tv963 = *([v86 @ X22_v1]);\nL_0142:\n\tgoto L_0144;\n\tv968 = *([v157 @ X24_v12]);\nL_0144:\n\tv430 = Il2CppMethodInfo;\n\t*([v24 @ X29_v1-18]) = v86;\n\t*([v24 @ X29_v1-10]) = *([v24 @ X29_v1-40]);\n\tv445 = &v25 @ stack_-60_v2 - 0x18;\n\t*([v430 @ X1_v33 (Il2CppMethodInfo)+10])(v432, *([v430 @ X1_v33 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v24 @ X29_v1-20]), v445, *([v24 @ X29_v1-40]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_00A1;\nL_014E:\n\tv610 = v397 == 0;\n\tif (v610) goto L_017D;\n\tgoto L_017C;\n\tv763 = *([v684 @ X8_v16+B0]);\n\tv764 = v763 + 8;\n\tv766 = *([v848 @ X10_v10-8]);\n\tv853 = v766 == v687;\n\tif (v853) goto L_0175;\n\tv770 = v839 - 1;\n\tv788 = v848 + 0x10;\n\tv768 = v839 != 1;\n\tif (v768) goto L_FFFFFFFF;\n\tv789 = v397;\n\tv790 = 0;\n\tv791 = 0xB349B4(v789, v687, v790, v351, v361, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_017C;\nL_0175:\n\tv894 = *([v848 @ X10_v10]);\n\tv895 = v894 << 4;\n\tv896 = v684 + v895;\n\tv897 = v896 + 0x138;\nL_017C:\n\tSystem.IDisposable::Dispose(v397);\nL_017D:\n\tv707 = v399 == 0;\n\tv395 = ~v707;\n\tif (v395) goto L_01B8;\n\tv792 = *([v24 @ X29_v1-50]);\n\tv453 = *([v792 @ X8_v14+28]) != *([v24 @ X29_v1-8]);\n\tif (v453) goto L_01B9;\n\treturn *([v24 @ X29_v1-20]);\n\tthrow System.NullReferenceException;\nL_01A2:\n\tv183 = new System.ArgumentNullException();\n\tgoto L_01B2;\nL_01AA:\n\tv188 = new System.ArgumentNullException();\nL_01B2:\n\tSystem.ArgumentNullException::.ctor(v210, v227);\n\tthrow v210;\n\tthrow System.NullReferenceException;\nL_01B8:\n\tv476 = new System.OutOfMemoryException();\nL_01B9:\n\tv482 = 0x1854EB0(v476, v645, v643, v445, *([v24 @ X29_v1-40]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_01C9;\n\tgoto L_01C9;\n\tgoto L_01C9;\n\tgoto L_01C9;\n\tgoto L_01C9;\nL_01C9:\n\tv543 = v645 != 1;\n\tif (v543) goto L_01D1;\n\tv572 = 0x1854E70(v482, v645, v643, v445, *([v24 @ X29_v1-40]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv399 = *([v572 @ X0_v36]);\n\tv393 = 0x1854E80(v572, v645, v643, v445, *([v24 @ X29_v1-40]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_014E;\nL_01D1:\n\tgoto L_01D3;\n\tX20 = X0;\nL_01D3:\n\tv583 = v478 == 0;\n\tif (v583) goto L_0204;\n\tgoto L_0201;\n\tv708 = *([v612 @ X8_v23+B0]);\n\tv709 = v708 + 8;\n\tv711 = *([v805 @ X10_v21-8]);\n\tv810 = v711 == v615;\n\tif (v810) goto L_01FA;\n\tv715 = v796 - 1;\n\tv733 = v805 + 0x10;\n\tv713 = v796 != 1;\n\tif (v713) goto L_FFFFFFFF;\n\tv734 = v478;\n\tv735 = 0;\n\tv736 = 0xB349B4(v734, v615, v735, v445, v450, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tgoto L_0201;\nL_01FA:\n\tv882 = *([v805 @ X10_v21]);\n\tv883 = v882 << 4;\n\tv884 = v612 + v883;\n\tv885 = v884 + 0x138;\nL_0201:\n\tSystem.IDisposable::Dispose(v478);\nL_0204:\n\tgoto L_0208;\n\tv738 = 0xBD3CD0(v482, v645, v643, v445, *([v24 @ X29_v1-40]), v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0208:\n\tv741 = new System.OutOfMemoryException();\n\treturnVal2 = 0x9DACB4(v741, v645\n// ... truncated")]
		public static OrderedDictionary<TKey, TSource> ToOrderedDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, IEqualityComparer<TKey> comparer)
		{
			//IL_033b: Expected O, but got I
			//IL_034e: Expected I4, but got I8
			//IL_035c: Expected O, but got I
			//IL_036a: Expected O, but got I
			//IL_0378: Expected O, but got I
			//IL_0393: Expected O, but got I
			//IL_03a6: Expected I4, but got I8
			//IL_03b4: Expected O, but got I
			//IL_03c2: Expected O, but got I
			//IL_03d0: Expected O, but got I
			//IL_03e8: Expected O, but got I
			//IL_0414: Expected O, but got I
			//IL_007d: Expected O, but got I
			//IL_0451: Expected O, but got I
			//IL_04a9: Expected O, but got I
			//IL_00a2: Expected O, but got I
			//IL_01b2: Expected I, but got O
			//IL_01b7: Expected I, but got O
			//IL_00b6: Expected O, but got I
			//IL_00c5: Expected O, but got I
			//IL_05fe: Expected I, but got O
			//IL_04e4: Expected I, but got O
			//IL_04f4: Expected O, but got I
			//IL_01e2: Expected O, but got I
			//IL_020d: Expected O, but got I4
			//IL_0215: Expected I, but got O
			//IL_061a: Expected I, but got O
			//IL_061f: Expected I, but got O
			//IL_0551: Expected O, but got I
			//IL_0562: Expected O, but got I
			//IL_011d: Expected O, but got I
			//IL_0230: Expected O, but got I
			//IL_0186: Expected I4, but got O
			//IL_0194: Expected O, but got I
			//IL_01a3: Expected O, but got I
			//IL_02c7: Expected I4, but got O
			//IL_0131: Expected O, but got I
			//IL_0140: Expected O, but got I
			//IL_02de: Expected O, but got I
			//IL_0674: Expected O, but got I
			//IL_0679: Expected I, but got O
			//IL_067e: Expected I, but got O
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v29 @ SYSREG+28]");
			_ = 0;
			nint num = 0;
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v60 @ X8_v3 (Il2CppClass<TSource>)+FC]");
			object obj3 = (nint)0 + (nint)15;
			int num3 = (int)((nint)obj3 & 0x1FFFFFFF0L);
			object obj5 = default(object);
			object obj4 = (nint)obj5 - num3;
			object obj6 = (nint)obj5 - num3;
			object obj7 = (nint)obj5 - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			object obj8 = (nint)0 + (nint)15;
			int num4 = (int)((nint)obj8 & 0x1FFFFFFF0L);
			object obj9 = (nint)obj5 - num4;
			object obj10 = (nint)obj5 - num4;
			object obj11 = (nint)obj5 - num3;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			object obj12 = (nint)obj5 - num4;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v61 @ X9_v1 (Il2CppClass<TKey>)+FC]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F20 (native memset)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-48]");
			object obj13 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-48]");
			ArgumentNullException ex4;
			if ((nint)0 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-28]");
				if ((nint)0 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-20]");
					OrderedDictionary<TKey, TSource> orderedDictionary = new OrderedDictionary<TKey, TSource>((IEqualityComparer<TKey>)0);
					object obj14 = obj13;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v36+12E]");
					object obj15 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v36+12E]");
					if ((nint)0 != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v238 @ X8_v36+B0]");
						object obj16 = (nint)0 + (nint)8;
						bool flag;
						do
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v287 @ X10_v49-8]");
							if ((nint)0 != 0)
							{
								object obj17 = (nint)obj15 - 1;
								obj16 = (nint)obj16 + 16;
								flag = (nint)obj15 != 1;
								obj15 = obj17;
								continue;
							}
							break;
						}
						while (flag);
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-48]");
					IEnumerator enumerator = ((IEnumerable<TSource>)0).GetEnumerator();
					bool flag2;
					while (true)
					{
						flag2 = enumerator.MoveNext();
						if (!flag2)
						{
							break;
						}
						nint num5 = (nint)enumerator;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ X8_v45 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						object obj18 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ X8_v45 (Il2CppClass<System.Collections.IEnumerator>)+12E]");
						if ((nint)0 == 0)
						{
							goto IL_0168;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v589 @ X8_v45 (Il2CppClass<System.Collections.IEnumerator>)+B0]");
						object obj19 = (nint)0 + (nint)8;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v753 @ X10_v39-8]");
							if ((nint)0 == 0)
							{
								break;
							}
							object obj20 = (nint)obj18 - 1;
							obj19 = (nint)obj19 + 16;
							bool flag3 = (nint)obj18 != 1;
							obj18 = obj20;
							if (flag3)
							{
								continue;
							}
							goto IL_0168;
						}
						int num6 = obj19 << 4;
						object obj21 = num5 + num6;
						object obj22 = (nint)obj21 + 312;
						goto IL_053c;
						IL_0168:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @B349B4");
						goto IL_053c;
						IL_053c:
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v824 @ X0_v69+8]");
						object obj23 = 0;
						object obj24 = (nint)obj2 - 24;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v826 @ X1_v26+10] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						nint num7 = 0;
						nint num8 = (nint)obj2 - 24;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v940 @ X1_v29 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854F10 (native memcpy)");
						nint num9 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-40]");
						_ = 0;
						nint num10 = (nint)obj2 - 24;
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v430 @ X1_v33 (Il2CppMethodInfo)+10] (should have been resolved before IL gen)");
					}
					nint num11 = unchecked((nint)null);
					nint num12 = unchecked((nint)null);
					IDisposable disposable = (IDisposable)enumerator;
					int num13 = 0;
					bool flag4 = default(bool);
					nint num14;
					object obj26 = default(object);
					while (true)
					{
						if (disposable != null)
						{
							disposable.Dispose();
							num11 = unchecked((nint)null);
							num12 = unchecked((nint)null);
							flag2 = flag4;
						}
						bool flag5 = num13 == 0;
						bool flag6 = !flag5;
						num14 = (nint)disposable;
						if (!flag6)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-50]");
							object obj25 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v792 @ X8_v14+28]");
							nint num15 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-8]");
							bool flag7 = num15 != 0;
							OutOfMemoryException ex = (OutOfMemoryException)flag2;
							num14 = (nint)disposable;
							if (!flag7)
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v24 @ X29_v1-20]");
								return (OrderedDictionary<TKey, TSource>)0;
							}
						}
						else
						{
							OutOfMemoryException ex = new OutOfMemoryException();
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854EB0 (native __stack_chk_fail)");
						if (num12 == 1)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
							num13 = (int)obj26;
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
							disposable = (IDisposable)num14;
							continue;
						}
						break;
					}
					if (num14 != 0)
					{
						((IDisposable)num14).Dispose();
						num11 = unchecked((nint)null);
						num12 = unchecked((nint)null);
					}
					OutOfMemoryException ex2 = new OutOfMemoryException();
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @9DACB4");
					OrderedDictionary<TKey, TSource> result = default(OrderedDictionary<TKey, TSource>);
					return result;
				}
				ArgumentNullException ex3 = new ArgumentNullException();
				ex4 = ex3;
				string text = "keySelector";
			}
			else
			{
				ArgumentNullException ex5 = new ArgumentNullException();
				ex4 = ex5;
				string text = "source";
			}
			throw ex4;
		}
	}
}
