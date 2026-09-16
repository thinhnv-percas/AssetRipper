using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using HutongGames.PlayMaker;
using UnityEngine;

[AttributeAttribute(Type = typeof(AddComponentMenu), RVA = "0x73E910", Offset = "0x73E910")]
[Token(Token = "0x200001B")]
public class PlayMakerTriggerStay2D : PlayMakerProxyBase
{
	[Token(Token = "0x60000DE")]
	[Address(RVA = "0x16765E4", Offset = "0x16765E4", Length = "0x134")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0017;\n\tv26 = *([1ED3330]);\n\tv27 = *([v26 @ X8_v15]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, other, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\n\tv45 = 0 | 1;\n\t*([202B4D3]) = v45;\nL_0017:\n\tv123 = this.TargetFSMs;\nL_0027:\n\tv134 = v92 >= v123._size;\n\tif (v134) goto L_007C;\n\tv162 = v123._size < v92;\n\tv88 = ~v162;\n\tv85 = v123._size - v92;\n\tv79 = v85 == 0;\n\tv163 = ~v79;\n\tv64 = v88 & v163;\n\tif (v64) goto L_0037;\n\tSystem.ThrowHelper::ThrowArgumentOutOfRangeException();\nL_0037:\n\tv195 = v123._items;\n\tgoto L_0048;\n\tv200 = *([v196 @ X0_v10+E0]);\n\tv201 = v200 == 0;\n\tv202 = ~v201;\n\tif (v202) goto L_0048;\n\tv204 = \"il2cpp_codegen_runtime_class_init\"(v196, v108, v107, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0048:\n\tv96 = UnityEngine.Object::op_Equality(v195[v92 @ X22_v6 (System.Int32)], 0);\n\tv208 = v96 == 0;\n\tv209 = ~v208;\n\tif (v209) goto L_006A;\n\tv214 = PlayMakerFSM::get_Fsm(v195[v92 @ X22_v6 (System.Int32)]);\n\tv217 = v214 == 0;\n\tif (v217) goto L_006A;\n\tv215 = PlayMakerFSM::get_Active(v195[v92 @ X22_v6 (System.Int32)]);\n\tv218 = v215 == 0;\n\tif (v218) goto L_006A;\n\tv153 = PlayMakerFSM::get_Fsm(v195[v92 @ X22_v6 (System.Int32)]);\n\tv219 = ~v153.handleTriggerStay2D;\n\tif (v219) goto L_006A;\n\tv154 = PlayMakerFSM::get_Fsm(v195[v92 @ X22_v6 (System.Int32)]);\n\tHutongGames.PlayMaker.Fsm::OnTriggerStay2D(v154, other);\nL_006A:\n\tv123 = this.TargetFSMs;\n\tv92 = v92 + 1;\n\tv220 = this.TargetFSMs == 0;\n\tv98 = ~v220;\n\tif (v98) goto L_0027;\n\tthrow System.NullReferenceException;\nL_007C:\n\tPlayMakerProxyBase::DoTrigger2DEventCallback(this, other);\n\treturn;\n// 79 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public void OnTriggerStay2D(Collider2D other)
	{
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
				if (!(items[num] == null))
				{
					Fsm fsm = items[num].Fsm;
					if (fsm != null && items[num].Active)
					{
						Fsm fsm2 = items[num].Fsm;
						if (fsm2.HandleTriggerStay2D)
						{
							Fsm fsm3 = items[num].Fsm;
							fsm3.OnTriggerStay2D(other);
						}
					}
				}
				targetFSMs = TargetFSMs;
				num++;
				continue;
			}
			DoTrigger2DEventCallback(other);
			return;
		}
		while (TargetFSMs != null);
		throw new NullReferenceException();
	}

	[Token(Token = "0x60000DF")]
	[Address(RVA = "0x1676718", Offset = "0x1676718", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tPlayMakerProxyBase::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public PlayMakerTriggerStay2D()
	{
	}
}
