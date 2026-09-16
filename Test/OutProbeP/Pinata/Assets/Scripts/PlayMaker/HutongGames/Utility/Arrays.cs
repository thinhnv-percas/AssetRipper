using AssetRipperInjected;
using Cpp2ILInjected;

namespace HutongGames.Utility
{
	[Token(Token = "0x2000082")]
	public static class Arrays<T>
	{
		[Token(Token = "0x400035E")]
		public static readonly T[] Empty;

		[Token(Token = "0x6000678")]
		[Address(RVA = "0xD9577C", Offset = "0xD9577C", Length = "0x8C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv17 = v12;\n\tv18 = 0x8907BC(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_0015:\n\tgoto L_001A;\n\tv41 = v36;\n\tv42 = 0x8907BC(v41, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_001A:\n\t// 26 NewArr v46 @ X0_v4 (T[]), typeof(Il2CppClass<T[]>), 0\n\tgoto L_002A;\n\tv53 = v47;\n\tv54 = 0x8907BC(v53, v45, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002A:\n\tgoto L_002E;\n\tv62 = v57;\n\tv63 = 0x8907BC(v62, v45, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\nL_002E:\n\tv65.Empty = v46;\n\treturn;\n// 38 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		static Arrays()
		{
			T[] empty = null;
			Empty = empty;
		}
	}
}
