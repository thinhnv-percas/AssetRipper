using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000013")]
public class MaterialSlot
{
	[Token(Token = "0x400001B")]
	[FieldOffset(Offset = "0x10")]
	public int MaterialIndex;

	[Token(Token = "0x400001C")]
	[FieldOffset(Offset = "0x18")]
	public Material Material;

	[Token(Token = "0x6000042")]
	[Address(RVA = "0x3C61E04", Offset = "0x3C61E04", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
	public MaterialSlot()
	{
	}
}
