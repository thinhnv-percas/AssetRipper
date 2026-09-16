using System;
using System.Runtime.CompilerServices;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x200005E")]
	public static class EaseManager
	{
		[Serializable]
		[CompilerGenerated]
		[Token(Token = "0x20000BC")]
		private sealed class _003C_003Ec
		{
			[Token(Token = "0x400025B")]
			public static readonly _003C_003Ec _003C_003E9;

			[Token(Token = "0x400025C")]
			public static EaseFunction _003C_003E9__4_0;

			[Token(Token = "0x400025D")]
			public static EaseFunction _003C_003E9__4_1;

			[Token(Token = "0x400025E")]
			public static EaseFunction _003C_003E9__4_2;

			[Token(Token = "0x400025F")]
			public static EaseFunction _003C_003E9__4_3;

			[Token(Token = "0x4000260")]
			public static EaseFunction _003C_003E9__4_4;

			[Token(Token = "0x4000261")]
			public static EaseFunction _003C_003E9__4_5;

			[Token(Token = "0x4000262")]
			public static EaseFunction _003C_003E9__4_6;

			[Token(Token = "0x4000263")]
			public static EaseFunction _003C_003E9__4_7;

			[Token(Token = "0x4000264")]
			public static EaseFunction _003C_003E9__4_8;

			[Token(Token = "0x4000265")]
			public static EaseFunction _003C_003E9__4_9;

			[Token(Token = "0x4000266")]
			public static EaseFunction _003C_003E9__4_10;

			[Token(Token = "0x4000267")]
			public static EaseFunction _003C_003E9__4_11;

			[Token(Token = "0x4000268")]
			public static EaseFunction _003C_003E9__4_12;

			[Token(Token = "0x4000269")]
			public static EaseFunction _003C_003E9__4_13;

			[Token(Token = "0x400026A")]
			public static EaseFunction _003C_003E9__4_14;

			[Token(Token = "0x400026B")]
			public static EaseFunction _003C_003E9__4_15;

			[Token(Token = "0x400026C")]
			public static EaseFunction _003C_003E9__4_16;

			[Token(Token = "0x400026D")]
			public static EaseFunction _003C_003E9__4_17;

			[Token(Token = "0x400026E")]
			public static EaseFunction _003C_003E9__4_18;

			[Token(Token = "0x400026F")]
			public static EaseFunction _003C_003E9__4_19;

			[Token(Token = "0x4000270")]
			public static EaseFunction _003C_003E9__4_20;

			[Token(Token = "0x4000271")]
			public static EaseFunction _003C_003E9__4_21;

			[Token(Token = "0x4000272")]
			public static EaseFunction _003C_003E9__4_22;

			[Token(Token = "0x4000273")]
			public static EaseFunction _003C_003E9__4_23;

			[Token(Token = "0x4000274")]
			public static EaseFunction _003C_003E9__4_24;

			[Token(Token = "0x4000275")]
			public static EaseFunction _003C_003E9__4_25;

			[Token(Token = "0x4000276")]
			public static EaseFunction _003C_003E9__4_26;

			[Token(Token = "0x4000277")]
			public static EaseFunction _003C_003E9__4_27;

			[Token(Token = "0x4000278")]
			public static EaseFunction _003C_003E9__4_28;

			[Token(Token = "0x4000279")]
			public static EaseFunction _003C_003E9__4_29;

			[Token(Token = "0x400027A")]
			public static EaseFunction _003C_003E9__4_30;

			[Token(Token = "0x400027B")]
			public static EaseFunction _003C_003E9__4_31;

			[Token(Token = "0x400027C")]
			public static EaseFunction _003C_003E9__4_32;

			[Token(Token = "0x400027D")]
			public static EaseFunction _003C_003E9__4_33;

			[Token(Token = "0x400027E")]
			public static EaseFunction _003C_003E9__4_34;

			[Token(Token = "0x400027F")]
			public static EaseFunction _003C_003E9__4_35;

			[Token(Token = "0x6000418")]
			[Address(RVA = "0x1074BF4", Offset = "0x1074BF4", Length = "0x64")]
			[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0015;\n\tv16 = *([1EE97A8]);\n\tv17 = *([v16 @ X8_v6]);\n\tv18 = \"il2cpp_codegen_initialize_method\"(v17, v19, v20, v21, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33);\n\tv37 = 0 | 1;\n\t*([20269A4]) = v37;\nL_0015:\n\tv41 = new DG.Tweening.Core.Easing.EaseManager+<>c();\n\tSystem.Object::.ctor(v41);\n\tv45.<>9 = v41;\n\treturn;\n// 24 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
			static _003C_003Ec()
			{
				_003C_003Ec _003C_003Ec2 = new _003C_003Ec();
				_003C_003E9 = _003C_003Ec2;
			}

			[Token(Token = "0x6000419")]
			[Address(RVA = "0x1074C58", Offset = "0x1074C58", Length = "0x8")]
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
				Il2CppRuntime.Boundary("SYSTEM_API:cos", "Method not found @6D2660 (native cos)");
				return 1f - num2;
			}

			internal float _003CToEaseFunction_003Eb__4_2(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time / duration;
				float result = num * ((float)Math.PI / 2f);
				Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @6D21F0 (native sin)");
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_3(float time, float duration, float overshootOrAmplitude, float period)
			{
				float num = time * (float)Math.PI;
				float num2 = num / duration;
				Il2CppRuntime.Boundary("SYSTEM_API:cos", "Method not found @6D2660 (native cos)");
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
				float num = time / duration;
				float num2 = num + -2f;
				float num3 = num * num2;
				return 0f - num3;
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
				float result;
				if (time != 0f)
				{
					float num = time / duration;
					float num2 = num + -1f;
					result = num2 * 10f;
					Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
				}
				else
				{
					result = 0f;
				}
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_17(float time, float duration, float overshootOrAmplitude, float period)
			{
				if (time == duration)
				{
					return 1f;
				}
				float num = time * -10f;
				float num2 = num / duration;
				Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
				return 1f - num2;
			}

			internal float _003CToEaseFunction_003Eb__4_18(float time, float duration, float overshootOrAmplitude, float period)
			{
				bool flag = time == 0f;
				float result = 0f;
				if (!flag)
				{
					if (time == duration)
					{
						result = 1f;
					}
					else
					{
						float num = duration * 0.5f;
						float num2 = time / num;
						float num4;
						if (num2 < 1f)
						{
							float num3 = num2 + -1f;
							num4 = num3 * 10f;
							Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
						}
						else
						{
							float num5 = num2 + -1f;
							float num6 = num5 * -10f;
							Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
							num4 = 2f - num6;
						}
						result = num4 * 0.5f;
					}
				}
				return result;
			}

			internal float _003CToEaseFunction_003Eb__4_19(float time, float duration, float overshootOrAmplitude, float period)
			{
				//IL_004d: Expected O, but got F4
				//IL_005a: Expected O, but got F4
				float num = time / duration;
				float num2 = num * num;
				float num3 = 1f - num2;
				float num4 = Mathf.Sqrt(num3);
				float num5 = num4 - num4;
				object obj = num4 ^ num4;
				object obj2 = num4 ^ num5;
				int num6 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
				if (num6 < 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
					num4 = num3;
				}
				float num7 = num4 + -1f;
				return 0f - num7;
			}

			internal float _003CToEaseFunction_003Eb__4_20(float time, float duration, float overshootOrAmplitude, float period)
			{
				//IL_004d: Expected O, but got F4
				//IL_005a: Expected O, but got F4
				float num = time / duration;
				float num2 = num + -1f;
				float num3 = num2 * num2;
				float num4 = 1f - num3;
				float num5 = Mathf.Sqrt(num4);
				float num6 = num5 - num5;
				object obj = num5 ^ num5;
				object obj2 = num5 ^ num6;
				int num7 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
				if (num7 >= 0)
				{
					return num5;
				}
				Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
				return num4;
			}

			internal float _003CToEaseFunction_003Eb__4_21(float time, float duration, float overshootOrAmplitude, float period)
			{
				//IL_005c: Expected I, but got O
				//IL_0013: Expected I, but got O
				//IL_0140: Expected O, but got F4
				//IL_014d: Expected O, but got F4
				float num = duration * 0.5f;
				float num2 = time / num;
				float num3;
				float num4;
				float num5;
				if (num2 < 1f)
				{
					IntPtr intPtr = (IntPtr)typeof(Math);
					num3 = num2 * num2;
					num4 = -0.5f;
					num5 = -1f;
				}
				else
				{
					float num6 = num2 + -2f;
					IntPtr intPtr = (IntPtr)typeof(Math);
					num3 = num6 * num6;
					num4 = 0.5f;
					num5 = 1f;
				}
				float num7 = 1f - num3;
				float num8 = Mathf.Sqrt(num7);
				float num9 = num8 - num8;
				object obj = num8 ^ num8;
				object obj2 = num8 ^ num9;
				int num10 = (int)((long)(IntPtr)obj & (long)(IntPtr)obj2);
				if (num10 < 0)
				{
					Il2CppRuntime.Boundary("SYSTEM_API:sqrtf", "Method not found @6D2F50 (native sqrtf)");
					num8 = num7;
				}
				float num11 = num5 + num8;
				return num4 * num11;
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
						float num6;
						if (overshootOrAmplitude < 1f)
						{
							num4 = num3 * 0.25f;
							float num5 = duration;
							num6 = 1f;
						}
						else
						{
							float num7 = 1f / overshootOrAmplitude;
							Il2CppRuntime.Boundary("SYSTEM_API:asin", "Method not found @6D2A50 (native asin)");
							float num5 = num3 / ((float)Math.PI * 2f);
							num4 = num5 * num7;
							num6 = overshootOrAmplitude;
						}
						float num8 = num + -1f;
						float num9 = num8 * 10f;
						Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
						float num10 = num8 * duration;
						float num11 = num10 - num4;
						float num12 = num11 * ((float)Math.PI * 2f);
						float num13 = num12 / num3;
						Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @6D21F0 (native sin)");
						float num14 = num6 * num9;
						float num15 = num14 * num13;
						result = 0f - num15;
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
						float num6;
						if (overshootOrAmplitude < 1f)
						{
							num4 = num3 * 0.25f;
							float num5 = duration;
							num6 = 1f;
						}
						else
						{
							float num7 = 1f / overshootOrAmplitude;
							Il2CppRuntime.Boundary("SYSTEM_API:asin", "Method not found @6D2A50 (native asin)");
							float num5 = num3 / ((float)Math.PI * 2f);
							num4 = num5 * num7;
							num6 = overshootOrAmplitude;
						}
						float num8 = num * -10f;
						Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
						float num9 = num * duration;
						float num10 = num9 - num4;
						float num11 = num10 * ((float)Math.PI * 2f);
						float num12 = num11 / num3;
						Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @6D21F0 (native sin)");
						float num13 = num6 * num8;
						float num14 = num13 * num12;
						result = num14 + 1f;
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
						float num7;
						if (overshootOrAmplitude < 1f)
						{
							num5 = num4 * 0.25f;
							float num6 = duration;
							num7 = 1f;
						}
						else
						{
							float num8 = 1f / overshootOrAmplitude;
							Il2CppRuntime.Boundary("SYSTEM_API:asin", "Method not found @6D2A50 (native asin)");
							float num6 = num4 / ((float)Math.PI * 2f);
							num5 = num6 * num8;
							num7 = overshootOrAmplitude;
						}
						float num9 = num2 + -1f;
						if (num2 < 1f)
						{
							float num10 = num9 * 10f;
							Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
							float num11 = num9 * duration;
							float num12 = num11 - num5;
							float num13 = num12 * ((float)Math.PI * 2f);
							float num14 = num13 / num4;
							Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @6D21F0 (native sin)");
							float num15 = num7 * num10;
							float num16 = num15 * num14;
							return num16 * -0.5f;
						}
						float num17 = num9 * -10f;
						Il2CppRuntime.Boundary("EXTERNAL_DEPENDENCY:exp2", "Method not found @6D2950 (native exp2)");
						float num18 = num9 * duration;
						float num19 = num18 - num5;
						float num20 = num19 * ((float)Math.PI * 2f);
						float num21 = num20 / num4;
						Il2CppRuntime.Boundary("SYSTEM_API:sin", "Method not found @6D21F0 (native sin)");
						float num22 = num7 * num17;
						float num23 = num22 * num21;
						float num24 = num23 * 0.5f;
						return num24 + 1f;
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
				float num = time / duration;
				float num2 = num + -2f;
				float num3 = num * num2;
				return 0f - num3;
			}
		}

		[Token(Token = "0x40001B6")]
		private const float _PiOver2 = (float)Math.PI / 2f;

		[Token(Token = "0x40001B7")]
		private const float _TwoPi = (float)Math.PI * 2f;

		[Token(Token = "0x60002EF")]
		[Address(RVA = "0x1072608", Offset = "0x1072608", Length = "0x20")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\treturnVal1 = DG.Tweening.Core.Easing.EaseManager::Evaluate(t.easeType, t.customEase, time, duration, overshootOrAmplitude, period);\n\treturn returnVal1;\n\tthrow System.NullReferenceException;\n\treturn time;\n// 9 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Evaluate(Tween t, float time, float duration, float overshootOrAmplitude, float period)
		{
			return Evaluate(t.easeType, t.customEase, time, duration, overshootOrAmplitude, period);
		}

		[Token(Token = "0x60002F0")]
		[Address(RVA = "0x1072628", Offset = "0x1072628", Length = "0xB10")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0021;\n\tv46 = *([1EEB7E8]);\n\tv47 = *([v46 @ X8_v8]);\n\tv48 = \"il2cpp_codegen_initialize_method\"(v47, customEase, methodInfo, v50, v51, v52, v53, v54, time, duration, overshootOrAmplitude, period, v55, v56, v57, v58);\n\tv61 = 0 | 1;\n\t*([20269A2]) = v61;\nL_0021:\n\tv62 = v59 - 1;\n\tv63 = v62 < 0x24;\n\tv64 = ~v63;\n\tv65 = v62 - 0x24;\n\tv67 = v65 == 0;\n\tv72 = ~v67;\n\tv73 = v64 & v72;\n\tif (v73) goto L_0036;\n\tv75 = 0x1825000 + 0x318;\n\tv78 = *([v75 @ X9_v2 (System.Int32)+v62 @ X8_v3 (System.Int32)*4]) + v75;\n\t// 51 IndirectJump v78 @ X8_v5, v59 @ X0_v1 (DG.Tweening.Ease), v59 @ X0_v1 (DG.Tweening.Ease), customEase @ X1 (DG.Tweening.EaseFunction), methodInfo @ X2 (Il2CppMethodInfo), v50 @ X3, v51 @ X4, v52 @ X5, v53 @ X6, v54 @ X7, 1f, duration @ V1 (System.Single), overshootOrAmplitude @ V2 (System.Single), period @ V3 (System.Single), v55 @ V4, v56 @ V5, v57 @ V6, v58 @ V7\n\tV0 = V10 / V8;\n\tgoto L_0464;\nL_0036:\n\tv79 = time / duration;\n\tv81 = v79 + -2f;\n\tv82 = v79 * v81;\n\treturnVal1 = -v82;\n\tgoto L_0464;\n\tV0 = V10;\n\tV1 = V8;\n\tV2 = V9;\n\tV3 = V11;\n\tX29 = stack[60];\n\tX30 = stack[68];\n\tX20 = stack[50];\n\tX19 = stack[58];\n\tX21 = stack[40];\n\tV9 = stack[30];\n\tV8 = stack[38];\n\tV11 = stack[20];\n\tV10 = stack[28];\n\tV13 = stack[10];\n\tV12 = stack[18];\n\tV15 = stack[0];\n\tV14 = stack[8];\n\t// 77 ShiftStack 112\n\tV0 = DG.Tweening.Core.Easing.Flash::EaseInOut(V0, V1, V2, V3, X0);\n\treturn V0;\n\tX8 = *([1ED7B50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_005C;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_005C;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_005C:\n\tX8 = 0x1818000;\n\tV0 = 1.5707964f;\n\tV1 = V10 / V8;\n\tV0 = V1 * V0;\n\tV0 = V0;\n\tX0 = 0x6D2660(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tgoto L_0136;\n\tX8 = *([1ED7B50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_006F;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_006F;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_006F:\n\tX8 = 0x1818000;\n\tV0 = 1.5707964f;\n\tV1 = V10 / V8;\n\tV0 = V1 * V0;\n\tV0 = V0;\n\tX0 = 0x6D21F0(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V0;\n\tgoto L_0464;\n\tX8 = *([1ED7B50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0083;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0083;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0083:\n\tX8 = 0x1818000;\n\tV0 = 3.1415927f;\n\tV0 = V10 * V0;\n\tV0 = V0 / V8;\n\tV0 = V0;\n\tX0 = 0x6D2660(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V0;\n\tgoto L_01EC;\n\tV0 = V10 / V8;\n\tV0 = V0 * V0;\n\tgoto L_0464;\n\tV1 = 0.5f;\n\tV0 = V8 * V1;\n\tV0 = V10 / V0;\n\tV2 = 1f;\n\tC = V0 < V2;\n\tC = ~C;\n\tTEMP1 = V0 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V2;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (N) goto L_00DA;\n\tV1 = -1f;\n\tV2 = -2f;\n\tV0 = V0 + V1;\n\tV2 = V0 + V2;\n\tgoto L_0347;\n\tV0 = V10 / V8;\n\tV1 = V0 * V0;\n\tV0 = V0 * V1;\n\tgoto L_0464;\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV1 = V0 * V0;\n\tgoto L_00E3;\n\tV0 = 0.5f;\n\tV1 = V8 * V0;\n\tV1 = V10 / V1;\n\tV2 = 1f;\n\tC = V1 < V2;\n\tC = ~C;\n\tTEMP1 = V1 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V1 ^ V2;\n\tTEMP3 = V1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (N) goto L_00F8;\n\tV2 = -2f;\n\tV1 = V1 + V2;\n\tV2 = V1 * V1;\n\tgoto L_0351;\n\tV0 = V10 / V8;\n\tV1 = V0 * V0;\n\tgoto L_00DA;\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV2 = V0 * V0;\n\tV2 = V0 * V2;\n\tV0 = V0 * V2;\n\tgoto L_018F;\n\tV1 = 0.5f;\n\tV0 = V8 * V1;\n\tV0 = V10 / V0;\n\tV2 = 1f;\n\tC = V0 < V2;\n\tC = ~C;\n\tTEMP1 = V0 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V2;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_0343;\n\tV1 = V0 * V1;\n\tgoto L_00D9;\n\tV0 = V10 / V8;\n\tV1 = V0 * V0;\nL_00D9:\n\tV1 = V0 * V1;\nL_00DA:\n\tV1 = V0 * V1;\n\tV0 = V0 * V1;\n\tgoto L_0464;\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV1 = V0 * V0;\n\tV1 = V0 * V1;\n\tV1 = V0 * V1;\nL_00E3:\n\tV0 = V0 * V1;\n\tV1 = 1f;\n\tV0 = V0 + V1;\n\tgoto L_0464;\n\tV0 = 0.5f;\n\tV1 = V8 * V0;\n\tV1 = V10 / V1;\n\tV2 = 1f;\n\tC = V1 < V2;\n\tC = ~C;\n\tTEMP1 = V1 - V2;\n\tN = TEMP1 < 0;\n\tTEMP2 = V1 ^ V2;\n\tTEMP3 = V1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_034C;\n\tV0 = V1 * V0;\n\tV0 = V1 * V0;\nL_00F8:\n\tV0 = V1 * V0;\n\tV0 = V1 * V0;\n\tV0 = V1 * V0;\n\tgoto L_0464;\n\tC = V10 < 0;\n\tC = ~C;\n\tTEMP1 = V10 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ 0;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0298;\n\tX8 = *([1ED7B50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0112;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0112;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0112:\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV0 = V0 + V1;\n\tV1 = 10f;\n\tV0 = V0 * V1;\n\tV0 = V0;\n\tX0 = 0x6D2950(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V0;\n\tgoto L_0464;\n\tC = V10 < V8;\n\tC = ~C;\n\tTEMP1 = V10 - V8;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ V8;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0464;\n\tX8 = *([1ED7B50]);\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0131;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0131;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0131:\n\tV0 = -10f;\n\tV0 = V10 * V0;\n\tV0 = V0 / V8;\n\tV0 = V0;\n\tX0 = 0x6D2950(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0136:\n\tV0 = V0;\n\tgoto L_02C9;\n\tC = V10 < 0;\n\tC = ~C;\n\tTEMP1 = V10 - 0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ 0;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0298;\n\tC = V10 < V8;\n\tC = ~C;\n\tTEMP1 = V10 - V8;\n\tN = TEMP1 < 0;\n\tTEMP2 = V10 ^ V8;\n\tTEMP3 = V10 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_0464;\n\tV9 = 0.5f;\n\tX8 = *([1ED7B50]);\n\tV0 = V8 * V9;\n\tV8 = V10 / V0;\n\tV0 = 1f;\n\tC = V8 < V0;\n\tC = ~C;\n\tTEMP1 = V8 - V0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V8 ^ V0;\n\tTEMP3 = V8 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~N;\n\tif (TEMPCOND) goto L_037E;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_0167;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0167;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_0167:\n\tV0 = -1f;\n\tV0 = V8 + V0;\n\tV1 = 10f;\n\tV0 = V0 * V1;\n\tV0 = V0;\n\tX0 = 0x6D2950(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tV0 = V0;\n\tV0 = V0 * V9;\n\tgoto L_0464;\n\tX8 = *([1ED7B50]);\n\tV8 = V10 / V8;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_017D;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_017D;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_017D:\n\tV0 = V8 * V8;\n\tV1 = 1f;\n\tV1 = V1 - V0;\n\tV0 = UnityEngine.Mathf::Sqrt(V1);\n\tC = V0 < V0;\n\tC = ~C;\n\tTEMP1 = V0 - V0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V0;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~V;\n\tif (TEMPCOND) goto L_018E;\n\tV0 = V1;\n\tX0 = 0x6D2F50(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_018E:\n\tV1 = -1f;\nL_018F:\n\tV0 = V0 + V1;\n\tV0 = -V0;\n\tgoto L_0464;\n\tX8 = *([1ED7B50]);\n\tV0 = V10 / V8;\n\tV1 = -1f;\n\tV8 = V0 + V1;\n\tX0 = *([X8]);\n\tX8 = *([X0+12F]);\n\tTEMP = X8 & 2;\n\tif (TEMP) goto L_01A1;\n\tX8 = *([X0+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_01A1;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\nL_01A1:\n\tV0 = V8 * V8;\n\tV1 = 1f;\n\tV1 = V1 - V0;\n\tV0 = UnityEngine.Mathf::Sqrt(V1);\n\tC = V0 < V0;\n\tC = ~C;\n\tTEMP1 = V0 - V0;\n\tN = TEMP1 < 0;\n\tTEMP2 = V0 ^ V0;\n\tTEMP3 = V0 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tTEMPCOND = ~V;\n\tif (TEMPCOND) goto L_0464;\n\tX29 = stack[60];\n\tX30 = stack[68];\n\tX20 = stack[50];\n\tX19 = stack[58];\n\tX21 = stack[40];\n\tV9 = stack[30];\n\tV8 = stack[38];\n\tV11 = stack[20];\n\tV10 = stack[28];\n\tV13 = stack[10];\n\tV12 = stack[18];\n\tV0 = V1;\n\tV15 = stack[0];\n\tV14 = stack[8];\n\t// 446 ShiftStack 112\n\tX0 = 0x6D2F50(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\treturn V0;\n\tV9 = 0.5f;\n\tX8 = *([1ED7B50]);\n\tV0 = V8 * V9;\n\tV10 = V10 / V0;\n\tV8 = 1f;\n\tC = V10 < V8;\n\tC = ~C;\n\n// ... truncated")]
		public static float Evaluate(Ease easeType, EaseFunction customEase, float time, float duration, float overshootOrAmplitude, float period)
		{
			//IL_0029: Expected O, but got I
			Ease ease = default(Ease);
			int num = (int)(ease - 1);
			bool flag = num < 36;
			bool flag2 = !flag;
			int num2 = num - 36;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25317376 + 792;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v75 @ X9_v2 (System.Int32)+v62 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v78 @ X8_v5 (should have been resolved before IL gen)");
			}
			float num4 = time / duration;
			float num5 = num4 + -2f;
			float num6 = num4 * num5;
			return 0f - num6;
		}

		[Token(Token = "0x60002F1")]
		[Address(RVA = "0x1073738", Offset = "0x1073738", Length = "0x149C")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0013;\n\tv18 = *([1EF5680]);\n\tv19 = *([v18 @ X8_v21]);\n\tv20 = \"il2cpp_codegen_initialize_method\"(v19, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv38 = 0 | 1;\n\t*([20269A3]) = v38;\nL_0013:\n\tv39 = v36 - 1;\n\tv40 = v39 < 0x22;\n\tv41 = ~v40;\n\tv42 = v39 - 0x22;\n\tv44 = v42 == 0;\n\tv49 = ~v44;\n\tv50 = v41 & v49;\n\tif (v50) goto L_005A;\n\tv52 = 0x1825000 + 0x3AC;\n\tv54 = *([v52 @ X9_v10 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]) + v52;\n\t// 36 IndirectJump v54 @ X8_v18, v36 @ X0_v1 (DG.Tweening.Ease), v36 @ X0_v1 (DG.Tweening.Ease), methodInfo @ X1 (Il2CppMethodInfo), v22 @ X2, v23 @ X3, v24 @ X4, v25 @ X5, v26 @ X6, v27 @ X7, v28 @ V0, v29 @ V1, v30 @ V2, v31 @ V3, v32 @ V4, v33 @ V5, v34 @ V6, v35 @ V7\n\tX19 = *([1EE2ED8]);\n\tX8 = *([X19]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0033;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0033;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\nL_0033:\n\tX9 = *([X8+B8]);\n\tX0 = *([X9+8]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_06C6;\n\tX10 = *([X8+12F]);\n\tTEMP = X10 & 2;\n\tif (TEMP) goto L_0044;\n\tX10 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0044;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8+B8]);\nL_0044:\n\tX8 = 0x1ECF000;\n\tX20 = *([X9]);\n\tX8 = *([1ECF768]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F046E0]);\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X0+20]) = X20;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\n\tX8 = *([X19]);\n\tX8 = *([X8+B8]);\n\t*([X8+8]) = X0;\n\tgoto L_06C6;\nL_005A:\n\tgoto L_0063;\n\tv80 = *([v57 @ X8_v4 (Il2CppClass<DG.Tweening.Core.Easing.EaseManager+<>c>)+E0]);\n\tv81 = v80 == 0;\n\tv82 = ~v81;\n\tif (v82) goto L_0063;\n\tv93 = v57;\n\tv85 = \"il2cpp_codegen_runtime_class_init\"(v93, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv88 = DG.Tweening.Core.Easing.EaseManager+<>c;\nL_0063:\n\treturnVal1 = v89.<>9__4_35;\n\tv91 = v89.<>9__4_35 == 0;\n\tv92 = ~v91;\n\tif (v92) goto L_06C6;\n\tgoto L_0077;\n\tv104 = *([v87 @ X8_v5 (Il2CppClass<DG.Tweening.Core.Easing.EaseManager+<>c>)+E0]);\n\tv105 = v104 == 0;\n\tv106 = ~v105;\n\tif (v106) goto L_0077;\n\tv116 = v87;\n\tv110 = \"il2cpp_codegen_runtime_class_init\"(v116, methodInfo, v22, v23, v24, v25, v26, v27, v28, v29, v30, v31, v32, v33, v34, v35);\n\tv112 = DG.Tweening.Core.Easing.EaseManager+<>c;\n\tv108 = *([v112 @ X8_v15+B8]);\nL_0077:\n\treturnVal1 = new DG.Tweening.EaseFunction();\n\tv119 = Il2CppMethodInfo;\n\treturnVal1.m_target = v107.<>9;\n\treturnVal1.method = Il2CppMethodInfo;\n\treturnVal1.method_ptr = *([v119 @ X8_v12 (Il2CppMethodInfo)]);\n\tv101.<>9__4_35 = returnVal1;\n\tgoto L_06C6;\n\tX19 = *([1EE2ED8]);\n\tX8 = *([X19]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_0091;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0091;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\nL_0091:\n\tX9 = *([X8+B8]);\n\tX0 = *([X9+10]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_06C6;\n\tX10 = *([X8+12F]);\n\tTEMP = X10 & 2;\n\tif (TEMP) goto L_00A2;\n\tX10 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00A2;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8+B8]);\nL_00A2:\n\tX8 = 0x1ECF000;\n\tX20 = *([X9]);\n\tX8 = *([1ECF768]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB8AB0]);\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X0+20]) = X20;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\n\tX8 = *([X19]);\n\tX8 = *([X8+B8]);\n\t*([X8+10]) = X0;\n\tgoto L_06C6;\n\tX19 = *([1EE2ED8]);\n\tX8 = *([X19]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00C0;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00C0;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\nL_00C0:\n\tX9 = *([X8+B8]);\n\tX0 = *([X9+18]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_06C6;\n\tX10 = *([X8+12F]);\n\tTEMP = X10 & 2;\n\tif (TEMP) goto L_00D1;\n\tX10 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00D1;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8+B8]);\nL_00D1:\n\tX8 = 0x1ECF000;\n\tX20 = *([X9]);\n\tX8 = *([1ECF768]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA55D0]);\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X0+20]) = X20;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\n\tX8 = *([X19]);\n\tX8 = *([X8+B8]);\n\t*([X8+18]) = X0;\n\tgoto L_06C6;\n\tX19 = *([1EE2ED8]);\n\tX8 = *([X19]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_00EF;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_00EF;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\nL_00EF:\n\tX9 = *([X8+B8]);\n\tX0 = *([X9+20]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_06C6;\n\tX10 = *([X8+12F]);\n\tTEMP = X10 & 2;\n\tif (TEMP) goto L_0100;\n\tX10 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_0100;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8+B8]);\nL_0100:\n\tX8 = 0x1ECF000;\n\tX20 = *([X9]);\n\tX8 = *([1ECF768]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EF5F08]);\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X0+20]) = X20;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\n\tX8 = *([X19]);\n\tX8 = *([X8+B8]);\n\t*([X8+20]) = X0;\n\tgoto L_06C6;\n\tX19 = *([1EE2ED8]);\n\tX8 = *([X19]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_011E;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_011E;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\nL_011E:\n\tX9 = *([X8+B8]);\n\tX0 = *([X9+28]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_06C6;\n\tX10 = *([X8+12F]);\n\tTEMP = X10 & 2;\n\tif (TEMP) goto L_012F;\n\tX10 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_012F;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8+B8]);\nL_012F:\n\tX8 = 0x1ECF000;\n\tX20 = *([X9]);\n\tX8 = *([1ECF768]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1F01538]);\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X0+20]) = X20;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\n\tX8 = *([X19]);\n\tX8 = *([X8+B8]);\n\t*([X8+28]) = X0;\n\tgoto L_06C6;\n\tX19 = *([1EE2ED8]);\n\tX8 = *([X19]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_014D;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_014D;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\nL_014D:\n\tX9 = *([X8+B8]);\n\tX0 = *([X9+30]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_06C6;\n\tX10 = *([X8+12F]);\n\tTEMP = X10 & 2;\n\tif (TEMP) goto L_015E;\n\tX10 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_015E;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8+B8]);\nL_015E:\n\tX8 = 0x1ECF000;\n\tX20 = *([X9]);\n\tX8 = *([1ECF768]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EB0E00]);\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X0+20]) = X20;\n\t*([X0+28]) = X8;\n\t*([X0+10]) = X9;\n\tX8 = *([X19]);\n\tX8 = *([X8+B8]);\n\t*([X8+30]) = X0;\n\tgoto L_06C6;\n\tX19 = *([1EE2ED8]);\n\tX8 = *([X19]);\n\tX9 = *([X8+12F]);\n\tTEMP = X9 & 2;\n\tif (TEMP) goto L_017C;\n\tX9 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_017C;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\nL_017C:\n\tX9 = *([X8+B8]);\n\tX0 = *([X9+38]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_06C6;\n\tX10 = *([X8+12F]);\n\tTEMP = X10 & 2;\n\tif (TEMP) goto L_018D;\n\tX10 = *([X8+E0]);\n\tTEMP = ~TEMP;\n\tif (TEMP) goto L_018D;\n\tX0 = X8;\n\tX0 = 0x8D8298(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([X19]);\n\tX9 = *([X8+B8]);\nL_018D:\n\tX8 = 0x1ECF000;\n\tX20 = *([X9]);\n\tX8 = *([1ECF768]);\n\tX0 = *([X8]);\n\tX0 = 0x8D82B4(X0, X1, X2, X3, X4, X5, X6, X7, V0, V1, V2, V3, V4, V5, V6, V7);\n\tX8 = *([1EA42F8]);\n\tX8 = *([X8]);\n\tX9 = *([X8]);\n\t*([X0+20]) = \n// ... truncated")]
		public unsafe static EaseFunction ToEaseFunction(Ease ease)
		{
			//IL_0029: Expected O, but got I
			Ease ease2 = default(Ease);
			int num = (int)(ease2 - 1);
			bool flag = num < 34;
			bool flag2 = !flag;
			int num2 = num - 34;
			bool flag3 = num2 == 0;
			bool flag4 = !flag3;
			if (!(flag2 && flag4))
			{
				int num3 = 25317376 + 940;
				Cpp2ILHelpers.NoteDecompilerIssue("Unmanaged memory load: [v52 @ X9_v10 (System.Int32)+v39 @ X8_v3 (System.Int32)*4]");
				object obj = 0L + (long)num3;
				Cpp2ILHelpers.NoteDecompilerIssue("Indirect jump: v54 @ X8_v18 (should have been resolved before IL gen)");
			}
			EaseFunction easeFunction = _003C_003Ec._003C_003E9__4_35;
			if (_003C_003Ec._003C_003E9__4_35 == null)
			{
				easeFunction = null;
				IntPtr method_ptr = (IntPtr)0;
				((Delegate)easeFunction).m_target = _003C_003Ec._003C_003E9;
				((Delegate)easeFunction).method = (IntPtr)__ldftn(_003C_003Ec._003CToEaseFunction_003Eb__4_35);
				((Delegate)easeFunction).method_ptr = method_ptr;
				_003C_003Ec._003C_003E9__4_35 = easeFunction;
			}
			return easeFunction;
		}

		[Token(Token = "0x60002F2")]
		[Address(RVA = "0x1074BE4", Offset = "0x1074BE4", Length = "0x10")]
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
