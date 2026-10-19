using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace AlmostEngine
{
	[Token(Token = "0x2000005")]
	public static class ListExtras
	{
		[Token(Token = "0x6000006")]
		[Address(RVA = "0x4A10830", Offset = "0x4A10830", Length = "0x114")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0016;\n\tv30 = 0x220C2B8(methodInfo, size, element, methodInfo, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41, v42);\nL_0016:\n\tv112 = list.Count;\n\tv55 = list.Count - size;\n\tv58 = list.Count <= size;\n\tif (v58) goto L_003D;\n\tSystem.Collections.Generic.List`1<T>::RemoveRange(list, size, v55);\n\treturn;\nL_003D:\n\tv135 = size - list.Count;\n\tv138 = size <= list.Count;\n\tif (v138) goto L_0093;\n\tv139 = v135 & 0x80000000;\n\tv140 = v139 == 0;\n\tv141 = ~v140;\n\tif (v141) goto L_0093;\n\tv75 = 0;\n\tgoto L_0063;\nL_0048:\n\tv249 = v112 + 1;\n\tlist.Count = v249;\n\tv64[v112 @ X8_v5 (System.Int32)] = element;\n\tv75 = v75 + 1;\n\tv112 = list.Count;\n\tv151 = size - list.Count;\n\tv160 = v75 > v151;\n\tif (v160) goto L_0093;\nL_0063:\n\tv236 = list._version + 1;\n\tlist._version = v236;\n\tv64 = list._items;\n\tv237 = v112 < v64.Length;\n\tv238 = ~v237;\n\tv246 = ~v238;\n\tif (v246) goto L_0048;\n\tSystem.Collections.Generic.List`1<T>::AddWithResize(list, element);\n\tv75 = v75 + 1;\n\tv112 = list.Count;\n\tv150 = size - list.Count;\n\tv159 = v75 <= v150;\n\tif (v159) goto L_0063;\nL_0093:\n\treturn;\n")]
		public static void Resize<T>(this List<T> list, int size, T element = default(T))
		{
			global::AssetRipperInjected.RecoveryStub.Missing("ListExtras::Resize");
		}
	}
}
