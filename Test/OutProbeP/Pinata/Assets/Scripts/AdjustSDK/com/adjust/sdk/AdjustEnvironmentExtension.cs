using AssetRipperInjected;
using Cpp2ILInjected;

namespace com.adjust.sdk
{
	[Token(Token = "0x200000E")]
	public static class AdjustEnvironmentExtension
	{
		[Token(Token = "0x60000D8")]
		[Address(RVA = "0x156D740", Offset = "0x156D740", Length = "0x6C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001B;\n\tv18 = *([1EDADB8]);\n\tv19 = *([v18 @ X8_v12]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20290BC]) = v38;\nL_001B:\n\tv47 = adjustEnvironment - 1;\n\tv49 = v47 == 0;\n\tv54 = ~v49;\n\tv55 = ~v54;\n\tif (v55) goto L_FFFFFFFF;\n\tgoto L_0032;\nL_0032:\n\tv68 = adjustEnvironment != 0;\n\tif (v68) goto L_003E;\n\tgoto L_003E;\nL_003E:\n\treturn *([v71 @ X8_v6 (System.String)]);\n// 47 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static string ToLowercaseString(this AdjustEnvironment adjustEnvironment)
		{
			string result = ((adjustEnvironment - 1 == AdjustEnvironment.Sandbox) ? "production" : "unknown");
			if (adjustEnvironment == AdjustEnvironment.Sandbox)
			{
				result = "sandbox";
			}
			return result;
		}
	}
}
