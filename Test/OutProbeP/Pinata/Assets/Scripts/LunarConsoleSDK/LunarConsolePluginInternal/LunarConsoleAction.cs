using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePlugin;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x2000024")]
	public class LunarConsoleAction : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000074")]
		[FieldOffset(Offset = "0x18")]
		private string m_title;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x4000075")]
		[FieldOffset(Offset = "0x20")]
		private List<LunarConsoleActionCall> m_calls;

		[Token(Token = "0x1700002A")]
		public List<LunarConsoleActionCall> calls
		{
			[Token(Token = "0x60000E1")]
			[Address(RVA = "0x13E13D4", Offset = "0x13E13D4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_calls;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return calls;
			}
		}

		[Token(Token = "0x1700002B")]
		private bool actionsEnabled
		{
			[Token(Token = "0x60000E6")]
			[Address(RVA = "0x13E0988", Offset = "0x13E0988", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED7F80]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AD2]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.LunarConsoleConfig>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = LunarConsolePluginInternal.LunarConsoleConfig::get_actionsEnabled();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LunarConsoleConfig.actionsEnabled;
			}
		}

		[Token(Token = "0x60000DC")]
		[Address(RVA = "0x13E090C", Offset = "0x13E090C", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EC4A60]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028ACA]) = v38;\nL_0013:\n\tv39 = LunarConsolePluginInternal.LunarConsoleAction::get_actionsEnabled(v36);\n\tv41 = v39 == 0;\n\tif (v41) goto L_0023;\n\treturn;\nL_0023:\n\tgoto L_0030;\n\tv68 = *([v48 @ X0_v3+E0]);\n\tv69 = v68 == 0;\n\tv70 = ~v69;\n\tif (v70) goto L_0030;\n\tv72 = \"il2cpp_codegen_runtime_class_init\"(v48, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0030:\n\tUnityEngine.Object::Destroy(v36);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (!actionsEnabled)
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		[Token(Token = "0x60000DD")]
		[Address(RVA = "0x13E09E4", Offset = "0x13E09E4", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F10D58]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028ACB]) = v38;\nL_0013:\n\tv39 = LunarConsolePluginInternal.LunarConsoleAction::get_actionsEnabled(v36);\n\tv41 = v39 == 0;\n\tif (v41) goto L_0025;\n\tLunarConsolePluginInternal.LunarConsoleAction::RegisterAction(v36);\n\treturn;\nL_0025:\n\tgoto L_0032;\n\tv53 = *([v49 @ X0_v3+E0]);\n\tv54 = v53 == 0;\n\tv55 = ~v54;\n\tif (v55) goto L_0032;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v49, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0032:\n\tUnityEngine.Object::Destroy(v36);\n\treturn;\n// 33 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Start()
		{
			if (actionsEnabled)
			{
				RegisterAction();
			}
			else
			{
				UnityEngine.Object.Destroy(this);
			}
		}

		[Token(Token = "0x60000DE")]
		[Address(RVA = "0x13E0AE4", Offset = "0x13E0AE4", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EF7BF0]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028ACC]) = v38;\nL_0015:\n\tv41 = 0;\n\tv42 = this.m_calls;\n\tv43 = this.m_calls == 0;\n\tif (v43) goto L_003D;\n\tv55 = v42._size < 1;\n\tif (v55) goto L_005A;\n\tv61 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>::GetEnumerator(this.m_calls);\nL_002F:\n\tv133 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>));\n\tv88 = v133 == 0;\n\tif (v88) goto L_003B;\n\tLunarConsolePluginInternal.LunarConsoleAction::Validate(this, 0);\n\tgoto L_002F;\nL_003B:\n\tv85 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>));\n\tgoto L_005A;\nL_003D:\n\tv56 = new System.NullReferenceException();\n\tgoto L_0048;\nL_0048:\n\tv66 = methodInfo != 1;\n\tif (v66) goto L_005B;\n\tv134 = 0x6D2BC0(v56, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv137 = 0x6D2490(v134, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv84 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>));\n\tv145 = *([v134 @ X0_v9]) == 0;\n\tv87 = ~v145;\n\tif (v87) goto L_005F;\nL_005A:\n\treturn;\nL_005B:\n\tv135 = 0x6D2380(v56, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005F:\n\tthrow System.TypeLoadException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnValidate()
		{
			List<LunarConsoleActionCall>.Enumerator enumerator = default(List<LunarConsoleActionCall>.Enumerator);
			List<LunarConsoleActionCall> list = calls;
			if (calls != null)
			{
				if (list.Count >= 1)
				{
					List<LunarConsoleActionCall>.Enumerator enumerator2 = calls.GetEnumerator();
					while (enumerator.MoveNext())
					{
						Validate(null);
					}
					enumerator.Dispose();
				}
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			IntPtr intPtr = default(IntPtr);
			if (intPtr == (IntPtr)1)
			{
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_begin_catch", "Method not found @6D2BC0 (native __cxa_begin_catch)");
				Il2CppRuntime.Boundary("SYSTEM_API:__cxa_end_catch", "Method not found @6D2490 (native __cxa_end_catch)");
				enumerator.Dispose();
				object obj = default(object);
				if (obj == null)
				{
					return;
				}
			}
			else
			{
				Il2CppRuntime.Boundary("SYSTEM_API:_Unwind_Resume", "Method not found @6D2380 (native _Unwind_Resume)");
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000DF")]
		[Address(RVA = "0x13E0BE4", Offset = "0x13E0BE4", Length = "0x2C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\n\tv26 = *([1EB2160]);\n\tv27 = *([v26 @ X8_v45]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, call, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2028ACD]) = v45;\nL_0020:\n\tgoto L_0029;\n\tv55 = *([v50 @ X0_v9+E0]);\n\tv56 = v55 == 0;\n\tv57 = ~v56;\n\tif (v57) goto L_0029;\n\tv59 = \"il2cpp_codegen_runtime_class_init\"(v50, call, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0029:\n\tv65 = UnityEngine.Object::op_Equality(call.m_target, 0);\n\tv126 = v65 == 0;\n\tif (v126) goto L_0047;\n\tv107 = UnityEngine.Component::get_gameObject(this);\n\tv242 = UnityEngine.Object::get_name(v107);\n\tv324 = System.String::Format(\"Action '{0}' ({1}) is missing a target object\", this.m_title, v242);\n\tgoto L_00E5;\nL_0047:\n\tgoto L_0050;\n\tv231 = *([v191 @ X0_v20+E0]);\n\tv232 = v231 == 0;\n\tv233 = ~v232;\n\tif (v233) goto L_0050;\n\tv235 = \"il2cpp_codegen_runtime_class_init\"(v191, v63, v64, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0050:\n\tv240 = LunarConsolePluginInternal.LunarConsoleActionCall::IsPersistantListenerValid(call.m_target, call.m_methodName, call.m_mode);\n\tv244 = v240 == 0;\n\tif (v244) goto L_0061;\n\treturn;\nL_0061:\n\t// 97 NewArr v108 @ X0_v25 (System.Object[]), typeof(System.Object[]), 5\n\tv336 = this.m_title == 0;\n\tif (v336) goto L_006F;\n\t// 107 IsInst v166 @ X0_v51, typeof(System.Object), this.m_title (System.String)\nL_006F:\n\tv348 = v108.Length == 0;\n\tif (v348) goto L_0101;\n\tv108[0] = this.m_title;\n\tv109 = UnityEngine.Component::get_gameObject(this);\n\tv371 = UnityEngine.Object::get_name(v109);\n\tv372 = v371 == 0;\n\tif (v372) goto L_0083;\n\t// 127 IsInst v167 @ X0_v49, typeof(System.Object), v371 @ X0_v31 (System.String)\nL_0083:\n\tv375 = v108.Length < 1;\n\tv92 = ~v375;\n\tv89 = v108.Length - 1;\n\tv83 = v89 == 0;\n\tv376 = ~v92;\n\tv68 = v376 | v83;\n\tif (v68) goto L_0101;\n\tv108[1] = v371;\n\tv378 = System.Object::GetType(call.m_target);\n\tv379 = v378 == 0;\n\tif (v379) goto L_009E;\n\t// 155 IsInst v168 @ X0_v47, typeof(System.Object), v378 @ X0_v34 (System.Type)\nL_009E:\n\tv368 = v108.Length;\n\tv382 = v108.Length < 2;\n\tv152 = ~v382;\n\tv149 = v108.Length - 2;\n\tv143 = v149 == 0;\n\tv383 = ~v152;\n\tv128 = v383 | v143;\n\tif (v128) goto L_0101;\n\tv108[2] = v378;\n\tv384 = call.m_methodName == 0;\n\tif (v384) goto L_00B6;\n\t// 178 IsInst v169 @ X0_v45, typeof(System.Object), call.m_methodName (System.String)\n\tv368 = v108.Length;\nL_00B6:\n\tv387 = v368 < 3;\n\tv153 = ~v387;\n\tv150 = v368 - 3;\n\tv144 = v150 == 0;\n\tv388 = ~v153;\n\tv129 = v388 | v144;\n\tif (v129) goto L_0101;\n\tv108[3] = call.m_methodName;\n\tv390 = LunarConsolePluginInternal.LunarConsoleAction::ModeParamTypeName(call.m_mode);\n\tv391 = v390 == 0;\n\tif (v391) goto L_00CF;\n\t// 203 IsInst v170 @ X0_v43, typeof(System.Object), v390 @ X0_v38 (System.String)\nL_00CF:\n\tv394 = v108.Length < 4;\n\tv317 = ~v394;\n\tv316 = v108.Length - 4;\n\tv314 = v316 == 0;\n\tv395 = ~v317;\n\tv309 = v395 | v314;\n\tif (v309) goto L_0101;\n\tv108[4] = v390;\n\tv324 = System.String::Format(\"Action '{0}' ({1}) is missing a handler <{2}.{3} ({4})>\", v108);\nL_00E5:\n\tv335 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00FF;\n\tv349 = *([v292 @ X8_v13+E0]);\n\tv350 = v349 == 0;\n\tv351 = ~v350;\n\tif (v351) goto L_00FF;\n\tv369 = v292;\n\tv353 = \"il2cpp_codegen_runtime_class_init\"(v369, v334, v320, v276, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_00FF:\n\tUnityEngine.Debug::LogWarning(v324, v335);\n\treturn;\nL_0101:\n\tv220 = new System.IndexOutOfRangeException();\n\tgoto L_0108;\n\tv124 = new System.NullReferenceException();\n\tv186 = new System.ArrayTypeMismatchException();\nL_0108:\n\tthrow v219;\n// 164 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Validate(LunarConsoleActionCall call)
		{
			//IL_01af: Expected O, but got I4
			//IL_0248: Expected O, but got I4
			//IL_0274: Expected O, but got I4
			//IL_043f: Expected O, but got I
			//IL_02fe: Expected O, but got I4
			//IL_0388: Expected O, but got I4
			string message;
			if (call.target == null)
			{
				GameObject gameObject = base.gameObject;
				string arg = gameObject.name;
				message = $"Action '{m_title}' ({arg}) is missing a target object";
				goto IL_03e6;
			}
			if (LunarConsoleActionCall.IsPersistantListenerValid(call.target, call.methodName, call.mode))
			{
				return;
			}
			object[] array = new object[5];
			if (m_title != null)
			{
				object obj = m_title as object;
			}
			if (array.Length != 0)
			{
				array[0] = m_title;
				GameObject gameObject2 = base.gameObject;
				string text = gameObject2.name;
				if (text != null)
				{
					object obj2 = text as object;
				}
				bool flag = array.Length < 1;
				bool flag2 = !flag;
				object obj3 = array.Length - 1;
				bool flag3 = obj3 == null;
				bool flag4 = !flag2;
				if (!(flag4 || flag3))
				{
					array[1] = text;
					Type type = call.target.GetType();
					if ((object)type != null)
					{
						object obj4 = type as object;
					}
					object obj5 = array.Length;
					bool flag5 = array.Length < 2;
					bool flag6 = !flag5;
					object obj6 = array.Length - 2;
					bool flag7 = obj6 == null;
					bool flag8 = !flag6;
					if (!(flag8 || flag7))
					{
						array[2] = type;
						if (call.methodName != null)
						{
							object obj7 = call.methodName as object;
							obj5 = array.Length;
						}
						bool flag9 = (long)(IntPtr)obj5 < 3L;
						bool flag10 = !flag9;
						object obj8 = (long)(IntPtr)obj5 - 3L;
						bool flag11 = obj8 == null;
						bool flag12 = !flag10;
						if (!(flag12 || flag11))
						{
							array[3] = call.methodName;
							string text2 = ModeParamTypeName(call.mode);
							if (text2 != null)
							{
								object obj9 = text2 as object;
							}
							bool flag13 = array.Length < 4;
							bool flag14 = !flag13;
							object obj10 = array.Length - 4;
							bool flag15 = obj10 == null;
							bool flag16 = !flag14;
							if (!(flag16 || flag15))
							{
								array[4] = text2;
								message = string.Format("Action '{0}' ({1}) is missing a handler <{2}.{3} ({4})>", array);
								goto IL_03e6;
							}
						}
					}
				}
			}
			IndexOutOfRangeException ex = new IndexOutOfRangeException();
			IndexOutOfRangeException ex2 = default(IndexOutOfRangeException);
			throw ex2;
			IL_03e6:
			GameObject context = base.gameObject;
			Debug.LogWarning(message, context);
		}

		[Token(Token = "0x60000E0")]
		[Address(RVA = "0x13E1330", Offset = "0x13E1330", Length = "0x34")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv10 = LunarConsolePluginInternal.LunarConsoleAction::get_actionsEnabled(this);\n\tv13 = v10 == 0;\n\tif (v13) goto L_0015;\n\tLunarConsolePluginInternal.LunarConsoleAction::UnregisterAction(this);\n\treturn;\nL_0015:\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void OnDestroy()
		{
			if (actionsEnabled)
			{
				UnregisterAction();
			}
		}

		[Token(Token = "0x60000E2")]
		[Address(RVA = "0x13E0A64", Offset = "0x13E0A64", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv20 = *([1EE3958]);\n\tv21 = *([v20 @ X8_v8]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([2028ACE]) = v40;\nL_0018:\n\tv45 = new System.Action();\n\tSystem.Action::.ctor(v45, this, Il2CppMethodInfo);\n\tLunarConsolePlugin.LunarConsole::RegisterAction(this.m_title, v45);\n\treturn;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void RegisterAction()
		{
			Action action = InvokeAction;
			LunarConsole.RegisterAction(m_title, action);
		}

		[Token(Token = "0x60000E3")]
		[Address(RVA = "0x13E1364", Offset = "0x13E1364", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EB8F20]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028ACF]) = v38;\nL_0016:\n\tv42 = new System.Action();\n\tSystem.Action::.ctor(v42, this, Il2CppMethodInfo);\n\tLunarConsolePlugin.LunarConsole::UnregisterAction(v42);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void UnregisterAction()
		{
			Action action = InvokeAction;
			LunarConsole.UnregisterAction(action);
		}

		[Token(Token = "0x60000E4")]
		[Address(RVA = "0x13E13DC", Offset = "0x13E13DC", Length = "0x194")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1F0C7A0]);\n\tv19 = *([v18 @ X8_v30]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AD0]) = v38;\nL_0015:\n\tv41 = 0;\n\tv42 = this.m_calls;\n\tv43 = this.m_calls == 0;\n\tif (v43) goto L_005B;\n\tv55 = v42._size < 1;\n\tif (v55) goto L_005B;\n\tv102 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>::GetEnumerator(this.m_calls);\nL_002F:\n\tv117 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>));\n\tv136 = v117 == 0;\n\tif (v136) goto L_003C;\n\tgoto L_003E;\n\tLunarConsolePluginInternal.LunarConsoleActionCall::Invoke(0);\n\tgoto L_002F;\nL_003C:\n\tv147 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>));\n\tgoto L_0083;\nL_003E:\n\tv184 = new System.NullReferenceException();\n\tgoto L_004A;\n\tgoto L_004A;\nL_004A:\n\tv59 = Il2CppMethodInfo != 1;\n\tif (v59) goto L_0089;\n\tv224 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::MoveNext(v184);\n\tv226 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::MoveNext(v224);\n\tv86 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>));\n\tv230 = ~v224.m_value;\n\tv88 = ~v230;\n\tif (v88) goto L_008D;\nL_005B:\n\t// 91 NewArr v97 @ X0_v8 (System.Object[]), typeof(System.Object[]), 1\n\tv108 = this.m_title == 0;\n\tif (v108) goto L_0069;\n\t// 101 IsInst v121 @ X0_v18, typeof(System.Object), this.m_title (System.String)\n\tv125 = v121 == 0;\n\tif (v125) goto L_0087;\nL_0069:\n\tv128 = v97.Length == 0;\n\tif (v128) goto L_0085;\n\tv97[0] = this.m_title;\n\tgoto L_007D;\n\tv149 = *([v139 @ X0_v13+E0]);\n\tv150 = v149 == 0;\n\tv151 = ~v150;\n\tif (v151) goto L_007D;\n\tv153 = \"il2cpp_codegen_runtime_class_init\"(v139, v122, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_007D:\n\tUnityEngine.Debug::LogWarningFormat(\"Action '{0}' has 0 calls\", v97);\nL_0083:\n\treturn;\n\tv109 = new System.NullReferenceException();\nL_0085:\n\tv134 = new System.IndexOutOfRangeException();\n\tgoto L_008D;\nL_0087:\n\tv148 = new System.ArrayTypeMismatchException();\n\tgoto L_008D;\nL_0089:\n\tv225 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleActionCall>+Enumerator<LunarConsolePluginInternal.LunarConsoleActionCall>::MoveNext(v184);\nL_008D:\n\tthrow System.TypeLoadException;\n// 87 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void InvokeAction()
		{
			List<LunarConsoleActionCall>.Enumerator enumerator = default(List<LunarConsoleActionCall>.Enumerator);
			List<LunarConsoleActionCall> list = calls;
			if (calls == null || list.Count < 1)
			{
				goto IL_00d6;
			}
			List<LunarConsoleActionCall>.Enumerator enumerator2 = calls.GetEnumerator();
			if (!enumerator.MoveNext())
			{
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((List<LunarConsoleActionCall>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((List<LunarConsoleActionCall>.Enumerator*)1) : ((List<LunarConsoleActionCall>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					goto IL_00d6;
				}
			}
			else
			{
				bool flag3 = ((List<LunarConsoleActionCall>.Enumerator*)ex)->MoveNext();
			}
			goto IL_020b;
			IL_00d6:
			object[] array = new object[1];
			if (m_title != null)
			{
				object obj = m_title as object;
				if (obj == null)
				{
					ArrayTypeMismatchException ex2 = new ArrayTypeMismatchException();
					goto IL_020b;
				}
			}
			if (array.Length != 0)
			{
				array[0] = m_title;
				Debug.LogWarningFormat("Action '{0}' has 0 calls", array);
				return;
			}
			IndexOutOfRangeException ex3 = new IndexOutOfRangeException();
			goto IL_020b;
			IL_020b:
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000E5")]
		[Address(RVA = "0x13E12CC", Offset = "0x13E12CC", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1F0A9D0]);\n\tv19 = *([v18 @ X8_v10]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AD1]) = v38;\nL_0013:\n\tv39 = mode < 5;\n\tv40 = ~v39;\n\tv41 = mode - 5;\n\tv43 = v41 == 0;\n\tv48 = ~v43;\n\tv49 = v40 & v48;\n\tif (v49) goto L_FFFFFFFF;\n\tv51 = 0x1E9D000 + 0xA70;\n\tv55 = *([v51 @ X8_v7 (System.Int32)+mode @ X0 (LunarConsolePluginInternal.LunarPersistentListenerMode)*8]);\n\tgoto L_002B;\nL_002B:\n\treturn *([v55 @ X8_v3 (System.String)]);\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static string ModeParamTypeName(LunarPersistentListenerMode mode)
		{
			//IL_0024: Expected O, but got I
			bool flag = mode < LunarPersistentListenerMode.Object;
			bool flag2 = !flag;
			int num = (int)(mode - 5);
			bool flag3 = num == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num2 = 32100352 + 2672;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v51 @ X8_v7 (System.Int32)+mode @ X0 (LunarConsolePluginInternal.LunarPersistentListenerMode)*8]");
				return (string)0;
			}
			return "???";
		}

		[Token(Token = "0x60000E7")]
		[Address(RVA = "0x13E1C18", Offset = "0x13E1C18", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv18 = *([1EEAC50]);\n\tv19 = *([v18 @ X8_v7]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AD3]) = v38;\nL_0018:\n\tthis.m_title = \"Untitled Action\";\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LunarConsoleAction()
		{
			m_title = "Untitled Action";
		}
	}
}
