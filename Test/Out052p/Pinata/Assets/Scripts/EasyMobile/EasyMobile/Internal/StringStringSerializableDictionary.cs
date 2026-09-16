using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace EasyMobile.Internal
{
	[Serializable]
	[Token(Token = "0x20000BC")]
	public class StringStringSerializableDictionary : SerializableDictionary<string, string>
	{
		[Token(Token = "0x60006FA")]
		[Address(RVA = "0xB52E04", Offset = "0xB52E04", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EADAC0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20227A5]) = v38;\nL_001C:\n\tEasyMobile.Internal.SerializableDictionary`2<System.String, System.String>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringStringSerializableDictionary()
		{
		}
	}
}
