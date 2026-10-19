using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.LevelProgresService.Interface
{
	[Token(Token = "0x200060A")]
	public interface ILevelProgressService
	{
		[Token(Token = "0x17000270")]
		int CurrentLevelIndex
		{
			[Token(Token = "0x60019DA")]
			get;
		}

		[Token(Token = "0x17000271")]
		string CurrentLevelGuid
		{
			[Token(Token = "0x60019DB")]
			get;
		}

		[Token(Token = "0x17000272")]
		bool CurrentIsLoop
		{
			[Token(Token = "0x60019DC")]
			get;
		}

		[Token(Token = "0x17000273")]
		int CurrentLoopTurnId
		{
			[Token(Token = "0x60019DD")]
			get;
		}

		[Token(Token = "0x17000274")]
		string LastUniqueCompletedGuid
		{
			[Token(Token = "0x60019DE")]
			get;
		}

		[Token(Token = "0x17000275")]
		string LastCompletedLoopGuid
		{
			[Token(Token = "0x60019DF")]
			get;
		}

		[Token(Token = "0x17000276")]
		string LevelOrderSignature
		{
			[Token(Token = "0x60019E0")]
			get;
		}

		[Token(Token = "0x17000277")]
		bool RemapMigrationDone
		{
			[Token(Token = "0x60019E1")]
			get;
		}

		[Token(Token = "0x60019E2")]
		void SetCurrentLevel(int index, string guid);

		[Token(Token = "0x60019E3")]
		void SetCurrentLevelIndex(int levelIndex);

		[Token(Token = "0x60019E4")]
		void SaveProgress();

		[Token(Token = "0x60019E5")]
		void LevelCompleted(int nextIndex, string nextGuid);

		[Token(Token = "0x60019E6")]
		void IncrementTotalCounter();

		[Token(Token = "0x60019E7")]
		void SetCurrentLevelGuid(string guid);

		[Token(Token = "0x60019E8")]
		void SetCurrentLevelPointer(string guid, bool isLoop);

		[Token(Token = "0x60019E9")]
		void SetCurrentLoopTurnId(int value);

		[Token(Token = "0x60019EA")]
		void SetLastUniqueCompletedGuid(string guid);

		[Token(Token = "0x60019EB")]
		void SetLastCompletedLoopGuid(string guid);

		[Token(Token = "0x60019EC")]
		void SetLevelOrderSignature(string signature);

		[Token(Token = "0x60019ED")]
		void SetRemapMigrationDone(bool value);
	}
}
