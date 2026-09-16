using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using LunarConsolePlugin;

namespace LunarConsolePluginInternal
{
	[Token(Token = "0x200001A")]
	public class CRegistry
	{
		[CompilerGenerated]
		[Token(Token = "0x2000033")]
		private sealed class _003C_003Ec__DisplayClass4_0
		{
			[Token(Token = "0x400009E")]
			[FieldOffset(Offset = "0x10")]
			public string name;

			[Token(Token = "0x600018B")]
			[Address(RVA = "0x13DE8C4", Offset = "0x13DE8C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass4_0()
			{
			}

			internal bool _003CUnregister_003Eb__0(CAction action)
			{
				return action.Name == name;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000034")]
		private sealed class _003C_003Ec__DisplayClass5_0
		{
			[Token(Token = "0x400009F")]
			[FieldOffset(Offset = "0x10")]
			public int id;

			[Token(Token = "0x600018D")]
			[Address(RVA = "0x13DEF54", Offset = "0x13DEF54", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass5_0()
			{
			}

			internal bool _003CUnregister_003Eb__0(CAction action)
			{
				int num = action.Id - id;
				return num == 0;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000035")]
		private sealed class _003C_003Ec__DisplayClass6_0
		{
			[Token(Token = "0x40000A0")]
			[FieldOffset(Offset = "0x10")]
			public Delegate del;

			[Token(Token = "0x600018F")]
			[Address(RVA = "0x13DEF5C", Offset = "0x13DEF5C", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass6_0()
			{
			}

			internal bool _003CUnregister_003Eb__0(CAction action)
			{
				return action.ActionDelegate == del;
			}
		}

		[CompilerGenerated]
		[Token(Token = "0x2000036")]
		private sealed class _003C_003Ec__DisplayClass7_0
		{
			[Token(Token = "0x40000A1")]
			[FieldOffset(Offset = "0x10")]
			public object target;

			[Token(Token = "0x6000191")]
			[Address(RVA = "0x13DEF64", Offset = "0x13DEF64", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec__DisplayClass7_0()
			{
			}

			internal bool _003CUnregisterAll_003Eb__0(CAction action)
			{
				//IL_0028: Expected O, but got I
				Delegate actionDelegate = action.ActionDelegate;
				object obj = (long)(IntPtr)actionDelegate.Target - (long)(IntPtr)target;
				return obj == null;
			}
		}

		[Token(Token = "0x4000049")]
		[FieldOffset(Offset = "0x10")]
		private readonly CActionList m_actions;

		[Token(Token = "0x400004A")]
		[FieldOffset(Offset = "0x18")]
		private readonly CVarList m_vars;

		[Token(Token = "0x400004B")]
		[FieldOffset(Offset = "0x20")]
		private ICRegistryDelegate m_delegate;

		[Token(Token = "0x1700001B")]
		public ICRegistryDelegate registryDelegate
		{
			[Token(Token = "0x60000A9")]
			[Address(RVA = "0x13DF060", Offset = "0x13DF060", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_delegate;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return registryDelegate;
			}
			[Token(Token = "0x60000AA")]
			[Address(RVA = "0x13DF068", Offset = "0x13DF068", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.m_delegate = value;\n\treturn;\n")]
			set
			{
				registryDelegate = value;
			}
		}

		[Token(Token = "0x1700001C")]
		public CActionList actions
		{
			[Token(Token = "0x60000AB")]
			[Address(RVA = "0x13DF070", Offset = "0x13DF070", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_actions;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return actions;
			}
		}

		[Token(Token = "0x1700001D")]
		public CVarList cvars
		{
			[Token(Token = "0x60000AC")]
			[Address(RVA = "0x13DF078", Offset = "0x13DF078", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.m_vars;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return cvars;
			}
		}

		[Token(Token = "0x600009D")]
		[Address(RVA = "0x13DBC94", Offset = "0x13DBC94", Length = "0x1C0")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EB7E30]);\n\tv27 = *([v26 @ X8_v31]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, name, actionDelegate, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([2028AAF]) = v44;\nL_0017:\n\tv45 = name == 0;\n\tif (v45) goto L_0077;\n\tv47 = name.m_stringLength == 0;\n\tif (v47) goto L_007E;\n\tv64 = actionDelegate == 0;\n\tif (v64) goto L_0089;\n\tv93 = LunarConsolePluginInternal.CActionList::Find(this.m_actions, name);\n\tv116 = v93 == 0;\n\tif (v116) goto L_002D;\n\tLunarConsolePluginInternal.CAction::set_ActionDelegate(v93, actionDelegate);\n\tgoto L_0072;\nL_002D:\n\tv121 = new LunarConsolePluginInternal.CAction();\n\tLunarConsolePluginInternal.CAction::.ctor(v121, name, actionDelegate);\n\tLunarConsolePluginInternal.CActionList::Add(this.m_actions, v121);\n\tv209 = this.m_delegate == 0;\n\tif (v209) goto L_0072;\n\tgoto L_0069;\n\tv219 = *([v215 @ X8_v25+B0]);\n\tv220 = 0;\n\tv221 = v219 + 8;\n\tv223 = *([v259 @ X11_v6-8]);\n\tv265 = v223 == v218;\n\tif (v265) goto L_0060;\n\tv245 = v260 + 1;\n\tv270 = v245 < v217;\n\tv241 = ~v270;\n\tv243 = v259 + 0x10;\n\tv225 = ~v241;\n\tif (v225) goto L_FFFFFFFF;\n\tv246 = v211;\n\tv247 = 0;\n\tv248 = 0x8909C4(v246, v218, v247, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tgoto L_0069;\nL_0060:\n\tv271 = *([v259 @ X11_v6]);\n\tv272 = v271 << 4;\n\tv273 = v215 + v272;\n\tv274 = v273 + 0x130;\nL_0069:\n\tLunarConsolePluginInternal.ICRegistryDelegate::OnActionRegistered(this.m_delegate, this, v121);\nL_0072:\n\treturn v213;\n\tthrow System.NullReferenceException;\nL_0077:\n\tv84 = new System.ArgumentNullException();\n\tgoto L_008F;\nL_007E:\n\tv68 = new System.ArgumentException();\n\tSystem.ArgumentException::.ctor(v68, \"Action's name is empty\");\n\tgoto L_0095;\nL_0089:\n\tv84 = new System.ArgumentNullException();\nL_008F:\n\tSystem.ArgumentNullException::.ctor(v84, *([v86 @ X8_v3 (System.String)]));\nL_0095:\n\tthrow v106;\n// 97 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CAction RegisterAction(string name, Delegate actionDelegate)
		{
			if (name != null)
			{
				if (name.Length != 0)
				{
					if (actionDelegate != null)
					{
						CAction cAction = actions.Find(name);
						CAction result;
						if (cAction != null)
						{
							cAction.ActionDelegate = actionDelegate;
							result = cAction;
						}
						else
						{
							CAction cAction2 = new CAction(name, actionDelegate);
							actions.Add(cAction2);
							bool flag = registryDelegate == null;
							result = cAction2;
							if (!flag)
							{
								registryDelegate.OnActionRegistered(this, cAction2);
								result = cAction2;
							}
						}
						return result;
					}
					ArgumentNullException ex = new ArgumentNullException();
					string text = "actionDelegate";
				}
				else
				{
					ArgumentException ex2 = new ArgumentException("Action's name is empty");
				}
			}
			else
			{
				string text = default(string);
				ArgumentNullException ex = new ArgumentNullException(text);
				text = "name";
			}
			object obj = default(object);
			throw obj;
		}

		[Token(Token = "0x600009E")]
		[Address(RVA = "0x13DBF00", Offset = "0x13DBF00", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EFE370]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, name, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AB0]) = v41;\nL_0018:\n\tv45 = new LunarConsolePluginInternal.CRegistry+<>c__DisplayClass4_0();\n\tSystem.Object::.ctor(v45);\n\tv45.name = name;\n\tv52 = new LunarConsolePluginInternal.CActionFilter();\n\tv60 = Il2CppMethodInfo;\n\tv52.m_target = v45;\n\tv52.method = Il2CppMethodInfo;\n\tv52.method_ptr = *([v60 @ X9_v3 (Il2CppMethodInfo)]);\n\treturnVal2 = LunarConsolePluginInternal.CRegistry::Unregister(this, v52);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Unregister(string name)
		{
			_003C_003Ec__DisplayClass4_0 _003C_003Ec__DisplayClass4_1 = new _003C_003Ec__DisplayClass4_0();
			_003C_003Ec__DisplayClass4_1.name = name;
			CActionFilter cActionFilter = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)cActionFilter).m_target = _003C_003Ec__DisplayClass4_1;
			((Delegate)cActionFilter).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass4_0._003CUnregister_003Eb__0);
			((Delegate)cActionFilter).method_ptr = method_ptr;
			return Unregister(cActionFilter);
		}

		[Token(Token = "0x600009F")]
		[Address(RVA = "0x13DEEA8", Offset = "0x13DEEA8", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1F10678]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, id, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AB1]) = v41;\nL_0018:\n\tv45 = new LunarConsolePluginInternal.CRegistry+<>c__DisplayClass5_0();\n\tSystem.Object::.ctor(v45);\n\tv45.id = id;\n\tv52 = new LunarConsolePluginInternal.CActionFilter();\n\tv60 = Il2CppMethodInfo;\n\tv52.m_target = v45;\n\tv52.method = Il2CppMethodInfo;\n\tv52.method_ptr = *([v60 @ X9_v3 (Il2CppMethodInfo)]);\n\treturnVal2 = LunarConsolePluginInternal.CRegistry::Unregister(this, v52);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Unregister(int id)
		{
			_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_1 = new _003C_003Ec__DisplayClass5_0();
			_003C_003Ec__DisplayClass5_1.id = id;
			CActionFilter cActionFilter = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)cActionFilter).m_target = _003C_003Ec__DisplayClass5_1;
			((Delegate)cActionFilter).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass5_0._003CUnregister_003Eb__0);
			((Delegate)cActionFilter).method_ptr = method_ptr;
			return Unregister(cActionFilter);
		}

		[Token(Token = "0x60000A0")]
		[Address(RVA = "0x13DBE54", Offset = "0x13DBE54", Length = "0xAC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EEA920]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, del, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AB2]) = v41;\nL_0018:\n\tv45 = new LunarConsolePluginInternal.CRegistry+<>c__DisplayClass6_0();\n\tSystem.Object::.ctor(v45);\n\tv45.del = del;\n\tv52 = new LunarConsolePluginInternal.CActionFilter();\n\tv60 = Il2CppMethodInfo;\n\tv52.m_target = v45;\n\tv52.method = Il2CppMethodInfo;\n\tv52.method_ptr = *([v60 @ X9_v3 (Il2CppMethodInfo)]);\n\treturnVal2 = LunarConsolePluginInternal.CRegistry::Unregister(this, v52);\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool Unregister(Delegate del)
		{
			_003C_003Ec__DisplayClass6_0 _003C_003Ec__DisplayClass6_1 = new _003C_003Ec__DisplayClass6_0();
			_003C_003Ec__DisplayClass6_1.del = del;
			CActionFilter cActionFilter = null;
			IntPtr method_ptr = (IntPtr)0;
			((Delegate)cActionFilter).m_target = _003C_003Ec__DisplayClass6_1;
			((Delegate)cActionFilter).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass6_0._003CUnregister_003Eb__0);
			((Delegate)cActionFilter).method_ptr = method_ptr;
			return Unregister(cActionFilter);
		}

		[Token(Token = "0x60000A1")]
		[Address(RVA = "0x13DBFAC", Offset = "0x13DBFAC", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv22 = *([1EDECF8]);\n\tv23 = *([v22 @ X8_v10]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, target, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AB3]) = v41;\nL_0018:\n\tv45 = new LunarConsolePluginInternal.CRegistry+<>c__DisplayClass7_0();\n\tSystem.Object::.ctor(v45);\n\tv45.target = target;\n\tv49 = target == 0;\n\tif (v49) goto L_003E;\n\tv55 = new LunarConsolePluginInternal.CActionFilter();\n\tv67 = Il2CppMethodInfo;\n\tv55.m_target = v45;\n\tv55.method = Il2CppMethodInfo;\n\tv55.method_ptr = *([v67 @ X9_v3 (Il2CppMethodInfo)]);\n\treturnVal3 = LunarConsolePluginInternal.CRegistry::Unregister(this, v55);\n\treturn returnVal3;\nL_003E:\n\treturn 0;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 45 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public unsafe bool UnregisterAll(object target)
		{
			_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_1 = new _003C_003Ec__DisplayClass7_0();
			_003C_003Ec__DisplayClass7_1.target = target;
			if (target != null)
			{
				CActionFilter cActionFilter = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)cActionFilter).m_target = _003C_003Ec__DisplayClass7_1;
				((Delegate)cActionFilter).method = (IntPtr)__ldftn(_003C_003Ec__DisplayClass7_0._003CUnregisterAll_003Eb__0);
				((Delegate)cActionFilter).method_ptr = method_ptr;
				return Unregister(cActionFilter);
			}
			return false;
		}

		[Token(Token = "0x60000A2")]
		[Address(RVA = "0x13DE8CC", Offset = "0x13DE8CC", Length = "0x5DC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EB7320]);\n\tv35 = *([v34 @ X8_v72]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, filter, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv53 = 0 | 1;\n\t*([2028AB4]) = v53;\nL_001B:\n\tv54 = &v55 @ stack_-70;\n\tv57 = filter == 0;\n\tif (v57) goto L_00D5;\n\tv61 = new System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>();\n\tSystem.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>::.ctor(v61);\n\tv146 = LunarConsolePluginInternal.CActionList::GetEnumerator(this.m_actions);\n\tv173 = v146 == 0;\n\tif (v173) goto L_00E3;\nL_0039:\n\tgoto L_0060;\n\tv258 = *([v244 @ X8_v57+B0]);\n\tv259 = 0;\n\tv260 = v258 + 8;\n\tv262 = *([v353 @ X11_v67-8]);\n\tv358 = v262 == v245;\n\tif (v358) goto L_0059;\n\tv282 = v352 + 1;\n\tv365 = v282 < v246;\n\tv280 = ~v365;\n\tv284 = v353 + 0x10;\n\tv264 = ~v280;\n\tif (v264) goto L_FFFFFFFF;\n\tv285 = v115;\n\tv286 = 0;\n\tv287 = 0x8909C4(v285, v245, v286, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0060;\nL_0059:\n\tv366 = *([v353 @ X11_v67]);\n\tv367 = v366 << 4;\n\tv368 = v244 + v367;\n\tv369 = v368 + 0x130;\nL_0060:\n\tv390 = System.Collections.IEnumerator::MoveNext(v146);\n\tv392 = v390 == 0;\n\tif (v392) goto L_00CB;\n\tgoto L_008F;\n\tv545 = *([v458 @ X8_v61+B0]);\n\tv546 = 0;\n\tv547 = v545 + 8;\n\tv549 = *([v639 @ X11_v62-8]);\n\tv644 = v549 == v459;\n\tif (v644) goto L_0088;\n\tv569 = v638 + 1;\n\tv750 = v569 < v460;\n\tv567 = ~v750;\n\tv571 = v639 + 0x10;\n\tv551 = ~v567;\n\tif (v551) goto L_FFFFFFFF;\n\tv572 = v115;\n\tv573 = 0;\n\tv574 = 0x8909C4(v572, v459, v573, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_008F;\nL_0088:\n\tv751 = *([v639 @ X11_v62]);\n\tv752 = v751 << 4;\n\tv753 = v458 + v752;\n\tv754 = v753 + 0x130;\nL_008F:\n\tv759 = System.Collections.Generic.IEnumerator`1<LunarConsolePluginInternal.CAction>::get_Current(v146);\n\tv237 = LunarConsolePluginInternal.CActionFilter::Invoke(filter, v759);\n\tv240 = v237 == 0;\n\tif (v240) goto L_0039;\n\tv945 = *([v61 @ X0_v72 (System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>)]);\n\tv241 = *([v945 @ X8_v64 (Il2CppClass<System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>>)+126]) == 0;\n\tif (v241) goto L_00BB;\n\tv1083 = *([v945 @ X8_v64 (Il2CppClass<System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>>)+B0]) + 8;\nL_00A6:\n\tv1088 = *([v1083 @ X11_v57-8]) == System.Collections.Generic.ICollection`1<LunarConsolePluginInternal.CAction>;\n\tif (v1088) goto L_00BE;\n\tv1082 = v1082 + 1;\n\tv1099 = v1082 < *([v945 @ X8_v64 (Il2CppClass<System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>>)+126]);\n\tv1021 = ~v1099;\n\tv1083 = v1083 + 0x10;\n\tv1005 = ~v1021;\n\tif (v1005) goto L_00A6;\nL_00BB:\n\tv1106 = 0x8909C4(v61, System.Collections.Generic.ICollection`1<LunarConsolePluginInternal.CAction>, 2, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_00C6;\nL_00BE:\n\tv1101 = *([v1083 @ X11_v57]) + 2;\n\tv1102 = v1101 << 4;\n\tv1103 = v945 + v1102;\n\tv1106 = v1103 + 0x130;\nL_00C6:\n\t*([v1106 @ X0_v86])(v238, v61, v759, *([v1106 @ X0_v86+8]), v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0039;\nL_00CB:\n\t*([v54 @ X24_v1]) = 0x4D;\n\tv465 = v146 == 0;\n\tv466 = ~v465;\n\tif (v466) goto L_0100;\n\tgoto L_0128;\n\tthrow System.NullReferenceException;\nL_00D5:\n\tv129 = new System.ArgumentNullException();\n\tSystem.ArgumentNullException::.ctor(v129, \"filter\");\n\tthrow v129;\n\tv172 = new System.NullReferenceException();\nL_00E3:\n\tv331 = new System.NullReferenceException();\n\tgoto L_00F2;\n\tgoto L_00F2;\n\tgoto L_00F2;\n\tgoto L_00F2;\n\tgoto L_00F2;\nL_00F2:\n\tv257 = Il2CppMethodInfo != 1;\n\tif (v257) goto L_0288;\n\tv288 = 0x6D2BC0(v331, Il2CppMethodInfo, v298, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv490 = *([v288 @ X0_v62]);\n\tv364 = 0x6D2490(v288, Il2CppMethodInfo, v298, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv394 = v146 == 0;\n\tif (v394) goto L_0128;\nL_0100:\n\tgoto L_0127;\n\tv575 = *([v494 @ X8_v39+B0]);\n\tv576 = 0;\n\tv577 = v575 + 8;\n\tv579 = *([v660 @ X11_v45-8]);\n\tv665 = v579 == v497;\n\tif (v665) goto L_0120;\n\tv599 = v659 + 1;\n\tv761 = v599 < v496;\n\tv597 = ~v761;\n\tv601 = v660 + 0x10;\n\tv581 = ~v597;\n\tif (v581) goto L_FFFFFFFF;\n\tv602 = v486;\n\tv603 = 0;\n\tv604 = 0x8909C4(v602, v497, v603, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0127;\nL_0120:\n\tv762 = *([v660 @ X11_v45]);\n\tv763 = v762 << 4;\n\tv764 = v494 + v763;\n\tv765 = v764 + 0x130;\nL_0127:\n\tSystem.IDisposable::Dispose(v486);\nL_0128:\n\tv540 = v769 + 1;\n\tv542 = v540 == 0;\n\tif (v542) goto L_013F;\n\tv615 = *([v54 @ X24_v1+v769 @ X23_v9 (System.Int32)*4]) != 0x4D;\n\tif (v615) goto L_013F;\n\tv671 = v340 == 0;\n\tv672 = ~v671;\n\tif (v672) goto L_014A;\n\tgoto L_01E3;\nL_013F:\n\tv626 = v1180 == 0;\n\tv627 = ~v626;\n\tif (v627) goto L_023B;\n\tv673 = v340 == 0;\n\tif (v673) goto L_01E3;\nL_014A:\n\tgoto L_0171;\n\tv833 = *([v782 @ X8_v20+B0]);\n\tv834 = 0;\n\tv835 = v833 + 8;\n\tv837 = *([v904 @ X11_v37-8]);\n\tv909 = v837 == v785;\n\tif (v909) goto L_016A;\n\tv857 = v903 + 1;\n\tv949 = v857 < v784;\n\tv855 = ~v949;\n\tv859 = v904 + 0x10;\n\tv839 = ~v855;\n\tif (v839) goto L_FFFFFFFF;\n\tv860 = v340;\n\tv861 = 0;\n\tv862 = 0x8909C4(v860, v785, v861, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0171;\nL_016A:\n\tv950 = *([v904 @ X11_v37]);\n\tv951 = v950 << 4;\n\tv952 = v782 + v951;\n\tv953 = v952 + 0x130;\nL_0171:\n\tv974 = System.Collections.Generic.IEnumerable`1<LunarConsolePluginInternal.CAction>::GetEnumerator(v340);\nL_017D:\n\tgoto L_01A4;\n\tv1109 = *([v1093 @ X8_v24+B0]);\n\tv1110 = 0;\n\tv1111 = v1109 + 8;\n\tv1113 = *([v1223 @ X11_v32-8]);\n\tv1228 = v1113 == v1094;\n\tif (v1228) goto L_019D;\n\tv1133 = v1222 + 1;\n\tv1263 = v1133 < v1095;\n\tv1131 = ~v1263;\n\tv1135 = v1223 + 0x10;\n\tv1115 = ~v1131;\n\tif (v1115) goto L_FFFFFFFF;\n\tv1136 = v813;\n\tv1137 = 0;\n\tv1138 = 0x8909C4(v1136, v1094, v1137, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01A4;\nL_019D:\n\tv1264 = *([v1223 @ X11_v32]);\n\tv1265 = v1264 << 4;\n\tv1266 = v1093 + v1265;\n\tv1267 = v1266 + 0x130;\nL_01A4:\n\tv1177 = System.Collections.IEnumerator::MoveNext(v974);\n\tv1273 = v1177 == 0;\n\tif (v1273) goto L_01D9;\n\tgoto L_01D3;\n\tv1309 = *([v1296 @ X8_v29+B0]);\n\tv1310 = 0;\n\tv1311 = v1309 + 8;\n\tv1313 = *([v1350 @ X11_v27-8]);\n\tv1355 = v1313 == v1297;\n\tif (v1355) goto L_01CC;\n\tv1333 = v1349 + 1;\n\tv1360 = v1333 < v1298;\n\tv1331 = ~v1360;\n\tv1335 = v1350 + 0x10;\n\tv1315 = ~v1331;\n\tif (v1315) goto L_FFFFFFFF;\n\tv1336 = v813;\n\tv1337 = 0;\n\tv1338 = 0x8909C4(v1336, v1297, v1337, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_01D3;\nL_01CC:\n\tv1361 = *([v1350 @ X11_v27]);\n\tv1362 = v1361 << 4;\n\tv1363 = v1296 + v1362;\n\tv1364 = v1363 + 0x130;\nL_01D3:\n\tv1369 = System.Collections.Generic.IEnumerator`1<LunarConsolePluginInternal.CAction>::get_Current(v974);\n\tv1046 = LunarConsolePluginInternal.CRegistry::RemoveAction(this, v1369);\n\tgoto L_017D;\nL_01D9:\n\tv1141 = v769 + 1;\n\t*([v54 @ X24_v1+v1141 @ X23_v7 (System.Int32)*4]) = 0x79;\n\tv1300 = v974 == 0;\n\tv1179 = ~v1300;\n\tif (v1179) goto L_01FD;\n\tgoto L_0225;\n\tthrow System.NullReferenceException;\nL_01E3:\n\tv331 = new System.NullReferenceException();\n\tgoto L_01F0;\n\tgoto L_01F0;\n\tgoto L_01F0;\nL_01F0:\n\tv300 = v330 != 1;\n\tif (v300) goto L_0288;\n\tv977 = 0x6D2BC0(v331, v330, v298, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1180 = *([v977 @ X0_v26]);\n\tv1051 = 0x6D2490(v977, v330, v298, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tv1098 = v1173 == 0;\n\tif (v1098) goto L_0225;\nL_01FD:\n\tgoto L_0224;\n\tv1233 = *([v1184 @ X8_v14+B0]);\n\tv1234 = 0;\n\tv1235 = v1233 + 8;\n\tv1237 = *([v1285 @ X11_v17-8]);\n\tv1290 = v1237 == v1187;\n\tif (v1290) goto L_021D;\n\tv1257 = v1284 + 1;\n\tv1301 = v1257 < v1186;\n\tv1255 = ~v1301;\n\tv1259 = v1285 + 0x10;\n\tv1239 = ~v1255;\n\tif (v1239) goto L_FFFFFFFF;\n\tv1260 = v1173;\n\tv1261 = 0;\n\tv1262 = 0x8909C4(v1260, v1187, v1261, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50);\n\tgoto L_0224;\nL_021D:\n\tv1302 = *([v1285 @ X11_v17]);\n\tv1303 = v1302 << 4;\n\tv1304 = v1184 + v1303;\n\tv1305 = v1304 + 0x130;\nL_0224:\n\tSystem.IDisposable::Dispose(v1173);\nL_0225\n// ... truncated")]
		private bool Unregister(CActionFilter filter)
		{
			//IL_022c: Expected I4, but got O
			//IL_015a: Expected O, but got I4
			//IL_026c: Expected I4, but got O
			//IL_05ca: Expected I, but got O
			//IL_05d7: Expected I, but got O
			//IL_01b2: Expected I, but got O
			//IL_01bf: Expected I, but got O
			//IL_0063: Expected I, but got O
			//IL_009e: Expected O, but got I
			//IL_05fe: Expected I, but got O
			//IL_0301: Expected I, but got O
			//IL_011b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0120: Expected O, but got Unknown
			//IL_013d: Expected O, but got I
			//IL_014c: Expected O, but got I
			//IL_03fc: Expected I4, but got O
			//IL_00ea: Expected O, but got I
			//IL_042a: Expected I4, but got O
			//IL_0652: Expected I, but got O
			object obj2 = default(object);
			object obj = obj2;
			IntPtr intPtr;
			int num3;
			IEnumerator<CAction> enumerator3;
			int num4;
			List<CAction> list3;
			NullReferenceException ex;
			if (filter != null)
			{
				List<CAction> list = new List<CAction>();
				IEnumerator<CAction> enumerator = actions.GetEnumerator();
				bool flag = enumerator == null;
				IEnumerator<CAction> enumerator2 = enumerator;
				intPtr = (IntPtr)0;
				List<CAction> list2 = list;
				int num;
				int num2;
				IntPtr intPtr3;
				if (flag)
				{
					ex = new NullReferenceException();
					if ((IntPtr)0 != (IntPtr)1)
					{
						goto IL_04b2;
					}
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
					object obj3 = default(object);
					num = (int)obj3;
					Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
					bool flag2 = enumerator == null;
					num2 = -1;
					num3 = -1;
					enumerator3 = enumerator;
					num4 = (int)obj3;
					list3 = list;
					if (flag2)
					{
						goto IL_0589;
					}
				}
				else
				{
					while (enumerator.MoveNext())
					{
						CAction current = enumerator.Current;
						if (!filter(current))
						{
							continue;
						}
						IntPtr intPtr2 = (IntPtr)list;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v945 @ X8_v64 (Il2CppClass<System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>>)+126]");
						if ((IntPtr)0 == (IntPtr)0)
						{
							goto IL_0103;
						}
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v945 @ X8_v64 (Il2CppClass<System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>>)+B0]");
						object obj4 = 0L + 8L;
						int num5 = 0;
						while (true)
						{
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v1083 @ X11_v57-8]");
							if ((IntPtr)0 == (IntPtr)typeof(ICollection<CAction>))
							{
								break;
							}
							num5++;
							int num6 = num5;
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v945 @ X8_v64 (Il2CppClass<System.Collections.Generic.List`1<LunarConsolePluginInternal.CAction>>)+126]");
							bool flag3 = (long)num6 < 0L;
							bool flag4 = !flag3;
							obj4 = (long)(IntPtr)obj4 + 16L;
							if (!flag4)
							{
								continue;
							}
							goto IL_0103;
						}
						object obj5 = obj4 + 2;
						int num7 = (int)((long)(IntPtr)obj5 << 4);
						object obj6 = (long)intPtr2 + (long)num7;
						object obj7 = (long)(IntPtr)obj6 + 304L;
						goto IL_057a;
						IL_057a:
						Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v1106 @ X0_v86] (should have been resolved before IL gen)");
						continue;
						IL_0103:
						Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
						goto IL_057a;
					}
					obj = 77;
					bool flag5 = enumerator == null;
					bool flag6 = !flag5;
					num2 = 0;
					enumerator2 = enumerator;
					num = 0;
					list2 = list;
					if (!flag6)
					{
						num3 = 0;
						intPtr3 = (IntPtr)null;
						enumerator3 = enumerator;
						intPtr = (IntPtr)null;
						num4 = 0;
						list3 = list;
						goto IL_0589;
					}
				}
				enumerator2.Dispose();
				num3 = num2;
				intPtr3 = (IntPtr)null;
				enumerator3 = enumerator2;
				intPtr = (IntPtr)null;
				num4 = num;
				list3 = list2;
				goto IL_0589;
			}
			ArgumentNullException ex2 = new ArgumentNullException("filter");
			throw ex2;
			IL_0589:
			int num8;
			IEnumerator<CAction> enumerator4 = default(IEnumerator<CAction>);
			CAction cAction = default(CAction);
			IntPtr intPtr4 = default(IntPtr);
			if (num3 + 1 != 0)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v769 @ X23_v9 (System.Int32)*4]");
				if ((IntPtr)0 == (IntPtr)77)
				{
					bool flag7 = list3 == null;
					bool flag8 = !flag7;
					num3 = -1;
					if (!flag8)
					{
						num8 = -1;
						IntPtr intPtr3 = intPtr4;
						enumerator3 = enumerator4;
						intPtr = (IntPtr)cAction;
						goto IL_03bc;
					}
					goto IL_05ec;
				}
			}
			if (num4 != 0)
			{
				goto IL_047f;
			}
			bool flag9 = list3 == null;
			num8 = -1;
			if (flag9)
			{
				goto IL_03bc;
			}
			goto IL_05ec;
			IL_05ec:
			enumerator4 = ((IEnumerable<CAction>)list3).GetEnumerator();
			intPtr4 = (IntPtr)null;
			cAction = null;
			while (enumerator4.MoveNext())
			{
				CAction current2 = enumerator4.Current;
				bool flag10 = RemoveAction(current2);
				intPtr4 = (IntPtr)null;
			}
			num8 = num3 + 1;
			_ = 121;
			bool flag11 = enumerator4 == null;
			bool flag12 = !flag11;
			enumerator3 = enumerator4;
			int num9;
			int num10;
			if (!flag12)
			{
				num9 = num8;
				num10 = num4;
				goto IL_0657;
			}
			goto IL_0682;
			IL_03bc:
			ex = new NullReferenceException();
			if (intPtr != (IntPtr)1)
			{
				goto IL_04b2;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2BC0 (native __cxa_begin_catch)");
			object obj8 = default(object);
			num4 = (int)obj8;
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2490 (native __cxa_end_catch)");
			bool flag13 = enumerator3 == null;
			num9 = num8;
			num10 = (int)obj8;
			if (flag13)
			{
				goto IL_0657;
			}
			goto IL_0682;
			IL_04b2:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @6D2380 (native _Unwind_Resume)");
			bool result = default(bool);
			return result;
			IL_0657:
			if (num9 + 1 != 0)
			{
				if (num10 != 0)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v54 @ X24_v1+v678 @ X23_v2 (System.Int32)*4]");
					if ((IntPtr)0 != (IntPtr)121)
					{
						goto IL_047f;
					}
				}
			}
			else if (num10 != 0)
			{
				goto IL_047f;
			}
			int count = ((ICollection<CAction>)list3).Count;
			bool flag14 = count < 0;
			bool flag15 = count == 0;
			int num11 = count ^ count;
			int num12 = count & num11;
			bool flag16 = num12 < 0;
			bool flag17 = flag14 == flag16;
			bool flag18 = !flag15;
			return flag17 && flag18;
			IL_047f:
			throw new TypeLoadException();
			IL_0682:
			enumerator3.Dispose();
			num9 = num8;
			num10 = num4;
			goto IL_0657;
		}

		[Token(Token = "0x60000A3")]
		[Address(RVA = "0x13DEF6C", Offset = "0x13DEF6C", Length = "0xF4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv22 = *([1F07A50]);\n\tv23 = *([v22 @ X8_v11]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, action, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AB5]) = v41;\nL_001B:\n\tv47 = LunarConsolePluginInternal.CActionList::Remove(this.m_actions, action.m_id);\n\tv52 = v47 == 0;\n\tif (v52) goto L_FFFFFFFF;\n\tv53 = this.m_delegate;\n\tv54 = this.m_delegate == 0;\n\tif (v54) goto L_FFFFFFFF;\n\tv121 = *([v53 @ X21_v4 (LunarConsolePluginInternal.ICRegistryDelegate)]);\n\tv125 = *([v121 @ X8_v5 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]) == 0;\n\tif (v125) goto L_0046;\n\tv207 = *([v121 @ X8_v5 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+B0]) + 8;\nL_0031:\n\tv213 = *([v207 @ X11_v7-8]) == LunarConsolePluginInternal.ICRegistryDelegate;\n\tif (v213) goto L_004B;\n\tv208 = v208 + 1;\n\tv218 = v208 < *([v121 @ X8_v5 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]);\n\tv189 = ~v218;\n\tv207 = v207 + 0x10;\n\tv173 = ~v189;\n\tif (v173) goto L_0031;\nL_0046:\n\tv225 = 0x8909C4(this.m_delegate, LunarConsolePluginInternal.ICRegistryDelegate, 1, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_0054;\n\tgoto L_005C;\nL_004B:\n\tv220 = *([v207 @ X11_v7]) + 1;\n\tv221 = v220 << 4;\n\tv222 = v121 + v221;\n\tv225 = v222 + 0x130;\nL_0054:\n\t*([v225 @ X0_v11])(v161, this.m_delegate, this, action, *([v225 @ X0_v11+8]), v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\nL_005C:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private bool RemoveAction(CAction action)
		{
			//IL_006b: Expected I, but got O
			//IL_00a6: Expected O, but got I
			//IL_0131: Unknown result type (might be due to invalid IL or missing references)
			//IL_0136: Expected O, but got Unknown
			//IL_0153: Expected O, but got I
			//IL_0162: Expected O, but got I
			//IL_00f2: Expected O, but got I
			if (actions.Remove(action.Id))
			{
				ICRegistryDelegate iCRegistryDelegate = registryDelegate;
				if (registryDelegate == null)
				{
					goto IL_0167;
				}
				IntPtr intPtr = (IntPtr)iCRegistryDelegate;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X8_v5 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]");
				if ((IntPtr)0 == (IntPtr)0)
				{
					goto IL_010b;
				}
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X8_v5 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+B0]");
				object obj = 0L + 8L;
				int num = 0;
				while (true)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v207 @ X11_v7-8]");
					if ((IntPtr)0 == (IntPtr)typeof(ICRegistryDelegate))
					{
						break;
					}
					num++;
					int num2 = num;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v121 @ X8_v5 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]");
					bool flag = (long)num2 < 0L;
					bool flag2 = !flag;
					obj = (long)(IntPtr)obj + 16L;
					if (!flag2)
					{
						continue;
					}
					goto IL_010b;
				}
				object obj2 = obj + 1;
				int num3 = (int)((long)(IntPtr)obj2 << 4);
				object obj3 = (long)intPtr + (long)num3;
				object obj4 = (long)(IntPtr)obj3 + 304L;
				goto IL_019f;
			}
			return false;
			IL_010b:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_019f;
			IL_0167:
			return true;
			IL_019f:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect call: [v225 @ X0_v11] (should have been resolved before IL gen)");
			goto IL_0167;
		}

		[Token(Token = "0x60000A4")]
		[Address(RVA = "0x13DA144", Offset = "0x13DA144", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = LunarConsolePluginInternal.CActionList::Find(this.m_actions, id);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CAction FindAction(int id)
		{
			return actions.Find(id);
		}

		[Token(Token = "0x60000A5")]
		[Address(RVA = "0x13D8B48", Offset = "0x13D8B48", Length = "0xE8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv22 = *([1EF6B70]);\n\tv23 = *([v22 @ X8_v8]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, cvar, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tv41 = 0 | 1;\n\t*([2028AB6]) = v41;\nL_0019:\n\tLunarConsolePlugin.CVarList::Add(this.m_vars, cvar);\n\tv46 = this.m_delegate;\n\tv47 = this.m_delegate == 0;\n\tif (v47) goto L_0049;\n\tv49 = *([v46 @ X21_v2 (LunarConsolePluginInternal.ICRegistryDelegate)]);\n\tv53 = *([v49 @ X8_v3 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]) == 0;\n\tif (v53) goto L_0041;\n\tv164 = *([v49 @ X8_v3 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+B0]) + 8;\nL_002C:\n\tv170 = *([v164 @ X11_v5-8]) == LunarConsolePluginInternal.ICRegistryDelegate;\n\tif (v170) goto L_004B;\n\tv165 = v165 + 1;\n\tv175 = v165 < *([v49 @ X8_v3 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]);\n\tv146 = ~v175;\n\tv164 = v164 + 0x10;\n\tv130 = ~v146;\n\tif (v130) goto L_002C;\nL_0041:\n\tv182 = 0x8909C4(this.m_delegate, LunarConsolePluginInternal.ICRegistryDelegate, 2, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38);\n\tgoto L_005A;\nL_0049:\n\treturn;\nL_004B:\n\tv177 = *([v164 @ X11_v5]) + 2;\n\tv178 = v177 << 4;\n\tv179 = v49 + v178;\n\tv182 = v179 + 0x130;\nL_005A:\n\t// 90 IndirectJump [v182 @ X0_v4], this.m_delegate (LunarConsolePluginInternal.ICRegistryDelegate), this.m_delegate (LunarConsolePluginInternal.ICRegistryDelegate), this @ X0 (LunarConsolePluginInternal.CRegistry), cvar @ X1 (LunarConsolePlugin.CVar), [v182 @ X0_v4+8], [v182 @ X0_v4], v28 @ X5, v29 @ X6, v30 @ X7, v31 @ V0, v32 @ V1, v33 @ V2, v34 @ V3, v35 @ V4, v36 @ V5, v37 @ V6, v38 @ V7\n\tthrow System.NullReferenceException;\n\treturn;\n// 61 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Register(CVar cvar)
		{
			//IL_0045: Expected I, but got O
			//IL_0080: Expected O, but got I
			//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
			//IL_0103: Expected O, but got Unknown
			//IL_0120: Expected O, but got I
			//IL_012f: Expected O, but got I
			//IL_00cc: Expected O, but got I
			cvars.Add(cvar);
			ICRegistryDelegate iCRegistryDelegate = registryDelegate;
			if (registryDelegate == null)
			{
				return;
			}
			IntPtr intPtr = (IntPtr)iCRegistryDelegate;
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v3 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]");
			if ((IntPtr)0 == (IntPtr)0)
			{
				goto IL_00e5;
			}
			Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v3 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+B0]");
			object obj = 0L + 8L;
			int num = 0;
			while (true)
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v164 @ X11_v5-8]");
				if ((IntPtr)0 == (IntPtr)typeof(ICRegistryDelegate))
				{
					break;
				}
				num++;
				int num2 = num;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v49 @ X8_v3 (Il2CppClass<LunarConsolePluginInternal.ICRegistryDelegate>)+126]");
				bool flag = (long)num2 < 0L;
				bool flag2 = !flag;
				obj = (long)(IntPtr)obj + 16L;
				if (!flag2)
				{
					continue;
				}
				goto IL_00e5;
			}
			object obj2 = obj + 2;
			int num3 = (int)((long)(IntPtr)obj2 << 4);
			object obj3 = (long)intPtr + (long)num3;
			object obj4 = (long)(IntPtr)obj3 + 304L;
			goto IL_015e;
			IL_015e:
			Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: [v182 @ X0_v4] (should have been resolved before IL gen)");
			return;
			IL_00e5:
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @8909C4");
			goto IL_015e;
		}

		[Token(Token = "0x60000A6")]
		[Address(RVA = "0x13DAA50", Offset = "0x13DAA50", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = LunarConsolePlugin.CVarList::Find(this.m_vars, variableId);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar FindVariable(int variableId)
		{
			return cvars.Find(variableId);
		}

		[Token(Token = "0x60000A7")]
		[Address(RVA = "0x13D8D00", Offset = "0x13D8D00", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = LunarConsolePlugin.CVarList::Find(this.m_vars, variableName);\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 7 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CVar FindVariable(string variableName)
		{
			return cvars.Find(variableName);
		}

		[Token(Token = "0x60000A8")]
		[Address(RVA = "0x13D7A28", Offset = "0x13D7A28", Length = "0x3C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tLunarConsolePluginInternal.CActionList::Clear(this.m_actions);\n\tLunarConsolePlugin.CVarList::Clear(this.m_vars);\n\tthis.m_delegate = 0;\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 16 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public void Destroy()
		{
			actions.Clear();
			cvars.Clear();
			registryDelegate = null;
		}

		[Token(Token = "0x60000AD")]
		[Address(RVA = "0x13D6B44", Offset = "0x13D6B44", Length = "0x80")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EBD3F8]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2028AB7]) = v38;\nL_0016:\n\tv42 = new LunarConsolePluginInternal.CActionList();\n\tLunarConsolePluginInternal.CActionList::.ctor(v42);\n\tthis.m_actions = v42;\n\tv47 = new LunarConsolePlugin.CVarList();\n\tLunarConsolePlugin.CVarList::.ctor(v47);\n\tthis.m_vars = v47;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public CRegistry()
		{
			CActionList cActionList = new CActionList();
			m_actions = cActionList;
			CVarList vars = new CVarList();
			m_vars = vars;
		}
	}
}
