using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000006")]
public class CSVSerializer
{
	[Token(Token = "0x6000027")]
	[Address(RVA = "0xDA50C4", Offset = "0xDA50C4", Length = "0xD4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_001C;\n\tv33 = 0xB3490C(methodInfo, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001C:\n\tgoto L_0020;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0020:\n\tv51 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv57 = CSVSerializer::ParseCSV(text, 0x2C);\n\tv61 = CSVSerializer::CreateArray(v51, v57);\n\tgoto L_0035;\n\tv69 = v64;\n\tv70 = 0xB348B0(v69, v58, v60, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv73 = v70;\nL_0035:\n\tv74 = v61 == 0;\n\tif (v74) goto L_FFFFFFFF;\n\t// 57 IsInst returnVal1 @ X0_v11 (T[]), typeof(T[]), v61 @ X0_v9 (System.Object)\n\tv85 = returnVal1 == 0;\n\tv83 = ~v85;\n\tif (v83) goto L_0046;\n\tthrow System.InvalidCastException;\nL_0046:\n\treturn returnVal1;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static T[] Deserialize<T>(string text)
	{
		Type typeFromHandle = typeof(T);
		List<string[]> rows = ParseCSV(text);
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

	[Token(Token = "0x6000028")]
	[Address(RVA = "0xDA5008", Offset = "0xDA5008", Length = "0xBC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tgoto L_001C;\n\tv33 = 0xB3490C(methodInfo, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001C:\n\tgoto L_0020;\n\tv47 = \"il2cpp_codegen_runtime_class_init\"(v42, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0020:\n\tv51 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tv55 = CSVSerializer::CreateArray(v51, rows);\n\tgoto L_002F;\n\tv63 = v58;\n\tv64 = 0xB348B0(v63, v53, v54, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv67 = v64;\nL_002F:\n\tv68 = v55 == 0;\n\tif (v68) goto L_FFFFFFFF;\n\t// 51 IsInst returnVal1 @ X0_v8 (T[]), typeof(T[]), v55 @ X0_v6 (System.Object)\n\tv79 = returnVal1 == 0;\n\tv77 = ~v79;\n\tif (v77) goto L_0040;\n\tthrow System.InvalidCastException;\nL_0040:\n\treturn returnVal1;\n// 46 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

	[Token(Token = "0x6000029")]
	[Address(RVA = "0xDA52C4", Offset = "0xDA52C4", Length = "0x144")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-60_v2;\n\t*([v22 @ X29_v1-8]) = *([v25 @ SYSREG+28]);\n\tv58 = *([v28 @ X4+38]);\n\tv38 = *([v28 @ X4+38]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0025;\n\tv58 = *([v28 @ X4+38]);\n\tv76 = *([v28 @ X4+38]) == 0;\n\tv57 = ~v76;\n\tif (v57) goto L_0025;\n\tv55 = 0xB3490C(v28, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv58 = *([v28 @ X4+38]);\nL_0025:\n\tv62 = *([v58 @ X8_v3+8]);\n\tv66 = *([v62 @ X9_v1+FC]) + 0xF;\n\tv67 = v66 & 0x1FFFFFFF0;\n\tv68 = &v65 @ stack_-70_v1 - v67;\n\tgoto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v72, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0036:\n\tv81 = System.Type::GetTypeFromHandle(*([v58 @ X8_v3]));\n\tv87 = CSVSerializer::ParseCSV(text, 0x2C);\n\tv93 = CSVSerializer::CreateIdValue(v81, v87, id_col, value_col);\n\tv94 = *([v28 @ X4+38]);\n\tv103 = *([v94 @ X8_v4+8]);\n\tv98 = *([v103 @ X1_v5+135]) & 1;\n\tv99 = v98 == 0;\n\tv100 = ~v99;\n\tif (v100) goto L_004F;\n\tv102 = 0xB348B0(v103, v103, id_col, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_004F:\n\tv108 = 0xAD95AC(v93, v103, v68, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = 0x1854F10(methodInfo, v108, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv124 = *([v25 @ SYSREG+28]) != *([v22 @ X29_v1-8]);\n\tif (v124) goto L_006F;\n\treturn returnVal1;\nL_006F:\n\treturnVal2 = 0x1854EB0(returnVal1, v108, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal2;\n// 78 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
		List<string[]> rows = ParseCSV(text);
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

	[Token(Token = "0x600002A")]
	[Address(RVA = "0xDA5198", Offset = "0xDA5198", Length = "0x12C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv22 = &v23 @ stack_-60_v2;\n\t*([v22 @ X29_v1-8]) = *([v25 @ SYSREG+28]);\n\tv58 = *([v28 @ X4+38]);\n\tv38 = *([v28 @ X4+38]) == 0;\n\tv39 = ~v38;\n\tif (v39) goto L_0025;\n\tv58 = *([v28 @ X4+38]);\n\tv76 = *([v28 @ X4+38]) == 0;\n\tv57 = ~v76;\n\tif (v57) goto L_0025;\n\tv55 = 0xB3490C(v28, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv58 = *([v28 @ X4+38]);\nL_0025:\n\tv62 = *([v58 @ X8_v3+8]);\n\tv66 = *([v62 @ X9_v1+FC]) + 0xF;\n\tv67 = v66 & 0x1FFFFFFF0;\n\tv68 = &v65 @ stack_-70_v1 - v67;\n\tgoto L_0036;\n\tv77 = \"il2cpp_codegen_runtime_class_init\"(v72, id_col, value_col, methodInfo, v28, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0036:\n\tv81 = System.Type::GetTypeFromHandle(*([v58 @ X8_v3]));\n\tv87 = CSVSerializer::CreateIdValue(v81, rows, id_col, value_col);\n\tv88 = *([v28 @ X4+38]);\n\tv97 = *([v88 @ X8_v4+8]);\n\tv92 = *([v97 @ X1_v4+135]) & 1;\n\tv93 = v92 == 0;\n\tv94 = ~v93;\n\tif (v94) goto L_0049;\n\tv96 = 0xB348B0(v97, v97, id_col, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\nL_0049:\n\tv102 = 0xAD95AC(v87, v97, v68, value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturnVal1 = 0x1854F10(methodInfo, v102, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\tv118 = *([v25 @ SYSREG+28]) != *([v22 @ X29_v1-8]);\n\tif (v118) goto L_0069;\n\treturn returnVal1;\nL_0069:\n\treturnVal2 = 0x1854EB0(returnVal1, v102, *([v62 @ X9_v1+FC]), value_col, 0, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52, v53);\n\treturn returnVal2;\n// 73 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

	[Token(Token = "0x600002B")]
	[Address(RVA = "0xBF5998", Offset = "0xBF5998", Length = "0x36C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0039;\n\tv34 = System.Char;\n\tv35 = \"il2cpp_codegen_initialize_runtime_metadata\"(v34, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv57 = Il2CppMethodInfo;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv211 = Il2CppMethodInfo;\n\tv212 = \"il2cpp_codegen_initialize_runtime_metadata\"(v211, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv249 = Il2CppMethodInfo;\n\tv250 = \"il2cpp_codegen_initialize_runtime_metadata\"(v249, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv298 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>;\n\tv299 = \"il2cpp_codegen_initialize_runtime_metadata\"(v298, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv343 = Il2CppMethodInfo;\n\tv344 = \"il2cpp_codegen_initialize_runtime_metadata\"(v343, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv346 = Il2CppMethodInfo;\n\tv347 = \"il2cpp_codegen_initialize_runtime_metadata\"(v346, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv353 = \"\";\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v353, rows, methodInfo, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\n\tv53 = 1;\n\t*([1A355B5]) = v53;\nL_0039:\n\tv66 = rows._size - 1;\n\tv70 = System.Array::CreateInstance(type, v66);\n\tv214 = new System.Collections.Generic.Dictionary`2<System.String, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::.ctor(v214);\n\tv231 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, 0);\nL_005C:\n\tv86 = v156 >= v231.Length;\n\tif (v86) goto L_013A;\n\tv187 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, 0);\n\tv98 = v187[v156 @ X23_v9 (System.Int32)];\n\tv383 = v98._stringLength < 1;\n\tif (v383) goto L_0117;\nL_0088:\n\tv425 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\n\tv430 = v425 & 0xFFFF;\n\tv431 = v430 < 0x61;\n\tv432 = ~v431;\n\tv440 = ~v432;\n\tif (v440) goto L_00A8;\n\tv448 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\n\tv471 = v448 & 0xFFFF;\n\tv479 = v471 < 0x7B;\n\tv466 = ~v479;\n\tv450 = ~v466;\n\tif (v450) goto L_00F2;\nL_00A8:\n\tv475 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\n\tv480 = v475 & 0xFFFF;\n\tv481 = v480 < 0x30;\n\tv482 = ~v481;\n\tv490 = ~v482;\n\tif (v490) goto L_00C9;\n\tv522 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\n\tv524 = v522 & 0xFFFF;\n\tv550 = v524 < 0x39;\n\tv516 = ~v550;\n\tv514 = v524 - 0x39;\n\tv510 = v514 == 0;\n\tv551 = ~v516;\n\tv500 = v551 | v510;\n\tif (v500) goto L_00F2;\nL_00C9:\n\tv546 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\n\tv552 = v546 & 0xFFFF;\n\tv553 = v552 < 0x41;\n\tv554 = ~v553;\n\tv562 = ~v554;\n\tif (v562) goto L_0104;\n\tv599 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\n\tv614 = v599 & 0xFFFF;\n\tv623 = v614 < 0x5A;\n\tv584 = ~v623;\n\tv582 = v614 - 0x5A;\n\tv578 = v582 == 0;\n\tv624 = ~v578;\n\tv566 = v584 & v624;\n\tif (v566) goto L_0104;\n\tv590 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\n\tv568 = v590 + 0x20;\n\tgoto L_00F8;\nL_00F2:\n\tv528 = System.String::get_Chars(v187[v156 @ X23_v9 (System.Int32)], v405);\nL_00F8:\n\tgoto L_00FD;\n\tv617 = v591;\n\tv618 = \"il2cpp_codegen_runtime_class_init\"(v617, v587, v585, v73, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49);\nL_00FD:\n\tv622 = System.Char::ToString(&v563 @ stack_-64_v7 (System.Char));\n\tv612 = System.String::Concat(v388, v622);\nL_0104:\n\tv405 = v405 + 1;\n\tv387 = v405 < v98._stringLength;\n\tif (v387) goto L_0088;\nL_0117:\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::Add(v214, v187[v156 @ X23_v9 (System.Int32)], v156);\n\tv444 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::ContainsKey(v214, v89);\n\tv477 = v444 == 0;\n\tv478 = ~v477;\n\tif (v478) goto L_0128;\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Int32>::Add(v214, v89, v156);\nL_0128:\n\tv156 = v156 + 1;\n\tv231 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, 0);\n\tv547 = v231 == 0;\n\tv191 = ~v547;\n\tif (v191) goto L_005C;\n\tthrow System.NullReferenceException;\nL_013A:\n\tv247 = rows._size < 2;\n\tif (v247) goto L_0167;\nL_0140:\n\tv308 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v157);\n\tv189 = CSVSerializer::Create(v308, v183, v165);\n\tv276 = v157 - 1;\n\tSystem.Array::SetValue(v199, v189, v276);\n\tv157 = v157 + 1;\n\tv256 = v157 < rows._size;\n\tif (v256) goto L_0140;\nL_0167:\n\treturn v199;\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 254 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static object CreateArray(Type type, List<string[]> rows)
	{
		int length = rows.Count - 1;
		Array array = Array.CreateInstance(type, length);
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		string[] array2 = rows[0];
		int num = 0;
		Type type2;
		Dictionary<string, int> table;
		Array array3;
		while (true)
		{
			bool flag = num >= array2.Length;
			type2 = type;
			table = dictionary;
			array3 = array;
			if (flag)
			{
				break;
			}
			string[] array4 = rows[0];
			string text = array4[num];
			bool flag2 = text.Length < 1;
			string key = "";
			if (!flag2)
			{
				int num2 = 0;
				string text2 = "";
				bool flag11;
				do
				{
					char c = array4[num][num2];
					int num3 = c & 0xFFFF;
					if (num3 >= 97)
					{
						char c2 = array4[num][num2];
						int num4 = c2 & 0xFFFF;
						if (num4 < 123)
						{
							goto IL_031c;
						}
					}
					char c3 = array4[num][num2];
					int num5 = c3 & 0xFFFF;
					if (num5 >= 48)
					{
						char c4 = array4[num][num2];
						int num6 = c4 & 0xFFFF;
						bool flag3 = num6 < 57;
						bool flag4 = !flag3;
						int num7 = num6 - 57;
						bool flag5 = num7 == 0;
						bool flag6 = !flag4;
						if (flag6 || flag5)
						{
							goto IL_031c;
						}
					}
					char c5 = array4[num][num2];
					int num8 = c5 & 0xFFFF;
					char c8;
					if (num8 >= 65)
					{
						char c6 = array4[num][num2];
						int num9 = c6 & 0xFFFF;
						bool flag7 = num9 < 90;
						bool flag8 = !flag7;
						int num10 = num9 - 90;
						bool flag9 = num10 == 0;
						bool flag10 = !flag9;
						if (!(flag8 && flag10))
						{
							char c7 = array4[num][num2];
							int num11 = c7 + 32;
							c8 = (char)num11;
							goto IL_0343;
						}
					}
					goto IL_04cf;
					IL_0343:
					string text3 = c8.ToString();
					string text4 = text2 + text3;
					text2 = text4;
					goto IL_04cf;
					IL_031c:
					char c9 = array4[num][num2];
					c8 = c9;
					goto IL_0343;
					IL_04cf:
					num2++;
					flag11 = num2 < text.Length;
					key = text2;
				}
				while (flag11);
			}
			dictionary.Add(array4[num], num);
			if (!dictionary.ContainsKey(key))
			{
				dictionary.Add(key, num);
			}
			num++;
			array2 = rows[0];
			bool flag12 = array2 == null;
			bool flag13 = !flag12;
			type2 = type;
			table = dictionary;
			array3 = array;
			if (!flag13)
			{
				throw new NullReferenceException();
			}
		}
		if (rows.Count >= 2)
		{
			int num12 = 1;
			do
			{
				string[] cols = rows[num12];
				object value = Create(cols, table, type2);
				int index = num12 - 1;
				array3.SetValue(value, index);
				num12++;
			}
			while (num12 < rows.Count);
		}
		return array3;
	}

	[Token(Token = "0x600002C")]
	[Address(RVA = "0xBF5D04", Offset = "0xBF5D04", Length = "0x158")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv30 = Il2CppMethodInfo;\n\tv31 = \"il2cpp_codegen_initialize_runtime_metadata\"(v30, table, type, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv53 = Il2CppMethodInfo;\n\tv46 = \"il2cpp_codegen_initialize_runtime_metadata\"(v53, table, type, methodInfo, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv48 = 1;\n\t*([1A355B6]) = v48;\nL_001D:\n\tv51 = System.Activator::CreateInstance(type);\n\tv61 = System.Type::GetFields(type, 0x34);\n\tv140 = v61.Length < 1;\n\tif (v140) goto L_0090;\nL_004F:\n\tv115 = System.Reflection.MemberInfo::get_Name(v61[v69 @ X24_v6 (System.Int32)]);\n\tv266 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::ContainsKey(table, v115);\n\tv268 = v266 == 0;\n\tif (v268) goto L_0078;\n\tv271 = System.Reflection.MemberInfo::get_Name(v61[v69 @ X24_v6 (System.Int32)]);\n\tv116 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>::get_Item(table, v271);\n\tv149 = v116 >= cols.Length;\n\tif (v149) goto L_0078;\n\tCSVSerializer::SetValue(v51, v61[v69 @ X24_v6 (System.Int32)], cols[v116 @ X0_v21 (System.Int32)]);\nL_0078:\n\tv69 = v69 + 1;\n\tv189 = v69 < v61.Length;\n\tif (v189) goto L_004F;\nL_0090:\n\treturn v51;\n\tv128 = new System.NullReferenceException();\n\treturnVal2 = new System.IndexOutOfRangeException();\n\treturn returnVal2;\n// 121 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static object Create(string[] cols, Dictionary<string, int> table, Type type)
	{
		object obj = Activator.CreateInstance(type);
		FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
		if (fields.Length >= 1)
		{
			int num = 0;
			do
			{
				string name = fields[num].Name;
				if (table.ContainsKey(name))
				{
					string name2 = fields[num].Name;
					int num2 = table[name2];
					if (num2 < cols.Length)
					{
						SetValue(obj, fields[num], cols[num2]);
					}
				}
				num++;
			}
			while (num < fields.Length);
		}
		return obj;
	}

	[Token(Token = "0x600002D")]
	[Address(RVA = "0xBF5E5C", Offset = "0xBF5E5C", Length = "0x5A8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0036;\n\tv36 = System.Convert;\n\tv37 = \"il2cpp_codegen_initialize_runtime_metadata\"(v36, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv57 = System.Enum;\n\tv58 = \"il2cpp_codegen_initialize_runtime_metadata\"(v57, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv137 = System.Int16;\n\tv138 = \"il2cpp_codegen_initialize_runtime_metadata\"(v137, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv227 = System.Int32;\n\tv228 = \"il2cpp_codegen_initialize_runtime_metadata\"(v227, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv231 = System.Int64;\n\tv232 = \"il2cpp_codegen_initialize_runtime_metadata\"(v231, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv318 = System.Single;\n\tv319 = \"il2cpp_codegen_initialize_runtime_metadata\"(v318, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv352 = System.Single;\n\tv353 = \"il2cpp_codegen_initialize_runtime_metadata\"(v352, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv361 = System.String;\n\tv362 = \"il2cpp_codegen_initialize_runtime_metadata\"(v361, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv366 = System.Type;\n\tv367 = \"il2cpp_codegen_initialize_runtime_metadata\"(v366, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv377 = \"\";\n\tv52 = \"il2cpp_codegen_initialize_runtime_metadata\"(v377, fieldinfo, value, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv54 = 1;\n\t*([1A355B7]) = v54;\nL_0036:\n\tv55 = value == 0;\n\tif (v55) goto L_004E;\n\tv64 = System.String::op_Equality(value, \"\");\n\tv116 = v64 == 0;\n\tif (v116) goto L_0055;\nL_004E:\n\treturn;\nL_0055:\n\tv237 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tv321 = System.Type::get_IsArray(v237);\n\tv295 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tv364 = v321 == 0;\n\tif (v364) goto L_00D3;\n\tv369 = System.Type::GetElementType(v295);\n\tv296 = System.String::Split(value, 0x2C, 0);\n\tv403 = System.Array::CreateInstance(v369, v296.Length);\n\tv423 = v296.Length < 1;\n\tif (v423) goto L_FFFFFFFF;\nL_0091:\n\tgoto L_0095;\n\tv593 = \"il2cpp_codegen_runtime_class_init\"(v582, v577, v578, v264, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0095:\n\tv597 = System.Type::GetTypeFromHandle(System.String);\n\tv297 = System.Type::op_Equality(v369, v597);\n\tv659 = v297 == 0;\n\tif (v659) goto L_00B1;\n\tv665 = v403 == 0;\n\tv303 = ~v665;\n\tif (v303) goto L_00BE;\n\tgoto L_01D6;\nL_00B1:\n\tgoto L_00B6;\n\tv680 = \"il2cpp_codegen_runtime_class_init\"(v666, v286, v291, v264, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00B6:\n\tv298 = System.Convert::ChangeType(v296[v282 @ X24_v14 (System.Int32)], v369);\nL_00BE:\n\tSystem.Array::SetValue(v403, v525, v282);\n\tv282 = v282 + 1;\n\tv502 = v282 < v296.Length;\n\tif (v502) goto L_0091;\n\tgoto L_0101;\nL_00D3:\n\tv373 = System.Type::get_IsEnum(v295);\n\tv375 = v373 == 0;\n\tif (v375) goto L_0106;\n\tv382 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tv388 = System.String::ToString(value);\n\tgoto L_00EF;\n\tv404 = v392;\n\tv405 = \"il2cpp_codegen_runtime_class_init\"(v404, v387, v62, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_00EF:\n\tv440 = System.Enum::Parse(v382, v388);\nL_0101:\n\tSystem.Reflection.FieldInfo::SetValue(v208, v202, v205);\n\treturn;\nL_0106:\n\tv399 = System.String::IndexOf(value, 0x2E);\n\tv411 = v399 + 1;\n\tv253 = v411 == 0;\n\tif (v253) goto L_01A6;\n\tv456 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tgoto L_0121;\n\tv556 = v460;\n\tv557 = \"il2cpp_codegen_runtime_class_init\"(v556, v455, v398, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0121:\n\tv561 = System.Type::GetTypeFromHandle(System.Int32);\n\tv588 = System.Type::op_Equality(v456, v561);\n\tv599 = v588 == 0;\n\tv600 = ~v599;\n\tif (v600) goto L_0166;\n\tv607 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tgoto L_013C;\n\tv643 = v609;\n\tv644 = \"il2cpp_codegen_runtime_class_init\"(v643, v606, v587, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_013C:\n\tv648 = System.Type::GetTypeFromHandle(System.Int64);\n\tv622 = System.Type::op_Equality(v607, v648);\n\tv670 = v622 == 0;\n\tv624 = ~v670;\n\tif (v624) goto L_0166;\n\tv687 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tgoto L_0157;\n\tv693 = v481;\n\tv694 = \"il2cpp_codegen_runtime_class_init\"(v693, v686, v620, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0157:\n\tv698 = System.Type::GetTypeFromHandle(System.Int16);\n\tv477 = System.Type::op_Equality(v687, v698);\n\tv479 = v477 == 0;\n\tif (v479) goto L_01A6;\nL_0166:\n\tgoto L_016A;\n\tv649 = \"il2cpp_codegen_runtime_class_init\"(v628, v617, v619, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_016A:\n\tv653 = System.Type::GetTypeFromHandle(System.Single);\n\tgoto L_0178;\n\tv671 = v312;\n\tv672 = \"il2cpp_codegen_runtime_class_init\"(v671, v652, v619, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0178:\n\tv299 = System.Convert::ChangeType(value, v653);\n\tv75 = v75_asT == 0;\n\tif (v75) goto L_01D8;\n\tv703 = \"il2cpp_vm_object_unbox\"(v299, System.Single, 0, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv43 = *([v703 @ X0_v53]);\n\t// 401 Box v707 @ X0_v55 (System.Object), typeof(System.Single), &v43 @ V0\n\tv710 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tv714 = System.Convert::ChangeType(v707, v710);\n\tSystem.Reflection.FieldInfo::SetValue(fieldinfo, v, v714);\n\tgoto L_004E;\nL_01A6:\n\tv488 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tgoto L_01B6;\n\tv562 = v493;\n\tv563 = \"il2cpp_codegen_runtime_class_init\"(v562, v487, v474, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_01B6:\n\tv567 = System.Type::GetTypeFromHandle(System.String);\n\tv592 = System.Type::op_Equality(v488, v567);\n\tv553 = v592 == 0;\n\tif (v553) goto L_01C6;\n\tgoto L_0101;\nL_01C6:\n\tv638 = System.Reflection.FieldInfo::get_FieldType(fieldinfo);\n\tgoto L_01D4;\n\tv654 = v446;\n\tv655 = \"il2cpp_codegen_runtime_class_init\"(v654, v637, v591, methodInfo, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_01D4:\n\tv440 = System.Convert::ChangeType(value, v638);\n\tgoto L_FFFFFFFF;\nL_01D6:\n\tv316 = new System.NullReferenceException();\n\tv350 = new System.IndexOutOfRangeException();\nL_01D8:\n\tthrow System.InvalidCastException;\n// 342 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static void SetValue(object v, FieldInfo fieldinfo, string value)
	{
		//IL_03c5: Expected F4, but got O
		//IL_0404: Expected F4, but got O
		if (value == null || value == "")
		{
			return;
		}
		Type fieldType = fieldinfo.FieldType;
		bool isArray = fieldType.IsArray;
		Type fieldType2 = fieldinfo.FieldType;
		Array array2;
		object obj2;
		if (isArray)
		{
			Type elementType = fieldType2.GetElementType();
			string[] array = value.Split(',');
			array2 = Array.CreateInstance(elementType, array.Length);
			if (array.Length < 1)
			{
				goto IL_01a5;
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
					goto IL_01a5;
				}
			}
			NullReferenceException ex = new NullReferenceException();
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
		}
		else
		{
			if (fieldType2.IsEnum)
			{
				Type fieldType3 = fieldinfo.FieldType;
				string value3 = value.ToString();
				obj2 = Enum.Parse(fieldType3, value3);
				goto IL_0221;
			}
			int num2 = value.IndexOf('.');
			if (num2 + 1 == 0)
			{
				goto IL_0446;
			}
			Type fieldType4 = fieldinfo.FieldType;
			Type typeFromHandle2 = typeof(int);
			if (!(fieldType4 == typeFromHandle2))
			{
				Type fieldType5 = fieldinfo.FieldType;
				Type typeFromHandle3 = typeof(long);
				if (!(fieldType5 == typeFromHandle3))
				{
					Type fieldType6 = fieldinfo.FieldType;
					Type typeFromHandle4 = typeof(short);
					if (!(fieldType6 == typeFromHandle4))
					{
						goto IL_0446;
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
				object value4 = (float)obj4;
				Type fieldType7 = fieldinfo.FieldType;
				object value5 = Convert.ChangeType(value4, fieldType7);
				fieldinfo.SetValue(v, value5);
				return;
			}
		}
		throw new InvalidCastException();
		IL_0446:
		Type fieldType8 = fieldinfo.FieldType;
		Type typeFromHandle6 = typeof(string);
		object obj6;
		Array value6;
		FieldInfo fieldInfo;
		if (fieldType8 == typeFromHandle6)
		{
			obj6 = v;
			value6 = (Array)(object)value;
			fieldInfo = fieldinfo;
			goto IL_055f;
		}
		Type fieldType9 = fieldinfo.FieldType;
		obj2 = Convert.ChangeType(value, fieldType9);
		goto IL_0221;
		IL_055f:
		fieldInfo.SetValue(obj6, value6);
		return;
		IL_01a5:
		obj6 = v;
		value6 = array2;
		fieldInfo = fieldinfo;
		goto IL_055f;
		IL_0221:
		obj6 = v;
		value6 = (Array)obj2;
		fieldInfo = fieldinfo;
		goto IL_055f;
	}

	[Token(Token = "0x600002E")]
	[Address(RVA = "0xBF6404", Offset = "0xBF6404", Length = "0x324")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_003A;\n\tv42 = UnityEngine.Debug;\n\tv43 = \"il2cpp_codegen_initialize_runtime_metadata\"(v42, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv64 = Il2CppMethodInfo;\n\tv65 = \"il2cpp_codegen_initialize_runtime_metadata\"(v64, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv71 = Il2CppMethodInfo;\n\tv72 = \"il2cpp_codegen_initialize_runtime_metadata\"(v71, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv76 = Il2CppMethodInfo;\n\tv77 = \"il2cpp_codegen_initialize_runtime_metadata\"(v76, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv80 = Il2CppMethodInfo;\n\tv81 = \"il2cpp_codegen_initialize_runtime_metadata\"(v80, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv270 = System.Collections.Generic.Dictionary`2<System.String, System.Int32>;\n\tv271 = \"il2cpp_codegen_initialize_runtime_metadata\"(v270, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv335 = Il2CppMethodInfo;\n\tv336 = \"il2cpp_codegen_initialize_runtime_metadata\"(v335, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv344 = Il2CppMethodInfo;\n\tv345 = \"il2cpp_codegen_initialize_runtime_metadata\"(v344, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv416 = \"Miss \";\n\tv57 = \"il2cpp_codegen_initialize_runtime_metadata\"(v416, rows, id_col, val_col, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\n\tv59 = 1;\n\t*([1A355B8]) = v59;\nL_003A:\n\tv62 = System.Activator::CreateInstance(type);\n\tv69 = new System.Collections.Generic.Dictionary`2<System.String, System.Int32>();\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Int32>::.ctor(v69);\n\tv95 = rows._size < 2;\n\tif (v95) goto L_00B3;\nL_005A:\n\tv222 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v264);\n\tv250 = v222[id_col @ X2 (System.Int32)];\n\tv133 = v250._stringLength < 1;\n\tif (v133) goto L_009F;\n\tv223 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v264);\n\tv225 = System.String::TrimEnd(v223[id_col @ X2 (System.Int32)], 0x20);\n\tSystem.Collections.Generic.Dictionary`2<System.Object, System.Int32>::Add(v69, v225, v264);\nL_009F:\n\tv264 = v264 + 1;\n\tv277 = v264 < rows._size;\n\tif (v277) goto L_005A;\nL_00B3:\n\tv227 = System.Type::GetFields(type, 0x34);\n\tv357 = v227.Length < 1;\n\tif (v357) goto L_014E;\nL_00DD:\n\tv229 = System.Reflection.MemberInfo::get_Name(v227[v128 @ X27_v7 (System.Int32)]);\n\tv481 = System.Collections.Generic.Dictionary`2<System.Object, System.Int32>::ContainsKey(v69, v229);\n\tv488 = System.Reflection.MemberInfo::get_Name(v227[v128 @ X27_v7 (System.Int32)]);\n\tv491 = v481 == 0;\n\tif (v491) goto L_0126;\n\tv495 = System.Collections.Generic.Dictionary`2<System.Object, System.Int32>::get_Item(v69, v488);\n\tv230 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v495);\n\tv137 = v230.Length <= val_col;\n\tif (v137) goto L_0133;\n\tv231 = System.Collections.Generic.List`1<System.String[]>::get_Item(rows, v495);\n\tCSVSerializer::SetValue(v62, v227[v128 @ X27_v7 (System.Int32)], v231[val_col @ X3 (System.Int32)]);\n\tgoto L_0133;\nL_0126:\n\tv500 = System.String::Concat(\"Miss \", v488);\n\tgoto L_0131;\n\tv507 = v502;\n\tv508 = \"il2cpp_codegen_runtime_class_init\"(v507, v489, v498, v108, methodInfo, v45, v46, v47, v48, v49, v50, v51, v52, v53, v54, v55);\nL_0131:\n\tUnityEngine.Debug::Log(v500);\nL_0133:\n\tv128 = v128 + 1;\n\tv429 = v128 < v227.Length;\n\tif (v429) goto L_00DD;\nL_014E:\n\treturn v62;\n\tv268 = new System.NullReferenceException();\n\treturnVal1 = new System.IndexOutOfRangeException();\n\treturn returnVal1;\n// 275 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	private static object CreateIdValue(Type type, List<string[]> rows, int id_col = 0, int val_col = 1)
	{
		object obj = Activator.CreateInstance(type);
		object obj2 = new Dictionary<string, int>();
		if (rows.Count >= 2)
		{
			int num = 1;
			do
			{
				string[] array = rows[num];
				string text = array[id_col];
				if (text.Length >= 1)
				{
					string[] array2 = rows[num];
					string key = array2[id_col].TrimEnd(' ');
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
					if (array3.Length > val_col)
					{
						string[] array4 = rows[index];
						SetValue(obj, fields[num2], array4[val_col]);
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

	[Token(Token = "0x600002F")]
	[Address(RVA = "0xBF6728", Offset = "0xBF6728", Length = "0x6BC")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0040;\n\tv44 = Il2CppMethodInfo;\n\tv45 = \"il2cpp_codegen_initialize_runtime_metadata\"(v44, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv67 = Il2CppMethodInfo;\n\tv68 = \"il2cpp_codegen_initialize_runtime_metadata\"(v67, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv72 = Il2CppMethodInfo;\n\tv73 = \"il2cpp_codegen_initialize_runtime_metadata\"(v72, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv77 = Il2CppMethodInfo;\n\tv78 = \"il2cpp_codegen_initialize_runtime_metadata\"(v77, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv82 = Il2CppMethodInfo;\n\tv83 = \"il2cpp_codegen_initialize_runtime_metadata\"(v82, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv87 = Il2CppMethodInfo;\n\tv88 = \"il2cpp_codegen_initialize_runtime_metadata\"(v87, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv92 = Il2CppMethodInfo;\n\tv93 = \"il2cpp_codegen_initialize_runtime_metadata\"(v92, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv96 = System.Collections.Generic.List`1<System.String[]>;\n\tv97 = \"il2cpp_codegen_initialize_runtime_metadata\"(v96, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv384 = System.Collections.Generic.List`1<System.String>;\n\tv385 = \"il2cpp_codegen_initialize_runtime_metadata\"(v384, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv414 = System.Text.StringBuilder;\n\tv61 = \"il2cpp_codegen_initialize_runtime_metadata\"(v414, separator, methodInfo, v47, v48, v49, v50, v51, v52, v53, v54, v55, v56, v57, v58, v59);\n\tv63 = 1;\n\t*([1A355B9]) = v63;\nL_0040:\n\tv65 = new System.Collections.Generic.List`1<System.String[]>();\n\tSystem.Collections.Generic.List`1<System.String[]>::.ctor(v65);\n\tv75 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v75);\n\tv85 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v85);\n\tv113 = text._stringLength < 1;\n\tif (v113) goto L_0274;\nL_0066:\n\tv432 = System.String::get_Chars(text, v923);\n\tv495 = v432 & 0xFFFF;\n\tv496 = v173 & 1;\n\tv497 = v496 == 0;\n\tif (v497) goto L_00C9;\n\tv509 = v495 != 0x5C;\n\tif (v509) goto L_0094;\n\tv522 = v923 + 1;\n\tv532 = v522 >= text._stringLength;\n\tif (v532) goto L_0094;\n\tv554 = System.String::get_Chars(text, v522);\n\tv556 = v554 & 0xFFFF;\n\tv545 = v556 == 0x22;\n\tif (v545) goto L_00C2;\nL_0094:\n\tv560 = System.String::get_Chars(text, v923);\n\tv608 = v560 & 0xFFFF;\n\tv618 = v608 != 0x22;\n\tif (v618) goto L_0114;\n\tv643 = v923 + 1;\n\tv653 = v643 >= text._stringLength;\n\tif (v653) goto L_0114;\n\tv676 = System.String::get_Chars(text, v643);\n\tv678 = v676 & 0xFFFF;\n\tv657 = v678 != 0x22;\n\tif (v657) goto L_0114;\nL_00C2:\n\tv708 = System.Text.StringBuilder::Append(v412, 0x22);\n\tv923 = v923 + 1;\n\tgoto L_FFFFFFFF;\nL_00C9:\n\tv514 = v495 == 0xD;\n\tif (v514) goto L_00E3;\n\tv564 = System.String::get_Chars(text, v923);\n\tv574 = v564 & 0xFFFF;\n\tv565 = v574 != 0xA;\n\tif (v565) goto L_018D;\nL_00E3:\n\tv318 = System.Text.StringBuilder::get_Length(v412);\n\tv179 = v318 < 1;\n\tif (v179) goto L_0186;\n\tv313 = System.Text.StringBuilder::ToString(v412);\n\tv354 = v75._items;\n\tv136 = v75._version + 1;\n\tv75._version = v136;\n\tv742 = v75._size;\n\tv778 = v75._size < v354.Length;\n\tv760 = ~v778;\n\tif (v760) goto L_01C1;\n\tv886 = v75._size + 1;\n\tv75._size = v886;\n\tv354[v742 @ X10_v20 (System.Int32)] = v313;\n\tgoto L_01C3;\nL_0114:\n\tv682 = System.String::get_Chars(text, v923);\n\tv688 = v682 & 0xFFFF;\n\tv698 = v688 != 0x5C;\n\tif (v698) goto L_014A;\n\tv375 = v923 + 1;\n\tv720 = v375 >= text._stringLength;\n\tif (v720) goto L_014A;\n\tv314 = System.String::get_Chars(text, v375);\n\tv355 = v314 & 0xFFFF;\n\tv180 = v355 != 0x6E;\n\tif (v180) goto L_014A;\n\tv917 = System.Text.StringBuilder::Append(v412, 0xA);\n\tgoto L_0263;\nL_014A:\n\tv315 = System.String::get_Chars(text, v923);\n\tv356 = v315 & 0xFFFF;\n\tv181 = v356 != 0x22;\n\tif (v181) goto L_017D;\n\tv316 = System.Text.StringBuilder::ToString(v412);\n\tv358 = v75._items;\n\tv137 = v75._version + 1;\n\tv75._version = v137;\n\tv793 = v75._size;\n\tv955 = v75._size < v358.Length;\n\tv956 = ~v955;\n\tif (v956) goto L_0214;\n\tv973 = v75._size + 1;\n\tv75._size = v973;\n\tv358[v793 @ X10_v26 (System.Int32)] = v316;\n\tgoto L_0216;\nL_017D:\n\tv317 = System.String::get_Chars(text, v923);\n\tv876 = System.Text.StringBuilder::Append(v412, v317);\n\tgoto L_0263;\nL_0186:\n\tv701 = v75 == 0;\n\tv337 = ~v701;\n\tif (v337) goto L_01D2;\n\tgoto L_02ED;\nL_018D:\n\tv319 = System.String::get_Chars(text, v923);\n\tv359 = v319 & 0xFFFF;\n\tv182 = v359 != separator;\n\tif (v182) goto L_0240;\n\tv320 = System.Text.StringBuilder::ToString(v412);\n\tv361 = v75._items;\n\tv138 = v75._version + 1;\n\tv75._version = v138;\n\tv791 = v75._size;\n\tv928 = v75._size < v361.Length;\n\tv835 = ~v928;\n\tif (v835) goto L_025B;\n\tv937 = v75._size + 1;\n\tv75._size = v937;\n\tv361[v791 @ X10_v23 (System.Int32)] = v320;\n\tgoto L_025D;\nL_01C1:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v313);\nL_01C3:\n\tv764 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v764);\nL_01D2:\n\tv183 = v75._size < 1;\n\tif (v183) goto L_FFFFFFFF;\n\tv321 = System.Collections.Generic.List`1<System.String>::ToArray(v75);\n\tv363 = v65._items;\n\tv140 = v65._version + 1;\n\tv65._version = v140;\n\tv792 = v65._size;\n\tv945 = v65._size < v363.Length;\n\tv946 = ~v945;\n\tif (v946) goto L_01F9;\n\tv966 = v65._size + 1;\n\tv65._size = v966;\n\tv363[v792 @ X10_v17 (System.Int32)] = v321;\n\tgoto L_01FC;\nL_01F9:\n\tSystem.Collections.Generic.List`1<System.String[]>::AddWithResize(v65, v321);\nL_01FC:\n\tv853 = v75._version + 1;\n\tv75._size = 0;\n\tv75._version = v853;\n\tv804 = v75._size < 1;\n\tif (v804) goto L_FFFFFFFF;\n\tSystem.Array::Clear(v75._items, 0, v75._size);\n\tgoto L_FFFFFFFF;\nL_0214:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v316);\nL_0216:\n\tv848 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v848);\n\tv856 = v923 + 1;\n\tv805 = v856 >= text._stringLength;\n\tif (v805) goto L_FFFFFFFF;\n\tv918 = System.String::get_Chars(text, v856);\n\tv920 = v918 & 0xFFFF;\n\tv893 = v920 != separator;\n\tif (v893) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0263;\nL_0240:\n\tv738 = System.String::get_Chars(text, v923);\n\tv364 = v738 & 0xFFFF;\n\tv248 = v364 == 0x22;\n\tif (v248) goto L_FFFFFFFF;\n\tv322 = System.String::get_Chars(text, v923);\n\tv849 = System.Text.StringBuilder::Append(v412, v322);\n\tgoto L_FFFFFFFF;\nL_025B:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v320);\nL_025D:\n\tv845 = new System.Text.StringBuilder();\n\tSystem.Text.StringBuilder::.ctor(v845);\nL_0263:\n\tv923 = v923 + 1;\n\tv396 = v923 < text._stringLength;\n\tif (v396) goto L_0066;\nL_0274:\n\tv325 = System.Text.StringBuilder::get_Length(v381);\n\tv185 = v325 < 1;\n\tif (v185) goto L_02A2;\n\tv324 = System.Text.StringBuilder::ToString(v381);\n\tv367 = v75._items;\n\tv142 = v75._version + 1;\n\tv75._version = v142;\n\tv578 = v75._size;\n\tv621 = v75._size < v367.Length;\n\tv596 = ~v621;\n\tif (v596) goto L_02AA;\n\tv579 = v75._size + 1;\n\tv75._size = v579;\n\tv367[v578 @ X10_v10 (System.Int32)] = v324;\n\tgoto L_02B6;\nL_02A2:\n\tv520 = v75 == 0;\n\tv347 = ~v520;\n\tif (v347) goto L_02B6;\n\tgoto L_02ED;\nL_02AA:\n\tSystem.Collections.Generic.List`1<System.String>::AddWithResize(v75, v324);\nL_02B6:\n\tv186 = v75._size < 1;\n\tif (v186) goto L_02EC;\n\tv326 = System.Collections.Generic.List`1<System.String>::ToArray(v75);\n\tv369 = v65._items;\n\tv144 = v65._version + 1;\n\tv65._version = v144;\n\tv625 = v65._size;\n\tv771 = v65._size < v369.Length;\n\tv635 = ~v771;\n\tif (v635) goto L_02DD;\n\tv626 = v65._size + 1;\n\tv65._size = v626;\n\tv369[v625 @ X10_v7 (System.Int32)] = v326;\n\tgoto L_02EC;\nL_02DD:\n\tSystem.Collections.Generic.List`1<System.String[]>::AddWithResize(v65, v326);\nL_02EC:\n\treturn v65;\nL_02ED:\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 531 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public static List<string[]> ParseCSV(string text, char separator = ',')
	{
		List<string[]> list = new List<string[]>();
		List<string> list2 = new List<string>();
		StringBuilder stringBuilder = new StringBuilder();
		bool flag = text.Length < 1;
		StringBuilder stringBuilder2 = stringBuilder;
		if (flag)
		{
			goto IL_08ee;
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
							goto IL_0b20;
						}
					}
				}
				char c7 = text[num2];
				int num12 = c7 & 0xFFFF;
				if (num12 != 34)
				{
					char value = text[num2];
					StringBuilder stringBuilder5 = stringBuilder3.Append(value);
					goto IL_04f8;
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
				int num13 = num2 + 1;
				bool flag2 = num13 >= text.Length;
				stringBuilder3 = stringBuilder6;
				if (!flag2)
				{
					char c8 = text[num13];
					int num14 = c8 & 0xFFFF;
					if (num14 == separator)
					{
						num2 = num13;
					}
					num = 0;
					stringBuilder3 = stringBuilder6;
					goto IL_0b20;
				}
			}
			else
			{
				if (num3 != 13)
				{
					char c9 = text[num2];
					int num15 = c9 & 0xFFFF;
					if (num15 != 10)
					{
						char c10 = text[num2];
						int num16 = c10 & 0xFFFF;
						if (num16 == separator)
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
							char c11 = text[num2];
							int num17 = c11 & 0xFFFF;
							if (num17 == 34)
							{
								goto IL_04f8;
							}
							char value2 = text[num2];
							StringBuilder stringBuilder8 = stringBuilder3.Append(value2);
						}
						goto IL_08e0;
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
			goto IL_08e0;
			IL_04f8:
			num = 1;
			goto IL_0b20;
			IL_0b20:
			num2++;
			bool flag3 = num2 < text.Length;
			stringBuilder2 = stringBuilder3;
			if (flag3)
			{
				continue;
			}
			goto IL_08ee;
			IL_08e0:
			num = 0;
			goto IL_0b20;
			IL_01a0:
			StringBuilder stringBuilder10 = stringBuilder3.Append('"');
			num2++;
			goto IL_04f8;
		}
		goto IL_0afa;
		IL_0afa:
		return (List<string[]>)(object)new NullReferenceException();
		IL_08ee:
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
			goto IL_0afa;
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

	[Token(Token = "0x6000030")]
	[Address(RVA = "0xBF6DE4", Offset = "0xBF6DE4", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CSVSerializer()
	{
	}
}
