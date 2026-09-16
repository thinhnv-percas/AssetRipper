using Cpp2ILInjected;

namespace Unity.IL2CPP.CompilerServices
{
	[Token(Token = "0x2000004")]
	public enum Option
	{
		[Token(Token = "0x4000002")]
		NullChecks = 1,
		[Token(Token = "0x4000003")]
		ArrayBoundsChecks = 2,
		[Token(Token = "0x4000004")]
		DivideByZeroChecks = 3
	}
}
