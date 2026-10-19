using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x20006A6")]
	public interface IHasCompletion
	{
		[Token(Token = "0x170002D6")]
		Action OnCompleted
		{
			[Token(Token = "0x6001C24")]
			get;
			[Token(Token = "0x6001C25")]
			set;
		}
	}
}
