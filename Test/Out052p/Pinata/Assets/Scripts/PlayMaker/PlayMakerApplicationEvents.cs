using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E4C0", Offset = "0x73E4C0")]
[Token(Token = "0x2000006")]
public class PlayMakerApplicationEvents : PlayMakerProxyBase
{
	[Token(Token = "0x600001C")]
	[Address(RVA = "0xE5428C", Offset = "0xE5428C", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EBB880]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20247CC]) = v50;\nL_0019:\n\tv136 = this.TargetFSMs;\nL_0030:\n\tv161 = v112 >= v136._size;\n\tif (v161) goto L_009D;\n\tv195 = v136._size < v112;\n\tv106 = ~v195;\n\tv103 = v136._size - v112;\n\tv97 = v103 == 0;\n\tv196 = ~v97;\n\tv82 = v106 & v196;\n\tif (v82) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv199 = v136._items;\n\tv71 = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0051;\n\tv204 = *([v200 @ X0_v8+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0051;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v135, v134, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0051:\n\tv117 = UnityEngine.Object::op_Equality(v199[v112 @ X22_v5 (System.Int32)], 0);\n\tv212 = v117 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_008B;\n\tv128 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\t*([v128 @ X8_v13+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv219 = *([v71 @ X21_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v219) goto L_008B;\n\t*([v222 @ X8_v14+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv129 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\tv220 = *([v129 @ X8_v15+14E]) == 0;\n\tif (v220) goto L_008B;\n\t*([v129 @ X8_v15+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0075;\n\tv228 = *([v224 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0075;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0075:\n\tgoto L_007D;\n\tv238 = v58;\n\tv239 = \"il2cpp_codegen_initialize_method\"(v238, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20236BD]) = v62;\nL_007D:\n\tgoto L_008A;\n\tv245 = *([v241 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\t// 129 Jump @b33\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v241, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = HutongGames.PlayMaker.FsmEvent;\nL_008A:\n\tHutongGames.PlayMaker.Fsm::Event(*([v71 @ X21_v6 (UnityEngine.Object)+18]), v221.<ApplicationFocus>k__BackingField);\nL_008B:\n\tv136 = this.TargetFSMs;\n\tv112 = v112 + 1;\n\tv223 = this.TargetFSMs == 0;\n\tv120 = ~v223;\n\tif (v120) goto L_0030;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnApplicationFocus()
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v15+14E]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.ApplicationFocus);
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

	[Token(Token = "0x600001D")]
	[Address(RVA = "0xE54410", Offset = "0xE54410", Length = "0x184")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0019;\n\tv30 = *([1EB4A00]);\n\tv31 = *([v30 @ X8_v26]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, methodInfo, v34, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20247CD]) = v50;\nL_0019:\n\tv136 = this.TargetFSMs;\nL_0030:\n\tv161 = v112 >= v136._size;\n\tif (v161) goto L_009D;\n\tv195 = v136._size < v112;\n\tv106 = ~v195;\n\tv103 = v136._size - v112;\n\tv97 = v103 == 0;\n\tv196 = ~v97;\n\tv82 = v106 & v196;\n\tif (v82) goto L_0040;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0040:\n\tv199 = v136._items;\n\tv71 = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0051;\n\tv204 = *([v200 @ X0_v8+E0]);\n\tv205 = v204 == 0;\n\tv206 = ~v205;\n\tif (v206) goto L_0051;\n\tv208 = \"il2cpp_codegen_runtime_class_init\"(v200, v135, v134, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0051:\n\tv117 = UnityEngine.Object::op_Equality(v199[v112 @ X22_v5 (System.Int32)], 0);\n\tv212 = v117 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_008B;\n\tv128 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\t*([v128 @ X8_v13+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv219 = *([v71 @ X21_v6 (UnityEngine.Object)+18]) == 0;\n\tif (v219) goto L_008B;\n\t*([v222 @ X8_v14+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tv129 = *([v71 @ X21_v6 (UnityEngine.Object)+18]);\n\tv220 = *([v129 @ X8_v15+14E]) == 0;\n\tif (v220) goto L_008B;\n\t*([v129 @ X8_v15+20]) = v199[v112 @ X22_v5 (System.Int32)];\n\tgoto L_0075;\n\tv228 = *([v224 @ X0_v13+E0]);\n\tv229 = v228 == 0;\n\tv230 = ~v229;\n\tif (v230) goto L_0075;\n\tv232 = \"il2cpp_codegen_runtime_class_init\"(v224, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\nL_0075:\n\tgoto L_007D;\n\tv238 = v58;\n\tv239 = \"il2cpp_codegen_initialize_method\"(v238, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\t*([20236BE]) = v62;\nL_007D:\n\tgoto L_008A;\n\tv245 = *([v241 @ X0_v16 (Il2CppClass<HutongGames.PlayMaker.FsmEvent>)+E0]);\n\tv246 = v245 == 0;\n\tv247 = ~v246;\n\t// 129 Jump @b33\n\tv250 = \"il2cpp_codegen_runtime_class_init\"(v241, v68, v65, v35, v36, v37, v38, v39, v40, v41, v42, v43, v44, v45, v46, v47);\n\tv248 = HutongGames.PlayMaker.FsmEvent;\nL_008A:\n\tHutongGames.PlayMaker.Fsm::Event(*([v71 @ X21_v6 (UnityEngine.Object)+18]), v221.<ApplicationPause>k__BackingField);\nL_008B:\n\tv136 = this.TargetFSMs;\n\tv112 = v112 + 1;\n\tv223 = this.TargetFSMs == 0;\n\tv120 = ~v223;\n\tif (v120) goto L_0030;\n\tthrow System.NullReferenceException;\nL_009D:\n\treturn;\n// 95 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnApplicationPause()
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v129 @ X8_v15+14E]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v71 @ X21_v6 (UnityEngine.Object)+18]");
						((Fsm)0).Event(FsmEvent.ApplicationPause);
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

	[Token(Token = "0x600001E")]
	[Address(RVA = "0xE54594", Offset = "0xE54594", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::.ctor(this);\n\treturn;\n")]
	public PlayMakerApplicationEvents()
	{
	}
}
