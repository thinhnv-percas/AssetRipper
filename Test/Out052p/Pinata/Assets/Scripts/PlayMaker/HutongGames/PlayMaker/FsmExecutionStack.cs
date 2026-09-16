using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.PlayMaker
{
	[Token(Token = "0x200004F")]
	public static class FsmExecutionStack
	{
		[Token(Token = "0x4000134")]
		private static readonly Stack<Fsm> fsmExecutionStack;

		[Token(Token = "0x17000059")]
		public static Fsm ExecutingFsm
		{
			[Token(Token = "0x600016C")]
			[Address(RVA = "0xCABE60", Offset = "0xCABE60", Length = "0xC0")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB7280]);\n\tv15 = *([v14 @ X8_v16]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235D2]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmExecutionStack;\nL_001F:\n\tv103 = v49.fsmExecutionStack;\n\tv64 = v103._size < 1;\n\tif (v64) goto L_FFFFFFFF;\n\tgoto L_0041;\n\tv84 = *([v45 @ X0_v3 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv98 = v84 == 0;\n\tv99 = ~v98;\n\tif (v99) goto L_0041;\n\tv134 = HutongGames.PlayMaker.FsmExecutionStack;\n\tv135 = *([v134 @ X8_v10 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+B8]);\n\tv91 = v135.fsmExecutionStack;\nL_0041:\n\treturnVal2 = System.Collections.Generic.Stack`1<HutongGames.PlayMaker.Fsm>::Peek(v103);\n\tgoto L_0048;\nL_0048:\n\treturn returnVal2;\n\treturnVal1 = new System.NullReferenceException();\n\treturn returnVal1;\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Stack<Fsm> stack = fsmExecutionStack;
				if (stack.Count >= 1)
				{
					return stack.Peek();
				}
				return null;
			}
		}

		[Token(Token = "0x1700005A")]
		public static FsmState ExecutingState
		{
			[Token(Token = "0x600016D")]
			[Address(RVA = "0xCABF20", Offset = "0xCABF20", Length = "0x98")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EEDDA0]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235D3]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\treturnVal1 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv50 = returnVal1 == 0;\n\tif (v50) goto L_0038;\n\tgoto L_002A;\n\tv58 = *([v51 @ X0_v5 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv59 = v58 == 0;\n\tv60 = ~v59;\n\tif (v60) goto L_002A;\n\tv62 = \"il2cpp_codegen_runtime_class_init\"(v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002A:\n\tv65 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\treturnVal2 = HutongGames.PlayMaker.Fsm::get_ActiveState(v65);\n\treturn returnVal2;\nL_0038:\n\treturn returnVal1;\n\treturnVal3 = new System.NullReferenceException();\n\treturn returnVal3;\n// 32 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmState executingFsm = (FsmState)(object)ExecutingFsm;
				if (executingFsm != null)
				{
					Fsm executingFsm2 = ExecutingFsm;
					return executingFsm2.ActiveState;
				}
				return executingFsm;
			}
		}

		[Token(Token = "0x1700005B")]
		public static string ExecutingStateName
		{
			[Token(Token = "0x600016E")]
			[Address(RVA = "0xCABFB8", Offset = "0xCABFB8", Length = "0x9C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1ED7A98]);\n\tv15 = *([v14 @ X8_v15]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235D4]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv50 = v49 == 0;\n\tif (v50) goto L_FFFFFFFF;\n\tgoto L_002A;\n\tv57 = *([v51 @ X0_v7 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv58 = v57 == 0;\n\tv59 = ~v58;\n\tif (v59) goto L_002A;\n\tv61 = \"il2cpp_codegen_runtime_class_init\"(v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002A:\n\tv64 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv68 = v64 + 0xF8;\n\tgoto L_0036;\nL_0036:\n\treturn *([v68 @ X8_v5 (System.String)]);\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				//IL_004d: Expected O, but got I
				Fsm executingFsm = ExecutingFsm;
				if (executingFsm != null)
				{
					Fsm executingFsm2 = ExecutingFsm;
					return (string)((long)(IntPtr)executingFsm2 + 248L);
				}
				return "[none]";
			}
		}

		[Token(Token = "0x1700005C")]
		public static FsmStateAction ExecutingAction
		{
			[Token(Token = "0x600016F")]
			[Address(RVA = "0xCAC054", Offset = "0xCAC054", Length = "0x8C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EBB4D0]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235D5]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\tv50 = v49 == 0;\n\tif (v50) goto L_0032;\n\tgoto L_002A;\n\tv64 = *([v51 @ X0_v6 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_002A;\n\tv68 = \"il2cpp_codegen_runtime_class_init\"(v51, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_002A:\n\tv70 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingState();\n\treturnVal1 = v70.activeAction;\nL_0032:\n\treturn returnVal1;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				FsmState executingState = ExecutingState;
				bool flag = executingState == null;
				FsmStateAction result = (FsmStateAction)(object)executingState;
				if (!flag)
				{
					FsmState executingState2 = ExecutingState;
					result = executingState2.ActiveAction;
				}
				return result;
			}
		}

		[Token(Token = "0x1700005D")]
		public static int StackCount
		{
			[Token(Token = "0x6000170")]
			[Address(RVA = "0xCAC0E0", Offset = "0xCAC0E0", Length = "0x78")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EB6BD0]);\n\tv15 = *([v14 @ X8_v9]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235D6]) = v35;\nL_0017:\n\tgoto L_001F;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001F;\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmExecutionStack;\nL_001F:\n\tv50 = v49.fsmExecutionStack;\n\treturn v50._size;\n\treturnVal2 = new System.NullReferenceException();\n\treturn returnVal2;\n// 26 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				Stack<Fsm> stack = fsmExecutionStack;
				return stack.Count;
			}
		}

		[Token(Token = "0x1700005E")]
		[field: Token(Token = "0x4000135")]
		public static int MaxStackCount
		{
			[Token(Token = "0x6000171")]
			[Address(RVA = "0xCAC158", Offset = "0xCAC158", Length = "0x68")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDA640]);\n\tv15 = *([v14 @ X8_v8]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235D7]) = v35;\nL_0017:\n\tgoto L_0024;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_0024;\n\tv54 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmExecutionStack;\nL_0024:\n\treturn v49.<MaxStackCount>k__BackingField;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get;
			[Token(Token = "0x6000172")]
			[Address(RVA = "0xCAC1C0", Offset = "0xCAC1C0", Length = "0x6C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv18 = *([1EAB7E0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20235D8]) = v38;\nL_0019:\n\tgoto L_0021;\n\tv45 = *([v41 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv46 = v45 == 0;\n\tv47 = ~v46;\n\tgoto L_0021;\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v41, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv49 = HutongGames.PlayMaker.FsmExecutionStack;\nL_0021:\n\tv52.<MaxStackCount>k__BackingField = value;\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			private set;
		}

		[Token(Token = "0x6000173")]
		[Address(RVA = "0xCAC22C", Offset = "0xCAC22C", Length = "0x16C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv20 = *([1EEAA48]);\n\tv21 = *([v20 @ X8_v35]);\n\tv22 = \"il2cpp_codegen_initialize_method\"(v21, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv40 = 0 | 1;\n\t*([20235D9]) = v40;\nL_001A:\n\tgoto L_0029;\n\tv47 = *([v43 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv48 = v47 == 0;\n\tv49 = ~v48;\n\t// 30 Jump @b30\n\tv57 = \"il2cpp_codegen_runtime_class_init\"(v43, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv51 = HutongGames.PlayMaker.FsmExecutionStack;\nL_0029:\n\tSystem.Collections.Generic.Stack`1<HutongGames.PlayMaker.Fsm>::Push(v54.fsmExecutionStack, executingFsm);\n\tv107 = v106.fsmExecutionStack;\n\tgoto L_003F;\n\tv159 = *([1EC1B20]);\n\tv160 = *([v159 @ X8_v30]);\n\tv161 = \"il2cpp_codegen_initialize_method\"(v160, v60, v61, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv163 = HutongGames.PlayMaker.FsmExecutionStack;\n\tv165 = 0 | 1;\n\t*([2023700]) = v165;\nL_003F:\n\tgoto L_0053;\n\tv169 = *([v162 @ X0_v11 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv170 = v169 == 0;\n\tv171 = ~v170;\n\tgoto L_0053;\n\tv181 = \"il2cpp_codegen_runtime_class_init\"(v162, v60, v61, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv173 = HutongGames.PlayMaker.FsmExecutionStack;\nL_0053:\n\tv114 = v107._size <= v176.<MaxStackCount>k__BackingField;\n\tif (v114) goto L_0082;\n\tgoto L_0060;\n\tv193 = *([v172 @ X0_v12 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv194 = v193 == 0;\n\tv195 = ~v194;\n\tif (v195) goto L_0060;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v172, v60, v61, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv196 = HutongGames.PlayMaker.FsmExecutionStack;\n\tv199 = *([v196 @ X0_v23+B8]);\nL_0060:\n\tv127 = v198.fsmExecutionStack;\n\tgoto L_0073;\n\tv204 = *([1EE8A08]);\n\tv205 = *([v204 @ X8_v25]);\n\tv206 = \"il2cpp_codegen_initialize_method\"(v205, v60, v61, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv208 = HutongGames.PlayMaker.FsmExecutionStack;\n\tv210 = 0 | 1;\n\t*([2023701]) = v210;\nL_0073:\n\tgoto L_007B;\n\tv214 = *([v207 @ X0_v15 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv215 = v214 == 0;\n\tv216 = ~v215;\n\tgoto L_007B;\n\tv219 = \"il2cpp_codegen_runtime_class_init\"(v207, v60, v61, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\n\tv217 = HutongGames.PlayMaker.FsmExecutionStack;\nL_007B:\n\tv192.<MaxStackCount>k__BackingField = v127._size;\nL_0082:\n\treturn;\n\tv97 = new System.NullReferenceException();\n\tthrow System.NullReferenceException;\n\treturn;\n// 76 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PushFsm(Fsm executingFsm)
		{
			fsmExecutionStack.Push(executingFsm);
			Stack<Fsm> stack = fsmExecutionStack;
			if (stack.Count > MaxStackCount)
			{
				Stack<Fsm> stack2 = fsmExecutionStack;
				MaxStackCount = stack2.Count;
			}
		}

		[Token(Token = "0x6000174")]
		[Address(RVA = "0xCAC398", Offset = "0xCAC398", Length = "0x7C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1F0A388]);\n\tv15 = *([v14 @ X8_v11]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235DA]) = v35;\nL_0017:\n\tgoto L_0029;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\t// 27 Jump @b13\n\tv52 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv46 = HutongGames.PlayMaker.FsmExecutionStack;\nL_0029:\n\tv59 = System.Collections.Generic.Stack`1<HutongGames.PlayMaker.Fsm>::Pop(v49.fsmExecutionStack);\n\treturn;\n\tthrow System.NullReferenceException;\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static void PopFsm()
		{
			Fsm fsm = fsmExecutionStack.Pop();
		}

		[Token(Token = "0x6000175")]
		[Address(RVA = "0xCAC414", Offset = "0xCAC414", Length = "0xA8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv14 = *([1EDFFF8]);\n\tv15 = *([v14 @ X8_v14]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235DB]) = v35;\nL_0017:\n\tgoto L_001D;\n\tv42 = *([v38 @ X0_v2 (Il2CppClass<HutongGames.PlayMaker.FsmExecutionStack>)+E0]);\n\tv43 = v42 == 0;\n\tv44 = ~v43;\n\tgoto L_001D;\n\tv46 = \"il2cpp_codegen_runtime_class_init\"(v38, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\nL_001D:\n\tv49 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingFsm();\n\tv59 = System.String::Concat(\"\", \"\\nExecutingFsm: \", v49);\n\tv61 = HutongGames.PlayMaker.FsmExecutionStack::get_ExecutingStateName();\n\treturnVal1 = System.String::Concat(v59, \"\\nExecutingState: \", v61);\n\treturn returnVal1;\n// 37 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string GetDebugString()
		{
			Fsm executingFsm = ExecutingFsm;
			string text = "" + "\nExecutingFsm: " + executingFsm;
			string executingStateName = ExecutingStateName;
			return text + "\nExecutingState: " + executingStateName;
		}

		[Token(Token = "0x6000176")]
		[Address(RVA = "0xCAC4BC", Offset = "0xCAC4BC", Length = "0x78")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv14 = *([1ECF6C0]);\n\tv15 = *([v14 @ X8_v12]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([20235DC]) = v35;\nL_0014:\n\tv39 = new System.Collections.Generic.Stack`1<HutongGames.PlayMaker.Fsm>();\n\tSystem.Collections.Generic.Stack`1<HutongGames.PlayMaker.Fsm>::.ctor(v39, 0x100);\n\tv48.fsmExecutionStack = v39;\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static FsmExecutionStack()
		{
			Stack<Fsm> stack = new Stack<Fsm>(256);
			fsmExecutionStack = stack;
		}
	}
}
