using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace GBG.Pinata.ECS
{
	[Serializable]
	[Token(Token = "0x200003C")]
	public class MetaUpgradeConfigs : UnitySerializedDictionary<string, MetaUpgradeConfig>
	{
		[Token(Token = "0x600006B")]
		[Address(RVA = "0xCC2878", Offset = "0xCC2878", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EB12C0]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023751]) = v38;\nL_001C:\n\tGBG.Pinata.ECS.UnitySerializedDictionary`2<System.String, GBG.Pinata.ECS.MetaUpgradeConfig>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public MetaUpgradeConfigs()
		{
		}
	}
}
