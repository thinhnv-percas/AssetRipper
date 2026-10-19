using Cpp2ILInjected;
using UnityEngine;
using UnityEngine.Serialization;
using _game.CoreGameKit.BaseLayer.LevelSystem.Interface;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000677")]
	public class LevelSoBase : ScriptableObject, ILevel
	{
		[SerializeField]
		[Token(Token = "0x4001626")]
		[FieldOffset(Offset = "0x18")]
		private string m_uniqueId;

		[SerializeField]
		[Token(Token = "0x4001627")]
		[FieldOffset(Offset = "0x20")]
		private string m_environmentId;

		[FormerlySerializedAs("m_time")]
		[SerializeField]
		[Token(Token = "0x4001628")]
		[FieldOffset(Offset = "0x28")]
		private float m_endConditionValue;

		[SerializeField]
		[Token(Token = "0x4001629")]
		[FieldOffset(Offset = "0x2C")]
		private GameEndCondition m_endConditionType;

		[SerializeField]
		[Token(Token = "0x400162A")]
		[FieldOffset(Offset = "0x30")]
		private string m_unlockedFeatureId;

		[SerializeField]
		[Token(Token = "0x400162B")]
		[FieldOffset(Offset = "0x38")]
		protected internal bool m_landHome;

		[SerializeField]
		[Token(Token = "0x400162C")]
		[FieldOffset(Offset = "0x3C")]
		internal LevelDifficulty m_difficulty;

		[Token(Token = "0x170002B2")]
		public string UniqueId
		{
			[Token(Token = "0x6001B63")]
			[Address(RVA = "0x3D5DE6C", Offset = "0x3D5DE6C", Length = "0x8")]
			get
			{
				return m_uniqueId;
			}
		}

		[Token(Token = "0x170002B3")]
		public string LevelId
		{
			[Token(Token = "0x6001B64")]
			[Address(RVA = "0x3D5DE74", Offset = "0x3D5DE74", Length = "0x8")]
			get
			{
				return base.name;
			}
		}

		[Token(Token = "0x170002B4")]
		public string LevelName
		{
			[Token(Token = "0x6001B65")]
			[Address(RVA = "0x3D5DE3C", Offset = "0x3D5DE3C", Length = "0x8")]
			get
			{
				return base.name;
			}
		}

		[Token(Token = "0x170002B5")]
		public string EnvironmentId
		{
			[Token(Token = "0x6001B66")]
			[Address(RVA = "0x3D5DE7C", Offset = "0x3D5DE7C", Length = "0x8")]
			get
			{
				return m_environmentId;
			}
		}

		[Token(Token = "0x170002B6")]
		public float LevelEndValue
		{
			[Token(Token = "0x6001B67")]
			[Address(RVA = "0x3D5DE84", Offset = "0x3D5DE84", Length = "0x8")]
			get
			{
				return m_endConditionValue;
			}
		}

		[Token(Token = "0x170002B7")]
		public float EndConditionValue
		{
			[Token(Token = "0x6001B68")]
			[Address(RVA = "0x3D5DE8C", Offset = "0x3D5DE8C", Length = "0x8")]
			get
			{
				return LevelEndValue;
			}
		}

		[Token(Token = "0x170002B8")]
		public GameEndCondition EndConditionType
		{
			[Token(Token = "0x6001B69")]
			[Address(RVA = "0x3D5DE94", Offset = "0x3D5DE94", Length = "0x8")]
			get
			{
				return m_endConditionType;
			}
		}

		[Token(Token = "0x170002B9")]
		public string UnlockedFeatureId
		{
			[Token(Token = "0x6001B6A")]
			[Address(RVA = "0x3D5DE9C", Offset = "0x3D5DE9C", Length = "0x8")]
			get
			{
				return m_unlockedFeatureId;
			}
		}

		[Token(Token = "0x170002BA")]
		public bool LandHome
		{
			[Token(Token = "0x6001B6B")]
			[Address(RVA = "0x3D5DEA4", Offset = "0x3D5DEA4", Length = "0x8")]
			get
			{
				return m_landHome;
			}
		}

		[Token(Token = "0x170002BB")]
		public LevelDifficulty Difficulty
		{
			[Token(Token = "0x6001B6C")]
			[Address(RVA = "0x3D5DEAC", Offset = "0x3D5DEAC", Length = "0x8")]
			get
			{
				return m_difficulty;
			}
		}

		[Token(Token = "0x170002BC")]
		public virtual ILevelCreationData CreationData
		{
			[Token(Token = "0x6001B6D")]
			[Address(RVA = "0x3D5DEB4", Offset = "0x3D5DEB4", Length = "0x8")]
			get
			{
				return null;
			}
		}

		[Token(Token = "0x6001B6E")]
		[Address(RVA = "0x3D5DE58", Offset = "0x3D5DE58", Length = "0x14")]
		public LevelSoBase()
		{
			m_landHome = true;
			m_difficulty = LevelDifficulty.Easy;
		}
	}
}
