using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

[Token(Token = "0x2000010")]
public class Readme : ScriptableObject
{
	[Serializable]
	[Token(Token = "0x2000011")]
	public class Section
	{
		[Token(Token = "0x4000015")]
		[FieldOffset(Offset = "0x10")]
		public string heading;

		[Token(Token = "0x4000016")]
		[FieldOffset(Offset = "0x18")]
		public string text;

		[Token(Token = "0x4000017")]
		[FieldOffset(Offset = "0x20")]
		public string linkText;

		[Token(Token = "0x4000018")]
		[FieldOffset(Offset = "0x28")]
		public string url;

		[Token(Token = "0x600003D")]
		[Address(RVA = "0x3C61C78", Offset = "0x3C61C78", Length = "0x8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public Section()
		{
		}
	}

	[Token(Token = "0x4000011")]
	[FieldOffset(Offset = "0x18")]
	public Texture2D icon;

	[Token(Token = "0x4000012")]
	[FieldOffset(Offset = "0x20")]
	public string title;

	[Token(Token = "0x4000013")]
	[FieldOffset(Offset = "0x28")]
	public Section[] sections;

	[Token(Token = "0x4000014")]
	[FieldOffset(Offset = "0x30")]
	public bool loadedLayout;

	[Token(Token = "0x600003C")]
	[Address(RVA = "0x3C61C70", Offset = "0x3C61C70", Length = "0x8")]
	[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tUnityEngine.ScriptableObject::.ctor(this);\n\treturn;\n")]
	public Readme()
	{
	}
}
