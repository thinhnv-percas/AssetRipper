using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200001A")]
	public struct TMP_LinkInfo
	{
		[Token(Token = "0x40000B4")]
		[FieldOffset(Offset = "0x0")]
		public TMP_Text textComponent;

		[Token(Token = "0x40000B5")]
		[FieldOffset(Offset = "0x8")]
		public int hashCode;

		[Token(Token = "0x40000B6")]
		[FieldOffset(Offset = "0xC")]
		public int linkIdFirstCharacterIndex;

		[Token(Token = "0x40000B7")]
		[FieldOffset(Offset = "0x10")]
		public int linkIdLength;

		[Token(Token = "0x40000B8")]
		[FieldOffset(Offset = "0x14")]
		public int linkTextfirstCharacterIndex;

		[Token(Token = "0x40000B9")]
		[FieldOffset(Offset = "0x18")]
		public int linkTextLength;

		[Token(Token = "0x40000BA")]
		[FieldOffset(Offset = "0x20")]
		internal char[] linkID;

		[Token(Token = "0x6000116")]
		[Address(RVA = "0x15CF764", Offset = "0x15CF764", Length = "0xD4")]
		internal void SetLinkID(char[] text, int startIndex, int length)
		{
		}

		[Token(Token = "0x6000117")]
		[Address(RVA = "0x15CF838", Offset = "0x15CF838", Length = "0x108")]
		public string GetLinkText()
		{
			return null;
		}

		[Token(Token = "0x6000118")]
		[Address(RVA = "0x15CF940", Offset = "0x15CF940", Length = "0xA8")]
		public string GetLinkID()
		{
			return null;
		}
	}
}
