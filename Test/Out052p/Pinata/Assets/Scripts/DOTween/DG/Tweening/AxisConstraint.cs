using System;
using Cpp2ILInjected;

namespace DG.Tweening
{
	[Flags]
	[Token(Token = "0x2000003")]
	public enum AxisConstraint
	{
		[Token(Token = "0x4000007")]
		None = 0,
		[Token(Token = "0x4000008")]
		X = 2,
		[Token(Token = "0x4000009")]
		Y = 4,
		[Token(Token = "0x400000A")]
		Z = 8,
		[Token(Token = "0x400000B")]
		W = 0x10
	}
}
