using System;
using System.Runtime.InteropServices;
using Cpp2ILInjected;
using Morpeh;

[Serializable]
[StructLayout((LayoutKind)0, Size = 12)]
[Token(Token = "0x2000002")]
public struct GameStateComponent : IComponent
{
	[Token(Token = "0x4000001")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x0")]
	public GameStatesEnum GameStates;

	[Token(Token = "0x4000002")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x4")]
	public bool InTransition;

	[Token(Token = "0x4000003")]
	[Cpp2ILInjected.FieldOffset(Offset = "0x5")]
	public bool Won;
}
