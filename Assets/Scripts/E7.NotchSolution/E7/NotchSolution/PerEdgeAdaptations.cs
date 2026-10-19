using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace E7.NotchSolution
{
	[Serializable]
	[Token(Token = "0x2000006")]
	internal class PerEdgeAdaptations : PerEdgeValues<BlendedClipsAdaptor>
	{
		[Token(Token = "0x6000010")]
		[Address(RVA = "0x3F45358", Offset = "0x3F45358", Length = "0x58")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0020;\nL_0020:\n\tE7.NotchSolution.PerEdgeValues`1<System.Object>::.ctor(v42);\n\treturn;\n")]
		public PerEdgeAdaptations()
		{
		}
	}
}
