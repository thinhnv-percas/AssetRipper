using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x2000690")]
	public interface IBaseLayerUiActionElement
	{
		[Token(Token = "0x6001BD6")]
		IBaseLayerUiActionElement GetInstance();

		[Token(Token = "0x6001BD7")]
		void Play(Action onComplete);

		[Token(Token = "0x6001BD8")]
		void Stop();
	}
}
