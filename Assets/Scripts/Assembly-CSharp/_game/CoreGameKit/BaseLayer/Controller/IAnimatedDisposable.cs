using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Controller
{
	[Token(Token = "0x20006C1")]
	public interface IAnimatedDisposable : IDisposable
	{
		[Token(Token = "0x6001CA6")]
		void DisposeAnimated(Action<IAnimatedDisposable> onComplete);
	}
}
