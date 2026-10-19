using System.Collections.Generic;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.Installers
{
	[Token(Token = "0x2000686")]
	public interface IRawInputProvider
	{
		[Token(Token = "0x6001BC1")]
		IReadOnlyList<ScreenPointInput> GetScreenPoints();
	}
}
