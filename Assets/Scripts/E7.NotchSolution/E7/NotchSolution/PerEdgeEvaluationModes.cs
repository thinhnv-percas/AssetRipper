using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x200000D")]
	internal class PerEdgeEvaluationModes : PerEdgeValues<EdgeEvaluationMode>
	{
		[Token(Token = "0x600002D")]
		[Address(RVA = "0x3F45F00", Offset = "0x3F45F00", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tE7.NotchSolution.PerEdgeValues`1<E7.NotchSolution.EdgeEvaluationMode>::.ctor(this);\n\treturn;\n")]
		public PerEdgeEvaluationModes()
		{
		}
	}
}
