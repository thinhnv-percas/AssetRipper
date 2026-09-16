using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000007")]
public class CSVHelper : MonoBehaviour
{
	[Token(Token = "0x400001C")]
	private const int NUMBER_RESOURCE_MAX = 20;

	[Token(Token = "0x6000031")]
	[Address(RVA = "0xBF6DEC", Offset = "0xBF6DEC", Length = "0x4EC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0049;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv196 = Il2CppMethodInfo;\n\tv197 = \"il2cpp_codegen_initialize_runtime_metadata\"(v196, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv254 = Il2CppMethodInfo;\n\tv255 = \"il2cpp_codegen_initialize_runtime_metadata\"(v254, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv351 = Il2CppMethodInfo;\n\tv352 = \"il2cpp_codegen_initialize_runtime_metadata\"(v351, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv428 = Il2CppMethodInfo;\n\tv429 = \"il2cpp_codegen_initialize_runtime_metadata\"(v428, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv489 = Il2CppMethodInfo;\n\tv490 = \"il2cpp_codegen_initialize_runtime_metadata\"(v489, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv545 = System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>;\n\tv546 = \"il2cpp_codegen_initialize_runtime_metadata\"(v545, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv580 = System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>;\n\tv581 = \"il2cpp_codegen_initialize_runtime_metadata\"(v580, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv661 = \"\";\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v661, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A355BA]) = v57;\nL_0049:\n\tv62 = new System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::.ctor(v62);\n\tv74 = new System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::.ctor(v74);\n\tv105 = System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::GetEnumerator(csvData);\nL_006F:\n\tv310 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v103 @ stack_-98_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv354 = v310 == 0;\n\tif (v354) goto L_010C;\n\tv494 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(v200, tagSeparator);\n\tv548 = v494 == 0;\n\tif (v548) goto L_00E9;\n\tv585 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v200, tagSeparator);\n\tv619 = System.String::Equals(v585, \"\");\n\tv722 = v619 == 0;\n\tv624 = ~v722;\n\tif (v624) goto L_00E9;\n\tv683 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v200, tagSeparator);\n\tv714 = System.String::Trim(v683);\n\tv620 = System.String::Equals(v714, \"\");\n\tv774 = v620 == 0;\n\tv625 = ~v774;\n\tif (v625) goto L_00E9;\n\tv777 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v200, tagSeparator);\n\tv621 = System.Int32::Parse(v777);\n\tv626 = v612 + 1;\n\tv779 = v626 == 0;\n\tv599 = ~v779;\n\tif (v599) goto L_00B5;\n\tgoto L_00B5;\nL_00B5:\n\tv586 = v621 != v612;\n\tif (v586) goto L_00BD;\n\tgoto L_00E9;\nL_00BD:\n\tv753 = v62._items;\n\tv750 = v62._version + 1;\n\tv62._version = v750;\n\tv597 = v62._size;\n\tv788 = v62._size < v753.Length;\n\tv602 = ~v788;\n\tif (v602) goto L_00DB;\n\tv789 = v62._size + 1;\n\tv62._size = v789;\n\tv753[v597 @ X10_v23 (System.Int32)] = v246;\n\tgoto L_00DF;\nL_00DB:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::AddWithResize(v62, v246);\nL_00DF:\n\tv618 = new System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::.ctor(v618);\nL_00E9:\n\tv526 = v246._items;\n\tv508 = v246._version + 1;\n\tv246._version = v508;\n\tv272 = v246._size;\n\tv694 = v246._size < v526.Length;\n\tv281 = ~v694;\n\tif (v281) goto L_0106;\n\tv274 = v246._size + 1;\n\tv246._size = v274;\n\tv526[v272 @ X10_v20 (System.Int32)] = v200;\n\tgoto L_006F;\nL_0106:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::AddWithResize(v246, v200);\n\tgoto L_006F;\nL_010C:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v103 @ stack_-98_v6 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_010D:\n\tv540 = v612 + 1;\n\tv145 = v540 == 0;\n\tif (v145) goto L_0130;\n\tv187 = v62._items;\n\tv130 = v62._version + 1;\n\tv62._version = v130;\n\tv217 = v62._size;\n\tv690 = v62._size < v187.Length;\n\tv223 = ~v690;\n\tif (v223) goto L_0139;\n\tv321 = v62._size + 1;\n\tv62._size = v321;\n\tv187[v217 @ X10_v8 (System.Int32)] = v246;\n\tgoto L_013B;\nL_0130:\n\tv576 = v62 == 0;\n\tv178 = ~v576;\n\tif (v178) goto L_013B;\n\tthrow System.NullReferenceException;\nL_0139:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::AddWithResize(v62, v246);\nL_013B:\n\tv349 = v345._size == 0;\n\tif (v349) goto L_0157;\n\treturn v345;\n\tv523 = new System.NullReferenceException();\n\tv529 = new System.NullReferenceException();\n\tv575 = new System.NullReferenceException();\n\tv653 = new System.NullReferenceException();\n\tv689 = new System.NullReferenceException();\n\tv720 = new System.NullReferenceException();\n\tv747 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\nL_0157:\n\tv487 = new System.Exception();\n\tSystem.Exception::.ctor(v487, \"result must not null\");\n\tthrow v487;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\n\tgoto L_0181;\nL_0181:\n\tv436 = Il2CppMethodInfo != 1;\n\tif (v436) goto L_0191;\n\tv755 = 0x1854E70(v693, Il2CppMethodInfo, 0, v41, v42, v43, v44, v45, v402, v47, v48, v49, v50, v51, v52, v53);\n\tv538 = *([v755 @ X0_v29]);\n\tv762 = 0x1854E80(v755, Il2CppMethodInfo, 0, v41, v42, v43, v44, v45, v402, v47, v48, v49, v50, v51, v52, v53);\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v399 @ stack_-80_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>), Il2CppMethodInfo);\n\tv537 = v538 == 0;\n\tif (v537) goto L_010D;\n\tthrow System.OutOfMemoryException;\nL_0191:\n\tgoto L_0197;\n\tX21 = X0;\nL_0197:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v399 @ stack_-80_v2 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>), Il2CppMethodInfo);\n\tif (-2) goto L_019E;\n\tv768 = Sys\n// ... truncated")]
	public static List<List<Dictionary<string, string>>> getListGroupCSV(List<Dictionary<string, string>> csvData, string tagSeparator)
	{
		List<List<Dictionary<string, string>>> list = new List<List<Dictionary<string, string>>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		List<Dictionary<string, string>>.Enumerator enumerator = csvData.GetEnumerator();
		int num = -1;
		List<Dictionary<string, string>> list3 = list2;
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		Dictionary<string, string> dictionary = default(Dictionary<string, string>);
		while (enumerator2.MoveNext())
		{
			if (dictionary.ContainsKey(tagSeparator))
			{
				string text = dictionary[tagSeparator];
				if (!text.Equals(""))
				{
					string text2 = dictionary[tagSeparator];
					string text3 = text2.Trim();
					if (!text3.Equals(""))
					{
						string s = dictionary[tagSeparator];
						int num2 = int.Parse(s);
						if (num + 1 == 0)
						{
							num = num2;
						}
						if (num2 == num)
						{
							num = num2;
						}
						else
						{
							List<Dictionary<string, string>>[] items = list._items;
							int version = list._version + 1;
							list._version = version;
							int count = list.Count;
							if (list.Count < items.Length)
							{
								int size = list.Count + 1;
								list._size = size;
								items[count] = list3;
							}
							else
							{
								list.Add(list3);
							}
							List<Dictionary<string, string>> list4 = new List<Dictionary<string, string>>();
							list3 = list4;
						}
					}
				}
			}
			Dictionary<string, string>[] items2 = list3._items;
			int version2 = list3._version + 1;
			list3._version = version2;
			int count2 = list3.Count;
			if (list3.Count < items2.Length)
			{
				int size2 = list3.Count + 1;
				list3._size = size2;
				items2[count2] = dictionary;
			}
			else
			{
				list3.Add(dictionary);
			}
		}
		enumerator2.Dispose();
		List<List<Dictionary<string, string>>> list5;
		if (num + 1 != 0)
		{
			List<Dictionary<string, string>>[] items3 = list._items;
			int version3 = list._version + 1;
			list._version = version3;
			int count3 = list.Count;
			if (list.Count < items3.Length)
			{
				int size3 = list.Count + 1;
				list._size = size3;
				items3[count3] = list3;
				list5 = list;
			}
			else
			{
				list.Add(list3);
				list5 = list;
			}
		}
		else
		{
			bool flag = list == null;
			bool flag2 = !flag;
			list5 = list;
			if (!flag2)
			{
				throw new NullReferenceException();
			}
		}
		if (list5.Count != 0)
		{
			return list5;
		}
		Exception ex = new Exception("result must not null");
		throw ex;
	}

