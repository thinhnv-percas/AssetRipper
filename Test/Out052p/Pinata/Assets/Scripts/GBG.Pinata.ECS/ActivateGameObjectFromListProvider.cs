using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh;
using Morpeh.Globals;

[Token(Token = "0x200001C")]
public class ActivateGameObjectFromListProvider : MonoProvider<ActivateGameObjectFromListComponent>
{
	[Token(Token = "0x4000078")]
	[FieldOffset(Offset = "0x28")]
	private GlobalEvent onClick;

	[Token(Token = "0x6000027")]
	[Address(RVA = "0xCBDFD8", Offset = "0xCBDFD8", Length = "0x64")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv14 = *([2023705]) & 1;\n\tv15 = v14 == 0;\n\tv16 = ~v15;\n\tif (v16) goto L_0018;\n\tv19 = 0xCCDC0C(this, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\treturn;\n\tX0 = 0x8D8204(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = 0 | 1;\n\t*([2023705]) = X8;\nL_0018:\n\tv38 = 0;\n\tv41 = Morpeh.MonoProvider`1<ActivateGameObjectFromListComponent>::GetData(this, &v38 @ stack_-24_v1 (System.Boolean));\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected override void Initialize()
	{
		Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [2023705]");
		if (0 == 0)
		{
			Cpp2ILHelpers.NoteDecompilerIssue("Method not found @CCDC0C (inside WeaponParametersProvider::.ctor +0x5C)");
			return;
		}
		bool existOnEntity = false;
		ref ActivateGameObjectFromListComponent data = ref GetData(out existOnEntity);
	}

	[Token(Token = "0x6000028")]
	[Address(RVA = "0xCBE03C", Offset = "0xCBE03C", Length = "0x50")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tv18 = *([1EF1158]);\n\tv19 = *([v18 @ X8_v6]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([2023706]) = v38;\nL_001C:\n\tMorpeh.MonoProvider`1<ActivateGameObjectFromListComponent>::.ctor(this);\n\treturn;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ActivateGameObjectFromListProvider()
	{
	}
}
