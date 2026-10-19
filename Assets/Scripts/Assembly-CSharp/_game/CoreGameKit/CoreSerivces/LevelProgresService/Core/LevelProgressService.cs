using Cpp2ILInjected;
using Reflex.Attributes;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Data;
using _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface;
using _game.Systems.ElephantStorage;

namespace _game.CoreGameKit.CoreSerivces.LevelProgresService.Core
{
	[Token(Token = "0x200060C")]
	public class LevelProgressService : ILevelProgressService
	{
		[Token(Token = "0x40014E7")]
		[FieldOffset(Offset = "0x10")]
		private LevelProgressPref _levelProgressPref;

		[Token(Token = "0x40014E8")]
		[FieldOffset(Offset = "0x18")]
		private IPlayerDataHandler _dataHandler;

		[Token(Token = "0x17000278")]
		public int CurrentLevelIndex
		{
			[Token(Token = "0x60019EF")]
			[Address(RVA = "0x3D4ED00", Offset = "0x3D4ED00", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.CurrentLevel;
			}
		}

		[Token(Token = "0x17000279")]
		public string CurrentLevelGuid
		{
			[Token(Token = "0x60019F0")]
			[Address(RVA = "0x3D4ED1C", Offset = "0x3D4ED1C", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.CurrentLevelGuid;
			}
		}

		[Token(Token = "0x1700027A")]
		public bool CurrentIsLoop
		{
			[Token(Token = "0x60019F1")]
			[Address(RVA = "0x3D4ED38", Offset = "0x3D4ED38", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.CurrentIsLoop;
			}
		}

		[Token(Token = "0x1700027B")]
		public int CurrentLoopTurnId
		{
			[Token(Token = "0x60019F2")]
			[Address(RVA = "0x3D4ED54", Offset = "0x3D4ED54", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.CurrentLoopTurnId;
			}
		}

		[Token(Token = "0x1700027C")]
		public string LastUniqueCompletedGuid
		{
			[Token(Token = "0x60019F3")]
			[Address(RVA = "0x3D4ED70", Offset = "0x3D4ED70", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.LastUniqueCompletedGuid;
			}
		}

		[Token(Token = "0x1700027D")]
		public string LastCompletedLoopGuid
		{
			[Token(Token = "0x60019F4")]
			[Address(RVA = "0x3D4ED8C", Offset = "0x3D4ED8C", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.LastCompletedLoopGuid;
			}
		}

		[Token(Token = "0x1700027E")]
		public string LevelOrderSignature
		{
			[Token(Token = "0x60019F5")]
			[Address(RVA = "0x3D4EDA8", Offset = "0x3D4EDA8", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.LevelOrderSignature;
			}
		}

		[Token(Token = "0x1700027F")]
		public bool RemapMigrationDone
		{
			[Token(Token = "0x60019F6")]
			[Address(RVA = "0x3D4EDC4", Offset = "0x3D4EDC4", Length = "0x1C")]
			get
			{
				LevelProgressPref levelProgressPref = _levelProgressPref;
				return levelProgressPref.RemapMigrationDone;
			}
		}

		[Inject(false)]
		[Token(Token = "0x60019F7")]
		[Address(RVA = "0x3D4EDE0", Offset = "0x3D4EDE0", Length = "0x34")]
		private void Inject(LevelProgressPref pref, IPlayerDataHandler dataHandler)
		{
			_levelProgressPref = pref;
			_dataHandler = dataHandler;
		}

		[Token(Token = "0x60019F8")]
		[Address(RVA = "0x3D4EE14", Offset = "0x3D4EE14", Length = "0xD0")]
		public void SetCurrentLevel(int index, string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetCurrentLevel");
		}

		[Token(Token = "0x60019F9")]
		[Address(RVA = "0x3D4EF9C", Offset = "0x3D4EF9C", Length = "0x100")]
		public void SetCurrentLevelIndex(int levelIndex)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetCurrentLevelIndex");
		}

		[Token(Token = "0x60019FA")]
		[Address(RVA = "0x3D4EEE4", Offset = "0x3D4EEE4", Length = "0xB8")]
		public void SaveProgress()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SaveProgress");
		}

		[Token(Token = "0x60019FB")]
		[Address(RVA = "0x3D4F09C", Offset = "0x3D4F09C", Length = "0xD0")]
		public void LevelCompleted(int nextIndex, string nextGuid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::LevelCompleted");
		}

		[Token(Token = "0x60019FC")]
		[Address(RVA = "0x3D4F16C", Offset = "0x3D4F16C", Length = "0xCC")]
		public void IncrementTotalCounter()
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::IncrementTotalCounter");
		}

		[Token(Token = "0x60019FD")]
		[Address(RVA = "0x3D4F238", Offset = "0x3D4F238", Length = "0xC8")]
		public void SetCurrentLevelGuid(string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetCurrentLevelGuid");
		}

		[Token(Token = "0x60019FE")]
		[Address(RVA = "0x3D4F300", Offset = "0x3D4F300", Length = "0xD8")]
		public void SetCurrentLevelPointer(string guid, bool isLoop)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetCurrentLevelPointer");
		}

		[Token(Token = "0x60019FF")]
		[Address(RVA = "0x3D4F3D8", Offset = "0x3D4F3D8", Length = "0xC4")]
		public void SetCurrentLoopTurnId(int value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetCurrentLoopTurnId");
		}

		[Token(Token = "0x6001A00")]
		[Address(RVA = "0x3D4F49C", Offset = "0x3D4F49C", Length = "0xC8")]
		public void SetLastUniqueCompletedGuid(string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetLastUniqueCompletedGuid");
		}

		[Token(Token = "0x6001A01")]
		[Address(RVA = "0x3D4F564", Offset = "0x3D4F564", Length = "0xC8")]
		public void SetLastCompletedLoopGuid(string guid)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetLastCompletedLoopGuid");
		}

		[Token(Token = "0x6001A02")]
		[Address(RVA = "0x3D4F62C", Offset = "0x3D4F62C", Length = "0xC8")]
		public void SetLevelOrderSignature(string signature)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetLevelOrderSignature");
		}

		[Token(Token = "0x6001A03")]
		[Address(RVA = "0x3D4F6F4", Offset = "0x3D4F6F4", Length = "0xC4")]
		public void SetRemapMigrationDone(bool value)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("LevelProgressService::SetRemapMigrationDone");
		}

		[Token(Token = "0x6001A04")]
		[Address(RVA = "0x3D4E4D8", Offset = "0x3D4E4D8", Length = "0x8")]
		public LevelProgressService()
		{
		}
	}
}
