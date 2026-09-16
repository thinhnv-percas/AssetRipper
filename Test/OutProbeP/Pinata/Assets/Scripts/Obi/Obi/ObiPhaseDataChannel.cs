using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200006E")]
	public class ObiPhaseDataChannel : ObiPathDataChannelIdentity<int>
	{
		[Token(Token = "0x600047A")]
		[Address(RVA = "0xC2D99C", Offset = "0xC2D99C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EC9F00]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202317C]) = v38;\nL_0016:\n\tv42 = new Obi.ObiConstantInterpolator();\n\tObi.ObiConstantInterpolator::.ctor(v42);\n\tObi.ObiPathDataChannelIdentity`1<System.Int32>::.ctor(this, v42);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiPhaseDataChannel()
			: base((ObiInterpolator<int>)new ObiConstantInterpolator())
		{
		}
	}
}
