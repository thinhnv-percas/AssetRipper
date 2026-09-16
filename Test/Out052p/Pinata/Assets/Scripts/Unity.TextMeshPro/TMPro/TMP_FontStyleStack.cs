using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 10)]
	[Token(Token = "0x2000037")]
	public struct TMP_FontStyleStack
	{
		[Token(Token = "0x40001F2")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public byte bold;

		[Token(Token = "0x40001F3")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1")]
		public byte italic;

		[Token(Token = "0x40001F4")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2")]
		public byte underline;

		[Token(Token = "0x40001F5")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3")]
		public byte strikethrough;

		[Token(Token = "0x40001F6")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public byte highlight;

		[Token(Token = "0x40001F7")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x5")]
		public byte superscript;

		[Token(Token = "0x40001F8")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x6")]
		public byte subscript;

		[Token(Token = "0x40001F9")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x7")]
		public byte uppercase;

		[Token(Token = "0x40001FA")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public byte lowercase;

		[Token(Token = "0x40001FB")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x9")]
		public byte smallcaps;

		[Token(Token = "0x60002E2")]
		[Address(RVA = "0x84678C", Offset = "0x84678C", Length = "0xC")]
		public void Clear()
		{
		}

		[Token(Token = "0x60002E3")]
		[Address(RVA = "0x846798", Offset = "0x846798", Length = "0x8")]
		public byte Add(FontStyles style)
		{
			return 0;
		}

		[Token(Token = "0x60002E4")]
		[Address(RVA = "0x8467A0", Offset = "0x8467A0", Length = "0x4C")]
		public byte Remove(FontStyles style)
		{
			return 0;
		}
	}
}
