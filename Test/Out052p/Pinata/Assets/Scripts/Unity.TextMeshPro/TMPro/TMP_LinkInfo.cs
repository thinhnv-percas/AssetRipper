using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000065")]
	public struct TMP_LinkInfo
	{
		[Token(Token = "0x400042E")]
		[FieldOffset(Offset = "0x0")]
		public TMP_Text textComponent;

		[Token(Token = "0x400042F")]
		[FieldOffset(Offset = "0x8")]
		public int hashCode;

		[Token(Token = "0x4000430")]
		[FieldOffset(Offset = "0xC")]
		public int linkIdFirstCharacterIndex;

		[Token(Token = "0x4000431")]
		[FieldOffset(Offset = "0x10")]
		public int linkIdLength;

		[Token(Token = "0x4000432")]
		[FieldOffset(Offset = "0x14")]
		public int linkTextfirstCharacterIndex;

		[Token(Token = "0x4000433")]
		[FieldOffset(Offset = "0x18")]
		public int linkTextLength;

		[Token(Token = "0x4000434")]
		[FieldOffset(Offset = "0x20")]
		internal char[] linkID;

		[Token(Token = "0x600053A")]
		[Address(RVA = "0x846954", Offset = "0x846954", Length = "0x8")]
		internal void SetLinkID(char[] text, int startIndex, int length)
		{
		}

		[Token(Token = "0x600053B")]
		[Address(RVA = "0x84695C", Offset = "0x84695C", Length = "0x8")]
		public string GetLinkText()
		{
			return null;
		}

		[Token(Token = "0x600053C")]
		[Address(RVA = "0x846964", Offset = "0x846964", Length = "0x4C")]
		public string GetLinkID()
		{
			return null;
		}
	}
}
