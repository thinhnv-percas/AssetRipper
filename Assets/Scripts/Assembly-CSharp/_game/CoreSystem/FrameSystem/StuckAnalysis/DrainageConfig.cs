using Cpp2ILInjected;

namespace _game.CoreSystem.FrameSystem.StuckAnalysis
{
	[Token(Token = "0x20004F2")]
	public struct DrainageConfig
	{
		[Token(Token = "0x4001090")]
		[FieldOffset(Offset = "0x0")]
		public float cellSize;

		[Token(Token = "0x4001091")]
		[FieldOffset(Offset = "0x4")]
		public float minRelevantY;

		[Token(Token = "0x4001092")]
		[FieldOffset(Offset = "0x8")]
		public float minRetainDepth;

		[Token(Token = "0x170001CD")]
		public static DrainageConfig Default
		{
			[Token(Token = "0x60014BC")]
			[Address(RVA = "0x3CFF0CC", Offset = "0x3CFF0CC", Length = "0x28")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("DrainageConfig::get_Default");
				return default;
			}
		}
	}
}
