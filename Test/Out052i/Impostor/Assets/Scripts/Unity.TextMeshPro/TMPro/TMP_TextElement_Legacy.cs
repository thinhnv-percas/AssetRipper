using System;
using Cpp2ILInjected;

namespace TMPro
{
	[Serializable]
	[Token(Token = "0x200009C")]
	public class TMP_TextElement_Legacy
	{
		[Token(Token = "0x40005C0")]
		[FieldOffset(Offset = "0x10")]
		public int id;

		[Token(Token = "0x40005C1")]
		[FieldOffset(Offset = "0x14")]
		public float x;

		[Token(Token = "0x40005C2")]
		[FieldOffset(Offset = "0x18")]
		public float y;

		[Token(Token = "0x40005C3")]
		[FieldOffset(Offset = "0x1C")]
		public float width;

		[Token(Token = "0x40005C4")]
		[FieldOffset(Offset = "0x20")]
		public float height;

		[Token(Token = "0x40005C5")]
		[FieldOffset(Offset = "0x24")]
		public float xOffset;

		[Token(Token = "0x40005C6")]
		[FieldOffset(Offset = "0x28")]
		public float yOffset;

		[Token(Token = "0x40005C7")]
		[FieldOffset(Offset = "0x2C")]
		public float xAdvance;

		[Token(Token = "0x40005C8")]
		[FieldOffset(Offset = "0x30")]
		public float scale;

		[Token(Token = "0x60005E9")]
		[Address(RVA = "0x160A658", Offset = "0x160A658", Length = "0x8")]
		public TMP_TextElement_Legacy()
		{
		}
	}
}
