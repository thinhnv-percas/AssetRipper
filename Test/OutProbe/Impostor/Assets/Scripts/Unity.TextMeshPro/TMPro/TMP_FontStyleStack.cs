using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200009F")]
	public struct TMP_FontStyleStack
	{
		[Token(Token = "0x40005DE")]
		[FieldOffset(Offset = "0x0")]
		public byte bold;

		[Token(Token = "0x40005DF")]
		[FieldOffset(Offset = "0x1")]
		public byte italic;

		[Token(Token = "0x40005E0")]
		[FieldOffset(Offset = "0x2")]
		public byte underline;

		[Token(Token = "0x40005E1")]
		[FieldOffset(Offset = "0x3")]
		public byte strikethrough;

		[Token(Token = "0x40005E2")]
		[FieldOffset(Offset = "0x4")]
		public byte highlight;

		[Token(Token = "0x40005E3")]
		[FieldOffset(Offset = "0x5")]
		public byte superscript;

		[Token(Token = "0x40005E4")]
		[FieldOffset(Offset = "0x6")]
		public byte subscript;

		[Token(Token = "0x40005E5")]
		[FieldOffset(Offset = "0x7")]
		public byte uppercase;

		[Token(Token = "0x40005E6")]
		[FieldOffset(Offset = "0x8")]
		public byte lowercase;

		[Token(Token = "0x40005E7")]
		[FieldOffset(Offset = "0x9")]
		public byte smallcaps;

		[Token(Token = "0x6000605")]
		[Address(RVA = "0x1611590", Offset = "0x1611590", Length = "0xC")]
		public void Clear()
		{
		}

		[Token(Token = "0x6000606")]
		[Address(RVA = "0x161159C", Offset = "0x161159C", Length = "0xFC")]
		public byte Add(FontStyles style)
		{
			return 0;
		}

		[Token(Token = "0x6000607")]
		[Address(RVA = "0x1611698", Offset = "0x1611698", Length = "0x144")]
		public byte Remove(FontStyles style)
		{
			return 0;
		}
	}
}
