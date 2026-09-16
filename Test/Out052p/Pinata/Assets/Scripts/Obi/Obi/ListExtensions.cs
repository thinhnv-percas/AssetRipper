using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Obi
{
	[Token(Token = "0x2000030")]
	public static class ListExtensions
	{
		[Token(Token = "0x6000274")]
		[Address(RVA = "0x96B934", Offset = "0x96B934", Length = "0x64")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv22 = v17;\n\tv23 = 0x8907BC(v22, methodInfo, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35, v36, v37);\nL_0013:\n\tv40 = new Il2CppClass<Obi.CastedList`2<TTo, TFrom>>();\n\tv46 = Obi.CastedList`2<TTo, TFrom>::.ctor(v40, list);\n\treturn v40;\n// 28 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static IList<TTo> CastList<TFrom, TTo>(this IList<TFrom> list)
		{
			return new CastedList<TTo, TFrom>(list);
		}
	}
}
