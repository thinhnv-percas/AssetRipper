using System.Runtime.Serialization;
using Cpp2ILInjected;
using Newtonsoft.Json;
using UnityEngine;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;
using _game.CoreSystem.LevelCreator;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000676")]
	public class LevelSo : LevelSoBase
	{
		[SerializeField]
		[Token(Token = "0x4001624")]
		[FieldOffset(Offset = "0x40")]
		private float m_time;

		[SerializeField]
		[Token(Token = "0x4001625")]
		[FieldOffset(Offset = "0x48")]
		private string m_creationDataJson;

		[Token(Token = "0x170002AD")]
		private LevelCreatorData Editor_CreationDataPreview
		{
			[Token(Token = "0x6001B5C")]
			[Address(RVA = "0x3D5DAF8", Offset = "0x3D5DAF8", Length = "0xD4")]
			get
			{
				if (string.IsNullOrEmpty(CreationDataJson))
				{
					return null;
				}
				return JsonConvert.DeserializeObject<LevelCreatorData>(CreationDataJson, LevelCreatorJsonSettings.Settings);
			}
		}

		[Token(Token = "0x170002AE")]
		public new string LevelId
		{
			[Token(Token = "0x6001B5D")]
			[Address(RVA = "0x3D5DBCC", Offset = "0x3D5DBCC", Length = "0x8")]
			get
			{
				return base.name;
			}
		}

		[Token(Token = "0x170002AF")]
		public float Time
		{
			[Token(Token = "0x6001B5E")]
			[Address(RVA = "0x3D5DBD4", Offset = "0x3D5DBD4", Length = "0x8")]
			get
			{
				return m_time;
			}
		}

		[Token(Token = "0x170002B0")]
		public override ILevelCreationData CreationData
		{
			[Token(Token = "0x6001B5F")]
			[Address(RVA = "0x3D5DBDC", Offset = "0x3D5DBDC", Length = "0xB0")]
			get
			{
				return JsonConvert.DeserializeObject<LevelCreatorData>(CreationDataJson, LevelCreatorJsonSettings.Settings);
			}
		}

		[Token(Token = "0x170002B1")]
		public string CreationDataJson
		{
			[Token(Token = "0x6001B60")]
			[Address(RVA = "0x3D5DC8C", Offset = "0x3D5DC8C", Length = "0x8")]
			get
			{
				return m_creationDataJson;
			}
		}

		[Token(Token = "0x6001B61")]
		[Address(RVA = "0x3D5DC94", Offset = "0x3D5DC94", Length = "0x1A8")]
		public LevelSerializable CreateLevelSerializable(LevelDifficulty? difficultyOverride = null)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelSo::CreateLevelSerializable");
			return default;
		}

		[Token(Token = "0x6001B62")]
		[Address(RVA = "0x3D5DE44", Offset = "0x3D5DE44", Length = "0x14")]
		public LevelSo()
		{
			m_landHome = true;
			m_difficulty = LevelDifficulty.Easy;
		}
	}
}
