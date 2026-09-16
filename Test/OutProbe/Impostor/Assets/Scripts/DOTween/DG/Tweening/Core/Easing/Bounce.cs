using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x20000C2")]
	public static class Bounce
	{
		[Token(Token = "0x6000471")]
		[Address(RVA = "0xC32DE4", Offset = "0xC32DE4", Length = "0x1C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = duration - time;\n\tv5 = DG.Tweening.Core.Easing.Bounce::EaseOut(v2, duration, unusedOvershootOrAmplitude, unusedPeriod);\n\treturnVal1 = 1f - v5;\n\treturn returnVal1;\n// 5 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseIn(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			float time2 = duration - time;
			float num = EaseOut(time2, duration, unusedOvershootOrAmplitude, unusedPeriod);
			return 1f - num;
		}

		[Token(Token = "0x6000472")]
		[Address(RVA = "0xC32E00", Offset = "0xC32E00", Length = "0xBC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = time / duration;\n\tv14 = v2 >= 0.36363637f;\n\tif (v14) goto L_001E;\n\tv17 = v2 * 0x40F20000;\n\treturnVal1 = v2 * v17;\n\treturn returnVal1;\nL_001E:\n\tv30 = v2 >= 0.72727275f;\n\tif (v30) goto L_0034;\n\tv61 = v2 + -0.54545456f;\n\tv62 = v61 * 0x40F20000;\n\tv79 = v61 * v62;\n\tgoto L_0048;\nL_0034:\n\tv76 = v2 >= 0.90909094f;\n\tif (v76) goto L_0044;\n\tv88 = v2 + -0.8181818f;\n\tv89 = v88 * 0x40F20000;\n\tv79 = v88 * v89;\n\tgoto L_0048;\nL_0044:\n\tv93 = v2 + -0.95454544f;\n\tv94 = v93 * 0x40F20000;\n\tv79 = v93 * v94;\nL_0048:\n\treturnVal2 = v79 + v32;\n\treturn returnVal2;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOut(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			float num = time / duration;
			if (num < 0.36363637f)
			{
				float num2 = num * 7.5625f;
				return num * num2;
			}
			float num5;
			float num6;
			if (num < 0.72727275f)
			{
				float num3 = num + -0.54545456f;
				float num4 = num3 * 7.5625f;
				num5 = num3 * num4;
				num6 = 0.75f;
			}
			else if (num < 0.90909094f)
			{
				float num7 = num + -0.8181818f;
				float num8 = num7 * 7.5625f;
				num5 = num7 * num8;
				num6 = 0.9375f;
			}
			else
			{
				float num9 = num + -21f / 22f;
				float num10 = num9 * 7.5625f;
				num5 = num9 * num10;
				num6 = 63f / 64f;
			}
			return num5 + num6;
		}

		[Token(Token = "0x6000473")]
		[Address(RVA = "0xC32EBC", Offset = "0xC32EBC", Length = "0x50")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv5 = duration * 0.5f;\n\tv17 = time + time;\n\tv20 = v5 <= time;\n\tif (v20) goto L_0019;\n\tv21 = duration - v17;\n\tv22 = DG.Tweening.Core.Easing.Bounce::EaseOut(v21, duration, v5, unusedPeriod);\n\tv28 = 1f - v22;\n\treturnVal1 = v28 * 0.5f;\n\tgoto L_0020;\nL_0019:\n\tv25 = v17 - duration;\n\tv26 = DG.Tweening.Core.Easing.Bounce::EaseOut(v25, duration, v5, unusedPeriod);\n\tv30 = v26 * 0.5f;\n\treturnVal1 = v30 + 0.5f;\nL_0020:\n\treturn returnVal1;\n// 19 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOut(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			float num = duration * 0.5f;
			float num2 = time + time;
			if (num > time)
			{
				float time2 = duration - num2;
				float num3 = EaseOut(time2, duration, num, unusedPeriod);
				float num4 = 1f - num3;
				return num4 * 0.5f;
			}
			float time3 = num2 - duration;
			float num5 = EaseOut(time3, duration, num, unusedPeriod);
			float num6 = num5 * 0.5f;
			return num6 + 0.5f;
		}
	}
}
