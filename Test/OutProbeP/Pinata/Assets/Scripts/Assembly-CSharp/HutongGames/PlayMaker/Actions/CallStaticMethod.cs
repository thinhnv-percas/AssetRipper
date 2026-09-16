using System;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D304", Offset = "0x75D304")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D304", Offset = "0x75D304")]
	[Token(Token = "0x2000342")]
	public class CallStaticMethod : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8B0C", Offset = "0x7C8B0C")]
		[Token(Token = "0x4001AD1")]
		[FieldOffset(Offset = "0x50")]
		public FsmString className;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8B44", Offset = "0x7C8B44")]
		[Token(Token = "0x4001AD2")]
		[FieldOffset(Offset = "0x58")]
		public FsmString methodName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8B7C", Offset = "0x7C8B7C")]
		[Token(Token = "0x4001AD3")]
		[FieldOffset(Offset = "0x60")]
		public FsmVar[] parameters;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C8BB4", Offset = "0x7C8BB4")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8BB4", Offset = "0x7C8BB4")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8BB4", Offset = "0x7C8BB4")]
		[Token(Token = "0x4001AD4")]
		[FieldOffset(Offset = "0x68")]
		public FsmVar storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8C28", Offset = "0x7C8C28")]
		[Token(Token = "0x4001AD5")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[Token(Token = "0x4001AD6")]
		[FieldOffset(Offset = "0x78")]
		private Type cachedType;

		[Token(Token = "0x4001AD7")]
		[FieldOffset(Offset = "0x80")]
		private string cachedClassName;

		[Token(Token = "0x4001AD8")]
		[FieldOffset(Offset = "0x88")]
		private string cachedMethodName;

		[Token(Token = "0x4001AD9")]
		[FieldOffset(Offset = "0x90")]
		private MethodInfo cachedMethodInfo;

		[Token(Token = "0x4001ADA")]
		[FieldOffset(Offset = "0x98")]
		private ParameterInfo[] cachedParameterInfo;

		[Token(Token = "0x4001ADB")]
		[FieldOffset(Offset = "0xA0")]
		private object[] parametersArray;

		[Token(Token = "0x4001ADC")]
		[FieldOffset(Offset = "0xA8")]
		private string errorString;

		[Token(Token = "0x6001051")]
		[Address(RVA = "0xA8D760", Offset = "0xA8D760", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EE71C8]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221D6]) = v38;\nL_0013:\n\tv39 = this.parameters;\n\t// 26 NewArr v45 @ X0_v5 (System.Object[]), typeof(System.Object[]), v39.Length\n\tthis.parametersArray = v45;\n\tHutongGames.PlayMaker.Actions.CallStaticMethod::DoMethodCall(this);\n\tv50 = ~this.everyFrame;\n\tif (v50) goto L_002E;\n\treturn;\nL_002E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void OnEnter()
		{
			FsmVar[] array = parameters;
			object[] array2 = new object[array.Length];
			parametersArray = array2;
			DoMethodCall();
			if (!everyFrame)
			{
				Finish();
			}
		}

		[Token(Token = "0x6001052")]
		[Address(RVA = "0xA8DA14", Offset = "0xA8DA14", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CallStaticMethod::DoMethodCall(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMethodCall();
		}

		[Token(Token = "0x6001053")]
		[Address(RVA = "0xA8D7EC", Offset = "0xA8D7EC", Length = "0x228")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EBBF70]);\n\tv25 = *([v24 @ X8_v34]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221D7]) = v44;\nL_0017:\n\tv46 = this.className == 0;\n\tif (v46) goto L_00B3;\n\tv48 = HutongGames.PlayMaker.FsmString::get_Value(this.className);\n\tv56 = System.String::IsNullOrEmpty(v48);\n\tv74 = v56 == 0;\n\tv59 = ~v74;\n\tif (v59) goto L_00B3;\n\tv159 = HutongGames.PlayMaker.FsmString::get_Value(this.className);\n\tv213 = System.String::op_Inequality(this.cachedClassName, v159);\n\tv215 = v213 == 0;\n\tv216 = ~v215;\n\tif (v216) goto L_0042;\n\tv234 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tv221 = System.String::op_Inequality(this.cachedMethodName, v234);\n\tv223 = v221 == 0;\n\tif (v223) goto L_0047;\nL_0042:\n\tthis.errorString = v230.Empty;\n\tv232 = HutongGames.PlayMaker.Actions.CallStaticMethod::DoCache(this);\n\tv236 = v232 == 0;\n\tif (v236) goto L_00A0;\nL_0047:\n\tv241 = this.cachedParameterInfo;\n\tv250 = v241.Length == 0;\n\tif (v250) goto L_FFFFFFFF;\n\tv335 = this.parameters;\nL_005B:\n\tv161 = v187 >= v335.Length;\n\tif (v161) goto L_0097;\n\tv357 = v187 < v335.Length;\n\tv287 = ~v357;\n\tif (v287) goto L_00CC;\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(v335[v187 @ X21_v8 (System.Int32)]);\n\tv255 = this.parametersArray;\n\tv300 = HutongGames.PlayMaker.FsmVar::GetValue(v335[v187 @ X21_v8 (System.Int32)]);\n\tv386 = v300 == 0;\n\tif (v386) goto L_0080;\n\t// 124 IsInst v388 @ X0_v33, typeof(System.Object), v300 @ X0_v30 (System.Object)\nL_0080:\n\tv390 = v187 < v255.Length;\n\tv286 = ~v390;\n\tif (v286) goto L_00CC;\n\tv255[v187 @ X21_v8 (System.Int32)] = v300;\n\tv335 = this.parameters;\n\tv187 = v187 + 1;\n\tv392 = this.parameters == 0;\n\tv303 = ~v392;\n\tif (v303) goto L_005B;\n\tthrow System.NullReferenceException;\nL_0097:\n\tv292 = this.parametersArray;\n\tgoto L_00BB;\nL_00A0:\n\tgoto L_00A8;\n\tv317 = *([v245 @ X0_v38+E0]);\n\tv318 = v317 == 0;\n\tv319 = ~v318;\n\tif (v319) goto L_00A8;\n\tv321 = \"il2cpp_codegen_runtime_class_init\"(v245, v218, v50, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00A8:\n\tUnityEngine.Debug::LogError(this.errorString);\nL_00B3:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_00BB:\n\tv301 = System.Reflection.MethodBase::Invoke(v353, 0, v292);\n\tHutongGames.PlayMaker.FsmVar::SetValue(this.storeResult, v301);\n\treturn;\nL_00CC:\n\tv376 = new System.IndexOutOfRangeException();\n\tgoto L_00D1;\n\tv383 = new System.ArrayTypeMismatchException();\nL_00D1:\n\tthrow v382;\n\tthrow System.NullReferenceException;\n// 142 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMethodCall()
		{
			if (className != null)
			{
				string value = className.Value;
				if (!string.IsNullOrEmpty(value))
				{
					string value2 = className.Value;
					if (!(cachedClassName != value2))
					{
						string value3 = methodName.Value;
						if (!(cachedMethodName != value3))
						{
							goto IL_0115;
						}
					}
					errorString = string.Empty;
					if (DoCache())
					{
						goto IL_0115;
					}
					Debug.LogError(errorString);
				}
			}
			Finish();
			return;
			IL_0115:
			ParameterInfo[] array = cachedParameterInfo;
			object[] array4;
			MethodBase methodBase;
			if (array.Length != 0)
			{
				FsmVar[] array2 = parameters;
				int num = 0;
				IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
				while (num < array2.Length)
				{
					if (num < array2.Length)
					{
						array2[num].UpdateValue();
						object[] array3 = parametersArray;
						object value4 = array2[num].GetValue();
						if (value4 != null)
						{
							object obj = value4 as object;
						}
						if (num < array3.Length)
						{
							array3[num] = value4;
							array2 = parameters;
							num++;
							if (parameters == null)
							{
								throw new NullReferenceException();
							}
							continue;
						}
					}
					IndexOutOfRangeException ex = new IndexOutOfRangeException();
					throw ex2;
				}
				array4 = parametersArray;
				methodBase = cachedMethodInfo;
			}
			else
			{
				array4 = null;
				methodBase = cachedMethodInfo;
			}
			object value5 = methodBase.Invoke(null, array4);
			storeResult.SetValue(value5);
		}

		[Token(Token = "0x6001054")]
		[Address(RVA = "0xA8DA18", Offset = "0xA8DA18", Length = "0x298")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv24 = *([1F08700]);\n\tv25 = *([v24 @ X8_v34]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221D8]) = v44;\nL_001A:\n\tv48 = HutongGames.PlayMaker.FsmString::get_Value(this.className);\n\tgoto L_002B;\n\tv190 = *([v140 @ X8_v8+E0]);\n\tv191 = v190 == 0;\n\tv192 = ~v191;\n\tif (v192) goto L_002B;\n\tv225 = v140;\n\tv194 = \"il2cpp_codegen_runtime_class_init\"(v225, v47, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_002B:\n\tv198 = HutongGames.PlayMaker.ReflectionUtils::GetGlobalType(v48);\n\tthis.cachedType = v198;\n\tgoto L_003D;\n\tv235 = *([v228 @ X0_v15+E0]);\n\tv236 = v235 == 0;\n\tv237 = ~v236;\n\tif (v237) goto L_003D;\n\tv239 = \"il2cpp_codegen_runtime_class_init\"(v228, v197, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_003D:\n\tv242 = System.Type::op_Equality(v198, 0);\n\tv244 = v242 == 0;\n\tif (v244) goto L_004E;\n\tv325 = this.errorString;\n\tv320 = HutongGames.PlayMaker.FsmString::get_Value(this.className);\n\tgoto L_00C0;\nL_004E:\n\tv170 = HutongGames.PlayMaker.FsmString::get_Value(this.className);\n\tv187 = this.parameters;\n\tthis.cachedClassName = v170;\n\tv171 = new System.Collections.Generic.List`1<System.Type>();\n\tSystem.Collections.Generic.List`1<System.Type>::.ctor(v171, v187.Length);\n\tv99 = this.parameters;\n\tv222 = v99.Length;\n\tv361 = v99.Length < 1;\n\tif (v361) goto L_009A;\nL_0070:\n\tv387 = v56 < v222;\n\tv96 = ~v387;\n\tif (v96) goto L_00E3;\n\tv172 = HutongGames.PlayMaker.FsmVar::get_RealType(v99[v56 @ X22_v10 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Type>::Add(v171, v172);\n\tv222 = v99.Length;\n\tv56 = v56 + 1;\n\tv365 = v56 < v99.Length;\n\tif (v365) goto L_0070;\nL_009A:\n\tv173 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tv174 = System.Collections.Generic.List`1<System.Type>::ToArray(v171);\n\tv393 = System.Type::GetMethod(this.cachedType, v173, v174);\n\tthis.cachedMethodInfo = v393;\n\tv396 = System.Reflection.MethodInfo::op_Equality(v393, 0);\n\tv398 = v396 == 0;\n\tif (v398) goto L_00CB;\n\tv325 = this.errorString;\n\tv320 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\nL_00C0:\n\tv334 = System.String::Concat(v325, *([v323 @ X8_v14 (System.String)]), v320, \"\\n\");\n\tthis.errorString = v334;\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tgoto L_00DF;\nL_00CB:\n\tv175 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tthis.cachedMethodName = v175;\n\tv401 = System.Reflection.MethodBase::GetParameters(this.cachedMethodInfo);\n\tthis.cachedParameterInfo = v401;\nL_00DF:\n\treturn returnVal2;\n\tthrow System.NullReferenceException;\n\tv189 = new System.NullReferenceException();\nL_00E3:\n\tv224 = new System.IndexOutOfRangeException();\n\tthrow v224;\n\treturn returnVal1;\n// 163 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoCache()
		{
			string value = className.Value;
			string text;
			string value2;
			string text2;
			if ((cachedType = ReflectionUtils.GetGlobalType(value)) == null)
			{
				text = errorString;
				value2 = className.Value;
				text2 = "Class is invalid: ";
			}
			else
			{
				string value3 = className.Value;
				FsmVar[] array = parameters;
				cachedClassName = value3;
				List<Type> list = new List<Type>(array.Length);
				FsmVar[] array2 = parameters;
				int num = array2.Length;
				if (array2.Length >= 1)
				{
					int num2 = 0;
					do
					{
						if (num2 < num)
						{
							Type realType = array2[num2].RealType;
							list.Add(realType);
							num = array2.Length;
							num2++;
							continue;
						}
						IndexOutOfRangeException ex = new IndexOutOfRangeException();
						throw ex;
					}
					while (num2 < array2.Length);
				}
				string value4 = methodName.Value;
				Type[] types = list.ToArray();
				if (!((cachedMethodInfo = cachedType.GetMethod(value4, types)) == null))
				{
					string value5 = methodName.Value;
					cachedMethodName = value5;
					ParameterInfo[] array3 = cachedMethodInfo.GetParameters();
					cachedParameterInfo = array3;
					return true;
				}
				text = errorString;
				value2 = methodName.Value;
				text2 = "Invalid Method Name or Parameters: ";
			}
			string text3 = text + text2 + value2 + "\n";
			errorString = text3;
			Finish();
			return false;
		}

		[Token(Token = "0x6001055")]
		[Address(RVA = "0xA8DCB0", Offset = "0xA8DCB0", Length = "0x510")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv24 = *([1EE98C0]);\n\tv25 = *([v24 @ X8_v87]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221D9]) = v44;\nL_001C:\n\tthis.errorString = v49.Empty;\n\tv51 = HutongGames.PlayMaker.Actions.CallStaticMethod::DoCache(this);\n\tv54 = System.String::IsNullOrEmpty(this.errorString);\n\tv56 = v54 == 0;\n\tif (v56) goto L_00E0;\n\tv586 = this.parameters;\n\tv60 = this.cachedParameterInfo;\n\tv99 = v586.Length != v60.Length;\n\tif (v99) goto L_00E6;\n\tv422 = v586.Length < 1;\n\tif (v422) goto L_0092;\nL_0044:\n\tv176 = v91 - 1;\n\tv189 = HutongGames.PlayMaker.FsmVar::get_RealType(v586[v176 @ X10_v13 (System.Int32)]);\n\tv207 = this.cachedParameterInfo;\n\tv190 = System.Reflection.ParameterInfo::get_ParameterType(v207[v176 @ X10_v13 (System.Int32)]);\n\tv97 = v189 != v190;\n\tif (v97) goto L_0171;\n\tv586 = this.parameters;\n\tv91 = v91 + 1;\n\tv562 = v91 < v586.Length;\n\tif (v562) goto L_0044;\nL_0092:\n\tv592 = System.Reflection.MethodInfo::get_ReturnType(this.cachedMethodInfo);\n\tgoto L_00A6;\n\tv688 = *([v367 @ X8_v42+E0]);\n\tv689 = v688 == 0;\n\tv690 = ~v689;\n\tif (v690) goto L_00A6;\n\tv697 = v367;\n\tv692 = \"il2cpp_codegen_runtime_class_init\"(v697, v591, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00A6:\n\tv194 = System.Type::GetTypeFromHandle(System.Void);\n\tv138 = v592 == v194;\n\tif (v138) goto L_0203;\n\tv191 = System.Reflection.MethodInfo::get_ReturnType(this.cachedMethodInfo);\n\tv712 = HutongGames.PlayMaker.FsmVar::get_RealType(this.storeResult);\n\tv321 = v191 == v712;\n\tif (v321) goto L_FFFFFFFF;\n\tv753 = System.Reflection.MethodInfo::get_ReturnType(this.cachedMethodInfo);\n\treturnVal2 = System.String::Concat(\"Store Result is of the wrong type.\\nIt should be of type: \", v753);\n\treturn returnVal2;\nL_00E0:\n\treturnVal1 = this.errorString;\n\tgoto L_021A;\nL_00E6:\n\t// 230 NewArr v798 @ X0_v16 (System.Object[]), typeof(System.Object[]), 5\n\tv601 = \"Parameter count does not match method.\\nMethod has \" == 0;\n\tif (v601) goto L_00F8;\n\t// 241 IsInst v520 @ X0_v41, typeof(System.Object), \"Parameter count does not match method.\nMethod has \"\n\tv532 = v520 == 0;\n\tif (v532) goto L_0221;\nL_00F8:\n\tv798[0] = \"Parameter count does not match method.\\nMethod has \";\n\tv210 = this.cachedParameterInfo;\n\tv49 = v210.Length;\n\t// 258 Box v704 @ X0_v25, typeof(System.Int32), &v49 @ X8_v4 (Il2CppStaticFields<System.String>)\n\tv710 = v704 == 0;\n\tif (v710) goto L_0119;\n\t// 265 IsInst v521 @ X0_v40, typeof(System.Object), v704 @ X0_v25\n\tv533 = v521 == 0;\n\tif (v533) goto L_0221;\nL_0119:\n\tv798[1] = v704;\n\tv742 = \" parameters.\\nYou specified \" == 0;\n\tif (v742) goto L_0132;\n\t// 289 IsInst v522 @ X0_v38, typeof(System.Object), \" parameters.\nYou specified \"\n\tv534 = v522 == 0;\n\tif (v534) goto L_0221;\nL_0132:\n\tv798[2] = \" parameters.\\nYou specified \";\n\tv211 = this.parameters;\n\tv49 = v211.Length;\n\t// 314 Box v764 @ X0_v30, typeof(System.Int32), &v49 @ X8_v4 (Il2CppStaticFields<System.String>)\n\tv767 = v764 == 0;\n\tif (v767) goto L_0151;\n\t// 321 IsInst v523 @ X0_v37, typeof(System.Object), v764 @ X0_v30\n\tv535 = v523 == 0;\n\tif (v535) goto L_0221;\nL_0151:\n\tv798[3] = v764;\n\tv781 = \" paramaters.\" == 0;\n\tif (v781) goto L_016B;\n\t// 345 IsInst v524 @ X0_v35, typeof(System.Object), \" paramaters.\"\n\tv536 = v524 == 0;\n\tif (v536) goto L_0221;\nL_016B:\n\tv798[4] = \" paramaters.\";\n\tgoto L_0201;\nL_0171:\n\t// 369 NewArr v798 @ X0_v16 (System.Object[]), typeof(System.Object[]), 6\n\tv760 = \"Parameters do not match method signature.\\nParameter \" == 0;\n\tif (v760) goto L_0184;\n\t// 380 IsInst v525 @ X0_v90, typeof(System.Object), \"Parameters do not match method signature.\nParameter \"\n\tv537 = v525 == 0;\n\tif (v537) goto L_0221;\nL_0184:\n\tv798[0] = \"Parameters do not match method signature.\\nParameter \";\n\t// 393 Box v773 @ X0_v73, typeof(System.Int32), &v91 @ X23_v12 (System.Int32)\n\tv778 = v773 == 0;\n\tif (v778) goto L_01A0;\n\t// 400 IsInst v526 @ X0_v89, typeof(System.Object), v773 @ X0_v73\n\tv538 = v526 == 0;\n\tif (v538) goto L_0221;\nL_01A0:\n\tv798[1] = v773;\n\tv791 = \" (\" == 0;\n\tif (v791) goto L_01B9;\n\t// 424 IsInst v527 @ X0_v87, typeof(System.Object), \" (\"\n\tv539 = v527 == 0;\n\tif (v539) goto L_0221;\nL_01B9:\n\tv798[2] = \" (\";\n\tv800 = v189 == 0;\n\tif (v800) goto L_01CF;\n\t// 447 IsInst v528 @ X0_v86, typeof(System.Object), v189 @ X0_v65 (System.Type)\n\tv540 = v528 == 0;\n\tif (v540) goto L_0221;\nL_01CF:\n\tv798[3] = v189;\n\tv807 = \") should be of type: \" == 0;\n\tif (v807) goto L_01E8;\n\t// 471 IsInst v529 @ X0_v84, typeof(System.Object), \") should be of type: \"\n\tv541 = v529 == 0;\n\tif (v541) goto L_0221;\nL_01E8:\n\tv798[4] = \") should be of type: \";\n\tv811 = v190 == 0;\n\tif (v811) goto L_01FE;\n\t// 494 IsInst v530 @ X0_v83, typeof(System.Object), v190 @ X0_v67 (System.Type)\n\tv542 = v530 == 0;\n\tif (v542) goto L_0221;\nL_01FE:\n\tv798[5] = v190;\nL_0201:\n\treturnVal1 = System.String::Concat(v798);\n\tgoto L_021A;\nL_0203:\n\tv212 = this.storeResult;\n\tv709 = System.String::IsNullOrEmpty(v212.variableName);\n\tv714 = v709 == 0;\n\tif (v714) goto L_FFFFFFFF;\n\tgoto L_0211;\nL_0211:\n\treturnVal1 = *([v49 @ X8_v4 (Il2CppStaticFields<System.String>)]);\nL_021A:\n\treturn returnVal1;\n\tv624 = new System.IndexOutOfRangeException();\nL_021E:\n\tthrow System.TypeLoadException;\n\tv372 = new System.NullReferenceException();\nL_0221:\n\tv559 = new System.ArrayTypeMismatchException();\n\tgoto L_021E;\n\treturn X0;\n// 410 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			//IL_067d: Expected I, but got O
			//IL_0709: Expected O, but got I
			//IL_066f: Expected I, but got O
			errorString = string.Empty;
			bool flag = DoCache();
			IntPtr intPtr;
			if (string.IsNullOrEmpty(errorString))
			{
				FsmVar[] array = parameters;
				ParameterInfo[] array2 = cachedParameterInfo;
				object[] array4;
				if (array.Length == array2.Length)
				{
					if (array.Length < 1)
					{
						goto IL_0108;
					}
					int num = 1;
					Type realType;
					Type parameterType;
					while (true)
					{
						int num2 = num - 1;
						realType = array[num2].RealType;
						ParameterInfo[] array3 = cachedParameterInfo;
						parameterType = array3[num2].ParameterType;
						if ((object)realType != parameterType)
						{
							break;
						}
						array = parameters;
						num++;
						if (num < array.Length)
						{
							continue;
						}
						goto IL_0108;
					}
					array4 = new object[6];
					if ("Parameters do not match method signature.\nParameter " != null)
					{
						object obj = "Parameters do not match method signature.\nParameter " as object;
						if (obj == null)
						{
							goto IL_0688;
						}
					}
					array4[0] = "Parameters do not match method signature.\nParameter ";
					object obj2 = num;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
						if (obj3 == null)
						{
							goto IL_0688;
						}
					}
					array4[1] = obj2;
					if (" (" != null)
					{
						object obj4 = " (" as object;
						if (obj4 == null)
						{
							goto IL_0688;
						}
					}
					array4[2] = " (";
					if ((object)realType != null)
					{
						object obj5 = realType as object;
						if (obj5 == null)
						{
							goto IL_0688;
						}
					}
					array4[3] = realType;
					if (") should be of type: " != null)
					{
						object obj6 = ") should be of type: " as object;
						if (obj6 == null)
						{
							goto IL_0688;
						}
					}
					array4[4] = ") should be of type: ";
					if ((object)parameterType != null)
					{
						object obj7 = parameterType as object;
						if (obj7 == null)
						{
							goto IL_0688;
						}
					}
					array4[5] = parameterType;
				}
				else
				{
					array4 = new object[5];
					if ("Parameter count does not match method.\nMethod has " != null)
					{
						object obj8 = "Parameter count does not match method.\nMethod has " as object;
						if (obj8 == null)
						{
							goto IL_0688;
						}
					}
					array4[0] = "Parameter count does not match method.\nMethod has ";
					ParameterInfo[] array5 = cachedParameterInfo;
					intPtr = (IntPtr)array5.Length;
					object obj9 = (int)(long)intPtr;
					if (obj9 != null)
					{
						object obj10 = obj9 as object;
						if (obj10 == null)
						{
							goto IL_0688;
						}
					}
					array4[1] = obj9;
					if (" parameters.\nYou specified " != null)
					{
						object obj11 = " parameters.\nYou specified " as object;
						if (obj11 == null)
						{
							goto IL_0688;
						}
					}
					array4[2] = " parameters.\nYou specified ";
					FsmVar[] array6 = parameters;
					intPtr = (IntPtr)array6.Length;
					object obj12 = (int)(long)intPtr;
					if (obj12 != null)
					{
						object obj13 = obj12 as object;
						if (obj13 == null)
						{
							goto IL_0688;
						}
					}
					array4[3] = obj12;
					if (" paramaters." != null)
					{
						object obj14 = " paramaters." as object;
						if (obj14 == null)
						{
							goto IL_0688;
						}
					}
					array4[4] = " paramaters.";
				}
				return string.Concat(array4);
			}
			return errorString;
			IL_0688:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw new TypeLoadException();
			IL_0701:
			return (string)(long)intPtr;
			IL_0108:
			Type returnType = cachedMethodInfo.ReturnType;
			Type typeFromHandle = typeof(void);
			if ((object)returnType != typeFromHandle)
			{
				Type returnType2 = cachedMethodInfo.ReturnType;
				Type realType2 = storeResult.RealType;
				if ((object)returnType2 != realType2)
				{
					Type returnType3 = cachedMethodInfo.ReturnType;
					return "Store Result is of the wrong type.\nIt should be of type: " + returnType3;
				}
			}
			else
			{
				FsmVar fsmVar = storeResult;
				if (!string.IsNullOrEmpty(fsmVar.variableName))
				{
					intPtr = (IntPtr)"Method does not have return.\nSpecify 'none' in Store Result.";
					goto IL_0701;
				}
			}
			intPtr = (IntPtr)string.Empty;
			goto IL_0701;
		}

		[Token(Token = "0x6001056")]
		[Address(RVA = "0xA8E1C0", Offset = "0xA8E1C0", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CallStaticMethod()
		{
		}
	}
}
