using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x2000661")]
	public enum GameEndCondition
	{
		[Token(Token = "0x40015D2")]
		Time = 0,
		[Token(Token = "0x40015D3")]
		Move = 1,
		[Token(Token = "0x40015D4")]
		Space = 2,
		[Token(Token = "0x40015D5")]
		Mix = 3
	}
}
