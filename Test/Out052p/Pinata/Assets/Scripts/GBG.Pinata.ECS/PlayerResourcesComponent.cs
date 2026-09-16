using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;

[StructLayout((LayoutKind)0, Size = 8)]
[Token(Token = "0x2000013")]
public struct PlayerResourcesComponent : IComponent
{
	[Token(Token = "0x400004E")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
	public int Money;

	[Token(Token = "0x400004F")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
	public int Diamonds;
}
