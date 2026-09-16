using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000021")]
	public struct RichTextTagAttribute
	{
		[Token(Token = "0x400010C")]
		[FieldOffset(Offset = "0x0")]
		public int nameHashCode;

		[Token(Token = "0x400010D")]
		[FieldOffset(Offset = "0x4")]
		public int valueHashCode;

		[Token(Token = "0x400010E")]
		[FieldOffset(Offset = "0x8")]
		public TagValueType valueType;

		[Token(Token = "0x400010F")]
		[FieldOffset(Offset = "0xC")]
		public int valueStartIndex;

		[Token(Token = "0x4000110")]
		[FieldOffset(Offset = "0x10")]
		public int valueLength;

		[Token(Token = "0x4000111")]
		[FieldOffset(Offset = "0x14")]
		public TagUnitType unitType;
	}
}
