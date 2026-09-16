using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace HutongGames.PlayMaker
{
	[Serializable]
	[Token(Token = "0x2000052")]
	public class FsmAnimationCurve
	{
		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x10")]
		public AnimationCurve curve;

		[Token(Token = "0x6000186")]
		[Address(RVA = "0xCA1A9C", Offset = "0xCA1A9C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC38C8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023521]) = v38;\nL_0016:\n\tv42 = new UnityEngine.AnimationCurve();\n\tUnityEngine.AnimationCurve::.ctor(v42);\n\tthis.curve = v42;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 25 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FsmAnimationCurve()
		{
			AnimationCurve animationCurve = new AnimationCurve();
			curve = animationCurve;
		}
	}
}
