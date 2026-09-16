using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace Morpeh.Globals
{
	[CreateAssetMenu]
	[Token(Token = "0x2000023")]
	public class GlobalEventInt : BaseGlobalEvent<int>
	{
		[Token(Token = "0x60000AE")]
		[Address(RVA = "0x15F7A28", Offset = "0x15F7A28", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1F04E88]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202A057]) = v38;\nL_001C:\n\tMorpeh.Globals.BaseGlobalEvent`1<System.Int32>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalEventInt()
		{
		}
	}
}
