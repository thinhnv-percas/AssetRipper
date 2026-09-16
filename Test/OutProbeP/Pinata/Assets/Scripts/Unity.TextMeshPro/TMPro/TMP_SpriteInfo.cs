using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 12)]
	[Token(Token = "0x2000067")]
	public struct TMP_SpriteInfo
	{
		[Token(Token = "0x4000439")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int spriteIndex;

		[Token(Token = "0x400043A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int characterIndex;

		[Token(Token = "0x400043B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int vertexIndex;
	}
}
