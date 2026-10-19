using Cpp2ILInjected;

namespace Unco.UText.Runtime.Layout
{
	[Token(Token = "0x20007B5")]
	public struct Element
	{
		[Token(Token = "0x40019B2")]
		[FieldOffset(Offset = "0x0")]
		public ElementKind Kind;

		[Token(Token = "0x40019B3")]
		[FieldOffset(Offset = "0x4")]
		public uint Codepoint;

		[Token(Token = "0x40019B4")]
		[FieldOffset(Offset = "0x8")]
		public int SpriteAtlasIndex;

		[Token(Token = "0x40019B5")]
		[FieldOffset(Offset = "0xC")]
		public int SpriteEntryIndex;

		[Token(Token = "0x40019B6")]
		[FieldOffset(Offset = "0x10")]
		public int RunStyleIndex;
	}
}
