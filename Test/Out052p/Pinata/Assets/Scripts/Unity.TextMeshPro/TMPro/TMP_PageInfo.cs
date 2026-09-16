using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 20)]
	[Token(Token = "0x2000064")]
	public struct TMP_PageInfo
	{
		[Token(Token = "0x4000429")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int firstCharacterIndex;

		[Token(Token = "0x400042A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int lastCharacterIndex;

		[Token(Token = "0x400042B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public float ascender;

		[Token(Token = "0x400042C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public float baseLine;

		[Token(Token = "0x400042D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public float descender;
	}
}
