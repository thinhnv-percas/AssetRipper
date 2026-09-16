using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace Zitga.CsvTools
{
	[Serializable]
	[Token(Token = "0x200003E")]
	public class StringIntDictionary : SerializableDictionary<string, int>
	{
		[Token(Token = "0x6000193")]
		[Address(RVA = "0xC05660", Offset = "0xC05660", Length = "0x48")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001A;\n\tv18 = Il2CppMethodInfo;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A35654]) = v37;\nL_001A:\n\tZitga.CsvTools.SerializableDictionary`2<System.Object, System.Int32>::.ctor(this);\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public StringIntDictionary()
		{
		}
	}
}
