using System;
using System.Collections.Generic;
using AssetRipperInjected;
using Cpp2ILInjected;

[Serializable]
[Token(Token = "0x2000015")]
public class BackgroundPreset
{
	[Token(Token = "0x400001F")]
	[FieldOffset(Offset = "0x10")]
	public string Name;

	[Token(Token = "0x4000020")]
	[FieldOffset(Offset = "0x18")]
	public List<RendererMaterialGroup> Groups;

	[Token(Token = "0x6000044")]
	[Address(RVA = "0x3C61E98", Offset = "0x3C61E98", Length = "0x8C")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001C;\n\tSystem.Object::.ctor(this);\n\treturn;\nL_001C:\n\tv48 = new System.Collections.Generic.List`1<RendererMaterialGroup>();\n\tSystem.Collections.Generic.List`1<RendererMaterialGroup>::.ctor(v48);\n\tthis.Groups = v48;\n")]
	public BackgroundPreset()
	{
		List<RendererMaterialGroup> groups = new List<RendererMaterialGroup>();
		Groups = groups;
	}
}
