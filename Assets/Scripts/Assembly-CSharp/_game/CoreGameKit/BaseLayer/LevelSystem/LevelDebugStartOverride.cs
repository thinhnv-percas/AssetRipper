using Cpp2ILInjected;

namespace _game.CoreGameKit.BaseLayer.LevelSystem
{
	[Token(Token = "0x2000664")]
	public static class LevelDebugStartOverride
	{
		[Token(Token = "0x2000665")]
		public struct ProgressSnapshot
		{
			[Token(Token = "0x40015E7")]
			[FieldOffset(Offset = "0x0")]
			public int Index;

			[Token(Token = "0x40015E8")]
			[FieldOffset(Offset = "0x8")]
			public string Guid;

			[Token(Token = "0x40015E9")]
			[FieldOffset(Offset = "0x10")]
			public bool IsLoop;

			[Token(Token = "0x40015EA")]
			[FieldOffset(Offset = "0x18")]
			public string LastUniqueGuid;

			[Token(Token = "0x40015EB")]
			[FieldOffset(Offset = "0x20")]
			public string LastLoopGuid;
		}

		[Token(Token = "0x40015DC")]
		private const string k_EditorPrefsAssetPathKeySandOut = "sand_out.debug.start_level_asset_path";

		[Token(Token = "0x40015DD")]
		private const string k_EditorPrefsAssetPathKeyPuzzle = "puzzle.debug.start_level_asset_path";

		[Token(Token = "0x40015DE")]
		private const string k_SnapshotTotalIndex = "sand_out.debug.start_level_total_index";

		[Token(Token = "0x40015DF")]
		private const string k_SnapshotGuid = "sand_out.debug.start_level_guid";

		[Token(Token = "0x40015E0")]
		private const string k_SnapshotIsLoop = "sand_out.debug.start_level_is_loop";

		[Token(Token = "0x40015E1")]
		private const string k_SnapshotLastUniqueGuid = "sand_out.debug.start_level_last_unique_guid";

		[Token(Token = "0x40015E2")]
		private const string k_SnapshotLastLoopGuid = "sand_out.debug.start_level_last_loop_guid";

		[Token(Token = "0x40015E3")]
		public const string k_AdvanceOnWinToggleKey = "sand_out.debug.advance_on_win";

		[Token(Token = "0x40015E4")]
		private const string k_LegacyGuidKeyPuzzle = "puzzle.debug.start_level_guid";

		[Token(Token = "0x40015E5")]
		private const string k_LegacyIndexKeySandOut = "sand_out.debug.start_level_index";

		[Token(Token = "0x40015E6")]
		private const string k_LegacyIndexKeyPuzzle = "puzzle.debug.start_level_index";

		[Token(Token = "0x17000298")]
		public static bool IsDebugSessionActive
		{
			[Token(Token = "0x6001AF8")]
			[Address(RVA = "0x3D579B8", Offset = "0x3D579B8", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x17000299")]
		public static bool ShouldAdvanceProgressionOnWin
		{
			[Token(Token = "0x6001AF9")]
			[Address(RVA = "0x3D579C0", Offset = "0x3D579C0", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x1700029A")]
		public static bool HasPendingEditorPlayOverride
		{
			[Token(Token = "0x6001AFA")]
			[Address(RVA = "0x3D579C8", Offset = "0x3D579C8", Length = "0x8")]
			get
			{
				return false;
			}
		}

		[Token(Token = "0x6001AFB")]
		[Address(RVA = "0x3D579D0", Offset = "0x3D579D0", Length = "0x20")]
		public static bool TryConsumeOverride(out string guid)
		{
			guid = null;
			guid = null;
			return false;
		}

		[Token(Token = "0x6001AFC")]
		[Address(RVA = "0x3D579F0", Offset = "0x3D579F0", Length = "0x14")]
		public static bool TryConsumeProgressSnapshot(out ProgressSnapshot snapshot)
		{
			snapshot = default(ProgressSnapshot);
			snapshot.LastLoopGuid = null;
			snapshot.Index = 0;
			snapshot.IsLoop = false;
			return false;
		}

		[Token(Token = "0x6001AFD")]
		[Address(RVA = "0x3D57A04", Offset = "0x3D57A04", Length = "0x20")]
		public static bool TryConsumeGuidOverride(out string guid)
		{
			guid = null;
			guid = null;
			return false;
		}
	}
}
