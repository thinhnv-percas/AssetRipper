using System;
using AssetRipperInjected;
using Cpp2ILInjected;

namespace _game.Tools.AlgorithmicLevelGenerator.Generator
{
	[Serializable]
	[Token(Token = "0x200004C")]
	public class GeneratorConfig
	{
		[Token(Token = "0x400014A")]
		[FieldOffset(Offset = "0x10")]
		public int ColorCount;

		[Token(Token = "0x400014B")]
		[FieldOffset(Offset = "0x14")]
		public int HiddenMoldCount;

		[Token(Token = "0x400014C")]
		[FieldOffset(Offset = "0x18")]
		public int LinkedMoldPairCount;

		[Token(Token = "0x400014D")]
		[FieldOffset(Offset = "0x1C")]
		public Difficulty Difficulty;

		[Token(Token = "0x400014E")]
		[FieldOffset(Offset = "0x20")]
		public int Seed;

		[Token(Token = "0x400014F")]
		[FieldOffset(Offset = "0x24")]
		public bool EnablePathingCheck;

		[Token(Token = "0x4000150")]
		[FieldOffset(Offset = "0x28")]
		public int PathingRolloutCount;

		[Token(Token = "0x4000151")]
		[FieldOffset(Offset = "0x2C")]
		public float TargetConveyorAvgPct;

		[Token(Token = "0x4000152")]
		[FieldOffset(Offset = "0x30")]
		public float MaxConveyorPeakPct;

		[Token(Token = "0x4000153")]
		[FieldOffset(Offset = "0x34")]
		public int PermutationBudget;

		[Token(Token = "0x4000154")]
		[FieldOffset(Offset = "0x38")]
		public float MoldRandomization;

		[Token(Token = "0x60000CD")]
		[Address(RVA = "0x3C19C7C", Offset = "0x3C19C7C", Length = "0x30")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tthis.ColorCount = 8;\n\tthis.Difficulty = 1;\n\tthis.PathingRolloutCount = 0x14;\n\tthis.TargetConveyorAvgPct = 0f;\n\tthis.PermutationBudget = 6;\n\tSystem.Object::.ctor(this);\n\treturn;\n")]
		public GeneratorConfig()
		{
			ColorCount = 8;
			Difficulty = Difficulty.Medium;
			PathingRolloutCount = 20;
			TargetConveyorAvgPct = 0f;
			PermutationBudget = 6;
		}
	}
}
