using System;
using Cpp2ILInjected;
using Unco.RewardSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x2000668")]
	public class DifficultyRewardEntry
	{
		[Token(Token = "0x40015EE")]
		[FieldOffset(Offset = "0x10")]
		public LevelDifficulty Difficulty;

		[Token(Token = "0x40015EF")]
		[FieldOffset(Offset = "0x18")]
		public LootDrop Reward;

		[Token(Token = "0x6001B01")]
		[Address(RVA = "0x3D57C10", Offset = "0x3D57C10", Length = "0x8")]
		public DifficultyRewardEntry()
		{
		}
	}
}
