using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 92)]
	[Token(Token = "0x200002D")]
	public struct TMP_LineInfo
	{
		[Token(Token = "0x400017C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		internal int controlCharacterCount;

		[Token(Token = "0x400017D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int characterCount;

		[Token(Token = "0x400017E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int visibleCharacterCount;

		[Token(Token = "0x400017F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public int spaceCount;

		[Token(Token = "0x4000180")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public int wordCount;

		[Token(Token = "0x4000181")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public int firstCharacterIndex;

		[Token(Token = "0x4000182")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x18")]
		public int firstVisibleCharacterIndex;

		[Token(Token = "0x4000183")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x1C")]
		public int lastCharacterIndex;

		[Token(Token = "0x4000184")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x20")]
		public int lastVisibleCharacterIndex;

		[Token(Token = "0x4000185")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x24")]
		public float length;

		[Token(Token = "0x4000186")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x28")]
		public float lineHeight;

		[Token(Token = "0x4000187")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x2C")]
		public float ascender;

		[Token(Token = "0x4000188")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x30")]
		public float baseline;

		[Token(Token = "0x4000189")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x34")]
		public float descender;

		[Token(Token = "0x400018A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x38")]
		public float maxAdvance;

		[Token(Token = "0x400018B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x3C")]
		public float width;

		[Token(Token = "0x400018C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x40")]
		public float marginLeft;

		[Token(Token = "0x400018D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x44")]
		public float marginRight;

		[Token(Token = "0x400018E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x48")]
		public TextAlignmentOptions alignment;

		[Token(Token = "0x400018F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4C")]
		public Extents lineExtents;
	}
}
