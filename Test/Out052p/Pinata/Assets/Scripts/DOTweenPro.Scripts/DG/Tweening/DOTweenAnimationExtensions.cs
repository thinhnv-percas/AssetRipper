using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening
{
	[Token(Token = "0x2000003")]
	public static class DOTweenAnimationExtensions
	{
		[Token(Token = "0x6000026")]
		[Address(RVA = "0x11B21B8", Offset = "0x11B21B8", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv19 = v14;\n\tv20 = 0x8907BC(v19, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\nL_0012:\n\t// 18 IsInst v38 @ X0_v3, typeof(T), t @ X0 (UnityEngine.Component)\n\tv45 = v38 == 0;\n\tv50 = ~v45;\n\treturn v50;\n// 29 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static bool IsSameOrSubclassOf<T>(this Component t)
		{
			object obj = ((t is T) ? t : null);
			bool flag = obj == null;
			return !flag;
		}
	}
}
