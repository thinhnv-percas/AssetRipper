using AssetRipperInjected;
using Cpp2ILInjected;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x200005D")]
	public static class Bounce
	{
		[Token(Token = "0x60002EC")]
		[Address(RVA = "0x1072400", Offset = "0x1072400", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv6 = duration - time;\n\tv9 = DG.Tweening.Core.Easing.Bounce::EaseOut(v6, duration, unusedOvershootOrAmplitude, unusedPeriod);\n\treturnVal1 = 1f - v9;\n\treturn returnVal1;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseIn(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			float time2 = duration - time;
			float num = EaseOut(time2, duration, unusedOvershootOrAmplitude, unusedPeriod);
			return 1f - num;
		}

		[Token(Token = "0x60002ED")]
		[Address(RVA = "0x1072420", Offset = "0x1072420", Length = "0xC4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv2 = time / duration;\n\tv14 = v2 >= 0.36363637f;\n\tif (v14) goto L_001E;\n\tv17 = v2 * 7.5625f;\n\treturnVal1 = v2 * v17;\n\treturn returnVal1;\nL_001E:\n\tv30 = v2 >= 0.72727275f;\n\tif (v30) goto L_0035;\n\tv73 = v2 + -0.54545456f;\n\tv74 = v73 * 7.5625f;\n\tv75 = v73 * v74;\n\treturnVal2 = v75 + 0.75f;\n\treturn returnVal2;\nL_0035:\n\tv43 = v2 >= 0.90909094f;\n\tif (v43) goto L_0047;\n\tv80 = v2 + -0.8181818f;\n\tv81 = v80 * 7.5625f;\n\tv82 = v80 * v81;\n\treturnVal3 = v82 + 0.9375f;\n\treturn returnVal3;\nL_0047:\n\tv86 = v2 + -0.95454544f;\n\tv41 = v86 * 7.5625f;\n\tv87 = v86 * v41;\n\treturnVal4 = v87 + 0.984375f;\n\treturn returnVal4;\n// 51 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOut(float time, float duration, float unusedOvershootOrAmplitude, float unusedPeriod)
		{
			float num = time / duration;
			if (num < 0.36363637f)
			{
				float num2 = num * 7.5625f;
				return num * num2;
			}
			if (num < 0.72727275f)
			{
				float num3 = num + -0.54545456f;
				float num4 = num3 * 7.5625f;
				float num5 = num3 * num4;
				return num5 + 0.75f;
			}
			if (num < 0.90909094f)
			{
				float num6 = num + -0.8181818f;
				float num7 = num6 * 7.5625f;
				float num8 = num6 * num7;
				return num8 + 0.9375f;
			}
			float num9 = num + -21f / 22f;
			float num10 = num9 * 7.5625f;
			float num11 = num9 * num10;
			return num11 + 63f / 64f;
		}

		[Token(Token = "0x60002EE")]
		[Address(RVA = "0x10724E4", Offset = "0x10724E4", Length = "0x54")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv9 = duration * 0.5f;\n\tv21 = time + time;\n\tv24 = v9 <= time;\n\tif (v24) goto L_001B;\n\tv25 = duration - v21;\n\tv26 = DG.Tweening.Core.Easing.Bounce::EaseOut(v25, duration, v9, unusedPeriod);\n\tv32 = 1f - v26;\n\treturnVal1 = v32 * 0.5f;\n\tgoto L_0023;\nL_001B:\n\tv29 = v21 - duration;\n\tv30 = DG.Tweening.Core.Easing.Bounce::EaseOut(v29, duration, v9, unusedPeriod);\n\tv34 = v30 * 0.5f;\n\treturnVal1 = v34 + 0.5f;\nL_0023:\n\treturn returnVal1;\n// 22 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
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
