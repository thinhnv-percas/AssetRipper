using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x2000427")]
	public interface IFailCheckSuppressor
	{
		[Token(Token = "0x17000162")]
		bool IsSuppressed
		{
			[Token(Token = "0x600115B")]
			get;
		}

		[Token(Token = "0x600115A")]
		IDisposable RequestSuppress(string reason);
	}
}
