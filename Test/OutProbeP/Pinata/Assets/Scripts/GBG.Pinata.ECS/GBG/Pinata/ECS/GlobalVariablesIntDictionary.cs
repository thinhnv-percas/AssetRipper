using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x200003B")]
	public class GlobalVariablesIntDictionary : UnitySerializedDictionary<string, GlobalVariableInt>
	{
		[Token(Token = "0x600006A")]
		[Address(RVA = "0xCBF170", Offset = "0xCBF170", Length = "0x60")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ECD688]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202371C]) = v38;\nL_001C:\n\tGBG.Pinata.ECS.UnitySerializedDictionary`2<System.String, Morpeh.Globals.GlobalVariableInt>::.ctor(this);\n\treturn;\n\t*([X0]) = X1;\n\t*([X0+8]) = X2;\n\t*([X0+C]) = X3;\n\t*([X0+10]) = X4;\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public GlobalVariablesIntDictionary()
		{
		}
	}
}
