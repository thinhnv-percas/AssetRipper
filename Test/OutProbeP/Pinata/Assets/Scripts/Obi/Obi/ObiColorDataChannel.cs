using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x2000068")]
	public class ObiColorDataChannel : ObiPathDataChannelIdentity<Color>
	{
		[Token(Token = "0x6000461")]
		[Address(RVA = "0xE427CC", Offset = "0xE427CC", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EFDEF0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202472B]) = v38;\nL_0016:\n\tv42 = new Obi.ObiColorInterpolator3D();\n\tObi.ObiColorInterpolator3D::.ctor(v42);\n\tObi.ObiPathDataChannelIdentity`1<UnityEngine.Color>::.ctor(this, v42);\n\treturn;\n// 27 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiColorDataChannel()
			: base((ObiInterpolator<Color>)new ObiColorInterpolator3D())
		{
		}
	}
}
