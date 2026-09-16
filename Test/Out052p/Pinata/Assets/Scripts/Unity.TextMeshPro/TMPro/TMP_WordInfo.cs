using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000066")]
	public struct TMP_WordInfo
	{
		[Token(Token = "0x4000435")]
		[FieldOffset(Offset = "0x0")]
		public TMP_Text textComponent;

		[Token(Token = "0x4000436")]
		[FieldOffset(Offset = "0x8")]
		public int firstCharacterIndex;

		[Token(Token = "0x4000437")]
		[FieldOffset(Offset = "0xC")]
		public int lastCharacterIndex;

		[Token(Token = "0x4000438")]
		[FieldOffset(Offset = "0x10")]
		public int characterCount;

		[Token(Token = "0x600053D")]
		[Address(RVA = "0x84C6F0", Offset = "0x84C6F0", Length = "0x64C")]
		public string GetWord()
		{
			return null;
		}
	}
}
