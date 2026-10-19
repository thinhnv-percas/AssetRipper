using Cpp2ILInjected;

namespace _game.CoreGameKit.CoreSerivces.LevelProgresService.Data
{
	[Token(Token = "0x200060B")]
	public class LevelProgressPref
	{
		[Token(Token = "0x40014DF")]
		[FieldOffset(Offset = "0x10")]
		public int CurrentLevel;

		[Token(Token = "0x40014E0")]
		[FieldOffset(Offset = "0x18")]
		public string CurrentLevelGuid;

		[Token(Token = "0x40014E1")]
		[FieldOffset(Offset = "0x20")]
		public bool CurrentIsLoop;

		[Token(Token = "0x40014E2")]
		[FieldOffset(Offset = "0x24")]
		public int CurrentLoopTurnId;

		[Token(Token = "0x40014E3")]
		[FieldOffset(Offset = "0x28")]
		public string LastUniqueCompletedGuid;

		[Token(Token = "0x40014E4")]
		[FieldOffset(Offset = "0x30")]
		public string LastCompletedLoopGuid;

		[Token(Token = "0x40014E5")]
		[FieldOffset(Offset = "0x38")]
		public string LevelOrderSignature;

		[Token(Token = "0x40014E6")]
		[FieldOffset(Offset = "0x40")]
		public bool RemapMigrationDone;

		[Token(Token = "0x60019EE")]
		[Address(RVA = "0x3D4ECF8", Offset = "0x3D4ECF8", Length = "0x8")]
		public LevelProgressPref()
		{
		}
	}
}
