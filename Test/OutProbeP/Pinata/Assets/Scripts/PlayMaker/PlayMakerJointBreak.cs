using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E980", Offset = "0x73E980")]
[Token(Token = "0x200001D")]
public class PlayMakerJointBreak : PlayMakerProxyBase
{
	[Token(Token = "0x60000E2")]
	[Address(RVA = "0xE5AE8C", Offset = "0xE5AE8C", Length = "0x128")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EC76C0]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, methodInfo, v30, v31, v32, v33, v34, v35, breakForce, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024829]) = v45;\nL_0017:\n\tv133 = this.TargetFSMs;\nL_0027:\n\tv144 = v95 >= v133._size;\n\tif (v144) goto L_007B;\n\tv169 = v133._size < v95;\n\tv91 = ~v169;\n\tv88 = v133._size - v95;\n\tv82 = v88 == 0;\n\tv170 = ~v82;\n\tv67 = v91 & v170;\n\tif (v67) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv200 = v133._items;\n\tv115 = v200[v95 @ X21_v6 (System.Int32)];\n\tgoto L_0048;\n\tv205 = *([v201 @ X0_v9+E0]);\n\tv206 = v205 == 0;\n\tv207 = ~v206;\n\tif (v207) goto L_0048;\n\tv209 = \"il2cpp_codegen_runtime_class_init\"(v201, v118, v117, v31, v32, v33, v34, v35, v53, v36, v37, v38, v39, v40, v41, v42);\nL_0048:\n\tv99 = UnityEngine.Object::op_Equality(v200[v95 @ X21_v6 (System.Int32)], 0);\n\tv213 = v99 == 0;\n\tv214 = ~v213;\n\tif (v214) goto L_006C;\n\tv110 = *([v115 @ X20_v8 (UnityEngine.Object)+18]);\n\t*([v110 @ X8_v12+20]) = v200[v95 @ X21_v6 (System.Int32)];\n\tv218 = *([v115 @ X20_v8 (UnityEngine.Object)+18]) == 0;\n\tif (v218) goto L_006C;\n\tv100 = PlayMakerFSM::get_Active(v200[v95 @ X21_v6 (System.Int32)]);\n\tv219 = v100 == 0;\n\tif (v219) goto L_006C;\n\tv111 = *([v115 @ X20_v8 (UnityEngine.Object)+18]);\n\t*([v111 @ X8_v14+20]) = v200[v95 @ X21_v6 (System.Int32)];\n\tv112 = *([v115 @ X20_v8 (UnityEngine.Object)+18]);\n\tv220 = *([v112 @ X8_v15+149]) == 0;\n\tif (v220) goto L_006C;\n\t*([v112 @ X8_v15+20]) = v200[v95 @ X21_v6 (System.Int32)];\n\tHutongGames.PlayMaker.Fsm::OnJointBreak(*([v115 @ X20_v8 (UnityEngine.Object)+18]), breakForce);\nL_006C:\n\tv133 = this.TargetFSMs;\n\tv95 = v95 + 1;\n\tv222 = this.TargetFSMs == 0;\n\tv102 = ~v222;\n\tif (v102) goto L_0027;\n\tthrow System.NullReferenceException;\nL_007B:\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnJointBreak(float breakForce)
	{
		//IL_00f5: Expected O, but got I
		//IL_0170: Expected O, but got I
		//IL_0193: Expected O, but got I
		//IL_01e5: Expected O, but got I
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X20_v8 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X20_v8 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0 && items[num].Active)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X20_v8 (UnityEngine.Object)+18]");
					object obj3 = 0;
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X20_v8 (UnityEngine.Object)+18]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v112 @ X8_v15+149]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v115 @ X20_v8 (UnityEngine.Object)+18]");
						((Fsm)0).OnJointBreak(breakForce);
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
		}
		while (TargetFSMs != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60000E3")]
	[Address(RVA = "0xE5AFB4", Offset = "0xE5AFB4", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::.ctor(this);\n\treturn;\n")]
	public PlayMakerJointBreak()
	{
	}
}
