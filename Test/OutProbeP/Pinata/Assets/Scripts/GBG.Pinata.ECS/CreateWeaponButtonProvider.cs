using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;

[Token(Token = "0x200001E")]
public class CreateWeaponButtonProvider : MonoProvider<CreateWeaponButtonComponent>
{
	[Token(Token = "0x600002D")]
	[Address(RVA = "0xCBE9B0", Offset = "0xCBE9B0", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EBA708]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202370F]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<CreateWeaponButtonComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public CreateWeaponButtonProvider()
	{
	}
}
