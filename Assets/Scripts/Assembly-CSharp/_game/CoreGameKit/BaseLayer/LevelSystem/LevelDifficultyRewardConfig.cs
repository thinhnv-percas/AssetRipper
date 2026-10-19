using System;
using System.Collections.Generic;
using Cpp2ILInjected;
using Unco.RewardSystem;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x2000667")]
	public class LevelDifficultyRewardConfig
	{
		[Token(Token = "0x40015EC")]
		[FieldOffset(Offset = "0x10")]
		public LootDrop reward;

		[Token(Token = "0x40015ED")]
		[FieldOffset(Offset = "0x28")]
		public List<DifficultyRewardEntry> rewards;

		[Token(Token = "0x6001AFF")]
		[Address(RVA = "0x3D57A7C", Offset = "0x3D57A7C", Length = "0xE0")]
		public LootDrop GetReward(LevelDifficulty difficulty)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelDifficultyRewardConfig::GetReward");
			return default;
		}

		[Token(Token = "0x6001B00")]
		[Address(RVA = "0x3D57B5C", Offset = "0x3D57B5C", Length = "0xB4")]
		public LevelDifficultyRewardConfig()
		{
			LootDrop lootDrop = new LootDrop("resource", "SoftCurrency", 40f);
			reward = lootDrop;
			reward.Amount = 0f;
		}
	}
}
