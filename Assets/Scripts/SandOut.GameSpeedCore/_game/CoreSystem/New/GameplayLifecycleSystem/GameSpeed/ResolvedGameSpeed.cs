using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.GameplayLifecycleSystem.GameSpeed
{
	[Token(Token = "0x2000005")]
	public readonly struct ResolvedGameSpeed
	{
		[Token(Token = "0x4000007")]
		[FieldOffset(Offset = "0x0")]
		public readonly float GroupTimeMultiplier;

		[Token(Token = "0x4000008")]
		[FieldOffset(Offset = "0x4")]
		public readonly int MaxSubSteps;

		[Token(Token = "0x4000009")]
		[FieldOffset(Offset = "0x8")]
		public readonly float SandScale;

		[Token(Token = "0x400000A")]
		[FieldOffset(Offset = "0xC")]
		public readonly float ConveyorScale;

		[Token(Token = "0x400000B")]
		[FieldOffset(Offset = "0x10")]
		public readonly float MoldScale;

		[Token(Token = "0x6000007")]
		[Address(RVA = "0x7AF12F8", Offset = "0x7AF12F8", Length = "0x14")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.GroupTimeMultiplier = groupTimeMultiplier;\n\tthis.MaxSubSteps = maxSubSteps;\n\tthis.SandScale = sandScale;\n\tthis.ConveyorScale = conveyorScale;\n\tthis.MoldScale = moldScale;\n\treturn;\n")]
		public ResolvedGameSpeed(float groupTimeMultiplier, int maxSubSteps, float sandScale, float conveyorScale, float moldScale)
		{
			GroupTimeMultiplier = groupTimeMultiplier;
			MaxSubSteps = maxSubSteps;
			SandScale = sandScale;
			ConveyorScale = conveyorScale;
			MoldScale = moldScale;
		}
	}
}
