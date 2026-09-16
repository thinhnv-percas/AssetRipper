using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200001A")]
	public class FaceInfo_Legacy
	{
		[Token(Token = "0x40000D9")]
		[FieldOffset(Offset = "0x10")]
		public string Name;

		[Token(Token = "0x40000DA")]
		[FieldOffset(Offset = "0x18")]
		public float PointSize;

		[Token(Token = "0x40000DB")]
		[FieldOffset(Offset = "0x1C")]
		public float Scale;

		[Token(Token = "0x40000DC")]
		[FieldOffset(Offset = "0x20")]
		public int CharacterCount;

		[Token(Token = "0x40000DD")]
		[FieldOffset(Offset = "0x24")]
		public float LineHeight;

		[Token(Token = "0x40000DE")]
		[FieldOffset(Offset = "0x28")]
		public float Baseline;

		[Token(Token = "0x40000DF")]
		[FieldOffset(Offset = "0x2C")]
		public float Ascender;

		[Token(Token = "0x40000E0")]
		[FieldOffset(Offset = "0x30")]
		public float CapHeight;

		[Token(Token = "0x40000E1")]
		[FieldOffset(Offset = "0x34")]
		public float Descender;

		[Token(Token = "0x40000E2")]
		[FieldOffset(Offset = "0x38")]
		public float CenterLine;

		[Token(Token = "0x40000E3")]
		[FieldOffset(Offset = "0x3C")]
		public float SuperscriptOffset;

		[Token(Token = "0x40000E4")]
		[FieldOffset(Offset = "0x40")]
		public float SubscriptOffset;

		[Token(Token = "0x40000E5")]
		[FieldOffset(Offset = "0x44")]
		public float SubSize;

		[Token(Token = "0x40000E6")]
		[FieldOffset(Offset = "0x48")]
		public float Underline;

		[Token(Token = "0x40000E7")]
		[FieldOffset(Offset = "0x4C")]
		public float UnderlineThickness;

		[Token(Token = "0x40000E8")]
		[FieldOffset(Offset = "0x50")]
		public float strikethrough;

		[Token(Token = "0x40000E9")]
		[FieldOffset(Offset = "0x54")]
		public float strikethroughThickness;

		[Token(Token = "0x40000EA")]
		[FieldOffset(Offset = "0x58")]
		public float TabWidth;

		[Token(Token = "0x40000EB")]
		[FieldOffset(Offset = "0x5C")]
		public float Padding;

		[Token(Token = "0x40000EC")]
		[FieldOffset(Offset = "0x60")]
		public float AtlasWidth;

		[Token(Token = "0x40000ED")]
		[FieldOffset(Offset = "0x64")]
		public float AtlasHeight;

		[Token(Token = "0x600018D")]
		[Address(RVA = "0x9176C8", Offset = "0x9176C8", Length = "0x8")]
		public FaceInfo_Legacy()
		{
		}
	}
}
