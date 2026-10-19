using Cpp2ILInjected;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004EC")]
	public struct RegionSyncResult
	{
		[Token(Token = "0x4001080")]
		[FieldOffset(Offset = "0x0")]
		public bool Skipped;

		[Token(Token = "0x4001081")]
		[FieldOffset(Offset = "0x8")]
		public string SkipReason;

		[Token(Token = "0x4001082")]
		[FieldOffset(Offset = "0x10")]
		public int MatchedLoops;

		[Token(Token = "0x4001083")]
		[FieldOffset(Offset = "0x14")]
		public int UnmatchedLoops;

		[Token(Token = "0x4001084")]
		[FieldOffset(Offset = "0x18")]
		public int RegionTypeChanges;

		[Token(Token = "0x4001085")]
		[FieldOffset(Offset = "0x1C")]
		public int GenerateMeshChanges;

		[Token(Token = "0x4001086")]
		[FieldOffset(Offset = "0x20")]
		public bool ArrayCountChanged;

		[Token(Token = "0x170001CC")]
		public bool Changed
		{
			[Token(Token = "0x60014B3")]
			[Address(RVA = "0x3CFCF0C", Offset = "0x3CFCF0C", Length = "0x3C")]
			get
			{
				if (RegionTypeChanges > 0)
				{
					return true;
				}
				if (GenerateMeshChanges > 0)
				{
					return true;
				}
				return ArrayCountChanged;
			}
		}
	}
}
