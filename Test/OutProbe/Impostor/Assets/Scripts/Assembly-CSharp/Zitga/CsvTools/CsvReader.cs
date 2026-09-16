using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Zitga.CsvTools
{
	[Token(Token = "0x200003C")]
	public static class CsvReader
	{
		[Token(Token = "0x600017D")]
		[Address(RVA = "0xDA7AC8", Offset = "0xDA7AC8", Length = "0xE0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tgoto L_001E;\n\tv36 = 0xB3490C(methodInfo, separator, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_001E:\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v45, separator, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0022:\n\tv54 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv60 = Zitga.CsvTools.CsvReader::ParseCsv(text, separator);\n\tv64 = Zitga.CsvTools.CsvReader::CreateArray(v54, v60);\n\tgoto L_0037;\n\tv72 = v67;\n\tv73 = 0xB348B0(v72, v61, v63, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv76 = v73;\nL_0037:\n\tv77 = v64 == 0;\n\tif (v77) goto L_FFFFFFFF;\n\t// 59 IsInst returnVal1 @ X0_v11 (T[]), typeof(T[]), v64 @ X0_v9 (System.Object)\n\tv88 = returnVal1 == 0;\n\tv86 = ~v88;\n\tif (v86) goto L_0049;\n\tthrow System.InvalidCastException;\nL_0049:\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T[] Deserialize<T>(string text, char separator = ',')
		{
			Type typeFromHandle = typeof(T);
			List<string[]> rows = ParseCsv(text, separator);
			object obj = CreateArray(typeFromHandle, rows);
			T[] array;
			if (obj != null)
			{
				array = obj as T[];
				if (array == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				array = null;
			}
			return array;
		}

		[Token(Token = "0x600017E")]
		[Address(RVA = "0xDA7A0C", Offset = "0xDA7A0C", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_001C;\n\tv33 = 0xB3490C(methodInfo, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001C:\n\tgoto L_0020;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0020:\n\tv51 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv55 = Zitga.CsvTools.CsvReader::CreateArray(v51, rows);\n\tgoto L_002F;\n\tv63 = v58;\n\tv64 = 0xB348B0(v63, v53, v54, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv67 = v64;\nL_002F:\n\tv68 = v55 == 0;\n\tif (v68) goto L_FFFFFFFF;\n\t// 51 IsInst returnVal1 @ X0_v8 (T[]), typeof(T[]), v55 @ X0_v6 (System.Object)\n\tv79 = returnVal1 == 0;\n\tv77 = ~v79;\n\tif (v77) goto L_0040;\n\tthrow System.InvalidCastException;\nL_0040:\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T[] Deserialize<T>(List<string[]> rows)
		{
			Type typeFromHandle = typeof(T);
			object obj = CreateArray(typeFromHandle, rows);
			T[] array;
			if (obj != null)
			{
				array = obj as T[];
				if (array == null)
				{
					throw new InvalidCastException();
				}
			}
			else
			{
				array = null;
			}
			return array;
		}

		[Token(Token = "0x600017F")]
		[Address(RVA = "0xDA7CD4", Offset = "0xDA7CD4", Length = "0x144")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-60_v2;\n\t*([v22 @ X29_v1-8]) = *([v25 @ SYSREG+28]);\n\tv58 = *([v28 @ X4+38]);\n\tv38 = *([v28 @ X4+38]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0025;\n\tv58 = *([v28 @ X4+38]);\n\tv76 = *([v28 @ X4+38]) == 0;\n\tv57 = ~v76;\n\tif (v57) goto L_0025;\n\tv55 = 0xB3490C(v28, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv58 = *([v28 @ X4+38]);\nL_0025:\n\tv62 = *([v58 @ X8_v3+8]);\n\tv66 = *([v62 @ X9_v1+FC]) + 0xF;\n\tv67 = v66 & 0x1FFFFFFF0;\n\tv68 = &v65 @ stack_-70_v1 - v67;\n\tgoto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v72, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0036:\n\tv81 = System.Type::GetTypeFromHandle(*([v58 @ X8_v3]));\n\tv87 = Zitga.CsvTools.CsvReader::ParseCsv(text, 0x2C);\n\tv93 = Zitga.CsvTools.CsvReader::CreateIdValue(v81, v87, id_col, value_col);\n\tv94 = *([v28 @ X4+38]);\n\tv103 = *([v94 @ X8_v4+8]);\n\tv98 = *([v103 @ X1_v5+135]) & 1;\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_004F;\n\tv102 = 0xB348B0(v103, v103, id_col, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_004F:\n\tv108 = 0xAD95AC(v93, v103, v68, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = 0x1854F10(methodInfo, v108, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv124 = *([v25 @ SYSREG+28]) != *([v22 @ X29_v1-8]);\n\tif (v124) goto L_006F;\n\treturn returnVal1;\nL_006F:\n\treturnVal2 = 0x1854EB0(returnVal1, v108, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T DeserializeIdValue<T>(string text, int id_col = 0, int value_col = 1)
		{
			//IL_0025: Expected O, but got I
			//IL_0199: Expected O, but got I
			//IL_01af: Expected O, but got I
			//IL_01c2: Expected I4, but got I8
			//IL_01d0: Expected O, but got I
			//IL_0065: Expected O, but got I
			//IL_0106: Expected O, but got I
			//IL_0116: Expected O, but got I
			//IL_00b4: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
			object handle = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
				handle = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
				if ((nint)0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
					handle = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v3+8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X9_v1+FC]");
			object obj4 = (nint)0 + (nint)15;
			int num = (int)((nint)obj4 & 0x1FFFFFFF0L);
			object obj6 = default(object);
			object obj5 = (nint)obj6 - num;
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)handle);
			List<string[]> rows = ParseCsv(text);
			object obj7 = CreateIdValue(typeFromHandle, rows, id_col, value_col);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v94 @ X8_v4+8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v103 @ X1_v5+135]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B348B0");
				object obj10 = default(object);
				obj9 = obj10;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD95AC");
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-8]");
			T result = default(T);
			if (num2 == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			T result2 = default(T);
			return result2;
		}

		[Token(Token = "0x6000180")]
		[Address(RVA = "0xDA7BA8", Offset = "0xDA7BA8", Length = "0x12C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-60_v2;\n\t*([v22 @ X29_v1-8]) = *([v25 @ SYSREG+28]);\n\tv58 = *([v28 @ X4+38]);\n\tv38 = *([v28 @ X4+38]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0025;\n\tv58 = *([v28 @ X4+38]);\n\tv76 = *([v28 @ X4+38]) == 0;\n\tv57 = ~v76;\n\tif (v57) goto L_0025;\n\tv55 = 0xB3490C(v28, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv58 = *([v28 @ X4+38]);\nL_0025:\n\tv62 = *([v58 @ X8_v3+8]);\n\tv66 = *([v62 @ X9_v1+FC]) + 0xF;\n\tv67 = v66 & 0x1FFFFFFF0;\n\tv68 = &v65 @ stack_-70_v1 - v67;\n\tgoto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v72, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0036:\n\tv81 = System.Type::GetTypeFromHandle(*([v58 @ X8_v3]));\n\tv87 = Zitga.CsvTools.CsvReader::CreateIdValue(v81, rows, id_col, value_col);\n\tv88 = *([v28 @ X4+38]);\n\tv97 = *([v88 @ X8_v4+8]);\n\tv92 = *([v97 @ X1_v4+135]) & 1;\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0049;\n\tv96 = 0xB348B0(v97, v97, id_col, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0049:\n\tv102 = 0xAD95AC(v87, v97, v68, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = 0x1854F10(methodInfo, v102, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv118 = *([v25 @ SYSREG+28]) != *([v22 @ X29_v1-8]);\n\tif (v118) goto L_0069;\n\treturn returnVal1;\nL_0069:\n\treturnVal2 = 0x1854EB0(returnVal1, v102, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal2;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static T DeserializeIdValue<T>(List<string[]> rows, int id_col = 0, int value_col = 1)
		{
			//IL_0025: Expected O, but got I
			//IL_0187: Expected O, but got I
			//IL_019d: Expected O, but got I
			//IL_01b0: Expected I4, but got I8
			//IL_01be: Expected O, but got I
			//IL_0065: Expected O, but got I
			//IL_00f4: Expected O, but got I
			//IL_0104: Expected O, but got I
			//IL_00b4: Expected O, but got I
			object obj2 = default(object);
			object obj = obj2;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
			object handle = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
			if ((nint)0 == 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
				handle = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
				if ((nint)0 == 0)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B3490C");
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
					handle = 0;
				}
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v58 @ X8_v3+8]");
			object obj3 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v62 @ X9_v1+FC]");
			object obj4 = (nint)0 + (nint)15;
			int num = (int)((nint)obj4 & 0x1FFFFFFF0L);
			object obj6 = default(object);
			object obj5 = (nint)obj6 - num;
			Type typeFromHandle = Type.GetTypeFromHandle((RuntimeTypeHandle)handle);
			object obj7 = CreateIdValue(typeFromHandle, rows, id_col, value_col);
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v28 @ X4+38]");
			object obj8 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v88 @ X8_v4+8]");
			object obj9 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v97 @ X1_v4+135]");
			if ((int)((nint)0 & (nint)1) == 0)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @B348B0");
				object obj10 = default(object);
				obj9 = obj10;
			}
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD95AC");
			Il2CppRuntime.Boundary("SYSTEM_API:memcpy", "Method not found @1854F10 (native memcpy)");
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v25 @ SYSREG+28]");
			nint num2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v22 @ X29_v1-8]");
			T result = default(T);
			if (num2 == 0)
			{
				return result;
			}
			Il2CppRuntime.Boundary("SYSTEM_API:__stack_chk_fail", "Method not found @1854EB0 (native __stack_chk_fail)");
			T result2 = default(T);
			return result2;
		}

		[Token(Token = "0x6000181")]
		[Address(RVA = "0xC03400", Offset = "0xC03400", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0031;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, rows, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, rows, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv73 = Il2CppMethodInfo;\n\tv74 = \"il2cpp_codegen_initialize_runtime_metadata\"(v73, rows, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv80 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, rows, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv85 = Il2CppMethodInfo;\n\tv86 = \"il2cpp_codegen_initialize_runtime_metadata\"(v85, rows, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv89 = Il2CppMethodInfo;\n\tv55 = \"il2cpp_codegen_initialize_runtime_metadata\"(v89, rows, methodInfo, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv57 = 1;\n\t*([1A35647]) = v57;\nL_0031:\n\tv62 = Zitga.CsvTools.CsvReader::CountNumberElement(1, 0, 0, rows);\n\tv71 = System.Array::CreateInstance(type, v62);\n\tv78 = new System.Collections.Generic.Dictionary`2<System.String, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::.ctor(v78);\n\tv214 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, 0);\nL_0058:\n\tv100 = v173 >= v214.Length;\n\tif (v100) goto L_0092;\n\tv196 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, 0);\n\tv339 = Zitga.CsvTools.CsvReader::IsValidKeyFormat(v196[v173 @ X24_v9 (System.Int32)]);\n\tv353 = v339 == 0;\n\tif (v353) goto L_FFFFFFFF;\n\tv197 = Zitga.CsvTools.CsvReader::ConvertSnakeCaseToCamelCase(v196[v173 @ X24_v9 (System.Int32)]);\n\tv371 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::ContainsKey(v78, v197);\n\tv376 = v371 == 0;\n\tv366 = ~v376;\n\tif (v366) goto L_FFFFFFFF;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::Add(v78, v197, v173);\n\tv173 = v173 + 1;\n\tv214 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, 0);\n\tv387 = v214 == 0;\n\tv201 = ~v387;\n\tif (v201) goto L_0058;\n\tv211 = new System.NullReferenceException();\nL_0092:\n\tv222 = System.Array::get_Length(v71);\n\tv245 = v222 < 1;\n\tif (v245) goto L_00D0;\nL_00A7:\n\tv337 = System.Collections.Generic.List`1<System.Int32>::get_Item(0, v175);\n\tv351 = Zitga.CsvTools.CsvReader::Create(v337, 0, rows, v78, type);\n\tSystem.Array::SetValue(v71, v351, v175);\n\tv175 = v175 + 1;\n\tv277 = System.Array::get_Length(v71);\n\tv251 = v175 < v277;\n\tif (v251) goto L_00A7;\nL_00D0:\n\treturn v71;\n\tgoto L_00D9;\nL_00D9:\n\tv374 = System.String::Concat(v364, v196[v173 @ X24_v9 (System.Int32)]);\n\tv384 = new System.Exception();\n\tSystem.Exception::.ctor(v384, v374);\n\tthrow v384;\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 179 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static object CreateArray(Type type, List<string[]> rows)
		{
			//IL_0251: Expected I4, but got O
			(int, List<int>) tuple = CountNumberElement(1, 0, 0, rows);
			Array array = Array.CreateInstance(type, (int)tuple);
			Dictionary<string, int> dictionary = new Dictionary<string, int>();
			string[] array2 = rows[0];
			int num = 0;
			string[] array3;
			string text;
			while (true)
			{
				if (num < array2.Length)
				{
					array3 = rows[0];
					if (!IsValidKeyFormat(array3[num]))
					{
						text = "Key is not valid: ";
						break;
					}
					string key = ConvertSnakeCaseToCamelCase(array3[num]);
					if (dictionary.ContainsKey(key))
					{
						text = "Key is duplicate: ";
						break;
					}
					dictionary.Add(key, num);
					num++;
					array2 = rows[0];
					if (array2 != null)
					{
						continue;
					}
					NullReferenceException ex = new NullReferenceException();
				}
				int length = array.Length;
				if (length >= 1)
				{
					int num2 = 0;
					int length2;
					do
					{
						int index = ((List<int>)null)[num2];
						object value = Create(index, 0, rows, dictionary, type);
						array.SetValue(value, num2);
						num2++;
						length2 = array.Length;
					}
					while (num2 < length2);
				}
				return array;
			}
			string message = text + array3[num];
			Exception ex2 = new Exception(message);
			throw ex2;
		}

		[Token(Token = "0x6000182")]
		[Address(RVA = "0xC03A88", Offset = "0xC03A88", Length = "0x3AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv38 = Il2CppMethodInfo;\n\tv39 = \"il2cpp_codegen_initialize_runtime_metadata\"(v38, parentIndex, rows, table, type, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv60 = Il2CppMethodInfo;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v60, parentIndex, rows, table, type, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv65 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, parentIndex, rows, table, type, methodInfo, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv55 = 1;\n\t*([1A35648]) = v55;\nL_0024:\n\tv58 = System.Activator::CreateInstance(v482);\n\tv71 = System.Type::GetFields(v482, 0x34);\n\tv149 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, index);\n\tv274 = v71.Length < 1;\n\tif (v274) goto L_011D;\nL_005B:\n\tv150 = Zitga.CsvTools.CsvReader::IsPrimitive(v333[v95 @ X29_v8 (System.Int32)]);\n\tv433 = v150 == 0;\n\tif (v433) goto L_0095;\n\tv151 = System.Reflection.MemberInfo::get_Name(v333[v95 @ X29_v8 (System.Int32)]);\n\tv453 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::ContainsKey(v287, v151);\n\tv253 = System.Reflection.MemberInfo::get_Name(v333[v95 @ X29_v8 (System.Int32)]);\n\tv255 = v453 == 0;\n\tif (v255) goto L_0125;\n\tv321 = *([v337 @ X22_v11 (Il2CppMethodInfo)]);\n\tv152 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::get_Item(v287, v253);\n\tv196 = v152 >= v149.Length;\n\tif (v196) goto L_0101;\n\tZitga.CsvTools.CsvReader::SetValue(v58, v333[v95 @ X29_v8 (System.Int32)], v299[v152 @ X0_v80 (System.Int32)]);\n\tgoto L_0101;\nL_0095:\n\tv153 = System.Reflection.FieldInfo::get_FieldType(v333[v95 @ X29_v8 (System.Int32)]);\n\tv455 = System.Type::get_IsArray(v153);\n\tv460 = v455 == 0;\n\tif (v460) goto L_00E9;\n\tv466 = Zitga.CsvTools.CsvReader::GetElementTypeFromFieldInfo(v333[v95 @ X29_v8 (System.Int32)]);\n\tv471 = Zitga.CsvTools.CsvReader::GetObjectIndex(v466, v287);\n\tv478 = Zitga.CsvTools.CsvReader::CountNumberRowElement(index, v471, v130, rows);\n\tv154 = System.Array::CreateInstance(v466, v478);\n\tv533 = System.Array::get_Length(v154);\n\tv544 = v533 < 1;\n\tif (v544) goto L_00DE;\nL_00C4:\n\tv584 = Zitga.CsvTools.CsvReader::CreateRow(index, v568, rows, v567, v466);\n\tSystem.Array::SetValue(v154, v584, v568);\n\tv568 = v568 + 1;\n\tv565 = System.Array::get_Length(v154);\n\tv551 = v568 < v565;\n\tif (v551) goto L_00C4;\nL_00DE:\n\tSystem.Reflection.FieldInfo::SetValue(v333[v95 @ X29_v8 (System.Int32)], v58, v154);\n\tgoto L_0101;\nL_00E9:\n\tv155 = System.Reflection.FieldInfo::get_FieldType(v333[v95 @ X29_v8 (System.Int32)]);\n\tv445 = System.Type::get_FullName(v155);\n\tv446 = v445 == 0;\n\tif (v446) goto L_0138;\n\tv479 = Zitga.CsvTools.CsvReader::GetType(v445);\n\tv525 = Zitga.CsvTools.CsvReader::GetObjectIndex(v479, v287);\n\tv530 = Zitga.CsvTools.CsvReader::Create(index, v525, rows, v287, v479);\n\tSystem.Reflection.FieldInfo::SetValue(v333[v95 @ X29_v8 (System.Int32)], v58, v530);\nL_0101:\n\t;\n\tv95 = v95 + 1;\n\tv303 = v95 < v333.Length;\n\tif (v303) goto L_005B;\nL_011D:\n\treturn v58;\n\tv180 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0125:\n\tv277 = System.String::Concat(\"Key is not exist: \", v230);\n\tv424 = new System.Exception();\n\tSystem.Exception::.ctor(v424, v277);\n\tthrow v424;\nL_0138:\n\tv456 = new System.Exception();\n\tSystem.Exception::.ctor(v456, \"Full name is nil\");\n\tthrow v456;\n\treturn returnVal2;\n// 258 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static object Create(int index, int parentIndex, List<string[]> rows, Dictionary<string, int> table, Type type)
		{
			//IL_0227: Expected I4, but got O
			//IL_011d: Expected O, but got I
			//IL_03b1: Expected I4, but got O
			Type type2 = default(Type);
			object obj = Activator.CreateInstance(type2);
			FieldInfo[] fields = type2.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			string[] array = rows[index];
			if (fields.Length >= 1)
			{
				int num = 0;
				string[] array2 = array;
				int parentIndex2 = 0;
				FieldInfo[] array3 = fields;
				nint num2 = 0;
				Dictionary<string, int> dictionary = default(Dictionary<string, int>);
				string text = default(string);
				bool flag3;
				do
				{
					string text2;
					if (IsPrimitive(array3[num]))
					{
						string name = array3[num].Name;
						bool flag = dictionary.ContainsKey(name);
						string name2 = array3[num].Name;
						if (!flag)
						{
							string message = "Key is not exist: " + text;
							Exception ex = new Exception(message);
							throw ex;
						}
						text2 = (string)num2;
						int num3 = dictionary[name2];
						if (num3 < array.Length)
						{
							SetValue(obj, array3[num], array2[num3]);
							text2 = array2[num3];
						}
					}
					else
					{
						Type fieldType = array3[num].FieldType;
						if (fieldType.IsArray)
						{
							Type elementTypeFromFieldInfo = GetElementTypeFromFieldInfo(array3[num]);
							int objectIndex = GetObjectIndex(elementTypeFromFieldInfo, dictionary);
							(int, List<int>) tuple = CountNumberRowElement(index, objectIndex, parentIndex2, rows);
							Array array4 = Array.CreateInstance(elementTypeFromFieldInfo, (int)tuple);
							int length = array4.Length;
							if (length >= 1)
							{
								Dictionary<string, int> table2 = (Dictionary<string, int>)(object)rows;
								int num4 = 0;
								bool flag2;
								do
								{
									object value = CreateRow(index, num4, rows, table2, elementTypeFromFieldInfo);
									array4.SetValue(value, num4);
									num4++;
									int length2 = array4.Length;
									flag2 = num4 < length2;
									type2 = elementTypeFromFieldInfo;
									table2 = null;
								}
								while (flag2);
							}
							array3[num].SetValue(obj, array4);
							dictionary = null;
							text2 = (string)(object)array4;
							array3 = fields;
						}
						else
						{
							Type fieldType2 = array3[num].FieldType;
							string fullName = fieldType2.FullName;
							if (fullName == null)
							{
								Exception ex2 = new Exception("Full name is nil");
								throw ex2;
							}
							Type type3 = GetType(fullName);
							int objectIndex2 = GetObjectIndex(type3, dictionary);
							object obj2 = Create(index, objectIndex2, rows, dictionary, type3);
							array3[num].SetValue(obj, obj2);
							type2 = type3;
							dictionary = null;
							text2 = (string)obj2;
						}
					}
					num++;
					flag3 = num < array3.Length;
					parentIndex2 = (int)text2;
				}
				while (flag3);
			}
			return obj;
		}

		[Token(Token = "0x6000183")]
		[Address(RVA = "0xC048E0", Offset = "0xC048E0", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv34 = Il2CppMethodInfo;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, idx, rows, table, type, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 1;\n\t*([1A35649]) = v50;\nL_001C:\n\tv53 = System.Activator::CreateInstance(type);\n\tv61 = System.Type::GetFields(type, 0x34);\n\tv121 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, index);\n\tv205 = v61.Length < 1;\n\tif (v205) goto L_008E;\n\tv73 = idx + 3;\n\tv70 = v73 << 3;\n\tv114 = v121 + v70;\n\tv66 = v114 + 0x20;\nL_0052:\n\tv122 = Zitga.CsvTools.CsvReader::IsPrimitive(v61[v68 @ X24_v5 (System.Int32)]);\n\tv255 = v122 == 0;\n\tif (v255) goto L_0075;\n\tv243 = v121.Length <= idx;\n\tif (v243) goto L_0075;\n\tZitga.CsvTools.CsvReader::SetValue(v53, v61[v68 @ X24_v5 (System.Int32)], *([v66 @ X26_v4]));\nL_0075:\n\tv68 = v68 + 1;\n\tv213 = v68 < v61.Length;\n\tif (v213) goto L_0052;\nL_008E:\n\treturn v53;\n\tv120 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static object CreateRow(int index, int idx, List<string[]> rows, Dictionary<string, int> table, Type type)
		{
			//IL_007b: Expected O, but got I
			//IL_008a: Expected O, but got I
			object obj = Activator.CreateInstance(type);
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			string[] array = rows[index];
			if (fields.Length >= 1)
			{
				int num = idx + 3;
				int num2 = num << 3;
				object obj2 = (nint)array + num2;
				object value = (nint)obj2 + 32;
				int num3 = 0;
				do
				{
					if (IsPrimitive(fields[num3]) && array.Length > idx)
					{
						SetValue(obj, fields[num3], (string)value);
					}
					num3++;
				}
				while (num3 < fields.Length);
			}
			return obj;
		}

		[Token(Token = "0x6000184")]
		[Address(RVA = "0xC03E8C", Offset = "0xC03E8C", Length = "0x61C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003E;\n\tv36 = System.Char[];\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv59 = System.Convert;\n\tv60 = \"il2cpp_codegen_initialize_runtime_metadata\"(v59, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv64 = System.Enum;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv141 = System.Int16;\n\tv142 = \"il2cpp_codegen_initialize_runtime_metadata\"(v141, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv338 = System.Int32;\n\tv339 = \"il2cpp_codegen_initialize_runtime_metadata\"(v338, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv374 = System.Int32;\n\tv375 = \"il2cpp_codegen_initialize_runtime_metadata\"(v374, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv392 = System.Int64;\n\tv393 = \"il2cpp_codegen_initialize_runtime_metadata\"(v392, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv397 = System.Single;\n\tv398 = \"il2cpp_codegen_initialize_runtime_metadata\"(v397, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv407 = System.Single;\n\tv408 = \"il2cpp_codegen_initialize_runtime_metadata\"(v407, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv422 = System.String;\n\tv423 = \"il2cpp_codegen_initialize_runtime_metadata\"(v422, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv436 = System.String;\n\tv437 = \"il2cpp_codegen_initialize_runtime_metadata\"(v436, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv468 = System.Type;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v468, fieldInfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A3564A]) = v54;\nL_003E:\n\tv57 = System.String::IsNullOrEmpty(value);\n\tv62 = v57 == 0;\n\tif (v62) goto L_0056;\nL_004F:\n\treturn;\nL_0056:\n\tv234 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tv341 = System.Type::get_IsArray(v234);\n\tv306 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tv395 = v341 == 0;\n\tif (v395) goto L_00EE;\n\tv400 = System.Type::GetElementType(v306);\n\t// 112 NewArr v307 @ X0_v99 (System.Char[]), typeof(System.Char[]), 2\n\tv307[0] = 0x2C;\n\tv307[1] = 0x7E;\n\tv308 = System.String::Split(value, v307);\n\tv573 = System.Array::CreateInstance(v400, v308.Length);\n\tv589 = v308.Length < 1;\n\tif (v589) goto L_FFFFFFFF;\nL_00AC:\n\tgoto L_00B0;\n\tv702 = \"il2cpp_codegen_runtime_class_init\"(v680, v675, v666, v237, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00B0:\n\tv706 = System.Type::GetTypeFromHandle(System.String);\n\tv309 = System.Type::op_Equality(v400, v706);\n\tv748 = v309 == 0;\n\tif (v748) goto L_00CC;\n\tv751 = v573 == 0;\n\tv318 = ~v751;\n\tif (v318) goto L_00D9;\n\tgoto L_01FF;\nL_00CC:\n\tgoto L_00D1;\n\tv764 = \"il2cpp_codegen_runtime_class_init\"(v752, v279, v244, v237, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00D1:\n\tv310 = System.Convert::ChangeType(v308[v303 @ X24_v13 (System.Int32)], v400);\nL_00D9:\n\tSystem.Array::SetValue(v573, v647, v303);\n\tv303 = v303 + 1;\n\tv634 = v303 < v308.Length;\n\tif (v634) goto L_00AC;\n\tgoto L_0116;\nL_00EE:\n\tv311 = System.Type::get_IsEnum(v306);\n\tv405 = v311 == 0;\n\tif (v405) goto L_011D;\n\tv413 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tgoto L_0104;\n\tv424 = v417;\n\tv425 = \"il2cpp_codegen_runtime_class_init\"(v424, v412, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0104:\n\tv455 = System.Enum::Parse(v413, value);\nL_0116:\n\tSystem.Reflection.FieldInfo::SetValue(v212, v183, v156);\n\treturn;\nL_011D:\n\tv434 = System.String::IndexOf(value, 0x2E);\n\tv466 = v434 + 1;\n\tv263 = v466 == 0;\n\tif (v263) goto L_01BD;\n\tv511 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tgoto L_0138;\n\tv550 = v515;\n\tv551 = \"il2cpp_codegen_runtime_class_init\"(v550, v510, v433, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0138:\n\tv555 = System.Type::GetTypeFromHandle(System.Int32);\n\tv565 = System.Type::op_Equality(v511, v555);\n\tv575 = v565 == 0;\n\tv576 = ~v575;\n\tif (v576) goto L_017D;\n\tv594 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tgoto L_0153;\n\tv653 = v596;\n\tv654 = \"il2cpp_codegen_runtime_class_init\"(v653, v593, v564, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0153:\n\tv658 = System.Type::GetTypeFromHandle(System.Int64);\n\tv609 = System.Type::op_Equality(v594, v658);\n\tv708 = v609 == 0;\n\tv611 = ~v708;\n\tif (v611) goto L_017D;\n\tv722 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tgoto L_016E;\n\tv738 = v536;\n\tv739 = \"il2cpp_codegen_runtime_class_init\"(v738, v721, v604, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_016E:\n\tv743 = System.Type::GetTypeFromHandle(System.Int16);\n\tv532 = System.Type::op_Equality(v722, v743);\n\tv534 = v532 == 0;\n\tif (v534) goto L_01BD;\nL_017D:\n\tgoto L_0181;\n\tv659 = \"il2cpp_codegen_runtime_class_init\"(v615, v605, v603, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0181:\n\tv663 = System.Type::GetTypeFromHandle(System.Single);\n\tgoto L_018F;\n\tv709 = v331;\n\tv710 = \"il2cpp_codegen_runtime_class_init\"(v709, v662, v603, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_018F:\n\tv312 = System.Convert::ChangeType(value, v663);\n\tv377 = v377_asT == 0;\n\tif (v377) goto L_0201;\n\tv750 = \"il2cpp_vm_object_unbox\"(v312, System.Single, 0, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv43 = *([v750 @ X0_v58]);\n\t// 424 Box v758 @ X0_v60 (System.Object), typeof(System.Single), &v43 @ V0\n\tv769 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tv733 = System.Convert::ChangeType(v758, v769);\nL_01B7:\n\tSystem.Reflection.FieldInfo::SetValue(fieldInfo, v, v733);\n\tgoto L_004F;\nL_01BD:\n\tv543 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tgoto L_01CD;\n\tv556 = v504;\n\tv557 = \"il2cpp_codegen_runtime_class_init\"(v556, v542, v523, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_01CD:\n\tv561 = System.Type::GetTypeFromHandle(System.String);\n\tv569 = System.Type::op_Equality(v543, v561);\n\tv501 = v569 == 0;\n\tif (v501) goto L_01E0;\n\tgoto L_0116;\nL_01E0:\n\tv628 = System.String::Equals(value, v626.Empty);\n\tv665 = v628 == 0;\n\tif (v665) goto L_01EF;\n\tv691 = 0;\n\t// 489 Box v733 @ X0_v41 (System.Object), typeof(System.Int32), &v691 @ stack_-68_v1\n\tgoto L_01B7;\nL_01EF:\n\tv698 = System.Reflection.FieldInfo::get_FieldType(fieldInfo);\n\tgoto L_01FD;\n\tv713 = v460;\n\tv714 = \"il2cpp_codegen_runtime_class_init\"(v713, v697, v624, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_01FD:\n\tv455 = System.Convert::ChangeType(value, v698);\n\tgoto L_FFFFFFFF;\nL_01FF:\n\tv336 = new System.NullReferenceException();\n\tv372 = new System.IndexOutOfRangeException();\nL_0201:\n\tthrow System.InvalidCastException;\n// 373 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static void SetValue(object v, FieldInfo fieldInfo, string value)
		{
			//IL_04dc: Expected O, but got I4
			//IL_04e5: Expected I4, but got O
			//IL_03b3: Expected F4, but got O
			//IL_03f2: Expected F4, but got O
			if (string.IsNullOrEmpty(value))
			{
				return;
			}
			Type fieldType = fieldInfo.FieldType;
			bool isArray = fieldType.IsArray;
			Type fieldType2 = fieldInfo.FieldType;
			Array array2;
			object obj2;
			object value4;
			if (isArray)
			{
				Type elementType = fieldType2.GetElementType();
				string[] array = value.Split(',', '~');
				array2 = Array.CreateInstance(elementType, array.Length);
				if (array.Length < 1)
				{
					goto IL_01a0;
				}
				int num = 0;
				while (true)
				{
					Type typeFromHandle = typeof(string);
					object value2;
					if (elementType == typeFromHandle)
					{
						bool flag = array2 == null;
						bool flag2 = !flag;
						value2 = array[num];
						if (!flag2)
						{
							break;
						}
					}
					else
					{
						object obj = Convert.ChangeType(array[num], elementType);
						value2 = obj;
					}
					array2.SetValue(value2, num);
					num++;
					if (num >= array.Length)
					{
						goto IL_01a0;
					}
				}
				NullReferenceException ex = new NullReferenceException();
				IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			}
			else
			{
				if (fieldType2.IsEnum)
				{
					Type fieldType3 = fieldInfo.FieldType;
					obj2 = Enum.Parse(fieldType3, value);
					goto IL_020f;
				}
				int num2 = value.IndexOf('.');
				if (num2 + 1 == 0)
				{
					goto IL_0434;
				}
				Type fieldType4 = fieldInfo.FieldType;
				Type typeFromHandle2 = typeof(int);
				if (!(fieldType4 == typeFromHandle2))
				{
					Type fieldType5 = fieldInfo.FieldType;
					Type typeFromHandle3 = typeof(long);
					if (!(fieldType5 == typeFromHandle3))
					{
						Type fieldType6 = fieldInfo.FieldType;
						Type typeFromHandle4 = typeof(short);
						if (!(fieldType6 == typeFromHandle4))
						{
							goto IL_0434;
						}
					}
				}
				Type typeFromHandle5 = typeof(float);
				object obj3 = Convert.ChangeType(value, typeFromHandle5);
				float num3 = (float)((obj3 is float) ? obj3 : null);
				if (num3 != 0f)
				{
					Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
					object obj5 = default(object);
					object obj4 = obj5;
					object value3 = (float)obj4;
					Type fieldType7 = fieldInfo.FieldType;
					value4 = Convert.ChangeType(value3, fieldType7);
					goto IL_041e;
				}
			}
			throw new InvalidCastException();
			IL_05a4:
			FieldInfo fieldInfo2;
			object obj6;
			object value5;
			fieldInfo2.SetValue(obj6, value5);
			return;
			IL_01a0:
			value5 = array2;
			obj6 = v;
			fieldInfo2 = fieldInfo;
			goto IL_05a4;
			IL_041e:
			fieldInfo.SetValue(v, value4);
			return;
			IL_020f:
			value5 = obj2;
			obj6 = v;
			fieldInfo2 = fieldInfo;
			goto IL_05a4;
			IL_0434:
			Type fieldType8 = fieldInfo.FieldType;
			Type typeFromHandle6 = typeof(string);
			if (fieldType8 == typeFromHandle6)
			{
				value5 = value;
				obj6 = v;
				fieldInfo2 = fieldInfo;
				goto IL_05a4;
			}
			if (value.Equals(string.Empty))
			{
				object obj7 = 0;
				value4 = (int)obj7;
				goto IL_041e;
			}
			Type fieldType9 = fieldInfo.FieldType;
			obj2 = Convert.ChangeType(value, fieldType9);
			goto IL_020f;
		}

		[Token(Token = "0x6000185")]
		[Address(RVA = "0xC04BC8", Offset = "0xC04BC8", Length = "0x324")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv42 = UnityEngine.Debug;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv80 = Il2CppMethodInfo;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv270 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>;\n\tv271 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv335 = Il2CppMethodInfo;\n\tv336 = \"il2cpp_codegen_initialize_runtime_metadata\"(v335, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv344 = Il2CppMethodInfo;\n\tv345 = \"il2cpp_codegen_initialize_runtime_metadata\"(v344, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv416 = \"Miss \";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v416, rows, idCol, valCol, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A3564B]) = v59;\nL_003A:\n\tv62 = System.Activator::CreateInstance(type);\n\tv69 = new System.Collections.Generic.Dictionary`2<System.String, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Int32>::.ctor(v69);\n\tv95 = rows._size < 2;\n\tif (v95) goto L_00B3;\nL_005A:\n\tv222 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v264);\n\tv250 = v222[idCol @ X2 (System.Int32)];\n\tv133 = v250._stringLength < 1;\n\tif (v133) goto L_009F;\n\tv223 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v264);\n\tv225 = System.String::TrimEnd(v223[idCol @ X2 (System.Int32)], 0x20);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Int32>::Add(v69, v225, v264);\nL_009F:\n\tv264 = v264 + 1;\n\tv277 = v264 < rows._size;\n\tif (v277) goto L_005A;\nL_00B3:\n\tv227 = System.Type::GetFields(type, 0x34);\n\tv357 = v227.Length < 1;\n\tif (v357) goto L_014E;\nL_00DD:\n\tv229 = System.Reflection.MemberInfo::get_Name(v227[v128 @ X27_v7 (System.Int32)]);\n\tv481 = System.Collections.Generic.Dictionary`2<System.Object, System.Int32>::ContainsKey(v69, v229);\n\tv488 = System.Reflection.MemberInfo::get_Name(v227[v128 @ X27_v7 (System.Int32)]);\n\tv491 = v481 == 0;\n\tif (v491) goto L_0126;\n\tv495 = System.Collections.Generic.Dictionary`2<System.Object, System.Int32>::get_Item(v69, v488);\n\tv230 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v495);\n\tv137 = v230.Length <= valCol;\n\tif (v137) goto L_0133;\n\tv231 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v495);\n\tZitga.CsvTools.CsvReader::SetValue(v62, v227[v128 @ X27_v7 (System.Int32)], v231[valCol @ X3 (System.Int32)]);\n\tgoto L_0133;\nL_0126:\n\tv500 = System.String::Concat(\"Miss \", v488);\n\tgoto L_0131;\n\tv507 = v502;\n\tv508 = \"il2cpp_codegen_runtime_class_init\"(v507, v489, v498, v108, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0131:\n\tUnityEngine.Debug::Log(v500);\nL_0133:\n\tv128 = v128 + 1;\n\tv429 = v128 < v227.Length;\n\tif (v429) goto L_00DD;\nL_014E:\n\treturn v62;\n\tv268 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 275 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static object CreateIdValue(Type type, List<string[]> rows, int idCol = 0, int valCol = 1)
		{
			object obj = Activator.CreateInstance(type);
			object obj2 = new Dictionary<string, int>();
			if (rows.Count >= 2)
			{
				int num = 1;
				do
				{
					string[] array = rows[num];
					string text = array[idCol];
					if (text.Length >= 1)
					{
						string[] array2 = rows[num];
						string key = array2[idCol].TrimEnd(' ');
						((Dictionary<object, int>)obj2).Add((object)key, num);
					}
					num++;
				}
				while (num < rows.Count);
			}
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (fields.Length >= 1)
			{
				int num2 = 0;
				do
				{
					string name = fields[num2].Name;
					bool flag = ((Dictionary<object, int>)obj2).ContainsKey((object)name);
					string name2 = fields[num2].Name;
					if (flag)
					{
						int index = ((Dictionary<object, int>)obj2)[(object)name2];
						string[] array3 = rows[index];
						if (array3.Length > valCol)
						{
							string[] array4 = rows[index];
							SetValue(obj, fields[num2], array4[valCol]);
						}
					}
					else
					{
						string message = "Miss " + name2;
						Debug.Log(message);
					}
					num2++;
				}
				while (num2 < fields.Length);
			}
			return obj;
		}

		[Token(Token = "0x6000186")]
		[Address(RVA = "0xC04EEC", Offset = "0xC04EEC", Length = "0x6A8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv96 = System.Collections.Generic.List`1<System.String[]>;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv394 = System.Collections.Generic.List`1<System.String>;\n\tv395 = \"il2cpp_codegen_initialize_runtime_metadata\"(v394, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv424 = System.Text.StringBuilder;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v424, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv63 = 1;\n\t*([1A3564C]) = v63;\nL_0040:\n\tv65 = new System.Collections.Generic.List`1<System.String[]>();\n\tSystem.Collections.Generic.List`1<System.String[]>::.ctor(v65);\n\tv75 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v75);\n\tv85 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v85);\n\tv113 = text._stringLength < 1;\n\tif (v113) goto L_026E;\nL_0066:\n\tv442 = System.String::get_Chars(text, v918);\n\tv505 = v442 & 0xFFFF;\n\tv506 = v173 & 1;\n\tv507 = v506 == 0;\n\tif (v507) goto L_00C9;\n\tv519 = v505 != 0x5C;\n\tif (v519) goto L_0094;\n\tv532 = v918 + 1;\n\tv542 = v532 >= text._stringLength;\n\tif (v542) goto L_0094;\n\tv564 = System.String::get_Chars(text, v532);\n\tv566 = v564 & 0xFFFF;\n\tv555 = v566 == 0x22;\n\tif (v555) goto L_00C2;\nL_0094:\n\tv570 = System.String::get_Chars(text, v918);\n\tv618 = v570 & 0xFFFF;\n\tv628 = v618 != 0x22;\n\tif (v628) goto L_0114;\n\tv653 = v918 + 1;\n\tv663 = v653 >= text._stringLength;\n\tif (v663) goto L_0114;\n\tv685 = System.String::get_Chars(text, v653);\n\tv687 = v685 & 0xFFFF;\n\tv666 = v687 != 0x22;\n\tif (v666) goto L_0114;\nL_00C2:\n\tv704 = System.Text.StringBuilder::Append(v422, 0x22);\n\tv918 = v918 + 1;\n\tgoto L_FFFFFFFF;\nL_00C9:\n\tv524 = v505 == 0xD;\n\tif (v524) goto L_00E3;\n\tv574 = System.String::get_Chars(text, v918);\n\tv584 = v574 & 0xFFFF;\n\tv575 = v584 != 0xA;\n\tif (v575) goto L_0187;\nL_00E3:\n\tv325 = System.Text.StringBuilder::get_Length(v422);\n\tv179 = v325 < 1;\n\tif (v179) goto L_015D;\n\tv322 = System.Text.StringBuilder::ToString(v422);\n\tv363 = v75._items;\n\tv136 = v75._version + 1;\n\tv75._version = v136;\n\tv723 = v75._size;\n\tv773 = v75._size < v363.Length;\n\tv741 = ~v773;\n\tif (v741) goto L_01BB;\n\tv881 = v75._size + 1;\n\tv75._size = v881;\n\tv363[v723 @ X10_v20 (System.Int32)] = v322;\n\tgoto L_01BD;\nL_0114:\n\tv326 = System.String::get_Chars(text, v918);\n\tv366 = v326 & 0xFFFF;\n\tv251 = v366 == 0x22;\n\tif (v251) goto L_0167;\n\tv715 = v366 != 0x5C;\n\tif (v715) goto L_0154;\n\tv385 = v918 + 1;\n\tv764 = v385 >= text._stringLength;\n\tif (v764) goto L_0154;\n\tv323 = System.String::get_Chars(text, v385);\n\tv364 = v323 & 0xFFFF;\n\tv180 = v364 != 0x6E;\n\tif (v180) goto L_0154;\n\tv912 = System.Text.StringBuilder::Append(v422, 0xA);\n\tgoto L_025D;\nL_0154:\n\tv324 = System.String::get_Chars(text, v918);\n\tv871 = System.Text.StringBuilder::Append(v422, v324);\n\tgoto L_025D;\nL_015D:\n\tv697 = v75 == 0;\n\tv343 = ~v697;\n\tif (v343) goto L_01CC;\n\tgoto L_02E7;\nL_0167:\n\tv327 = System.Text.StringBuilder::ToString(v422);\n\tv368 = v75._items;\n\tv137 = v75._version + 1;\n\tv75._version = v137;\n\tv788 = v75._size;\n\tv924 = v75._size < v368.Length;\n\tv925 = ~v924;\n\tif (v925) goto L_020E;\n\tv940 = v75._size + 1;\n\tv75._size = v940;\n\tv368[v788 @ X10_v26 (System.Int32)] = v327;\n\tgoto L_0210;\nL_0187:\n\tv328 = System.String::get_Chars(text, v918);\n\tv369 = v328 & 0xFFFF;\n\tv183 = v369 != separator;\n\tif (v183) goto L_023A;\n\tv329 = System.Text.StringBuilder::ToString(v422);\n\tv371 = v75._items;\n\tv138 = v75._version + 1;\n\tv75._version = v138;\n\tv786 = v75._size;\n\tv934 = v75._size < v371.Length;\n\tv830 = ~v934;\n\tif (v830) goto L_0255;\n\tv947 = v75._size + 1;\n\tv75._size = v947;\n\tv371[v786 @ X10_v23 (System.Int32)] = v329;\n\tgoto L_0257;\nL_01BB:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v322);\nL_01BD:\n\tv745 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v745);\nL_01CC:\n\tv184 = v75._size < 1;\n\tif (v184) goto L_FFFFFFFF;\n\tv330 = System.Collections.Generic.List`1<System.String>::ToArray(v75);\n\tv373 = v65._items;\n\tv140 = v65._version + 1;\n\tv65._version = v140;\n\tv787 = v65._size;\n\tv955 = v65._size < v373.Length;\n\tv956 = ~v955;\n\tif (v956) goto L_01F3;\n\tv970 = v65._size + 1;\n\tv65._size = v970;\n\tv373[v787 @ X10_v17 (System.Int32)] = v330;\n\tgoto L_01F6;\nL_01F3:\n\tSystem.Collections.Generic.List`1<System.String[]>::AddWithResize(v65, v330);\nL_01F6:\n\tv848 = v75._version + 1;\n\tv75._size = 0;\n\tv75._version = v848;\n\tv799 = v75._size < 1;\n\tif (v799) goto L_FFFFFFFF;\n\tSystem.Array::Clear(v75._items, 0, v75._size);\n\tgoto L_FFFFFFFF;\nL_020E:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v327);\nL_0210:\n\tv843 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v843);\n\tv851 = v918 + 1;\n\tv800 = v851 >= text._stringLength;\n\tif (v800) goto L_FFFFFFFF;\n\tv913 = System.String::get_Chars(text, v851);\n\tv915 = v913 & 0xFFFF;\n\tv888 = v915 != separator;\n\tif (v888) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_025D;\nL_023A:\n\tv719 = System.String::get_Chars(text, v918);\n\tv374 = v719 & 0xFFFF;\n\tv254 = v374 == 0x22;\n\tif (v254) goto L_FFFFFFFF;\n\tv331 = System.String::get_Chars(text, v918);\n\tv844 = System.Text.StringBuilder::Append(v422, v331);\n\tgoto L_FFFFFFFF;\nL_0255:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v329);\nL_0257:\n\tv840 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v840);\nL_025D:\n\tv918 = v918 + 1;\n\tv406 = v918 < text._stringLength;\n\tif (v406) goto L_0066;\nL_026E:\n\tv334 = System.Text.StringBuilder::get_Length(v391);\n\tv186 = v334 < 1;\n\tif (v186) goto L_029C;\n\tv333 = System.Text.StringBuilder::ToString(v391);\n\tv377 = v75._items;\n\tv142 = v75._version + 1;\n\tv75._version = v142;\n\tv588 = v75._size;\n\tv631 = v75._size < v377.Length;\n\tv606 = ~v631;\n\tif (v606) goto L_02A4;\n\tv589 = v75._size + 1;\n\tv75._size = v589;\n\tv377[v588 @ X10_v10 (System.Int32)] = v333;\n\tgoto L_02B0;\nL_029C:\n\tv530 = v75 == 0;\n\tv356 = ~v530;\n\tif (v356) goto L_02B0;\n\tgoto L_02E7;\nL_02A4:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v333);\nL_02B0:\n\tv187 = v75._size < 1;\n\tif (v187) goto L_02E6;\n\tv335 = System.Collections.Generic.List`1<System.String>::ToArray(v75);\n\tv379 = v65._items;\n\tv144 = v65._version + 1;\n\tv65._version = v144;\n\tv635 = v65._size;\n\tv752 = v65._size < v379.Length;\n\tv645 = ~v752;\n\tif (v645) goto L_02D7;\n\tv636 = v65._size + 1;\n\tv65._size = v636;\n\tv379[v635 @ X10_v7 (System.Int32)] = v335;\n\tgoto L_02E6;\nL_02D7:\n\tSystem.Collections.Generic.List`1<System.String[]>::AddWithResize(v65, v335);\nL_02E6:\n\treturn v65;\nL_02E7:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 527 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<string[]> ParseCsv(string text, char separator = ',')
		{
			List<string[]> list = new List<string[]>();
			List<string> list2 = new List<string>();
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = text.Length < 1;
			StringBuilder stringBuilder2 = stringBuilder;
			if (flag)
			{
				goto IL_08cc;
			}
			int num = 0;
			int num2 = 0;
			StringBuilder stringBuilder3 = stringBuilder;
			while (true)
			{
				char c = text[num2];
				int num3 = c & 0xFFFF;
				if ((num & 1) != 0)
				{
					if (num3 == 92)
					{
						int num4 = num2 + 1;
						if (num4 < text.Length)
						{
							char c2 = text[num4];
							int num5 = c2 & 0xFFFF;
							if (num5 == 34)
							{
								goto IL_01a0;
							}
						}
					}
					char c3 = text[num2];
					int num6 = c3 & 0xFFFF;
					if (num6 == 34)
					{
						int num7 = num2 + 1;
						if (num7 < text.Length)
						{
							char c4 = text[num7];
							int num8 = c4 & 0xFFFF;
							if (num8 == 34)
							{
								goto IL_01a0;
							}
						}
					}
					char c5 = text[num2];
					int num9 = c5 & 0xFFFF;
					if (num9 != 34)
					{
						if (num9 == 92)
						{
							int num10 = num2 + 1;
							if (num10 < text.Length)
							{
								char c6 = text[num10];
								int num11 = c6 & 0xFFFF;
								if (num11 == 110)
								{
									StringBuilder stringBuilder4 = stringBuilder3.Append('\n');
									num = 1;
									num2 = num10;
									goto IL_0afe;
								}
							}
						}
						char value = text[num2];
						StringBuilder stringBuilder5 = stringBuilder3.Append(value);
						goto IL_0421;
					}
					string text2 = stringBuilder3.ToString();
					string[] items = list2._items;
					int version = list2._version + 1;
					list2._version = version;
					int count = list2.Count;
					if (list2.Count < items.Length)
					{
						int size = list2.Count + 1;
						list2._size = size;
						items[count] = text2;
					}
					else
					{
						list2.Add(text2);
					}
					StringBuilder stringBuilder6 = new StringBuilder();
					int num12 = num2 + 1;
					bool flag2 = num12 >= text.Length;
					stringBuilder3 = stringBuilder6;
					if (!flag2)
					{
						char c7 = text[num12];
						int num13 = c7 & 0xFFFF;
						if (num13 == separator)
						{
							num2 = num12;
						}
						num = 0;
						stringBuilder3 = stringBuilder6;
						goto IL_0afe;
					}
				}
				else
				{
					if (num3 != 13)
					{
						char c8 = text[num2];
						int num14 = c8 & 0xFFFF;
						if (num14 != 10)
						{
							char c9 = text[num2];
							int num15 = c9 & 0xFFFF;
							if (num15 == separator)
							{
								string text3 = stringBuilder3.ToString();
								string[] items2 = list2._items;
								int version2 = list2._version + 1;
								list2._version = version2;
								int count2 = list2.Count;
								if (list2.Count < items2.Length)
								{
									int size2 = list2.Count + 1;
									list2._size = size2;
									items2[count2] = text3;
								}
								else
								{
									list2.Add(text3);
								}
								StringBuilder stringBuilder7 = new StringBuilder();
								stringBuilder3 = stringBuilder7;
							}
							else
							{
								char c10 = text[num2];
								int num16 = c10 & 0xFFFF;
								if (num16 == 34)
								{
									goto IL_0421;
								}
								char value2 = text[num2];
								StringBuilder stringBuilder8 = stringBuilder3.Append(value2);
							}
							goto IL_08be;
						}
					}
					int length = stringBuilder3.Length;
					if (length >= 1)
					{
						string text4 = stringBuilder3.ToString();
						string[] items3 = list2._items;
						int version3 = list2._version + 1;
						list2._version = version3;
						int count3 = list2.Count;
						if (list2.Count < items3.Length)
						{
							int size3 = list2.Count + 1;
							list2._size = size3;
							items3[count3] = text4;
						}
						else
						{
							list2.Add(text4);
						}
						StringBuilder stringBuilder9 = new StringBuilder();
						stringBuilder3 = stringBuilder9;
					}
					else if (list2 == null)
					{
						break;
					}
					if (list2.Count >= 1)
					{
						string[] array = list2.ToArray();
						string[][] items4 = list._items;
						int version4 = list._version + 1;
						list._version = version4;
						int count4 = list.Count;
						if (list.Count < items4.Length)
						{
							int size4 = list.Count + 1;
							list._size = size4;
							items4[count4] = array;
						}
						else
						{
							list.Add(array);
						}
						int version5 = list2._version + 1;
						list2._size = 0;
						list2._version = version5;
						if (list2.Count >= 1)
						{
							Array.Clear(list2._items, 0, list2.Count);
						}
					}
				}
				goto IL_08be;
				IL_08be:
				num = 0;
				goto IL_0afe;
				IL_0afe:
				num2++;
				bool flag3 = num2 < text.Length;
				stringBuilder2 = stringBuilder3;
				if (flag3)
				{
					continue;
				}
				goto IL_08cc;
				IL_0421:
				num = 1;
				goto IL_0afe;
				IL_01a0:
				StringBuilder stringBuilder10 = stringBuilder3.Append('"');
				num2++;
				goto IL_0421;
			}
			goto IL_0ad8;
			IL_0ad8:
			return (List<string[]>)(object)new NullReferenceException();
			IL_08cc:
			int length2 = stringBuilder2.Length;
			if (length2 >= 1)
			{
				string text5 = stringBuilder2.ToString();
				string[] items5 = list2._items;
				int version6 = list2._version + 1;
				list2._version = version6;
				int count5 = list2.Count;
				if (list2.Count < items5.Length)
				{
					int size5 = list2.Count + 1;
					list2._size = size5;
					items5[count5] = text5;
				}
				else
				{
					list2.Add(text5);
				}
			}
			else if (list2 == null)
			{
				goto IL_0ad8;
			}
			if (list2.Count >= 1)
			{
				string[] array2 = list2.ToArray();
				string[][] items6 = list._items;
				int version7 = list._version + 1;
				list._version = version7;
				int count6 = list.Count;
				if (list.Count < items6.Length)
				{
					int size6 = list.Count + 1;
					list._size = size6;
					items6[count6] = array2;
				}
				else
				{
					list.Add(array2);
				}
			}
			return list;
		}

		[Token(Token = "0x6000187")]
		[Address(RVA = "0xC04A10", Offset = "0xC04A10", Length = "0x1B8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0023;\n\tv22 = Il2CppMethodInfo;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv52 = Il2CppMethodInfo;\n\tv53 = \"il2cpp_codegen_initialize_runtime_metadata\"(v52, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv61 = System.Type;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v61, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A3564D]) = v42;\nL_0023:\n\tgoto L_0028;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0028:\n\tv59 = 0xAD98B4(strFullyQualifiedName, Il2CppMethodInfo, Il2CppMethodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv65 = System.Type::op_Equality(v59, 0);\n\tv67 = v65 == 0;\n\tif (v67) goto L_007D;\n\tv69 = System.AppDomain::get_CurrentDomain();\n\tv133 = System.AppDomain::GetAssemblies(v69);\n\tv82 = v133.Length < 1;\n\tif (v82) goto L_007D;\nL_005A:\n\tv288 = System.Reflection.Assembly::GetType(v133[v78 @ X23_v7 (System.Int32)], strFullyQualifiedName);\n\tgoto L_0066;\n\tv294 = v140;\n\tv295 = \"il2cpp_codegen_runtime_class_init\"(v294, v285, v287, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0066:\n\tv132 = System.Type::op_Inequality(v288, 0);\n\tv300 = v132 == 0;\n\tv135 = ~v300;\n\tif (v135) goto L_007D;\n\tv78 = v78 + 1;\n\tv80 = v78 < v133.Length;\n\tif (v80) goto L_005A;\nL_007D:\n\tgoto L_0082;\n\tv148 = \"il2cpp_codegen_runtime_class_init\"(v143, v128, v126, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0082:\n\tv153 = System.Type::op_Equality(v141, 0);\n\tv182 = v153 == 0;\n\tv183 = ~v182;\n\tif (v183) goto L_0097;\n\treturn v141;\n\tv180 = new System.NullReferenceException();\n\tthrow System.IndexOutOfRangeException;\nL_0097:\n\tv268 = System.String::Concat(\"Type is null: \", strFullyQualifiedName);\n\tv282 = new System.Exception();\n\tSystem.Exception::.ctor(v282, v268);\n\tthrow v282;\n// 125 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Type GetType(string strFullyQualifiedName)
		{
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @AD98B4");
			Type type = default(Type);
			bool flag = type == null;
			bool flag2 = !flag;
			Type type2 = type;
			if (!flag2)
			{
				AppDomain currentDomain = AppDomain.CurrentDomain;
				Assembly[] assemblies = currentDomain.GetAssemblies();
				bool flag3 = assemblies.Length < 1;
				type2 = type;
				if (!flag3)
				{
					int num = 0;
					bool flag7;
					do
					{
						Type type3 = assemblies[num].GetType(strFullyQualifiedName);
						bool flag4 = type3 != null;
						bool flag5 = !flag4;
						bool flag6 = !flag5;
						type2 = type3;
						if (!flag6)
						{
							num++;
							flag7 = num < assemblies.Length;
							type2 = type3;
							continue;
						}
						break;
					}
					while (flag7);
				}
			}
			if (!(type2 == null))
			{
				return type2;
			}
			string message = "Type is null: " + strFullyQualifiedName;
			Exception ex = new Exception(message);
			throw ex;
		}

		[Token(Token = "0x6000188")]
		[Address(RVA = "0xC045CC", Offset = "0xC045CC", Length = "0x128")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = Il2CppMethodInfo;\n\tv27 = \"il2cpp_codegen_initialize_runtime_metadata\"(v26, table, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv48 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v48, table, methodInfo, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv45 = 1;\n\t*([1A3564E]) = v45;\nL_0020:\n\tv54 = System.Type::GetFields(type, 0x34);\n\tv131 = v54.Length < 1;\n\tif (v131) goto L_FFFFFFFF;\nL_004A:\n\tv108 = System.Reflection.MemberInfo::get_Name(v54[v65 @ X23_v6 (System.Int32)]);\n\tv252 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::ContainsKey(table, v108);\n\tv188 = v252 == 0;\n\tif (v188) goto L_006F;\n\tv258 = System.Reflection.MemberInfo::get_Name(v54[v65 @ X23_v6 (System.Int32)]);\n\tv262 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::get_Item(table, v258);\n\tv279 = v262 - v213;\n\tv277 = v279 < 0;\n\tv273 = v262 ^ v213;\n\tv271 = v262 ^ v279;\n\tv269 = v273 & v271;\n\tv267 = v269 < 0;\n\tv288 = v277 == v267;\n\tv265 = ~v288;\n\tv263 = ~v265;\n\tif (v263) goto L_006F;\n\tgoto L_006F;\nL_006F:\n\tv65 = v65 + 1;\n\tv167 = v65 < v54.Length;\n\tif (v167) goto L_004A;\n\tgoto L_0088;\nL_0088:\n\treturn v213;\n\tv119 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 105 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static int GetObjectIndex(Type type, Dictionary<string, int> table)
		{
			FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			int num2;
			if (fields.Length >= 1)
			{
				int num = 0;
				num2 = int.MaxValue;
				do
				{
					string name = fields[num].Name;
					if (table.ContainsKey(name))
					{
						string name2 = fields[num].Name;
						int num3 = table[name2];
						int num4 = num3 - num2;
						bool flag = num4 < 0;
						int num5 = num3 ^ num2;
						int num6 = num3 ^ num4;
						int num7 = num5 & num6;
						bool flag2 = num7 < 0;
						if (flag != flag2)
						{
							num2 = num3;
						}
					}
					num++;
				}
				while (num < fields.Length);
			}
			else
			{
				num2 = int.MaxValue;
			}
			return num2;
		}

		[Token(Token = "0x6000189")]
		[Address(RVA = "0xC03698", Offset = "0xC03698", Length = "0x244")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0033;\n\tv42 = Il2CppMethodInfo;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, objectIndex, parentIndex, rows, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, objectIndex, parentIndex, rows, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv68 = Il2CppMethodInfo;\n\tv69 = \"il2cpp_codegen_initialize_runtime_metadata\"(v68, objectIndex, parentIndex, rows, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, objectIndex, parentIndex, rows, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv201 = System.Collections.Generic.List`1<System.Int32>;\n\tv202 = \"il2cpp_codegen_initialize_runtime_metadata\"(v201, objectIndex, parentIndex, rows, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv239 = System.String;\n\tv240 = \"il2cpp_codegen_initialize_runtime_metadata\"(v239, objectIndex, parentIndex, rows, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv308 = Il2CppMethodInfo;\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v308, objectIndex, parentIndex, rows, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A3564F]) = v59;\nL_0033:\n\tv61 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v61);\n\tv86 = rows._size <= rowIndex;\n\tif (v86) goto L_FFFFFFFF;\nL_0050:\n\tv196 = rowIndex + v114;\n\tv179 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v196);\n\tv229 = System.String::Equals(v179[objectIndex @ X1 (System.Int32)], v362.Empty);\n\tv364 = v229 == 0;\n\tv231 = ~v364;\n\tif (v231) goto L_00BF;\n\tv369 = objectIndex == parentIndex;\n\tif (v369) goto L_009E;\n\tv292 = System.String::Equals(v179[parentIndex @ X2 (System.Int32)], v296.Empty);\n\tv408 = v114 == 0;\n\tif (v408) goto L_009E;\n\tv294 = v292 == 0;\n\tif (v294) goto L_00D5;\nL_009E:\n\tv194 = v61._items;\n\tv93 = v61._version + 1;\n\tv61._version = v93;\n\tv375 = v61._size;\n\tv298 = v298 + 1;\n\tv414 = v61._size < v194.Length;\n\tv396 = ~v414;\n\tif (v396) goto L_00BD;\n\tv377 = v61._size + 1;\n\tv61._size = v377;\n\tv194[v375 @ X10_v8 (System.Int32)] = v196;\n\tgoto L_00BF;\nL_00BD:\n\tSystem.Collections.Generic.List`1<System.Int32>::AddWithResize(v61, v196);\nL_00BF:\n\tv114 = v114 + 1;\n\tv243 = rowIndex + v114;\n\tv248 = v243 < rows._size;\n\tif (v248) goto L_0050;\n\tgoto L_00D5;\nL_00D5:\n\tv302 = 0;\n\tSystem.ValueTuple`2<System.Int32, System.Object>::.ctor(&v302 @ stack_-70_v1 (System.ValueTuple`2<System.Int32, System.Object>), v298, v61);\n\treturn 0;\n\tv199 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 177 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static (int, List<int>) CountNumberElement(int rowIndex, int objectIndex, int parentIndex, List<string[]> rows)
		{
			List<int> list = new List<int>();
			int num2;
			if (rows.Count > rowIndex)
			{
				int num = 0;
				num2 = 0;
				int num4;
				do
				{
					int num3 = rowIndex + num;
					string[] array = rows[num3];
					if (!array[objectIndex].Equals(string.Empty))
					{
						if (objectIndex != parentIndex)
						{
							bool flag = array[parentIndex].Equals(string.Empty);
							if (num != 0 && !flag)
							{
								break;
							}
						}
						int[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						int count = list.Count;
						num2++;
						if (list.Count < items.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items[count] = num3;
						}
						else
						{
							list.Add(num3);
						}
					}
					num++;
					num4 = rowIndex + num;
				}
				while (num4 < rows.Count);
			}
			else
			{
				num2 = 0;
			}
			(int, object) tuple = default((int, object));
			tuple = (num2, list);
			return default((int, List<int>));
		}

		[Token(Token = "0x600018A")]
		[Address(RVA = "0xC046F4", Offset = "0xC046F4", Length = "0x1EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_002D;\n\tv36 = Il2CppMethodInfo;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, objectIndex, parentIndex, rows, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv58 = Il2CppMethodInfo;\n\tv59 = \"il2cpp_codegen_initialize_runtime_metadata\"(v58, objectIndex, parentIndex, rows, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv63 = Il2CppMethodInfo;\n\tv64 = \"il2cpp_codegen_initialize_runtime_metadata\"(v63, objectIndex, parentIndex, rows, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv67 = System.Collections.Generic.List`1<System.Int32>;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, objectIndex, parentIndex, rows, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv164 = System.String;\n\tv165 = \"il2cpp_codegen_initialize_runtime_metadata\"(v164, objectIndex, parentIndex, rows, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv199 = Il2CppMethodInfo;\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, objectIndex, parentIndex, rows, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A35650]) = v54;\nL_002D:\n\tv56 = new System.Collections.Generic.List`1<System.Int32>();\n\tSystem.Collections.Generic.List`1<System.Int32>::.ctor(v56);\n\tv74 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, rowIndex);\n\tv100 = objectIndex > 0xF;\n\tif (v100) goto L_FFFFFFFF;\n\tv204 = objectIndex << 3;\n\tv205 = v74 + v204;\n\tv245 = 0x10 - objectIndex;\n\tv83 = v205 + 0x20;\nL_0055:\n\tv149 = objectIndex + v161;\n\tv142 = System.String::Equals(*([v83 @ X26_v5+v161 @ X23_v7 (System.Int32)*8]), v156.Empty);\n\tv319 = v161 == 0;\n\tif (v319) goto L_0071;\n\tv321 = v142 == 0;\n\tv243 = ~v321;\n\tif (v243) goto L_FFFFFFFF;\nL_0071:\n\tv157 = v56._items;\n\tv81 = v56._version + 1;\n\tv56._version = v81;\n\tv210 = v56._size;\n\tv324 = v56._size < v157.Length;\n\tv325 = ~v324;\n\tif (v325) goto L_008E;\n\tv333 = v56._size + 1;\n\tv56._size = v333;\n\tv157[v210 @ X10_v7 (System.Int32)] = v149;\n\tgoto L_008F;\nL_008E:\n\tSystem.Collections.Generic.List`1<System.Int32>::AddWithResize(v56, v149);\nL_008F:\n\tv161 = v161 + 1;\n\tv249 = objectIndex + v161;\n\tv219 = v249 != 0x10;\n\tif (v219) goto L_0055;\n\tgoto L_00A6;\n\tgoto L_00A6;\nL_00A6:\n\tv256 = 0;\n\tSystem.ValueTuple`2<System.Int32, System.Object>::.ctor(&v256 @ stack_-60_v1 (System.ValueTuple`2<System.Int32, System.Object>), v245, v56);\n\treturn 0;\n\tv162 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 131 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static (int, List<int>) CountNumberRowElement(int rowIndex, int objectIndex, int parentIndex, List<string[]> rows)
		{
			//IL_004f: Expected O, but got I
			//IL_006c: Expected O, but got I
			//IL_0090: Expected O, but got I
			List<int> list = new List<int>();
			string[] array = rows[rowIndex];
			int item;
			if (objectIndex <= 15)
			{
				int num = objectIndex << 3;
				object obj = (nint)array + num;
				item = 16 - objectIndex;
				object obj2 = (nint)obj + 32;
				int num2 = 0;
				int num4;
				do
				{
					int num3 = objectIndex + num2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v83 @ X26_v5+v161 @ X23_v7 (System.Int32)*8]");
					bool flag = ((string)0).Equals(string.Empty);
					if (num2 == 0 || !flag)
					{
						int[] items = list._items;
						int version = list._version + 1;
						list._version = version;
						int count = list.Count;
						if (list.Count < items.Length)
						{
							int size = list.Count + 1;
							list._size = size;
							items[count] = num3;
						}
						else
						{
							list.Add(num3);
						}
						num2++;
						num4 = objectIndex + num2;
						continue;
					}
					item = num2;
					break;
				}
				while (num4 != 16);
			}
			else
			{
				item = 0;
			}
			(int, object) tuple = default((int, object));
			tuple = (item, list);
			return default((int, List<int>));
		}

		[Token(Token = "0x600018B")]
		[Address(RVA = "0xC038DC", Offset = "0xC038DC", Length = "0x2C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv8 = System.String::ToLower(key);\n\treturnVal2 = System.String::Equals(key, v8);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 13 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsValidKeyFormat(string key)
		{
			string value = key.ToLower();
			return key.Equals(value);
		}

		[Token(Token = "0x600018C")]
		[Address(RVA = "0xC03E34", Offset = "0xC03E34", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = System.Reflection.FieldInfo::get_FieldType(tmp);\n\tv37 = System.Type::get_IsArray(v10);\n\tv39 = v37 == 0;\n\tif (v39) goto L_0014;\n\tv60 = Zitga.CsvTools.CsvReader::GetElementTypeFromFieldInfo(tmp);\n\tgoto L_001C;\nL_0014:\n\t;\n\tv60 = System.Reflection.FieldInfo::get_FieldType(tmp);\nL_001C:\n\treturnVal2 = Zitga.CsvTools.CsvReader::IsPrimitive(v60);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 20 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsPrimitive(FieldInfo tmp)
		{
			Type fieldType = tmp.FieldType;
			Type type = ((!fieldType.IsArray) ? tmp.FieldType : GetElementTypeFromFieldInfo(tmp));
			return IsPrimitive(type);
		}

		[Token(Token = "0x600018D")]
		[Address(RVA = "0xC05594", Offset = "0xC05594", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001E;\n\tv22 = System.String;\n\tv23 = \"il2cpp_codegen_initialize_runtime_metadata\"(v22, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv49 = System.Type;\n\tv40 = \"il2cpp_codegen_initialize_runtime_metadata\"(v49, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv42 = 1;\n\t*([1A35651]) = v42;\nL_001E:\n\tgoto L_0022;\n\tv50 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0022:\n\tv54 = System.Type::GetTypeFromHandle(System.String);\n\tv58 = System.Type::op_Equality(type, v54);\n\tv60 = v58 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_003C;\n\tv69 = System.Type::get_IsEnum(type);\n\tv71 = v69 == 0;\n\tif (v71) goto L_0045;\nL_003C:\n\treturn 1;\nL_0045:\n\treturnVal3 = System.Type::get_IsPrimitive(type);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static bool IsPrimitive(Type type)
		{
			Type typeFromHandle = typeof(string);
			if (type == typeFromHandle || type.IsEnum)
			{
				return true;
			}
			return type.IsPrimitive;
		}

		[Token(Token = "0x600018E")]
		[Address(RVA = "0xC044A8", Offset = "0xC044A8", Length = "0x124")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv16 = System.String;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv35 = 1;\n\t*([1A35652]) = v35;\nL_001C:\n\tv46 = System.Reflection.FieldInfo::get_FieldType(tmp);\n\tv83 = System.Type::get_IsArray(v46);\n\tv63 = System.Reflection.FieldInfo::get_FieldType(tmp);\n\tv118 = System.Type::get_FullName(v63);\n\tv113 = v83 == 0;\n\tif (v113) goto L_005A;\n\tv114 = v118 == 0;\n\tif (v114) goto L_FFFFFFFF;\n\tv64 = System.Reflection.FieldInfo::get_FieldType(tmp);\n\tv127 = System.Type::get_FullName(v64);\n\tv65 = System.Reflection.FieldInfo::get_FieldType(tmp);\n\tv66 = System.Type::get_FullName(v65);\n\tv115 = v66._stringLength - 2;\n\tv118 = System.String::Substring(v127, 0, v115);\n\tgoto L_005A;\nL_005A:\n\treturnVal2 = Zitga.CsvTools.CsvReader::GetType(v118);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Type GetElementTypeFromFieldInfo(FieldInfo tmp)
		{
			Type fieldType = tmp.FieldType;
			bool isArray = fieldType.IsArray;
			Type fieldType2 = tmp.FieldType;
			string text = fieldType2.FullName;
			if (isArray)
			{
				if (text != null)
				{
					Type fieldType3 = tmp.FieldType;
					string fullName = fieldType3.FullName;
					Type fieldType4 = tmp.FieldType;
					string fullName2 = fieldType4.FullName;
					int length = fullName2.Length - 2;
					text = fullName.Substring(0, length);
				}
				else
				{
					text = string.Empty;
				}
			}
			return GetType(text);
		}

		[Token(Token = "0x600018F")]
		[Address(RVA = "0xC03908", Offset = "0xC03908", Length = "0x180")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv24 = System.Char;\n\tv25 = \"il2cpp_codegen_initialize_runtime_metadata\"(v24, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv50 = System.String[];\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv54 = \"_\";\n\tv42 = \"il2cpp_codegen_initialize_runtime_metadata\"(v54, methodInfo, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv44 = 1;\n\t*([1A35653]) = v44;\nL_001F:\n\t// 31 NewArr v48 @ X0_v3 (System.String[]), typeof(System.String[]), 1\n\tv48[0] = \"_\";\n\tv48 = System.String::Split(snakeCase, v48, 1);\n\tv237 = v48[0];\n\tv211 = v48.Length < 2;\n\tif (v211) goto L_008C;\nL_0051:\n\tv142 = *([v48 @ X0_v3 (System.String[])+v70 @ X23_v6 (System.Int32)*8]);\n\tv253 = System.String::get_Chars(*([v48 @ X0_v3 (System.String[])+v70 @ X23_v6 (System.Int32)*8]), 0);\n\tgoto L_0062;\n\tv258 = v254;\n\tv259 = \"il2cpp_codegen_runtime_class_init\"(v258, v251, v252, v113, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\nL_0062:\n\tv263 = System.Char::ToUpperInvariant(v253);\n\tv266 = System.Char::ToString(&v263 @ X0_v17 (System.Char));\n\tv270 = v142._stringLength - 1;\n\tv272 = System.String::Substring(*([v48 @ X0_v3 (System.String[])+v70 @ X23_v6 (System.Int32)*8]), 1, v270);\n\tv234 = System.String::Concat(v139, v266, v272);\n\tv70 = v70 + 1;\n\tv215 = v70 - 4;\n\tv221 = v215 < v48.Length;\n\tif (v221) goto L_0051;\nL_008C:\n\treturn v237;\n\tv122 = new System.IndexOutOfRangeException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 111 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string ConvertSnakeCaseToCamelCase(string snakeCase)
		{
			//IL_0099: Expected O, but got I
			//IL_00b4: Expected O, but got I
			//IL_0109: Expected O, but got I
			string[] array = snakeCase.Split(new string[1] { "_" }, StringSplitOptions.RemoveEmptyEntries);
			string result = array[0];
			if (array.Length >= 2)
			{
				int num = 5;
				string text = array[0];
				bool flag;
				do
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X0_v3 (System.String[])+v70 @ X23_v6 (System.Int32)*8]");
					string text2 = (string)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X0_v3 (System.String[])+v70 @ X23_v6 (System.Int32)*8]");
					char c = ((string)0)[0];
					string text3 = char.ToUpperInvariant(c).ToString();
					int length = text2.Length - 1;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X0_v3 (System.String[])+v70 @ X23_v6 (System.Int32)*8]");
					string text4 = ((string)0).Substring(1, length);
					string text5 = text + text3 + text4;
					num++;
					int num2 = num - 4;
					flag = num2 < array.Length;
					result = text5;
					text = text5;
				}
				while (flag);
			}
			return result;
		}
	}
}
