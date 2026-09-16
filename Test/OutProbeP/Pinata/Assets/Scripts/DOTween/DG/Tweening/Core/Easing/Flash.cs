using System;
using AssetRipperInjected;
using Cpp2ILInjected;
using UnityEngine;

namespace DG.Tweening.Core.Easing
{
	[Token(Token = "0x2000060")]
	public static class Flash
	{
		[Token(Token = "0x60002F5")]
		[Address(RVA = "0x10733D0", Offset = "0x10733D0", Length = "0xC8")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EE2428]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20269B1]) = v47;\nL_001F:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\nL_0025:\n\tv61 = time / duration;\n\tv62 = v61 * overshootOrAmplitude;\n\tv64 = UnityEngine.Mathf::CeilToInt(v62);\n\tv65 = v64 - 1;\n\tv66 = duration / overshootOrAmplitude;\n\tv68 = v66 * v65;\n\tv69 = v64 & 1;\n\tv71 = v69 == 0;\n\tv75 = time - v68;\n\tv77 = ~v71;\n\tif (v77) goto L_FFFFFFFF;\n\tgoto L_003B;\nL_003B:\n\tv85 = v75 - v66;\n\tv82 = ~v71;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tv86 = v80 * v85;\n\tv87 = v86 / v66;\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v64, v75, v80, v87);\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float Ease(float time, float duration, float overshootOrAmplitude, float period)
		{
			float num = time / duration;
			float f = num * overshootOrAmplitude;
			int num2 = Mathf.CeilToInt(f);
			int num3 = num2 - 1;
			float num4 = duration / overshootOrAmplitude;
			float num5 = num4 * (float)num3;
			int num6 = num2 & 1;
			bool flag = num6 == 0;
			float num7 = time - num5;
			float num8 = ((!flag) ? 1f : (-1f));
			float num9 = num7 - num4;
			if (!flag)
			{
				num9 = num7;
			}
			float num10 = num8 * num9;
			float res = num10 / num4;
			return WeightedEase(overshootOrAmplitude, period, num2, num7, num8, res);
		}

		[Token(Token = "0x60002F6")]
		[Address(RVA = "0x1073498", Offset = "0x1073498", Length = "0xCC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1ECACD8]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20269B2]) = v47;\nL_001F:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\nL_0025:\n\tv61 = time / duration;\n\tv62 = v61 * overshootOrAmplitude;\n\tv64 = UnityEngine.Mathf::CeilToInt(v62);\n\tv65 = v64 - 1;\n\tv66 = duration / overshootOrAmplitude;\n\tv68 = v66 * v65;\n\tv69 = v64 & 1;\n\tv71 = v69 == 0;\n\tv75 = time - v68;\n\tv77 = ~v71;\n\tif (v77) goto L_FFFFFFFF;\n\tgoto L_003B;\nL_003B:\n\tv85 = v75 - v66;\n\tv82 = ~v71;\n\tif (v82) goto L_FFFFFFFF;\n\tgoto L_0042;\nL_0042:\n\tv86 = v80 * v85;\n\tv87 = v86 / v66;\n\tv88 = v87 * v87;\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v64, v75, v80, v88);\n\treturn returnVal1;\n// 48 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseIn(float time, float duration, float overshootOrAmplitude, float period)
		{
			float num = time / duration;
			float f = num * overshootOrAmplitude;
			int num2 = Mathf.CeilToInt(f);
			int num3 = num2 - 1;
			float num4 = duration / overshootOrAmplitude;
			float num5 = num4 * (float)num3;
			int num6 = num2 & 1;
			bool flag = num6 == 0;
			float num7 = time - num5;
			float num8 = ((!flag) ? 1f : (-1f));
			float num9 = num7 - num4;
			if (!flag)
			{
				num9 = num7;
			}
			float num10 = num8 * num9;
			float num11 = num10 / num4;
			float res = num11 * num11;
			return WeightedEase(overshootOrAmplitude, period, num2, num7, num8, res);
		}

		[Token(Token = "0x60002F7")]
		[Address(RVA = "0x1073564", Offset = "0x1073564", Length = "0xD4")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1EC0D58]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20269B3]) = v47;\nL_001F:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\nL_0025:\n\tv61 = time / duration;\n\tv62 = v61 * overshootOrAmplitude;\n\tv64 = UnityEngine.Mathf::CeilToInt(v62);\n\tv65 = v64 - 1;\n\tv66 = v64 & 1;\n\tv68 = v66 == 0;\n\tv73 = duration / overshootOrAmplitude;\n\tv74 = ~v68;\n\tif (v74) goto L_FFFFFFFF;\n\tgoto L_0039;\nL_0039:\n\tv79 = v73 * v65;\n\tv85 = time - v79;\n\tv81 = v85 - v73;\n\tv82 = ~v68;\n\tif (v82) goto L_0042;\n\tgoto L_0042;\nL_0042:\n\tv86 = v77 * v85;\n\tv87 = v86 / v73;\n\tv89 = v87 + -2f;\n\tv90 = v87 * v89;\n\tv91 = -v90;\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v64, v81, v77, v91);\n\treturn returnVal1;\n// 49 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseOut(float time, float duration, float overshootOrAmplitude, float period)
		{
			float num = time / duration;
			float f = num * overshootOrAmplitude;
			int num2 = Mathf.CeilToInt(f);
			int num3 = num2 - 1;
			int num4 = num2 & 1;
			bool flag = num4 == 0;
			float num5 = duration / overshootOrAmplitude;
			float num6 = ((!flag) ? 1f : (-1f));
			float num7 = num5 * (float)num3;
			float num8 = time - num7;
			float num9 = num8 - num5;
			if (flag)
			{
				num8 = num9;
			}
			float num10 = num6 * num8;
			float num11 = num10 / num5;
			float num12 = num11 + -2f;
			float num13 = num11 * num12;
			float res = 0f - num13;
			return WeightedEase(overshootOrAmplitude, period, num2, num9, num6, res);
		}

		[Token(Token = "0x60002F8")]
		[Address(RVA = "0x1073638", Offset = "0x1073638", Length = "0x100")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_001F;\n\tv30 = *([1ED8BE8]);\n\tv31 = *([v30 @ X8_v10]);\n\tv32 = \"il2cpp_codegen_initialize_method\"(v31, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\n\tv47 = 0 | 1;\n\t*([20269B4]) = v47;\nL_001F:\n\tgoto L_0025;\n\tv54 = *([v50 @ X0_v2+E0]);\n\tv55 = v54 == 0;\n\tv56 = ~v55;\n\tgoto L_0025;\n\tv58 = \"il2cpp_codegen_runtime_class_init\"(v50, v33, v34, v35, v36, v37, v38, v39, time, duration, overshootOrAmplitude, period, v40, v41, v42, v43);\nL_0025:\n\tv61 = time / duration;\n\tv62 = v61 * overshootOrAmplitude;\n\tv64 = UnityEngine.Mathf::CeilToInt(v62);\n\tv65 = v64 - 1;\n\tv66 = duration / overshootOrAmplitude;\n\tv68 = v66 * v65;\n\tv69 = time - v68;\n\tv70 = v64 & 1;\n\tv72 = v70 == 0;\n\tv82 = v69 - v66;\n\tv79 = ~v72;\n\tif (v79) goto L_FFFFFFFF;\n\tgoto L_003D;\nL_003D:\n\tv83 = ~v72;\n\tif (v83) goto L_FFFFFFFF;\n\tgoto L_0043;\nL_0043:\n\tv87 = v86 * v82;\n\tv88 = v66 * 0.5f;\n\tv111 = v87 / v88;\n\tv99 = v111 >= 1f;\n\tif (v99) goto L_0054;\n\tv100 = v111 * 0.5f;\n\tv110 = v111 * v100;\n\tgoto L_0065;\nL_0054:\n\tv102 = v111 + -1f;\n\tv111 = v102 + -2f;\n\tv105 = v102 * v111;\n\tv106 = v105 + -1f;\n\tv110 = v106 * -0.5f;\nL_0065:\n\treturnVal1 = DG.Tweening.Core.Easing.Flash::WeightedEase(overshootOrAmplitude, period, v64, v111, v86, v110);\n\treturn returnVal1;\n// 60 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		public static float EaseInOut(float time, float duration, float overshootOrAmplitude, float period)
		{
			float num = time / duration;
			float f = num * overshootOrAmplitude;
			int num2 = Mathf.CeilToInt(f);
			int num3 = num2 - 1;
			float num4 = duration / overshootOrAmplitude;
			float num5 = num4 * (float)num3;
			float num6 = time - num5;
			int num7 = num2 & 1;
			bool flag = num7 == 0;
			float num8 = num6 - num4;
			if (!flag)
			{
				num8 = num6;
			}
			float num9 = ((!flag) ? 1f : (-1f));
			float num10 = num9 * num8;
			float num11 = num4 * 0.5f;
			float num12 = num10 / num11;
			float res;
			if (num12 < 1f)
			{
				float num13 = num12 * 0.5f;
				res = num12 * num13;
			}
			else
			{
				float num14 = num12 + -1f;
				num12 = num14 + -2f;
				float num15 = num14 * num12;
				float num16 = num15 + -1f;
				res = num16 * -0.5f;
			}
			return WeightedEase(overshootOrAmplitude, period, num2, num12, num9, res);
		}

		[Token(Token = "0x60002F9")]
		[Address(RVA = "0x1075A2C", Offset = "0x1075A2C", Length = "0x1AC")]
		[NativeSource(Body = "// Approximate reconstruction from native code. Reads as C#; does not compile.\n\tgoto L_0026;\n\tv34 = *([1EE6318]);\n\tv35 = *([v34 @ X8_v16]);\n\tv36 = \"il2cpp_codegen_initialize_method\"(v35, methodInfo, v38, v39, v40, v41, v42, v43, overshootOrAmplitude, period, stepDuration, dir, res, v45, v46, v47);\n\tv50 = 0 | 1;\n\t*([20269B5]) = v50;\nL_0026:\n\tv62 = dir <= 0;\n\tif (v62) goto L_0038;\n\tv64 = overshootOrAmplitude & 1;\n\tv65 = v64 == 0;\n\tv66 = ~v65;\n\tif (v66) goto L_0038;\n\tv93 = stepIndex + 1;\n\tgoto L_0048;\nL_0038:\n\tv78 = dir >= 0;\n\tif (v78) goto L_0048;\n\tv81 = overshootOrAmplitude & 1;\n\tv93 = v81 + stepIndex;\nL_0048:\n\tv106 = period <= 0;\n\tif (v106) goto L_0077;\n\tgoto L_0058;\n\tv115 = *([v109 @ X0_v4+E0]);\n\tv116 = v115 == 0;\n\tv117 = ~v116;\n\tif (v117) goto L_0058;\n\tv119 = \"il2cpp_codegen_runtime_class_init\"(v109, methodInfo, v38, v39, v40, v41, v42, v43, overshootOrAmplitude, period, stepDuration, dir, res, v45, v46, v47);\nL_0058:\n\tv124 = System.Math::Truncate(overshootOrAmplitude);\n\tv131 = overshootOrAmplitude - v124;\n\tv132 = 0x6D1F60(0, methodInfo, v38, v39, v40, v41, v42, v43, v124, 2f, stepDuration, dir, res, v45, v46, v47);\n\tv158 = v124 < 0;\n\tv156 = v124 == 0;\n\tv152 = v124 ^ v124;\n\tv150 = v124 & v152;\n\tv148 = v150 < 0;\n\tv209 = 1f - v131;\n\tv204 = v158 == v148;\n\tv138 = ~v156;\n\tv146 = v204 & v138;\n\tv135 = ~v146;\n\tif (v135) goto L_FFFFFFFF;\n\tgoto L_0072;\nL_0072:\n\tv210 = v209 * v93;\n\tv174 = v210 / overshootOrAmplitude;\n\tv142 = overshootOrAmplitude - v93;\n\tgoto L_007C;\nL_0077:\n\tv114 = period >= 0;\n\tif (v114) goto L_FFFFFFFF;\n\tv186 = -period;\nL_007C:\n\tv168 = v141 * res;\n\tv173 = v168 / overshootOrAmplitude;\n\tgoto L_0080;\nL_0080:\n\tv189 = v173 - res;\n\tv190 = v189 * v186;\n\tv191 = v174 + v190;\n\tv192 = v191 + res;\n\treturnVal1 = UnityEngine.Mathf::Min(v192, 1f);\n\treturn returnVal1;\n\tX0 = *([X0]);\n\treturn V0;\n\t*([X0]) = X1;\n\treturn V0;\n\tX0 = *([X0+4]);\n\treturn V0;\n\t*([X0+4]) = X1;\n\treturn V0;\n\tX0 = *([X0+8]);\n\treturn V0;\n\t*([X0+8]) = X1;\n\treturn V0;\n\tX0 = *([X0+C]);\n\treturn V0;\n\t*([X0+C]) = X1;\n\treturn V0;\n\tC = X1 < 3;\n\tC = ~C;\n\tTEMP1 = X1 - 3;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 3;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00C0;\n\tC = X1 < 2;\n\tC = ~C;\n\tTEMP1 = X1 - 2;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 2;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00C2;\n\tC = X1 < 1;\n\tC = ~C;\n\tTEMP1 = X1 - 1;\n\tN = TEMP1 < 0;\n\tTEMP2 = X1 ^ 1;\n\tTEMP3 = X1 ^ TEMP1;\n\tTEMP4 = TEMP2 & TEMP3;\n\tV = TEMP4 < 0;\n\tif (Z) goto L_00C3;\n\tX0 = X0 + 0xC;\n\tgoto L_00C3;\nL_00C0:\n\tX0 = X0 + 8;\n\tgoto L_00C3;\nL_00C2:\n\tX0 = X0 + 4;\nL_00C3:\n\tX8 = *([X0]);\n\tX8 = X8 + 1;\n\t*([X0]) = X8;\n\treturn V0;\n// 90 bookkeeping instructions omitted: flag registers, address bases and no-ops.\n")]
		private static float WeightedEase(float overshootOrAmplitude, float period, int stepIndex, float stepDuration, float dir, float res)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Expected O, but got Unknown
			//IL_0081: Unknown result type (might be due to invalid IL or missing references)
			//IL_0086: Expected O, but got Unknown
			//IL_00c8: Expected O, but got F8
			//IL_0104: Expected O, but got F8
			//IL_010d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0112: Expected I4, but got Unknown
			//IL_025d: Expected I4, but got F4
			int num;
			if (dir > 0f)
			{
				object obj = overshootOrAmplitude & 1;
				if (obj == null)
				{
					num = stepIndex + 1;
					goto IL_0204;
				}
			}
			bool flag = !(dir < 0f);
			num = stepIndex;
			if (!flag)
			{
				object obj2 = overshootOrAmplitude & 1;
				num = (int)((long)(IntPtr)obj2 + (long)stepIndex);
			}
			goto IL_0204;
			IL_0204:
			float num7;
			int num9;
			float num10;
			float num11;
			if (period > 0f)
			{
				double num2 = Math.Truncate(overshootOrAmplitude);
				float num3 = overshootOrAmplitude - (float)num2;
				object obj3 = num2 % 2.0;
				bool flag2 = num2 < 0.0;
				bool flag3 = num2 == 0.0;
				object obj4 = num2 ^ num2;
				int num4 = num2 & (long)(IntPtr)obj4;
				bool flag4 = num4 < 0;
				float num5 = 1f - num3;
				bool flag5 = flag2 == flag4;
				bool flag6 = !flag3;
				if (!(flag5 && flag6))
				{
					num5 = num3;
				}
				float num6 = num5 * (float)num;
				num7 = num6 / overshootOrAmplitude;
				float num8 = overshootOrAmplitude - (float)num;
				num9 = (int)num8;
				num10 = period;
			}
			else
			{
				if (!(period < 0f))
				{
					num11 = 0f;
					num7 = 0f;
					num10 = period;
					goto IL_026a;
				}
				num10 = 0f - period;
				num9 = num;
				num7 = 0f;
			}
			float num12 = (float)num9 * res;
			num11 = num12 / overshootOrAmplitude;
			goto IL_026a;
			IL_026a:
			float num13 = num11 - res;
			float num14 = num13 * num10;
			float num15 = num7 + num14;
			float a = num15 + res;
			return Mathf.Min(a, 1f);
		}
	}
}
