using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Morpeh.Utils
{
	[Serializable]
	[Token(Token = "0x2000037")]
	public class FixedSystemPair : BasePair<FixedUpdateSystem>
	{
		[Token(Token = "0x60000E9")]
		[Address(RVA = "0x15F8AA4", Offset = "0x15F8AA4", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EAFDF8]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A06E]) = v38;\nL_001C:\n\tMorpeh.Utils.BasePair`1<Morpeh.FixedUpdateSystem>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public FixedSystemPair()
		{
		}
	}
}
