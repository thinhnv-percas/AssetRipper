using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory;

namespace _game.CoreSystem.New.LevelGeneratorSystem.Conveyor
{
	[Token(Token = "0x200039B")]
	public static class PcaCurveSynthesizer
	{
		[CompilerGenerated]
		[Token(Token = "0x200039C")]
		private sealed class _003C_003Ec__DisplayClass3_0
		{
			[Token(Token = "0x4000B09")]
			[FieldOffset(Offset = "0x10")]
			public double[] vals;

			[Token(Token = "0x6000F28")]
			[Address(RVA = "0x3C97528", Offset = "0x3C97528", Length = "0x8")]
			public _003C_003Ec__DisplayClass3_0()
			{
			}

			internal unsafe int _003CSynthesize_003Eb__0(int x, int y)
			{
				global::AssetRipperInjected.RecoveryStub.Missing("PcaCurveSynthesizer._003C_003Ec__DisplayClass3_0::_003CSynthesize_003Eb__0");
				return default;
			}
		}

		[Token(Token = "0x4000B06")]
		private const int MaxComponents = 6;

		[Token(Token = "0x4000B07")]
		private const float ComponentScale = 0.85f;

		[Token(Token = "0x4000B08")]
		private const double VarianceTarget = 0.95;

		[Token(Token = "0x6000F23")]
		[Address(RVA = "0x3C95FB4", Offset = "0x3C95FB4", Length = "0x1574")]
		public unsafe static float[] Synthesize(IReadOnlyList<float[]> corpusCurves, int points, int seed)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PcaCurveSynthesizer::Synthesize");
			return default;
		}

		[Token(Token = "0x6000F24")]
		[Address(RVA = "0x3C97B60", Offset = "0x3C97B60", Length = "0x34")]
		private static float[] PinEnd(float[] curve)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PcaCurveSynthesizer::PinEnd");
			return default;
		}

		[Token(Token = "0x6000F25")]
		[Address(RVA = "0x3C97910", Offset = "0x3C97910", Length = "0x250")]
		private static float[] SafeDefault(int points)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PcaCurveSynthesizer::SafeDefault");
			return default;
		}

		[Token(Token = "0x6000F26")]
		[Address(RVA = "0x3C982E8", Offset = "0x3C982E8", Length = "0xBC")]
		private static double NextGaussian(Random rng)
		{
			double num = rng.NextDouble();
			double num2 = rng.NextDouble();
			object obj = default(object);
			double num3 = 1.0 - (double)obj;
			double num4 = 1.0 - (double)obj;
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF68C0");
			double d = num4 * -2.0;
			double num5 = num3 * (Math.PI * 2.0);
			double num6 = Math.Sqrt(d);
			Il2CppRuntime.Boundary("UNKNOWN", "Method not found @8BF6080");
			return num6 * num5;
		}

		[Token(Token = "0x6000F27")]
		[Address(RVA = "0x3C97B94", Offset = "0x3C97B94", Length = "0x754")]
		private unsafe static void JacobiEigen(double[,] aIn, int n, out double[] vals, out double[][] vecs)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("PcaCurveSynthesizer::JacobiEigen");
			vals = default;
			vecs = default;
		}
	}
}
