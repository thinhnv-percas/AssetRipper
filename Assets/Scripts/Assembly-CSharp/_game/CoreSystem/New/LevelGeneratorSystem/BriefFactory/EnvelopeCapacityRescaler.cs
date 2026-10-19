using System;
using Cpp2ILInjected;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Token(Token = "0x20003AD")]
	public static class EnvelopeCapacityRescaler
	{
		[Token(Token = "0x4000B50")]
		public const double RatioMin = 0.9;

		[Token(Token = "0x4000B51")]
		public const double RatioMax = 1.0;

		[Token(Token = "0x6000F56")]
		[Address(RVA = "0x3C9C01C", Offset = "0x3C9C01C", Length = "0x24C")]
		public static FeatureEnvelope Rescale(FeatureEnvelope env, int seed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnvelopeCapacityRescaler::Rescale");
			return default;
		}

		[Token(Token = "0x6000F57")]
		[Address(RVA = "0x3C9C270", Offset = "0x3C9C270", Length = "0x470")]
		private static FeatureStat Scale(FeatureStat s, Random rng)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnvelopeCapacityRescaler::Scale");
			return default;
		}

		[Token(Token = "0x6000F58")]
		[Address(RVA = "0x3C9C6E8", Offset = "0x3C9C6E8", Length = "0xF0")]
		private static int R(int v, double r)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("EnvelopeCapacityRescaler::R");
			return default;
		}
	}
}
