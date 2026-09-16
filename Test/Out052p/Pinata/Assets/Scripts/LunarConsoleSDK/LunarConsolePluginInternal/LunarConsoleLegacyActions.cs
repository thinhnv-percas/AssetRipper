using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace LunarConsolePluginInternal
{
	[Obsolete]
	[Token(Token = "0x200001D")]
	public class LunarConsoleLegacyActions : MonoBehaviour
	{
		[SerializeField]
		[Token(Token = "0x4000059")]
		[FieldOffset(Offset = "0x18")]
		private bool m_dontDestroyOnLoad;

		[SerializeField]
		[HideInInspector]
		[Token(Token = "0x400005A")]
		[FieldOffset(Offset = "0x20")]
		private List<LunarConsoleLegacyAction> m_actions;

		[Token(Token = "0x1700001E")]
		public List<LunarConsoleLegacyAction> actions
		{
			[Token(Token = "0x60000BA")]
			[Address(RVA = "0x13E3978", Offset = "0x13E3978", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_actions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return actions;
			}
		}

		[Token(Token = "0x1700001F")]
		private bool actionsEnabled
		{
			[Token(Token = "0x60000BB")]
			[Address(RVA = "0x13E3680", Offset = "0x13E3680", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EE3940]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([2028AEC]) = v35;\nL_0017:\n\tgoto L_0021;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<LunarConsolePluginInternal.LunarConsoleConfig>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0021;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, methodInfo, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_0021:\n\treturnVal1 = LunarConsolePluginInternal.LunarConsoleConfig::get_actionsEnabled();\n\treturn returnVal1;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return LunarConsoleConfig.actionsEnabled;
			}
		}

		[Token(Token = "0x60000B6")]
		[Address(RVA = "0x13E35BC", Offset = "0x13E35BC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EAA400]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AE8]) = v38;\nL_0013:\n\tv39 = LunarConsolePluginInternal.LunarConsoleLegacyActions::get_actionsEnabled(v36);\n\tv41 = v39 == 0;\n\tv42 = ~v41;\n\tif (v42) goto L_0028;\n\tgoto L_0026;\n\tv59 = *([v45 @ X0_v11+E0]);\n\tv60 = v59 == 0;\n\tv61 = ~v60;\n\tif (v61) goto L_0026;\n\tv63 = \"il2cpp_codegen_runtime_class_init\"(v45, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0026:\n\tUnityEngine.Object::Destroy(v36);\nL_0028:\n\tv58 = ~v36.m_dontDestroyOnLoad;\n\tif (v58) goto L_0049;\n\tv66 = UnityEngine.Component::get_gameObject(v36);\n\tgoto L_0042;\n\tv96 = *([v74 @ X8_v7+E0]);\n\tv97 = v96 == 0;\n\tv98 = ~v97;\n\tif (v98) goto L_0042;\n\tv101 = v74;\n\tv100 = \"il2cpp_codegen_runtime_class_init\"(v101, v65, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_0042:\n\tUnityEngine.Object::DontDestroyOnLoad(v66);\n\treturn;\nL_0049:\n\treturn;\n// 44 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private void Awake()
		{
			if (!actionsEnabled)
			{
				UnityEngine.Object.Destroy(this);
			}
			if (m_dontDestroyOnLoad)
			{
				GameObject target = base.gameObject;
				UnityEngine.Object.DontDestroyOnLoad(target);
			}
		}

		[Token(Token = "0x60000B7")]
		[Address(RVA = "0x13E36DC", Offset = "0x13E36DC", Length = "0x130")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EA6A80]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AE9]) = v38;\nL_0015:\n\tv41 = 0;\n\tv42 = LunarConsolePluginInternal.LunarConsoleLegacyActions::get_actionsEnabled(v36);\n\tv44 = v42 == 0;\n\tif (v44) goto L_0055;\n\tv46 = v36.m_actions == 0;\n\tif (v46) goto L_0036;\n\tv94 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>::GetEnumerator(v36.m_actions);\nL_0026:\n\tv142 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>));\n\tv129 = v142 == 0;\n\tif (v129) goto L_0033;\n\tLunarConsolePluginInternal.LunarConsoleLegacyAction::Register(0);\n\tgoto L_0026;\nL_0033:\n\tv127 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>));\n\tgoto L_0063;\n\tv98 = new System.NullReferenceException();\nL_0036:\n\tv104 = new System.NullReferenceException();\n\tgoto L_0042;\n\tgoto L_0042;\nL_0042:\n\tv48 = Il2CppMethodInfo != 1;\n\tif (v48) goto L_0064;\n\tv169 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(v104);\n\tv173 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(v169);\n\tv77 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>));\n\tv179 = ~v169.m_value;\n\tv79 = ~v179;\n\tif (v79) goto L_0068;\nL_0055:\n\tgoto L_005D;\n\tv105 = *([v86 @ X0_v5+E0]);\n\tv106 = v105 == 0;\n\tv107 = ~v106;\n\tif (v107) goto L_005D;\n\tv109 = \"il2cpp_codegen_runtime_class_init\"(v86, v74, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\nL_005D:\n\tUnityEngine.Object::Destroy(v36);\nL_0063:\n\treturn;\nL_0064:\n\tv170 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(v104);\nL_0068:\n\tthrow System.TypeLoadException;\n// 64 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void Start()
		{
			List<LunarConsoleLegacyAction>.Enumerator enumerator = default(List<LunarConsoleLegacyAction>.Enumerator);
			if (actionsEnabled)
			{
				if (actions != null)
				{
					List<LunarConsoleLegacyAction>.Enumerator enumerator2 = actions.GetEnumerator();
					while (enumerator.MoveNext())
					{
						((LunarConsoleLegacyAction)null).Register();
					}
					enumerator.Dispose();
					return;
				}
				NullReferenceException ex = new NullReferenceException();
				if ((IntPtr)0 == (IntPtr)1)
				{
					bool flag = ((List<LunarConsoleLegacyAction>.Enumerator*)ex)->MoveNext();
					bool flag2 = (flag ? ((List<LunarConsoleLegacyAction>.Enumerator*)1) : ((List<LunarConsoleLegacyAction>.Enumerator*)null))->MoveNext();
					enumerator.Dispose();
					if (!((bool*)(flag ? 1 : 0))->m_value)
					{
						goto IL_00d3;
					}
				}
				else
				{
					bool flag3 = ((List<LunarConsoleLegacyAction>.Enumerator*)ex)->MoveNext();
				}
				throw new TypeLoadException();
			}
			goto IL_00d3;
			IL_00d3:
			UnityEngine.Object.Destroy(this);
		}

		[Token(Token = "0x60000B8")]
		[Address(RVA = "0x13E380C", Offset = "0x13E380C", Length = "0x104")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv18 = *([1EE82A8]);\n\tv19 = *([v18 @ X8_v15]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AEA]) = v38;\nL_0015:\n\tv41 = 0;\n\tv42 = LunarConsolePluginInternal.LunarConsoleLegacyActions::get_actionsEnabled(v36);\n\tv44 = v42 == 0;\n\tif (v44) goto L_0054;\n\tv46 = v36.m_actions == 0;\n\tif (v46) goto L_0036;\n\tv97 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>::GetEnumerator(v36.m_actions);\nL_0026:\n\tv137 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>));\n\tv82 = v137 == 0;\n\tif (v82) goto L_0033;\n\tLunarConsolePluginInternal.LunarConsoleLegacyAction::Unregister(0);\n\tgoto L_0026;\nL_0033:\n\tv79 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>));\n\tgoto L_0054;\n\tv101 = new System.NullReferenceException();\nL_0036:\n\tv106 = new System.NullReferenceException();\n\tgoto L_0042;\n\tgoto L_0042;\nL_0042:\n\tv48 = Il2CppMethodInfo != 1;\n\tif (v48) goto L_0055;\n\tv140 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(v106);\n\tv144 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(v140);\n\tv78 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::Dispose(&v41 @ stack_-38_v1 (System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>));\n\tv150 = ~v140.m_value;\n\tv81 = ~v150;\n\tif (v81) goto L_0059;\nL_0054:\n\treturn;\nL_0055:\n\tv141 = System.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>+Enumerator<LunarConsolePluginInternal.LunarConsoleLegacyAction>::MoveNext(v106);\nL_0059:\n\tthrow System.TypeLoadException;\n// 56 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private unsafe void OnDestroy()
		{
			List<LunarConsoleLegacyAction>.Enumerator enumerator = default(List<LunarConsoleLegacyAction>.Enumerator);
			if (!actionsEnabled)
			{
				return;
			}
			if (actions != null)
			{
				List<LunarConsoleLegacyAction>.Enumerator enumerator2 = actions.GetEnumerator();
				while (enumerator.MoveNext())
				{
					((LunarConsoleLegacyAction)null).Unregister();
				}
				enumerator.Dispose();
				return;
			}
			NullReferenceException ex = new NullReferenceException();
			if ((IntPtr)0 == (IntPtr)1)
			{
				bool flag = ((List<LunarConsoleLegacyAction>.Enumerator*)ex)->MoveNext();
				bool flag2 = (flag ? ((List<LunarConsoleLegacyAction>.Enumerator*)1) : ((List<LunarConsoleLegacyAction>.Enumerator*)null))->MoveNext();
				enumerator.Dispose();
				if (!((bool*)(flag ? 1 : 0))->m_value)
				{
					return;
				}
			}
			else
			{
				bool flag3 = ((List<LunarConsoleLegacyAction>.Enumerator*)ex)->MoveNext();
			}
			throw new TypeLoadException();
		}

		[Token(Token = "0x60000B9")]
		[Address(RVA = "0x13E3910", Offset = "0x13E3910", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0022;\n\tv22 = *([1EF6270]);\n\tv23 = *([v22 @ X8_v7]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, action, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AEB]) = v41;\nL_0022:\n\tSystem.Collections.Generic.List`1<LunarConsolePluginInternal.LunarConsoleLegacyAction>::Add(this.m_actions, action);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void AddAction(LunarConsoleLegacyAction action)
		{
			actions.Add(action);
		}

		[Token(Token = "0x60000BC")]
		[Address(RVA = "0x13E3980", Offset = "0x13E3980", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.MonoBehaviour::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public LunarConsoleLegacyActions()
		{
		}
	}
}
