using AssetRipperInjected;
using Cpp2ILInjected;
using GBG.Pinata.ECS.Components;
using Morpeh;

namespace GBG.Pinata.ECS.Providers
{
	[Token(Token = "0x2000077")]
	public class EnemyProvider : MonoProvider<EnemyConfigComponent>
	{
		[Token(Token = "0x60000E6")]
		[Address(RVA = "0xCC2D74", Offset = "0xCC2D74", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EE2090]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023756]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<GBG.Pinata.ECS.Components.EnemyConfigComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public EnemyProvider()
		{
		}
	}
}
