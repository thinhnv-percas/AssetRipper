using Cpp2ILInjected;

namespace TMPro
{
	[Token(Token = "0x200001C")]
	public struct TMP_SpriteInfo
	{
		[Token(Token = "0x40000BF")]
		[FieldOffset(Offset = "0x0")]
		public int spriteIndex;

		[Token(Token = "0x40000C0")]
		[FieldOffset(Offset = "0x4")]
		public int characterIndex;

		[Token(Token = "0x40000C1")]
		[FieldOffset(Offset = "0x8")]
		public int vertexIndex;
	}
}
