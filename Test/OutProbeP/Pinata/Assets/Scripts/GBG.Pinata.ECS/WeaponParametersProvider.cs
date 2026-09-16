using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;

[Token(Token = "0x2000024")]
public class WeaponParametersProvider : MonoProvider<WeaponParametersComponent>
{
	[Token(Token = "0x600003C")]
	[Address(RVA = "0xCCDBB0", Offset = "0xCCDBB0", Length = "0x1050")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF5290]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20237AD]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<WeaponParametersComponent>::.ctor(this);\n\treturn;\n\tSystem.Array::Resize(X0, X1, X2);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xCBF004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xCBE004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX0 = *([X8]);\n\tX0 = 0xCC1004(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\tX8 = *([X8+B88]);\n\tX0 = 0xCC8008(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn;\n\treturn;\n// 1037 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public WeaponParametersProvider()
	{
	}
}
