using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 24)]
	[Token(Token = "0x200006C")]
	public struct RichTextTagAttribute
	{
		[Token(Token = "0x400047A")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int nameHashCode;

		[Token(Token = "0x400047B")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int valueHashCode;

		[Token(Token = "0x400047C")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public TagValueType valueType;

		[Token(Token = "0x400047D")]
		[Cpp2ILInjected.FieldOffset(Offset = "0xC")]
		public int valueStartIndex;

		[Token(Token = "0x400047E")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x10")]
		public int valueLength;

		[Token(Token = "0x400047F")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x14")]
		public TagUnitType unitType;
	}
}
