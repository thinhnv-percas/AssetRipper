using Cpp2ILInjected;

namespace _game.CoreSystem.FrameSystem
{
	[Token(Token = "0x20004EB")]
	public struct RegionSyncOptions
	{
		[Token(Token = "0x400107D")]
		[FieldOffset(Offset = "0x0")]
		public float AreaRelEpsilon;

		[Token(Token = "0x400107E")]
		[FieldOffset(Offset = "0x4")]
		public bool SyncRegionTypes;

		[Token(Token = "0x400107F")]
		[FieldOffset(Offset = "0x5")]
		public bool SyncGenerateMesh;

		[Token(Token = "0x170001CB")]
		public static RegionSyncOptions Default
		{
			[Token(Token = "0x60014B2")]
			[Address(RVA = "0x3CFCEFC", Offset = "0x3CFCEFC", Length = "0x10")]
			get
			{
				global::AssetRipperInjected.RecoveryStub.Missing("RegionSyncOptions::get_Default");
				return default;
			}
		}
	}
}
