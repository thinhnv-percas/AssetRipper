using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000065")]
	public struct TMP_LineInfo
	{
		[Token(Token = "0x40002C8")]
		[FieldOffset(Offset = "0x0")]
		internal int controlCharacterCount;

		[Token(Token = "0x40002C9")]
		[FieldOffset(Offset = "0x4")]
		public int characterCount;

		[Token(Token = "0x40002CA")]
		[FieldOffset(Offset = "0x8")]
		public int visibleCharacterCount;

		[Token(Token = "0x40002CB")]
		[FieldOffset(Offset = "0xC")]
		public int spaceCount;

		[Token(Token = "0x40002CC")]
		[FieldOffset(Offset = "0x10")]
		public int wordCount;

		[Token(Token = "0x40002CD")]
		[FieldOffset(Offset = "0x14")]
		public int firstCharacterIndex;

		[Token(Token = "0x40002CE")]
		[FieldOffset(Offset = "0x18")]
		public int firstVisibleCharacterIndex;

		[Token(Token = "0x40002CF")]
		[FieldOffset(Offset = "0x1C")]
		public int lastCharacterIndex;

		[Token(Token = "0x40002D0")]
		[FieldOffset(Offset = "0x20")]
		public int lastVisibleCharacterIndex;

		[Token(Token = "0x40002D1")]
		[FieldOffset(Offset = "0x24")]
		public float length;

		[Token(Token = "0x40002D2")]
		[FieldOffset(Offset = "0x28")]
		public float lineHeight;

		[Token(Token = "0x40002D3")]
		[FieldOffset(Offset = "0x2C")]
		public float ascender;

		[Token(Token = "0x40002D4")]
		[FieldOffset(Offset = "0x30")]
		public float baseline;

		[Token(Token = "0x40002D5")]
		[FieldOffset(Offset = "0x34")]
		public float descender;

		[Token(Token = "0x40002D6")]
		[FieldOffset(Offset = "0x38")]
		public float maxAdvance;

		[Token(Token = "0x40002D7")]
		[FieldOffset(Offset = "0x3C")]
		public float width;

		[Token(Token = "0x40002D8")]
		[FieldOffset(Offset = "0x40")]
		public float marginLeft;

		[Token(Token = "0x40002D9")]
		[FieldOffset(Offset = "0x44")]
		public float marginRight;

		[Token(Token = "0x40002DA")]
		[FieldOffset(Offset = "0x48")]
		public HorizontalAlignmentOptions alignment;

		[Token(Token = "0x40002DB")]
		[FieldOffset(Offset = "0x4C")]
		public Extents lineExtents;
	}
}
