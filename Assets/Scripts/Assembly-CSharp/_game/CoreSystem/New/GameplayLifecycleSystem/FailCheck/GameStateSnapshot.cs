using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.FailCheck
{
	[Token(Token = "0x2000426")]
	public struct GameStateSnapshot
	{
		[Token(Token = "0x4000D12")]
		[FieldOffset(Offset = "0x0")]
		public bool AnyBreakableCube;

		[Token(Token = "0x4000D13")]
		[FieldOffset(Offset = "0x1")]
		public bool ConveyorAtCapacity;

		[Token(Token = "0x4000D14")]
		[FieldOffset(Offset = "0x2")]
		public bool AnyConveyorParticleAbsorbable;

		[Token(Token = "0x4000D15")]
		[FieldOffset(Offset = "0x3")]
		public bool AnyAbsorbingInFlight;
	}
}
