using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.WinCheck
{
	[Token(Token = "0x20003EA")]
	public interface IWinCheckSuppressor
	{
		[Token(Token = "0x1700014E")]
		bool IsSuppressed
		{
			[Token(Token = "0x600107A")]
			get;
		}

		[Token(Token = "0x6001079")]
		IDisposable RequestSuppress(string reason);

		[Token(Token = "0x600107B")]
		string ActiveReasons();
	}
}
