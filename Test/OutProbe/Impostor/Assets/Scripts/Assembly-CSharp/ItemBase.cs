using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000031")]
public class ItemBase
{
	[Token(Token = "0x40000C3")]
	[FieldOffset(Offset = "0x10")]
	public TypeResources type;

	[Token(Token = "0x40000C4")]
	[FieldOffset(Offset = "0x14")]
	public int id;

	[Token(Token = "0x6000143")]
	[Address(RVA = "0xC02550", Offset = "0xC02550", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public ItemBase()
	{
	}
}
