using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E948", Offset = "0x73E948")]
[Token(Token = "0x200001C")]
public class PlayMakerParticleCollision : PlayMakerProxyBase
{
	[Token(Token = "0x60000E0")]
	[Address(RVA = "0xE5C0A0", Offset = "0xE5C0A0", Length = "0x128")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1F02020]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, other, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([2024836]) = v45;\nL_0017:\n\tv131 = this.TargetFSMs;\nL_0027:\n\tv142 = v93 >= v131._size;\n\tif (v142) goto L_007B;\n\tv166 = v131._size < v93;\n\tv89 = ~v166;\n\tv86 = v131._size - v93;\n\tv80 = v86 == 0;\n\tv167 = ~v80;\n\tv65 = v89 & v167;\n\tif (v65) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv196 = v131._items;\n\tv113 = v196[v93 @ X22_v6 (System.Int32)];\n\tgoto L_0048;\n\tv201 = *([v197 @ X0_v9+E0]);\n\tv202 = v201 == 0;\n\tv203 = ~v202;\n\tif (v203) goto L_0048;\n\tv205 = \"il2cpp_codegen_runtime_class_init\"(v197, v116, v115, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0048:\n\tv97 = UnityEngine.Object::op_Equality(v196[v93 @ X22_v6 (System.Int32)], 0);\n\tv209 = v97 == 0;\n\tv210 = ~v209;\n\tif (v210) goto L_006C;\n\tv108 = *([v113 @ X21_v8 (UnityEngine.Object)+18]);\n\t*([v108 @ X8_v12+20]) = v196[v93 @ X22_v6 (System.Int32)];\n\tv214 = *([v113 @ X21_v8 (UnityEngine.Object)+18]) == 0;\n\tif (v214) goto L_006C;\n\tv98 = PlayMakerFSM::get_Active(v196[v93 @ X22_v6 (System.Int32)]);\n\tv215 = v98 == 0;\n\tif (v215) goto L_006C;\n\tv109 = *([v113 @ X21_v8 (UnityEngine.Object)+18]);\n\t*([v109 @ X8_v14+20]) = v196[v93 @ X22_v6 (System.Int32)];\n\tv110 = *([v113 @ X21_v8 (UnityEngine.Object)+18]);\n\tv216 = *([v110 @ X8_v15+147]) == 0;\n\tif (v216) goto L_006C;\n\t*([v110 @ X8_v15+20]) = v196[v93 @ X22_v6 (System.Int32)];\n\tHutongGames.PlayMaker.Fsm::OnParticleCollision(*([v113 @ X21_v8 (UnityEngine.Object)+18]), other);\nL_006C:\n\tv131 = this.TargetFSMs;\n\tv93 = v93 + 1;\n\tv218 = this.TargetFSMs == 0;\n\tv100 = ~v218;\n\tif (v100) goto L_0027;\n\tthrow System.NullReferenceException;\nL_007B:\n\treturn;\n// 74 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnParticleCollision(GameObject other)
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
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v8 (UnityEngine.Object)+18]");
				object obj2 = 0;
				_ = items[num];
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v8 (UnityEngine.Object)+18]");
				if ((IntPtr)0 != (IntPtr)0 && items[num].Active)
				{
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v8 (UnityEngine.Object)+18]");
					object obj3 = 0;
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v8 (UnityEngine.Object)+18]");
					object obj4 = 0;
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X8_v15+147]");
					if ((IntPtr)0 != (IntPtr)0)
					{
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v8 (UnityEngine.Object)+18]");
						((Fsm)0).OnParticleCollision(other);
					}
				}
			}
			targetFSMs = TargetFSMs;
			num++;
		}
		while (TargetFSMs != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60000E1")]
	[Address(RVA = "0xE5C1C8", Offset = "0xE5C1C8", Length = "0x4")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::.ctor(this);\n\treturn;\n")]
	public PlayMakerParticleCollision()
	{
	}
}
