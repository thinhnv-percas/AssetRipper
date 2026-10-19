using System;
using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem.Interface
{
	[Serializable]
	[Token(Token = "0x200067F")]
	public enum LevelDifficulty
	{
		[Token(Token = "0x4001657")]
		Null = 0,
		[Token(Token = "0x4001658")]
		Easy = 1,
		[Token(Token = "0x4001659")]
		Medium = 2,
		[Token(Token = "0x400165A")]
		Hard = 3,
		[Token(Token = "0x400165B")]
		SuperHard = 4
	}
}
