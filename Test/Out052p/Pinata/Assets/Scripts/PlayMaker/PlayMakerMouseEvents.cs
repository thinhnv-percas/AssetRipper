using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E774", Offset = "0x73E774")]
[Token(Token = "0x2000013")]
public class PlayMakerMouseEvents : PlayMakerProxyBase
{
	[Token(Token = "0x60000A1")]
	[Address(RVA = "0xE5B200", Offset = "0xE5B200", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EBABB0]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202482C]) = v50;\nL_0019:\n\tv136 = this.TargetFSMs;\nL_0030:\n\tv161 = v112 >= v136._size;\n\tif (v161) goto L_009D;\n\tv195 = v136._size < v112;\n\tv106 = ~v195;\n\tv103 = v136._size - v112;\n\tv97 = v103 == 0;\n\tv196 = ~v97;\n\tv82 = v106 & v196;\n\tif (v82) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv199 = v136._items;\n\tv71 = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0051;\n\tv204 = *([v200 @ X0_v8+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0051;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v135, v134, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0051:\n\tv117 = UnityEngine.Object::op_Equality(v199[v112 @ X22_v5 (System.Int32)], 0);\n\tv212 = v117 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_008B;\n\tv128 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\t*([v128 @ X8_v13+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv219 = *([v71 @ X21_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v219) goto L_008B;\n\t*([v222 @ X8_v14+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv129 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\tv220 = *([v129 @ X8_v15+139]) == 0;\n\tif (v220) goto L_008B;\n\t*([v129 @ X8_v15+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0075;\n\tv228 = *([v224 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0075;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0075:\n\tgoto L_007D;\n\tv238 = v58;\n\tv239 = \"il2cpp_codegen_initialize_method\"(v238, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20236B8]) = v62;\nL_007D:\n\tgoto L_008A;\n\tv245 = *([v241 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\t// 129 Jump @b33\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v241, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = HutongGames.PlayMaker.FsmEvent;\nL_008A:\n\tHutongGames.PlayMaker.Fsm::Event(*([v71 @ X21_v6 (UnityEngine.Object)+18]), v221.<MouseEnter>k__BackingField);\nL_008B:\n\tv136 = this.TargetFSMs;\n\tv112 = v112 + 1;\n\tv223 = this.TargetFSMs == 0;\n\tv120 = ~v223;\n\tif (v120) goto L_0030;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseEnter()
	{
		//IL_00f5: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_01a3: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		while (num < targetFSMs.Count)
		{
			bool flag = targetFSMs.Count < num;
			bool flag2 = !flag;
			int num2 = targetFSMs.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items = targetFSMs._items;
			UnityEngine.Object obj = items[num];
			if (!(items[num] == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v15+139]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.MouseEnter);
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
			if (TargetFSMs == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x60000A2")]
	[Address(RVA = "0xE5B384", Offset = "0xE5B384", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ECA158]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([202482D]) = v50;\nL_0019:\n\tv136 = this.TargetFSMs;\nL_0030:\n\tv161 = v112 >= v136._size;\n\tif (v161) goto L_009D;\n\tv195 = v136._size < v112;\n\tv106 = ~v195;\n\tv103 = v136._size - v112;\n\tv97 = v103 == 0;\n\tv196 = ~v97;\n\tv82 = v106 & v196;\n\tif (v82) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv199 = v136._items;\n\tv71 = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0051;\n\tv204 = *([v200 @ X0_v8+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0051;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v135, v134, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0051:\n\tv117 = UnityEngine.Object::op_Equality(v199[v112 @ X22_v5 (System.Int32)], 0);\n\tv212 = v117 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_008B;\n\tv128 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\t*([v128 @ X8_v13+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv219 = *([v71 @ X21_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v219) goto L_008B;\n\t*([v222 @ X8_v14+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv129 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\tv220 = *([v129 @ X8_v15+139]) == 0;\n\tif (v220) goto L_008B;\n\t*([v129 @ X8_v15+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0075;\n\tv228 = *([v224 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0075;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0075:\n\tgoto L_007D;\n\tv238 = v58;\n\tv239 = \"il2cpp_codegen_initialize_method\"(v238, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20236B6]) = v62;\nL_007D:\n\tgoto L_008A;\n\tv245 = *([v241 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\t// 129 Jump @b33\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v241, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = HutongGames.PlayMaker.FsmEvent;\nL_008A:\n\tHutongGames.PlayMaker.Fsm::Event(*([v71 @ X21_v6 (UnityEngine.Object)+18]), v221.<MouseDown>k__BackingField);\nL_008B:\n\tv136 = this.TargetFSMs;\n\tv112 = v112 + 1;\n\tv223 = this.TargetFSMs == 0;\n\tv120 = ~v223;\n\tif (v120) goto L_0030;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseDown()
	{
		//IL_00f5: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_01a3: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		while (num < targetFSMs.Count)
		{
			bool flag = targetFSMs.Count < num;
			bool flag2 = !flag;
			int num2 = targetFSMs.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items = targetFSMs._items;
			UnityEngine.Object obj = items[num];
			if (!(items[num] == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v15+139]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.MouseDown);
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
			if (TargetFSMs == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x60000A3")]
	[Address(RVA = "0xE5B508", Offset = "0xE5B508", Length = "0x20C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EA3428]);\n\tv35 = *([v34 @ X8_v36]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202482E]) = v54;\nL_001B:\n\tv147 = this.TargetFSMs;\nL_0037:\n\tv172 = v116 >= v147._size;\n\tif (v172) goto L_00CB;\n\tv210 = v147._size < v116;\n\tv110 = ~v210;\n\tv107 = v147._size - v116;\n\tv101 = v107 == 0;\n\tv211 = ~v101;\n\tv86 = v110 & v211;\n\tif (v86) goto L_0047;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0047:\n\tv214 = v147._items;\n\tv80 = v214[v116 @ X23_v5 (System.Int32)];\n\tgoto L_0058;\n\tv219 = *([v215 @ X0_v8+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_0058;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v215, v146, v145, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0058:\n\tv128 = UnityEngine.Object::op_Equality(v214[v116 @ X23_v5 (System.Int32)], 0);\n\tv227 = v128 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_00B7;\n\tv139 = *([v80 @ X22_v6 (UnityEngine.Object)+18]);\n\t*([v139 @ X8_v13+20]) = v214[v116 @ X23_v5 (System.Int32)];\n\tv237 = *([v80 @ X22_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v237) goto L_00B7;\n\t*([v240 @ X8_v14+20]) = v214[v116 @ X23_v5 (System.Int32)];\n\tv140 = *([v80 @ X22_v6 (UnityEngine.Object)+18]);\n\tv238 = *([v140 @ X8_v15+139]) == 0;\n\tif (v238) goto L_00B7;\n\t*([v140 @ X8_v15+20]) = v214[v116 @ X23_v5 (System.Int32)];\n\tgoto L_007C;\n\tv246 = *([v242 @ X0_v13+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_007C;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v242, v77, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_007C:\n\tgoto L_0085;\n\tv256 = v66;\n\tv257 = \"il2cpp_codegen_initialize_method\"(v256, v77, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv260 = 0 | 1;\n\t*([20236BB]) = v260;\nL_0085:\n\tgoto L_0092;\n\tv265 = *([v261 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\t// 137 Jump @b43\n\tv270 = \"il2cpp_codegen_runtime_class_init\"(v261, v77, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv268 = HutongGames.PlayMaker.FsmEvent;\nL_0092:\n\tHutongGames.PlayMaker.Fsm::Event(*([v80 @ X22_v6 (UnityEngine.Object)+18]), v271.<MouseUp>k__BackingField);\n\tv275 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00A5;\n\tv280 = *([v276 @ X8_v23+E0]);\n\tv281 = v280 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_00A5;\n\tv289 = v276;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v289, v230, v229, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00A5:\n\tgoto L_00AE;\n\tv290 = v67;\n\tv291 = \"il2cpp_codegen_initialize_method\"(v290, v230, v229, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv294 = 0 | 1;\n\t*([202486E]) = v294;\nL_00AE:\n\tgoto L_00B6;\n\tv299 = *([v295 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tgoto L_00B6;\n\tv304 = \"il2cpp_codegen_runtime_class_init\"(v295, v230, v229, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv302 = HutongGames.PlayMaker.Fsm;\nL_00B6:\n\tv239.<LastClickedObject>k__BackingField = v275;\nL_00B7:\n\tv147 = this.TargetFSMs;\n\tv116 = v116 + 1;\n\tv241 = this.TargetFSMs == 0;\n\tv131 = ~v241;\n\tif (v131) goto L_0037;\n\tthrow System.NullReferenceException;\nL_00CB:\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseUp()
	{
		//IL_00f5: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_01a3: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		while (num < targetFSMs.Count)
		{
			bool flag = targetFSMs.Count < num;
			bool flag2 = !flag;
			int num2 = targetFSMs.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items = targetFSMs._items;
			UnityEngine.Object obj = items[num];
			if (!(items[num] == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v15+139]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.MouseUp);
						GameObject _003CLastClickedObject_003Ek__BackingField = base.gameObject;
						Fsm.LastClickedObject = _003CLastClickedObject_003Ek__BackingField;
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
			if (TargetFSMs == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x60000A4")]
	[Address(RVA = "0xE5B714", Offset = "0xE5B714", Length = "0x20C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv34 = *([1EF47C0]);\n\tv35 = *([v34 @ X8_v36]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv54 = 0 | 1;\n\t*([202482F]) = v54;\nL_001B:\n\tv147 = this.TargetFSMs;\nL_0037:\n\tv172 = v116 >= v147._size;\n\tif (v172) goto L_00CB;\n\tv210 = v147._size < v116;\n\tv110 = ~v210;\n\tv107 = v147._size - v116;\n\tv101 = v107 == 0;\n\tv211 = ~v101;\n\tv86 = v110 & v211;\n\tif (v86) goto L_0047;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0047:\n\tv214 = v147._items;\n\tv80 = v214[v116 @ X23_v5 (System.Int32)];\n\tgoto L_0058;\n\tv219 = *([v215 @ X0_v8+E0]);\n\tv220 = v219 == 0;\n\tv221 = ~v220;\n\tif (v221) goto L_0058;\n\tv223 = \"il2cpp_codegen_runtime_class_init\"(v215, v146, v145, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_0058:\n\tv128 = UnityEngine.Object::op_Equality(v214[v116 @ X23_v5 (System.Int32)], 0);\n\tv227 = v128 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_00B7;\n\tv139 = *([v80 @ X22_v6 (UnityEngine.Object)+18]);\n\t*([v139 @ X8_v13+20]) = v214[v116 @ X23_v5 (System.Int32)];\n\tv237 = *([v80 @ X22_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v237) goto L_00B7;\n\t*([v240 @ X8_v14+20]) = v214[v116 @ X23_v5 (System.Int32)];\n\tv140 = *([v80 @ X22_v6 (UnityEngine.Object)+18]);\n\tv238 = *([v140 @ X8_v15+139]) == 0;\n\tif (v238) goto L_00B7;\n\t*([v140 @ X8_v15+20]) = v214[v116 @ X23_v5 (System.Int32)];\n\tgoto L_007C;\n\tv246 = *([v242 @ X0_v13+E0]);\n\tv247 = v246 == 0;\n\tv248 = ~v247;\n\tif (v248) goto L_007C;\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v242, v77, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_007C:\n\tgoto L_0085;\n\tv256 = v66;\n\tv257 = \"il2cpp_codegen_initialize_method\"(v256, v77, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv260 = 0 | 1;\n\t*([20236BC]) = v260;\nL_0085:\n\tgoto L_0092;\n\tv265 = *([v261 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv266 = v265 == 0;\n\tv267 = ~v266;\n\t// 137 Jump @b43\n\tv270 = \"il2cpp_codegen_runtime_class_init\"(v261, v77, v74, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv268 = HutongGames.PlayMaker.FsmEvent;\nL_0092:\n\tHutongGames.PlayMaker.Fsm::Event(*([v80 @ X22_v6 (UnityEngine.Object)+18]), v271.<MouseUpAsButton>k__BackingField);\n\tv275 = UnityEngine.Component::get_gameObject(this);\n\tgoto L_00A5;\n\tv280 = *([v276 @ X8_v23+E0]);\n\tv281 = v280 == 0;\n\tv282 = ~v281;\n\tif (v282) goto L_00A5;\n\tv289 = v276;\n\tv284 = \"il2cpp_codegen_runtime_class_init\"(v289, v230, v229, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\nL_00A5:\n\tgoto L_00AE;\n\tv290 = v67;\n\tv291 = \"il2cpp_codegen_initialize_method\"(v290, v230, v229, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv294 = 0 | 1;\n\t*([202486E]) = v294;\nL_00AE:\n\tgoto L_00B6;\n\tv299 = *([v295 @ X0_v23 (Il2CppClass<HutongGames.PlayMaker.Fsm>)+E0]);\n\tv300 = v299 == 0;\n\tv301 = ~v300;\n\tgoto L_00B6;\n\tv304 = \"il2cpp_codegen_runtime_class_init\"(v295, v230, v229, v39, v40, v41, v42, v43, v44, v45, v46, v47, v48, v49, v50, v51);\n\tv302 = HutongGames.PlayMaker.Fsm;\nL_00B6:\n\tv239.<LastClickedObject>k__BackingField = v275;\nL_00B7:\n\tv147 = this.TargetFSMs;\n\tv116 = v116 + 1;\n\tv241 = this.TargetFSMs == 0;\n\tv131 = ~v241;\n\tif (v131) goto L_0037;\n\tthrow System.NullReferenceException;\nL_00CB:\n\treturn;\n// 119 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseUpAsButton()
	{
		//IL_00f5: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_01a3: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		while (num < targetFSMs.Count)
		{
			bool flag = targetFSMs.Count < num;
			bool flag2 = !flag;
			int num2 = targetFSMs.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items = targetFSMs._items;
			UnityEngine.Object obj = items[num];
			if (!(items[num] == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v140 @ X8_v15+139]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v80 @ X22_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.MouseUpAsButton);
						GameObject _003CLastClickedObject_003Ek__BackingField = base.gameObject;
						Fsm.LastClickedObject = _003CLastClickedObject_003Ek__BackingField;
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
			if (TargetFSMs == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x60000A5")]
	[Address(RVA = "0xE5B920", Offset = "0xE5B920", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EC74B8]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2024830]) = v50;\nL_0019:\n\tv136 = this.TargetFSMs;\nL_0030:\n\tv161 = v112 >= v136._size;\n\tif (v161) goto L_009D;\n\tv195 = v136._size < v112;\n\tv106 = ~v195;\n\tv103 = v136._size - v112;\n\tv97 = v103 == 0;\n\tv196 = ~v97;\n\tv82 = v106 & v196;\n\tif (v82) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv199 = v136._items;\n\tv71 = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0051;\n\tv204 = *([v200 @ X0_v8+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0051;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v135, v134, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0051:\n\tv117 = UnityEngine.Object::op_Equality(v199[v112 @ X22_v5 (System.Int32)], 0);\n\tv212 = v117 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_008B;\n\tv128 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\t*([v128 @ X8_v13+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv219 = *([v71 @ X21_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v219) goto L_008B;\n\t*([v222 @ X8_v14+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv129 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\tv220 = *([v129 @ X8_v15+139]) == 0;\n\tif (v220) goto L_008B;\n\t*([v129 @ X8_v15+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0075;\n\tv228 = *([v224 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0075;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0075:\n\tgoto L_007D;\n\tv238 = v58;\n\tv239 = \"il2cpp_codegen_initialize_method\"(v238, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20236B9]) = v62;\nL_007D:\n\tgoto L_008A;\n\tv245 = *([v241 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\t// 129 Jump @b33\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v241, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = HutongGames.PlayMaker.FsmEvent;\nL_008A:\n\tHutongGames.PlayMaker.Fsm::Event(*([v71 @ X21_v6 (UnityEngine.Object)+18]), v221.<MouseExit>k__BackingField);\nL_008B:\n\tv136 = this.TargetFSMs;\n\tv112 = v112 + 1;\n\tv223 = this.TargetFSMs == 0;\n\tv120 = ~v223;\n\tif (v120) goto L_0030;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseExit()
	{
		//IL_00f5: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_01a3: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		while (num < targetFSMs.Count)
		{
			bool flag = targetFSMs.Count < num;
			bool flag2 = !flag;
			int num2 = targetFSMs.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items = targetFSMs._items;
			UnityEngine.Object obj = items[num];
			if (!(items[num] == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v15+139]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.MouseExit);
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
			if (TargetFSMs == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x60000A6")]
	[Address(RVA = "0xE5BAA4", Offset = "0xE5BAA4", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EFA438]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2024831]) = v50;\nL_0019:\n\tv136 = this.TargetFSMs;\nL_0030:\n\tv161 = v112 >= v136._size;\n\tif (v161) goto L_009D;\n\tv195 = v136._size < v112;\n\tv106 = ~v195;\n\tv103 = v136._size - v112;\n\tv97 = v103 == 0;\n\tv196 = ~v97;\n\tv82 = v106 & v196;\n\tif (v82) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv199 = v136._items;\n\tv71 = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0051;\n\tv204 = *([v200 @ X0_v8+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0051;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v135, v134, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0051:\n\tv117 = UnityEngine.Object::op_Equality(v199[v112 @ X22_v5 (System.Int32)], 0);\n\tv212 = v117 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_008B;\n\tv128 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\t*([v128 @ X8_v13+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv219 = *([v71 @ X21_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v219) goto L_008B;\n\t*([v222 @ X8_v14+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv129 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\tv220 = *([v129 @ X8_v15+139]) == 0;\n\tif (v220) goto L_008B;\n\t*([v129 @ X8_v15+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0075;\n\tv228 = *([v224 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0075;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0075:\n\tgoto L_007D;\n\tv238 = v58;\n\tv239 = \"il2cpp_codegen_initialize_method\"(v238, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20236B7]) = v62;\nL_007D:\n\tgoto L_008A;\n\tv245 = *([v241 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\t// 129 Jump @b33\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v241, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = HutongGames.PlayMaker.FsmEvent;\nL_008A:\n\tHutongGames.PlayMaker.Fsm::Event(*([v71 @ X21_v6 (UnityEngine.Object)+18]), v221.<MouseDrag>k__BackingField);\nL_008B:\n\tv136 = this.TargetFSMs;\n\tv112 = v112 + 1;\n\tv223 = this.TargetFSMs == 0;\n\tv120 = ~v223;\n\tif (v120) goto L_0030;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseDrag()
	{
		//IL_00f5: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_01a3: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		while (num < targetFSMs.Count)
		{
			bool flag = targetFSMs.Count < num;
			bool flag2 = !flag;
			int num2 = targetFSMs.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items = targetFSMs._items;
			UnityEngine.Object obj = items[num];
			if (!(items[num] == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v15+139]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.MouseDrag);
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
			if (TargetFSMs == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x60000A7")]
	[Address(RVA = "0xE5BC28", Offset = "0xE5BC28", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1ED3278]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([2024832]) = v50;\nL_0019:\n\tv136 = this.TargetFSMs;\nL_0030:\n\tv161 = v112 >= v136._size;\n\tif (v161) goto L_009D;\n\tv195 = v136._size < v112;\n\tv106 = ~v195;\n\tv103 = v136._size - v112;\n\tv97 = v103 == 0;\n\tv196 = ~v97;\n\tv82 = v106 & v196;\n\tif (v82) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv199 = v136._items;\n\tv71 = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0051;\n\tv204 = *([v200 @ X0_v8+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0051;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v135, v134, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0051:\n\tv117 = UnityEngine.Object::op_Equality(v199[v112 @ X22_v5 (System.Int32)], 0);\n\tv212 = v117 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_008B;\n\tv128 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\t*([v128 @ X8_v13+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv219 = *([v71 @ X21_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v219) goto L_008B;\n\t*([v222 @ X8_v14+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv129 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\tv220 = *([v129 @ X8_v15+139]) == 0;\n\tif (v220) goto L_008B;\n\t*([v129 @ X8_v15+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0075;\n\tv228 = *([v224 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0075;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0075:\n\tgoto L_007D;\n\tv238 = v58;\n\tv239 = \"il2cpp_codegen_initialize_method\"(v238, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20236BA]) = v62;\nL_007D:\n\tgoto L_008A;\n\tv245 = *([v241 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\t// 129 Jump @b33\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v241, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = HutongGames.PlayMaker.FsmEvent;\nL_008A:\n\tHutongGames.PlayMaker.Fsm::Event(*([v71 @ X21_v6 (UnityEngine.Object)+18]), v221.<MouseOver>k__BackingField);\nL_008B:\n\tv136 = this.TargetFSMs;\n\tv112 = v112 + 1;\n\tv223 = this.TargetFSMs == 0;\n\tv120 = ~v223;\n\tif (v120) goto L_0030;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnMouseOver()
	{
		//IL_00f5: Expected O, but got I
		//IL_014b: Expected O, but got I
		//IL_01a3: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		while (num < targetFSMs.Count)
		{
			bool flag = targetFSMs.Count < num;
			bool flag2 = !flag;
			int num2 = targetFSMs.Count - num;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				throw new ArgumentOutOfRangeException();
			}
			PlayMakerFSM[] items = targetFSMs._items;
			UnityEngine.Object obj = items[num];
			if (!(items[num] == null))
			{
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0)
				{
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
					object obj3 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v15+139]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.MouseOver);
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
			if (TargetFSMs == null)
			{
				throw new NullReferenceException();
			}
		}
	}

	[Token(Token = "0x60000A8")]
	[Address(RVA = "0xE5BDAC", Offset = "0xE5BDAC", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::.ctor(this);\n\treturn;\n")]
	public PlayMakerMouseEvents()
	{
	}
}
