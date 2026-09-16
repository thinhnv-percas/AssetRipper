using System;
using AssetRipperInjected;
using CodeStage.AntiCheat.ObscuredTypes;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000012")]
public abstract class ItemInventory
{
	[Token(Token = "0x4000038")]
	[FieldOffset(Offset = "0x10")]
	public TypeResources type;

	[Token(Token = "0x4000039")]
	[FieldOffset(Offset = "0x14")]
	public ObscuredInt idItem;

	[Token(Token = "0x17000007")]
	public abstract long Value
	{
		[Token(Token = "0x600006C")]
		get;
	}

	[Token(Token = "0x600006D")]
	public abstract void Add(long number);

	[Token(Token = "0x600006E")]
	public abstract void Sub(long number);

	[Token(Token = "0x600006F")]
	[Address(RVA = "0xBFA07C", Offset = "0xBFA07C", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	protected internal ItemInventory()
	{
	}
}
