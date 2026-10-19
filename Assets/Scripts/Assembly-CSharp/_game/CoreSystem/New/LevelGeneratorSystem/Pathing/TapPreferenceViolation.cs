using AssetRipperInjected;
using Cpp2ILInjected;
using _game.CoreSystem.New.GridEcsBinding;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Pathing
{
	[Token(Token = "0x2000359")]
	public readonly struct TapPreferenceViolation
	{
		[Token(Token = "0x40009DD")]
		[FieldOffset(Offset = "0x0")]
		public readonly int StepIndex;

		[Token(Token = "0x40009DE")]
		[FieldOffset(Offset = "0x4")]
		public readonly GridCoord Tapped;

		[Token(Token = "0x40009DF")]
		[FieldOffset(Offset = "0x10")]
		public readonly GameColor Color;

		[Token(Token = "0x40009E0")]
		[FieldOffset(Offset = "0x14")]
		public readonly GridCoord Better;

		[Token(Token = "0x40009E1")]
		[FieldOffset(Offset = "0x20")]
		public readonly TapClass BetterClass;

		[Token(Token = "0x6000DFE")]
		[Address(RVA = "0x3F01390", Offset = "0x3F01390", Length = "0x18")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.StepIndex = stepIndex;\n\tthis.Tapped = tapped;\n\t*([this @ X0 (_game.CoreSystem.New.LevelGeneratorSystem.Pathing.TapPreferenceViolation)+C]) = tapped.IsValid;\n\tthis.Color = color;\n\tthis.Better = better;\n\t*([this @ X0 (_game.CoreSystem.New.LevelGeneratorSystem.Pathing.TapPreferenceViolation)+1C]) = better.IsValid;\n\tthis.BetterClass = betterClass;\n\treturn;\n")]
		public TapPreferenceViolation(int stepIndex, GridCoord tapped, GameColor color, GridCoord better, TapClass betterClass)
		{
			StepIndex = stepIndex;
			Tapped = tapped;
			_ = tapped.IsValid;
			Color = color;
			Better = better;
			_ = better.IsValid;
			BetterClass = betterClass;
		}
	}
}
