using System.Collections.Generic;
using System.Text.RegularExpressions;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000008")]
public class CSVReader
{
	[Token(Token = "0x400001D")]
	private static string SPLIT_RE = ",";

	[Token(Token = "0x400001E")]
	private static string LINE_SPLIT_RE = "\\r\\n|\\n\\r|\\n|\\r";

	[Token(Token = "0x400001F")]
	private static char[] TRIM_CHARS = new char[1] { '"' };

	[Token(Token = "0x4000020")]
	private static string comma = "|";

	[Token(Token = "0x6000035")]
	[Address(RVA = "0xBF78D4", Offset = "0xBF78D4", Length = "0x400")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv36 = CSVReader;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv69 = System.Collections.Generic.Dictionary`2<System.String, System.String>;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv254 = Il2CppMethodInfo;\n\tv255 = \"il2cpp_codegen_initialize_runtime_metadata\"(v254, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv309 = Il2CppMethodInfo;\n\tv310 = \"il2cpp_codegen_initialize_runtime_metadata\"(v309, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv320 = System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>;\n\tv321 = \"il2cpp_codegen_initialize_runtime_metadata\"(v320, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv390 = System.Text.RegularExpressions.Regex;\n\tv391 = \"il2cpp_codegen_initialize_runtime_metadata\"(v390, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv393 = \",\";\n\tv394 = \"il2cpp_codegen_initialize_runtime_metadata\"(v393, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv409 = \"\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v409, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A355BC]) = v56;\nL_0039:\n\tv58 = new System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::.ctor(v58);\n\tv77 = UnityEngine.TextAsset::get_text(data);\n\tgoto L_0055;\n\tv311 = v256;\n\tv312 = \"il2cpp_codegen_runtime_class_init\"(v311, v76, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv315 = CSVReader;\nL_0055:\n\tgoto L_005A;\n\tv322 = \"il2cpp_codegen_runtime_class_init\"(v316, v76, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_005A:\n\tv205 = System.Text.RegularExpressions.Regex::Split(v77, v231.LINE_SPLIT_RE);\n\tv407 = v205.Length < 2;\n\tif (v407) goto L_01A1;\n\tgoto L_0079;\n\tv468 = \"il2cpp_codegen_runtime_class_init\"(v410, v195, v169, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv470 = CSVReader;\nL_0079:\n\tgoto L_007F;\n\tv473 = v471;\n\tv474 = \"il2cpp_codegen_runtime_class_init\"(v473, v195, v169, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_007F:\n\tv456 = System.Text.RegularExpressions.Regex::Split(v205[0], v447.SPLIT_RE);\n\tv427 = v205.Length < 2;\n\tif (v427) goto L_01A1;\nL_00A5:\n\tgoto L_00AE;\n\tv496 = \"il2cpp_codegen_runtime_class_init\"(v491, v290, v282, v86, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv498 = CSVReader;\nL_00AE:\n\tgoto L_00B4;\n\tv501 = v232;\n\tv502 = \"il2cpp_codegen_runtime_class_init\"(v501, v290, v282, v86, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_00B4:\n\tv206 = System.Text.RegularExpressions.Regex::Split(v460[v101 @ X28_v6 (System.Int32)], v181.SPLIT_RE);\n\tv506 = v206.Length == 0;\n\tif (v506) goto L_0185;\n\tv517 = v206.Length < 1;\n\tif (v517) goto L_0185;\nL_00D8:\n\tv552 = System.String::Equals(v206[v243 @ X19_v10 (System.Int32)], \"\");\n\tv553 = v552 == 0;\n\tif (v553) goto L_00EF;\n\tv243 = v243 + 1;\n\tv522 = v243 < v206.Length;\n\tif (v522) goto L_00D8;\n\tgoto L_0185;\nL_00EF:\n\tv208 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v208);\n\tv589 = v456.Length < 1;\n\tif (v589) goto L_0162;\nL_0106:\n\t;\n\tv110 = v185 >= v206.Length;\n\tif (v110) goto L_0162;\n\tgoto L_012A;\n\tv636 = \"il2cpp_codegen_runtime_class_init\"(v632, v199, v173, v87, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_012A:\n\tv210 = System.String::TrimStart(v206[v185 @ X26_v13 (System.Int32)], v236.TRIM_CHARS);\n\tv211 = System.String::TrimEnd(v210, v237.TRIM_CHARS);\n\tv212 = System.String::Replace(v211, v641.comma, \",\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v208, v456[v185 @ X26_v13 (System.Int32)], v212);\n\tv185 = v185 + 1;\n\tv592 = v185 < v456.Length;\n\tif (v592) goto L_0106;\nL_0162:\n\tv240 = v58._items;\n\tv84 = v58._version + 1;\n\tv58._version = v84;\n\tv519 = v58._size;\n\tv631 = v58._size < v240.Length;\n\tv545 = ~v631;\n\tif (v545) goto L_0184;\n\tv548 = v58._size + 1;\n\tv58._size = v548;\n\tv240[v519 @ X10_v10 (System.Int32)] = v208;\n\tgoto L_0185;\nL_0184:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::AddWithResize(v58, v208);\nL_0185:\n\t;\n\tv101 = v101 + 1;\n\tv426 = v101 < v460.Length;\n\tif (v426) goto L_00A5;\nL_01A1:\n\treturn v450;\n\tv252 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 323 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static List<Dictionary<string, string>> Read(TextAsset data)
	{
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		string text = data.text;
		string[] array = Regex.Split(text, LINE_SPLIT_RE);
		bool flag = array.Length < 2;
		List<Dictionary<string, string>> result = list;
		if (!flag)
		{
			string[] array2 = Regex.Split(array[0], SPLIT_RE);
			bool flag2 = array.Length < 2;
			result = list;
			if (!flag2)
			{
				int num = 1;
				string[] array3 = array;
				bool flag3;
				do
				{
					string[] array4 = Regex.Split(array3[num], SPLIT_RE);
					if (array4.Length != 0 && array4.Length >= 1)
					{
						int num2 = 0;
						do
						{
							if (array4[num2].Equals(""))
							{
								num2++;
								continue;
							}
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							if (array2.Length >= 1)
							{
								int num3 = 0;
								while (num3 < array4.Length)
								{
									string text2 = array4[num3].TrimStart(TRIM_CHARS);
									string text3 = text2.TrimEnd(TRIM_CHARS);
									string value = text3.Replace(comma, ",");
									dictionary[array2[num3]] = value;
									num3++;
									if (num3 >= array2.Length)
									{
										break;
									}
								}
							}
							Dictionary<string, string>[] items = list._items;
							int version = list._version + 1;
							list._version = version;
							int count = list.Count;
							if (list.Count < items.Length)
							{
								int size = list.Count + 1;
								list._size = size;
								items[count] = dictionary;
								array3 = array;
							}
							else
							{
								list.Add(dictionary);
								array3 = array;
							}
							break;
						}
						while (num2 < array4.Length);
					}
					num++;
					flag3 = num < array3.Length;
					result = list;
				}
				while (flag3);
			}
		}
		return result;
	}

	[Token(Token = "0x6000036")]
	[Address(RVA = "0xBF7CD4", Offset = "0xBF7CD4", Length = "0xB8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = CSVReader;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv43 = UnityEngine.TextAsset;\n\tv36 = \"il2cpp_codegen_initialize_runtime_metadata\"(v43, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv38 = 1;\n\t*([1A355BD]) = v38;\nL_0018:\n\tv41 = UnityEngine.Resources::Load(file);\n\tv44 = CSVReader;\n\tv47 = *([v44 @ X8_v3 (Il2CppClass<CSVReader>)+E0]) == 0;\n\tif (v47) goto L_0024;\n\tv48 = v41 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_0035;\n\tgoto L_FFFFFFFF;\nL_0024:\n\tv54 = v41 == 0;\n\tif (v54) goto L_FFFFFFFF;\nL_0035:\n\tgoto L_FFFFFFFF;\n\tgoto L_0050;\n\tv108 = v108_asT == 0;\n\tif (v108) goto L_FFFFFFFF;\n\tgoto L_0050;\nL_0050:\n\treturnVal1 = CSVReader::ReadPro(v124);\n\treturn returnVal1;\n// 58 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static Dictionary<string, List<string>> ReadPro(string file)
	{
		//IL_00ba: Expected I, but got O
		Object obj = Resources.Load(file);
		nint num = (nint)typeof(CSVReader);
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v44 @ X8_v3 (Il2CppClass<CSVReader>)+E0]");
		if ((nint)0 != 0)
		{
			if ((object)obj == null)
			{
				goto IL_0054;
			}
		}
		else if ((object)obj == null)
		{
			goto IL_0054;
		}
		TextAsset textAsset = obj as TextAsset;
		TextAsset data = (TextAsset)(((object)textAsset == null) ? null : obj);
		goto IL_00df;
		IL_0054:
		data = null;
		goto IL_00df;
		IL_00df:
		return ReadPro(data);
	}

	[Token(Token = "0x6000037")]
	[Address(RVA = "0xBF7D8C", Offset = "0xBF7D8C", Length = "0x46C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv36 = CSVReader;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv69 = Il2CppMethodInfo;\n\tv70 = \"il2cpp_codegen_initialize_runtime_metadata\"(v69, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv267 = Il2CppMethodInfo;\n\tv268 = \"il2cpp_codegen_initialize_runtime_metadata\"(v267, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv339 = System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.String>>;\n\tv340 = \"il2cpp_codegen_initialize_runtime_metadata\"(v339, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv352 = Il2CppMethodInfo;\n\tv353 = \"il2cpp_codegen_initialize_runtime_metadata\"(v352, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv420 = Il2CppMethodInfo;\n\tv421 = \"il2cpp_codegen_initialize_runtime_metadata\"(v420, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv423 = System.Collections.Generic.List`1<System.String>;\n\tv424 = \"il2cpp_codegen_initialize_runtime_metadata\"(v423, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv429 = System.Text.RegularExpressions.Regex;\n\tv430 = \"il2cpp_codegen_initialize_runtime_metadata\"(v429, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv489 = System.String;\n\tv490 = \"il2cpp_codegen_initialize_runtime_metadata\"(v489, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv499 = \",\";\n\tv54 = \"il2cpp_codegen_initialize_runtime_metadata\"(v499, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv56 = 1;\n\t*([1A355BE]) = v56;\nL_003F:\n\tv58 = new System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.String>>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.String>>::.ctor(v58);\n\tv75 = UnityEngine.TextAsset::get_text(data);\n\tgoto L_005B;\n\tv341 = v269;\n\tv342 = \"il2cpp_codegen_runtime_class_init\"(v341, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv345 = CSVReader;\nL_005B:\n\tgoto L_0060;\n\tv354 = \"il2cpp_codegen_runtime_class_init\"(v348, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0060:\n\tv219 = System.Text.RegularExpressions.Regex::Split(v75, v245.LINE_SPLIT_RE);\n\tv120 = v219.Length < 2;\n\tif (v120) goto L_01E1;\n\tgoto L_0081;\n\tv491 = \"il2cpp_codegen_runtime_class_init\"(v431, v208, v189, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv493 = CSVReader;\nL_0081:\n\tgoto L_0087;\n\tv500 = v246;\n\tv501 = \"il2cpp_codegen_runtime_class_init\"(v500, v208, v189, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0087:\n\tv220 = System.Text.RegularExpressions.Regex::Split(v219[0], v202.SPLIT_RE);\n\tv514 = v220.Length < 1;\n\tif (v514) goto L_00FF;\nL_00A0:\n\tv319 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v319);\n\tv96 = v101 << 3;\n\tv581 = v220 + v96;\n\tv92 = v581 + 0x20;\n\tv222 = System.String::Equals(*([v92 @ X29_v10]), v590.Empty);\n\tv596 = v222 == 0;\n\tv325 = ~v596;\n\tif (v325) goto L_00E7;\n\tv320 = System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.String>>::ContainsKey(v58, *([v92 @ X29_v10]));\n\tv679 = v320 == 0;\n\tv326 = ~v679;\n\tif (v326) goto L_00E7;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.String>>::Add(v58, *([v92 @ X29_v10]), v319);\nL_00E7:\n\tv101 = v101 + 1;\n\tv522 = v220.Length != v101;\n\tif (v522) goto L_00A0;\nL_00FF:\n\tv456 = v219.Length <= 1;\n\tif (v456) goto L_01E1;\nL_011A:\n\tgoto L_0125;\n\tv582 = \"il2cpp_codegen_runtime_class_init\"(v576, v317, v310, v88, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv584 = CSVReader;\nL_0125:\n\tgoto L_012B;\n\tv591 = v249;\n\tv592 = \"il2cpp_codegen_runtime_class_init\"(v591, v317, v310, v88, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_012B:\n\tv223 = System.Text.RegularExpressions.Regex::Split(v219[v112 @ X26_v7 (System.Int32)], v203.SPLIT_RE);\n\tv614 = v223.Length == 0;\n\tif (v614) goto L_01C6;\n\tv626 = v220.Length < 1;\n\tif (v626) goto L_01C6;\n\tv632 = v223.Length < 1;\n\tif (v632) goto L_01C6;\nL_015E:\n\tgoto L_0167;\n\tv695 = \"il2cpp_codegen_runtime_class_init\"(v692, v213, v194, v89, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\nL_0167:\n\tv225 = System.String::TrimStart(v223[v313 @ X9_v15 (System.Int32)], v251.TRIM_CHARS);\n\tv226 = System.String::TrimEnd(v225, v252.TRIM_CHARS);\n\tv227 = System.String::Replace(v226, v700.comma, \",\");\n\tv228 = System.Collections.Generic.Dictionary`2<System.String, System.Collections.Generic.List`1<System.String>>::get_Item(v58, v220[v313 @ X9_v15 (System.Int32)]);\n\tv255 = v228._items;\n\tv85 = v228._version + 1;\n\tv228._version = v85;\n\tv628 = v228._size;\n\tv704 = v228._size < v255.Length;\n\tv705 = ~v704;\n\tif (v705) goto L_01AA;\n\tv713 = v228._size + 1;\n\tv228._size = v713;\n\tv255[v628 @ X10_v11 (System.Int32)] = v227;\n\tgoto L_01AC;\nL_01AA:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v228, v227);\nL_01AC:\n\tv313 = v313 + 1;\n\tv633 = v313 >= v220.Length;\n\tif (v633) goto L_01C6;\n\tv631 = v313 < v223.Length;\n\tif (v631) goto L_015E;\nL_01C6:\n\tv112 = v112 + 1;\n\tv455 = v112 < v219.Length;\n\tif (v455) goto L_011A;\nL_01E1:\n\treturn v58;\n\tv265 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 375 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static Dictionary<string, List<string>> ReadPro(TextAsset data)
	{
		//IL_00bc: Expected O, but got I
		//IL_00cb: Expected O, but got I
		Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
		string text = data.text;
		string[] array = Regex.Split(text, LINE_SPLIT_RE);
		if (array.Length >= 2)
		{
			string[] array2 = Regex.Split(array[0], SPLIT_RE);
			if (array2.Length >= 1)
			{
				int num = 0;
				do
				{
					List<string> value = new List<string>();
					int num2 = num << 3;
					object obj = (nint)array2 + num2;
					object obj2 = (nint)obj + 32;
					if (!((string)obj2).Equals(string.Empty) && !dictionary.ContainsKey((string)obj2))
					{
						dictionary.Add((string)obj2, value);
					}
					num++;
				}
				while (array2.Length != num);
			}
			if (array.Length > 1)
			{
				int num3 = 1;
				do
				{
					string[] array3 = Regex.Split(array[num3], SPLIT_RE);
					if (array3.Length != 0 && array2.Length >= 1 && array3.Length >= 1)
					{
						int num4 = 0;
						do
						{
							string text2 = array3[num4].TrimStart(TRIM_CHARS);
							string text3 = text2.TrimEnd(TRIM_CHARS);
							string text4 = text3.Replace(comma, ",");
							List<string> list = dictionary[array2[num4]];
							string[] items = list._items;
							int version = list._version + 1;
							list._version = version;
							int count = list.Count;
							if (list.Count < items.Length)
							{
								int size = list.Count + 1;
								list._size = size;
								items[count] = text4;
							}
							else
							{
								list.Add(text4);
							}
							num4++;
						}
						while (num4 < array2.Length && num4 < array3.Length);
					}
					num3++;
				}
				while (num3 < array.Length);
			}
		}
		return dictionary;
	}

	[Token(Token = "0x6000038")]
	[Address(RVA = "0xBF81F8", Offset = "0xBF81F8", Length = "0x70")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = CSVReader;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, lowerCaseKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 1;\n\t*([1A355BF]) = v40;\nL_0019:\n\tgoto L_0026;\n\tv45 = \"il2cpp_codegen_runtime_class_init\"(v41, lowerCaseKey, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv47 = CSVReader;\nL_0026:\n\treturnVal1 = CSVReader::ReadSpecialSplit(content, lowerCaseKey, v48.SPLIT_RE);\n\treturn returnVal1;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static List<Dictionary<string, string>> Read(string content, bool lowerCaseKey = false)
	{
		return ReadSpecialSplit(content, lowerCaseKey, SPLIT_RE);
	}

	[Token(Token = "0x6000039")]
	[Address(RVA = "0xBF8268", Offset = "0xBF8268", Length = "0x3E8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003F;\n\tv42 = CSVReader;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv66 = Il2CppMethodInfo;\n\tv67 = \"il2cpp_codegen_initialize_runtime_metadata\"(v66, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv78 = System.Collections.Generic.Dictionary`2<System.String, System.String>;\n\tv79 = \"il2cpp_codegen_initialize_runtime_metadata\"(v78, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv90 = Il2CppMethodInfo;\n\tv91 = \"il2cpp_codegen_initialize_runtime_metadata\"(v90, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv100 = Il2CppMethodInfo;\n\tv101 = \"il2cpp_codegen_initialize_runtime_metadata\"(v100, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv104 = System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>;\n\tv105 = \"il2cpp_codegen_initialize_runtime_metadata\"(v104, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv292 = System.Text.RegularExpressions.Regex;\n\tv293 = \"il2cpp_codegen_initialize_runtime_metadata\"(v292, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv426 = \",\";\n\tv427 = \"il2cpp_codegen_initialize_runtime_metadata\"(v426, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv464 = \"\";\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v464, lowerCaseKey, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv60 = 1;\n\t*([1A355C0]) = v60;\nL_003F:\n\tv64 = new System.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>();\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::.ctor(v64);\n\tgoto L_0050;\n\tv80 = \"il2cpp_codegen_runtime_class_init\"(v73, v68, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\n\tv82 = CSVReader;\nL_0050:\n\tgoto L_0056;\n\tv92 = v83;\n\tv93 = \"il2cpp_codegen_runtime_class_init\"(v92, v68, keySplit, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0056:\n\tv98 = System.Text.RegularExpressions.Regex::Split(content, v84.LINE_SPLIT_RE);\n\tv118 = v98.Length < 2;\n\tif (v118) goto L_019B;\n\tgoto L_0071;\n\tv428 = \"il2cpp_codegen_runtime_class_init\"(v294, v96, v97, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0071:\n\tv352 = System.Text.RegularExpressions.Regex::Split(v98[0], keySplit);\n\tv319 = v98.Length < 2;\n\tif (v319) goto L_019B;\nL_0097:\n\tgoto L_009C;\n\tv482 = \"il2cpp_codegen_runtime_class_init\"(v479, v405, v403, v126, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_009C:\n\tv240 = System.Text.RegularExpressions.Regex::Split(v98[v149 @ X28_v6 (System.Int32)], v356);\n\tv486 = v240.Length == 0;\n\tif (v486) goto L_0180;\n\tv497 = v240.Length < 1;\n\tif (v497) goto L_0180;\nL_00C0:\n\tv531 = System.String::Equals(v240[v282 @ X20_v10 (System.Int32)], \"\");\n\tv532 = v531 == 0;\n\tif (v532) goto L_00D6;\n\tv282 = v282 + 1;\n\tv503 = v282 < v240.Length;\n\tif (v503) goto L_00C0;\n\tgoto L_0180;\nL_00D6:\n\tv242 = new System.Collections.Generic.Dictionary`2<System.String, System.String>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::.ctor(v242);\n\tv568 = v352.Length < 1;\n\tif (v568) goto L_015E;\nL_00F7:\n\tv158 = v288 >= v240.Length;\n\tif (v158) goto L_015E;\n\tgoto L_0111;\n\tv622 = \"il2cpp_codegen_runtime_class_init\"(v612, v231, v220, v127, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56);\nL_0111:\n\tv244 = System.String::TrimStart(v240[v288 @ X21_v11 (System.Int32)], v273.TRIM_CHARS);\n\tv245 = System.String::TrimEnd(v244, v274.TRIM_CHARS);\n\tv410 = System.String::Replace(v245, v627.comma, \",\");\n\tv632 = lowerCaseKey == 0;\n\tif (v632) goto L_013C;\n\tv247 = System.String::ToLower(v352[v288 @ X21_v11 (System.Int32)]);\nL_013C:\n\tv248 = System.String::TrimStart(v247, 0x20);\n\tv249 = System.String::TrimEnd(v248, 0x20);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.String>::set_Item(v242, v249, v410);\n\tv288 = v288 + 1;\n\tv571 = v288 < v352.Length;\n\tif (v571) goto L_00F7;\nL_015E:\n\tv277 = v64._items;\n\tv124 = v64._version + 1;\n\tv64._version = v124;\n\tv499 = v64._size;\n\tv611 = v64._size < v277.Length;\n\tv526 = ~v611;\n\tif (v526) goto L_017D;\n\tv615 = v64._size + 1;\n\tv64._size = v615;\n\tv277[v499 @ X10_v9 (System.Int32)] = v242;\n\tgoto L_FFFFFFFF;\nL_017D:\n\tSystem.Collections.Generic.List`1<System.Collections.Generic.Dictionary`2<System.String, System.String>>::AddWithResize(v64, v242);\nL_0180:\n\tv149 = v149 + 1;\n\tv318 = v149 < v98.Length;\n\tif (v318) goto L_0097;\nL_019B:\n\treturn v64;\n\tv290 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 323 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static List<Dictionary<string, string>> ReadSpecialSplit(string content, bool lowerCaseKey = false, string keySplit = ",")
	{
		List<Dictionary<string, string>> list = new List<Dictionary<string, string>>();
		string[] array = Regex.Split(content, LINE_SPLIT_RE);
		if (array.Length >= 2)
		{
			string[] array2 = Regex.Split(array[0], keySplit);
			if (array.Length >= 2)
			{
				int num = 1;
				string pattern = keySplit;
				do
				{
					string[] array3 = Regex.Split(array[num], pattern);
					if (array3.Length != 0 && array3.Length >= 1)
					{
						int num2 = 0;
						do
						{
							if (array3[num2].Equals(""))
							{
								num2++;
								continue;
							}
							Dictionary<string, string> dictionary = new Dictionary<string, string>();
							if (array2.Length >= 1)
							{
								int num3 = 0;
								while (num3 < array3.Length)
								{
									string text = array3[num3].TrimStart(TRIM_CHARS);
									string text2 = text.TrimEnd(TRIM_CHARS);
									string value = text2.Replace(comma, ",");
									bool flag = !lowerCaseKey;
									string text3 = array2[num3];
									if (!flag)
									{
										text3 = array2[num3].ToLower();
									}
									string text4 = text3.TrimStart(' ');
									string key = text4.TrimEnd(' ');
									dictionary[key] = value;
									num3++;
									if (num3 >= array2.Length)
									{
										break;
									}
								}
							}
							Dictionary<string, string>[] items = list._items;
							int version = list._version + 1;
							list._version = version;
							int count = list.Count;
							if (list.Count < items.Length)
							{
								int size = list.Count + 1;
								list._size = size;
								items[count] = dictionary;
							}
							else
							{
								list.Add(dictionary);
							}
							pattern = keySplit;
							break;
						}
						while (num2 < array3.Length);
					}
					num++;
				}
				while (num < array.Length);
			}
		}
		return list;
	}

	[Token(Token = "0x600003A")]
	[Address(RVA = "0xBF8650", Offset = "0xBF8650", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CSVReader()
	{
	}
}
