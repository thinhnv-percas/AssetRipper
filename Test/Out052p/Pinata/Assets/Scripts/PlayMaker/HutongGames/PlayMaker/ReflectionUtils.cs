using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200007A")]
	public static class ReflectionUtils
	{
		[Token(Token = "0x400033B")]
		private static List<string> assemblyNames;

		[Token(Token = "0x400033C")]
		private static Assembly[] loadedAssemblies;

		[Token(Token = "0x400033D")]
		private static readonly Dictionary<string, Type> typeLookup;

		[Token(Token = "0x6000664")]
		[Address(RVA = "0xE521D8", Offset = "0xE521D8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv7 = System.AppDomain::get_CurrentDomain();\n\treturnVal1 = System.AppDomain::GetAssemblies(v7);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 11 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Assembly[] GetLoadedAssemblies()
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			return currentDomain.GetAssemblies();
		}

		[AttributeAttribute(Type = typeof(LocalizableAttribute), RVA = "0x74137C", Offset = "0x74137C")]
		[Token(Token = "0x6000665")]
		[Address(RVA = "0xE521FC", Offset = "0xE521FC", Length = "0x934")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1F10738]);\n\tv35 = *([v34 @ X8_v118]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([20247BA]) = v54;\nL_0021:\n\tv61 = System.String::IsNullOrEmpty(typeName);\n\tv65 = v61 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_00AB;\n\tgoto L_003E;\n\tv165 = *([v69 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+E0]);\n\tv166 = v165 == 0;\n\tv167 = ~v166;\n\t// 50 ConditionalJump @b232, v167 @ TEMP_v151\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v69, v56, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv169 = HutongGames.PlayMaker.ReflectionUtils;\nL_003E:\n\tv241 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(v172.typeLookup, typeName, &v137 @ stack_-68_v8 (System.Type));\n\tv338 = v137 == 0;\n\tv147 = ~v338;\n\tif (v147) goto L_00AB;\n\tv438 = System.String::Concat(typeName, \",Assembly-CSharp\");\n\tgoto L_0058;\n\tv534 = *([v478 @ X8_v17+E0]);\n\tv535 = v534 == 0;\n\tv536 = ~v535;\n\tif (v536) goto L_0058;\n\tv546 = v478;\n\tv539 = \"il2cpp_codegen_runtime_class_init\"(v546, v437, v436, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0058:\n\tv542 = 0x181C000 + 0x7D4;\n\tv544 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(v438, v542, 0);\n\tv585 = System.Type::GetType(v544);\n\tv571 = v585 == 0;\n\tv572 = ~v571;\n\tif (v572) goto L_FFFFFFFF;\n\tv585 = System.Type::GetType(v438);\n\tv604 = v585 == 0;\n\tv592 = ~v604;\n\tif (v592) goto L_FFFFFFFF;\n\tv639 = System.String::Concat(typeName, \",PlayMaker\");\n\tgoto L_0077;\n\tv654 = *([v597 @ X8_v33+E0]);\n\tv655 = v654 == 0;\n\tv656 = ~v655;\n\tif (v656) goto L_0077;\n\tv664 = v597;\n\tv658 = \"il2cpp_codegen_runtime_class_init\"(v664, v638, v584, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0077:\n\tv578 = 0x181C000 + 0x7D4;\n\tv662 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(v639, v578, 0);\n\tv585 = System.Type::GetType(v662);\n\tv591 = v585 == 0;\n\tif (v591) goto L_00AD;\nL_0082:\n\tgoto L_0091;\n\tv640 = *([v631 @ X0_v31 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+E0]);\n\tv641 = v640 == 0;\n\tv642 = ~v641;\n\t// 134 Jump @b233\n\tv650 = \"il2cpp_codegen_runtime_class_init\"(v631, v308, v316, v304, v40, v41, v42, v43, v251, v45, v46, v47, v48, v49, v50, v51);\n\tv644 = HutongGames.PlayMaker.ReflectionUtils;\nL_0091:\n\tv653 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::Remove(v331.typeLookup, typeName);\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Type>::set_Item(v329.typeLookup, typeName, v137);\nL_00AB:\n\treturn returnVal1;\nL_00AD:\n\tv621 = System.Type::GetType(v639);\n\tv690 = v621 == 0;\n\tv625 = ~v690;\n\tif (v625) goto L_0082;\n\tv695 = System.String::Concat(typeName, \",Assembly-CSharp-firstpass\");\n\tgoto L_00C5;\n\tv699 = *([v598 @ X8_v36+E0]);\n\tv700 = v699 == 0;\n\tv701 = ~v700;\n\tif (v701) goto L_00C5;\n\tv708 = v598;\n\tv703 = \"il2cpp_codegen_runtime_class_init\"(v708, v694, v315, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00C5:\n\tv579 = 0x181C000 + 0x7D4;\n\tv707 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(v695, v579, 0);\n\tv585 = System.Type::GetType(v707);\n\tv709 = v585 == 0;\n\tv593 = ~v709;\n\tif (v593) goto L_FFFFFFFF;\n\tv585 = System.Type::GetType(v695);\n\tv711 = v585 == 0;\n\tv594 = ~v711;\n\tif (v594) goto L_FFFFFFFF;\n\tgoto L_00DC;\n\tv716 = *([v712 @ X0_v59+E0]);\n\tv717 = v716 == 0;\n\tv718 = ~v717;\n\tif (v718) goto L_00DC;\n\tv720 = \"il2cpp_codegen_runtime_class_init\"(v712, v579, v315, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00DC:\n\tv580 = 0x181C000 + 0x7D4;\n\tv724 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(typeName, v580, 0);\n\tv585 = System.Type::GetType(v724);\n\tv725 = v585 == 0;\n\tv595 = ~v725;\n\tif (v595) goto L_FFFFFFFF;\n\tv622 = System.Type::GetType(typeName);\n\tv727 = v622 == 0;\n\tv626 = ~v727;\n\tif (v626) goto L_0082;\n\tgoto L_00F6;\n\tv732 = *([v728 @ X0_v66 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+E0]);\n\tv733 = v732 == 0;\n\tv734 = ~v733;\n\tif (v734) goto L_00F6;\n\tv743 = \"il2cpp_codegen_runtime_class_init\"(v728, v580, v315, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv736 = HutongGames.PlayMaker.ReflectionUtils;\nL_00F6:\n\tv741 = v739.assemblyNames == 0;\n\tv742 = ~v741;\n\tif (v742) goto L_0165;\n\tv747 = new System.Collections.Generic.List`1<System.String>();\n\tSystem.Collections.Generic.List`1<System.String>::.ctor(v747);\n\tgoto L_010F;\n\tv793 = *([v783 @ X0_v148 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+E0]);\n\tv794 = v793 == 0;\n\tv795 = ~v794;\n\tif (v795) goto L_010F;\n\tv806 = \"il2cpp_codegen_runtime_class_init\"(v783, v307, v315, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv797 = HutongGames.PlayMaker.ReflectionUtils;\nL_010F:\n\tv330.assemblyNames = v747;\n\tv320 = System.AppDomain::get_CurrentDomain();\n\tv414 = System.AppDomain::GetAssemblies(v320);\n\tv395.loadedAssemblies = v414;\n\tv392 = v424.loadedAssemblies;\n\tv853 = v392.Length < 1;\n\tif (v853) goto L_0165;\nL_013D:\n\tgoto L_014C;\n\tv928 = *([v897 @ X0_v156 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+E0]);\n\tv929 = v928 == 0;\n\tv930 = ~v929;\n\t// 321 ConditionalJump @b237, v930 @ TEMP_v137\n\tv941 = \"il2cpp_codegen_runtime_class_init\"(v897, v406, v411, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv931 = HutongGames.PlayMaker.ReflectionUtils;\nL_014C:\n\tv415 = System.Reflection.Assembly::get_FullName(v392[v359 @ X25_v17 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.String>::Add(v942.assemblyNames, v415);\n\tv359 = v359 + 1;\n\tv861 = v359 < v392.Length;\n\tif (v861) goto L_013D;\nL_0165:\n\tgoto L_0174;\n\tv776 = *([v764 @ X0_v68 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+E0]);\n\tv777 = v776 == 0;\n\tv778 = ~v777;\n\t// 361 Jump @b239\n\tv787 = \"il2cpp_codegen_runtime_class_init\"(v764, v309, v317, v131, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv780 = HutongGames.PlayMaker.ReflectionUtils;\nL_0174:\n\tv792 = System.Collections.Generic.List`1<System.String>::GetEnumerator(v332.assemblyNames);\n\tv630 = 0x181C000 + 0x7D4;\nL_0181:\n\tv825 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::MoveNext(&v350 @ stack_-98_v9 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tv827 = v825 == 0;\n\tif (v827) goto L_01A7;\n\tv831 = System.String::Concat(typeName, \",\", v804);\n\tgoto L_0197;\n\tv874 = *([v854 @ X0_v136+E0]);\n\tv875 = v874 == 0;\n\tv876 = ~v875;\n\tif (v876) goto L_0197;\n\tv878 = \"il2cpp_codegen_runtime_class_init\"(v854, v829, v816, v810, v40, v41, v42, v43, v348, v45, v46, v47, v48, v49, v50, v51);\nL_0197:\n\tv881 = System.Collections.Generic.Dictionary`2<System.String, System.Type>::TryGetValue(v831, v630, v804);\n\tv835 = System.Type::GetType(v881);\n\tv901 = v835 == 0;\n\tv837 = ~v901;\n\tif (v837) goto L_FFFFFFFF;\n\tv818 = System.Type::GetType(v831);\n\tv820 = v818 == 0;\n\tif (v820) goto L_0181;\n\tgoto L_01A7;\nL_01A7:\n\tv623 = System.Collections.Generic.List`1<System.String>+Enumerator<System.String>::Dispose(&v350 @ stack_-98_v9 (System.Collections.Generic.List`1<System.String>+Enumerator<System.String>));\n\tgoto L_01C4;\n\tgoto L_01AB;\n\tgoto L_01AB;\nL_01AB:\n\tX20 = X0;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~Z;\n\tif (TEMPCOND) goto L_0367;\n\tX0 = X20;\n\tX0 = 0x6D2BC0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX20 = *([X0]);\n\tX0 = 0x6D2490(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA6D58]);\n\tX0 = &stack[20];\n\tX1 = *([X8]);\n\tX0 = 0xEF9AAC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_FFFFFFFF;\nL_01C4:\n\tv882 = v137 == 0;\n\tv627 = ~v882;\n\tif (v627) goto L_0082;\n\tgoto L_FFFFFFFF;\nL_01D2:\n\tv949 = *([v417 @ X0_v80 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+12F]) & 2;\n\tv950 = v949 == 0;\n\tif (v950) goto L_01E0;\n\tv954 = *([v417 @ X0_v80 (Il2CppClass<HutongGames.PlayMaker.ReflectionUt\n// ... truncated")]
		public unsafe static Type GetGlobalType(string typeName)
		{
			//IL_0076: Expected O, but got I4
			//IL_0091: Expected O, but got I4
			//IL_011d: Expected O, but got I4
			//IL_0138: Expected O, but got I4
			//IL_0209: Expected O, but got I4
			//IL_0224: Expected O, but got I4
			//IL_029e: Expected O, but got I4
			//IL_02b9: Expected O, but got I4
			//IL_0413: Expected O, but got I4
			//IL_0429: Expected O, but got Ref
			//IL_045e: Expected O, but got I4
			//IL_0c44: Expected I, but got O
			//IL_04f6: Expected I, but got O
			//IL_04b9: Expected I, but got O
			//IL_04dc: Expected I, but got O
			//IL_0a8f: Expected O, but got I
			//IL_0639: Expected I, but got O
			//IL_0649: Expected O, but got I
			//IL_0ab3: Expected O, but got I
			//IL_0b67: Expected O, but got I4
			//IL_0b6b: Expected O, but got I4
			//IL_0afa: Expected I, but got O
			//IL_06cf: Expected O, but got I
			//IL_06de: Expected O, but got I
			bool flag = string.IsNullOrEmpty(typeName);
			bool flag2 = !flag;
			bool flag3 = !flag2;
			Type result = null;
			Type value;
			object obj2;
			if (!flag3)
			{
				bool flag4 = typeLookup.TryGetValue(typeName, out value);
				bool flag5 = (object)value == null;
				bool flag6 = !flag5;
				result = value;
				if (!flag6)
				{
					string text = typeName + ",Assembly-CSharp";
					string key = (string)(25280512 + 2004);
					bool flag7 = ((Dictionary<string, Type>)(object)text).TryGetValue(key, out *(Type*)null);
					Type type = Type.GetType((string)flag7);
					if ((object)type == null)
					{
						type = Type.GetType(text);
						if ((object)type == null)
						{
							string text2 = typeName + ",PlayMaker";
							string key2 = (string)(25280512 + 2004);
							bool flag8 = ((Dictionary<string, Type>)(object)text2).TryGetValue(key2, out *(Type*)null);
							type = Type.GetType((string)flag8);
							if ((object)type == null)
							{
								Type type2 = Type.GetType(text2);
								bool flag9 = (object)type2 == null;
								bool flag10 = !flag9;
								value = type2;
								if (flag10)
								{
									goto IL_016b;
								}
								string text3 = typeName + ",Assembly-CSharp-firstpass";
								string key3 = (string)(25280512 + 2004);
								bool flag11 = ((Dictionary<string, Type>)(object)text3).TryGetValue(key3, out *(Type*)null);
								type = Type.GetType((string)flag11);
								if ((object)type == null)
								{
									type = Type.GetType(text3);
									if ((object)type == null)
									{
										string key4 = (string)(25280512 + 2004);
										bool flag12 = ((Dictionary<string, Type>)(object)typeName).TryGetValue(key4, out *(Type*)null);
										type = Type.GetType((string)flag12);
										if ((object)type == null)
										{
											Type type3 = Type.GetType(typeName);
											bool flag13 = (object)type3 == null;
											bool flag14 = !flag13;
											value = type3;
											if (!flag14)
											{
												bool flag15 = assemblyNames == null;
												bool flag16 = !flag15;
												ref Type reference = ref *(Type*)null;
												if (!flag16)
												{
													List<string> list = new List<string>();
													assemblyNames = list;
													AppDomain currentDomain = AppDomain.CurrentDomain;
													Assembly[] assemblies = currentDomain.GetAssemblies();
													loadedAssemblies = assemblies;
													Assembly[] array = loadedAssemblies;
													bool flag17 = array.Length < 1;
													reference = ref *(Type*)null;
													if (!flag17)
													{
														int num = 0;
														bool flag18;
														do
														{
															string fullName = array[num].FullName;
															assemblyNames.Add(fullName);
															num++;
															flag18 = num < array.Length;
															reference = ref *(Type*)null;
														}
														while (flag18);
													}
												}
												List<string>.Enumerator enumerator = assemblyNames.GetEnumerator();
												string key5 = (string)(25280512 + 2004);
												IntPtr intPtr = (IntPtr)0;
												value = type3;
												string text4 = (string)System.Runtime.CompilerServices.Unsafe.AsPointer(ref reference);
												List<string>.Enumerator enumerator2 = default(List<string>.Enumerator);
												string text6 = default(string);
												while (enumerator2.MoveNext())
												{
													string text5 = typeName + "," + text6;
													string typeName2 = (string)((Dictionary<string, Type>)(object)text5).TryGetValue(key5, out *(Type*)text6);
													Type type4 = Type.GetType(typeName2);
													if ((object)type4 == null)
													{
														Type type5 = Type.GetType(text5);
														bool flag19 = (object)type5 == null;
														intPtr = (IntPtr)null;
														value = type5;
														text4 = text6;
														if (!flag19)
														{
															intPtr = (IntPtr)null;
															value = type5;
															text4 = text6;
															break;
														}
														continue;
													}
													intPtr = (IntPtr)null;
													value = type4;
													text4 = text6;
													break;
												}
												enumerator2.Dispose();
												if ((object)value == null)
												{
													int num2 = 0;
													IntPtr intPtr2 = (IntPtr)0;
													string text8 = default(string);
													string text9 = default(string);
													string text12 = default(string);
													string text13 = default(string);
													while (true)
													{
														IntPtr intPtr3 = (IntPtr)typeof(ReflectionUtils);
														Assembly[] array2 = loadedAssemblies;
														if (num2 >= array2.Length)
														{
															break;
														}
														Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X0_v80 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+12F]");
														NullReferenceException ex;
														string text7;
														if (0u != 0)
														{
															Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v417 @ X0_v80 (Il2CppClass<HutongGames.PlayMaker.ReflectionUtils>)+E0]");
															if ((IntPtr)0 == (IntPtr)0)
															{
																array2 = loadedAssemblies;
																if (loadedAssemblies == null)
																{
																	ex = new NullReferenceException();
																	text7 = (string)(long)intPtr2;
																	goto IL_0b27;
																}
															}
														}
														Type[] types;
														int num4;
														string text10;
														string text11;
														if (num2 < array2.Length)
														{
															Assembly assembly = array2[num2];
															if ((object)array2[num2] != null)
															{
																IntPtr intPtr4 = (IntPtr)assembly;
																Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v980 @ X8_v64 (Il2CppClass<System.Reflection.Assembly>)+228]");
																text7 = (string)0;
																types = array2[num2].GetTypes();
																if (types != null)
																{
																	int num3 = types.Length;
																	if (types.Length < 1)
																	{
																		goto IL_0ae4;
																	}
																	num4 = 0;
																	while (true)
																	{
																		if (num4 < num3)
																		{
																			int num5 = num4 << 3;
																			object obj = (long)(IntPtr)types + (long)num5;
																			obj2 = (long)(IntPtr)obj + 32L;
																			object obj3 = obj2;
																			if (obj2 != null)
																			{
																				object obj4 = obj3;
																				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1106 @ X8_v68+1A0] (should have been resolved before IL gen)");
																				bool flag20 = text8 == typeName;
																				bool flag21 = !flag20;
																				text7 = typeName;
																				text4 = null;
																				if (flag21)
																				{
																					goto IL_0957;
																				}
																				if (num4 < types.Length)
																				{
																					object obj5 = obj2;
																					if (obj2 == null)
																					{
																						break;
																					}
																					object obj6 = obj5;
																					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1136 @ X8_v72+2D0] (should have been resolved before IL gen)");
																					bool flag22 = text9 == "UnityEngine";
																					bool flag23 = !flag22;
																					bool flag24 = !flag23;
																					text10 = "UnityEngine";
																					text11 = null;
																					if (!flag24)
																					{
																						if (num4 >= types.Length)
																						{
																							IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
																							throw ex2;
																						}
																						object obj7 = obj2;
																						if (obj2 == null)
																						{
																							goto IL_0a1c;
																						}
																						object obj8 = obj7;
																						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1154 @ X8_v83+2D0] (should have been resolved before IL gen)");
																						bool flag25 = text12 == "HutongGames.PlayMaker";
																						bool flag26 = !flag25;
																						bool flag27 = !flag26;
																						text10 = "HutongGames.PlayMaker";
																						text11 = null;
																						if (!flag27)
																						{
																							if (num4 >= types.Length)
																							{
																								IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
																								throw ex3;
																							}
																							object obj9 = obj2;
																							if (obj2 == null)
																							{
																								goto IL_0a54;
																							}
																							object obj10 = obj9;
																							Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1130 @ X8_v85+2D0] (should have been resolved before IL gen)");
																							bool flag28 = text13 == "HutongGames.PlayMaker.Actions";
																							bool flag29 = !flag28;
																							bool flag30 = !flag29;
																							text7 = "HutongGames.PlayMaker.Actions";
																							text4 = null;
																							text10 = "HutongGames.PlayMaker.Actions";
																							text11 = null;
																							if (!flag30)
																							{
																								goto IL_0957;
																							}
																						}
																					}
																					goto IL_0992;
																				}
																				IndexOutOfRangeException ex4 = new IndexOutOfRangeException();
																				throw ex4;
																			}
																			throw new NullReferenceException();
																		}
																		IndexOutOfRangeException ex5 = new IndexOutOfRangeException();
																		throw ex5;
																		IL_0957:
																		num3 = types.Length;
																		num4++;
																		if (num4 >= types.Length)
																		{
																			goto IL_0ae4;
																		}
																	}
																	ex = new NullReferenceException();
																	text7 = typeName;
																	text4 = null;
																}
																else
																{
																	ex = new NullReferenceException();
																}
															}
															else
															{
																ex = new NullReferenceException();
																text7 = (string)(long)intPtr2;
															}
															goto IL_0b27;
														}
														IndexOutOfRangeException ex6 = new IndexOutOfRangeException();
														throw ex6;
														IL_0a54:
														ex = new NullReferenceException();
														text7 = "HutongGames.PlayMaker";
														text4 = null;
														goto IL_0b27;
														IL_0a1c:
														ex = new NullReferenceException();
														text7 = "UnityEngine";
														text4 = null;
														goto IL_0b27;
														IL_0b27:
														bool flag31 = ((Dictionary<string, Type>)(object)ex).TryGetValue(text7, out *(Type*)text4);
														bool flag32 = ((Dictionary<string, Type>)(object)ex).TryGetValue(text7, out *(Type*)text4);
														return (Type)((Dictionary<string, Type>)flag32).TryGetValue(text7, out *(Type*)text4);
														IL_0ae4:
														num2++;
														intPtr2 = (IntPtr)text7;
														continue;
														IL_0992:
														if (num4 >= types.Length)
														{
															IndexOutOfRangeException ex7 = new IndexOutOfRangeException();
															throw ex7;
														}
														if (typeLookup == null)
														{
															ex = new NullReferenceException();
															text7 = text10;
															text4 = text11;
															goto IL_0b27;
														}
														goto IL_09c0;
													}
												}
											}
											goto IL_016b;
										}
									}
								}
							}
						}
					}
					value = type;
					goto IL_016b;
				}
			}
			goto IL_0baf;
			IL_0199:
			result = value;
			goto IL_0baf;
			IL_0baf:
			return result;
			IL_09c0:
			typeLookup.set_Item(typeName, (Type)obj2);
			value = (Type)obj2;
			goto IL_0199;
			IL_016b:
			bool flag33 = typeLookup.Remove(typeName);
			typeLookup.set_Item(typeName, value);
			goto IL_0199;
		}

		[Token(Token = "0x6000666")]
		[Address(RVA = "0xE52B30", Offset = "0xE52B30", Length = "0x13C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1EEB648]);\n\tv25 = *([v24 @ X8_v19]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, path, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20247BB]) = v43;\nL_001A:\n\t// 26 NewArr v48 @ X0_v3 (System.Char[]), typeof(System.Char[]), 1\n\tv52 = v48.Length == 0;\n\tif (v52) goto L_0077;\n\tv48[0] = 0x2E;\n\tv97 = System.String::Split(path, v48);\n\tv148 = v97.Length;\n\tv214 = v97.Length < 1;\n\tif (v214) goto L_0076;\nL_003A:\n\tv253 = v115 < v148;\n\tv133 = ~v253;\n\tif (v133) goto L_0077;\n\tv257 = System.Type::GetProperty(v145, v97[v115 @ X22_v7 (System.Int32)]);\n\tv258 = v257 == 0;\n\tif (v258) goto L_0056;\n\tv259 = *([v257 @ X0_v18 (System.Reflection.PropertyInfo)]);\n\tv232 = *([v259 @ X8_v16 (Il2CppClass<System.Reflection.PropertyInfo>)+260]);\n\tv231 = *([v259 @ X8_v16 (Il2CppClass<System.Reflection.PropertyInfo>)+268]);\n\tgoto L_005C;\nL_0056:\n\tv234 = System.Type::GetField(v145, v97[v115 @ X22_v7 (System.Int32)]);\n\tv236 = v234 == 0;\n\tif (v236) goto L_FFFFFFFF;\n\tv267 = *([v234 @ X0_v22 (System.Reflection.FieldInfo)]);\n\tv232 = *([v267 @ X8_v15 (Il2CppClass<System.Reflection.FieldInfo>)+250]);\n\tv231 = *([v267 @ X8_v15 (Il2CppClass<System.Reflection.FieldInfo>)+258]);\nL_005C:\n\tv232(v235, v257, v231, v229, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv148 = v97.Length;\n\tv115 = v115 + 1;\n\tv219 = v115 < v97.Length;\n\tif (v219) goto L_003A;\n\tgoto L_0076;\nL_0076:\n\treturn v238;\nL_0077:\n\tv151 = new System.IndexOutOfRangeException();\n\tthrow v151;\n\tv96 = new System.NullReferenceException();\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 85 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Type GetPropertyType(Type type, string path)
		{
			//IL_00d8: Expected I, but got O
			//IL_00e8: Expected O, but got I
			//IL_00f8: Expected O, but got I
			//IL_0101: Expected O, but got I4
			//IL_0145: Expected I, but got O
			//IL_0155: Expected O, but got I
			//IL_0165: Expected O, but got I
			//IL_016e: Expected O, but got I4
			char[] array = new char[1];
			Type result;
			Type type3 = default(Type);
			if (array.Length != 0)
			{
				array[0] = '.';
				string[] array2 = path.Split(array);
				int num = array2.Length;
				bool flag = array2.Length < 1;
				result = type;
				if (flag)
				{
					goto IL_01b3;
				}
				int num2 = 0;
				Type type2 = type;
				while (num2 < num)
				{
					PropertyInfo property = type2.GetProperty(array2[num2]);
					if ((object)property != null)
					{
						IntPtr intPtr = (IntPtr)property;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v16 (Il2CppClass<System.Reflection.PropertyInfo>)+260]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v259 @ X8_v16 (Il2CppClass<System.Reflection.PropertyInfo>)+268]");
						object obj2 = 0;
						object obj3 = 0;
					}
					else
					{
						FieldInfo field = type2.GetField(array2[num2]);
						if ((object)field == null)
						{
							goto IL_0188;
						}
						IntPtr intPtr2 = (IntPtr)field;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X8_v15 (Il2CppClass<System.Reflection.FieldInfo>)+250]");
						object obj = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v267 @ X8_v15 (Il2CppClass<System.Reflection.FieldInfo>)+258]");
						object obj2 = 0;
						object obj3 = 0;
						property = (PropertyInfo)(object)field;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v232 @ X9_v8 (should have been resolved before IL gen)");
					num = array2.Length;
					num2++;
					bool flag2 = num2 < array2.Length;
					type2 = type3;
					if (flag2)
					{
						continue;
					}
					goto IL_017b;
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			throw ex;
			IL_01b3:
			return result;
			IL_017b:
			result = type3;
			goto IL_01b3;
			IL_0188:
			result = null;
			goto IL_01b3;
		}

		[Token(Token = "0x6000667")]
		[Address(RVA = "0xE52C6C", Offset = "0xE52C6C", Length = "0x1D4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv28 = *([1EAF2C0]);\n\tv29 = *([v28 @ X8_v30]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, path, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv47 = 0 | 1;\n\t*([20247BC]) = v47;\nL_0018:\n\tv48 = type == 0;\n\tif (v48) goto L_FFFFFFFF;\n\t// 30 NewArr v53 @ X0_v6 (System.Char[]), typeof(System.Char[]), 1\n\tv176 = v53.Length == 0;\n\tif (v176) goto L_00B6;\n\tv53[0] = 0x2E;\n\tv212 = System.String::Split(path, v53);\n\t// 52 NewArr v154 @ X0_v19 (System.Reflection.MemberInfo[]), typeof(System.Reflection.MemberInfo[]), v212.Length\n\tv323 = v212.Length;\n\tv118 = v212.Length < 1;\n\tif (v118) goto L_00B3;\nL_0044:\n\tv360 = v93 < v323;\n\tv88 = ~v360;\n\tif (v88) goto L_00B6;\n\tv388 = System.Type::GetProperty(v318, v212[v93 @ X9_v10 (System.Int32)]);\n\tv362 = v388 == 0;\n\tif (v362) goto L_0079;\n\t// 96 IsInst v309 @ X0_v33, typeof(System.Reflection.MemberInfo), v388 @ X0_v23 (System.Reflection.PropertyInfo)\n\tv366 = v93 < v154.Length;\n\tv293 = ~v366;\n\tif (v293) goto L_00B6;\n\tv154[v93 @ X9_v10 (System.Int32)] = v388;\n\tv372 = *([v388 @ X0_v23 (System.Reflection.PropertyInfo)]);\n\tv385 = *([v372 @ X8_v27 (Il2CppClass<System.Reflection.PropertyInfo>)+260]);\n\tv152 = *([v372 @ X8_v27 (Il2CppClass<System.Reflection.PropertyInfo>)+268]);\n\tgoto L_0097;\nL_0079:\n\tv98 = System.Type::GetField(v318, v212[v93 @ X9_v10 (System.Int32)]);\n\tv100 = v98 == 0;\n\tif (v100) goto L_FFFFFFFF;\n\t// 130 IsInst v310 @ X0_v30, typeof(System.Reflection.MemberInfo), v98 @ X0_v28 (System.Reflection.FieldInfo)\n\tv395 = v93 < v154.Length;\n\tv294 = ~v395;\n\tif (v294) goto L_00B6;\n\tv154[v93 @ X9_v10 (System.Int32)] = v98;\n\tv392 = *([v98 @ X0_v28 (System.Reflection.FieldInfo)]);\n\tv385 = *([v392 @ X8_v23 (Il2CppClass<System.Reflection.FieldInfo>)+250]);\n\tv152 = *([v392 @ X8_v23 (Il2CppClass<System.Reflection.FieldInfo>)+258]);\nL_0097:\n\tv385(v155, v388, v152, v146, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44);\n\tv323 = v212.Length;\n\tv93 = v93 + 1;\n\tv119 = v93 < v212.Length;\n\tif (v119) goto L_0044;\n\tgoto L_00B3;\nL_00B3:\n\treturn v165;\n\tv307 = new System.NullReferenceException();\nL_00B6:\n\tv328 = new System.IndexOutOfRangeException();\n\tgoto L_00BB;\n\tv342 = new System.ArrayTypeMismatchException();\nL_00BB:\n\tthrow v341;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 133 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static MemberInfo[] GetMemberInfo(Type type, string path)
		{
			//IL_0146: Expected I, but got O
			//IL_0156: Expected O, but got I
			//IL_0166: Expected O, but got I
			//IL_016f: Expected O, but got I4
			//IL_01ff: Expected I, but got O
			//IL_020f: Expected O, but got I
			//IL_021f: Expected O, but got I
			//IL_0228: Expected O, but got I4
			MemberInfo[] array3;
			MemberInfo[] result;
			if ((object)type != null)
			{
				char[] array = new char[1];
				if (array.Length != 0)
				{
					array[0] = '.';
					string[] array2 = path.Split(array);
					array3 = new MemberInfo[array2.Length];
					int num = array2.Length;
					bool flag = array2.Length < 1;
					result = array3;
					if (flag)
					{
						goto IL_027c;
					}
					int num2 = 0;
					Type type2 = type;
					Type type3 = default(Type);
					while (num2 < num)
					{
						PropertyInfo property = type2.GetProperty(array2[num2]);
						if ((object)property != null)
						{
							object obj = property as MemberInfo;
							if (num2 >= array3.Length)
							{
								break;
							}
							array3[num2] = property;
							IntPtr intPtr = (IntPtr)property;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ X8_v27 (Il2CppClass<System.Reflection.PropertyInfo>)+260]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v372 @ X8_v27 (Il2CppClass<System.Reflection.PropertyInfo>)+268]");
							object obj3 = 0;
							object obj4 = 0;
						}
						else
						{
							FieldInfo field = type2.GetField(array2[num2]);
							if ((object)field == null)
							{
								goto IL_0242;
							}
							object obj5 = field as MemberInfo;
							if (num2 >= array3.Length)
							{
								break;
							}
							array3[num2] = field;
							IntPtr intPtr2 = (IntPtr)field;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ X8_v23 (Il2CppClass<System.Reflection.FieldInfo>)+250]");
							object obj2 = 0;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v392 @ X8_v23 (Il2CppClass<System.Reflection.FieldInfo>)+258]");
							object obj3 = 0;
							object obj4 = 0;
							property = (PropertyInfo)(object)field;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: v385 @ X9_v11 (should have been resolved before IL gen)");
						num = array2.Length;
						num2++;
						bool flag2 = num2 < array2.Length;
						type2 = type3;
						if (flag2)
						{
							continue;
						}
						goto IL_0235;
					}
				}
				IndexOutOfRangeException ex = new IndexOutOfRangeException();
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				throw ex2;
			}
			goto IL_0242;
			IL_027c:
			return result;
			IL_0235:
			result = array3;
			goto IL_027c;
			IL_0242:
			result = null;
			goto IL_027c;
		}

		[Token(Token = "0x6000668")]
		[Address(RVA = "0xE52E40", Offset = "0xE52E40", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EE8968]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247BD]) = v38;\nL_0019:\n\tv44 = System.Reflection.MemberInfo::get_MemberType(member);\n\tv49 = v44 == 4;\n\tif (v49) goto L_FFFFFFFF;\n\tv65 = v44 != 0x10;\n\tif (v65) goto L_FFFFFFFF;\n\tv118 = member->klass;\n\tgoto L_FFFFFFFF;\n\tv77 = v77_asT == 0;\n\tif (v77) goto L_0064;\n\tv144 = member->klass->vtable[17];\n\tv157 = member->klass->vtable[17];\n\t// 87 IndirectJump v144 @ X2_v1, member @ X0 (System.Reflection.MemberInfo), member @ X0 (System.Reflection.MemberInfo), v157 @ X1_v4, v144 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tgoto L_0060;\nL_0060:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0064:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CanReadMemberValue(MemberInfo member)
		{
			//IL_0057: Expected I, but got O
			//IL_00da: Expected I4, but got O
			//IL_0096: Expected O, but got I
			//IL_00a6: Expected O, but got I
			MemberTypes memberType = member.MemberType;
			if (memberType != MemberTypes.Field)
			{
				if (memberType != MemberTypes.Property)
				{
					return false;
				}
				IntPtr intPtr = (IntPtr)member;
				PropertyInfo propertyInfo = member as PropertyInfo;
				if ((object)propertyInfo == null)
				{
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v5 (Il2CppClass<System.Reflection.MemberInfo>)+240]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v5 (Il2CppClass<System.Reflection.MemberInfo>)+248]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v144 @ X2_v1 (should have been resolved before IL gen)");
			}
			return true;
		}

		[Token(Token = "0x6000669")]
		[Address(RVA = "0xE52F0C", Offset = "0xE52F0C", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EC8448]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247BE]) = v38;\nL_0019:\n\tv44 = System.Reflection.MemberInfo::get_MemberType(member);\n\tv49 = v44 == 4;\n\tif (v49) goto L_FFFFFFFF;\n\tv65 = v44 != 0x10;\n\tif (v65) goto L_FFFFFFFF;\n\tv118 = member->klass;\n\tgoto L_FFFFFFFF;\n\tv77 = v77_asT == 0;\n\tif (v77) goto L_0064;\n\tv144 = member->klass->vtable[18];\n\tv157 = member->klass->vtable[18];\n\t// 87 IndirectJump v144 @ X2_v1, member @ X0 (System.Reflection.MemberInfo), member @ X0 (System.Reflection.MemberInfo), v157 @ X1_v4, v144 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tgoto L_0060;\nL_0060:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0064:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CanSetMemberValue(MemberInfo member)
		{
			//IL_0057: Expected I, but got O
			//IL_00da: Expected I4, but got O
			//IL_0096: Expected O, but got I
			//IL_00a6: Expected O, but got I
			MemberTypes memberType = member.MemberType;
			if (memberType != MemberTypes.Field)
			{
				if (memberType != MemberTypes.Property)
				{
					return false;
				}
				IntPtr intPtr = (IntPtr)member;
				PropertyInfo propertyInfo = member as PropertyInfo;
				if ((object)propertyInfo == null)
				{
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v5 (Il2CppClass<System.Reflection.MemberInfo>)+250]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v5 (Il2CppClass<System.Reflection.MemberInfo>)+258]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v144 @ X2_v1 (should have been resolved before IL gen)");
			}
			return true;
		}

		[Token(Token = "0x600066A")]
		[Address(RVA = "0xE52FD8", Offset = "0xE52FD8", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EED680]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247BF]) = v38;\nL_0019:\n\tv44 = System.Reflection.MemberInfo::get_MemberType(member);\n\tv49 = v44 == 4;\n\tif (v49) goto L_FFFFFFFF;\n\tv65 = v44 != 0x10;\n\tif (v65) goto L_FFFFFFFF;\n\tv118 = member->klass;\n\tgoto L_FFFFFFFF;\n\tv77 = v77_asT == 0;\n\tif (v77) goto L_0064;\n\tv144 = member->klass->vtable[17];\n\tv157 = member->klass->vtable[17];\n\t// 87 IndirectJump v144 @ X2_v1, member @ X0 (System.Reflection.MemberInfo), member @ X0 (System.Reflection.MemberInfo), v157 @ X1_v4, v144 @ X2_v1, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tgoto L_0060;\nL_0060:\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_0064:\n\treturnVal2 = new System.InvalidCastException();\n\treturn returnVal2;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool CanGetMemberValue(MemberInfo member)
		{
			//IL_0057: Expected I, but got O
			//IL_00da: Expected I4, but got O
			//IL_0096: Expected O, but got I
			//IL_00a6: Expected O, but got I
			MemberTypes memberType = member.MemberType;
			if (memberType != MemberTypes.Field)
			{
				if (memberType != MemberTypes.Property)
				{
					return false;
				}
				IntPtr intPtr = (IntPtr)member;
				PropertyInfo propertyInfo = member as PropertyInfo;
				if ((object)propertyInfo == null)
				{
					InvalidCastException ex = new InvalidCastException();
					return (byte)(int)ex != 0;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v5 (Il2CppClass<System.Reflection.MemberInfo>)+240]");
				object obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v118 @ X8_v5 (Il2CppClass<System.Reflection.MemberInfo>)+248]");
				object obj2 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v144 @ X2_v1 (should have been resolved before IL gen)");
			}
			return true;
		}

		[Token(Token = "0x600066B")]
		[Address(RVA = "0xE530A4", Offset = "0xE530A4", Length = "0x18C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EF8080]);\n\tv19 = *([v18 @ X8_v20]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20247C0]) = v38;\nL_0019:\n\tv44 = System.Reflection.MemberInfo::get_MemberType(member);\n\tv49 = v44 == 2;\n\tif (v49) goto L_005D;\n\tv105 = v44 == 0x10;\n\tif (v105) goto L_007F;\n\tv130 = v44 != 4;\n\tif (v130) goto L_00BB;\n\tv235 = member->klass;\n\tv230 = System.Reflection.FieldInfo;\n\tv233 = member->klass->typeHierarchyDepth;\n\tv193 = *([v230 @ X1_v11 (Il2CppClass<System.Reflection.FieldInfo>)+128]);\n\tgoto L_FFFFFFFF;\n\tv195 = v195_asT == 0;\n\tif (v195) goto L_00B5;\n\tgoto L_009E;\nL_005D:\n\tv235 = member->klass;\n\tv113 = System.Reflection.EventInfo;\n\tv233 = member->klass->typeHierarchyDepth;\n\tv193 = *([v113 @ X1_v9 (Il2CppClass<System.Reflection.EventInfo>)+128]);\n\tgoto L_FFFFFFFF;\n\tv185 = v185_asT == 0;\n\tif (v185) goto L_00B5;\n\tgoto L_009E;\nL_007F:\n\tv235 = member->klass;\n\tv159 = System.Reflection.PropertyInfo;\n\tv233 = member->klass->typeHierarchyDepth;\n\tv193 = *([v159 @ X1_v10 (Il2CppClass<System.Reflection.PropertyInfo>)+128]);\n\tgoto L_FFFFFFFF;\n\tv196 = v196_asT == 0;\n\tif (v196) goto L_00B5;\nL_009E:\n\tv272 = v233 < v193;\n\tv229 = ~v272;\n\tv197 = ~v229;\n\tif (v197) goto L_00B5;\n\tv273 = v191 << 4;\n\tv274 = v235 + v273;\n\tv275 = *([v274 @ X8_v13+130]);\n\tv276 = *([v274 @ X8_v13+138]);\n\t// 179 IndirectJump v275 @ X2_v3, member @ X0 (System.Reflection.MemberInfo), member @ X0 (System.Reflection.MemberInfo), v276 @ X1_v7, v275 @ X2_v3, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\nL_00B5:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_00BB:\n\tv154 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v154, \"MemberInfo must be of type FieldInfo, PropertyInfo or EventInfo\", \"member\");\n\tthrow v154;\n// 154 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static Type GetMemberUnderlyingType(MemberInfo member)
		{
			//IL_00e7: Expected I, but got O
			//IL_00f5: Expected I, but got O
			//IL_0105: Expected O, but got I
			//IL_0115: Expected O, but got I
			//IL_015a: Expected I, but got O
			//IL_0168: Expected I, but got O
			//IL_0178: Expected O, but got I
			//IL_0188: Expected O, but got I
			//IL_0074: Expected I, but got O
			//IL_0082: Expected I, but got O
			//IL_0092: Expected O, but got I
			//IL_00a2: Expected O, but got I
			//IL_01e1: Expected O, but got I
			//IL_01f1: Expected O, but got I
			//IL_0201: Expected O, but got I
			MemberTypes memberType = member.MemberType;
			IntPtr intPtr;
			object obj;
			object obj2;
			int num;
			if (memberType != MemberTypes.Event)
			{
				if (memberType != MemberTypes.Property)
				{
					if (memberType != MemberTypes.Field)
					{
						ArgumentException ex = new ArgumentException("MemberInfo must be of type FieldInfo, PropertyInfo or EventInfo", "member");
						throw ex;
					}
					intPtr = (IntPtr)member;
					IntPtr intPtr2 = (IntPtr)typeof(FieldInfo);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X8_v12 (Il2CppClass<System.Reflection.MemberInfo>)+128]");
					obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v230 @ X1_v11 (Il2CppClass<System.Reflection.FieldInfo>)+128]");
					obj2 = 0;
					FieldInfo fieldInfo = member as FieldInfo;
					if ((object)fieldInfo == null)
					{
						goto IL_020b;
					}
					num = 18;
				}
				else
				{
					intPtr = (IntPtr)member;
					IntPtr intPtr3 = (IntPtr)typeof(PropertyInfo);
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X8_v12 (Il2CppClass<System.Reflection.MemberInfo>)+128]");
					obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v159 @ X1_v10 (Il2CppClass<System.Reflection.PropertyInfo>)+128]");
					obj2 = 0;
					PropertyInfo propertyInfo = member as PropertyInfo;
					if ((object)propertyInfo == null)
					{
						goto IL_020b;
					}
					num = 19;
				}
			}
			else
			{
				intPtr = (IntPtr)member;
				IntPtr intPtr4 = (IntPtr)typeof(EventInfo);
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v235 @ X8_v12 (Il2CppClass<System.Reflection.MemberInfo>)+128]");
				obj = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X1_v9 (Il2CppClass<System.Reflection.EventInfo>)+128]");
				obj2 = 0;
				EventInfo eventInfo = member as EventInfo;
				if ((object)eventInfo == null)
				{
					goto IL_020b;
				}
				num = 16;
			}
			if (System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj) >= System.Runtime.CompilerServices.Unsafe.As<object, UIntPtr>(ref obj2))
			{
				int num2 = num << 4;
				object obj3 = (long)intPtr + (long)num2;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X8_v13+130]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v274 @ X8_v13+138]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v275 @ X2_v3 (should have been resolved before IL gen)");
			}
			goto IL_020b;
			IL_020b:
			throw new InvalidCastException();
		}

		[Token(Token = "0x600066C")]
		[Address(RVA = "0xE53230", Offset = "0xE53230", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv26 = *([1EFD008]);\n\tv27 = *([v26 @ X8_v13]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, target, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([20247C1]) = v45;\nL_0019:\n\tv107 = memberInfo.Length;\n\tv58 = memberInfo.Length < 1;\n\tif (v58) goto L_005B;\nL_0029:\n\tv169 = v70 < v107;\n\tv98 = ~v169;\n\tif (v98) goto L_005C;\n\tgoto L_0042;\n\tv198 = *([v193 @ X0_v10+E0]);\n\tv199 = v198 == 0;\n\tv200 = ~v199;\n\tif (v200) goto L_0042;\n\tv202 = \"il2cpp_codegen_runtime_class_init\"(v193, v159, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0042:\n\tv142 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(memberInfo[v70 @ X22_v5 (System.Int32)], v105);\n\tv107 = memberInfo.Length;\n\tv70 = v70 + 1;\n\tv124 = v70 < memberInfo.Length;\n\tif (v124) goto L_0029;\nL_005B:\n\treturn v145;\nL_005C:\n\tv197 = new System.IndexOutOfRangeException();\n\tthrow v197;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 71 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static object GetMemberValue(MemberInfo[] memberInfo, object target)
		{
			int num = memberInfo.Length;
			bool flag = memberInfo.Length < 1;
			object result = target;
			if (!flag)
			{
				int num2 = 0;
				object target2 = target;
				bool flag2;
				do
				{
					if (num2 < num)
					{
						object memberValue = GetMemberValue(memberInfo[num2], target2);
						num = memberInfo.Length;
						num2++;
						flag2 = num2 < memberInfo.Length;
						result = memberValue;
						target2 = memberValue;
						continue;
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex;
				}
				while (flag2);
			}
			return result;
		}

		[Token(Token = "0x600066D")]
		[Address(RVA = "0xE53304", Offset = "0xE53304", Length = "0x230")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1EB1C70]);\n\tv23 = *([v22 @ X8_v28]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, target, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([20247C2]) = v41;\nL_001B:\n\tv47 = System.Reflection.MemberInfo::get_MemberType(member);\n\tv52 = v47 == 0x10;\n\tif (v52) goto L_005E;\n\tv68 = v47 != 4;\n\tif (v68) goto L_008E;\n\tv114 = member->klass;\n\tgoto L_FFFFFFFF;\n\tv189 = v189_asT == 0;\n\tif (v189) goto L_00A1;\n\tv223 = member->klass->vtable[19];\n\tv224 = member->klass->vtable[19];\n\t// 91 IndirectJump v223 @ X3_v8, member @ X0 (System.Reflection.MemberInfo), member @ X0 (System.Reflection.MemberInfo), target @ X1 (System.Object), v224 @ X2_v11, v223 @ X3_v8, v279 @ X4_v2, v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\nL_005E:\n\tv71 = member->klass;\n\tgoto L_FFFFFFFF;\n\tv141 = v141_asT == 0;\n\tif (v141) goto L_009F;\n\t*([v71 @ X8_v24 (Il2CppClass<System.Reflection.MemberInfo>)+2C0])(returnVal1, member, target, 0, *([v71 @ X8_v24 (Il2CppClass<System.Reflection.MemberInfo>)+2C8]), v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\nL_008E:\n\tv111 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v111, \"MemberInfo is not of type FieldInfo or PropertyInfo\", \"member\");\n\tthrow v111;\nL_009F:\n\tthrow System.InvalidCastException;\nL_00A1:\n\tv209 = new System.InvalidCastException();\n\tv242 = v262 != 1;\n\tif (v242) goto L_00DA;\n\tv278 = 0x6D2BC0(v209, v262, v302, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv294 = *([v278 @ X0_v10 (System.ArgumentException)]);\n\tv298 = \"il2cpp_vm_class_is_assignable_from\"(System.Reflection.TargetParameterCountException, *([v294 @ X19_v5 (System.Exception)]), v302, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv299 = v298 & 1;\n\tv286 = v299 == 0;\n\tif (v286) goto L_00D0;\n\tv300 = 0x6D2490(v298, *([v294 @ X19_v5 (System.Exception)]), v302, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv318 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v318, \"MemberInfo has index parameters\", \"member\", v294);\n\tthrow v318;\nL_00D0:\n\tv314 = 0x6D1E60(8, *([v294 @ X19_v5 (System.Exception)]), v302, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\t*([v314 @ X0_v15]) = *([v278 @ X0_v10 (System.ArgumentException)]);\n\tv262 = 0x1E8A000 + 0x870;\n\tv320 = 0x6D2A00(v314, v262, 0, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv285 = 0x6D2490(v320, v262, 0, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_00DA:\n\tv291 = 0x6D2380(v270, v262, v302, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturnVal2 = 0x846AA4(v291, v262, v302, v281, v279, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\treturn returnVal2;\n// 171 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static object GetMemberValue(MemberInfo member, object target)
		{
			//IL_00d4: Expected I, but got O
			//IL_0057: Expected I, but got O
			//IL_0065: Expected I4, but got O
			//IL_0094: Expected I4, but got O
			//IL_00b2: Expected O, but got I
			//IL_00c2: Expected O, but got I
			//IL_023d: Expected I, but got O
			//IL_01f2: Expected O, but got I4
			MemberTypes memberType = member.MemberType;
			if (memberType != MemberTypes.Property)
			{
				if (memberType != MemberTypes.Field)
				{
					ArgumentException ex = new ArgumentException("MemberInfo is not of type FieldInfo or PropertyInfo", "member");
					IntPtr intPtr = (IntPtr)0;
					Exception ex2 = null;
					throw ex;
				}
				IntPtr intPtr2 = (IntPtr)member;
				int num = (int)typeof(FieldInfo);
				FieldInfo fieldInfo = member as FieldInfo;
				bool flag = (object)fieldInfo == null;
				num = (int)typeof(FieldInfo);
				if (flag)
				{
					InvalidCastException ex3 = new InvalidCastException();
					bool flag2 = num != 1;
					InvalidCastException ex4 = ex3;
					if (!flag2)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
						ArgumentException ex5 = default(ArgumentException);
						Exception innerException = ex5;
						Cpp2ILHelpers.NoteDecompilerIssue("Unknown call target operand: \"il2cpp_vm_class_is_assignable_from\"");
						object obj = default(object);
						IntPtr intPtr;
						if ((uint)((ulong)(long)(IntPtr)obj & 1uL) != 0)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
							ArgumentException ex6 = new ArgumentException("MemberInfo has index parameters", "member", innerException);
							object obj2 = 0;
							intPtr = (IntPtr)0;
							throw ex6;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D1E60 (native __cxa_allocate_exception)");
						object obj3 = ex5;
						num = 32022528 + 2160;
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2A00 (native __cxa_throw)");
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
						intPtr = (IntPtr)null;
						InvalidCastException ex7 = default(InvalidCastException);
						ex4 = ex7;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @846AA4 (inside TMPro.TMP_MeshInfo::SwapVertexData +0x8C)");
					object result = default(object);
					return result;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v25 (Il2CppClass<System.Reflection.MemberInfo>)+260]");
				object obj4 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v114 @ X8_v25 (Il2CppClass<System.Reflection.MemberInfo>)+268]");
				object obj5 = 0;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v223 @ X3_v8 (should have been resolved before IL gen)");
			}
			IntPtr intPtr3 = (IntPtr)member;
			PropertyInfo propertyInfo = member as PropertyInfo;
			if ((object)propertyInfo != null)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v71 @ X8_v24 (Il2CppClass<System.Reflection.MemberInfo>)+2C0] (should have been resolved before IL gen)");
				object result2 = default(object);
				return result2;
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x600066E")]
		[Address(RVA = "0xE53534", Offset = "0xE53534", Length = "0x170")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv26 = *([1ED3710]);\n\tv27 = *([v26 @ X8_v20]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, target, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20247C3]) = v44;\nL_001D:\n\tv50 = System.Reflection.MemberInfo::get_MemberType(member);\n\tv55 = v50 == 0x10;\n\tif (v55) goto L_0062;\n\tv113 = v50 != 4;\n\tif (v113) goto L_0095;\n\tgoto L_FFFFFFFF;\n\tv180 = v180_asT == 0;\n\tif (v180) goto L_008F;\n\tSystem.Reflection.FieldInfo::SetValue(member, target, value);\n\treturn;\nL_0062:\n\tv116 = member->klass;\n\tgoto L_FFFFFFFF;\n\tv178 = v178_asT == 0;\n\tif (v178) goto L_008F;\n\tv202 = member->klass->vtable[27];\n\tv203 = member->klass->vtable[27];\n\t// 141 IndirectJump v202 @ X5_v1, member @ X0 (System.Reflection.MemberInfo), member @ X0 (System.Reflection.MemberInfo), target @ X1 (System.Object), value @ X2 (System.Object), 0, v203 @ X4_v1, v202 @ X5_v1, v32 @ X6, v33 @ X7, v34 @ V0, v35 @ V1, v36 @ V2, v37 @ V3, v38 @ V4, v39 @ V5, v40 @ V6, v41 @ V7\nL_008F:\n\tthrow System.InvalidCastException;\n\tthrow System.NullReferenceException;\nL_0095:\n\tv148 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v148, \"MemberInfo must be if type FieldInfo or PropertyInfo\", \"member\");\n\tthrow v148;\n// 138 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetMemberValue(MemberInfo member, object target, object value)
		{
			//IL_0098: Expected I, but got O
			//IL_00d7: Expected O, but got I
			//IL_00e7: Expected O, but got I
			MemberTypes memberType = member.MemberType;
			if (memberType != MemberTypes.Property)
			{
				if (memberType != MemberTypes.Field)
				{
					ArgumentException ex = new ArgumentException("MemberInfo must be if type FieldInfo or PropertyInfo", "member");
					throw ex;
				}
				FieldInfo fieldInfo = member as FieldInfo;
				if ((object)fieldInfo != null)
				{
					((FieldInfo)member).SetValue(target, value);
					return;
				}
			}
			else
			{
				IntPtr intPtr = (IntPtr)member;
				PropertyInfo propertyInfo = member as PropertyInfo;
				if ((object)propertyInfo != null)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v13 (Il2CppClass<System.Reflection.MemberInfo>)+2E0]");
					object obj = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v116 @ X8_v13 (Il2CppClass<System.Reflection.MemberInfo>)+2E8]");
					object obj2 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v202 @ X5_v1 (should have been resolved before IL gen)");
				}
			}
			throw new InvalidCastException();
		}

		[Token(Token = "0x600066F")]
		[Address(RVA = "0xE536A4", Offset = "0xE536A4", Length = "0x198")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv32 = *([1ED0908]);\n\tv33 = *([v32 @ X8_v20]);\n\tv34 = \"il2cpp_codegen_initialize_method\"(v33, target, value, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20247C4]) = v50;\nL_001C:\n\tv182 = memberInfo.Length;\n\tv53 = memberInfo.Length - 1;\n\tv64 = v53 < 1;\n\tif (v64) goto L_00A4;\nL_002D:\n\tv184 = v167 < v182;\n\tv185 = ~v184;\n\tif (v185) goto L_00A9;\n\tgoto L_0047;\n\tv231 = *([v223 @ X0_v21+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0047;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v223, v164, value, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0047:\n\tv108 = HutongGames.PlayMaker.ReflectionUtils::GetMemberValue(memberInfo[v167 @ X24_v8 (System.Int32)], v181);\n\tv182 = memberInfo.Length;\n\tv167 = v167 + 1;\n\tv105 = memberInfo.Length - 1;\n\tv78 = v167 < v105;\n\tif (v78) goto L_002D;\nL_005C:\n\tv154 = System.Object::GetType(v158);\n\tv215 = System.Type::get_IsValueType(v154);\n\tv217 = memberInfo.Length == 0;\n\tif (v217) goto L_00A9;\n\tv306 = memberInfo.Length << 0x20;\n\tv307 = 0xFFFFFFFF00000000 + v306;\n\tv263 = v307 >> 0x1D;\n\tv308 = memberInfo + v263;\n\tv312 = v215 == 0;\n\tif (v312) goto L_008D;\n\tgoto L_0089;\n\tv317 = *([v309 @ X0_v13+E0]);\n\tv318 = v317 == 0;\n\tv319 = ~v318;\n\tif (v319) goto L_0089;\n\tv321 = \"il2cpp_codegen_runtime_class_init\"(v309, v198, value, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0089:\n\tHutongGames.PlayMaker.ReflectionUtils::SetBoxedMemberValue(v162, v126, v158, *([v308 @ X9_v8+20]), value);\n\treturn;\nL_008D:\n\tgoto L_00A0;\n\tv322 = *([v309 @ X0_v13+E0]);\n\tv323 = v322 == 0;\n\tv324 = ~v323;\n\tif (v324) goto L_00A0;\n\tv326 = \"il2cpp_codegen_runtime_class_init\"(v309, v198, value, methodInfo, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_00A0:\n\tHutongGames.PlayMaker.ReflectionUtils::SetMemberValue(*([v308 @ X9_v8+20]), v158, value);\n\treturn;\nL_00A4:\n\tv122 = target == 0;\n\tv110 = ~v122;\n\tif (v110) goto L_005C;\n\tv163 = new System.NullReferenceException();\nL_00A9:\n\tv222 = new System.IndexOutOfRangeException();\n\tthrow v222;\n\treturn;\n// 116 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetMemberValue(MemberInfo[] memberInfo, object target, object value)
		{
			//IL_0143: Expected O, but got I8
			//IL_0160: Expected O, but got I
			//IL_01c2: Expected O, but got I
			//IL_01a3: Expected O, but got I
			int num = memberInfo.Length;
			int num2 = memberInfo.Length - 1;
			int num3;
			object memberValue;
			MemberInfo memberInfo2;
			object obj;
			object obj2;
			if (num2 >= 1)
			{
				num3 = 0;
				object target2 = target;
				while (num3 < num)
				{
					memberValue = GetMemberValue(memberInfo[num3], target2);
					num = memberInfo.Length;
					num3++;
					int num4 = memberInfo.Length - 1;
					bool flag = num3 < num4;
					target2 = memberValue;
					if (flag)
					{
						continue;
					}
					goto IL_00bd;
				}
			}
			else
			{
				bool flag2 = target == null;
				bool flag3 = !flag2;
				memberInfo2 = null;
				obj = target;
				obj2 = null;
				if (flag3)
				{
					goto IL_00e3;
				}
				NullReferenceException ex = new NullReferenceException();
			}
			goto IL_01fd;
			IL_01fd:
			IndexOutOfRangeException ex2 = new IndexOutOfRangeException();
			throw ex2;
			IL_00e3:
			Type type = obj.GetType();
			bool isValueType = type.IsValueType;
			if (memberInfo.Length != 0)
			{
				int num5 = memberInfo.Length << 32;
				object obj3 = -4294967296L + num5;
				int num6 = (int)((long)(IntPtr)obj3 >> 29);
				object obj4 = (long)(IntPtr)memberInfo + (long)num6;
				if (isValueType)
				{
					object parent = obj2;
					MemberInfo targetInfo = memberInfo2;
					object target3 = obj;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ X9_v8+20]");
					SetBoxedMemberValue(parent, targetInfo, target3, (MemberInfo)0, value);
				}
				else
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v308 @ X9_v8+20]");
					SetMemberValue((MemberInfo)0, obj, value);
				}
				return;
			}
			goto IL_01fd;
			IL_00bd:
			memberInfo2 = memberInfo[num3];
			obj = memberValue;
			obj2 = memberValue;
			goto IL_00e3;
		}

		[Token(Token = "0x6000670")]
		[Address(RVA = "0xE5383C", Offset = "0xE5383C", Length = "0x9C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv34 = *([1EBC678]);\n\tv35 = *([v34 @ X8_v9]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, targetInfo, target, propertyInfo, value, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20247C5]) = v50;\nL_0021:\n\tgoto L_002A;\n\tv57 = *([v53 @ X0_v2+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tgoto L_002A;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v53, targetInfo, target, propertyInfo, value, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_002A:\n\tHutongGames.PlayMaker.ReflectionUtils::SetMemberValue(propertyInfo, target, value);\n\tHutongGames.PlayMaker.ReflectionUtils::SetMemberValue(targetInfo, parent, target);\n\treturn;\n// 42 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void SetBoxedMemberValue(object parent, MemberInfo targetInfo, object target, MemberInfo propertyInfo, object value)
		{
			SetMemberValue(propertyInfo, target, value);
			SetMemberValue(targetInfo, parent, target);
		}

		[Token(Token = "0x6000671")]
		[Address(RVA = "0x96C444", Offset = "0x96C444", Length = "0xB4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv22 = *([1ED6648]);\n\tv23 = *([v22 @ X8_v12]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2021558]) = v41;\nL_001D:\n\tgoto L_0025;\n\tv50 = *([v44 @ X0_v2+E0]);\n\tv51 = v50 == 0;\n\tv52 = ~v51;\n\tgoto L_0025;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v44, methodInfo, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_0025:\n\tv59 = System.Type::GetTypeFromHandle(Il2CppClass<T>);\n\tgoto L_003D;\n\tv67 = *([v63 @ X8_v9+E0]);\n\tv68 = v67 == 0;\n\tv69 = ~v68;\n\tif (v69) goto L_003D;\n\tv83 = v63;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v83, v58, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_003D:\n\treturnVal1 = HutongGames.PlayMaker.ReflectionUtils::GetFieldsAndProperties(v59, bindingAttr);\n\treturn returnVal1;\n// 41 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<MemberInfo> GetFieldsAndProperties<T>(BindingFlags bindingAttr)
		{
			Type typeFromHandle = typeof(T);
			return GetFieldsAndProperties(typeFromHandle, bindingAttr);
		}

		[Token(Token = "0x6000672")]
		[Address(RVA = "0xE538D8", Offset = "0xE538D8", Length = "0xDC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv24 = *([1EE7638]);\n\tv25 = *([v24 @ X8_v12]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, bindingAttr, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40);\n\tv43 = 0 | 1;\n\t*([20247C6]) = v43;\nL_0019:\n\tv47 = new System.Collections.Generic.List`1<System.Reflection.MemberInfo>();\n\tSystem.Collections.Generic.List`1<System.Reflection.MemberInfo>::.ctor(v47);\n\tv58 = System.Type::GetFields(type, bindingAttr);\n\tSystem.Collections.Generic.List`1<System.Reflection.MemberInfo>::AddRange(v47, v58);\n\tv79 = System.Type::GetProperties(type, bindingAttr);\n\tSystem.Collections.Generic.List`1<System.Reflection.MemberInfo>::AddRange(v47, v79);\n\treturn v47;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 54 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static List<MemberInfo> GetFieldsAndProperties(Type type, BindingFlags bindingAttr)
		{
			List<MemberInfo> list = new List<MemberInfo>();
			IEnumerable<MemberInfo> fields = type.GetFields(bindingAttr);
			list.AddRange(fields);
			IEnumerable<MemberInfo> properties = type.GetProperties(bindingAttr);
			list.AddRange(properties);
			return list;
		}

		[Token(Token = "0x6000673")]
		[Address(RVA = "0xE539B4", Offset = "0xE539B4", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = type->klass;\n\tv4 = type->klass->vtable[44];\n\tv5 = type->klass->vtable[44];\n\t// 6 IndirectJump v4 @ X3_v1, type @ X0 (System.Type), type @ X0 (System.Type), 20, v5 @ X2_v1, v4 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static FieldInfo[] GetPublicFields(this Type type)
		{
			//IL_0008: Expected I, but got O
			//IL_0018: Expected O, but got I
			//IL_0028: Expected O, but got I
			IntPtr intPtr = (IntPtr)type;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Type>)+3F0]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Type>)+3F8]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000674")]
		[Address(RVA = "0xE539D8", Offset = "0xE539D8", Length = "0x24")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = type->klass;\n\tv4 = type->klass->vtable[54];\n\tv5 = type->klass->vtable[54];\n\t// 6 IndirectJump v4 @ X3_v1, type @ X0 (System.Type), type @ X0 (System.Type), 20, v5 @ X2_v1, v4 @ X3_v1, v6 @ X4, v7 @ X5, v8 @ X6, v9 @ X7, v10 @ V0, v11 @ V1, v12 @ V2, v13 @ V3, v14 @ V4, v15 @ V5, v16 @ V6, v17 @ V7\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static PropertyInfo[] GetPublicProperties(this Type type)
		{
			//IL_0008: Expected I, but got O
			//IL_0018: Expected O, but got I
			//IL_0028: Expected O, but got I
			IntPtr intPtr = (IntPtr)type;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Type>)+490]");
			object obj = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v2 @ X8_v1 (Il2CppClass<System.Type>)+498]");
			object obj2 = 0;
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v4 @ X3_v1 (should have been resolved before IL gen)");
			return null;
		}

		[Token(Token = "0x6000675")]
		[Address(RVA = "0xE539FC", Offset = "0xE539FC", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv13 = System.Type::GetMethod(type, methodName);\n\tv37 = System.Reflection.MemberInfo::get_DeclaringType(v13);\n\tv42 = v37 - type;\n\tv44 = v42 == 0;\n\treturn v44;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool ImplementsMethod(this Type type, string methodName)
		{
			//IL_0032: Expected O, but got I
			MethodInfo method = type.GetMethod(methodName);
			Type declaringType = method.DeclaringType;
			object obj = (long)(IntPtr)declaringType - (long)(IntPtr)type;
			return obj == null;
		}

		[Token(Token = "0x6000676")]
		[Address(RVA = "0xE53A44", Offset = "0xE53A44", Length = "0x74")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1EAA900]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20247C7]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Dictionary`2<System.String, System.Type>();\n\tSystem.Collections.Generic.Dictionary`2<System.String, System.Type>::.ctor(v39);\n\tv47.typeLookup = v39;\n\treturn;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static ReflectionUtils()
		{
			Dictionary<string, Type> dictionary = new Dictionary<string, Type>();
			typeLookup = dictionary;
		}
	}
}
