using System;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000020")]
public class DataCreatePlayer
{
	[Token(Token = "0x4000069")]
	[FieldOffset(Offset = "0x10")]
	public long createdTimestamp;

	[Token(Token = "0x400006A")]
	[FieldOffset(Offset = "0x18")]
	public int interstitialAds;

	[Token(Token = "0x400006B")]
	[FieldOffset(Offset = "0x1C")]
	public int numberAds;

	[Token(Token = "0x400006C")]
	[FieldOffset(Offset = "0x20")]
	public bool isRemoveAds;

	[Token(Token = "0x400006D")]
	[FieldOffset(Offset = "0x28")]
	public Inventory inventoryNew;

	[Token(Token = "0x17000011")]
	public Inventory Inventory
	{
		[Token(Token = "0x60000B0")]
		[Address(RVA = "0xBFBA7C", Offset = "0xBFBA7C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.inventoryNew;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return inventoryNew;
		}
		[Token(Token = "0x60000B1")]
		[Address(RVA = "0xBFBA84", Offset = "0xBFBA84", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.inventoryNew = value;\n\treturn;\n")]
		set
		{
			inventoryNew = value;
		}
	}

	[Token(Token = "0x17000012")]
	public long CreatedTimestamp
	{
		[Token(Token = "0x60000B2")]
		[Address(RVA = "0xBFBA8C", Offset = "0xBFBA8C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.createdTimestamp;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return createdTimestamp;
		}
		[Token(Token = "0x60000B3")]
		[Address(RVA = "0xBFBA94", Offset = "0xBFBA94", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.createdTimestamp = value;\n\treturn;\n")]
		set
		{
			createdTimestamp = value;
		}
	}

	[Token(Token = "0x17000013")]
	public int NumberAds
	{
		[Token(Token = "0x60000B4")]
		[Address(RVA = "0xBFBA9C", Offset = "0xBFBA9C", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.numberAds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return numberAds;
		}
		[Token(Token = "0x60000B5")]
		[Address(RVA = "0xBFBAA4", Offset = "0xBFBAA4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.numberAds = value;\n\treturn;\n")]
		set
		{
			numberAds = value;
		}
	}

	[Token(Token = "0x17000014")]
	public int InterstititialAdsCount
	{
		[Token(Token = "0x60000B6")]
		[Address(RVA = "0xBFBAAC", Offset = "0xBFBAAC", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturn this.interstitialAds;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		get
		{
			return interstitialAds;
		}
		[Token(Token = "0x60000B7")]
		[Address(RVA = "0xBFBAB4", Offset = "0xBFBAB4", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.interstitialAds = value;\n\treturn;\n")]
		set
		{
			interstitialAds = value;
		}
	}

	[Token(Token = "0x60000B8")]
	[Address(RVA = "0xBF9060", Offset = "0xBF9060", Length = "0x5C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0014;\n\tv18 = Inventory;\n\tv19 = \"il2cpp_codegen_initialize_runtime_metadata\"(v18, methodInfo, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34);\n\tv37 = 1;\n\t*([1A355EC]) = v37;\nL_0014:\n\tv39 = new Inventory();\n\tInventory::.ctor(v39);\n\tthis.inventoryNew = v39;\n\tSystem.Object::.ctor(this);\n\treturn;\n// 23 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
	public DataCreatePlayer()
	{
		Inventory inventory = new Inventory();
		inventoryNew = inventory;
	}
}
