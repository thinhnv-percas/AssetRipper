using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x2000055")]
	public class TMP_TextElement_Legacy
	{
		[Token(Token = "0x40003CF")]
		[FieldOffset(Offset = "0x10")]
		public int id;

		[Token(Token = "0x40003D0")]
		[FieldOffset(Offset = "0x14")]
		public float x;

		[Token(Token = "0x40003D1")]
		[FieldOffset(Offset = "0x18")]
		public float y;

		[Token(Token = "0x40003D2")]
		[FieldOffset(Offset = "0x1C")]
		public float width;

		[Token(Token = "0x40003D3")]
		[FieldOffset(Offset = "0x20")]
		public float height;

		[Token(Token = "0x40003D4")]
		[FieldOffset(Offset = "0x24")]
		public float xOffset;

		[Token(Token = "0x40003D5")]
		[FieldOffset(Offset = "0x28")]
		public float yOffset;

		[Token(Token = "0x40003D6")]
		[FieldOffset(Offset = "0x2C")]
		public float xAdvance;

		[Token(Token = "0x40003D7")]
		[FieldOffset(Offset = "0x30")]
		public float scale;

		[Token(Token = "0x60004CE")]
		[Address(RVA = "0xC89ED0", Offset = "0xC89ED0", Length = "0x8")]
		public TMP_TextElement_Legacy()
		{
		}
	}
}
