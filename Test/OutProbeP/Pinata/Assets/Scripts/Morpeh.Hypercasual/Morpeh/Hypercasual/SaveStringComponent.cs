using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;

namespace Morpeh.Hypercasual
{
	[Serializable]
	[StructLayout((LayoutKind)0, Size = 16)]
	[Token(Token = "0x2000003")]
	public struct SaveStringComponent : IComponent
	{
		[Token(Token = "0x4000003")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
		public string Name;

		[Token(Token = "0x4000004")]
		[Cpp2ILInjected.FieldOffset(Offset = "0x8")]
		public string Value;
	}
}
