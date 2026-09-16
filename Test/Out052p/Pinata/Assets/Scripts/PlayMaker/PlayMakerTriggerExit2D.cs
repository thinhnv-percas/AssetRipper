using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E8A0", Offset = "0x73E8A0")]
[Token(Token = "0x2000019")]
public class PlayMakerTriggerExit2D : PlayMakerProxyBase
{
	[Token(Token = "0x60000DA")]
	[Address(RVA = "0xE5FF0C", Offset = "0xE5FF0C", Length = "0x148")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1EE78B0]);\n\tv27 = *([v26 @ X8_v18]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, other, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202485C]) = v45;\nL_0017:\n\tv131 = this.TargetFSMs;\nL_0027:\n\tv142 = v93 >= v131._size;\n\tif (v142) goto L_0074;\n\tv166 = v131._size < v93;\n\tv89 = ~v166;\n\tv86 = v131._size - v93;\n\tv80 = v86 == 0;\n\tv167 = ~v80;\n\tv65 = v89 & v167;\n\tif (v65) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv191 = v131._items;\n\tv113 = v191[v93 @ X22_v8 (System.Int32)];\n\tgoto L_0048;\n\tv211 = *([v192 @ X0_v10+E0]);\n\tv212 = v211 == 0;\n\tv213 = ~v212;\n\tif (v213) goto L_0048;\n\tv215 = \"il2cpp_codegen_runtime_class_init\"(v192, v116, v115, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0048:\n\tv97 = UnityEngine.Object::op_Equality(v191[v93 @ X22_v8 (System.Int32)], 0);\n\tv227 = v97 == 0;\n\tv228 = ~v227;\n\tif (v228) goto L_006C;\n\tv108 = *([v113 @ X21_v10 (UnityEngine.Object)+18]);\n\t*([v108 @ X8_v12+20]) = v191[v93 @ X22_v8 (System.Int32)];\n\tv232 = *([v113 @ X21_v10 (UnityEngine.Object)+18]) == 0;\n\tif (v232) goto L_006C;\n\tv98 = PlayMakerFSM::get_Active(v191[v93 @ X22_v8 (System.Int32)]);\n\tv233 = v98 == 0;\n\tif (v233) goto L_006C;\n\tv109 = *([v113 @ X21_v10 (UnityEngine.Object)+18]);\n\t*([v109 @ X8_v14+20]) = v191[v93 @ X22_v8 (System.Int32)];\n\tv110 = *([v113 @ X21_v10 (UnityEngine.Object)+18]);\n\tv234 = *([v110 @ X8_v15+13C]) == 0;\n\tif (v234) goto L_006C;\n\t*([v110 @ X8_v15+20]) = v191[v93 @ X22_v8 (System.Int32)];\n\tHutongGames.PlayMaker.Fsm::OnTriggerExit2D(*([v113 @ X21_v10 (UnityEngine.Object)+18]), other);\nL_006C:\n\tv131 = this.TargetFSMs;\n\tv93 = v93 + 1;\n\tv236 = this.TargetFSMs == 0;\n\tv100 = ~v236;\n\tif (v100) goto L_0027;\n\tthrow System.NullReferenceException;\nL_0074:\n\tv188 = this.Trigger2DEventCallback == 0;\n\tif (v188) goto L_0089;\n\tPlayMakerProxyBase+Trigger2DEvent::Invoke(this.Trigger2DEventCallback, other);\n\treturn;\nL_0089:\n\treturn;\n// 84 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnTriggerExit2D(Collider2D other)
	{
		//IL_00f6: Expected O, but got I
		//IL_0174: Expected O, but got I
		//IL_0197: Expected O, but got I
		//IL_01ec: Expected O, but got I
		List<PlayMakerFSM> targetFSMs = TargetFSMs;
		int num = 0;
		do
		{
			if (num < targetFSMs.Count)
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
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v10 (UnityEngine.Object)+18]");
					object obj2 = 0;
					_ = items[num];
					Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v10 (UnityEngine.Object)+18]");
					if ((IntPtr)0 != (IntPtr)0 && items[num].Active)
					{
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v10 (UnityEngine.Object)+18]");
						object obj3 = 0;
						_ = items[num];
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v10 (UnityEngine.Object)+18]");
						object obj4 = 0;
						Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v110 @ X8_v15+13C]");
						if ((IntPtr)0 != (IntPtr)0)
						{
							_ = items[num];
							Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v113 @ X21_v10 (UnityEngine.Object)+18]");
							((Fsm)0).OnTriggerExit2D(other);
						}
					}
				}
				targetFSMs = TargetFSMs;
				num++;
				continue;
			}
			if (Trigger2DEventCallback != null)
			{
				Trigger2DEventCallback(other);
			}
			return;
		}
		while (TargetFSMs != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60000DB")]
	[Address(RVA = "0xE60054", Offset = "0xE60054", Length = "0x1004")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::.ctor(this);\n\treturn;\n\tSystem.Array+EmptyInternalEnumerator`1<GBG.Pinata.ECS.Systems.InitEnemyHealthMarker>::Dispose(X0, X1);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xE57004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1021 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PlayMakerTriggerExit2D()
	{
	}
}
