using System;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Events;

namespace Facebook.Unity
{
	[Token(Token = "0x2000045")]
	internal class CodelessIAPAutoLog
	{
		[Token(Token = "0x600016C")]
		[Address(RVA = "0xD23AB8", Offset = "0xD23AB8", Length = "0x370")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EF4080]);\n\tv27 = *([v26 @ X8_v60]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\n\tv46 = 0 | 1;\n\t*([2023B9C]) = v46;\nL_0017:\n\tv47 = Facebook.Unity.FB+Mobile::IsImplicitPurchaseLoggingEnabled();\n\tv49 = v47 == 0;\n\tif (v49) goto L_00C6;\n\tv54 = Facebook.Unity.CodelessIAPAutoLog::GetProperty(v44, \"metadata\");\n\tv125 = Facebook.Unity.CodelessIAPAutoLog::GetProperty(v44, \"definition\");\n\tv129 = v54 == 0;\n\tif (v129) goto L_00C6;\n\tv130 = v125 == 0;\n\tif (v130) goto L_00C6;\n\tv192 = Facebook.Unity.CodelessIAPAutoLog::GetProperty(v54, \"localizedPrice\");\n\tv208 = v208_asT == 0;\n\tif (v208) goto L_00C8;\n\tv210 = \"il2cpp_vm_object_unbox\"(v192, System.Decimal, v368, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\tv232 = Facebook.Unity.CodelessIAPAutoLog::GetProperty(v54, \"isoCurrencyCode\");\n\tv264 = v232 == 0;\n\tif (v264) goto L_0061;\n\tv272 = *([v232 @ X0_v48 (System.Object)]) != System.String;\n\tif (v272) goto L_00CC;\nL_0061:\n\tv317 = Facebook.Unity.CodelessIAPAutoLog::GetProperty(v125, \"id\");\n\tv341 = v317 == 0;\n\tif (v341) goto L_0076;\n\tv320 = *([v317 @ X0_v50 (System.Object)]) != System.String;\n\tif (v320) goto L_00CE;\nL_0076:\n\tgoto L_007F;\n\tv357 = *([v351 @ X0_v51+E0]);\n\tv358 = v357 == 0;\n\tv359 = ~v358;\n\tif (v359) goto L_007F;\n\tv361 = \"il2cpp_codegen_runtime_class_init\"(v351, v349, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43);\nL_007F:\n\tv62 = System.Decimal::op_Explicit(*([v210 @ X0_v46]));\n\tv382 = 0x115CA98(&v58 @ stack_-48_v6 (System.Nullable`1<System.Single>), Il2CppMethodInfo, 0, v31, v32, v33, v34, v35, v62, v37, v38, v39, v40, v41, v42, v43);\n\tv392 = new System.Collections.Generic.Dictionary`2<System.String, System.Object>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::.ctor(v392);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v392, \"_implicitlyLogged\", \"1\");\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v392, \"fb_currency\", v232);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Object>::Add(v392, \"fb_content_id\", v317);\n\tgoto L_00BC;\n\tv454 = *([v449 @ X0_v62+E0]);\n\tv455 = v454 == 0;\n\tv456 = ~v455;\n\tif (v456) goto L_00BC;\n\tv458 = \"il2cpp_codegen_runtime_class_init\"(v449, v439, v441, v56, v32, v33, v34, v35, v62, v37, v38, v39, v40, v41, v42, v43);\nL_00BC:\n\tFacebook.Unity.FB::LogAppEvent(\"fb_mobile_purchase\", v58, v392);\nL_00C6:\n\treturn;\n\tv209 = new System.NullReferenceException();\nL_00C8:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_00CC:\n\tthrow System.InvalidCastException;\nL_00CE:\n\tv347 = new System.InvalidCastException();\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\n\tgoto L_00E7;\nL_00E7:\n\tv79 = System.String != 1;\n\tif (v79) goto L_0122;\n\tv367 = 0x6D2BC0(v347, System.String, v368, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\tv384 = *([v367 @ X0_v18]);\n\tv176 = *([v384 @ X19_v8]);\n\tv388 = \"il2cpp_vm_class_is_assignable_from\"(System.Exception, *([v384 @ X19_v8]), v368, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\tv393 = v388 & 1;\n\tv394 = v393 == 0;\n\tif (v394) goto L_0116;\n\tv396 = 0x6D2490(v388, v176, v368, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\tv399 = v384 == 0;\n\tif (v399) goto L_011E;\n\tv413 = *([v384 @ X19_v8]);\n\t*([v413 @ X8_v16+180])(v417, v384, *([v413 @ X8_v16+188]), v368, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\tv422 = System.String::Concat(\"Failed to automatically handle Purchase Completed: \", v417);\n\tgoto L_0113;\n\tv442 = *([v139 @ X8_v22+E0]);\n\tv443 = v442 == 0;\n\tv444 = ~v443;\n\tif (v444) goto L_0113;\n\tv453 = v139;\n\tv446 = \"il2cpp_codegen_runtime_class_init\"(v453, v122, v66, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\nL_0113:\n\tFacebook.Unity.FacebookLogger::Log(v422);\n\tgoto L_00C6;\nL_0116:\n\tv398 = 0x6D1E60(8, *([v384 @ X19_v8]), v368, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\t*([v398 @ X0_v26]) = *([v367 @ X0_v18]);\n\tv176 = 0x1E8A000 + 0x870;\n\tv404 = 0x6D2A00(v398, v176, 0, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\nL_011E:\n\tv425 = new System.NullReferenceException();\n\tv371 = 0x6D2490(v425, v176, 0, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\nL_0122:\n\tv376 = 0x6D2380(v186, v176, 0, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\tv178 = 0x846AA4(v376, v176, 0, v31, v32, v33, v34, v35, v63, v37, v38, v39, v40, v41, v42, v43);\n\treturn;\n// 191 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void handlePurchaseCompleted(object data)
		{
			//IL_0116: Expected I, but got O
			//IL_017d: Expected I, but got O
			//IL_0280: Expected I, but got O
			if (!FB.Mobile.IsImplicitPurchaseLoggingEnabled())
			{
				return;
			}
			object inObj = default(object);
			object property = GetProperty(inObj, "metadata");
			object property2 = GetProperty(inObj, "definition");
			if (property == null || property2 == null)
			{
				return;
			}
			object property3 = GetProperty(property, "localizedPrice");
			decimal num = (decimal)((property3 is decimal) ? property3 : null);
			if (num != null)
			{
				Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_object_unbox\"");
				object property4 = GetProperty(property, "isoCurrencyCode");
				if (property4 != null)
				{
					bool flag = (object)property4.GetType() != typeof(string);
					IntPtr intPtr = (IntPtr)typeof(string);
					if (flag)
					{
						throw new InvalidCastException();
					}
				}
				object property5 = GetProperty(property2, "id");
				if (property5 != null)
				{
					bool flag2 = (object)property5.GetType() != typeof(string);
					IntPtr intPtr = (IntPtr)typeof(string);
					if (flag2)
					{
						InvalidCastException ex = new InvalidCastException();
						bool flag3 = (IntPtr)typeof(string) != (IntPtr)1;
						InvalidCastException ex2 = ex;
						if (!flag3)
						{
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
							object obj2 = default(object);
							object obj = obj2;
							intPtr = (IntPtr)obj;
							Il2CppRuntime.Boundary("UNKNOWN", "Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
							object obj3 = default(object);
							if ((uint)((ulong)(long)(IntPtr)obj3 & 1uL) != 0)
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
								if (obj != null)
								{
									object obj4 = obj;
									Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v413 @ X8_v16+180] (should have been resolved before IL gen)");
									string text = default(string);
									string msg = "Failed to automatically handle Purchase Completed: " + text;
									FacebookLogger.Log(msg);
									return;
								}
							}
							else
							{
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_allocate_exception", "Method not found @6D1E60 (native __cxa_allocate_exception)");
								object obj5 = obj2;
								intPtr = (IntPtr)(32022528 + 2160);
								Il2CppRuntime.Boundary("SYSTEM_API:__cxa_throw", "Method not found @6D2A00 (native __cxa_throw)");
							}
							NullReferenceException ex3 = new NullReferenceException();
							Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
							ex2 = (InvalidCastException)(object)ex3;
						}
						Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
						Il2CppRuntime.Boundary("UNKNOWN", "Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
						return;
					}
				}
				object obj6 = default(object);
				float num2 = (float)(decimal)obj6;
				Il2CppRuntime.Boundary("UNKNOWN", "Method not found @115CA98 (inside System.Nullable`1<System.Int64>::Unbox +0xA8)");
				Dictionary<string, object> dictionary = new Dictionary<string, object>();
				dictionary.Add("_implicitlyLogged", "1");
				dictionary.Add("fb_currency", property4);
				dictionary.Add("fb_content_id", property5);
				float? valueToSum = default(float?);
				FB.LogAppEvent("fb_mobile_purchase", valueToSum, dictionary);
				return;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x600016D")]
		[Address(RVA = "0xD2415C", Offset = "0xD2415C", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EA9E30]);\n\tv21 = *([v20 @ X8_v12]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2023B9D]) = v40;\nL_001A:\n\tv47 = Facebook.Unity.CodelessIAPAutoLog::FindObjectsOfTypeByName(\"IAPButton\", \"UnityEngine.Purchasing\");\n\tv49 = v47 == 0;\n\tif (v49) goto L_004F;\n\tv137 = v47.Length;\n\tv61 = v47.Length < 1;\n\tif (v61) goto L_004F;\nL_002C:\n\tv150 = v114 < v137;\n\tv132 = ~v150;\n\tif (v132) goto L_0050;\n\tFacebook.Unity.CodelessIAPAutoLog::addListenerToGameObject(v47[v114 @ X21_v4 (System.Int32)], listenerObject);\n\tv137 = v47.Length;\n\tv114 = v114 + 1;\n\tv70 = v114 < v47.Length;\n\tif (v70) goto L_002C;\nL_004F:\n\treturn;\nL_0050:\n\tv152 = new System.IndexOutOfRangeException();\n\tthrow v152;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void addListenerToIAPButtons(object listenerObject)
		{
			UnityEngine.Object[] array = FindObjectsOfTypeByName("IAPButton", "UnityEngine.Purchasing");
			if (array == null)
			{
				return;
			}
			int num = array.Length;
			if (array.Length < 1)
			{
				return;
			}
			int num2 = 0;
			while (num2 < num)
			{
				addListenerToGameObject(array[num2], listenerObject);
				num = array.Length;
				num2++;
				if (num2 >= array.Length)
				{
					return;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
		}

		[Token(Token = "0x600016E")]
		[Address(RVA = "0xD242A8", Offset = "0xD242A8", Length = "0x33C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EBA6E8]);\n\tv35 = *([v34 @ X8_v49]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, listenerObject, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2023B9E]) = v53;\nL_0021:\n\tv60 = Facebook.Unity.CodelessIAPAutoLog::FindTypeInAssemblies(\"Product\", \"UnityEngine.Purchasing\");\n\tv62 = v60 == 0;\n\tif (v62) goto L_0104;\n\tgoto L_0036;\n\tv83 = *([v65 @ X0_v4+E0]);\n\tv84 = v83 == 0;\n\tv85 = ~v84;\n\tif (v85) goto L_0036;\n\tv87 = \"il2cpp_codegen_runtime_class_init\"(v65, v59, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\nL_0036:\n\tv92 = System.Type::GetTypeFromHandle(UnityEngine.Events.UnityEvent`1);\n\tv195 = System.Type::GetTypeFromHandle(UnityEngine.Events.UnityAction`1);\n\t// 68 NewArr v202 @ X0_v11 (System.Type[]), typeof(System.Type[]), 1\n\t// 75 IsInst v208 @ X0_v18, typeof(System.Type), v60 @ X0_v3 (System.Type)\n\tv305 = v202.Length == 0;\n\tif (v305) goto L_0107;\n\tv202[0] = v60;\n\tv423 = System.Type::MakeGenericType(v92, v202);\n\tv445 = System.Type::MakeGenericType(v195, v202);\n\tv299 = Facebook.Unity.CodelessIAPAutoLog::GetField(gameObject, \"onPurchaseComplete\");\n\tv300 = v299 == 0;\n\tif (v300) goto L_0093;\n\tgoto L_FFFFFFFF;\n\tv276 = v276_asT == 0;\n\tif (v276) goto L_010F;\nL_0093:\n\tv461 = System.Type::GetMethod(v423, \"AddListener\");\n\tv430 = System.Type::GetMethod(v423, \"RemoveListener\");\n\tv257 = System.Object::GetType(listenerObject);\n\tv470 = System.Type::GetMethod(v257, \"onPurchaseCompleteHandler\", 0x14);\n\t// 175 NewArr v474 @ X0_v42 (System.Object[]), typeof(System.Object[]), 1\n\tv431 = System.Delegate::CreateDelegate(v445, listenerObject, v470);\n\tv476 = v431 == 0;\n\tif (v476) goto L_00C2;\n\t// 190 IsInst v339 @ X0_v58, typeof(System.Object), v431 @ X0_v44 (System.Delegate)\nL_00C2:\n\tv403 = v474.Length == 0;\n\tif (v403) goto L_0107;\n\tv474[0] = v431;\n\tv484 = System.Reflection.MethodBase::Invoke(v430, v299, v474);\n\t// 206 NewArr v487 @ X0_v49 (System.Object[]), typeof(System.Object[]), 1\n\tv432 = System.Delegate::CreateDelegate(v445, listenerObject, v470);\n\tv489 = v432 == 0;\n\tif (v489) goto L_00E1;\n\t// 221 IsInst v340 @ X0_v56, typeof(System.Object), v432 @ X0_v51 (System.Delegate)\nL_00E1:\n\tv404 = v487.Length == 0;\n\tif (v404) goto L_0107;\n\tv487[0] = v432;\n\tv170 = System.Reflection.MethodBase::Invoke(v461, v299, v487);\n\treturn;\nL_0104:\n\treturn;\n\tv398 = new System.NullReferenceException();\nL_0107:\n\tv414 = new System.IndexOutOfRangeException();\n\tgoto L_010C;\n\tv351 = new System.ArrayTypeMismatchException();\nL_010C:\n\tthrow v417;\n\tthrow System.NullReferenceException;\nL_010F:\n\tthrow System.InvalidCastException;\n// 212 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static void addListenerToGameObject(UnityEngine.Object gameObject, object listenerObject)
		{
			Type type = FindTypeInAssemblies("Product", "UnityEngine.Purchasing");
			if ((object)type == null)
			{
				return;
			}
			Type typeFromHandle = typeof(UnityEvent<>);
			Type typeFromHandle2 = typeof(UnityAction<>);
			Type[] array = new Type[1];
			object obj = type as Type;
			if (array.Length != 0)
			{
				array[0] = type;
				Type type2 = typeFromHandle.MakeGenericType(array);
				Type type3 = typeFromHandle2.MakeGenericType(array);
				object field = GetField(gameObject, "onPurchaseComplete");
				if (field != null)
				{
					UnityEventBase unityEventBase = field as UnityEventBase;
					if (unityEventBase == null)
					{
						throw new InvalidCastException();
					}
				}
				MethodInfo method = type2.GetMethod("AddListener");
				MethodInfo method2 = type2.GetMethod("RemoveListener");
				Type type4 = listenerObject.GetType();
				MethodInfo method3 = type4.GetMethod("onPurchaseCompleteHandler", BindingFlags.Instance | BindingFlags.Public);
				object[] array2 = new object[1];
				Delegate obj2 = Delegate.CreateDelegate(type3, listenerObject, method3);
				if (obj2 != null)
				{
					object obj3 = obj2 as object;
				}
				if (array2.Length != 0)
				{
					array2[0] = obj2;
					object obj4 = method2.Invoke(field, array2);
					object[] array3 = new object[1];
					Delegate obj5 = Delegate.CreateDelegate(type3, listenerObject, method3);
					if (obj5 != null)
					{
						object obj6 = obj5 as object;
					}
					if (array3.Length != 0)
					{
						array3[0] = obj5;
						object obj7 = method.Invoke(field, array3);
						return;
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
		}

		[Token(Token = "0x600016F")]
		[Address(RVA = "0xD245E4", Offset = "0xD245E4", Length = "0x158")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv25 = System.AppDomain::get_CurrentDomain();\n\tv28 = System.AppDomain::GetAssemblies(v25);\n\tv167 = v28.Length;\n\tv194 = v28.Length < 1;\n\tif (v194) goto L_FFFFFFFF;\nL_0024:\n\tv247 = v54 < v167;\n\tv96 = ~v247;\n\tif (v96) goto L_00B3;\n\tv120 = System.Reflection.Assembly::GetTypes(v28[v54 @ X23_v7 (System.Int32)]);\n\tv103 = v120.Length;\n\tv314 = v120.Length < 1;\n\tif (v314) goto L_008B;\nL_0048:\n\tv352 = v39 < v103;\n\tv97 = ~v352;\n\tif (v97) goto L_00B3;\n\tv52 = v39 << 3;\n\tv353 = v120 + v52;\n\tv36 = v353 + 0x20;\n\tv121 = *([v36 @ X25_v10]);\n\tv354 = *([v121 @ X0_v17]);\n\t*([v354 @ X8_v13+1A0])(v356, v121, *([v354 @ X8_v13+1A8]), v32, v124, v125, v126, v127, v128, v129, v130, v131, v132, v133, v134, v135, v136);\n\tv180 = System.String::op_Equality(typeName, v356);\n\tv175 = v180 == 0;\n\tif (v175) goto L_007D;\n\tv359 = v39 < v120.Length;\n\tv98 = ~v359;\n\tif (v98) goto L_00B3;\n\tv122 = *([v36 @ X25_v10]);\n\tv369 = *([v122 @ X0_v22]);\n\t*([v369 @ X8_v17+2D0])(v373, v122, *([v369 @ X8_v17+2D8]), 0, v124, v125, v126, v127, v128, v129, v130, v131, v132, v133, v134, v135, v136);\n\tv181 = System.String::op_Equality(nameSpace, v373);\n\tv376 = v181 == 0;\n\tv176 = ~v376;\n\tif (v176) goto L_009C;\nL_007D:\n\tv103 = v120.Length;\n\tv39 = v39 + 1;\n\tv320 = v39 < v120.Length;\n\tif (v320) goto L_0048;\nL_008B:\n\tv167 = v28.Length;\n\tv54 = v54 + 1;\n\tv213 = v54 < v28.Length;\n\tif (v213) goto L_0024;\n\tgoto L_00B1;\nL_009C:\n\tv377 = v39 < v120.Length;\n\tv165 = ~v377;\n\tif (v165) goto L_00B3;\n\treturnVal2 = *([v36 @ X25_v10]);\nL_00B1:\n\treturn returnVal2;\n\tv123 = new System.NullReferenceException();\nL_00B3:\n\tv182 = new System.IndexOutOfRangeException();\n\tthrow v182;\n\treturn returnVal1;\n// 132 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static Type FindTypeInAssemblies(string typeName, string nameSpace)
		{
			//IL_00cd: Expected O, but got I
			//IL_00dc: Expected O, but got I
			//IL_0120: Expected I, but got O
			//IL_01a6: Expected I, but got O
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			int num = assemblies.Length;
			if (assemblies.Length >= 1)
			{
				int num2 = 0;
				IntPtr intPtr2 = default(IntPtr);
				string text = default(string);
				string text2 = default(string);
				do
				{
					if (num2 < num)
					{
						Type[] types = assemblies[num2].GetTypes();
						int num3 = types.Length;
						if (types.Length < 1)
						{
							goto IL_01f2;
						}
						IntPtr intPtr = intPtr2;
						int num4 = 0;
						while (num4 < num3)
						{
							int num5 = num4 << 3;
							object obj = (long)(IntPtr)types + (long)num5;
							object obj2 = (long)(IntPtr)obj + 32L;
							object obj3 = obj2;
							object obj4 = obj3;
							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v354 @ X8_v13+1A0] (should have been resolved before IL gen)");
							bool flag = typeName == text;
							bool flag2 = !flag;
							intPtr2 = (IntPtr)null;
							if (!flag2)
							{
								if (num4 >= types.Length)
								{
									break;
								}
								object obj5 = obj2;
								object obj6 = obj5;
								Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v369 @ X8_v17+2D0] (should have been resolved before IL gen)");
								bool flag3 = nameSpace == text2;
								bool flag4 = !flag3;
								bool flag5 = !flag4;
								intPtr2 = (IntPtr)null;
								if (flag5)
								{
									if (num4 >= types.Length)
									{
										break;
									}
									return (Type)obj2;
								}
							}
							num3 = types.Length;
							num4++;
							bool flag6 = num4 < types.Length;
							intPtr = intPtr2;
							if (flag6)
							{
								continue;
							}
							goto IL_01f2;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
					IL_01f2:
					num = assemblies.Length;
					num2++;
				}
				while (num2 < assemblies.Length);
			}
			return null;
		}

		[Token(Token = "0x6000170")]
		[Address(RVA = "0xD24210", Offset = "0xD24210", Length = "0x98")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv22 = *([1EEDC40]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, nameSpace, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2023B9F]) = v41;\nL_0017:\n\treturnVal1 = Facebook.Unity.CodelessIAPAutoLog::FindTypeInAssemblies(typeName, nameSpace);\n\tv46 = returnVal1 == 0;\n\tif (v46) goto L_0037;\n\tgoto L_002F;\n\tv58 = *([v49 @ X0_v4+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_002F;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v49, v43, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_002F:\n\treturnVal2 = UnityEngine.Object::FindObjectsOfType(returnVal1);\n\treturn returnVal2;\nL_0037:\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static UnityEngine.Object[] FindObjectsOfTypeByName(string typeName, string nameSpace)
		{
			UnityEngine.Object[] array = (UnityEngine.Object[])(object)FindTypeInAssemblies(typeName, nameSpace);
			if (array != null)
			{
				return UnityEngine.Object.FindObjectsOfType((Type)(object)array);
			}
			return array;
		}

		[Token(Token = "0x6000171")]
		[Address(RVA = "0xD2473C", Offset = "0xD2473C", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.Object::GetType(inObj);\n\treturnVal2 = System.Type::GetField(v17, fieldName);\n\tv54 = returnVal2 == 0;\n\tif (v54) goto L_0023;\n\tv46 = *([returnVal2 @ X0_v5 (System.Object)]);\n\tv41 = *([v46 @ X8_v1 (Il2CppClass<System.Object>)+260]);\n\tv49 = *([v46 @ X8_v1 (Il2CppClass<System.Object>)+268]);\n\t// 29 IndirectJump v41 @ X3_v1, returnVal2 @ X0_v5 (System.Object), returnVal2 @ X0_v5 (System.Object), inObj @ X0 (System.Object), v49 @ X2_v2, v41 @ X3_v1, v25 @ X4, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\nL_0023:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static object GetField(object inObj, string fieldName)
		{
			//IL_0048: Expected I, but got O
			//IL_0058: Expected O, but got I
			//IL_0068: Expected O, but got I
			Type type = inObj.GetType();
			object field = type.GetField(fieldName);
			if (field != null)
			{
				IntPtr intPtr = (IntPtr)field;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v1 (Il2CppClass<System.Object>)+260]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v46 @ X8_v1 (Il2CppClass<System.Object>)+268]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v41 @ X3_v1 (should have been resolved before IL gen)");
			}
			return field;
		}

		[Token(Token = "0x6000172")]
		[Address(RVA = "0xD23EDC", Offset = "0xD23EDC", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv17 = System.Object::GetType(inObj);\n\treturnVal2 = System.Type::GetProperty(v17, propertyName);\n\tv56 = returnVal2 == 0;\n\tif (v56) goto L_0024;\n\tv48 = *([returnVal2 @ X0_v5 (System.Object)]);\n\tv43 = *([v48 @ X8_v1 (Il2CppClass<System.Object>)+2C0]);\n\tv41 = *([v48 @ X8_v1 (Il2CppClass<System.Object>)+2C8]);\n\t// 30 IndirectJump v43 @ X4_v1, returnVal2 @ X0_v5 (System.Object), returnVal2 @ X0_v5 (System.Object), inObj @ X0 (System.Object), 0, v41 @ X3_v1, v43 @ X4_v1, v26 @ X5, v27 @ X6, v28 @ X7, v29 @ V0, v30 @ V1, v31 @ V2, v32 @ V3, v33 @ V4, v34 @ V5, v35 @ V6, v36 @ V7\nL_0024:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static object GetProperty(object inObj, string propertyName)
		{
			//IL_0048: Expected I, but got O
			//IL_0058: Expected O, but got I
			//IL_0068: Expected O, but got I
			Type type = inObj.GetType();
			object property = type.GetProperty(propertyName);
			if (property != null)
			{
				IntPtr intPtr = (IntPtr)property;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v1 (Il2CppClass<System.Object>)+2C0]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v48 @ X8_v1 (Il2CppClass<System.Object>)+2C8]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v43 @ X4_v1 (should have been resolved before IL gen)");
			}
			return property;
		}
	}
}
