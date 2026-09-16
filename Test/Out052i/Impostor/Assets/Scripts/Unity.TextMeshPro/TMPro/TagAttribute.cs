using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x2000020")]
	public struct TagAttribute
	{
		[Token(Token = "0x4000109")]
		[FieldOffset(Offset = "0x0")]
		public int startIndex;

		[Token(Token = "0x400010A")]
		[FieldOffset(Offset = "0x4")]
		public int length;

		[Token(Token = "0x400010B")]
		[FieldOffset(Offset = "0x8")]
		public int hashCode;
	}
}
