using System;
using System.Collections.Generic;
using System.Reflection;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[AttributeAttribute(Type = typeof(ActionCategoryAttribute), RVA = "0x75D2B4", Offset = "0x75D2B4")]
	[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x75D2B4", Offset = "0x75D2B4")]
	[Token(Token = "0x2000341")]
	public class CallMethod : FsmStateAction
	{
		[AttributeAttribute(Type = typeof(ObjectTypeAttribute), RVA = "0x7C8930", Offset = "0x7C8930")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8930", Offset = "0x7C8930")]
		[Token(Token = "0x4001AC4")]
		[FieldOffset(Offset = "0x50")]
		public FsmObject behaviour;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C89B8", Offset = "0x7C89B8")]
		[Token(Token = "0x4001AC5")]
		[FieldOffset(Offset = "0x58")]
		public FsmString methodName;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C89F0", Offset = "0x7C89F0")]
		[Token(Token = "0x4001AC6")]
		[FieldOffset(Offset = "0x60")]
		public FsmVar[] parameters;

		[AttributeAttribute(Type = typeof(ActionSection), RVA = "0x7C8A28", Offset = "0x7C8A28")]
		[AttributeAttribute(Type = typeof(UIHintAttribute), RVA = "0x7C8A28", Offset = "0x7C8A28")]
		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8A28", Offset = "0x7C8A28")]
		[Token(Token = "0x4001AC7")]
		[FieldOffset(Offset = "0x68")]
		public FsmVar storeResult;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8A9C", Offset = "0x7C8A9C")]
		[Token(Token = "0x4001AC8")]
		[FieldOffset(Offset = "0x70")]
		public bool everyFrame;

		[AttributeAttribute(Type = typeof(TooltipAttribute), RVA = "0x7C8AD4", Offset = "0x7C8AD4")]
		[Token(Token = "0x4001AC9")]
		[FieldOffset(Offset = "0x71")]
		public bool manualUI;

		[Token(Token = "0x4001ACA")]
		[FieldOffset(Offset = "0x78")]
		private FsmObject cachedBehaviour;

		[Token(Token = "0x4001ACB")]
		[FieldOffset(Offset = "0x80")]
		private FsmString cachedMethodName;

		[Token(Token = "0x4001ACC")]
		[FieldOffset(Offset = "0x88")]
		private Type cachedType;

		[Token(Token = "0x4001ACD")]
		[FieldOffset(Offset = "0x90")]
		private MethodInfo cachedMethodInfo;

		[Token(Token = "0x4001ACE")]
		[FieldOffset(Offset = "0x98")]
		private ParameterInfo[] cachedParameterInfo;

		[Token(Token = "0x4001ACF")]
		[FieldOffset(Offset = "0xA0")]
		private object[] parametersArray;

		[Token(Token = "0x4001AD0")]
		[FieldOffset(Offset = "0xA8")]
		private string errorString;

		[Token(Token = "0x6001048")]
		[Address(RVA = "0xA8CA20", Offset = "0xA8CA20", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.everyFrame = 0;\n\tthis.behaviour = 0;\n\tthis.parameters = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override void Reset()
		{
			everyFrame = false;
			behaviour = null;
			parameters = null;
		}

		[Token(Token = "0x6001049")]
		[Address(RVA = "0xA8CA30", Offset = "0xA8CA30", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1ED3058]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20221D1]) = v38;\nL_0013:\n\tv39 = this.parameters;\n\t// 26 NewArr v45 @ X0_v5 (System.Object[]), typeof(System.Object[]), v39.Length\n\tthis.parametersArray = v45;\n\tHutongGames.PlayMaker.Actions.CallMethod::DoMethodCall(this);\n\tv50 = ~this.everyFrame;\n\tif (v50) goto L_002E;\n\treturn;\nL_002E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 34 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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

		[Token(Token = "0x600104A")]
		[Address(RVA = "0xA8CE08", Offset = "0xA8CE08", Length = "0x4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.Actions.CallMethod::DoMethodCall(this);\n\treturn;\n")]
		public override void OnUpdate()
		{
			DoMethodCall();
		}

		[Token(Token = "0x600104B")]
		[Address(RVA = "0xA8CABC", Offset = "0xA8CABC", Length = "0x34C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv28 = *([1EE65B0]);\n\tv29 = *([v28 @ X8_v44]);\n\tv30 = \"il2cpp_codegen_initialize_method\"(v29, methodInfo, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\n\tv48 = 0 | 1;\n\t*([20221D2]) = v48;\nL_001C:\n\tv52 = HutongGames.PlayMaker.FsmObject::get_Value(this.behaviour);\n\tgoto L_002E;\n\tv242 = *([v194 @ X8_v8+E0]);\n\tv243 = v242 == 0;\n\tv244 = ~v243;\n\tif (v244) goto L_002E;\n\tv250 = v194;\n\tv246 = \"il2cpp_codegen_runtime_class_init\"(v250, v51, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_002E:\n\tv249 = UnityEngine.Object::op_Equality(v52, 0);\n\tv252 = v249 == 0;\n\tif (v252) goto L_0041;\nL_003E:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\treturn;\nL_0041:\n\tv299 = HutongGames.PlayMaker.Actions.CallMethod::NeedToUpdateCache(this);\n\tv301 = v299 == 0;\n\tif (v301) goto L_004A;\n\tv363 = HutongGames.PlayMaker.Actions.CallMethod::DoCache(this);\n\tv366 = v363 == 0;\n\tif (v366) goto L_0152;\nL_004A:\n\tv367 = this.cachedParameterInfo;\n\tv370 = v367.Length == 0;\n\tif (v370) goto L_0115;\n\tv512 = this.parameters;\nL_0060:\n\tv375 = v125 >= v512.Length;\n\tif (v375) goto L_010A;\n\tv187 = v512[v125 @ X23_v10 (System.Int32)];\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(v512[v125 @ X23_v10 (System.Int32)]);\n\tHutongGames.PlayMaker.FsmVar::UpdateValue(v512[v125 @ X23_v10 (System.Int32)]);\n\tv60 = v187.type != 0xD;\n\tif (v60) goto L_00FB;\n\tv563 = HutongGames.PlayMaker.FsmVar::GetValue(v512[v125 @ X23_v10 (System.Int32)]);\n\t// 136 IsInst v460 @ X0_v44, typeof(System.Object[]), v563 @ X0_v43 (System.Object)\n\tv481 = this.cachedParameterInfo;\n\tv167 = System.Reflection.ParameterInfo::get_ParameterType(v481[v125 @ X23_v10 (System.Int32)]);\n\tv461 = System.Type::GetElementType(v167);\n\tv579 = System.Array::CreateInstance(v461, *([v460 @ X0_v44+18]));\n\tv591 = *([v460 @ X0_v44+18]) < 1;\n\tif (v591) goto L_00DC;\nL_00C7:\n\tv595 = v440 << 3;\n\tv619 = v460 + v595;\n\tSystem.Array::SetValue(v579, *([v619 @ X8_v34+20]), v440);\n\tv440 = v440 + 1;\n\tv594 = v440 < *([v460 @ X0_v44+18]);\n\tif (v594) goto L_00C7;\nL_00DC:\n\tv224 = this.parametersArray;\nL_00DF:\n\tv570 = v240 == 0;\n\tif (v570) goto L_00F4;\n\t// 228 IsInst v234 @ X0_v41, typeof(System.Object), v240 @ X20_v18 (System.Object)\n\tv236 = v234 == 0;\n\tif (v236) goto L_0161;\nL_00F4:\n\tv224[v125 @ X23_v10 (System.Int32)] = v240;\n\tv512 = this.parameters;\n\tv125 = v125 + 1;\n\tv576 = this.parameters == 0;\n\tv475 = ~v576;\n\tif (v475) goto L_0060;\n\tgoto L_0104;\nL_00FB:\n\tv224 = this.parametersArray;\n\tv458 = HutongGames.PlayMaker.FsmVar::GetValue(v512[v125 @ X23_v10 (System.Int32)]);\n\tv565 = this.parametersArray == 0;\n\tv468 = ~v565;\n\tif (v468) goto L_00DF;\nL_0104:\n\tthrow System.NullReferenceException;\nL_010A:\n\tv465 = HutongGames.PlayMaker.FsmObject::get_Value(this.cachedBehaviour);\n\tv148 = this.parametersArray;\n\tgoto L_011C;\nL_0115:\n\tv466 = HutongGames.PlayMaker.FsmObject::get_Value(this.cachedBehaviour);\nL_011C:\n\tv548 = System.Reflection.MethodBase::Invoke(v546, v542, v148);\n\tv551 = this.storeResult == 0;\n\tif (v551) goto L_014A;\n\tv556 = HutongGames.PlayMaker.FsmVar::get_IsNone(this.storeResult);\n\tv560 = v556 == 0;\n\tv557 = ~v560;\n\tif (v557) goto L_014A;\n\tv170 = this.storeResult;\n\tv348 = v170.type + 1;\n\tv312 = v348 == 0;\n\tif (v312) goto L_014A;\n\tHutongGames.PlayMaker.FsmVar::SetValue(v170, v548);\n\treturn;\nL_014A:\n\treturn;\nL_0152:\n\tgoto L_015A;\n\tv514 = *([v495 @ X0_v54+E0]);\n\tv515 = v514 == 0;\n\tv516 = ~v515;\n\tif (v516) goto L_015A;\n\tv518 = \"il2cpp_codegen_runtime_class_init\"(v495, v162, v147, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45);\nL_015A:\n\tUnityEngine.Debug::LogError(this.errorString);\n\tgoto L_003E;\n\tv273 = new System.IndexOutOfRangeException();\nL_015F:\n\tv165 = new System.TypeLoadException();\n\tv191 = new System.NullReferenceException();\nL_0161:\n\tv241 = new System.ArrayTypeMismatchException();\n\tgoto L_015F;\n\treturn;\n// 255 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void DoMethodCall()
		{
			//IL_0214: Expected O, but got I
			//IL_022d: Expected O, but got I
			UnityEngine.Object value = behaviour.Value;
			if (!(value == null))
			{
				if (!NeedToUpdateCache() || DoCache())
				{
					ParameterInfo[] array = cachedParameterInfo;
					object[] array6;
					UnityEngine.Object obj5;
					MethodBase methodBase;
					if (array.Length != 0)
					{
						FsmVar[] array2 = parameters;
						int num = 0;
						while (num < array2.Length)
						{
							FsmVar fsmVar = array2[num];
							array2[num].UpdateValue();
							array2[num].UpdateValue();
							object[] array5;
							object obj3;
							if (fsmVar.Type == VariableType.Array)
							{
								object value2 = array2[num].GetValue();
								object obj = value2 as object[];
								ParameterInfo[] array3 = cachedParameterInfo;
								Type parameterType = array3[num].ParameterType;
								Type elementType = parameterType.GetElementType();
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ X0_v44+18]");
								Array array4 = Array.CreateInstance(elementType, 0);
								Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ X0_v44+18]");
								if (0L >= 1L)
								{
									int num2 = 0;
									int num4;
									do
									{
										int num3 = num2 << 3;
										object obj2 = (long)(IntPtr)obj + (long)num3;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v619 @ X8_v34+20]");
										array4.SetValue(0, num2);
										num2++;
										num4 = num2;
										Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v460 @ X0_v44+18]");
									}
									while ((long)num4 < 0L);
								}
								array5 = parametersArray;
								obj3 = array4;
							}
							else
							{
								array5 = parametersArray;
								object value3 = array2[num].GetValue();
								bool flag = parametersArray == null;
								bool flag2 = !flag;
								obj3 = value3;
								if (!flag2)
								{
									goto IL_0367;
								}
							}
							if (obj3 != null)
							{
								object obj4 = obj3 as object;
								if (obj4 == null)
								{
									while (true)
									{
										ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
										TypeLoadException ex2 = new TypeLoadException();
										NullReferenceException ex3 = new NullReferenceException();
									}
								}
							}
							array5[num] = obj3;
							array2 = parameters;
							num++;
							if (parameters != null)
							{
								continue;
							}
							goto IL_0367;
							IL_0367:
							throw new NullReferenceException();
						}
						UnityEngine.Object value4 = cachedBehaviour.Value;
						array6 = parametersArray;
						obj5 = value4;
						methodBase = cachedMethodInfo;
					}
					else
					{
						UnityEngine.Object value5 = cachedBehaviour.Value;
						array6 = null;
						obj5 = value5;
						methodBase = cachedMethodInfo;
					}
					object value6 = methodBase.Invoke(obj5, array6);
					if (storeResult != null && !storeResult.IsNone)
					{
						FsmVar fsmVar2 = storeResult;
						if (fsmVar2.Type + 1 != VariableType.Float)
						{
							fsmVar2.SetValue(value6);
						}
					}
					return;
				}
				Debug.LogError(errorString);
			}
			Finish();
		}

		[Token(Token = "0x600104C")]
		[Address(RVA = "0xA8CE0C", Offset = "0xA8CE0C", Length = "0x14C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv20 = *([1F0EF20]);\n\tv21 = *([v20 @ X8_v16]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20221D3]) = v40;\nL_0015:\n\tv42 = this.cachedBehaviour == 0;\n\tif (v42) goto L_0061;\n\tv44 = this.cachedMethodName == 0;\n\tif (v44) goto L_0061;\n\tv81 = HutongGames.PlayMaker.FsmObject::get_Value(this.cachedBehaviour);\n\tv116 = HutongGames.PlayMaker.FsmObject::get_Value(this.behaviour);\n\tgoto L_0034;\n\tv140 = *([v69 @ X8_v10+E0]);\n\tv141 = v140 == 0;\n\tv142 = ~v141;\n\tif (v142) goto L_0034;\n\tv147 = v69;\n\tv144 = \"il2cpp_codegen_runtime_class_init\"(v147, v115, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0034:\n\tv61 = UnityEngine.Object::op_Inequality(v81, v116);\n\tv149 = v61 == 0;\n\tv65 = ~v149;\n\tif (v65) goto L_0061;\n\tv70 = this.cachedBehaviour;\n\tv50 = this.behaviour;\n\tv62 = System.String::op_Inequality(v70.name, v50.name);\n\tv152 = v62 == 0;\n\tv66 = ~v152;\n\tif (v66) goto L_0061;\n\tv123 = HutongGames.PlayMaker.FsmString::get_Value(this.cachedMethodName);\n\tv155 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tv60 = System.String::op_Inequality(v123, v155);\n\tv64 = v60 == 0;\n\tif (v64) goto L_0062;\nL_0061:\n\treturn 1;\nL_0062:\n\tv105 = this.cachedMethodName;\n\tv88 = this.methodName;\n\treturnVal3 = System.String::op_Inequality(v105.name, v88.name);\n\treturn returnVal3;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 77 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool NeedToUpdateCache()
		{
			if (cachedBehaviour != null && cachedMethodName != null)
			{
				UnityEngine.Object value = cachedBehaviour.Value;
				UnityEngine.Object value2 = behaviour.Value;
				if (!(value != value2))
				{
					FsmObject fsmObject = cachedBehaviour;
					FsmObject fsmObject2 = behaviour;
					if (!(fsmObject.Name != fsmObject2.Name))
					{
						string value3 = cachedMethodName.Value;
						string value4 = methodName.Value;
						if (!(value3 != value4))
						{
							FsmString fsmString = cachedMethodName;
							FsmString fsmString2 = methodName;
							return fsmString.Name != fsmString2.Name;
						}
					}
				}
			}
			return true;
		}

		[Token(Token = "0x600104D")]
		[Address(RVA = "0xA8D244", Offset = "0xA8D244", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.cachedParameterInfo = 0;\n\tthis.cachedType = 0;\n\tthis.cachedBehaviour = 0;\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void ClearCache()
		{
			cachedParameterInfo = null;
			cachedType = null;
			cachedBehaviour = null;
		}

		[Token(Token = "0x600104E")]
		[Address(RVA = "0xA8CF58", Offset = "0xA8CF58", Length = "0x2EC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv24 = *([1F01898]);\n\tv25 = *([v24 @ X8_v40]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221D4]) = v44;\nL_0016:\n\tthis.cachedParameterInfo = 0;\n\tthis.cachedType = 0;\n\tthis.cachedBehaviour = 0;\n\tthis.errorString = v50.Empty;\n\tv55 = new HutongGames.PlayMaker.FsmObject();\n\tHutongGames.PlayMaker.FsmObject::.ctor(v55, this.behaviour);\n\tthis.cachedBehaviour = v55;\n\tv63 = new HutongGames.PlayMaker.FsmString();\n\tHutongGames.PlayMaker.FsmString::.ctor(v63, this.methodName);\n\tthis.cachedMethodName = v63;\n\tv70 = HutongGames.PlayMaker.FsmObject::get_Value(this.cachedBehaviour);\n\tgoto L_004A;\n\tv208 = *([v178 @ X8_v16+E0]);\n\tv209 = v208 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_004A;\n\tv220 = v178;\n\tv212 = \"il2cpp_codegen_runtime_class_init\"(v220, v69, v65, v29, v30, v31, v32, v33, v47, v35, v36, v37, v38, v39, v40, v41);\nL_004A:\n\tv216 = UnityEngine.Object::op_Equality(v70, 0);\n\tv223 = v216 == 0;\n\tif (v223) goto L_0065;\n\tv297 = HutongGames.PlayMaker.NamedVariable::get_UsesVariable(this.behaviour);\n\tv300 = v297 == 0;\n\tif (v300) goto L_0061;\n\tv302 = UnityEngine.Application::get_isPlaying();\n\tv305 = v302 == 0;\n\tif (v305) goto L_00DF;\nL_0061:\n\tv350 = System.String::Concat(this.errorString, \"Behaviour is invalid!\\n\");\n\tgoto L_00DC;\nL_0065:\n\tv153 = HutongGames.PlayMaker.FsmObject::get_Value(this.behaviour);\n\tv232 = System.Object::GetType(v153);\n\tv243 = this.parameters;\n\tthis.cachedType = v232;\n\tv233 = new System.Collections.Generic.List`1<System.Type>();\n\tSystem.Collections.Generic.List`1<System.Type>::.ctor(v233, v243.Length);\n\tv137 = this.parameters;\n\tv205 = v137.Length;\n\tv391 = v137.Length < 1;\n\tif (v391) goto L_00B5;\nL_008B:\n\tv417 = v80 < v205;\n\tv130 = ~v417;\n\tif (v130) goto L_00F7;\n\tv234 = HutongGames.PlayMaker.FsmVar::get_RealType(v137[v80 @ X22_v11 (System.Int32)]);\n\tSystem.Collections.Generic.List`1<System.Type>::Add(v233, v234);\n\tv205 = v137.Length;\n\tv80 = v80 + 1;\n\tv395 = v80 < v137.Length;\n\tif (v395) goto L_008B;\nL_00B5:\n\tv235 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tv236 = System.Collections.Generic.List`1<System.Type>::ToArray(v233);\n\tv423 = System.Type::GetMethod(this.cachedType, v235, v236);\n\tthis.cachedMethodInfo = v423;\n\tv426 = System.Reflection.MethodInfo::op_Equality(v423, 0);\n\tv428 = v426 == 0;\n\tif (v428) goto L_00E8;\n\tv430 = HutongGames.PlayMaker.FsmString::get_Value(this.methodName);\n\tv350 = System.String::Concat(this.errorString, \"Invalid Method Name or Parameters: \", v430, \"\\n\");\nL_00DC:\n\tthis.errorString = v350;\nL_00DF:\n\tHutongGames.PlayMaker.FsmStateAction::Finish(this);\n\tgoto L_00F3;\nL_00E8:\n\tv431 = System.Reflection.MethodBase::GetParameters(this.cachedMethodInfo);\n\tthis.cachedParameterInfo = v431;\nL_00F3:\n\treturn returnVal2;\n\tv152 = new System.NullReferenceException();\n\tv175 = new System.NullReferenceException();\nL_00F7:\n\tv207 = new System.IndexOutOfRangeException();\n\tthrow v207;\n\treturn returnVal1;\n// 178 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool DoCache()
		{
			cachedParameterInfo = null;
			cachedType = null;
			cachedBehaviour = null;
			errorString = string.Empty;
			FsmObject fsmObject = new FsmObject(behaviour);
			cachedBehaviour = fsmObject;
			FsmString fsmString = new FsmString(methodName);
			cachedMethodName = fsmString;
			UnityEngine.Object value = cachedBehaviour.Value;
			string text;
			if (value == null)
			{
				if (behaviour.UsesVariable && !Application.isPlaying)
				{
					goto IL_02f0;
				}
				text = errorString + "Behaviour is invalid!\n";
			}
			else
			{
				UnityEngine.Object value2 = behaviour.Value;
				Type type = value2.GetType();
				FsmVar[] array = parameters;
				cachedType = type;
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
				string value3 = methodName.Value;
				Type[] types = list.ToArray();
				if (!((cachedMethodInfo = cachedType.GetMethod(value3, types)) == null))
				{
					ParameterInfo[] array3 = cachedMethodInfo.GetParameters();
					cachedParameterInfo = array3;
					return true;
				}
				string value4 = methodName.Value;
				text = errorString + "Invalid Method Name or Parameters: " + value4 + "\n";
			}
			errorString = text;
			goto IL_02f0;
			IL_02f0:
			Finish();
			return false;
		}

		[Token(Token = "0x600104F")]
		[Address(RVA = "0xA8D258", Offset = "0xA8D258", Length = "0x500")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv24 = *([1EC4AB0]);\n\tv25 = *([v24 @ X8_v86]);\n\tv26 = \"il2cpp_codegen_initialize_method\"(v25, methodInfo, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20221D5]) = v44;\nL_0017:\n\tv46 = UnityEngine.Application::get_isPlaying();\n\tv48 = v46 == 0;\n\tv49 = ~v48;\n\tif (v49) goto L_00DD;\n\tv51 = HutongGames.PlayMaker.Actions.CallMethod::DoCache(this);\n\tv54 = v51 == 0;\n\tif (v54) goto L_00DD;\n\tv146 = this.parameters;\n\tv196 = this.cachedParameterInfo;\n\tv234 = v146.Length != v196.Length;\n\tif (v234) goto L_00EB;\n\tv421 = v146.Length < 1;\n\tif (v421) goto L_008F;\nL_0041:\n\tv301 = v228 - 1;\n\tv305 = HutongGames.PlayMaker.FsmVar::get_RealType(v146[v301 @ X10_v13 (System.Int32)]);\n\tv323 = this.cachedParameterInfo;\n\tv306 = System.Reflection.ParameterInfo::get_ParameterType(v323[v301 @ X10_v13 (System.Int32)]);\n\tv233 = v305 != v306;\n\tif (v233) goto L_0176;\n\tv146 = this.parameters;\n\tv228 = v228 + 1;\n\tv561 = v228 < v146.Length;\n\tif (v561) goto L_0041;\nL_008F:\n\tv591 = System.Reflection.MethodInfo::get_ReturnType(this.cachedMethodInfo);\n\tgoto L_00A3;\n\tv687 = *([v405 @ X8_v39+E0]);\n\tv688 = v687 == 0;\n\tv689 = ~v688;\n\tif (v689) goto L_00A3;\n\tv696 = v405;\n\tv691 = \"il2cpp_codegen_runtime_class_init\"(v696, v590, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\nL_00A3:\n\tv310 = System.Type::GetTypeFromHandle(System.Void);\n\tv268 = v591 == v310;\n\tif (v268) goto L_0208;\n\tv307 = System.Reflection.MethodInfo::get_ReturnType(this.cachedMethodInfo);\n\tv711 = HutongGames.PlayMaker.FsmVar::get_RealType(this.storeResult);\n\tv174 = v307 == v711;\n\tif (v174) goto L_FFFFFFFF;\n\tv754 = System.Reflection.MethodInfo::get_ReturnType(this.cachedMethodInfo);\n\treturnVal2 = System.String::Concat(\"Store Result is of the wrong type.\\nIt should be of type: \", v754);\n\treturn returnVal2;\nL_00DD:\n\treturnVal1 = this.errorString;\nL_00E6:\n\treturn returnVal1;\nL_00EB:\n\t// 235 NewArr v799 @ X0_v17 (System.Object[]), typeof(System.Object[]), 5\n\tv600 = \"Parameter count does not match method.\\nMethod has \" == 0;\n\tif (v600) goto L_00FD;\n\t// 246 IsInst v519 @ X0_v42, typeof(System.Object), \"Parameter count does not match method.\nMethod has \"\n\tv531 = v519 == 0;\n\tif (v531) goto L_0220;\nL_00FD:\n\tv799[0] = \"Parameter count does not match method.\\nMethod has \";\n\tv326 = this.cachedParameterInfo;\n\tv146 = v326.Length;\n\t// 263 Box v703 @ X0_v26, typeof(System.Int32), &v146 @ X8_v4 (HutongGames.PlayMaker.FsmVar[])\n\tv709 = v703 == 0;\n\tif (v709) goto L_011E;\n\t// 270 IsInst v520 @ X0_v41, typeof(System.Object), v703 @ X0_v26\n\tv532 = v520 == 0;\n\tif (v532) goto L_0220;\nL_011E:\n\tv799[1] = v703;\n\tv743 = \" parameters.\\nYou specified \" == 0;\n\tif (v743) goto L_0137;\n\t// 294 IsInst v521 @ X0_v39, typeof(System.Object), \" parameters.\nYou specified \"\n\tv533 = v521 == 0;\n\tif (v533) goto L_0220;\nL_0137:\n\tv799[2] = \" parameters.\\nYou specified \";\n\tv146 = this.parameters;\n\tv146 = v146.Length;\n\t// 319 Box v765 @ X0_v31, typeof(System.Int32), &v146 @ X8_v4 (HutongGames.PlayMaker.FsmVar[])\n\tv768 = v765 == 0;\n\tif (v768) goto L_0156;\n\t// 326 IsInst v522 @ X0_v38, typeof(System.Object), v765 @ X0_v31\n\tv534 = v522 == 0;\n\tif (v534) goto L_0220;\nL_0156:\n\tv799[3] = v765;\n\tv782 = \" paramaters.\" == 0;\n\tif (v782) goto L_0170;\n\t// 350 IsInst v523 @ X0_v36, typeof(System.Object), \" paramaters.\"\n\tv535 = v523 == 0;\n\tif (v535) goto L_0220;\nL_0170:\n\tv799[4] = \" paramaters.\";\n\tgoto L_0206;\nL_0176:\n\t// 374 NewArr v799 @ X0_v17 (System.Object[]), typeof(System.Object[]), 6\n\tv761 = \"Parameters do not match method signature.\\nParameter \" == 0;\n\tif (v761) goto L_0189;\n\t// 385 IsInst v524 @ X0_v91, typeof(System.Object), \"Parameters do not match method signature.\nParameter \"\n\tv536 = v524 == 0;\n\tif (v536) goto L_0220;\nL_0189:\n\tv799[0] = \"Parameters do not match method signature.\\nParameter \";\n\t// 398 Box v774 @ X0_v74, typeof(System.Int32), &v228 @ X22_v14 (System.Int32)\n\tv779 = v774 == 0;\n\tif (v779) goto L_01A5;\n\t// 405 IsInst v525 @ X0_v90, typeof(System.Object), v774 @ X0_v74\n\tv537 = v525 == 0;\n\tif (v537) goto L_0220;\nL_01A5:\n\tv799[1] = v774;\n\tv792 = \" (\" == 0;\n\tif (v792) goto L_01BE;\n\t// 429 IsInst v526 @ X0_v88, typeof(System.Object), \" (\"\n\tv538 = v526 == 0;\n\tif (v538) goto L_0220;\nL_01BE:\n\tv799[2] = \" (\";\n\tv801 = v305 == 0;\n\tif (v801) goto L_01D4;\n\t// 452 IsInst v527 @ X0_v87, typeof(System.Object), v305 @ X0_v66 (System.Type)\n\tv539 = v527 == 0;\n\tif (v539) goto L_0220;\nL_01D4:\n\tv799[3] = v305;\n\tv808 = \") should be of type: \" == 0;\n\tif (v808) goto L_01ED;\n\t// 476 IsInst v528 @ X0_v85, typeof(System.Object), \") should be of type: \"\n\tv540 = v528 == 0;\n\tif (v540) goto L_0220;\nL_01ED:\n\tv799[4] = \") should be of type: \";\n\tv812 = v306 == 0;\n\tif (v812) goto L_0203;\n\t// 499 IsInst v529 @ X0_v84, typeof(System.Object), v306 @ X0_v68 (System.Type)\n\tv541 = v529 == 0;\n\tif (v541) goto L_0220;\nL_0203:\n\tv799[5] = v306;\nL_0206:\n\treturnVal1 = System.String::Concat(v799);\n\tgoto L_00E6;\nL_0208:\n\tv328 = this.storeResult;\n\tv708 = System.String::IsNullOrEmpty(v328.variableName);\n\tv713 = v708 == 0;\n\tif (v713) goto L_FFFFFFFF;\n\tgoto L_0218;\nL_0218:\n\treturnVal1 = *([v146 @ X8_v4 (HutongGames.PlayMaker.FsmVar[])]);\n\tgoto L_00E6;\n\tv623 = new System.IndexOutOfRangeException();\nL_021D:\n\tthrow System.TypeLoadException;\n\tv410 = new System.NullReferenceException();\nL_0220:\n\tv558 = new System.ArrayTypeMismatchException();\n\tgoto L_021D;\n\treturn X0;\n// 407 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public override string ErrorCheck()
		{
			//IL_0269: Expected O, but got I4
			//IL_0272: Expected I4, but got O
			//IL_0344: Expected O, but got I4
			//IL_034d: Expected I4, but got O
			FsmVar[] array;
			if (!Application.isPlaying && DoCache())
			{
				array = parameters;
				ParameterInfo[] array2 = cachedParameterInfo;
				object[] array4;
				if (array.Length == array2.Length)
				{
					if (array.Length < 1)
					{
						goto IL_012f;
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
						goto IL_012f;
					}
					array4 = new object[6];
					if ("Parameters do not match method signature.\nParameter " != null)
					{
						object obj = "Parameters do not match method signature.\nParameter " as object;
						if (obj == null)
						{
							goto IL_06af;
						}
					}
					array4[0] = "Parameters do not match method signature.\nParameter ";
					object obj2 = num;
					if (obj2 != null)
					{
						object obj3 = obj2 as object;
						if (obj3 == null)
						{
							goto IL_06af;
						}
					}
					array4[1] = obj2;
					if (" (" != null)
					{
						object obj4 = " (" as object;
						if (obj4 == null)
						{
							goto IL_06af;
						}
					}
					array4[2] = " (";
					if ((object)realType != null)
					{
						object obj5 = realType as object;
						if (obj5 == null)
						{
							goto IL_06af;
						}
					}
					array4[3] = realType;
					if (") should be of type: " != null)
					{
						object obj6 = ") should be of type: " as object;
						if (obj6 == null)
						{
							goto IL_06af;
						}
					}
					array4[4] = ") should be of type: ";
					if ((object)parameterType != null)
					{
						object obj7 = parameterType as object;
						if (obj7 == null)
						{
							goto IL_06af;
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
							goto IL_06af;
						}
					}
					array4[0] = "Parameter count does not match method.\nMethod has ";
					ParameterInfo[] array5 = cachedParameterInfo;
					array = (FsmVar[])array5.Length;
					object obj9 = (int)array;
					if (obj9 != null)
					{
						object obj10 = obj9 as object;
						if (obj10 == null)
						{
							goto IL_06af;
						}
					}
					array4[1] = obj9;
					if (" parameters.\nYou specified " != null)
					{
						object obj11 = " parameters.\nYou specified " as object;
						if (obj11 == null)
						{
							goto IL_06af;
						}
					}
					array4[2] = " parameters.\nYou specified ";
					array = parameters;
					array = (FsmVar[])array.Length;
					object obj12 = (int)array;
					if (obj12 != null)
					{
						object obj13 = obj12 as object;
						if (obj13 == null)
						{
							goto IL_06af;
						}
					}
					array4[3] = obj12;
					if (" paramaters." != null)
					{
						object obj14 = " paramaters." as object;
						if (obj14 == null)
						{
							goto IL_06af;
						}
					}
					array4[4] = " paramaters.";
				}
				return string.Concat(array4);
			}
			return errorString;
			IL_0718:
			return (string)(object)array;
			IL_012f:
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
					array = (FsmVar[])(object)"Method does not have return.\nSpecify 'none' in Store Result.";
					goto IL_0718;
				}
			}
			array = (FsmVar[])(object)string.Empty;
			goto IL_0718;
			IL_06af:
			ArrayTypeMismatchException ex = new ArrayTypeMismatchException();
			throw new TypeLoadException();
		}

		[Token(Token = "0x6001050")]
		[Address(RVA = "0xA8D758", Offset = "0xA8D758", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tHutongGames.PlayMaker.FsmStateAction::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CallMethod()
		{
		}
	}
}
