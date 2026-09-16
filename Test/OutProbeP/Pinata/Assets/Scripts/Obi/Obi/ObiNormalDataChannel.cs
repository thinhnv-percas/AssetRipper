using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Obi
{
	[Serializable]
	[Token(Token = "0x200006A")]
	public class ObiNormalDataChannel : ObiPathDataChannelIdentity<Vector3>
	{
		[Token(Token = "0x6000463")]
		[Address(RVA = "0xC2733C", Offset = "0xC2733C", Length = "0x70")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv18 = *([1EF9CD0]);\n\tv19 = *([v18 @ X8_v8]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023134]) = v38;\nL_0016:\n\tv42 = new Obi.ObiCatmullRomInterpolator3D();\n\tObi.ObiCatmullRomInterpolator3D::.ctor(v42);\n\tObi.ObiPathDataChannelIdentity`1<UnityEngine.Vector3>::.ctor(this, v42);\n\treturn;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public ObiNormalDataChannel()
			: base((ObiInterpolator<Vector3>)new ObiCatmullRomInterpolator3D())
		{
		}
	}
}
