using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Cpp2ILInjected;
using UnityEngine;

namespace _game.CoreSystem.New.LevelGeneratorSystem.BriefFactory
{
	[Token(Token = "0x20003AC")]
	public static class CurveSynthesizer
	{
		[Token(Token = "0x6000F53")]
		[Address(RVA = "0x3C97530", Offset = "0x3C97530", Length = "0x3E0")]
		public static float[] Resample(float[] source, int n)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurveSynthesizer::Resample");
			return default;
		}

		[Token(Token = "0x6000F54")]
		[Address(RVA = "0x3C9B924", Offset = "0x3C9B924", Length = "0x5B8")]
		public static float[] Mean(IReadOnlyList<float[]> curves)
		{
			global::AssetRipperInjected.RecoveryStub.Missing("CurveSynthesizer::Mean");
			return default;
		}

		[Token(Token = "0x6000F55")]
		[Address(RVA = "0x3C9BEDC", Offset = "0x3C9BEDC", Length = "0x140")]
		public static AnimationCurve ToAnimationCurve(float[] fills)
		{
			AnimationCurve animationCurve = new AnimationCurve();
			if (fills != null)
			{
				int num = fills.Length;
				if (fills.Length != 0)
				{
					int num2 = fills.Length - 1;
					if (fills.Length >= 1)
					{
						if (animationCurve == null)
						{
							int num3 = fills.Length & 0x7FFFFFFF;
							bool flag = num3 == 1;
							float time = 0f;
							if (!flag)
							{
								time = 0f / (float)num2;
							}
							Keyframe keyframe = default(Keyframe);
							keyframe = new Keyframe(time, fills[0]);
							return (AnimationCurve)(object)new NullReferenceException();
						}
						int num4 = 0;
						int num5 = fills.Length;
						bool flag3;
						do
						{
							bool flag2 = num == 1;
							float time2 = 0f;
							if (!flag2)
							{
								int num6 = num5 - 1;
								time2 = (float)num4 / (float)num6;
							}
							Keyframe keyframe = new Keyframe(time2, fills[num4]);
							Keyframe key = keyframe;
							int num7 = animationCurve.AddKey(key);
							num4++;
							num5 = fills.Length;
							flag3 = num4 >= fills.Length;
							num = fills.Length;
						}
						while (!flag3);
					}
				}
			}
			return animationCurve;
		}
	}
}
