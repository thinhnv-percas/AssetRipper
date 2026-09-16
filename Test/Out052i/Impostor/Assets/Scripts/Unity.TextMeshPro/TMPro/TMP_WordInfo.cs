using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200001B")]
	public struct TMP_WordInfo
	{
		[Token(Token = "0x40000BB")]
		[FieldOffset(Offset = "0x0")]
		public TMP_Text textComponent;

		[Token(Token = "0x40000BC")]
		[FieldOffset(Offset = "0x8")]
		public int firstCharacterIndex;

		[Token(Token = "0x40000BD")]
		[FieldOffset(Offset = "0xC")]
		public int lastCharacterIndex;

		[Token(Token = "0x40000BE")]
		[FieldOffset(Offset = "0x10")]
		public int characterCount;

		[Token(Token = "0x6000119")]
		[Address(RVA = "0x15CF9E8", Offset = "0x15CF9E8", Length = "0x108")]
		public string GetWord()
		{
			return null;
		}
	}
}
