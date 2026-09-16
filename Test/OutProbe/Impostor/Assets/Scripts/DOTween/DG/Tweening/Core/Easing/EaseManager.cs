using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x20000C3")]
	public static class EaseManager
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20000C4")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x4000288")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x4000289")]
			public static EaseFunction _003C_003E9__4_0;

			[Token(Token = "0x400028A")]
			public static EaseFunction _003C_003E9__4_1;

			[Token(Token = "0x400028B")]
			public static EaseFunction _003C_003E9__4_2;

			[Token(Token = "0x400028C")]
			public static EaseFunction _003C_003E9__4_3;

			[Token(Token = "0x400028D")]
			public static EaseFunction _003C_003E9__4_4;

			[Token(Token = "0x400028E")]
			public static EaseFunction _003C_003E9__4_5;

			[Token(Token = "0x400028F")]
			public static EaseFunction _003C_003E9__4_6;

			[Token(Token = "0x4000290")]
			public static EaseFunction _003C_003E9__4_7;

			[Token(Token = "0x4000291")]
			public static EaseFunction _003C_003E9__4_8;

			[Token(Token = "0x4000292")]
			public static EaseFunction _003C_003E9__4_9;

			[Token(Token = "0x4000293")]
			public static EaseFunction _003C_003E9__4_10;

			[Token(Token = "0x4000294")]
			public static EaseFunction _003C_003E9__4_11;

			[Token(Token = "0x4000295")]
			public static EaseFunction _003C_003E9__4_12;

			[Token(Token = "0x4000296")]
			public static EaseFunction _003C_003E9__4_13;

			[Token(Token = "0x4000297")]
			public static EaseFunction _003C_003E9__4_14;

			[Token(Token = "0x4000298")]
			public static EaseFunction _003C_003E9__4_15;

			[Token(Token = "0x4000299")]
			public static EaseFunction _003C_003E9__4_16;

			[Token(Token = "0x400029A")]
			public static EaseFunction _003C_003E9__4_17;

			[Token(Token = "0x400029B")]
			public static EaseFunction _003C_003E9__4_18;

			[Token(Token = "0x400029C")]
			public static EaseFunction _003C_003E9__4_19;

			[Token(Token = "0x400029D")]
			public static EaseFunction _003C_003E9__4_20;

			[Token(Token = "0x400029E")]
			public static EaseFunction _003C_003E9__4_21;

			[Token(Token = "0x400029F")]
			public static EaseFunction _003C_003E9__4_22;

			[Token(Token = "0x40002A0")]
			public static EaseFunction _003C_003E9__4_23;

			[Token(Token = "0x40002A1")]
			public static EaseFunction _003C_003E9__4_24;

			[Token(Token = "0x40002A2")]
			public static EaseFunction _003C_003E9__4_25;

			[Token(Token = "0x40002A3")]
			public static EaseFunction _003C_003E9__4_26;

			[Token(Token = "0x40002A4")]
			public static EaseFunction _003C_003E9__4_27;

			[Token(Token = "0x40002A5")]
			public static EaseFunction _003C_003E9__4_28;

			[Token(Token = "0x40002A6")]
			public static EaseFunction _003C_003E9__4_29;

			[Token(Token = "0x40002A7")]
			public static EaseFunction _003C_003E9__4_30;

			[Token(Token = "0x40002A8")]
			public static EaseFunction _003C_003E9__4_31;

			[Token(Token = "0x40002A9")]
			public static EaseFunction _003C_003E9__4_32;

			[Token(Token = "0x40002AA")]
			public static EaseFunction _003C_003E9__4_33;

			[Token(Token = "0x40002AB")]
			public static EaseFunction _003C_003E9__4_34;

			[Token(Token = "0x40002AC")]
			public static EaseFunction _003C_003E9__4_35;

			[Token(Token = "0x6000478")]
			[Address(RVA = "0xC35068", Offset = "0xC35068", Length = "0x5C")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0012;\n\tv14 = DG.Tweening.Core.Easing.EaseManager+<>c;\n\tv15 = \"il2cpp_codegen_initialize_runtime_metadata\"(v14, v16, v17, v18, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30);\n\tv34 = 1;\n\t*([1A35814]) = v34;\nL_0012:\n\tv36 = new DG.Tweening.Core.Easing.EaseManager+<>c();\n\tSystem.Object::.ctor(v36);\n\tv40.<>9 = v36;\n\treturn;\n// 21 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000479")]
			[Address(RVA = "0xC350C4", Offset = "0xC350C4", Length = "0x8")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tSystem.Object::.ctor(this);\n\treturn;\n// 1 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			public _003C_003Ec()
			{
			}

			internal float _003CToEaseFunction_003Eb__4_0(float time, float duration, float overshootOrAmplitude, float period)
			{
				return time / duration;
			}

			internal float _003CToEaseFunction_003Eb__4_1(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num * ((float)Math.PI / 2f);
				Il2CppRuntime.Boundary("SYSTEM_API:cos", "Method not found @1854F50 (native cos)");
				return 1f - num2;
			}

			internal float _003CToEaseFunction_003Eb__4_2(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float result = num * ((float)Math.PI / 2f);
				Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_3(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time * (float)Math.PI;
				float num2 = num / duration;
				Il2CppRuntime.Boundary("SYSTEM_API:cos", "Method not found @1854F50 (native cos)");
				float num3 = num2 + -1f;
				return num3 * -0.5f;
			}

			internal float _003CToEaseFunction_003Eb__4_4(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				return num * num;
			}

			internal float _003CToEaseFunction_003Eb__4_5(float time, float duration, float overshootOrAmplitude, float period)
			{
				//IL_0018: Expected O, but got F4
				float num = time / duration;
				object obj = 0f - num;
				float num2 = num + -2f;
				return num2 * (float)obj;
			}

			internal float _003CToEaseFunction_003Eb__4_6(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = duration * 0.5f;
				float num2 = time / num;
				float num3;
				if (num2 < 1f)
				{
					num3 = num2 * 0.5f;
				}
				else
				{
					float num4 = num2 + -1f;
					float num5 = num4 + -2f;
					float num6 = num4 * num5;
					num2 = num6 + -1f;
					num3 = -0.5f;
				}
				return num2 * num3;
			}

			internal float _003CToEaseFunction_003Eb__4_7(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num * num;
				return num * num2;
			}

			internal float _003CToEaseFunction_003Eb__4_8(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num + -1f;
				float num3 = num2 * num2;
				float num4 = num2 * num3;
				return num4 + 1f;
			}

			internal float _003CToEaseFunction_003Eb__4_9(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = duration * 0.5f;
				float num2 = time / num;
				if (num2 < 1f)
				{
					float num3 = num2 * 0.5f;
					float num4 = num2 * num3;
					return num2 * num4;
				}
				float num5 = num2 + -2f;
				float num6 = num5 * num5;
				float num7 = num5 * num6;
				float num8 = num7 + 2f;
				return num8 * 0.5f;
			}

			internal float _003CToEaseFunction_003Eb__4_10(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num * num;
				float num3 = num * num2;
				return num * num3;
			}

			internal float _003CToEaseFunction_003Eb__4_11(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num + -1f;
				float num3 = num2 * num2;
				float num4 = num2 * num3;
				float num5 = num2 * num4;
				float num6 = num5 + -1f;
				return 0f - num6;
			}

			internal float _003CToEaseFunction_003Eb__4_12(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = duration * 0.5f;
				float num2 = time / num;
				float num5;
				if (num2 < 1f)
				{
					float num3 = num2 * 0.5f;
					float num4 = num2 * num3;
					num5 = num2 * num4;
				}
				else
				{
					float num6 = num2 + -2f;
					float num7 = num6 * num6;
					float num8 = num6 * num7;
					float num9 = num6 * num8;
					num2 = num9 + -2f;
					num5 = -0.5f;
				}
				return num2 * num5;
			}

			internal float _003CToEaseFunction_003Eb__4_13(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num * num;
				float num3 = num * num2;
				float num4 = num * num3;
				return num * num4;
			}

			internal float _003CToEaseFunction_003Eb__4_14(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num + -1f;
				float num3 = num2 * num2;
				float num4 = num2 * num3;
				float num5 = num2 * num4;
				float num6 = num2 * num5;
				return num6 + 1f;
			}

			internal float _003CToEaseFunction_003Eb__4_15(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = duration * 0.5f;
				float num2 = time / num;
				if (num2 < 1f)
				{
					float num3 = num2 * 0.5f;
					float num4 = num2 * num3;
					float num5 = num2 * num4;
					float num6 = num2 * num5;
					return num2 * num6;
				}
				float num7 = num2 + -2f;
				float num8 = num7 * num7;
				float num9 = num7 * num8;
				float num10 = num7 * num9;
				float num11 = num7 * num10;
				float num12 = num11 + 2f;
				return num12 * 0.5f;
			}

			internal float _003CToEaseFunction_003Eb__4_16(float time, float duration, float overshootOrAmplitude, float period)
			{
				bool flag = time == 0f;
				float result = 0f;
				if (!flag)
				{
					float num = time / duration;
					float num2 = num + -1f;
					float num3 = num2 * 10f;
					double num4 = Math.Pow(2.0, num3);
					result = (float)num4;
				}
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_17(float time, float duration, float overshootOrAmplitude, float period)
			{
				bool flag = time == duration;
				float result = 1f;
				if (!flag)
				{
					float num = time * -10f;
					float num2 = num / duration;
					double num3 = Math.Pow(2.0, num2);
					result = 1f - (float)num3;
				}
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_18(float time, float duration, float overshootOrAmplitude, float period)
			{
				bool flag = time == 0f;
				float result = 0f;
				if (!flag)
				{
					bool flag2 = time == duration;
					result = 1f;
					if (!flag2)
					{
						float num = duration * 0.5f;
						float num2 = time / num;
						double num5;
						if (num2 < 1f)
						{
							float num3 = num2 + -1f;
							float num4 = num3 * 10f;
							num5 = Math.Pow(2.0, num4);
						}
						else
						{
							float num6 = num2 + -1f;
							float num7 = num6 * -10f;
							double num8 = Math.Pow(2.0, num7);
							float num9 = 2f - (float)num8;
							num5 = num9;
						}
						result = (float)num5 * 0.5f;
					}
				}
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_19(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num * num;
				float f = 1f - num2;
				float num3 = Mathf.Sqrt(f);
				float num4 = num3 + -1f;
				return 0f - num4;
			}

			internal float _003CToEaseFunction_003Eb__4_20(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num + -1f;
				float num3 = num2 * num2;
				float f = 1f - num3;
				return Mathf.Sqrt(f);
			}

			internal float _003CToEaseFunction_003Eb__4_21(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = duration * 0.5f;
				float num2 = time / num;
				float num3;
				float num4;
				float num5;
				if (num2 < 1f)
				{
					num3 = num2 * num2;
					num4 = -1f;
					num5 = -0.5f;
				}
				else
				{
					float num6 = num2 + -2f;
					num3 = num6 * num6;
					num4 = 1f;
					num5 = 0.5f;
				}
				float f = 1f - num3;
				float num7 = Mathf.Sqrt(f);
				float num8 = num7 + num4;
				return num8 * num5;
			}

			internal float _003CToEaseFunction_003Eb__4_22(float time, float duration, float overshootOrAmplitude, float period)
			{
				float result;
				if (time != 0f)
				{
					float num = time / duration;
					bool flag = num == 1f;
					result = 1f;
					if (!flag)
					{
						float num2 = duration * 0.3f;
						float num3 = ((period != 0f) ? period : num2);
						float num4;
						float num5;
						if (overshootOrAmplitude < 1f)
						{
							num4 = num3 * 0.25f;
							num5 = 1f;
						}
						else
						{
							float num6 = 1f / overshootOrAmplitude;
							Il2CppRuntime.Boundary("SYSTEM_API:asin", "Method not found @1854F70 (native asin)");
							float num7 = num3 / ((float)Math.PI * 2f);
							num4 = num7 * num6;
							num5 = overshootOrAmplitude;
						}
						float num8 = num + -1f;
						float num9 = num8 * 10f;
						double num10 = Math.Pow(2.0, num9);
						float num11 = num8 * duration;
						float num12 = num11 - num4;
						float num13 = num12 * ((float)Math.PI * -2f);
						float num14 = num13 / num3;
						Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
						float num15 = num5 * (float)num10;
						result = num15 * num14;
					}
				}
				else
				{
					result = 0f;
				}
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_23(float time, float duration, float overshootOrAmplitude, float period)
			{
				float result;
				if (time != 0f)
				{
					float num = time / duration;
					bool flag = num == 1f;
					result = 1f;
					if (!flag)
					{
						float num2 = duration * 0.3f;
						float num3 = ((period != 0f) ? period : num2);
						float num4;
						float num5;
						if (overshootOrAmplitude < 1f)
						{
							num4 = num3 * 0.25f;
							num5 = 1f;
						}
						else
						{
							float num6 = 1f / overshootOrAmplitude;
							Il2CppRuntime.Boundary("SYSTEM_API:asin", "Method not found @1854F70 (native asin)");
							float num7 = num3 / ((float)Math.PI * 2f);
							num4 = num7 * num6;
							num5 = overshootOrAmplitude;
						}
						float num8 = num * -10f;
						double num9 = Math.Pow(2.0, num8);
						float num10 = num * duration;
						float num11 = num10 - num4;
						float num12 = num11 * ((float)Math.PI * 2f);
						float num13 = num12 / num3;
						Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
						float num14 = num5 * (float)num9;
						float num15 = num14 * num13;
						result = num15 + 1f;
					}
				}
				else
				{
					result = 0f;
				}
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_24(float time, float duration, float overshootOrAmplitude, float period)
			{
				if (time != 0f)
				{
					float num = duration * 0.5f;
					float num2 = time / num;
					if (num2 != 2f)
					{
						float num3 = duration * 0.45000002f;
						float num4 = ((period != 0f) ? period : num3);
						float num5;
						float num6;
						if (overshootOrAmplitude < 1f)
						{
							num5 = num4 * 0.25f;
							num6 = 1f;
						}
						else
						{
							float num7 = 1f / overshootOrAmplitude;
							Il2CppRuntime.Boundary("SYSTEM_API:asin", "Method not found @1854F70 (native asin)");
							float num8 = num4 / ((float)Math.PI * 2f);
							num5 = num8 * num7;
							num6 = overshootOrAmplitude;
						}
						float num9 = num2 + -1f;
						if (num2 < 1f)
						{
							float num10 = num9 * 10f;
							double num11 = Math.Pow(2.0, num10);
							float num12 = num9 * duration;
							float num13 = num12 - num5;
							float num14 = num13 * ((float)Math.PI * 2f);
							float num15 = num14 / num4;
							Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
							float num16 = num6 * (float)num11;
							float num17 = num16 * num15;
							return num17 * -0.5f;
						}
						float num18 = num9 * -10f;
						double num19 = Math.Pow(2.0, num18);
						float num20 = num9 * duration;
						float num21 = num20 - num5;
						float num22 = num21 * ((float)Math.PI * 2f);
						float num23 = num22 / num4;
						Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @1854F60 (native sin)");
						float num24 = num6 * (float)num19;
						float num25 = num24 * num23;
						float num26 = num25 * 0.5f;
						return num26 + 1f;
					}
					return 1f;
				}
				return 0f;
			}

			internal float _003CToEaseFunction_003Eb__4_25(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = overshootOrAmplitude + 1f;
				float num3 = num * num;
				float num4 = num * num2;
				float num5 = num4 - overshootOrAmplitude;
				return num3 * num5;
			}

			internal float _003CToEaseFunction_003Eb__4_26(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float num2 = num + -1f;
				float num3 = overshootOrAmplitude + 1f;
				float num4 = num2 * num2;
				float num5 = num3 * num2;
				float num6 = num5 + overshootOrAmplitude;
				float num7 = num4 * num6;
				return num7 + 1f;
			}

			internal float _003CToEaseFunction_003Eb__4_27(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = duration * 0.5f;
				float num2 = time / num;
				float num8;
				if (num2 < 1f)
				{
					float num3 = overshootOrAmplitude * 1.525f;
					float num4 = num3 + 1f;
					float num5 = num2 * num4;
					float num6 = num2 * num2;
					float num7 = num5 - num3;
					num8 = num6 * num7;
				}
				else
				{
					float num9 = overshootOrAmplitude * 1.525f;
					float num10 = num2 + -2f;
					float num11 = num9 + 1f;
					float num12 = num11 * num10;
					float num13 = num10 * num10;
					float num14 = num9 + num12;
					float num15 = num13 * num14;
					num8 = num15 + 2f;
				}
				return num8 * 0.5f;
			}

			internal float _003CToEaseFunction_003Eb__4_28(float time, float duration, float overshootOrAmplitude, float period)
			{
				float time2 = duration - time;
				float num = Bounce.EaseOut(time2, duration, overshootOrAmplitude, period);
				return 1f - num;
			}

			internal float _003CToEaseFunction_003Eb__4_29(float time, float duration, float overshootOrAmplitude, float period)
			{
				return Bounce.EaseOut(time, duration, overshootOrAmplitude, period);
			}

			internal float _003CToEaseFunction_003Eb__4_30(float time, float duration, float overshootOrAmplitude, float period)
			{
				return Bounce.EaseInOut(time, duration, overshootOrAmplitude, period);
			}

			internal float _003CToEaseFunction_003Eb__4_31(float time, float duration, float overshootOrAmplitude, float period)
			{
				return Flash.Ease(time, duration, overshootOrAmplitude, period);
			}

			internal float _003CToEaseFunction_003Eb__4_32(float time, float duration, float overshootOrAmplitude, float period)
			{
				return Flash.EaseIn(time, duration, overshootOrAmplitude, period);
			}

			internal float _003CToEaseFunction_003Eb__4_33(float time, float duration, float overshootOrAmplitude, float period)
			{
				return Flash.EaseOut(time, duration, overshootOrAmplitude, period);
			}

			internal float _003CToEaseFunction_003Eb__4_34(float time, float duration, float overshootOrAmplitude, float period)
			{
				return Flash.EaseInOut(time, duration, overshootOrAmplitude, period);
			}

			internal float _003CToEaseFunction_003Eb__4_35(float time, float duration, float overshootOrAmplitude, float period)
			{
				//IL_0018: Expected O, but got F4
				float num = time / duration;
				object obj = 0f - num;
				float num2 = num + -2f;
				return num2 * (float)obj;
			}
		}

		[Token(Token = "0x4000286")]
		private const float _PiOver2 = (float)Math.PI / 2f;

		[Token(Token = "0x4000287")]
		private const float _TwoPi = (float)Math.PI * 2f;

		[Token(Token = "0x6000474")]
		[Address(RVA = "0xC32F0C", Offset = "0xC32F0C", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, time, duration, overshootOrAmplitude, period);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn time;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Evaluate(Tween t, float time, float duration, float overshootOrAmplitude, float period)
		{
			return Evaluate(t.easeType, t.customEase, time, duration, overshootOrAmplitude, period);
		}

		[Token(Token = "0x6000475")]
		[Address(RVA = "0xC32F2C", Offset = "0xC32F2C", Length = "0xA40")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001D;\n\tv40 = System.Math;\n\tv41 = \"il2cpp_codegen_initialize_runtime_metadata\"(v40, customEase, methodInfo, v43, v44, v45, v46, v47, time, duration, overshootOrAmplitude, period, v48, v49, v50, v51);\n\tv54 = 1;\n\t*([1A35812]) = v54;\nL_001D:\n\tv55 = v52 - 1;\n\tv56 = v55 < 0x24;\n\tv57 = ~v56;\n\tv58 = v55 - 0x24;\n\tv60 = v58 == 0;\n\tv65 = ~v60;\n\tv66 = v57 & v65;\n\tif (v66) goto L_0034;\n\tv68 = 0x424000 + 0x18C;\n\tv71 = *([v68 @ X9_v2 (System.Int32)+v55 @ X8_v3 (System.Int32)*2]) << 2;\n\tv72 = 0xC36FA4 + v71;\n\t// 49 IndirectJump v72 @ X10_v2 (System.Int32), v52 @ X0_v1 (DG.Tweening.Ease), v52 @ X0_v1 (DG.Tweening.Ease), customEase @ X1 (DG.Tweening.EaseFunction), methodInfo @ X2 (Il2CppMethodInfo), v43 @ X3, v44 @ X4, v45 @ X5, v46 @ X6, v47 @ X7, 1f, duration @ V1 (System.Single), overshootOrAmplitude @ V2 (System.Single), period @ V3 (System.Single), v48 @ V4, v49 @ V5, v50 @ V6, v51 @ V7\n\tV0 = V10 / V8;\n\tgoto L_0354;\nL_0034:\n\tv74 = time / duration;\n\tv76 = -v74;\n\tv77 = v74 + -2f;\n\treturnVal1 = v77 * v76;\n\tgoto L_0354;\n\tV0 = V10;\n\tV1 = V8;\n\tV2 = V9;\n\tV3 = V11;\n\tX20 = stack[50];\n\tX19 = stack[58];\n\tX30 = stack[40];\n\tX21 = stack[48];\n\tV9 = stack[30];\n\tV8 = stack[38];\n\tV11 = stack[20];\n\tV10 = stack[28];\n\tV13 = stack[10];\n\tV12 = stack[18];\n\tV14 = stack[0];\n\t// 73 ShiftStack 96\n\tV0 = DG.Tweening.Core.Easing.Flash::EaseInOut(V0, V1, V2, V3, X0);\n\treturn V0;\n\tX8 = *([19355D8]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0054;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0054:\n\tX8 = 0x407000;\n\tV0 = 1.5707964f;\n\tV1 = V10 / V8;\n\tV0 = V1 * V0;\n\tV0 = V0;\n\tX0 = 0x1854F50(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_011F;\n\tX8 = *([19355D8]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0063;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0063:\n\tX8 = 0x407000;\n\tV0 = 1.5707964f;\n\tV1 = V10 / V8;\n\tV0 = V1 * V0;\n\tV0 = V0;\n\tX0 = 0x1854F60(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0104;\n\tX8 = *([19355D8]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0072;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0072:\n\tX8 = 0x407000;\n\tV0 = 3.1415927f;\n\tV0 = V10 * V0;\n\tV0 = V0 / V8;\n\tV0 = V0;\n\tX0 = 0x1854F50(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V0;\n\tV1 = -1f;\n\tgoto L_02E3;\n\tV0 = V10 / V8;\n\tV0 = V0 * V0;\n\tgoto L_0354;\n\tV1 = 0.5f;\n\tV0 = V8 * V1;\n\tV0 = V10 / V0;\n\tV2 = 1f;\n\tC = V0 < V2;\n\tC = ~C;\n\tTEMP1 = V0 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V2;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (N) goto L_00C9;\n\tV1 = -1f;\n\tV2 = -2f;\n\tV0 = V0 + V1;\n\tV2 = V0 + V2;\n\tgoto L_02E2;\n\tV0 = V10 / V8;\n\tV1 = V0 * V0;\n\tgoto L_0318;\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV1 = V0 * V0;\n\tgoto L_00D1;\n\tV0 = 0.5f;\n\tV1 = V8 * V0;\n\tV1 = V10 / V1;\n\tV2 = 1f;\n\tC = V1 < V2;\n\tC = ~C;\n\tTEMP1 = V1 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V1 ^ V2;\n\tTEMP3 = V1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (N) goto L_00E6;\n\tV2 = -2f;\n\tV1 = V1 + V2;\n\tV2 = V1 * V1;\n\tgoto L_02EB;\n\tV0 = V10 / V8;\n\tV1 = V0 * V0;\n\tgoto L_00C9;\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV2 = V0 * V0;\n\tV2 = V0 * V2;\n\tV0 = V0 * V2;\n\tgoto L_0164;\n\tV1 = 0.5f;\n\tV0 = V8 * V1;\n\tV0 = V10 / V0;\n\tV2 = 1f;\n\tC = V0 < V2;\n\tC = ~C;\n\tTEMP1 = V0 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V2;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_02DE;\n\tV1 = V0 * V1;\n\tgoto L_00C8;\n\tV0 = V10 / V8;\n\tV1 = V0 * V0;\nL_00C8:\n\tV1 = V0 * V1;\nL_00C9:\n\tV1 = V0 * V1;\n\tgoto L_0318;\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV1 = V0 * V0;\n\tV1 = V0 * V1;\n\tV1 = V0 * V1;\nL_00D1:\n\tV0 = V0 * V1;\nL_00D2:\n\tV1 = 1f;\n\tV0 = V0 + V1;\n\tgoto L_0354;\n\tV0 = 0.5f;\n\tV1 = V8 * V0;\n\tV1 = V10 / V1;\n\tV2 = 1f;\n\tC = V1 < V2;\n\tC = ~C;\n\tTEMP1 = V1 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V1 ^ V2;\n\tTEMP3 = V1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_02E6;\n\tV0 = V1 * V0;\n\tV0 = V1 * V0;\nL_00E6:\n\tV0 = V1 * V0;\n\tV0 = V1 * V0;\n\tgoto L_0347;\n\tC = V10 < 0;\n\tC = ~C;\n\tTEMP1 = V10 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ 0;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_023F;\n\tX8 = *([19355D8]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00FB;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_00FB:\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV1 = 10f;\n\tV0 = V0 * V1;\n\tV1 = V0;\n\tV0 = 2d;\n\tX0 = 0;\n\tV0 = System.Math::Pow(V0, V1, X0);\nL_0104:\n\tV0 = V0;\n\tgoto L_0354;\n\tC = V10 < V8;\n\tC = ~C;\n\tTEMP1 = V10 - V8;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ V8;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0354;\n\tX8 = *([19355D8]);\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0118;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0118:\n\tV0 = -10f;\n\tV0 = V10 * V0;\n\tV0 = V0 / V8;\n\tV1 = V0;\n\tV0 = 2d;\n\tX0 = 0;\n\tV0 = System.Math::Pow(V0, V1, X0);\nL_011F:\n\tV0 = V0;\n\tgoto L_026F;\n\tC = V10 < 0;\n\tC = ~C;\n\tTEMP1 = V10 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ 0;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_023F;\n\tC = V10 < V8;\n\tC = ~C;\n\tTEMP1 = V10 - V8;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ V8;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0354;\n\tV0 = 0.5f;\n\tX8 = *([19355D8]);\n\tV0 = V8 * V0;\n\tV8 = V10 / V0;\n\tV0 = 1f;\n\tC = V8 < V0;\n\tC = ~C;\n\tTEMP1 = V8 - V0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ V0;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_0306;\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014C;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_014C:\n\tV0 = -1f;\n\tV0 = V8 + V0;\n\tV1 = 10f;\n\tV0 = V0 * V1;\n\tV1 = V0;\n\tV0 = 2d;\n\tX0 = 0;\n\tV0 = System.Math::Pow(V0, V1, X0);\n\tV0 = V0;\n\tgoto L_0317;\n\tX8 = *([19355D8]);\n\tV8 = V10 / V8;\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_015F;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_015F:\n\tV0 = V8 * V8;\n\tV1 = 1f;\n\tV0 = V1 - V0;\n\tV0 = UnityEngine.Mathf::Sqrt(V0);\n\tV1 = -1f;\nL_0164:\n\tV0 = V0 + V1;\n\tV0 = -V0;\n\tgoto L_0354;\n\tX8 = *([19355D8]);\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV8 = V0 + V1;\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0172;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0172:\n\tV0 = V8 * V8;\n\tV1 = 1f;\n\tV0 = V1 - V0;\n\tV0 = UnityEngine.Mathf::Sqrt(V0);\n\tgoto L_0354;\n\tV0 = 0.5f;\n\tX8 = *([19355D8]);\n\tV0 = V8 * V0;\n\tV8 = V10 / V0;\n\tV0 = 1f;\n\tC = V8 < V0;\n\tC = ~C;\n\tTEMP1 = V8 - V0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ V0;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_02ED;\n\tX0 = *([X8]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_018E;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_018E:\n\tV0 = V8 * V8;\n\tV1 = 1f;\n\tV0 = V1 - V0;\n\tV2 = -1f;\n\tV0 = UnityEngine.Mathf::Sqrt(V0);\n\tV0 = V0 + V2;\n\tgoto L_02E4;\n\tC = V10 < 0;\n\tC = ~C;\n\tTEMP1 = V10 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ 0;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_023F;\n\tV10 = V10 / V8;\n\tV0 = 1f;\n\tC = V10 < V0;\n\tC = ~C;\n\tTEMP1 = V10 - V0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ V0;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0354;\n\tV0 = 0.3f;\n\tC = V11 < 0;\n\tC = ~C;\n\tTEMP1 = V11 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V11 ^ 0;\n\tTEMP3 = V11 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tV1 = 1f;\n\tV0 = V8 * V0;\n\tTEMPCSEL = ~Z;\n\tif (TEMPCSEL) goto L_01BC;\n\tV11 = V0;\n\tgoto L_01BD;\nL_01BC:\n\tV11 = V11;\nL_01BD:\n\t;\n\tC = V9 < V1;\n\tC = ~C;\n\tTEMP1 = V9 - V1;\n\tN = TEMP1 < 0;\n\tTEMP2 = V9 ^ V1;\n\tTEMP3 = V9 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_031A;\n\tV0 = 0.25f;\n\tV12 = V11 * V0;\n\tV9 = 1f;\n\tgoto L_032B;\n\tC = V10 < 0;\n\tC = ~C;\n\tTEMP1 = V10 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ 0;\n\tTEMP3 = V10 ^ TEMP1;\n// ... 514 further instruct\n// ... truncated")]
		public static float Evaluate(Ease easeType, EaseFunction customEase, float time, float duration, float overshootOrAmplitude, float period)
		{
			//IL_005a: Expected O, but got F4
			Ease ease = default(Ease);
			int num = (int)(ease - 1);
			bool flag = num < 36;
			bool flag2 = !flag;
			int num2 = num - 36;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 4341760 + 396;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v68 @ X9_v2 (System.Int32)+v55 @ X8_v3 (System.Int32)*2]");
				int num4 = (int)((nint)0 << 2);
				int num5 = 12808100 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v72 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			float num6 = time / duration;
			object obj = 0f - num6;
			float num7 = num6 + -2f;
			return num7 * (float)obj;
		}

		[Token(Token = "0x6000476")]
		[Address(RVA = "0xC33CD0", Offset = "0xC33CD0", Length = "0x1388")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0080;\n\tv16 = DG.Tweening.EaseFunction;\n\tv17 = \"il2cpp_codegen_initialize_runtime_metadata\"(v16, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv50 = Il2CppMethodInfo;\n\tv51 = \"il2cpp_codegen_initialize_runtime_metadata\"(v50, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv65 = Il2CppMethodInfo;\n\tv66 = \"il2cpp_codegen_initialize_runtime_metadata\"(v65, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv103 = Il2CppMethodInfo;\n\tv104 = \"il2cpp_codegen_initialize_runtime_metadata\"(v103, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv121 = Il2CppMethodInfo;\n\tv122 = \"il2cpp_codegen_initialize_runtime_metadata\"(v121, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv130 = Il2CppMethodInfo;\n\tv131 = \"il2cpp_codegen_initialize_runtime_metadata\"(v130, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv135 = Il2CppMethodInfo;\n\tv136 = \"il2cpp_codegen_initialize_runtime_metadata\"(v135, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv139 = Il2CppMethodInfo;\n\tv140 = \"il2cpp_codegen_initialize_runtime_metadata\"(v139, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv142 = Il2CppMethodInfo;\n\tv143 = \"il2cpp_codegen_initialize_runtime_metadata\"(v142, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv145 = Il2CppMethodInfo;\n\tv146 = \"il2cpp_codegen_initialize_runtime_metadata\"(v145, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv148 = Il2CppMethodInfo;\n\tv149 = \"il2cpp_codegen_initialize_runtime_metadata\"(v148, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv151 = Il2CppMethodInfo;\n\tv152 = \"il2cpp_codegen_initialize_runtime_metadata\"(v151, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv154 = Il2CppMethodInfo;\n\tv155 = \"il2cpp_codegen_initialize_runtime_metadata\"(v154, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv157 = Il2CppMethodInfo;\n\tv158 = \"il2cpp_codegen_initialize_runtime_metadata\"(v157, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv160 = Il2CppMethodInfo;\n\tv161 = \"il2cpp_codegen_initialize_runtime_metadata\"(v160, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv163 = Il2CppMethodInfo;\n\tv164 = \"il2cpp_codegen_initialize_runtime_metadata\"(v163, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv166 = Il2CppMethodInfo;\n\tv167 = \"il2cpp_codegen_initialize_runtime_metadata\"(v166, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv169 = Il2CppMethodInfo;\n\tv170 = \"il2cpp_codegen_initialize_runtime_metadata\"(v169, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv172 = Il2CppMethodInfo;\n\tv173 = \"il2cpp_codegen_initialize_runtime_metadata\"(v172, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv175 = Il2CppMethodInfo;\n\tv176 = \"il2cpp_codegen_initialize_runtime_metadata\"(v175, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv178 = Il2CppMethodInfo;\n\tv179 = \"il2cpp_codegen_initialize_runtime_metadata\"(v178, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv181 = Il2CppMethodInfo;\n\tv182 = \"il2cpp_codegen_initialize_runtime_metadata\"(v181, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv184 = Il2CppMethodInfo;\n\tv185 = \"il2cpp_codegen_initialize_runtime_metadata\"(v184, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv187 = Il2CppMethodInfo;\n\tv188 = \"il2cpp_codegen_initialize_runtime_metadata\"(v187, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv190 = Il2CppMethodInfo;\n\tv191 = \"il2cpp_codegen_initialize_runtime_metadata\"(v190, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv193 = Il2CppMethodInfo;\n\tv194 = \"il2cpp_codegen_initialize_runtime_metadata\"(v193, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv196 = Il2CppMethodInfo;\n\tv197 = \"il2cpp_codegen_initialize_runtime_metadata\"(v196, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv199 = Il2CppMethodInfo;\n\tv200 = \"il2cpp_codegen_initialize_runtime_metadata\"(v199, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv202 = Il2CppMethodInfo;\n\tv203 = \"il2cpp_codegen_initialize_runtime_metadata\"(v202, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv205 = Il2CppMethodInfo;\n\tv206 = \"il2cpp_codegen_initialize_runtime_metadata\"(v205, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv208 = Il2CppMethodInfo;\n\tv209 = \"il2cpp_codegen_initialize_runtime_metadata\"(v208, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv211 = Il2CppMethodInfo;\n\tv212 = \"il2cpp_codegen_initialize_runtime_metadata\"(v211, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv214 = Il2CppMethodInfo;\n\tv215 = \"il2cpp_codegen_initialize_runtime_metadata\"(v214, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv217 = Il2CppMethodInfo;\n\tv218 = \"il2cpp_codegen_initialize_runtime_metadata\"(v217, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv220 = Il2CppMethodInfo;\n\tv221 = \"il2cpp_codegen_initialize_runtime_metadata\"(v220, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv223 = Il2CppMethodInfo;\n\tv224 = \"il2cpp_codegen_initialize_runtime_metadata\"(v223, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv226 = Il2CppMethodInfo;\n\tv227 = \"il2cpp_codegen_initialize_runtime_metadata\"(v226, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv229 = DG.Tweening.Core.Easing.EaseManager+<>c;\n\tv34 = \"il2cpp_codegen_initialize_runtime_metadata\"(v229, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv36 = 1;\n\t*([1A35813]) = v36;\nL_0080:\n\tv37 = v33 - 1;\n\tv38 = v37 < 0x22;\n\tv39 = ~v38;\n\tv40 = v37 - 0x22;\n\tv42 = v40 == 0;\n\tv47 = ~v42;\n\tv48 = v39 & v47;\n\tif (v48) goto L_00BF;\n\tv53 = 0x424000 + 0x1D6;\n\tv56 = *([v53 @ X9_v5 (System.Int32)+v37 @ X8_v3 (System.Int32)*2]) << 2;\n\tv57 = 0xC37EDC + v56;\n\t// 147 IndirectJump v57 @ X10_v2 (System.Int32), v33 @ X0_v1 (DG.Tweening.Ease), v33 @ X0_v1 (DG.Tweening.Ease), methodInfo @ X1 (Il2CppMethodInfo), v19 @ X2, v20 @ X3, v21 @ X4, v22 @ X5, v23 @ X6, v24 @ X7, v25 @ V0, v26 @ V1, v27 @ V2, v28 @ V3, v29 @ V4, v30 @ V5, v31 @ V6, v32 @ V7\n\tX21 = *([1937BD8]);\n\tX0 = *([X21]);\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_009D;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_009D:\n\tX8 = *([X0+B8]);\n\tX19 = *([X8+8]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_05CD;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A8;\n\tX0 = 0xAD9598(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX0 = *([X21]);\nL_00A8:\n\tX9 = 0x1936000;\n\tX8 = *([X0+B8]);\n\tX9 = *([1936BF8]);\n\tX20 = *([X8]);\n\tX0 = *([X9]);\n\tX0 = 0xAD96AC(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1937AB8]);\n\tX1 = X20;\n\tX3 = 0;\n\tX19 = X0;\n\tX2 = *([X8]);\n\tDG.Tweening.EaseFunction::.ctor(X0, X1, X2, X3);\n\tX8 = *([X21]);\n\tX8 = *([X8+B8]);\n\t*([X8+8]) = X19;\n\tgoto L_05CD;\nL_00BF:\n\tgoto L_00C3;\n\tv95 = \"il2cpp_codegen_runtime_class_init\"(v60, methodInfo, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32);\n\tv97 = DG.Tweening.Core.Easing.EaseManager+<>c;\nL_00C3:\n\tv115 = v98.<>9__4_35;\n\tv100 = v98.<>9__4_35 == 0;\n\tv101 = ~v100;\n\tif (v101) goto L_05CD;\n\tgoto L_00D2;\n\tv123 = \"il\n// ... truncated")]
		public static EaseFunction ToEaseFunction(Ease ease)
		{
			Ease ease2 = default(Ease);
			int num = (int)(ease2 - 1);
			bool flag = num < 34;
			bool flag2 = !flag;
			int num2 = num - 34;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 4341760 + 470;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v53 @ X9_v5 (System.Int32)+v37 @ X8_v3 (System.Int32)*2]");
				int num4 = (int)((nint)0 << 2);
				int num5 = 12811996 + num4;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v57 @ X10_v2 (System.Int32) (should have been resolved before IL gen)");
			}
			EaseFunction result = _003C_003Ec._003C_003E9__4_35;
			if (_003C_003Ec._003C_003E9__4_35 == null)
			{
				result = (_003C_003Ec._003C_003E9__4_35 = delegate(float time, float duration, float overshootOrAmplitude, float period)
				{
					//IL_0018: Expected O, but got F4
					float num6 = time / duration;
					object obj = 0f - num6;
					float num7 = num6 + -2f;
					return num7 * (float)obj;
				});
			}
			return result;
		}

		[Token(Token = "0x6000477")]
		[Address(RVA = "0xC35058", Offset = "0xC35058", Length = "0x10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tv0 = ease & 0xFFFFFFFC;\n\tv4 = v0 - 0x20;\n\tv6 = v4 == 0;\n\treturn v6;\n// 8 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		internal static bool IsFlashEase(Ease ease)
		{
			//IL_0012: Expected I4, but got I8
			int num = (int)((long)ease & 0xFFFFFFFCL);
			int num2 = num - 32;
			return num2 == 0;
		}
	}
}
