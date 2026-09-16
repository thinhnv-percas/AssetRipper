using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace Morpeh.Hypercasual
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000002")]
	public struct SaveIntComponent : IComponent
	{
		[Token(Token = "0x4000001")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public string Name;

		[Token(Token = "0x4000002")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public int Value;
	}
}
