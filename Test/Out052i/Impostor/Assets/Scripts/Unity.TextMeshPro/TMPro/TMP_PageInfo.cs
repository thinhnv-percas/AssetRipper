using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000019")]
	public struct TMP_PageInfo
	{
		[Token(Token = "0x40000AF")]
		[FieldOffset(Offset = "0x0")]
		public int firstCharacterIndex;

		[Token(Token = "0x40000B0")]
		[FieldOffset(Offset = "0x4")]
		public int lastCharacterIndex;

		[Token(Token = "0x40000B1")]
		[FieldOffset(Offset = "0x8")]
		public float ascender;

		[Token(Token = "0x40000B2")]
		[FieldOffset(Offset = "0xC")]
		public float baseLine;

		[Token(Token = "0x40000B3")]
		[FieldOffset(Offset = "0x10")]
		public float descender;
	}
}
