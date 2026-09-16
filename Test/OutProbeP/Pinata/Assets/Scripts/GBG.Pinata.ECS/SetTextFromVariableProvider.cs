using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;

[Token(Token = "0x2000020")]
public class SetTextFromVariableProvider : MonoProvider<SetTextFromIntVariableComponent>
{
	[Token(Token = "0x600002F")]
	[Address(RVA = "0xCCA58C", Offset = "0xCCA58C", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1ED1920]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([202378D]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<SetTextFromIntVariableComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SetTextFromVariableProvider()
	{
	}
}
