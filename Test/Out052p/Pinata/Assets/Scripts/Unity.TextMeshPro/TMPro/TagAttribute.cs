using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace TMPro
{
	[StructLayout((LayoutKind)0, Size = 12)]
	[Token(Token = "0x200006B")]
	public struct TagAttribute
	{
		[Token(Token = "0x4000477")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public int startIndex;

		[Token(Token = "0x4000478")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
		public int length;

		[Token(Token = "0x4000479")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int hashCode;
	}
}
