using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x200068F")]
	public interface IBaseLayerIntroElement
	{
		[Token(Token = "0x6001BD3")]
		IBaseLayerIntroElement GetInstance();

		[Token(Token = "0x6001BD4")]
		void Play(Action onComplete);

		[Token(Token = "0x6001BD5")]
		void Stop();
	}
}
