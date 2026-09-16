using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using Morpeh.Globals;
using TMPro;

[Serializable]
[Token(Token = "0x2000015")]
public class SetTextSetup
{
	[Token(Token = "0x4000051")]
	[FieldOffset(Offset = "0x10")]
	public TextMeshProUGUI Text;

	[Token(Token = "0x4000052")]
	[FieldOffset(Offset = "0x18")]
	public GlobalVariableInt IntVariable;

	[Token(Token = "0x6000021")]
	[Address(RVA = "0xCCA8FC", Offset = "0xCCA8FC", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public SetTextSetup()
	{
	}
}
