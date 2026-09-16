using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E6B8", Offset = "0x73E6B8")]
[Token(Token = "0x200000F")]
public class PlayMakerLateUpdate : PlayMakerProxyBase
{
	[Token(Token = "0x600002F")]
	[Address(RVA = "0xE5B0E4", Offset = "0xE5B0E4", Length = "0x118")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv22 = *([1ED0138]);\n\tv23 = *([v22 @ X8_v18]);\n\tv24 = \"il2cpp_codegen_initialize_method\"(v23, methodInfo, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\n\tv42 = 0 | 1;\n\t*([202482B]) = v42;\nL_0015:\n\tv127 = this.TargetFSMs;\nL_0025:\n\tv138 = v89 >= v127._size;\n\tif (v138) goto L_0077;\n\tv162 = v127._size < v89;\n\tv85 = ~v162;\n\tv82 = v127._size - v89;\n\tv76 = v82 == 0;\n\tv163 = ~v76;\n\tv61 = v85 & v163;\n\tif (v61) goto L_0035;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0035:\n\tv191 = v127._items;\n\tv109 = v191[v89 @ X21_v6 (System.Int32)];\n\tgoto L_0046;\n\tv196 = *([v192 @ X0_v9+E0]);\n\tv197 = v196 == 0;\n\tv198 = ~v197;\n\tif (v198) goto L_0046;\n\tv200 = \"il2cpp_codegen_runtime_class_init\"(v192, v112, v111, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39);\nL_0046:\n\tv93 = UnityEngine.Object::op_Equality(v191[v89 @ X21_v6 (System.Int32)], 0);\n\tv204 = v93 == 0;\n\tv205 = ~v204;\n\tif (v205) goto L_0069;\n\tv104 = *([v109 @ X20_v8 (UnityEngine.Object)+18]);\n\t*([v104 @ X8_v12+20]) = v191[v89 @ X21_v6 (System.Int32)];\n\tv208 = *([v109 @ X20_v8 (UnityEngine.Object)+18]) == 0;\n\tif (v208) goto L_0069;\n\tv94 = PlayMakerFSM::get_Active(v191[v89 @ X21_v6 (System.Int32)]);\n\tv209 = v94 == 0;\n\tif (v209) goto L_0069;\n\tv105 = *([v109 @ X20_v8 (UnityEngine.Object)+18]);\n\t*([v105 @ X8_v14+20]) = v191[v89 @ X21_v6 (System.Int32)];\n\tv106 = *([v109 @ X20_v8 (UnityEngine.Object)+18]);\n\tv210 = *([v106 @ X8_v15+14D]) == 0;\n\tif (v210) goto L_0069;\n\t*([v106 @ X8_v15+20]) = v191[v89 @ X21_v6 (System.Int32)];\n\tHutongGames.PlayMaker.Fsm::LateUpdate(*([v109 @ X20_v8 (UnityEngine.Object)+18]));\nL_0069:\n\tv127 = this.TargetFSMs;\n\tv89 = v89 + 1;\n\tv212 = this.TargetFSMs == 0;\n\tv96 = ~v212;\n\tif (v96) goto L_0025;\n\tthrow System.NullReferenceException;\nL_0077:\n\treturn;\n// 70 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void LateUpdate()
	{
		//IL_00f5: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_0193: Expected O, but got I
		//IL_01e1: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		do
		{
			if (num >= targetFSMs.Count)
			{
				return;
			}
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X20_v8 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X20_v8 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0 && items[num].Active)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X20_v8 (UnityEngine.Object)+18]");
					object obj3 = 0;
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X20_v8 (UnityEngine.Object)+18]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v106 @ X8_v15+14D]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v109 @ X20_v8 (UnityEngine.Object)+18]");
						((Fsm)0).LateUpdate();
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
		}
		while (TargetFSMs != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x6000030")]
	[Address(RVA = "0xE5B1FC", Offset = "0xE5B1FC", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::.ctor(this);\n\treturn;\n")]
	public PlayMakerLateUpdate()
	{
	}
}
