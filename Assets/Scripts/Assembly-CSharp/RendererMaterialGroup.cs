using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Serializable]
[Token(Token = "0x2000014")]
public class RendererMaterialGroup
{
	[Token(Token = "0x400001D")]
	[FieldOffset(Offset = "0x10")]
	public Renderer Renderer;

	[Token(Token = "0x400001E")]
	[FieldOffset(Offset = "0x18")]
	public List<MaterialSlot> Slots;

	[Token(Token = "0x6000043")]
	[Address(RVA = "0x3C61E0C", Offset = "0x3C61E0C", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<MaterialSlot>();\n\tSystem.Collections.Generic.List`1<MaterialSlot>::.ctor(v48);\n\tthis.Slots = v48;\n")]
	public RendererMaterialGroup()
	{
		List<MaterialSlot> slots = new List<MaterialSlot>();
		Slots = slots;
	}
}
