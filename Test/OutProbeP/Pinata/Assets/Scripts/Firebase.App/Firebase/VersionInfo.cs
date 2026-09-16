using AssetRipperInjected;
using Cpp2ILInjected;

namespace Firebase
{
	[Token(Token = "0x2000011")]
	internal class VersionInfo
	{
		[Token(Token = "0x17000015")]
		internal static string SdkVersion
		{
			[Token(Token = "0x6000080")]
			[Address(RVA = "0x16007F8", Offset = "0x16007F8", Length = "0x48")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0018;\n\tv14 = *([1EB0268]);\n\tv15 = *([v14 @ X8_v6]);\n\tv16 = \"il2cpp_codegen_initialize_method\"(v15, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31);\n\tv35 = 0 | 1;\n\t*([202A1B2]) = v35;\nL_0018:\n\treturn \"6.9.0\";\n// 18 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			get
			{
				return "6.9.0";
			}
		}
	}
}
