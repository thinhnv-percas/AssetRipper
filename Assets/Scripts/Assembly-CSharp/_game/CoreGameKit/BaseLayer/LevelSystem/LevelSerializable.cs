using System;
using Cpp2ILInjected;
using Unco.RewardSystem;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Serializable]
	[Token(Token = "0x2000674")]
	public class LevelSerializable : ILevel
	{
		[SerializeField]
		[Token(Token = "0x4001619")]
		[FieldOffset(Offset = "0x10")]
		internal string uniqueId;

		[SerializeField]
		[Token(Token = "0x400161A")]
		[FieldOffset(Offset = "0x18")]
		internal string levelName;

		[SerializeField]
		[Token(Token = "0x400161B")]
		[FieldOffset(Offset = "0x20")]
		internal string environmentId;

		[SerializeField]
		[Token(Token = "0x400161C")]
		[FieldOffset(Offset = "0x28")]
		internal float time;

		[SerializeField]
		[Token(Token = "0x400161D")]
		[FieldOffset(Offset = "0x2C")]
		internal GameEndCondition endConditionType;

		[SerializeField]
		[Token(Token = "0x400161E")]
		[FieldOffset(Offset = "0x30")]
		private LootDrop reward;

		[SerializeField]
		[Token(Token = "0x400161F")]
		[FieldOffset(Offset = "0x48")]
		internal string unlockedFeatureId;

		[SerializeField]
		[Token(Token = "0x4001620")]
		[FieldOffset(Offset = "0x50")]
		internal bool landHome;

		[SerializeField]
		[Token(Token = "0x4001621")]
		[FieldOffset(Offset = "0x54")]
		internal LevelDifficulty difficulty;

		[Token(Token = "0x4001622")]
		[FieldOffset(Offset = "0x58")]
		public LevelCreatorData creationData;

		[Token(Token = "0x170002A3")]
		public string UniqueId
		{
			[Token(Token = "0x6001B50")]
			[Address(RVA = "0x3D5D9C8", Offset = "0x3D5D9C8", Length = "0x8")]
			get
			{
				return uniqueId;
			}
		}

		[Token(Token = "0x170002A4")]
		public string LevelName
		{
			[Token(Token = "0x6001B51")]
			[Address(RVA = "0x3D5D9D0", Offset = "0x3D5D9D0", Length = "0x8")]
			get
			{
				return levelName;
			}
		}

		[Token(Token = "0x170002A5")]
		public string EnvironmentId
		{
			[Token(Token = "0x6001B52")]
			[Address(RVA = "0x3D5D9D8", Offset = "0x3D5D9D8", Length = "0x8")]
			get
			{
				return environmentId;
			}
		}

		[Token(Token = "0x170002A6")]
		public float LevelEndValue
		{
			[Token(Token = "0x6001B53")]
			[Address(RVA = "0x3D5D9E0", Offset = "0x3D5D9E0", Length = "0x8")]
			get
			{
				return time;
			}
		}

		[Token(Token = "0x170002A7")]
		public GameEndCondition EndConditionType
		{
			[Token(Token = "0x6001B54")]
			[Address(RVA = "0x3D5D9E8", Offset = "0x3D5D9E8", Length = "0x8")]
			get
			{
				return endConditionType;
			}
		}

		[Token(Token = "0x170002A8")]
		ILevelCreationData ILevel.CreationData
		{
			[Token(Token = "0x6001B55")]
			[Address(RVA = "0x3D5D9F0", Offset = "0x3D5D9F0", Length = "0x8")]
			get
			{
				return creationData;
			}
		}

		[Token(Token = "0x170002A9")]
		public LootDrop Reward
		{
			[Token(Token = "0x6001B56")]
			[Address(RVA = "0x3D5D9F8", Offset = "0x3D5D9F8", Length = "0x14")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("LevelSerializable::get_Reward");
				return default;
			}
		}

		[Token(Token = "0x170002AA")]
		public string UnlockedFeatureId
		{
			[Token(Token = "0x6001B57")]
			[Address(RVA = "0x3D5DA0C", Offset = "0x3D5DA0C", Length = "0x8")]
			get
			{
				return unlockedFeatureId;
			}
		}

		[Token(Token = "0x170002AB")]
		public bool LandHome
		{
			[Token(Token = "0x6001B58")]
			[Address(RVA = "0x3D5DA14", Offset = "0x3D5DA14", Length = "0x8")]
			get
			{
				return landHome;
			}
		}

		[Token(Token = "0x170002AC")]
		public LevelDifficulty Difficulty
		{
			[Token(Token = "0x6001B59")]
			[Address(RVA = "0x3D5DA1C", Offset = "0x3D5DA1C", Length = "0x8")]
			get
			{
				return difficulty;
			}
		}

		[Token(Token = "0x6001B5A")]
		[Address(RVA = "0x3D5DA24", Offset = "0x3D5DA24", Length = "0xCC")]
		public LevelSerializable(string uniqueId, string levelId, string levelName, string environmentId, float time, GameEndCondition endConditionType, string unlockedFeatureId, bool landHome, LevelDifficulty difficulty, LevelCreatorData creationData = null)
		{
			this.uniqueId = uniqueId;
			this.levelName = levelName;
			this.environmentId = environmentId;
			this.time = time;
			this.endConditionType = endConditionType;
			this.unlockedFeatureId = unlockedFeatureId;
			this.creationData = creationData;
			this.landHome = landHome;
			this.difficulty = difficulty;
		}
	}
}
