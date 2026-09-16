using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace UnityEngine.Purchasing
{
	[Token(Token = "0x2000097")]
	internal static class ProductDefinitionExtensions
	{
		[Token(Token = "0x600026F")]
		[Address(RVA = "0xC5F3E8", Offset = "0xC5F3E8", Length = "0x6B0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv21 = &v21 @ X29;\n\tv31 = &v21 @ X29 - 0x80;\n\tgoto L_0020;\n\tv36 = *([1EBEA60]);\n\tv37 = *([v36 @ X8_v96]);\n\tv38 = \"il2cpp_codegen_initialize_method\"(v37, storeName, methodInfo, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51, v52);\n\tv55 = 0 | 1;\n\t*([2023398]) = v55;\nL_0020:\n\tv59 = &v21 @ X29 - 0x18;\n\t*([v21 @ X29-70]) = 0;\n\t*([v21 @ X29-90]) = 0;\n\t*([v21 @ X29-88]) = 0;\n\t*([v21 @ X29-A0]) = 0;\n\t*([v21 @ X29-98]) = 0;\n\t*([v31 @ X22_v1]) = 0;\n\t*([v21 @ X29-C0]) = 0;\n\t*([v21 @ X29-B0]) = 0;\n\t*([v21 @ X29-C8]) = 0;\n\t*([v59 @ X19_v2-100]) = &v58 @ stack_-140;\n\tv64 = new System.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>();\n\tv67 = &v21 @ X29 - 0x10;\n\t*([v67 @ X19_v3-100]) = v64;\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>::.ctor(v64);\n\tv75 = System.Collections.Generic.List`1<System.Object>::GetEnumerator(productsList);\n\tv281 = *([v21 @ X29-E0]);\n\t*([v21 @ X29-70]) = *([v21 @ X29-D0]);\n\t*([v31 @ X22_v1]) = *([v21 @ X29-E0]);\nL_004E:\n\t;\n\tv294 = &v21 @ X29 - 0x80;\n\tv295 = 0xEF9AB0(v294, *([v278 @ X9_v12 (Il2CppMethodInfo)]), Il2CppMethodInfo, *([v1218 @ X0_v82]), 0, v42, v43, v44, v281, v243, v47, v48, v49, v50, v51, v52);\n\tv350 = v295 & 1;\n\tv351 = v350 == 0;\n\tif (v351) goto L_01EC;\n\tv329 = *([v21 @ X29-70]);\n\tv435 = *([v329 @ X23_v9]);\n\tv436 = *([v234 @ X19_v15 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv439 = *([v435 @ X8_v37+128]) < *([v436 @ X1_v26+128]);\n\tv440 = ~v439;\n\tv448 = ~v440;\n\tif (v448) goto L_01F3;\n\tv530 = *([v436 @ X1_v26+128]) << 3;\n\tv531 = *([v435 @ X8_v37+C8]) + v530;\n\tv542 = *([v531 @ X8_v40-8]) != v436;\n\tif (v542) goto L_01F3;\n\tv615 = &v21 @ X29 - 0x88;\n\tv617 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v329, \"id\", v615);\n\tv689 = &v21 @ X29 - 0x90;\n\tv691 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v329, \"store_ids\", v689);\n\tv667 = &v21 @ X29 - 0x98;\n\tv843 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v329, \"type\", v667);\n\tv926 = *([v21 @ X29-90]);\n\tv927 = *([v21 @ X29-90]) == 0;\n\tif (v927) goto L_FFFFFFFF;\n\tv977 = *([v926 @ X8_v48 (System.Int32)]);\n\tv978 = *([v234 @ X19_v15 (Il2CppClass<System.Collections.Generic.Dictionary`2<System.String, System.Object>>)]);\n\tv981 = *([v977 @ X10_v18+128]) < *([v978 @ X9_v33+128]);\n\tv982 = ~v981;\n\tif (v982) goto L_009D;\n\tgoto L_00B0;\nL_009D:\n\t;\n\tv1022 = *([v978 @ X9_v33+128]) << 3;\n\tv1023 = *([v977 @ X10_v18+C8]) + v1022;\n\tv1034 = *([v1023 @ X10_v20-8]) != v978;\n\tif (v1034) goto L_FFFFFFFF;\n\tgoto L_00B0;\nL_00B0:\n\tv289 = *([v21 @ X29-88]);\n\tv882 = *([v21 @ X29-88]) == 0;\n\tif (v882) goto L_00C0;\n\tv855 = *([v289 @ X22_v17 (System.String)]) != System.String;\n\tif (v855) goto L_01FB;\nL_00C0:\n\tv1057 = v880 == 0;\n\tif (v1057) goto L_0113;\n\tv1062 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::GetEnumerator(v880);\n\tv357 = &v21 @ X29 - 8;\n\tv281 = *([v21 @ X29-F8]);\n\tv243 = *([v357 @ X30_v24-100]);\n\t*([v21 @ X29-A0]) = *([v21 @ X29-E8]);\n\t*([v21 @ X29-C0]) = *([v357 @ X30_v24-100]);\n\t*([v21 @ X29-B0]) = *([v21 @ X29-F8]);\n\tgoto L_00E6;\nL_00D1:\n\tv1213 = System.String::ToLower(storeName);\n\tv1207 = System.String::op_Equality(v1213, v1121);\nL_00DF:\n\tv1069 = v1087 != 0;\n\tif (v1069) goto L_FFFFFFFF;\n\tgoto L_00E6;\nL_00E6:\n\tv1088 = &v21 @ X29 - 0xC0;\n\tv1089 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v1088, Il2CppMethodInfo, v667);\n\tv1113 = v1089 == 0;\n\tif (v1113) goto L_0136;\n\tv419 = *([v21 @ X29-B0]) == 0;\n\tif (v419) goto L_013C;\n\tv402 = *([v21 @ X29-A8]);\n\tv1121 = System.String::ToLower(*([v21 @ X29-B0]));\n\tv420 = *([v21 @ X29-A8]) == 0;\n\tif (v420) goto L_0103;\n\tv367 = *([v402 @ X23_v21 (System.String)]) != System.String;\n\tif (v367) goto L_013F;\nL_0103:\n\tv1179 = System.String::IsNullOrEmpty(*([v21 @ X29-A8]));\n\tv1192 = v1179 == 0;\n\tif (v1192) goto L_0109;\n\tgoto L_00DF;\nL_0109:\n\tv1201 = storeName == 0;\n\tv418 = ~v1201;\n\tif (v418) goto L_00D1;\n\tv414 = new System.NullReferenceException();\n\tgoto L_0207;\nL_0113:\n\tv667 = &v21 @ X29 - 0xC8;\n\tv1067 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v329, \"storeSpecificId\", v667);\n\tv340 = *([v21 @ X29-C8]);\n\tv342 = *([v21 @ X29-C8]) == 0;\n\tif (v342) goto L_012F;\n\tv310 = *([v340 @ X0_v91 (System.String)]) != System.String;\n\tif (v310) goto L_0206;\nL_012F:\n\tv1111 = *([v21 @ X29-C8]) != 0;\n\tif (v1111) goto L_FFFFFFFF;\n\tgoto L_FFFFFFFF;\n\tgoto L_0182;\nL_0136:\n\tv1117 = &v21 @ X29 - 0x18;\n\tv1118 = *([v1117 @ X30_v25-100]);\n\tv508 = v508 + 1;\n\t*([v1118 @ X8_v80+v508 @ X25_v3 (System.String)*4]) = 0xDF;\n\tgoto L_015C;\nL_013C:\n\tv415 = new System.NullReferenceException();\n\tgoto L_0207;\nL_013F:\n\tv416 = new System.InvalidCastException();\n\tgoto L_0207;\n\tgoto L_0148;\n\tgoto L_0148;\n\tgoto L_0148;\n\tgoto L_0148;\n\tgoto L_0148;\n\tgoto L_0148;\n\tgoto L_0148;\nL_0148:\n\tX8 = X1;\n\tX21 = X0;\n\tC = X8 < 1;\n\tC = ~C;\n\tTEMP1 = X8 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X8 ^ 1;\n\tTEMP3 = X8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_022A;\n\tX0 = X21;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX21 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_015C:\n\tv1124 = &v21 @ X29 - 0xC0;\n\tv225 = System.Collections.Generic.Dictionary`2<System.String, System.Object>::TryGetValue(v1124, Il2CppMethodInfo, v667);\n\tv1151 = v508 + 1;\n\tv1163 = v1151 == 0;\n\tif (v1163) goto L_FFFFFFFF;\n\tv1126 = &v21 @ X29 - 0x18;\n\tv1180 = *([v1126 @ X30_v27-100]);\n\tv1128 = *([v1180 @ X8_v84+v508 @ X25_v3 (System.String)*4]) != 0xDF;\n\tif (v1128) goto L_FFFFFFFF;\n\tv1153 = 0xFFFFFFFF ^ v508;\n\tv508 = v508 + v1153;\n\tgoto L_0182;\n\tgoto L_0182;\nL_0182:\n\tgoto L_018A;\n\tv1166 = *([v1157 @ X0_v74+E0]);\n\tv1167 = v1166 == 0;\n\tv1168 = ~v1167;\n\tif (v1168) goto L_018A;\n\tv1170 = \"il2cpp_codegen_runtime_class_init\"(v1157, v1148, v936, v555, v172, v42, v43, v44, v281, v243, v47, v48, v49, v50, v51, v52);\nL_018A:\n\tv1175 = System.Type::GetTypeFromHandle(UnityEngine.Purchasing.ProductType);\n\tv545 = *([v21 @ X29-98]);\n\tgoto L_0199;\n\tv1194 = *([v1186 @ X0_v78+E0]);\n\tv1195 = v1194 == 0;\n\tv1196 = ~v1195;\n\tif (v1196) goto L_0199;\n\tv1197 = \"il2cpp_codegen_runtime_class_init\"(v1186, v1174, v936, v555, v172, v42, v43, v44, v281, v243, v47, v48, v49, v50, v51, v52);\nL_0199:\n\tv967 = *([v21 @ X29-98]) == 0;\n\tif (v967) goto L_01AB;\n\tv940 = *([v545 @ X24_v16 (System.String)]) != System.String;\n\tif (v940) goto L_01FD;\nL_01AB:\n\tv586 = System.Enum::Parse(v1175, *([v21 @ X29-98]));\n\tv628 = v628_asT == 0;\n\tif (v628) goto L_01F8;\n\tv1218 = \"il2cpp_vm_object_unbox\"(v586, UnityEngine.Purchasing.ProductType, 0, v555, 0, v42, v43, v44, v281, v243, v47, v48, v49, v50, v51, v52);\n\tv1012 = *([v21 @ X29-88]);\n\tv1015 = new UnityEngine.Purchasing.ProductDefinition();\n\tv1016 = *([v21 @ X29-88]) == 0;\n\tif (v1016) goto L_01DC;\n\tv1003 = *([v1012 @ X25_v18 (System.String)]) != System.String;\n\tif (v1003) goto L_01FF;\nL_01DC:\n\tUnityEngine.Purchasing.ProductDefinition::.ctor(v1015, *([v21 @ X29-88]), v289, *([v1218 @ X0_v82]));\n\tv245 = &v21 @ X29 - 0x10;\n\tSystem.Collections.Generic.List`1<UnityEngine.Purchasing.ProductDefinition>::Add(*([v245 @ X30_v23-100]), v1015);\n\tgoto L_004E;\nL_01EC:\n\tv429 = &v21 @ X29 - 0x18;\n\tv430 = *([v429 @ X30_v15-100]);\n\tv508 = v508 + 1;\n\t*([v430 @ X9_v13+v508 @ X25_v3 (System.String)*4]) = 0x162;\n\tgoto L_0233;\nL_01F3:\n\tthrow System.InvalidCastException;\n\tv477 = new System.NullReferenceException();\n\tv593 = new System.NullReferenceException();\nL_01F8:\n\tv660 = new System.InvalidCastException();\n\tthrow System.NullReferenceException;\nL_01FB:\n\tthrow System.InvalidCastException;\nL_01FD:\n\tthrow System.InvalidCastException;\nL_01FF:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\n\tv238 = new System.TypeLoadException();\nL_0206:\n\tv349 = new System.InvalidCastException();\nL_0207:\n\tgoto L_022A;\n\t// 520 Jump @b121\n\tgoto L_0216;\n\t// 522 Jump @b121\n\t// 523 Jump @b121\n\tgoto L_0216;\n\t// 525 Jump @b121\n\tgoto L_0216;\n\t// 527 Jump @b121\n\tgoto L_0259;\n// ... truncated")]
		internal unsafe static List<ProductDefinition> DecodeJSON(this List<object> productsList, string storeName)
		{
			//IL_0017: Expected O, but got I
			//IL_0bf7: Expected O, but got I
			//IL_0c1e: Expected O, but got I4
			//IL_0c4d: Expected O, but got I
			//IL_0056: Expected O, but got I
			//IL_0063: Expected O, but got I8
			//IL_0077: Expected I, but got O
			//IL_0d27: Expected O, but got I
			//IL_08a7: Expected O, but got I
			//IL_08b7: Expected O, but got I
			//IL_08c6: Expected O, but got I
			//IL_09a4: Expected O, but got I
			//IL_09bc: Expected O, but got I
			//IL_008c: Expected O, but got I
			//IL_0a69: Expected O, but got I
			//IL_0a79: Expected O, but got I
			//IL_00a1: Expected O, but got I
			//IL_0aa7: Expected O, but got I
			//IL_0ab7: Expected O, but got I
			//IL_0111: Expected O, but got I
			//IL_0a01: Expected O, but got I
			//IL_0a11: Expected O, but got I
			//IL_0a20: Expected O, but got I
			//IL_0a30: Expected O, but got I
			//IL_0c68: Expected O, but got I
			//IL_01ea: Expected O, but got I4
			//IL_01f2: Expected O, but got I
			//IL_0265: Expected O, but got I
			//IL_0509: Expected O, but got I
			//IL_0301: Expected O, but got I4
			//IL_0314: Expected O, but got I
			//IL_0335: Expected O, but got I
			//IL_05aa: Expected O, but got I
			//IL_055f: Expected I, but got O
			//IL_0c9c: Expected O, but got I
			//IL_0cab: Expected O, but got I
			//IL_0947: Expected O, but got I
			//IL_094f: Expected I4, but got O
			//IL_05be: Expected O, but got I
			//IL_05ce: Expected O, but got I
			//IL_05dd: Expected O, but got I
			//IL_0643: Expected O, but got I
			//IL_0652: Expected O, but got I
			//IL_0665: Expected O, but got I
			//IL_072a: Expected O, but got I
			//IL_05fd: Expected O, but got I
			//IL_0605: Expected I4, but got O
			//IL_0691: Expected O, but got I
			//IL_06a1: Expected O, but got I
			//IL_03e6: Expected O, but got I
			//IL_03f7: Expected O, but got I
			//IL_0794: Expected O, but got I
			//IL_0bc5: Expected O, but got I4
			//IL_0bda: Expected O, but got I4
			//IL_0bde: Expected O, but got I4
			//IL_096a: Expected O, but got I4
			//IL_098c: Expected O, but got I4
			//IL_045c: Expected O, but got I
			//IL_07aa: Expected I4, but got O
			//IL_0acd: Expected O, but got I4
			//IL_06dd: Expected I4, but got I8
			//IL_06eb: Expected O, but got I
			//IL_062f: Expected I4, but got O
			//IL_07e2: Expected O, but got I
			//IL_07fb: Expected I4, but got O
			//IL_07fb: Expected O, but got I
			//IL_0b54: Expected O, but got I4
			//IL_0b54: Expected O, but got I4
			//IL_0b79: Expected O, but got I4
			//IL_0b87: Expected O, but got I4
			//IL_04cf: Expected I4, but got O
			//IL_0b9e: Expected O, but got I4
			//IL_0b2f: Expected O, but got I4
			//IL_03ab: Expected O, but got I
			//IL_0864: Expected O, but got I
			//IL_087f: Expected O, but got I
			//IL_0893: Expected I, but got O
			object obj = obj;
			object obj2 = (long)(IntPtr)obj - 128L;
			object obj3 = (long)(IntPtr)obj - 24L;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			obj2 = 0;
			_ = 0;
			_ = 0;
			_ = 0;
			List<ProductDefinition> list = new List<ProductDefinition>();
			object obj4 = (long)(IntPtr)obj - 16L;
			object enumerator = productsList.GetEnumerator();
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-E0]");
			int num = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-D0]");
			_ = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-E0]");
			obj2 = 0;
			string text = (string)4294967295L;
			IntPtr intPtr = (IntPtr)0;
			IntPtr intPtr2 = (IntPtr)typeof(Dictionary<string, object>);
			object obj6 = default(object);
			object obj16 = default(object);
			List<ProductDefinition> result;
			object obj18 = default(object);
			while (true)
			{
				object obj5 = (long)(IntPtr)obj - 128L;
				Cpp2ILHelpers.NoteDecompilerIssue("Method not found @EF9AB0");
				object obj7;
				ref object value;
				int num5;
				if ((uint)((ulong)(long)(IntPtr)obj6 & 1uL) != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-70]");
					obj7 = 0;
					object obj8 = obj7;
					object obj9 = (long)intPtr2;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v37+128]");
					IntPtr intPtr3 = (IntPtr)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ X1_v26+128]");
					if ((long)intPtr3 >= 0L)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v436 @ X1_v26+128]");
						int num2 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v435 @ X8_v37+C8]");
						object obj10 = 0L + (long)num2;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v531 @ X8_v40-8]");
						if ((IntPtr)0 == (IntPtr)obj9)
						{
							bool flag = ((Dictionary<string, object>)obj7).TryGetValue("id", out *(object*)((long)(IntPtr)obj - 136L));
							bool flag2 = ((Dictionary<string, object>)obj7).TryGetValue("store_ids", out *(object*)((long)(IntPtr)obj - 144L));
							value = ref *(object*)((long)(IntPtr)obj - 152L);
							bool flag3 = ((Dictionary<string, object>)obj7).TryGetValue("type", out value);
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							int num3 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
							if ((IntPtr)0 != (IntPtr)0)
							{
								object obj11 = num3;
								object obj12 = (long)intPtr2;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ X10_v18+128]");
								IntPtr intPtr4 = (IntPtr)0;
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ X9_v33+128]");
								if ((long)intPtr4 >= 0L)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v978 @ X9_v33+128]");
									int num4 = 0;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v977 @ X10_v18+C8]");
									object obj13 = 0L + (long)num4;
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1023 @ X10_v20-8]");
									if ((IntPtr)0 == (IntPtr)obj12)
									{
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-90]");
										num5 = 0;
									}
									else
									{
										num5 = 0;
									}
									goto IL_0c58;
								}
							}
							num5 = 0;
							goto IL_0c58;
						}
					}
					throw new InvalidCastException();
				}
				object obj14 = (long)(IntPtr)obj - 24L;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v429 @ X30_v15-100]");
				object obj15 = 0;
				text = (string)((long)(IntPtr)text + 1L);
				_ = 354;
				bool flag4 = false;
				goto IL_0995;
				IL_0cf7:
				string text2;
				bool flag6;
				if ((IntPtr)text2 == (IntPtr)1)
				{
					bool flag5 = ((Dictionary<string, object>)flag6).TryGetValue(text2, out value);
					flag4 = ((bool*)(flag5 ? 1 : 0))->m_value;
					bool flag7 = ((Dictionary<string, object>)flag5).TryGetValue(text2, out value);
					goto IL_0995;
				}
				bool flag8 = (IntPtr)text2 != (IntPtr)1;
				bool flag9 = flag6;
				if (!flag8)
				{
					bool flag10 = ((Dictionary<string, object>)flag6).TryGetValue(text2, out value);
					bool value2 = ((bool*)(flag10 ? 1 : 0))->m_value;
					Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
					if ((uint)((ulong)(long)(IntPtr)obj16 & 1uL) != 0)
					{
						bool flag11 = ((Dictionary<string, object>)obj16).TryGetValue((string)((bool*)(value2 ? 1 : 0))->m_value, out value);
						result = null;
						break;
					}
					bool flag12 = ((Dictionary<string, object>)8).TryGetValue((string)((bool*)(value2 ? 1 : 0))->m_value, out value);
					((bool*)(flag12 ? 1 : 0))->m_value = ((bool*)(flag10 ? 1 : 0))->m_value;
					text2 = (string)(32022528 + 2160);
					bool flag13 = ((Dictionary<string, object>)flag12).TryGetValue(text2, out *(object*)null);
					bool flag14 = ((Dictionary<string, object>)flag13).TryGetValue(text2, out *(object*)null);
					value = ref *(object*)null;
					flag9 = flag13;
				}
				bool flag15 = ((Dictionary<string, object>)flag9).TryGetValue(text2, out value);
				return (List<ProductDefinition>)((Dictionary<string, object>)flag15).TryGetValue(text2, out value);
				IL_070c:
				Type typeFromHandle = typeof(ProductType);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
				string text3 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
				string text5;
				if ((IntPtr)0 == (IntPtr)0 || (object)text3.GetType() == typeof(string))
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-98]");
					object obj17 = Enum.Parse(typeFromHandle, (string)0);
					if ((int)((obj17 is ProductType) ? obj17 : null) != 0)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_object_unbox\"");
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
						string text4 = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
						ProductDefinition item = new ProductDefinition((string)0, text5, (ProductType)obj18);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
						if ((IntPtr)0 == (IntPtr)0 || (object)text4.GetType() == typeof(string))
						{
							object obj19 = (long)(IntPtr)obj - 16L;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v245 @ X30_v23-100]");
							((List<ProductDefinition>)0).Add(item);
							intPtr = (IntPtr)0;
							intPtr2 = (IntPtr)typeof(Dictionary<string, object>);
							continue;
						}
						throw new InvalidCastException();
					}
					InvalidCastException ex = new InvalidCastException();
					throw new NullReferenceException();
				}
				throw new InvalidCastException();
				IL_0c58:
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
				text5 = (string)0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-88]");
				IntPtr intPtr6;
				if ((IntPtr)0 == (IntPtr)0 || (object)text5.GetType() == typeof(string))
				{
					if (num5 != 0)
					{
						object enumerator2 = ((Dictionary<string, object>)num5).GetEnumerator();
						object obj20 = (long)(IntPtr)obj - 8L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-F8]");
						num = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ X30_v24-100]");
						object obj21 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-E8]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v357 @ X30_v24-100]");
						_ = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-F8]");
						_ = 0;
						while (true)
						{
							object obj22 = (long)(IntPtr)obj - 192L;
							if (!((Dictionary<string, object>)obj22).TryGetValue((string)0, out value))
							{
								break;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
							if ((IntPtr)0 == (IntPtr)0)
							{
								goto IL_05e8;
							}
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
							string text6 = (string)0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-B0]");
							string text7 = ((string)0).ToLower();
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
							if ((IntPtr)0 == (IntPtr)0 || (object)text6.GetType() == typeof(string))
							{
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
								int num6;
								if (!string.IsNullOrEmpty((string)0))
								{
									if (storeName == null)
									{
										goto IL_04b3;
									}
									string text8 = storeName.ToLower();
									bool flag16 = text8 == text7;
									value = ref *(object*)null;
									num6 = (flag16 ? 1 : 0);
								}
								else
								{
									num6 = 0;
								}
								if (num6 != 0)
								{
									Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-A8]");
									text5 = (string)0;
								}
								continue;
							}
							goto IL_060a;
						}
						object obj23 = (long)(IntPtr)obj - 24L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1117 @ X30_v25-100]");
						object obj24 = 0;
						text = (string)((long)(IntPtr)text + 1L);
						_ = 223;
						object obj25 = (long)(IntPtr)obj - 192L;
						bool flag17 = ((Dictionary<string, object>)obj25).TryGetValue((string)0, out value);
						object obj26 = (long)(IntPtr)text + 1L;
						IntPtr intPtr5;
						if (obj26 != null)
						{
							object obj27 = (long)(IntPtr)obj - 24L;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1126 @ X30_v27-100]");
							object obj28 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1180 @ X8_v84+v508 @ X25_v3 (System.String)*4]");
							if ((IntPtr)0 == (IntPtr)223)
							{
								int num7 = (int)(0xFFFFFFFFL ^ (long)(IntPtr)text);
								text = (string)((long)(IntPtr)text + (long)num7);
								intPtr5 = (IntPtr)0;
								goto IL_070c;
							}
						}
						intPtr5 = (IntPtr)0;
						intPtr6 = (IntPtr)0;
					}
					else
					{
						value = ref *(object*)((long)(IntPtr)obj - 200L);
						bool flag18 = ((Dictionary<string, object>)obj7).TryGetValue("storeSpecificId", out value);
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
						string text9 = (string)0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							bool flag19 = (object)text9.GetType() != typeof(string);
							intPtr6 = (IntPtr)0;
							IntPtr intPtr7 = (IntPtr)typeof(string);
							if (flag19)
							{
								InvalidCastException ex2 = new InvalidCastException();
								text2 = (string)(long)intPtr7;
								flag6 = (byte)(int)ex2 != 0;
								goto IL_0cf7;
							}
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v21 @ X29-C8]");
							text5 = (string)0;
						}
						IntPtr intPtr5 = (IntPtr)0;
					}
					goto IL_070c;
				}
				throw new InvalidCastException();
				IL_0995:
				object obj29 = (long)(IntPtr)obj - 128L;
				((List<object>.Enumerator*)obj29)->Dispose();
				object obj30 = (long)(IntPtr)text + 1L;
				if (obj30 != null)
				{
					if (!flag4)
					{
						object obj31 = (long)(IntPtr)obj - 16L;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v768 @ X30_v5-100]");
						result = (List<ProductDefinition>)0;
						break;
					}
					object obj32 = (long)(IntPtr)obj - 24L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v726 @ X30_v8-100]");
					object obj33 = 0;
					object obj34 = (long)(IntPtr)obj - 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v728 @ X30_v9-100]");
					result = (List<ProductDefinition>)0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v727 @ X8_v14+v508 @ X25_v3 (System.String)*4]");
					if ((IntPtr)0 == (IntPtr)354)
					{
						break;
					}
				}
				else
				{
					object obj35 = (long)(IntPtr)obj - 16L;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v662 @ X30_v7-100]");
					result = (List<ProductDefinition>)0;
					if (!flag4)
					{
						break;
					}
				}
				throw new TypeLoadException();
				IL_060a:
				InvalidCastException ex3 = new InvalidCastException();
				intPtr6 = (IntPtr)0;
				text2 = (string)(object)typeof(string);
				flag6 = (byte)(int)ex3 != 0;
				goto IL_0cf7;
				IL_04b3:
				NullReferenceException ex4 = new NullReferenceException();
				intPtr6 = (IntPtr)0;
				text2 = null;
				flag6 = (byte)(int)ex4 != 0;
				goto IL_0cf7;
				IL_05e8:
				NullReferenceException ex5 = new NullReferenceException();
				intPtr6 = (IntPtr)0;
				text2 = (string)0;
				flag6 = (byte)(int)ex5 != 0;
				goto IL_0cf7;
			}
			return result;
		}
	}
}