	[Token(Token = "0x6000032")]
	[Address(RVA = "0xBF72D8", Offset = "0xBF72D8", Length = "0x40")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = System.String::Split(filename, 0x5F, 0);\n\treturnVal2 = System.Int32::Parse(v7[1]);\n\treturn returnVal2;\n\tv17 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static int GetIdFromFileName(string filename)
	{
		string[] array = filename.Split('_');
		return int.Parse(array[1]);
	}

	[Token(Token = "0x6000033")]
	[Address(RVA = "0xBF7318", Offset = "0xBF7318", Length = "0x5B4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0052;\n\tv38 = UnityEngine.Debug;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv83 = Il2CppMethodInfo;\n\tv84 = \"il2cpp_codegen_initialize_runtime_metadata\"(v83, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv88 = Il2CppMethodInfo;\n\tv89 = \"il2cpp_codegen_initialize_runtime_metadata\"(v88, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv249 = Il2CppMethodInfo;\n\tv250 = \"il2cpp_codegen_initialize_runtime_metadata\"(v249, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv311 = Il2CppMethodInfo;\n\tv312 = \"il2cpp_codegen_initialize_runtime_metadata\"(v311, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv401 = Il2CppMethodInfo;\n\tv402 = \"il2cpp_codegen_initialize_runtime_metadata\"(v401, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv406 = Il2CppMethodInfo;\n\tv407 = \"il2cpp_codegen_initialize_runtime_metadata\"(v406, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv415 = Il2CppMethodInfo;\n\tv416 = \"il2cpp_codegen_initialize_runtime_metadata\"(v415, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv477 = Il2CppMethodInfo;\n\tv478 = \"il2cpp_codegen_initialize_runtime_metadata\"(v477, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv520 = System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>;\n\tv521 = \"il2cpp_codegen_initialize_runtime_metadata\"(v520, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv581 = System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>;\n\tv582 = \"il2cpp_codegen_initialize_runtime_metadata\"(v581, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv659 = System.String;\n\tv660 = \"il2cpp_codegen_initialize_runtime_metadata\"(v659, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv728 = \"Load Group csv count = 0\";\n\tv729 = \"il2cpp_codegen_initialize_runtime_metadata\"(v728, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv778 = \"\";\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v778, tagSeparator, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A355BB]) = v57;\nL_0052:\n\tv62 = new System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::.ctor(v62);\n\tv74 = new System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::.ctor(v74);\n\tv383 = v99.Empty;\n\tv108 = System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::GetEnumerator(csvData);\nL_007A:\n\tv360 = System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::MoveNext(&v107 @ stack_-98_v5 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\n\tv404 = v360 == 0;\n\tif (v404) goto L_0117;\n\tv420 = System.Collections.Generic.Dictionary`2<System.String, System.String>::ContainsKey(v252, tagSeparator);\n\tv480 = v420 == 0;\n\tif (v480) goto L_FFFFFFFF;\n\tv525 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v252, tagSeparator);\n\tv541 = System.String::Equals(v525, \"\");\n\tv731 = v541 == 0;\n\tv545 = ~v731;\n\tif (v545) goto L_FFFFFFFF;\n\tv622 = System.Collections.Generic.Dictionary`2<System.String, System.String>::get_Item(v252, tagSeparator);\n\tv784 = System.String::Trim(v622);\n\tv542 = System.String::IsNullOrEmpty(v784);\n\tv789 = v542 == 0;\n\tv546 = ~v789;\n\tif (v546) goto L_FFFFFFFF;\n\tv665 = System.String::IsNullOrEmpty(v383);\n\tv278 = v665 == 0;\n\tv272 = ~v278;\n\tv270 = ~v272;\n\tif (v270) goto L_00BA;\n\tgoto L_00BA;\nL_00BA:\n\tv300 = System.String::Equals(v784, v383);\n\tv544 = v300 == 0;\n\tif (v544) goto L_00EA;\nL_00C3:\n\tv455 = v321._items;\n\tv433 = v321._version + 1;\n\tv321._version = v433;\n\tv320 = v321._size;\n\tv732 = v321._size < v455.Length;\n\tv329 = ~v732;\n\tif (v329) goto L_00E2;\n\tv343 = v321._size + 1;\n\tv321._size = v343;\n\tv455[v320 @ X10_v22 (System.Int32)] = v252;\n\tgoto L_007A;\nL_00E2:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::AddWithResize(v321, v252);\n\tgoto L_007A;\nL_00EA:\n\tv395 = v62._items;\n\tv368 = v62._version + 1;\n\tv62._version = v368;\n\tv392 = v62._items == 0;\n\tif (v392) goto L_019A;\n\tv589 = v62._size;\n\tv802 = v62._size < v395.Length;\n\tv592 = ~v802;\n\tif (v592) goto L_0108;\n\tv803 = v62._size + 1;\n\tv62._size = v803;\n\tv395[v589 @ X10_v25 (System.Int32)] = v241;\n\tgoto L_010C;\nL_0108:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::AddWithResize(v62, v241);\nL_010C:\n\tv598 = new System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::.ctor(v598);\n\tgoto L_00C3;\nL_0117:\n\tSystem.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>::Dispose(&v107 @ stack_-98_v5 (System.Collections.Generic.List`1<System.Object>+Enumerator<System.Object>));\nL_011A:\n\tv221 = System.String::IsNullOrEmpty(v383);\n\tv509 = v221 == 0;\n\tif (v509) goto L_0126;\n\tv574 = v707 == 0;\n\tv225 = ~v574;\n\tif (v225) goto L_0148;\n\tgoto L_0198;\nL_0126:\n\tv235 = v707._items;\n\tv143 = v707._version + 1;\n\tv707._version = v143;\n\tv633 = v707._size;\n\tv721 = v707._size < v235.Length;\n\tv635 = ~v721;\n\tif (v635) goto L_0144;\n\tv639 = v707._size + 1;\n\tv707._size = v639;\n\tv235[v633 @ X10_v12 (System.Int32)] = v243;\n\tgoto L_0148;\nL_0144:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::AddWithResize(v707, v243);\nL_0148:\n\tv650 = v707._size == 0;\n\tv651 = ~v650;\n\tif (v651) goto L_0191;\n\tgoto L_0157;\n\tv733 = \"il2cpp_codegen_runtime_class_init\"(v669, v640, v183, v41, v42, v43, v44, v45, v195, v47, v48, v49, v50, v51, v52, v53);\nL_0157:\n\tUnityEngine.Debug::LogWarning(\"Load Group csv count = 0\");\n\tv222 = new System.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::.ctor(v222);\n\tv237 = v222._items;\n\tv145 = v222._version + 1;\n\tv222._version = v145;\n\tv686 = v222._size;\n\tv790 = v222._size < v237.Length;\n\tv690 = ~v790;\n\tif (v690) goto L_0182;\n\tv792 = v222._size + 1;\n\tv222._size = v792;\n\tv237[v686 @ X10_v9 (System.Int32)] = csvData;\n\tgoto L_0191;\nL_0182:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>>::AddWithResize(v222, csvData);\nL_0191:\n\treturn v707;\n\tv452 = ne\n// ... truncated")]
	public unsafe static List<List<Dictionary<string, string>>> GetListGroupCSV(List<Dictionary<string, string>> csvData, string tagSeparator)
	{
		//IL_060e: Expected O, but got I
		//IL_02b3: Expected I, but got O
		List<List<Dictionary<string, string>>> list = new List<List<Dictionary<string, string>>>();
		List<Dictionary<string, string>> list2 = new List<Dictionary<string, string>>();
		string text = string.Empty;
		List<Dictionary<string, string>>.Enumerator enumerator = csvData.GetEnumerator();
		List<Dictionary<string, string>> list3 = list2;
		List<object>.Enumerator enumerator2 = default(List<object>.Enumerator);
		Dictionary<string, string> dictionary = default(Dictionary<string, string>);
		List<object>.Enumerator enumerator3;
		object obj = default(object);
		IntPtr intPtr = default(IntPtr);
		string text7 = default(string);
		IntPtr intPtr2 = default(IntPtr);
		while (true)
		{
			string text5;
			List<List<Dictionary<string, string>>> list4;
			List<Dictionary<string, string>> list5;
			List<Dictionary<string, string>> list7;
			string text6;
			if (enumerator2.MoveNext())
			{
				if (dictionary.ContainsKey(tagSeparator))
				{
					string text2 = dictionary[tagSeparator];
					if (!text2.Equals(""))
					{
						string text3 = dictionary[tagSeparator];
						string text4 = text3.Trim();
						if (!string.IsNullOrEmpty(text4))
						{
							if (string.IsNullOrEmpty(text))
							{
								text = text4;
							}
							if (!text4.Equals(text))
							{
								List<Dictionary<string, string>>[] items = list._items;
								int version = list._version + 1;
								list._version = version;
								bool flag = list._items == null;
								nint num = unchecked((nint)null);
								enumerator3 = enumerator2;
								List<object>.Enumerator enumerator4 = enumerator2;
								text5 = text;
								list4 = list;
								list5 = list3;
								if (!flag)
								{
									int count = list.Count;
									if (list.Count < items.Length)
									{
										int size = list.Count + 1;
										list._size = size;
										items[count] = list3;
									}
									else
									{
										list.Add(list3);
									}
									List<Dictionary<string, string>> list6 = new List<Dictionary<string, string>>();
									list7 = list6;
									text6 = text4;
									goto IL_0198;
								}
								goto IL_0629;
							}
						}
					}
				}
				list7 = list3;
				text6 = text;
				goto IL_0198;
			}
			enumerator2.Dispose();
			list4 = list;
			list5 = list3;
			goto IL_03af;
			IL_0629:
			NullReferenceException ex = new NullReferenceException();
			if ((nint)text5 == 1)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E70 (native __cxa_begin_catch)");
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @1854E80 (native __cxa_end_catch)");
				enumerator3.Dispose();
				if (obj != null)
				{
					throw new OutOfMemoryException();
				}
				goto IL_03af;
			}
			break;
			IL_03af:
			if (string.IsNullOrEmpty(text))
			{
				if (list4 == null)
				{
					enumerator3 = enumerator2;
					List<object>.Enumerator enumerator4 = enumerator2;
					list4 = list;
					NullReferenceException ex2 = new NullReferenceException();
					nint num = intPtr;
					text = text7;
					text5 = (string)(nint)intPtr2;
					list5 = list3;
					NullReferenceException ex3 = new NullReferenceException();
					goto IL_0629;
				}
			}
			else
			{
				List<Dictionary<string, string>>[] items2 = list4._items;
				int version2 = list4._version + 1;
				list4._version = version2;
				int count2 = list4.Count;
				if (list4.Count < items2.Length)
				{
					int size2 = list4.Count + 1;
					list4._size = size2;
					items2[count2] = list5;
				}
				else
				{
					list4.Add(list5);
				}
			}
			if (list4.Count == 0)
			{
				Debug.LogWarning("Load Group csv count = 0");
				List<List<Dictionary<string, string>>> list8 = new List<List<Dictionary<string, string>>>();
				List<Dictionary<string, string>>[] items3 = list8._items;
				int version3 = list8._version + 1;
				list8._version = version3;
				int count3 = list8.Count;
				if (list8.Count < items3.Length)
				{
					int size3 = list8.Count + 1;
					list8._size = size3;
					items3[count3] = csvData;
					list4 = list8;
				}
				else
				{
					list8.Add(csvData);
					list4 = list8;
				}
			}
			return list4;
			IL_0198:
			Dictionary<string, string>[] items4 = list7._items;
			int version4 = list7._version + 1;
			list7._version = version4;
			int count4 = list7.Count;
			if (list7.Count < items4.Length)
			{
				int size4 = list7.Count + 1;
				list7._size = size4;
				items4[count4] = dictionary;
				text = text6;
				list3 = list7;
			}
			else
			{
				list7.Add(dictionary);
				text = text6;
				list3 = list7;
			}
		}
		enumerator3.Dispose();
		OutOfMemoryException ex4 = new OutOfMemoryException();
		((List<Dictionary<string, string>>.Enumerator*)ex4)->Dispose();
		List<List<Dictionary<string, string>>> result = default(List<List<Dictionary<string, string>>>);
		return result;
	}

	[Token(Token = "0x6000034")]
	[Address(RVA = "0xBF78CC", Offset = "0xBF78CC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CSVHelper()
	{
	}
}
