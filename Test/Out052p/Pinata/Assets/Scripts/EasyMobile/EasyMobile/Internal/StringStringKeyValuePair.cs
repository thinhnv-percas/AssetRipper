using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Token(Token = "0x20000C1")]
	public class StringStringKeyValuePair : SerializableKeyValuePair<string, string>
	{
		[Token(Token = "0x600070A")]
		[Address(RVA = "0xB52D9C", Offset = "0xB52D9C", Length = "0x68")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0024;\n\tv26 = *([1EB06A0]);\n\tv27 = *([v26 @ X8_v6]);\n\tv28 = \"il2cpp_codegen_initialize_method\"(v27, key, value, methodInfo, v30, v31, v32, v33, v34, v35, v36, v37, v38, v39, v40, v41);\n\tv44 = 0 | 1;\n\t*([20227A4]) = v44;\nL_0024:\n\tEasyMobile.Internal.SerializableKeyValuePair`2<System.String, System.String>::.ctor(this, key, value);\n\treturn;\n// 30 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringStringKeyValuePair(string key, string value)
			: base(key, value)
		{
		}
	}
}
